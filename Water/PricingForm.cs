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
    public partial class PricingForm : Form
    {
        private bool isEditMode = false;
        Clas.pricing pricing = new Clas.pricing();
        Clas.GridBtnViewHelper gridBtnViewHelper = new Clas.GridBtnViewHelper();
        private bool isSearchMode = false; 
        private DateTime lastClickTime = DateTime.MinValue; // آخر وقت للنقر
        private const int DOUBLE_CLICK_INTERVAL = 500; 
        public PricingForm()
        {
            InitializeComponent();
            btnView.Click += btnView_Click;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnSave.Click += btnSave_Click;

            // ربط أحداث التعبئة التلقائية
            txtWaterHourPrice.TextChanged += txtWaterHourPrice_TextChanged;
            txtDieselHourPrice.TextChanged += txtDieselHourPrice_TextChanged;
            txtDieselUsedHour.TextChanged += txtDieselUsedHour_TextChanged;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataTable dt = pricing.GET_ALL_PRICINGS();
            DataRow row = gridBtnViewHelper.Show(dt, "عرض مستويات الأسعار");
            if (row != null)
            {
                LoadPricingData(row);
                SetViewMode();
            }
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isEditMode = false;
            isSearchMode = false;
            clear_PRICING();
            try
            {
                txtPriceLevelId.Text = pricing.GET_NEXT_PRICING_CODE();
            }
            catch
            {
                txtPriceLevelId.Text = "1";
            }           
            SetAddMode();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPriceLevelId.Text))
            {
                MessageBox.Show("الرجاء إدخال كود مستوى السعر أو اختيار مستوى من قائمة العرض", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable dt = pricing.VIEW_PRICING(txtPriceLevelId.Text.Trim());

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("مستوى السعر غير موجود", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LoadPricingData(dt.Rows[0]);
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
            if (string.IsNullOrWhiteSpace(txtPriceLevelId.Text))
            {
                MessageBox.Show("الرجاء إدخال كود مستوى السعر المراد حذفه", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "هل أنت متأكد من حذف مستوى السعر: " + txtPriceLevelId.Text + "؟",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    pricing.DELETE_PRICING(txtPriceLevelId.Text.Trim());
                    MessageBox.Show("تم حذف مستوى السعر بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_PRICING();
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
                // التحقق من أن الحقول المطلوبة مملوءة
                if (string.IsNullOrWhiteSpace(txtPriceLevelId.Text) ||
                    string.IsNullOrWhiteSpace(txtLevelName.Text))
                {
                    MessageBox.Show("الرجاء إدخال كود مستوى السعر واسم المستوى على الأقل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // تحويل القيم الرقمية
                double? dieselHourPrice = string.IsNullOrWhiteSpace(txtDieselHourPrice.Text) ? (double?)null : Convert.ToDouble(txtDieselHourPrice.Text);
                double? dieselMinutePrice = string.IsNullOrWhiteSpace(txtDieselMinutePrice.Text) ? (double?)null : Convert.ToDouble(txtDieselMinutePrice.Text);
                double? dieselUsedHour = string.IsNullOrWhiteSpace(txtDieselUsedHour.Text) ? (double?)null : Convert.ToDouble(txtDieselUsedHour.Text);
                double? dieselUsedMinute = string.IsNullOrWhiteSpace(txtDieselUsedMinute.Text) ? (double?)null : Convert.ToDouble(txtDieselUsedMinute.Text);
                double? waterHourPrice = string.IsNullOrWhiteSpace(txtWaterHourPrice.Text) ? (double?)null : Convert.ToDouble(txtWaterHourPrice.Text);
                double? waterMinutePrice = string.IsNullOrWhiteSpace(txtWaterMinutePrice.Text) ? (double?)null : Convert.ToDouble(txtWaterMinutePrice.Text);

                if (isEditMode)
                {
                    // تحديث بيانات مستوى السعر
                    pricing.UPDATE_PRICING(
                        txtPriceLevelId.Text.Trim(),
                        txtLevelName.Text.Trim(),
                        dtpPricingDate.Value.Date,
                        dieselHourPrice,
                        dieselMinutePrice,
                        dieselUsedHour,
                        dieselUsedMinute,
                        waterHourPrice,
                        waterMinutePrice,
                        txtNotes.Text.Trim()
                    );

                    MessageBox.Show("تم تحديث بيانات مستوى السعر بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // إضافة مستوى سعر جديد
                    pricing.ADD_PRICING(
                        txtPriceLevelId.Text.Trim(),
                        txtLevelName.Text.Trim(),
                        dtpPricingDate.Value.Date,
                        dieselHourPrice,
                        dieselMinutePrice,
                        dieselUsedHour,
                        dieselUsedMinute,
                        waterHourPrice,
                        waterMinutePrice,
                        txtNotes.Text.Trim()
                    );

                    MessageBox.Show("تم حفظ بيانات مستوى السعر بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                isSearchMode = false;
                isEditMode = false;                
                SetAfterSaveMode();
            }
            catch (FormatException)
            {
                MessageBox.Show("الرجاء إدخال قيم رقمية صحيحة في الحقول الرقمية", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ee)
            {
                MessageBox.Show("حدث خطأ أثناء الحفظ: " + ee.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPricingData(DataRow row)
        {
            txtPriceLevelId.Text = row["PriceLevleId"].ToString();
            txtLevelName.Text = row["LevelName"].ToString();

            if (row["PricingDate"] != DBNull.Value)
            {
                dtpPricingDate.Value = Convert.ToDateTime(row["PricingDate"]);
            }
            else
            {
                dtpPricingDate.Value = DateTime.Now;
            }

            txtDieselHourPrice.Text = row["DieselHourPrice"] != DBNull.Value ? row["DieselHourPrice"].ToString() : "";
            txtDieselMinutePrice.Text = row["DieselMinutePrice"] != DBNull.Value ? row["DieselMinutePrice"].ToString() : "";
            txtDieselUsedHour.Text = row["DieselUsedHour"] != DBNull.Value ? row["DieselUsedHour"].ToString() : "";
            txtDieselUsedMinute.Text = row["DieselUsedMinute"] != DBNull.Value ? row["DieselUsedMinute"].ToString() : "";
            txtWaterHourPrice.Text = row["WaterHourPrice"] != DBNull.Value ? row["WaterHourPrice"].ToString() : "";
            txtWaterMinutePrice.Text = row["WaterMinutePrice"] != DBNull.Value ? row["WaterMinutePrice"].ToString() : "";
            txtNotes.Text = row["Notes"] != DBNull.Value ? row["Notes"].ToString() : "";
        }

        private void clear_PRICING()
        {
            txtPriceLevelId.Clear();
            txtLevelName.Clear();
            dtpPricingDate.Value = DateTime.Now;
            txtDieselHourPrice.Clear();
            txtDieselMinutePrice.Clear();
            txtDieselUsedHour.Clear();
            txtDieselUsedMinute.Clear();
            txtWaterHourPrice.Clear();
            txtWaterMinutePrice.Clear();
            txtNotes.Clear();
        }

        private void txtNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            // يسمح بالأرقام والنقطة والـ Backspace فقط
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }

            // يمنع إدخال أكثر من نقطة واحدة
            TextBox txt = sender as TextBox;
            if (e.KeyChar == '.' && txt != null && txt.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txtWaterHourPrice_TextChanged(object sender, EventArgs e)
        {
            // حساب سعر دقيقة الماء تلقائياً: سعر الساعة / 60
            try
            {
                if (!string.IsNullOrWhiteSpace(txtWaterHourPrice.Text))
                {
                    double waterHourPrice = Convert.ToDouble(txtWaterHourPrice.Text);
                    double waterMinutePrice = waterHourPrice / 60.0;
                    txtWaterMinutePrice.Text = waterMinutePrice.ToString("F4"); // 4 خانات عشرية
                }
                else
                {
                    txtWaterMinutePrice.Clear();
                }
            }
            catch
            {
                // في حالة الخطأ، لا نفعل شيئاً
            }
        }

        private void txtDieselHourPrice_TextChanged(object sender, EventArgs e)
        {
            // حساب سعر دقيقة الديزل تلقائياً: سعر الساعة / 60
            try
            {
                if (!string.IsNullOrWhiteSpace(txtDieselHourPrice.Text))
                {
                    double dieselHourPrice = Convert.ToDouble(txtDieselHourPrice.Text);
                    double dieselMinutePrice = dieselHourPrice / 60.0;
                    txtDieselMinutePrice.Text = dieselMinutePrice.ToString("F4"); // 4 خانات عشرية
                }
                else
                {
                    txtDieselMinutePrice.Clear();
                }
            }
            catch
            {
                // في حالة الخطأ، لا نفعل شيئاً
            }
        }

        private void txtDieselUsedHour_TextChanged(object sender, EventArgs e)
        {
            // حساب استهلاك الديزل في الدقيقة تلقائياً: استهلاك الساعة / 60
            // لأن: استهلاك الدقيقة = استهلاك الساعة / 60
            try
            {
                if (!string.IsNullOrWhiteSpace(txtDieselUsedHour.Text))
                {
                    double dieselUsedHour = Convert.ToDouble(txtDieselUsedHour.Text);
                    double dieselUsedMinute = dieselUsedHour / 60.0;
                    txtDieselUsedMinute.Text = dieselUsedMinute.ToString("F4"); // 4 خانات عشرية
                }
                else
                {
                    txtDieselUsedMinute.Clear();
                }
            }
            catch
            {
                // في حالة الخطأ، لا نفعل شيئاً
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            
             if (btnSave.Enabled)
            {
                DialogResult result = MessageBox.Show($"هل تريد الرجوع وعدم حفظ البيانات ؟", "تأكيد الإلغاء", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    clear_PRICING();
                    isEditMode = false;
                    isSearchMode = false;
                    SetNormalMode();
                }
                // إذا اختار "لا"، لا نفعل شيئاً ونبقى في الشاشة
            }
            else if (isSearchMode)
            {
                clear_PRICING();
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

            txtPriceLevelId.ReadOnly = true;
            txtLevelName.ReadOnly = true;            
            txtDieselHourPrice.ReadOnly = true;            
            txtDieselUsedHour.ReadOnly = true;            
            txtWaterHourPrice.ReadOnly = true;            
            txtNotes.ReadOnly = true;
        }
         private void SetViewMode()
        {
            btnView.Enabled = true;
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnSearch.Enabled = true;
            
            txtPriceLevelId.ReadOnly = true;
            txtLevelName.ReadOnly = true;            
            txtDieselHourPrice.ReadOnly = true;            
            txtDieselUsedHour.ReadOnly = true;            
            txtWaterHourPrice.ReadOnly = true;            
            txtNotes.ReadOnly = true;
        }

        private void SetAddMode()
        {
            btnSave.Enabled = true;
            btnView.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = false;
            btnSearch.Enabled = false;
            
            txtPriceLevelId.ReadOnly = false;
            txtLevelName.ReadOnly = false;  
            dtpPricingDate.Enabled = true;
            txtDieselHourPrice.ReadOnly = false;            
            txtDieselUsedHour.ReadOnly = false;            
            txtWaterHourPrice.ReadOnly = false;            
            txtNotes.ReadOnly = false;
        }

        private void SetEditMode()
        {
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnView.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSearch.Enabled = false;

            txtPriceLevelId.ReadOnly = true;
            dtpPricingDate.Enabled = true;
            txtLevelName.ReadOnly = false;            
            txtDieselHourPrice.ReadOnly = false;            
            txtDieselUsedHour.ReadOnly = false;            
            txtWaterHourPrice.ReadOnly = false;            
            txtNotes.ReadOnly = false;
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

            clear_PRICING();

            txtPriceLevelId.ReadOnly = false;
            txtLevelName.ReadOnly = false;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime currentClickTime = DateTime.Now;
            TimeSpan timeSinceLastClick = currentClickTime - lastClickTime;

            // نقرتين متتاليتين → أول فاتورة
            if (timeSinceLastClick.TotalMilliseconds < DOUBLE_CLICK_INTERVAL)
            {
                LoadFirstPricing();
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
            // النقرة الثانية → البحث (بدون تحقق من customerId)
            SearchPricing();

        }       
        private void SearchPricing()
        {
            try
            {
                // الحصول على جميع القيود
                DataTable allPricings = pricing.GET_ALL_PRICINGS();

                if (allPricings == null || allPricings.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات مستويات الأسعار", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // البحث بناءً على الحقول المدخلة
                string searchPricingLvlId = txtPriceLevelId.Text.Trim();
                string searchLevelName = txtLevelName.Text.Trim();                          

                DataRow foundRow = null;

                // البحث في البيانات
                foreach (DataRow row in allPricings.Rows)
                {
                    bool matches = true;

                    // البحث برقم مستوى الأسعار
                    if (!string.IsNullOrWhiteSpace(searchPricingLvlId))
                    {
                        string pricingLvlId = row["PriceLevleId"] != DBNull.Value ? row["PriceLevleId"].ToString().Trim().ToUpper() : "";
                        if (pricingLvlId.IndexOf(searchPricingLvlId.Trim().ToUpper()) < 0)
                        {
                            matches = false;
                        }
                    }
                    // البحث باسم المستوى
                    if (matches && !string.IsNullOrWhiteSpace(searchLevelName))
                    {
                        string levelName = row["LevelName"] != DBNull.Value ? row["LevelName"].ToString().Trim().ToUpper() : "";
                        if (levelName.IndexOf(searchLevelName.Trim().ToUpper()) < 0)
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
                    LoadPricingData(foundRow);
                    SetViewMode();
                    isSearchMode = false;
                    
                }
                else
                {
                    MessageBox.Show("لم يتم العثور على قيد يطابق معايير البحث", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء البحث: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFirstPricing()
        {
            try
            {
                DataTable allPricings = pricing.GET_ALL_PRICINGS();

                if (allPricings == null || allPricings.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات مستويات الأسعار", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // تحميل بيانات أول مستوى أسعار
                LoadPricingData(allPricings.Rows[0]);
                SetViewMode();
                isSearchMode = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
    }
}

