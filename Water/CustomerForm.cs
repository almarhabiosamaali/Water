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
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }
        Clas.customer cus = new Clas.customer();
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // التحقق من أن جميع الحقول مملوءة
                if (string.IsNullOrWhiteSpace(txtCustomerCode.Text) ||
                    string.IsNullOrWhiteSpace(txtCustomerName.Text) ||
                    cmbType.SelectedIndex == -1 ||
                    numAllocatedHours.Value <= 0 ||
                    numMinutes.Value <= 0 ||
                    string.IsNullOrWhiteSpace(txtPhone.Text) ||
                    string.IsNullOrWhiteSpace(txtNotes.Text))
                {
                    MessageBox.Show("الرجاء إكمال جميع البيانات المطلوبة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // استدعاء دالة إضافة العميل
                cus.ADD_CUSTOMER(
                    txtCustomerCode.Text.Trim(),
                    txtCustomerName.Text.Trim(),
                    cmbType.SelectedItem.ToString(),
                    (int)numAllocatedHours.Value,
                    (int)numMinutes.Value,
                    txtPhone.Text.Trim(),
                    txtNotes.Text.Trim()
                );

                MessageBox.Show("تم حفظ بيانات العميل بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear_CUSTOMER();
            }
            catch (Exception ee)
            {
                MessageBox.Show("حدث خطأ أثناء الحفظ: " + ee.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clear_CUSTOMER()
        {
            txtCustomerCode.Clear();
            txtCustomerName.Clear();
            cmbType.SelectedIndex = -1;
            numAllocatedHours.Value = 0;
            numMinutes.Value = 0;
            txtPhone.Clear();
            txtNotes.Clear();
        }
    }
}

