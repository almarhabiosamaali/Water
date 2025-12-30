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
        Clas.GridBtnViewHelper gridBtnViewHelper = new Clas.GridBtnViewHelper();
        public PeriodForm()
        {
            InitializeComponent();
            btnView.Click += btnView_Click;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnSave.Click += btnSave_Click;
            
            // ربط أحداث حساب عدد الأيام وإجمالي الساعات تلقائياً
            dtpStartDate.ValueChanged += CalculateDaysAndHours;
            dtpEndDate.ValueChanged += CalculateDaysAndHours;
        }

        private void btnView_Click(object sender, EventArgs e)
        {            
            DataTable dt = per.GET_ALL_PERIODS();
            DataRow row = gridBtnViewHelper.Show(dt, "عرض الفترات");
            if (row != null)
            {
                LoadPeriodData(row);
                SetViewMode();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isEditMode = false;
            clear_PERIOD();
            txtDownDays.Text = "0";
            txtDowntimeHours.Text = "0";
            try
            {
                txtPeriodCode.Text = per.GET_NEXT_PERIOD_CODE();
            }
            catch
            {
                txtPeriodCode.Text = "1";
            }
            SetAddMode();
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
                SetEditMode();
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
                    SetDeleteMode();
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
                  //  string.IsNullOrWhiteSpace(txtDowntimeHours.Text) ||
                    //string.IsNullOrWhiteSpace(txtDownDays.Text) ||
                    string.IsNullOrWhiteSpace(txtTotalHours.Text))
                {
                    MessageBox.Show("الرجاء إكمال جميع البيانات المطلوبة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // التحقق من صحة الأرقام المدخلة
                int baseDays, extendedDays, totalHours;
                /*if (!int.TryParse(txtBaseDays.Text.Trim(), out baseDays) || baseDays <= 0)
                {
                    MessageBox.Show("الرجاء إدخال قيمة صحيحة للأيام الأساسية", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtDownDays.Text.Trim(), out extendedDays) || extendedDays <= 0)
                {
                    MessageBox.Show("الرجاء إدخال قيمة صحيحة لأيام التوقف", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }*/

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
                baseDays = Convert.ToInt32(txtBaseDays.Text);
                extendedDays = Convert.ToInt32(txtDownDays.Text);

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
                        totalHours,
                        txtStatment.Text.Trim()
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
                        totalHours,
                        txtStatment.Text.Trim()
                    );

                    MessageBox.Show("تم حفظ بيانات الفترة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                clear_PERIOD();
                isEditMode = false;
                SetAfterSaveMode();
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
            if (row["statment"] != DBNull.Value)
            {
                txtStatment.Text = row["statment"].ToString();
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
            txtWorkingHours.Clear();
            txtStatment.Clear();
        }

        /// <summary>
        /// حساب عدد الأيام وإجمالي الساعات تلقائياً من تاريخ البداية وتاريخ النهاية
        /// </summary>
        private void CalculateDaysAndHours(object sender, EventArgs e)
        {
            try
            {
                // التحقق من أن تاريخ النهاية بعد تاريخ البداية أو يساويه
                if (dtpEndDate.Value < dtpStartDate.Value)
                {
                    // إذا كان تاريخ النهاية قبل تاريخ البداية، لا نحسب
                    return;
                }

                // حساب عدد الأيام: الفرق بين تاريخ النهاية وتاريخ البداية + 1
                // (لأننا نريد تضمين يوم البداية ويوم النهاية)
                TimeSpan difference = dtpEndDate.Value.Date - dtpStartDate.Value.Date;
                int days = (int)difference.TotalDays + 1; // +1 لتضمين يوم البداية

                // حساب إجمالي الساعات: عدد الأيام × 24 ساعة
                int totalHours = days * 24;
                int workingHours =days * 20;

                // تحديث الحقول
                txtBaseDays.Text = days.ToString();
                txtTotalHours.Text = totalHours.ToString();
                txtWorkingHours.Text = workingHours.ToString();
            }
            catch (Exception ex)
            {
                // في حالة حدوث خطأ، لا نفعل شيئاً لتجنب تعطيل المستخدم
                // يمكن إضافة تسجيل الخطأ هنا إذا لزم الأمر
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
           
             if (btnSave.Enabled)
            {
                DialogResult result = MessageBox.Show($"هل تريد الرجوع وعدم حفظ البيانات ؟", "تأكيد الإلغاء", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    clear_PERIOD();
                    isEditMode = false;
                    
                    SetNormalMode();
                }
                // إذا اختار "لا"، لا نفعل شيئاً ونبقى في الشاشة
            }
            else
            {                
                this.Close();
            }
        }
          private void SetNormalMode()
        {
            btnSave.Enabled = false;
            btnView.Enabled = true;
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void SetViewMode()
        {
            btnView.Enabled = true;
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }

        private void SetAddMode()
        {
            btnSave.Enabled = true;
            btnView.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = false;
        }

        private void SetEditMode()
        {
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnView.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }
        private void SetDeleteMode()
        {                                   
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }

        private void SetAfterSaveMode()
        {
            btnSave.Enabled = false;
            btnView.Enabled = true;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }
    }
}

