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
            try
            {
                DataTable dt = pricing.GET_ALL_PRICINGS();

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات للعرض", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Form viewForm = new Form();
                viewForm.Text = "عرض مستويات الأسعار";
                viewForm.RightToLeft = RightToLeft.Yes;
                viewForm.RightToLeftLayout = true;
                viewForm.Size = new Size(1400, 600);
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
                        LoadPricingData(row);
                        viewForm.Close();
                    }
                };

                viewForm.Controls.Add(dgv);
                viewForm.ShowDialog();
                SetViewMode();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء عرض البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isEditMode = false;
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

                clear_PRICING();
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

