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
    public partial class PeriodForm : Form
    {
        Clas.period per = new Clas.period();

        public PeriodForm()
        {
            InitializeComponent();
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // التحقق من أن جميع الحقول مملوءة
                if (string.IsNullOrWhiteSpace(txtPeriodCode.Text) ||
                    numBaseDays.Value <= 0 ||
                    string.IsNullOrWhiteSpace(txtDowntimeHours.Text) ||
                    numExtendedDays.Value <= 0 ||
                    numTotalHours.Value <= 0)
                {
                    MessageBox.Show("الرجاء إكمال جميع البيانات المطلوبة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // التحقق من أن تاريخ النهاية بعد تاريخ البداية
                if (dtpEndDate.Value < dtpStartDate.Value)
                {
                    MessageBox.Show("تاريخ النهاية يجب أن يكون بعد تاريخ البداية", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // استدعاء دالة إضافة الفترة
                per.ADD_PERIOD(
                    txtPeriodCode.Text.Trim(),
                    dtpStartDate.Value,
                    dtpEndDate.Value,
                    (int)numBaseDays.Value,
                    txtDowntimeHours.Text.Trim(),
                    (int)numExtendedDays.Value,
                    (double)numTotalHours.Value
                );

                MessageBox.Show("تم حفظ بيانات الفترة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear_PERIOD();
            }
            catch (Exception ee)
            {
                MessageBox.Show("حدث خطأ أثناء الحفظ: " + ee.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clear_PERIOD()
        {
            txtPeriodCode.Clear();
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;
            numBaseDays.Value = 0;
            txtDowntimeHours.Clear();
            numExtendedDays.Value = 0;
            numTotalHours.Value = 0;
        }
    }
}

