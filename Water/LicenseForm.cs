using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Water
{
    public partial class LicenseForm : Form
    {
        private string errorMessage;
        private bool showHardwareInfoOption;

        public LicenseForm(string errorMessage = "", bool showHardwareInfoOption = false)
        {
            InitializeComponent();
            this.errorMessage = errorMessage;
            this.showHardwareInfoOption = showHardwareInfoOption;
        }

        private void LicenseForm_Load(object sender, EventArgs e)
        {
            LoadLicenseInfo();
        }

        private void LoadLicenseInfo()
        {
            try
            {
                // عرض رسالة الخطأ إن وجدت
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    txtMessage.Text = errorMessage;
                    txtMessage.ForeColor = Color.Red;
                }
                else
                {
                    // محاولة قراءة معلومات الترخيص
                    Clas.LicenseInfo licenseInfo = Clas.LicenseManager.ReadLicense();
                    
                    if (licenseInfo != null && string.IsNullOrEmpty(licenseInfo.ErrorMessage))
                    {
                        // عرض معلومات الترخيص
                        txtHardwareID.Text = licenseInfo.HardwareID;
                        txtExpiryDate.Text = licenseInfo.ExpiryDate.ToString("yyyy-MM-dd");
                        txtIssueDate.Text = licenseInfo.IssueDate.ToString("yyyy-MM-dd");
                        
                        int daysRemaining = (licenseInfo.ExpiryDate - DateTime.Now).Days;
                        if (daysRemaining > 0)
                        {
                            txtMessage.Text = $"الترخيص صالح. متبقي {daysRemaining} يوم.";
                            txtMessage.ForeColor = Color.Green;
                        }
                        else
                        {
                            txtMessage.Text = "انتهت صلاحية الترخيص.";
                            txtMessage.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        txtMessage.Text = licenseInfo?.ErrorMessage ?? "لم يتم العثور على ترخيص صالح.";
                        txtMessage.ForeColor = Color.Red;
                    }
                }

                // إظهار/إخفاء زر معلومات الجهاز
                btnGenerateHardwareInfo.Visible = showHardwareInfoOption;
            }
            catch (Exception ex)
            {
                txtMessage.Text = $"خطأ في قراءة معلومات الترخيص: {ex.Message}";
                txtMessage.ForeColor = Color.Red;
            }
        }

        private void btnGenerateHardwareInfo_Click(object sender, EventArgs e)
        {
            try
            {
                HardwareInfoForm hardwareInfoForm = new HardwareInfoForm();
                hardwareInfoForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في فتح شاشة معلومات الجهاز: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelectLicenseFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "License Files (*.lic)|*.lic|All Files (*.*)|*.*";
                openFileDialog.Title = "اختر ملف الترخيص";
                openFileDialog.FileName = "license.lic";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string sourcePath = openFileDialog.FileName;
                    string destinationPath = Clas.LicenseManager.GetLicenseFilePath();

                    try
                    {
                        // نسخ الملف إلى مجلد التطبيق
                        System.IO.File.Copy(sourcePath, destinationPath, true);

                        MessageBox.Show("تم نسخ ملف الترخيص بنجاح. يرجى إعادة تشغيل التطبيق.", 
                            "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // إعادة تحميل معلومات الترخيص
                        LoadLicenseInfo();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"خطأ في نسخ ملف الترخيص: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في اختيار ملف الترخيص: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSetServer_Click(object sender, EventArgs e)
        {
            SetServer ss = new SetServer();
            ss.ShowDialog();
        }
    }
}

