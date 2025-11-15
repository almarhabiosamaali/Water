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
    public partial class AccountForm : Form
    {
        Clas.account acc = new Clas.account();

        public AccountForm()
        {
            InitializeComponent();
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // التحقق من أن جميع الحقول مملوءة
                if (string.IsNullOrWhiteSpace(txtAccountCode.Text) ||
                    string.IsNullOrWhiteSpace(txtAccountName.Text) ||
                    string.IsNullOrWhiteSpace(txtNotes.Text))
                {
                    MessageBox.Show("الرجاء إكمال جميع البيانات المطلوبة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // استدعاء دالة إضافة الحساب
                acc.ADD_ACCOUNT(
                    txtAccountCode.Text.Trim(),
                    txtAccountName.Text.Trim(),
                    txtNotes.Text.Trim()
                );

                MessageBox.Show("تم حفظ بيانات الحساب بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear_ACCOUNT();
            }
            catch (Exception ee)
            {
                MessageBox.Show("حدث خطأ أثناء الحفظ: " + ee.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clear_ACCOUNT()
        {
            txtAccountCode.Clear();
            txtAccountName.Clear();
            txtNotes.Clear();
        }
    }
}

