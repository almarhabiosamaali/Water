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
            
            // ربط أحداث F2 و Enter على حقل رقم الفترة لعرض قائمة الفترات
            txtPeriodId.KeyDown += txtPeriodId_KeyDown;
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
            try
            {
                txtDowntimeCode.Text = dwn.GET_NEXT_DOWNTIME_CODE();
            }
            catch
            {
                txtDowntimeCode.Text = "1";
            }
            btnSave.Text = "حفظ";
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
                // int? dayesCount = txtDayesCount.Value > 0 ? (int?)txtDayesCount.Value : null;
               string dayesCount=!string.IsNullOrWhiteSpace (txtDayesCount.Text)?txtDayesCount.Text : null;
                string hours = !string.IsNullOrWhiteSpace( txtHours.Text)? txtHours.Text : null;
                string minutes = !string.IsNullOrWhiteSpace(txtMinutes.Text)?txtMinutes.Text : null;
                DateTime? startTime = dtpStartTime.Checked ? (DateTime?)dtpStartTime.Value : null;
                DateTime? endTime = dtpEndTime.Checked ? (DateTime?)dtpEndTime.Value : null;
                double? amount = double.TryParse(txtAmount.Text, out double val) ? val : (double?)null;

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
                txtDayesCount.Text = row["dayesCount"].ToString();
            }
            else
            {
                txtDayesCount.Text = "0";
            }

            if (row["hours"] != DBNull.Value)
            {
                txtHours.Text = row["hours"].ToString();
            }
            else
            {
                txtHours.Text = "0";
            }

            if (row["minutes"] != DBNull.Value)
            {
                txtMinutes.Text =row["minutes"].ToString();
            }
            else
            {
                txtMinutes.Text = "0";
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
                txtAmount.Text = row["amount"].ToString();
            }
            else
            {
                txtAmount.Text = "0";
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
            txtDayesCount.Clear();
            txtHours.Clear();
            txtMinutes.Clear();
            dtpStartTime.Checked = false;
            dtpEndTime.Checked = false;
            txtAmount.Clear();
            txtNote.Clear();
        }

        private void txtPeriodId_KeyDown(object sender, KeyEventArgs e)
        {
            // عرض قائمة الفترات عند الضغط على F2 أو Enter
            if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // منع التنقل الافتراضي لـ Enter
                // استخدام الكلاس المساعد الموحد (لا توجد حقول بداية ونهاية الفترة في هذه الشاشة)
              //  Clas.PeriodHelper.ShowPeriodsList(txtPeriodId, null, null);
                Clas.PeriodHelper.ShowPeriodsList(txtPeriodId, txtPeriodStartDate, txtPeriodEndDate);
            }
        }

      
    }
}

