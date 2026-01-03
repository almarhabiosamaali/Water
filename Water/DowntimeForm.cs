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
        private bool isSearchMode = false;
        private DateTime lastClickTime = DateTime.MinValue; // آخر وقت للنقر
        private const int DOUBLE_CLICK_INTERVAL = 500;
        private bool dateEntered = false; // لتتبع ما إذا تم إدخال قيمة في تاريخ البداية
        private DateTime initialDate; // تاريخ البداية الافتراضي عند تفعيل البحث
        Clas.downtime dwn = new Clas.downtime();
        Clas.period period = new Clas.period();
        Clas.GridBtnViewHelper gridBtnViewHelper = new Clas.GridBtnViewHelper();
        public DowntimeForm()
        {
            InitializeComponent();
            btnView.Click += btnView_Click;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnSave.Click += btnSave_Click;

            // ربط أحداث F2 و Enter على حقل رقم الفترة لعرض قائمة الفترات            
            txtPeriodId.Leave += txtPeriodId_Leave;

            // ربط أحداث حساب الأيام والساعات تلقائياً
            dtpStartTime.ValueChanged += CalculateDaysAndHours;
            dtpEndTime.ValueChanged += CalculateDaysAndHours;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataTable dt = dwn.GET_ALL_DOWNTIMES();
            DataRow row = gridBtnViewHelper.Show(dt, "عرض التوقفات");
            if (row != null)
            {
                LoadDowntimeData(row);
                SetViewMode();
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
            SetAddMode();
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
                //txtDowntimeCode.Enabled = false;                
                SetEditMode();
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
                "هل أنت متأكد من حذف التوقف: " + txtDowntimeCode.Text + "؟\nسيتم إلغاء التعديلات التي تمت على الفترة المرتبطة بهذا التوقف.",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // قراءة بيانات التوقف قبل الحذف لإلغاء التعديلات من الفترة
                    string downtimeId = txtDowntimeCode.Text.Trim();

                    // قراءة بيانات التوقف من قاعدة البيانات
                    DataTable dt = dwn.VIEW_DOWNTIME(downtimeId);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        string periodId = row["period_id"] != DBNull.Value ? row["period_id"].ToString() : null;

                        // إذا كان هناك period_id، نقرأ الأيام/الساعات/الدقائق ونلغي التعديلات
                        if (!string.IsNullOrWhiteSpace(periodId))
                        {
                            int days = 0;
                            int hrs = 0;
                            int mins = 0;

                            // قراءة الأيام
                            if (row["dayesCount"] != DBNull.Value && !string.IsNullOrWhiteSpace(row["dayesCount"].ToString()))
                            {
                                int.TryParse(row["dayesCount"].ToString(), out days);
                            }

                            // قراءة الساعات
                            if (row["hours"] != DBNull.Value && !string.IsNullOrWhiteSpace(row["hours"].ToString()))
                            {
                                int.TryParse(row["hours"].ToString(), out hrs);
                            }

                            // قراءة الدقائق
                            if (row["minutes"] != DBNull.Value && !string.IsNullOrWhiteSpace(row["minutes"].ToString()))
                            {
                                int.TryParse(row["minutes"].ToString(), out mins);
                            }

                            // إلغاء التعديلات من الفترة فقط إذا كان هناك قيمة فعلية
                            if (days > 0 || hrs > 0 || mins > 0)
                            {
                                try
                                {
                                    period.ReverseDowntimeFromPeriod(
                                        periodId,
                                        downtimeId,
                                        days,
                                        hrs,
                                        mins
                                    );
                                }
                                catch (Exception periodEx)
                                {
                                    // في حالة فشل إلغاء التعديلات، نعرض رسالة تحذيرية لكن نستمر في الحذف
                                    MessageBox.Show(
                                        "تم حذف التوقف، لكن حدث خطأ أثناء إلغاء التعديلات من الفترة:\n" + periodEx.Message,
                                        "تحذير",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning
                                    );
                                }
                            }
                        }
                    }

                    // حذف التوقف
                    dwn.DELETE_DOWNTIME(downtimeId);
                    MessageBox.Show("تم حذف التوقف بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_DOWNTIME();
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
                // التحقق من أن الحقول الأساسية مملوءة
                if (string.IsNullOrWhiteSpace(txtDowntimeCode.Text))
                {
                    MessageBox.Show("الرجاء إدخال كود التوقف", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // تحضير القيم الاختيارية
                // int? dayesCount = txtDayesCount.Value > 0 ? (int?)txtDayesCount.Value : null;
                string dayesCount = !string.IsNullOrWhiteSpace(txtDayesCount.Text) ? txtDayesCount.Text : null;
                string hours = !string.IsNullOrWhiteSpace(txtHours.Text) ? txtHours.Text : null;
                string minutes = !string.IsNullOrWhiteSpace(txtMinutes.Text) ? txtMinutes.Text : null;
                DateTime? startTime = dtpStartTime.Checked ? (DateTime?)dtpStartTime.Value : null;
                DateTime? endTime = dtpEndTime.Checked ? (DateTime?)dtpEndTime.Value : null;
                double? amount = double.TryParse(txtAmount.Text, out double val) ? val : (double?)null;

                string note = !string.IsNullOrWhiteSpace(txtNote.Text) ? txtNote.Text.Trim() : null;
                string periodId = !string.IsNullOrWhiteSpace(txtPeriodId.Text) ? txtPeriodId.Text.Trim() : null;
                string description = !string.IsNullOrWhiteSpace(txtDescription.Text) ? txtDescription.Text.Trim() : null;

                // القيمة الافتراضية عند الإضافة = 0، وعند التحديث نستخدم القيمة الحالية
                int? isProcessed;
                if (isEditMode)
                {
                    isProcessed = chkIsProcessed.Checked ? 1 : 0;
                }
                else
                {
                    // عند الإضافة، القيمة الافتراضية = 0
                    isProcessed = 0;
                }

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
                        note,
                        description,
                        isProcessed
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
                        note,
                        description,
                        isProcessed
                    );

                    MessageBox.Show("تم حفظ بيانات التوقف بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // تطبيق التوقف على الفترة إذا كان هناك period_id وأيام/ساعات/دقائق
                /*
                if (!string.IsNullOrWhiteSpace(periodId))
                {
                    int days = int.TryParse(dayesCount, out int d) ? d : 0;
                    int hrs = int.TryParse(hours, out int h) ? h : 0;
                    int mins = int.TryParse(minutes, out int m) ? m : 0;
                    
                    // تطبيق التوقف على الفترة فقط إذا كان هناك قيمة فعلية
                    if (days > 0 || hrs > 0 || mins > 0)
                    {
                        try
                        {
                            period.ApplyDowntimeToPeriod(
                                periodId,
                                txtDowntimeCode.Text.Trim(),
                                days,
                                hrs,
                                mins
                            );
                        }
                        catch (Exception periodEx)
                        {
                            // في حالة فشل تطبيق التوقف على الفترة، نعرض رسالة تحذيرية
                            MessageBox.Show(
                                "تم حفظ التوقف بنجاح، لكن حدث خطأ أثناء تطبيقه على الفترة:\n" + periodEx.Message,
                                "تحذير",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                        }
                    }
                }
                */
                isEditMode = false;
                txtDowntimeCode.Enabled = true;
                SetAfterSaveMode();
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
                string periodId = row["period_id"].ToString();
                txtPeriodId.Text = periodId;

                // تحميل بيانات الفترة وعرضها
                try
                {
                    DataTable periodDt = period.VIEW_PERIOD(periodId);
                    if (periodDt != null && periodDt.Rows.Count > 0)
                    {
                        LoadPeriodDataToDowntime(periodDt.Rows[0]);
                    }
                }
                catch
                {
                    // في حالة الخطأ، لا نفعل شيئاً
                }
            }
            else
            {
                txtPeriodId.Clear();
                if (txtPeriodStartDate != null)
                    txtPeriodStartDate.Clear();
                if (txtPeriodEndDate != null)
                    txtPeriodEndDate.Clear();
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
                txtMinutes.Text = row["minutes"].ToString();
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

            if (row["description"] != DBNull.Value)
            {
                txtDescription.Text = row["description"].ToString();
            }
            else
            {
                txtDescription.Clear();
            }

            if (row["isProcessed"] != DBNull.Value)
            {
                int processedValue = Convert.ToInt32(row["isProcessed"]);
                chkIsProcessed.Checked = processedValue == 1;
            }
            else
            {
                chkIsProcessed.Checked = false;
            }
        }

        private void clear_DOWNTIME()
        {
            txtDowntimeCode.Clear();
            txtPeriodId.Clear();
            dtpDate.Value = DateTime.Now;
            dtpStartTime.Value=DateTime.Now;
            dtpEndTime.Value=DateTime.Now;
            txtDayesCount.Clear();
            txtHours.Clear();
            txtMinutes.Clear();            
            txtAmount.Clear();
            txtNote.Clear();
            txtDescription.Clear();
            chkIsProcessed.Checked = false;
            txtWorkingHours.Clear();
            txtPeriodStartDate.Clear();
            txtPeriodEndDate.Clear();
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

        private void LoadPeriodDataToDowntime(DataRow row)
        {
            try
            {
                // عرض بداية الفترة
                if (txtPeriodStartDate != null)
                {
                    if (row["start_date"] != DBNull.Value)
                    {
                        txtPeriodStartDate.Text = Convert.ToDateTime(row["start_date"]).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        txtPeriodStartDate.Clear();
                    }
                }

                // عرض نهاية الفترة
                if (txtPeriodEndDate != null)
                {
                    if (row["end_date"] != DBNull.Value)
                    {
                        txtPeriodEndDate.Text = Convert.ToDateTime(row["end_date"]).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        txtPeriodEndDate.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل بيانات الفترة: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// حساب عدد الأيام والساعات تلقائياً من وقت البداية ووقت النهاية
        /// </summary>
        private void CalculateDaysAndHours(object sender, EventArgs e)
        {
            try
            {
                // التحقق من أن وقت البداية ووقت النهاية مفعّلان (Checked)
                if (!dtpStartTime.Checked || !dtpEndTime.Checked)
                {
                    // إذا لم يكن أحدهما مفعلاً، لا نحسب
                    return;
                }

                // التحقق من أن وقت النهاية بعد وقت البداية أو يساويه
                if (dtpEndTime.Value < dtpStartTime.Value)
                {
                    // إذا كان وقت النهاية قبل وقت البداية، لا نحسب
                    return;
                }

                // حساب الفرق بين وقت النهاية ووقت البداية
                TimeSpan difference = dtpEndTime.Value - dtpStartTime.Value;

                // حساب إجمالي الساعات (الفرق في الساعات)
                int totalHours = (int)difference.TotalHours;
                int daysf = difference.Days;
                // حساب عدد أيام العمل: قسمة إجمالي الساعات على 20 (يوم العمل = 20 ساعة)
                int days = (totalHours - (daysf * 4)) / 20;

                // حساب الساعات المتبقية بعد أيام العمل الكاملة
                int hours = (totalHours % 20) - (days * 4);
                int minutes = difference.Minutes;

                if (hours < 0)
                {
                    hours = 0;
                    minutes = 0;
                }


                // حساب الدقائق


                // حساب ساعات العمل الفعلية: عدد أيام العمل × 20 ساعة
                int workingHours = days * 20;

                // تحديث الحقول
                txtDayesCount.Text = days.ToString();
                txtHours.Text = hours.ToString();
                txtMinutes.Text = minutes.ToString();
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
                    clear_DOWNTIME();
                    isEditMode = false;

                    SetNormalMode();
                }
                // إذا اختار "لا"، لا نفعل شيئاً ونبقى في الشاشة
            }
            else if (isSearchMode)
            {
                clear_DOWNTIME();
                isEditMode = false;
                isSearchMode = false;
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

            txtDowntimeCode.ReadOnly = true;
            txtPeriodId.ReadOnly = true;
            dtpDate.Enabled = false;
            dtpStartTime.Enabled = false;
            dtpEndTime.Enabled = false;         
            txtAmount.ReadOnly = true;
            txtNote.ReadOnly = true;
            txtDescription.ReadOnly = true;
            chkIsProcessed.Enabled = false;
        }

        private void SetViewMode()
        {
            btnView.Enabled = true;
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnSearch.Enabled = true;

            txtDowntimeCode.ReadOnly = true;
            txtPeriodId.ReadOnly = true;
            dtpDate.Enabled = false;
            dtpStartTime.Enabled = false;
            dtpEndTime.Enabled = false;         
            txtAmount.ReadOnly = true;
            txtNote.ReadOnly = true;
            txtDescription.ReadOnly = true;
            chkIsProcessed.Enabled = false;
        }

        private void SetAddMode()
        {
            btnSave.Enabled = true;
            btnView.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = false;
            btnSearch.Enabled = false;
          

            txtDowntimeCode.ReadOnly = true;
            txtPeriodId.ReadOnly = false;
            dtpDate.Enabled = true;   
            dtpStartTime.Enabled = true;
            dtpEndTime.Enabled = true;         
            txtAmount.ReadOnly = false;
            txtNote.ReadOnly = false;
            txtDescription.ReadOnly = false;
            chkIsProcessed.Enabled = false;
        }

        private void SetEditMode()
        {
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnView.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSearch.Enabled = false;

            txtDowntimeCode.ReadOnly = true;
            txtPeriodId.ReadOnly = false;
            dtpDate.Enabled = true;
            dtpStartTime.Enabled = true;
            dtpEndTime.Enabled = true;         
            txtAmount.ReadOnly = false;
            txtNote.ReadOnly = false;
            txtDescription.ReadOnly = false;
            chkIsProcessed.Enabled = false;
        }
        private void SetDeleteMode()
        {
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
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

            clear_DOWNTIME();

            txtDowntimeCode.ReadOnly = false;
            txtPeriodId.ReadOnly = false;
            dtpDate.Enabled = true;
            chkIsProcessed.Enabled = true;
            txtAmount.ReadOnly = false;
            txtNote.ReadOnly = false;
            // تهيئة التواريخ لتكون فارغة (تبدو فارغة)
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = " ";

            // حفظ التواريخ الافتراضية لتحديد ما إذا تم تغييرها
            initialDate = dtpDate.Value;
            dateEntered = false;

            // إضافة أحداث لتتبع تغيير التواريخ
            dtpDate.ValueChanged += dtpDate_SearchValueChanged;
        }
        private void dtpDate_SearchValueChanged(object sender, EventArgs e)
        {
            // إذا تم تغيير التاريخ عن القيمة الافتراضية، نعتبره تم إدخاله
            if (isSearchMode && dtpDate.Value != initialDate)
            {
                dateEntered = true;
                // تغيير التنسيق لإظهار التاريخ
                dtpDate.Format = DateTimePickerFormat.Short;
            }
        }

        private void txtPeriodId_Leave(object sender, EventArgs e)
        {
            if (txtPeriodId == null || string.IsNullOrWhiteSpace(txtPeriodId.Text))
            {
                // مسح حقول الفترة إذا كان الحقل فارغاً
                if (txtPeriodStartDate != null)
                    txtPeriodStartDate.Clear();
                if (txtPeriodEndDate != null)
                    txtPeriodEndDate.Clear();
                return;
            }

            try
            {
                string periodId = txtPeriodId.Text.Trim();

                // التحقق من وجود الفترة في قاعدة البيانات
                DataTable dt = period.VIEW_PERIOD(periodId);

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("رقم الفترة غير موجود", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPeriodId.Focus();
                    // مسح حقول الفترة
                    if (txtPeriodStartDate != null)
                        txtPeriodStartDate.Clear();
                    if (txtPeriodEndDate != null)
                        txtPeriodEndDate.Clear();
                    return;
                }

                // تحميل بيانات الفترة وعرضها في الحقول
                LoadPeriodDataToDowntime(dt.Rows[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء التحقق من رقم الفترة: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPeriodId.Focus();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime currentClickTime = DateTime.Now;
            TimeSpan timeSinceLastClick = currentClickTime - lastClickTime;

            // نقرتين متتاليتين → أول فترة
            if (timeSinceLastClick.TotalMilliseconds < DOUBLE_CLICK_INTERVAL)
            {
                LoadFirstDowntime();
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
            SearchDowntime();
        }

        private void SearchDowntime()
        {
            try
            {
                //الحصول على جميع الفترات
                DataTable allDowntimes = dwn.GET_ALL_DOWNTIMES();

                if (allDowntimes == null || allDowntimes.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات توقفات", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // البحث بناءً على الحقول المدخلة
                string searchDowntimeCode = txtDowntimeCode.Text.Trim();
                string searchPeriodId = txtPeriodId.Text.Trim();
                DateTime? searchDate = null;
                string searchIsProcessed = chkIsProcessed.Checked ? "1" : "0";
                string searchAmount = txtAmount.Text.Trim();
                string searchNote = txtNote.Text.Trim();

                if (dateEntered)
                {  
                    searchDate = dtpDate.Value.Date;
                }

                DataRow foundRow = null;

                // البحث في البيانات
                foreach (DataRow row in allDowntimes.Rows)
                {
                    bool matches = true;

                    // البحث برقم التوقف
                    if (!string.IsNullOrWhiteSpace(searchDowntimeCode))
                    {
                        string downtimeCode = row["id"] != DBNull.Value ? row["id"].ToString().Trim().ToUpper() : "";
                        if (downtimeCode.IndexOf(searchDowntimeCode.Trim().ToUpper()) < 0)
                        {
                            matches = false;
                        }
                    }
                    // البحث برقم الفترة
                    if (matches && !string.IsNullOrWhiteSpace(searchPeriodId))
                    {
                        string periodId = row["period_id"] != DBNull.Value ? row["period_id"].ToString().Trim().ToUpper() : "";
                        if (periodId.IndexOf(searchPeriodId.Trim().ToUpper()) < 0)
                        {
                            matches = false;
                        }
                    }
                    if (matches && searchDate.HasValue)
                    {
                        DateTime rowdate = Convert.ToDateTime(row["date"]).Date;// != DBNull.Value ? row["date"].ToString().Trim().ToUpper() : "";
                        if (rowdate !=searchDate.Value)
                        {
                            matches = false;
                        }
                    }
                    // البحث بالتوقف المعالج
                    if (matches && !string.IsNullOrWhiteSpace(searchIsProcessed))
                    {
                        string isProcessed = row["isProcessed"] != DBNull.Value ? row["isProcessed"].ToString().Trim().ToUpper() : "";
                        if (isProcessed.IndexOf(searchIsProcessed.Trim().ToUpper()) < 0)
                        {
                            matches = false;
                        }
                    }
                    // البحث بالمبلغ
                    if (matches && !string.IsNullOrWhiteSpace(searchAmount))
                    {
                        string amount = row["amount"] != DBNull.Value ? row["amount"].ToString().Trim().ToUpper() : "";
                        if (amount.IndexOf(searchAmount.Trim().ToUpper()) < 0)
                        {
                            matches = false;
                        }
                    }
                    // البحث بالملاحظات
                    if (matches && !string.IsNullOrWhiteSpace(searchNote))
                    {
                        string note = row["note"] != DBNull.Value ? row["note"].ToString().Trim().ToUpper() : "";
                        if (note.IndexOf(searchNote.Trim().ToUpper()) < 0)
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
                    LoadDowntimeData(foundRow);
                    SetViewMode();
                    isSearchMode = false;

                    // إزالة الأحداث عند الخروج من وضع البحث
                    dtpDate.ValueChanged -= dtpDate_SearchValueChanged;
                }
                else
                {
                    MessageBox.Show("لم يتم العثور على توقف يطابق معايير البحث", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء البحث: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFirstDowntime()
        {
            try
            {
                DataTable allDowntimes = dwn.GET_ALL_DOWNTIMES();

                if (allDowntimes == null || allDowntimes.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات توقفات", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // تحميل بيانات أول توقف
                LoadDowntimeData(allDowntimes.Rows[0]);
                isSearchMode = false;
                // إزالة الأحداث إذا كانت موجودة
                dtpDate.ValueChanged -= dtpDate_SearchValueChanged;
                SetViewMode();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

