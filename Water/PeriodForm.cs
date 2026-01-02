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
        private bool isSearchMode = false; 
        private DateTime lastClickTime = DateTime.MinValue; // آخر وقت للنقر
        private const int DOUBLE_CLICK_INTERVAL = 500;
        private bool startDateEntered = false; // لتتبع ما إذا تم إدخال قيمة في تاريخ البداية
        private bool endDateEntered = false; // لتتبع ما إذا تم إدخال قيمة في تاريخ النهاية
        private DateTime initialStartDate; // تاريخ البداية الافتراضي عند تفعيل البحث
        private DateTime initialEndDate; // تاريخ النهاية الافتراضي عند تفعيل البحث
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
                isSearchMode = false;
                // إزالة الأحداث إذا كانت موجودة
                dtpStartDate.ValueChanged -= dtpStartDate_SearchValueChanged;
                dtpEndDate.ValueChanged -= dtpEndDate_SearchValueChanged;
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
                    string.IsNullOrWhiteSpace(txtTotalHours.Text))
                {
                    MessageBox.Show("الرجاء إكمال جميع البيانات المطلوبة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // التحقق من صحة الأرقام المدخلة
                int baseDays, extendedDays, totalHours;
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
                isSearchMode = false;
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
                    isSearchMode = false;
                    // إزالة الأحداث إذا كانت موجودة
                    dtpStartDate.ValueChanged -= dtpStartDate_SearchValueChanged;
                    dtpEndDate.ValueChanged -= dtpEndDate_SearchValueChanged;
                    SetNormalMode();
                }
                // إذا اختار "لا"، لا نفعل شيئاً ونبقى في الشاشة
            }
            else if (isSearchMode)
            {
                clear_PERIOD();
                isEditMode = false;
                isSearchMode = false;
                // إزالة الأحداث إذا كانت موجودة
                dtpStartDate.ValueChanged -= dtpStartDate_SearchValueChanged;
                dtpEndDate.ValueChanged -= dtpEndDate_SearchValueChanged;
                SetNormalMode();
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
            btnSearch.Enabled = true;

            txtPeriodCode.ReadOnly = true;
            txtStatment.ReadOnly = true;
            dtpStartDate.Enabled = false;
            dtpEndDate.Enabled = false;
            
            // إعادة تنسيق التواريخ إلى الوضع الطبيعي
            ResetDatePickersFormat();
        }
        private void SetViewMode()
        {
            btnView.Enabled = true;
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnSearch.Enabled = true;

            txtPeriodCode.ReadOnly = true;
            txtStatment.ReadOnly = true;
            dtpStartDate.Enabled = false;
            dtpEndDate.Enabled = false;
            
            // إعادة تنسيق التواريخ إلى الوضع الطبيعي
            ResetDatePickersFormat();
        }

        private void SetAddMode()
        {
            btnSave.Enabled = true;
            btnView.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = false;
            btnSearch.Enabled = false;

            txtPeriodCode.ReadOnly = true;
            txtStatment.ReadOnly = false;
            dtpStartDate.Enabled = true;
            dtpEndDate.Enabled = true;
            // إعادة تنسيق التواريخ إلى الوضع الطبيعي
            ResetDatePickersFormat();

            dtpEndDate.Value = dtpStartDate.Value.AddDays(30);
        }

        private void SetEditMode()
        {
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnView.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSearch.Enabled = false;

            txtPeriodCode.ReadOnly = true;
            txtStatment.ReadOnly = false;
            dtpStartDate.Enabled = true;
            dtpEndDate.Enabled = true;
            // إعادة تنسيق التواريخ إلى الوضع الطبيعي
            ResetDatePickersFormat();
        }
        
        /// <summary>
        /// إعادة تنسيق DateTimePicker إلى الوضع الطبيعي (إزالة CustomFormat)
        /// </summary>
        private void ResetDatePickersFormat()
        {
            // إزالة الأحداث إذا كانت موجودة
            dtpStartDate.ValueChanged -= dtpStartDate_SearchValueChanged;
            dtpEndDate.ValueChanged -= dtpEndDate_SearchValueChanged;
            
            // إعادة التنسيق إلى الوضع الطبيعي
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Format = DateTimePickerFormat.Short;
        }
        private void SetDeleteMode()
        {                                   
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            
            // إعادة تنسيق التواريخ إلى الوضع الطبيعي
            ResetDatePickersFormat();
        }

        private void SetAfterSaveMode()
        {
           SetNormalMode();
        }
        private void SetSearchMode()
        {
            btnSearch.Enabled = true;
            btnView.Enabled = false;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;

            clear_PERIOD();

            txtPeriodCode.ReadOnly = false;
            txtStatment.ReadOnly = false;
            dtpStartDate.Enabled = true;
            dtpEndDate.Enabled = true;
            
            // تهيئة التواريخ لتكون فارغة (تبدو فارغة)
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.CustomFormat = " ";
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.CustomFormat = " ";
            
            // حفظ التواريخ الافتراضية لتحديد ما إذا تم تغييرها
            initialStartDate = dtpStartDate.Value;
            initialEndDate = dtpEndDate.Value;
            startDateEntered = false;
            endDateEntered = false;
            
            // إضافة أحداث لتتبع تغيير التواريخ
            dtpStartDate.ValueChanged += dtpStartDate_SearchValueChanged;
            dtpEndDate.ValueChanged += dtpEndDate_SearchValueChanged;
        }
        
        private void dtpStartDate_SearchValueChanged(object sender, EventArgs e)
        {
            // إذا تم تغيير التاريخ عن القيمة الافتراضية، نعتبره تم إدخاله
            if (isSearchMode && dtpStartDate.Value != initialStartDate)
            {
                startDateEntered = true;
                // تغيير التنسيق لإظهار التاريخ
                dtpStartDate.Format = DateTimePickerFormat.Short;
            }
        }
        
        private void dtpEndDate_SearchValueChanged(object sender, EventArgs e)
        {
            // إذا تم تغيير التاريخ عن القيمة الافتراضية، نعتبره تم إدخاله
            if (isSearchMode && dtpEndDate.Value != initialEndDate)
            {
                endDateEntered = true;
                // تغيير التنسيق لإظهار التاريخ
                dtpEndDate.Format = DateTimePickerFormat.Short;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime currentClickTime = DateTime.Now;
            TimeSpan timeSinceLastClick = currentClickTime - lastClickTime;

            // نقرتين متتاليتين → أول فترة
            if (timeSinceLastClick.TotalMilliseconds < DOUBLE_CLICK_INTERVAL)
            {
                LoadFirstPeriod();
                lastClickTime = DateTime.MinValue;               
                return;
            }
            lastClickTime = currentClickTime;
            // أول نقرة → تفعيل وضع البحث
            if (!isSearchMode)
            {
                SetSearchMode();
                isSearchMode = true;
                return;
            }
            // النقرة الثانية → البحث 
            SearchPeriod();
        }

        private void SearchPeriod()
        {
            try
            {
                //الحصول على جميع الفترات
                DataTable allPeriods = per.GET_ALL_PERIODS();

                if (allPeriods == null || allPeriods.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات الفترات", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // البحث بناءً على الحقول المدخلة
                string searchPeriodCode = txtPeriodCode.Text.Trim();
                string searchPeriodStatment = txtStatment.Text.Trim();
                
                // استخدام التواريخ فقط إذا تم إدخالها
                string searchStartDate = "";
                string searchEndDate = "";
                if (startDateEntered)
                {
                    searchStartDate = dtpStartDate.Value.ToString("yyyy-MM-dd");
                }
                if (endDateEntered)
                {
                    searchEndDate = dtpEndDate.Value.ToString("yyyy-MM-dd");
                }

                DataRow foundRow = null;

                // البحث في البيانات
                foreach (DataRow row in allPeriods.Rows)
                {
                    bool matches = true;

                    // البحث برقم الفترة
                    if (!string.IsNullOrWhiteSpace(searchPeriodCode))
                    {
                        string periodCode = row["id"] != DBNull.Value ? row["id"].ToString().Trim().ToUpper() : "";
                        if (periodCode.IndexOf(searchPeriodCode.Trim().ToUpper()) < 0)
                        {
                            matches = false;
                        }
                    }
                    // البحث بالبيان
                    if (matches && !string.IsNullOrWhiteSpace(searchPeriodStatment))
                    {
                        string periodStatment = row["statment"] != DBNull.Value ? row["statment"].ToString().Trim().ToUpper() : "";
                        if (periodStatment.IndexOf(searchPeriodStatment.Trim().ToUpper()) < 0)
                        {
                            matches = false;
                        }
                    }
                    // البحث بتاريخ البداية (فقط إذا تم إدخاله)
                    if (matches && !string.IsNullOrWhiteSpace(searchStartDate))
                    {
                        string startDate = row["start_date"] != DBNull.Value ? row["start_date"].ToString().Trim().ToUpper() : "";
                        if (startDate.IndexOf(searchStartDate.Trim().ToUpper()) < 0)
                        {
                            matches = false;
                        }
                    }
                    // البحث بتاريخ النهاية (فقط إذا تم إدخاله)
                    if (matches && !string.IsNullOrWhiteSpace(searchEndDate))
                    {
                        string endDate = row["end_date"] != DBNull.Value ? row["end_date"].ToString().Trim().ToUpper() : "";
                        if (endDate.IndexOf(searchEndDate.Trim().ToUpper()) < 0)
                        {
                            matches = false;
                        }
                    }
                    // إذا تطابقت جميع الشروط
                    if (matches)
                    {
                        foundRow = row;
                        break;
                    }
                }

                if (foundRow != null)
                {
                    LoadPeriodData(foundRow);
                    SetViewMode();
                    isSearchMode = false;
                    
                    // إزالة الأحداث عند الخروج من وضع البحث
                    dtpStartDate.ValueChanged -= dtpStartDate_SearchValueChanged;
                    dtpEndDate.ValueChanged -= dtpEndDate_SearchValueChanged;
                }
                else
                {
                    MessageBox.Show("لم يتم العثور على فترة يطابق معايير البحث", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء البحث: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFirstPeriod()
        {
            try
            {
                DataTable allPeriods = per.GET_ALL_PERIODS();

                if (allPeriods == null || allPeriods.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات الفترات", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // تحميل بيانات أول فترة
                LoadPeriodData(allPeriods.Rows[0]);
                isSearchMode = false;
                // إزالة الأحداث إذا كانت موجودة
                dtpStartDate.ValueChanged -= dtpStartDate_SearchValueChanged;
                dtpEndDate.ValueChanged -= dtpEndDate_SearchValueChanged;
                SetViewMode();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
    }
}

