using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Water.Clas
{
    public class CryptoHelper
    {
        // مفتاح التشفير الثابت (يجب أن يكون 32 بايت لـ AES-256)
        // في الإنتاج الحقيقي، يجب تخزين هذا المفتاح بشكل آمن
        private static readonly string EncryptionKeyString = "WaterLicenseKey2024!@#$%^&*()ABCDEF";

        /// <summary>
        /// توليد مفتاح تشفير ثابت من 32 بايت باستخدام SHA256
        /// </summary>
        private static byte[] GetEncryptionKey()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] keyBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(EncryptionKeyString));
                return keyBytes; // SHA256 يعطي بالضبط 32 بايت
            }
        }

        /// <summary>
        /// تشفير النص باستخدام AES-256
        /// </summary>
        public static string Encrypt(string plainText)
        {
            try
            {
                if (string.IsNullOrEmpty(plainText))
                {
                    return string.Empty;
                }

                //byte[] keyBytes = Encoding.UTF8.GetBytes(EncryptionKey);
                byte[] keyBytes = GetEncryptionKey();
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = keyBytes;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;
                    aes.GenerateIV();

                    using (ICryptoTransform encryptor = aes.CreateEncryptor())
                    {
                        byte[] encryptedBytes = encryptor.TransformFinalBlock(plainTextBytes, 0, plainTextBytes.Length);
                        
                        // دمج IV مع البيانات المشفرة
                        byte[] result = new byte[aes.IV.Length + encryptedBytes.Length];
                        Array.Copy(aes.IV, 0, result, 0, aes.IV.Length);
                        Array.Copy(encryptedBytes, 0, result, aes.IV.Length, encryptedBytes.Length);

                        return Convert.ToBase64String(result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"خطأ في التشفير: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// فك تشفير النص المشفر باستخدام AES-256
        /// </summary>
        public static string Decrypt(string cipherText)
        {
            try
            {
                if (string.IsNullOrEmpty(cipherText))
                {
                    return string.Empty;
                }

                //byte[] keyBytes = Encoding.UTF8.GetBytes(EncryptionKey);
                byte[] keyBytes = GetEncryptionKey();
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = keyBytes;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    // استخراج IV من بداية البيانات
                    byte[] iv = new byte[aes.BlockSize / 8];
                    byte[] encryptedData = new byte[cipherTextBytes.Length - iv.Length];
                    
                    Array.Copy(cipherTextBytes, 0, iv, 0, iv.Length);
                    Array.Copy(cipherTextBytes, iv.Length, encryptedData, 0, encryptedData.Length);

                    aes.IV = iv;

                    using (ICryptoTransform decryptor = aes.CreateDecryptor())
                    {
                        byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
                        return Encoding.UTF8.GetString(decryptedBytes);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"خطأ في فك التشفير: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// تشفير ملف
        /// </summary>
        public static bool EncryptFile(string inputFile, string outputFile)
        {
            try
            {
                if (!File.Exists(inputFile))
                {
                    throw new FileNotFoundException($"الملف غير موجود: {inputFile}");
                }

                string plainText = File.ReadAllText(inputFile, Encoding.UTF8);
                string encryptedText = Encrypt(plainText);
                File.WriteAllText(outputFile, encryptedText, Encoding.UTF8);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"خطأ في تشفير الملف: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// فك تشفير ملف
        /// </summary>
        public static bool DecryptFile(string inputFile, string outputFile)
        {
            try
            {
                if (!File.Exists(inputFile))
                {
                    throw new FileNotFoundException($"الملف غير موجود: {inputFile}");
                }

                string encryptedText = File.ReadAllText(inputFile, Encoding.UTF8);
                string decryptedText = Decrypt(encryptedText);
                File.WriteAllText(outputFile, decryptedText, Encoding.UTF8);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"خطأ في فك تشفير الملف: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// توليد Hash من النص (للتوقيع)
        /// </summary>
        public static string GenerateHash(string text)
        {
            try
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                    return BitConverter.ToString(hashBytes).Replace("-", "").ToUpper();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"خطأ في توليد Hash: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// التحقق من صحة التوقيع
        /// </summary>
        public static bool VerifySignature(string data, string signature)
        {
            try
            {
                string computedHash = GenerateHash(data);
                return computedHash.Equals(signature, StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }
    }
}

