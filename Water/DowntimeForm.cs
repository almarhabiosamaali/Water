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
    public partial class DowntimeForm : Form
    {
        private bool isEditMode = false;
        Clas.downtime dwn = new Clas.downtime();

        public DowntimeForm()
        {
            InitializeComponent();
            btnView.Click += btnView_Click;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnSave.Click += btnSave_Click;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = dwn.GET_ALL_DOWNTIMES();
                
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات للعرض", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Form viewForm = new Form();
                viewForm.Text = "عرض التوقفات";
                viewForm.RightToLeft = RightToLeft.Yes;
                viewForm.RightToLeftLayout = true;
                viewForm.Size = new Size(900, 500);
                viewForm.StartPosition = FormStartPosition.CenterScreen;

                DataGridView dgv = new DataGridView();
                dgv.Dock = DockStyle.Fill;
                dgv.DataSource = dt;
                dgv.ReadOnly = true;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.MultiSelect = false;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.RightToLeft = RightToLeft.Yes;

                dgv.CellDoubleClick += (s, args) =>
                {
                    if (args.RowIndex >= 0)
                    {
                        DataRow row = dt.Rows[args.RowIndex];
                        LoadDowntimeData(row);
                        viewForm.Close();
                    }
                };

                viewForm.Controls.Add(dgv);
                viewForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء عرض البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isEditMode = false;
            clear_DOWNTIME();
            txtDowntimeCode.Enabled = true;
            btnSave.Text = "حفظ";
            MessageBox.Show("يمكنك الآن إدخال بيانات توقف جديد", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDowntimeCode.Text))
            {
                MessageBox.Show("الرجاء إدخال كود التوقف أو اختيار توقف من قائمة العرض", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable dt = dwn.VIEW_DOWNTIME(txtDowntimeCode.Text.Trim());
                
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("التوقف غير موجود", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LoadDowntimeData(dt.Rows[0]);
                isEditMode = true;
                txtDowntimeCode.Enabled = false;
                btnSave.Text = "تحديث";
                MessageBox.Show("يمكنك الآن تعديل بيانات التوقف", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDowntimeCode.Text))
            {
                MessageBox.Show("الرجاء إدخال كود التوقف المراد حذفه", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "هل أنت متأكد من حذف التوقف: " + txtDowntimeCode.Text + "؟",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    dwn.DELETE_DOWNTIME(txtDowntimeCode.Text.Trim());
                    MessageBox.Show("تم حذف التوقف بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_DOWNTIME();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("حدث خطأ أثناء الحذف: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // التحقق من أن الحقول الأساسية مملوءة
                if (string.IsNullOrWhiteSpace(txtDowntimeCode.Text))
                {
                    MessageBox.Show("الرجاء إدخال كود التوقف", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // تحضير القيم الاختيارية
                int? dayesCount = numDayesCount.Value > 0 ? (int?)numDayesCount.Value : null;
                int? hours = numHours.Value > 0 ? (int?)numHours.Value : null;
                int? minutes = numMinutes.Value > 0 ? (int?)numMinutes.Value : null;
                DateTime? startTime = dtpStartTime.Checked ? (DateTime?)dtpStartTime.Value : null;
                DateTime? endTime = dtpEndTime.Checked ? (DateTime?)dtpEndTime.Value : null;
                double? amount = numAmount.Value > 0 ? (double?)numAmount.Value : null;
                string note = !string.IsNullOrWhiteSpace(txtNote.Text) ? txtNote.Text.Trim() : null;
                string periodId = !string.IsNullOrWhiteSpace(txtPeriodId.Text) ? txtPeriodId.Text.Trim() : null;

                if (isEditMode)
                {
                    // تحديث بيانات التوقف
                    dwn.UPDATE_DOWNTIME(
                        txtDowntimeCode.Text.Trim(),
                        periodId,
                        dtpDate.Value.Date,
                        dayesCount,
                        hours,
                        minutes,
                        startTime,
                        endTime,
                        amount,
                        note
                    );

                    MessageBox.Show("تم تحديث بيانات التوقف بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // إضافة توقف جديد
                    dwn.ADD_DOWNTIME(
                        txtDowntimeCode.Text.Trim(),
                        periodId,
                        dtpDate.Value.Date,
                        dayesCount,
                        hours,
                        minutes,
                        startTime,
                        endTime,
                        amount,
                        note
                    );

                    MessageBox.Show("تم حفظ بيانات التوقف بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                clear_DOWNTIME();
                isEditMode = false;
                txtDowntimeCode.Enabled = true;
                btnSave.Text = "حفظ";
            }
            catch (Exception ee)
            {
                MessageBox.Show("حدث خطأ أثناء الحفظ: " + ee.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDowntimeData(DataRow row)
        {
            txtDowntimeCode.Text = row["id"].ToString();
            
            if (row["period_id"] != DBNull.Value)
            {
                txtPeriodId.Text = row["period_id"].ToString();
            }
            else
            {
                txtPeriodId.Clear();
            }
            
            if (row["date"] != DBNull.Value)
            {
                dtpDate.Value = Convert.ToDateTime(row["date"]);
            }

            if (row["dayesCount"] != DBNull.Value)
            {
                numDayesCount.Value = Convert.ToDecimal(row["dayesCount"]);
            }
            else
            {
                numDayesCount.Value = 0;
            }

            if (row["hours"] != DBNull.Value)
            {
                numHours.Value = Convert.ToDecimal(row["hours"]);
            }
            else
            {
                numHours.Value = 0;
            }

            if (row["minutes"] != DBNull.Value)
            {
                numMinutes.Value = Convert.ToDecimal(row["minutes"]);
            }
            else
            {
                numMinutes.Value = 0;
            }

            if (row["startTime"] != DBNull.Value)
            {
                dtpStartTime.Value = Convert.ToDateTime(row["startTime"]);
                dtpStartTime.Checked = true;
            }
            else
            {
                dtpStartTime.Checked = false;
            }

            if (row["endTime"] != DBNull.Value)
            {
                dtpEndTime.Value = Convert.ToDateTime(row["endTime"]);
                dtpEndTime.Checked = true;
            }
            else
            {
                dtpEndTime.Checked = false;
            }

            if (row["amount"] != DBNull.Value)
            {
                numAmount.Value = Convert.ToDecimal(row["amount"]);
            }
            else
            {
                numAmount.Value = 0;
            }

            if (row["note"] != DBNull.Value)
            {
                txtNote.Text = row["note"].ToString();
            }
            else
            {
                txtNote.Clear();
            }
        }

        private void clear_DOWNTIME()
        {
            txtDowntimeCode.Clear();
            txtPeriodId.Clear();
            dtpDate.Value = DateTime.Now;
            numDayesCount.Value = 0;
            numHours.Value = 0;
            numMinutes.Value = 0;
            dtpStartTime.Checked = false;
            dtpEndTime.Checked = false;
            numAmount.Value = 0;
            txtNote.Clear();
        }
    }
}

