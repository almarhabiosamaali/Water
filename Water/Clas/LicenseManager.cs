using System;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace Water.Clas
{
    public class LicenseInfo
    {
        public string HardwareID { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime IssueDate { get; set; }
        public string Signature { get; set; }
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class LicenseManager
    {
        private static readonly string LicenseFileName = "license.lic";
        private static readonly string LicenseFilePath = Path.Combine(Application.StartupPath, LicenseFileName);

        /// <summary>
        /// الحصول على مسار ملف الترخيص
        /// </summary>
        public static string GetLicenseFilePath()
        {
            return LicenseFilePath;
        }

        /// <summary>
        /// التحقق من وجود ملف الترخيص
        /// </summary>
        public static bool LicenseFileExists()
        {
            return File.Exists(LicenseFilePath);
        }

        /// <summary>
        /// قراءة ملف الترخيص وفك التشفير
        /// </summary>
        public static LicenseInfo ReadLicense()
        {
            LicenseInfo licenseInfo = new LicenseInfo
            {
                IsValid = false
            };

            try
            {
                if (!LicenseFileExists())
                {
                    licenseInfo.ErrorMessage = "لم يتم العثور على ملف الترخيص";
                    return licenseInfo;
                }

                // قراءة الملف المشفر
                string encryptedContent = File.ReadAllText(LicenseFilePath, System.Text.Encoding.UTF8);

                if (string.IsNullOrEmpty(encryptedContent))
                {
                    licenseInfo.ErrorMessage = "ملف الترخيص فارغ";
                    return licenseInfo;
                }

                // فك التشفير
                string decryptedContent = CryptoHelper.Decrypt(encryptedContent);

                // قراءة XML
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(decryptedContent);

                // استخراج البيانات
                XmlNode hardwareIdNode = doc.SelectSingleNode("//License/HardwareID");
                XmlNode expiryDateNode = doc.SelectSingleNode("//License/ExpiryDate");
                XmlNode issueDateNode = doc.SelectSingleNode("//License/IssueDate");
                XmlNode signatureNode = doc.SelectSingleNode("//License/Signature");

                if (hardwareIdNode == null || expiryDateNode == null || issueDateNode == null)
                {
                    licenseInfo.ErrorMessage = "ملف الترخيص تالف أو غير صحيح";
                    return licenseInfo;
                }

                licenseInfo.HardwareID = hardwareIdNode.InnerText;
                licenseInfo.ExpiryDate = DateTime.Parse(expiryDateNode.InnerText);
                licenseInfo.IssueDate = DateTime.Parse(issueDateNode.InnerText);
                licenseInfo.Signature = signatureNode?.InnerText ?? "";

                return licenseInfo;
            }
            catch (Exception ex)
            {
                licenseInfo.ErrorMessage = $"خطأ في قراءة ملف الترخيص: {ex.Message}";
                return licenseInfo;
            }
        }

        /// <summary>
        /// التحقق من صحة الترخيص
        /// </summary>
        public static LicenseValidationResult ValidateLicense()
        {
            LicenseValidationResult result = new LicenseValidationResult
            {
                IsValid = false,
                ErrorMessage = ""
            };

            try
            {
                // التحقق من وجود ملف الترخيص
                if (!LicenseFileExists())
                {
                    result.ErrorMessage = "لم يتم العثور على ملف الترخيص. يرجى التواصل مع الموزع للحصول على ترخيص صالح.";
                    return result;
                }

                // قراءة الترخيص
                LicenseInfo licenseInfo = ReadLicense();

                if (!string.IsNullOrEmpty(licenseInfo.ErrorMessage))
                {
                    result.ErrorMessage = licenseInfo.ErrorMessage;
                    return result;
                }

                // التحقق من Hardware ID
                string currentHardwareID = HardwareInfo.GenerateHardwareID();
                if (string.IsNullOrEmpty(currentHardwareID) || currentHardwareID == "ERROR")
                {
                    result.ErrorMessage = "خطأ في جلب معلومات الجهاز";
                    return result;
                }

                if (!currentHardwareID.Equals(licenseInfo.HardwareID, StringComparison.OrdinalIgnoreCase))
                {
                    result.ErrorMessage = "الترخيص غير صالح لهذا الجهاز. يرجى التواصل مع الموزع.";
                    return result;
                }

                // التحقق من تاريخ الانتهاء
                if (DateTime.Now > licenseInfo.ExpiryDate)
                {
                    result.ErrorMessage = $"انتهت صلاحية الترخيص في تاريخ {licenseInfo.ExpiryDate:yyyy-MM-dd}. يرجى التواصل مع الموزع لتجديد الترخيص.";
                    return result;
                }

                // التحقق من التوقيع (اختياري - للتحقق الإضافي)
                if (!string.IsNullOrEmpty(licenseInfo.Signature))
                {
                    string dataToVerify = $"{licenseInfo.HardwareID}-{licenseInfo.ExpiryDate:yyyy-MM-dd}-{licenseInfo.IssueDate:yyyy-MM-dd}";
                    if (!CryptoHelper.VerifySignature(dataToVerify, licenseInfo.Signature))
                    {
                        result.ErrorMessage = "ملف الترخيص تالف أو تم التلاعب به";
                        return result;
                    }
                }

                // كل شيء صحيح
                result.IsValid = true;
                result.ExpiryDate = licenseInfo.ExpiryDate;
                result.DaysRemaining = (licenseInfo.ExpiryDate - DateTime.Now).Days;
                result.ErrorMessage = "";

                return result;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = $"خطأ في التحقق من الترخيص: {ex.Message}";
                return result;
            }
        }

        /// <summary>
        /// كتابة ملف الترخيص (لنظام الترخيص)
        /// </summary>
        public static bool WriteLicense(string hardwareID, DateTime expiryDate, string outputPath = null)
        {
            try
            {
                if (string.IsNullOrEmpty(hardwareID))
                {
                    throw new ArgumentException("Hardware ID مطلوب");
                }

                DateTime issueDate = DateTime.Now;

                // إنشاء XML
                XmlDocument doc = new XmlDocument();
                XmlElement root = doc.CreateElement("License");
                doc.AppendChild(root);

                XmlElement hardwareIdElement = doc.CreateElement("HardwareID");
                hardwareIdElement.InnerText = hardwareID;
                root.AppendChild(hardwareIdElement);

                XmlElement expiryDateElement = doc.CreateElement("ExpiryDate");
                expiryDateElement.InnerText = expiryDate.ToString("yyyy-MM-dd HH:mm:ss");
                root.AppendChild(expiryDateElement);

                XmlElement issueDateElement = doc.CreateElement("IssueDate");
                issueDateElement.InnerText = issueDate.ToString("yyyy-MM-dd HH:mm:ss");
                root.AppendChild(issueDateElement);

                // توليد التوقيع
                string dataToSign = $"{hardwareID}-{expiryDate:yyyy-MM-dd}-{issueDate:yyyy-MM-dd}";
                string signature = CryptoHelper.GenerateHash(dataToSign);

                XmlElement signatureElement = doc.CreateElement("Signature");
                signatureElement.InnerText = signature;
                root.AppendChild(signatureElement);

                // تحويل XML إلى نص
                string xmlContent = doc.OuterXml;

                // تشفير المحتوى
                string encryptedContent = CryptoHelper.Encrypt(xmlContent);

                // تحديد مسار الحفظ
                string filePath = outputPath ?? LicenseFilePath;

                // حفظ الملف
                File.WriteAllText(filePath, encryptedContent, System.Text.Encoding.UTF8);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في كتابة ملف الترخيص: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// حذف ملف الترخيص
        /// </summary>
        public static bool DeleteLicense()
        {
            try
            {
                if (LicenseFileExists())
                {
                    File.Delete(LicenseFilePath);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في حذف ملف الترخيص: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }

    /// <summary>
    /// نتيجة التحقق من الترخيص
    /// </summary>
    public class LicenseValidationResult
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int DaysRemaining { get; set; }
    }
}

