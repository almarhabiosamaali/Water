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
    public partial class LoginForm : Form
    {
        Clas.user user = new Clas.user();
        public string LoggedInUserId { get; private set; }
        public string LoggedInUserName { get; private set; }
        public string LoggedInUserType { get; private set; }

        // اسم المستخدم وكلمة المرور الخاصة بفتح شاشة معلومات الجهاز
        private const string LICENSE_USERNAME = "license";
        private const string LICENSE_PASSWORD = "license123";

        public LoginForm()
        {
            InitializeComponent();
            // إخفاء الزر المخفي بشكل افتراضي
            btnLicenseStatus.Visible = false;
            
            // إضافة حدث للتحقق من إدخال اسم المستخدم وكلمة المرور
            txtUsername.TextChanged += TxtUsername_TextChanged;
            txtPassword.TextChanged += TxtPassword_TextChanged;
        }

        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {
            CheckAndShowHardwareInfoButton();
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            CheckAndShowHardwareInfoButton();
        }

        private void CheckAndShowHardwareInfoButton()
        {
            // التحقق من اسم المستخدم وكلمة المرور
            if (txtUsername.Text.Trim().ToLower() == LICENSE_USERNAME.ToLower() && 
                txtPassword.Text == LICENSE_PASSWORD)
            {
                btnLicenseStatus.Visible = true;
            }
            else
            {
                btnLicenseStatus.Visible = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    MessageBox.Show("يرجى إدخال اسم المستخدم", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("يرجى إدخال كلمة المرور", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }

                DataTable dt = user.LOGIN_USER(txtUsername.Text.Trim(), txtPassword.Text);

                if (dt != null && dt.Rows.Count > 0)
                {
                    // تسجيل الدخول ناجح
                    DataRow row = dt.Rows[0];
                    LoggedInUserId = row["ID"] != DBNull.Value ? row["ID"].ToString() : "";
                    LoggedInUserName = row["FullName"] != DBNull.Value ? row["FullName"].ToString() : "";
                    LoggedInUserType = row["UserType"] != DBNull.Value ? row["UserType"].ToString() : "";

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("اسم المستخدم أو كلمة المرور غير صحيحة", "خطأ في تسجيل الدخول", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تسجيل الدخول: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void btnHardwareInfo_Click(object sender, EventArgs e)
        {
            try
            {
                // فتح شاشة معلومات الجهاز
                HardwareInfoForm hardwareInfoForm = new HardwareInfoForm();
                hardwareInfoForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في فتح شاشة معلومات الجهاز: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLicenseStatus_Click(object sender, EventArgs e)
        {
            try
            {
                // فتح شاشة حالة الترخيص
                LicenseForm licenseForm = new LicenseForm("", true);
                licenseForm.StartPosition = FormStartPosition.CenterParent;
                licenseForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في فتح شاشة حالة الترخيص: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
