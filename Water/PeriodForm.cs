using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Water
{
    public partial class PeriodForm : Form
    {
        private bool isEditMode = false;
        Clas.period per = new Clas.period();

        public PeriodForm()
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
                DataTable dt = per.GET_ALL_PERIODS();
                
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات للعرض", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Form viewForm = new Form();
                viewForm.Text = "عرض الفترات";
                viewForm.RightToLeft = RightToLeft.Yes;
                viewForm.RightToLeftLayout = true;
                viewForm.Size = new Size(1200, 600);
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
                        LoadPeriodData(row);
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
            clear_PERIOD();
            try
            {
                txtPeriodCode.Text = per.GET_NEXT_PERIOD_CODE();
            }
            catch
            {
                txtPeriodCode.Text = "1";
            }
            txtPeriodCode.Enabled = false;
            btnSave.Text = "حفظ";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPeriodCode.Text))
            {
                MessageBox.Show("الرجاء إدخال كود الفترة أو اختيار فترة من قائمة العرض", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable dt = per.VIEW_PERIOD(txtPeriodCode.Text.Trim());
                
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("الفترة غير موجودة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LoadPeriodData(dt.Rows[0]);
                isEditMode = true;
                txtPeriodCode.Enabled = false;
                btnSave.Text = "تحديث";
                MessageBox.Show("يمكنك الآن تعديل بيانات الفترة", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPeriodCode.Text))
            {
                MessageBox.Show("الرجاء إدخال كود الفترة المراد حذفها", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "هل أنت متأكد من حذف الفترة: " + txtPeriodCode.Text + "؟",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    per.DELETE_PERIOD(txtPeriodCode.Text.Trim());
                    MessageBox.Show("تم حذف الفترة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_PERIOD();
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
                // التحقق من أن جميع الحقول مملوءة
                if (string.IsNullOrWhiteSpace(txtPeriodCode.Text) ||
                   // string.IsNullOrWhiteSpace(txtBa.Text) ||
                    string.IsNullOrWhiteSpace(txtDowntimeHours.Text) ||
                    //string.IsNullOrWhiteSpace(txtDownDays.Text) ||
                    string.IsNullOrWhiteSpace(txtTotalHours.Text))
                {
                    MessageBox.Show("الرجاء إكمال جميع البيانات المطلوبة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // التحقق من صحة الأرقام المدخلة
                int baseDays, extendedDays, totalHours;
                if (!int.TryParse(txtBaseDays.Text.Trim(), out baseDays) || baseDays <= 0)
                {
                    MessageBox.Show("الرجاء إدخال قيمة صحيحة للأيام الأساسية", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtDownDays.Text.Trim(), out extendedDays) || extendedDays <= 0)
                {
                    MessageBox.Show("الرجاء إدخال قيمة صحيحة لأيام التوقف", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtTotalHours.Text.Trim(), out totalHours) || totalHours <= 0)
                {
                    MessageBox.Show("الرجاء إدخال قيمة صحيحة لإجمالي الساعات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // التحقق من أن تاريخ النهاية بعد تاريخ البداية
                if (dtpEndDate.Value < dtpStartDate.Value)
                {
                    MessageBox.Show("تاريخ النهاية يجب أن يكون بعد تاريخ البداية", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (isEditMode)
                {
                    // تحديث بيانات الفترة
                    per.UPDATE_PERIOD(
                        txtPeriodCode.Text.Trim(),
                        dtpStartDate.Value,
                        dtpEndDate.Value,
                        baseDays,
                        txtDowntimeHours.Text.Trim(),
                        extendedDays,
                        totalHours
                    );

                    MessageBox.Show("تم تحديث بيانات الفترة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // إضافة فترة جديدة
                    per.ADD_PERIOD(
                        txtPeriodCode.Text.Trim(),
                        dtpStartDate.Value,
                        dtpEndDate.Value,
                        baseDays,
                        txtDowntimeHours.Text.Trim(),
                        extendedDays,
                        totalHours
                    );

                    MessageBox.Show("تم حفظ بيانات الفترة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                clear_PERIOD();
                isEditMode = false;
                btnSave.Text = "حفظ";
            }
            catch (SqlException sqlEx)
            {
                string errorMessage = "حدث خطأ في قاعدة البيانات:\n\n";
                errorMessage += "الرسالة: " + sqlEx.Message + "\n\n";
                if (sqlEx.Number > 0)
                {
                    errorMessage += "رقم الخطأ: " + sqlEx.Number + "\n";
                }
                if (!string.IsNullOrEmpty(sqlEx.Procedure))
                {
                    errorMessage += "Stored Procedure: " + sqlEx.Procedure + "\n";
                }
                MessageBox.Show(errorMessage, "خطأ في قاعدة البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ee)
            {
                MessageBox.Show("حدث خطأ أثناء الحفظ: " + ee.Message + "\n\nالتفاصيل: " + ee.ToString(), "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPeriodData(DataRow row)
        {
            txtPeriodCode.Text = row["id"].ToString();
            
            if (row["start_date"] != DBNull.Value)
            {
                dtpStartDate.Value = Convert.ToDateTime(row["start_date"]);
            }

            if (row["end_date"] != DBNull.Value)
            {
                dtpEndDate.Value = Convert.ToDateTime(row["end_date"]);
            }

            if (row["base_days"] != DBNull.Value)
            {
                txtBaseDays.Text = row["base_days"].ToString();
            }
            else
            {
                txtBaseDays.Clear();
            }

            txtDowntimeHours.Text = row["downtime_hours"].ToString();

            if (row["extended_days"] != DBNull.Value)
            {
                txtDownDays.Text = row["extended_days"].ToString();
            }
            else
            {
                txtDownDays.Clear();
            }

            if (row["total_hours"] != DBNull.Value)
            {
                txtTotalHours.Text = row["total_hours"].ToString();
            }
            else
            {
                txtTotalHours.Clear();
            }
        }

        private void clear_PERIOD()
        {
            txtPeriodCode.Clear();
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;
            txtBaseDays.Clear();
            txtDowntimeHours.Clear();
            txtDownDays.Clear();
            txtTotalHours.Clear();
        }
    }
}

