using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Security.Cryptography;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace Water.Clas
{
    public class HardwareInfo
    {
        /// <summary>
        /// جلب Processor ID
        /// </summary>
        public static string GetProcessorId()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor");
                foreach (ManagementObject obj in searcher.Get())
                {
                    return obj["ProcessorId"]?.ToString() ?? "UNKNOWN";
                }
            }
            catch
            {
                return "UNKNOWN";
            }
            return "UNKNOWN";
        }

        /// <summary>
        /// جلب Motherboard Serial Number
        /// </summary>
        public static string GetMotherboardSerial()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard");
                foreach (ManagementObject obj in searcher.Get())
                {
                    string serial = obj["SerialNumber"]?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(serial) && serial != "To be filled by O.E.M.")
                    {
                        return serial;
                    }
                }
            }
            catch
            {
            }
            return "UNKNOWN";
        }

        /// <summary>
        /// جلب Hard Disk Serial Number
        /// </summary>
        public static string GetDiskSerial()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_DiskDrive WHERE MediaType='Fixed hard disk media'");
                foreach (ManagementObject obj in searcher.Get())
                {
                    string serial = obj["SerialNumber"]?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(serial))
                    {
                        return serial.Trim();
                    }
                }
            }
            catch
            {
            }
            return "UNKNOWN";
        }

        /// <summary>
        /// جلب MAC Address
        /// </summary>
        public static string GetMACAddress()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT MACAddress FROM Win32_NetworkAdapter WHERE MACAddress IS NOT NULL AND PNPDeviceID IS NOT NULL");
                foreach (ManagementObject obj in searcher.Get())
                {
                    string mac = obj["MACAddress"]?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(mac))
                    {
                        return mac;
                    }
                }
            }
            catch
            {
            }
            return "UNKNOWN";
        }

        /// <summary>
        /// جلب Machine Name
        /// </summary>
        public static string GetMachineName()
        {
            try
            {
                return Environment.MachineName;
            }
            catch
            {
                return "UNKNOWN";
            }
        }

        /// <summary>
        /// توليد Hardware ID فريد من معلومات الجهاز
        /// </summary>
        public static string GenerateHardwareID()
        {
            try
            {
                string processorId = GetProcessorId();
                string motherboardSerial = GetMotherboardSerial();
                string diskSerial = GetDiskSerial();
                string macAddress = GetMACAddress();

                // دمج المعلومات
                string combinedInfo = $"{processorId}-{motherboardSerial}-{diskSerial}-{macAddress}";

                // توليد Hash من المعلومات المدمجة
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combinedInfo));
                    string hashString = BitConverter.ToString(hashBytes).Replace("-", "");

                    // أخذ أول 32 حرف وتنسيقها بشكل أفضل
                    string hardwareId = hashString.Substring(0, Math.Min(32, hashString.Length));
                    
                    // تنسيق كـ XXXXX-XXXXX-XXXXX-XXXXX
                    StringBuilder formatted = new StringBuilder();
                    for (int i = 0; i < hardwareId.Length; i += 5)
                    {
                        if (i > 0) formatted.Append("-");
                        int length = Math.Min(5, hardwareId.Length - i);
                        formatted.Append(hardwareId.Substring(i, length));
                    }

                    return formatted.ToString().ToUpper();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في توليد Hardware ID: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "ERROR";
            }
        }

        /// <summary>
        /// جلب جميع معلومات الجهاز
        /// </summary>
        public static Dictionary<string, string> GetAllHardwareInfo()
        {
            Dictionary<string, string> info = new Dictionary<string, string>();
            
            info["HardwareID"] = GenerateHardwareID();
            info["MachineName"] = GetMachineName();
            info["ProcessorID"] = GetProcessorId();
            info["MotherboardSerial"] = GetMotherboardSerial();
            info["DiskSerial"] = GetDiskSerial();
            info["MACAddress"] = GetMACAddress();
            info["GeneratedDate"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            return info;
        }

        /// <summary>
        /// حفظ معلومات الجهاز في ملف XML
        /// </summary>
        public static bool SaveHardwareInfoToFile(string filePath)
        {
            try
            {
                Dictionary<string, string> info = GetAllHardwareInfo();

                using (XmlWriter writer = XmlWriter.Create(filePath, new XmlWriterSettings { Indent = true, Encoding = Encoding.UTF8 }))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("HardwareInfo");

                    foreach (var item in info)
                    {
                        writer.WriteElementString(item.Key, item.Value);
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في حفظ ملف معلومات الجهاز: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// قراءة Hardware ID من ملف XML
        /// </summary>
        public static string ReadHardwareIDFromFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    return null;
                }

                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);

                XmlNode hardwareIdNode = doc.SelectSingleNode("//HardwareID");
                if (hardwareIdNode != null)
                {
                    return hardwareIdNode.InnerText;
                }

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في قراءة ملف معلومات الجهاز: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// قراءة جميع معلومات الجهاز من ملف XML
        /// </summary>
        public static Dictionary<string, string> ReadHardwareInfoFromFile(string filePath)
        {
            Dictionary<string, string> info = new Dictionary<string, string>();

            try
            {
                if (!File.Exists(filePath))
                {
                    return info;
                }

                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);

                XmlNodeList nodes = doc.SelectNodes("//HardwareInfo/*");
                if (nodes != null)
                {
                    foreach (XmlNode node in nodes)
                    {
                        info[node.Name] = node.InnerText;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في قراءة ملف معلومات الجهاز: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return info;
        }
    }
}

