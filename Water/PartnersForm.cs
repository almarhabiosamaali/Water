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
    public partial class PartnersForm : Form
    {
        private bool isEditMode = false;
        private bool isSearchMode = false; 
        private DateTime lastClickTime = DateTime.MinValue; // آخر وقت للنقر
        private const int DOUBLE_CLICK_INTERVAL = 500; 
        Clas.partners partner = new Clas.partners();
        Clas.GridBtnViewHelper gridBtnViewHelper = new Clas.GridBtnViewHelper();

        public PartnersForm()
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
            DataTable dt = partner.GET_ALL_PARTNERS("1");

                DataRow row = gridBtnViewHelper.Show(dt, "عرض الشركاء");

                if (row != null)
                {
                    LoadPartnerData(row);
                    SetViewMode();
                }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isEditMode = false;
            clear_PARTNER();
            try
            {
                String id= partner.GET_NEXT_PARTNER_CODE();
                if (id == "1")
                {
                    txtPartnerCode.Text = "10001";
                }
                else{
                txtPartnerCode.Text = id;
                }
            }
            catch
            {
                MessageBox.Show("catch error");
            }
            SetAddMode();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPartnerCode.Text))
            {
                MessageBox.Show("الرجاء إدخال كود الشريك أو اختيار شريك من قائمة العرض", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable dt = partner.VIEW_PARTNER(txtPartnerCode.Text.Trim(),"1");
                
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("الشريك غير موجود", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LoadPartnerData(dt.Rows[0]);
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
            if (string.IsNullOrWhiteSpace(txtPartnerCode.Text))
            {
                MessageBox.Show("الرجاء إدخال كود الشريك المراد حذفه", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "هل أنت متأكد من حذف الشريك: " + txtPartnerCode.Text + "؟",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    partner.DELETE_PARTNER(txtPartnerCode.Text.Trim());
                    MessageBox.Show("تم حذف الشريك بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_PARTNER();
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
                if (string.IsNullOrWhiteSpace(txtPartnerCode.Text) ||
                    string.IsNullOrWhiteSpace(txtPartnerName.Text))
                {
                    MessageBox.Show("الرجاء إدخال كود الشريك واسم الشريك على الأقل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (isEditMode)
                {
                    // تحديث بيانات الشريك
                    partner.UPDATE_PARTNER(
                        txtPartnerCode.Text.Trim(),
                        txtPartnerName.Text.Trim(),
                        txtAllocatedHours.Text.Trim(),
                        txtMinutes.Text.Trim(),
                      //  txtAvalibleHours.Text.Trim(),
                        //txtAvalibleMinutes.Text.Trim(),
                        txtPhone.Text.Trim(),
                        txtAddress.Text.Trim(),
                        txtNotes.Text.Trim(),
                        dtpDate.Value
                    );

                    MessageBox.Show("تم تحديث بيانات الشريك بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // إضافة شريك جديد
                    partner.ADD_PARTNER(
                        txtPartnerCode.Text.Trim(),
                        txtPartnerName.Text.Trim(),
                        txtAllocatedHours.Text.Trim(),
                        txtMinutes.Text.Trim(),
                        //txtAvalibleHours.Text.Trim(),
                        //txtAvalibleMinutes.Text.Trim(),
                        txtPhone.Text.Trim(),
                        txtAddress.Text.Trim(),
                        txtNotes.Text.Trim(),
                        dtpDate.Value
                    );

                    MessageBox.Show("تم حفظ بيانات الشريك بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                clear_PARTNER();
                isEditMode = false;
                SetAfterSaveMode();
            }
            catch (Exception ee)
            {
                MessageBox.Show("حدث خطأ أثناء الحفظ: " + ee.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPartnerData(DataRow row)
        {
            txtPartnerCode.Text = row["id"].ToString();
            txtPartnerName.Text = row["name"].ToString();
            
            if (row["allocated_hours"] != DBNull.Value)
            {
                txtAllocatedHours.Text = row["allocated_hours"].ToString();
            }
            else
            {
                txtAllocatedHours.Clear();
            }

            if (row["minutes"] != DBNull.Value)
            {
                txtMinutes.Text = row["minutes"].ToString();
            }
            else
            {
                txtMinutes.Clear();
            }

            if (row["avalibleHours"] != DBNull.Value)
            {
                txtAvalibleHours.Text = row["avalibleHours"].ToString();
            }
            else
            {
                txtAvalibleHours.Clear();
            }

            if (row["avalibleMinutes"] != DBNull.Value)
            {
                txtAvalibleMinutes.Text = row["avalibleMinutes"].ToString();
            }
            else
            {
                txtAvalibleMinutes.Clear();
            }

            txtPhone.Text = row["phone"] != DBNull.Value ? row["phone"].ToString() : "";
            txtAddress.Text = row["address"] != DBNull.Value ? row["address"].ToString() : "";
            txtNotes.Text = row["notes"] != DBNull.Value ? row["notes"].ToString() : "";
            
            if (row["created_date"] != DBNull.Value)
            {
                dtpDate.Value = Convert.ToDateTime(row["created_date"]);
            }
            else
            {
                dtpDate.Value = DateTime.Now;
            }
        }

        private void clear_PARTNER()
        {
            txtPartnerCode.Clear();
            txtPartnerName.Clear();
            txtAllocatedHours.Clear();
            txtMinutes.Clear();
            txtAvalibleHours.Clear();
            txtAvalibleMinutes.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtNotes.Clear();
            dtpDate.Value = DateTime.Now;
        }

        private void txtAllocatedHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            // يسمح بالأرقام فقط + Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtMinutes_KeyPress(object sender, KeyPressEventArgs e)
        {
            // يسمح بالأرقام فقط + Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtAvalibleHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            // يسمح بالأرقام فقط + Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtAvalibleMinutes_KeyPress(object sender, KeyPressEventArgs e)
            {
                // يسمح بالأرقام فقط + Backspace
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }        

        private void SearchPartner()
        {
            try
            {
                // الحصول على جميع العملاء
                DataTable allPartners = partner.GET_ALL_PARTNERS("1");

                if (allPartners == null || allPartners.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات شركاء", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // البحث بناءً على الحقول المدخلة
                string searchCode = txtPartnerCode.Text.Trim();
                string searchName = txtPartnerName.Text.Trim();
                string searchPhone = txtPhone.Text.Trim();

                DataRow foundRow = null;

                // البحث في البيانات
                foreach (DataRow row in allPartners.Rows)
                {
                    bool matches = true;

                    // البحث برقم الشريك
                    if (!string.IsNullOrWhiteSpace(searchCode))
                    {
                        string customerId = row["id"] != DBNull.Value ? row["id"].ToString().Trim().ToUpper() : "";
                        if (customerId.IndexOf(searchCode.Trim().ToUpper()) < 0)
                        {
                            matches = false;
                        }
                    }

                    // البحث باسم الشريك
                    if (matches && !string.IsNullOrWhiteSpace(searchName))
                    {
                        string partnerName = row["name"] != DBNull.Value ? row["name"].ToString().Trim().ToUpper() : "";
                        if (partnerName.IndexOf(searchName.Trim().ToUpper()) < 0)
                        {
                            matches = false;
                        }
                    }

                    // البحث برقم الهاتف
                    if (matches && !string.IsNullOrWhiteSpace(searchPhone))
                    {
                        string partnerPhone = row["phone"] != DBNull.Value ? row["phone"].ToString().Trim().ToUpper() : "";
                        if (partnerPhone.IndexOf(searchPhone.Trim().ToUpper()) < 0)
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
                    LoadPartnerData(foundRow);
                    SetViewMode();
                    isSearchMode = false;
                    
                }
                else
                {
                    MessageBox.Show("لم يتم العثور على شريك يطابق معايير البحث", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء البحث: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFirstPartner()
        {
            try
            {
                DataTable allPartners = partner.GET_ALL_PARTNERS("1");

                if (allPartners == null || allPartners.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات شركاء", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // تحميل بيانات أول شريك
                LoadPartnerData(allPartners.Rows[0]);
                SetViewMode();
                isSearchMode = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }      


        private void btnExit_Click(object sender, EventArgs e)
        {            
            if (btnSave.Enabled)
            {
                DialogResult result = MessageBox.Show($"هل تريد الرجوع وعدم حفظ البيانات ؟", "تأكيد الإلغاء", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    clear_PARTNER();
                    isEditMode = false;                    
                    SetNormalMode();
                }
                // إذا اختار "لا"، لا نفعل شيئاً ونبقى في الشاشة
            }
            else if (isSearchMode)
            {
                clear_PARTNER();
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

            txtPartnerCode.ReadOnly = true;
            txtPartnerCode.Enabled = true;
            txtPartnerName.ReadOnly = true;
            txtAllocatedHours.ReadOnly = true;
            txtMinutes.ReadOnly = true;
            txtPhone.ReadOnly = true;
            txtAddress.ReadOnly = true;
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

            txtPartnerCode.ReadOnly = true;
            txtPartnerCode.Enabled = true;
            txtPartnerName.ReadOnly = true;
            txtAllocatedHours.ReadOnly = true;
            txtMinutes.ReadOnly = true;
            txtPhone.ReadOnly = true;
            txtAddress.ReadOnly = true;
            txtNotes.ReadOnly = true;
        }

        private void SetAddMode()
        {
            btnSave.Enabled = true;
            btnView.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = false;
            txtAllocatedHours.Text = "0";
            txtMinutes.Text = "0";
            btnSearch.Enabled = false;

            txtPartnerCode.ReadOnly = true;
            txtPartnerName.ReadOnly = false;
            txtAllocatedHours.ReadOnly = false;
            txtMinutes.ReadOnly = false;
            txtPhone.ReadOnly = false;
            txtAddress.ReadOnly = false;
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

            txtPartnerCode.ReadOnly = true;
            txtPartnerName.ReadOnly = false;
            txtAllocatedHours.ReadOnly = false;
            txtMinutes.ReadOnly = false;
            txtPhone.ReadOnly = false;
            txtAddress.ReadOnly = false;
            txtNotes.ReadOnly = false;
        }
        private void SetDeleteMode()
        {                                   
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            //btnSearch.Enabled = true;
        }

        private void SetAfterSaveMode()
        {
            btnSave.Enabled = false;
            btnView.Enabled = true;
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSearch.Enabled = true;

            txtPartnerCode.ReadOnly = true;
            txtPartnerName.ReadOnly = true;
            txtAllocatedHours.ReadOnly = true;
            txtMinutes.ReadOnly = true;
            txtPhone.ReadOnly = true;
            txtAddress.ReadOnly = true;
            txtNotes.ReadOnly = true;
        }       
        private void SetSearchMode()
        {
            btnSearch.Enabled = true;
            btnView.Enabled = false;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;

            clear_PARTNER();

            txtPartnerCode.ReadOnly = false;
            txtPartnerCode.Enabled = true;
            txtPartnerName.ReadOnly = false;
            txtPhone.ReadOnly = false;
            txtAddress.ReadOnly = false;
            //txtNotes.ReadOnly = false;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime currentClickTime = DateTime.Now;
            TimeSpan timeSinceLastClick = currentClickTime - lastClickTime;

            // التحقق من النقر المزدوج (مرتين متتابعتين)
            if (timeSinceLastClick.TotalMilliseconds < DOUBLE_CLICK_INTERVAL)
            {
                // النقر المزدوج: إرجاع بيانات أول عميل
                LoadFirstPartner();
                lastClickTime = DateTime.MinValue; // إعادة تعيين
                return;
            }

            lastClickTime = currentClickTime;

            // إذا لم تكن في وضع البحث، تفعيل الحقول
            if (!isSearchMode)
            {
                //EnableSearchFields();
                SetSearchMode();
                isSearchMode = true;
            }
            else
            {
                // البحث بناءً على الحقول المدخلة
                SearchPartner();
            }
        }
    }

}

