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
    public partial class SalesForm : Form
    {
        Clas.sales sal = new Clas.sales();

        public SalesForm()
        {
            InitializeComponent();
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // التحقق من أن جميع الحقول المطلوبة مملوءة
                if (string.IsNullOrWhiteSpace(txtSalesCode.Text) ||
                    string.IsNullOrWhiteSpace(txtPeriodId.Text) ||
                    string.IsNullOrWhiteSpace(txtCustomerId.Text) ||
                    numHours.Value <= 0 ||
                    numMinutes.Value <= 0 ||
                    numWaterHourPrice.Value <= 0 ||
                    numDieselHourPrice.Value <= 0 ||
                    numWaterTotal.Value <= 0 ||
                    numDieselTotal.Value <= 0 ||
                    numTotalAmount.Value <= 0 ||
                    numDueAmount.Value < 0 ||
                    numPaidAmount.Value < 0 ||
                    numRemainingAmount.Value < 0)
                {
                    MessageBox.Show("الرجاء إكمال جميع البيانات المطلوبة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // التحقق من أن وقت النهاية بعد وقت البداية
                if (dtpEndTime.Value < dtpStartTime.Value)
                {
                    MessageBox.Show("وقت النهاية يجب أن يكون بعد وقت البداية", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // استدعاء دالة إضافة المبيعات
                sal.ADD_SALES(
                    txtSalesCode.Text.Trim(),
                    txtPeriodId.Text.Trim(),
                    txtCustomerId.Text.Trim(),
                    dtpStartTime.Value,
                    dtpEndTime.Value,
                    (double)numHours.Value,
                    (double)numMinutes.Value,
                    (double)numWaterHourPrice.Value,
                    (double)numDieselHourPrice.Value,
                    (double)numWaterTotal.Value,
                    (double)numDieselTotal.Value,
                    (double)numTotalAmount.Value,
                    (double)numDueAmount.Value,
                    (double)numPaidAmount.Value,
                    (double)numRemainingAmount.Value
                );

                MessageBox.Show("تم حفظ بيانات الفاتورة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear_SALES();
            }
            catch (Exception ee)
            {
                MessageBox.Show("حدث خطأ أثناء الحفظ: " + ee.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clear_SALES()
        {
            txtSalesCode.Clear();
            txtPeriodId.Clear();
            txtCustomerId.Clear();
            dtpStartTime.Value = DateTime.Now;
            dtpEndTime.Value = DateTime.Now;
            numHours.Value = 0;
            numMinutes.Value = 0;
            numWaterHourPrice.Value = 0;
            numDieselHourPrice.Value = 0;
            numWaterTotal.Value = 0;
            numDieselTotal.Value = 0;
            numTotalAmount.Value = 0;
            numDueAmount.Value = 0;
            numPaidAmount.Value = 0;
            numRemainingAmount.Value = 0;
        }
    }
}

