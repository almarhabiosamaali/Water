using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Water
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // التحقق من الترخيص قبل تشغيل التطبيق
            if (!ValidateLicense())
            {
                // إذا فشل التحقق من الترخيص، يتم إغلاق التطبيق
                return;
            }

            // الترخيص صالح - تشغيل التطبيق
            Application.Run(new Form1());
        }

        /// <summary>
        /// التحقق من صحة الترخيص
        /// </summary>
        private static bool ValidateLicense()
        {
            try
            {
                // التحقق من الترخيص
                Clas.LicenseValidationResult validationResult = Clas.LicenseManager.ValidateLicense();

                if (validationResult.IsValid)
                {
                    // الترخيص صالح - يمكن المتابعة
                    return true;
                }
                else
                {
                    // الترخيص غير صالح - عرض شاشة الترخيص
                    LicenseForm licenseForm = new LicenseForm(validationResult.ErrorMessage, true);
                    licenseForm.StartPosition = FormStartPosition.CenterScreen;
                    
                    DialogResult result = licenseForm.ShowDialog();

                    // إذا اختار المستخدم الخروج أو ألغى
                    if (result == DialogResult.Cancel || result == DialogResult.None)
                    {
                        return false;
                    }

                    // إذا اختار موافق، نتحقق مرة أخرى (ربما قام باختيار ملف ترخيص جديد)
                    Clas.LicenseValidationResult retryResult = Clas.LicenseManager.ValidateLicense();
                    
                    if (retryResult.IsValid)
                    {
                        return true;
                    }
                    else
                    {
                        // لا يزال الترخيص غير صالح
                        MessageBox.Show(retryResult.ErrorMessage, "خطأ في الترخيص", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء التحقق من الترخيص: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
