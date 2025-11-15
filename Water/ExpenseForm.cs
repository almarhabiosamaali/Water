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
    public partial class ExpenseForm : Form
    {
        Clas.expense exp = new Clas.expense();

        public ExpenseForm()
        {
            InitializeComponent();
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // التحقق من أن جميع الحقول مملوءة
                if (string.IsNullOrWhiteSpace(txtExpenseCode.Text) ||
                    cmbType.SelectedIndex == -1 ||
                    cmbAccountType.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(txtAccountId.Text) ||
                    string.IsNullOrWhiteSpace(txtAccountName.Text) ||
                    numAmount.Value <= 0 ||
                    string.IsNullOrWhiteSpace(txtPeriodId.Text) ||
                    string.IsNullOrWhiteSpace(txtDescription.Text) ||
                    string.IsNullOrWhiteSpace(txtNotes.Text))
                {
                    MessageBox.Show("الرجاء إكمال جميع البيانات المطلوبة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // استدعاء دالة إضافة القيد
                exp.ADD_EXPENSE(
                    txtExpenseCode.Text.Trim(),
                    dtpDate.Value.Date,
                    cmbType.SelectedItem.ToString(),
                    cmbAccountType.SelectedItem.ToString(),
                    txtAccountId.Text.Trim(),
                    txtAccountName.Text.Trim(),
                    (double)numAmount.Value,
                    txtPeriodId.Text.Trim(),
                    txtDescription.Text.Trim(),
                    txtNotes.Text.Trim()
                );

                MessageBox.Show("تم حفظ بيانات القيد بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear_EXPENSE();
            }
            catch (Exception ee)
            {
                MessageBox.Show("حدث خطأ أثناء الحفظ: " + ee.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clear_EXPENSE()
        {
            txtExpenseCode.Clear();
            dtpDate.Value = DateTime.Now;
            cmbType.SelectedIndex = -1;
            cmbAccountType.SelectedIndex = -1;
            txtAccountId.Clear();
            txtAccountName.Clear();
            numAmount.Value = 0;
            txtPeriodId.Clear();
            txtDescription.Clear();
            txtNotes.Clear();
        }
    }
}

