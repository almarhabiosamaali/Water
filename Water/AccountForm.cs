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
    public partial class AccountForm : Form
    {
        private bool isEditMode = false;
        private bool isSearchMode = false; 
        private DateTime lastClickTime = DateTime.MinValue; // آخر وقت للنقر
        private const int DOUBLE_CLICK_INTERVAL = 500; 
        Clas.account acc = new Clas.account();
        Clas.GridBtnViewHelper gridBtnViewHelper = new Clas.GridBtnViewHelper();
        public AccountForm()
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
            DataTable dt = acc.GET_ALL_ACCOUNTS();
            DataRow row = gridBtnViewHelper.Show(dt, "عرض الحسابات");
            if (row != null)
            {
                LoadAccountData(row);
                SetViewMode();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isEditMode = false;
            clear_ACCOUNT();
            try
            {  String id= acc.GET_NEXT_ACCOUNT_CODE();
                if (id == "1")
                {
                    txtAccountCode.Text = "30001";
                }
                else{
                txtAccountCode.Text = id;
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
            if (string.IsNullOrWhiteSpace(txtAccountCode.Text))
            {
                MessageBox.Show("الرجاء إدخال كود الحساب أو اختيار حساب من قائمة العرض", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable dt = acc.VIEW_ACCOUNT(txtAccountCode.Text.Trim());
                
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("الحساب غير موجود", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LoadAccountData(dt.Rows[0]);
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
            if (string.IsNullOrWhiteSpace(txtAccountCode.Text))
            {
                MessageBox.Show("الرجاء إدخال كود الحساب المراد حذفه", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "هل أنت متأكد من حذف الحساب: " + txtAccountCode.Text + "؟",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    acc.DELETE_ACCOUNT(txtAccountCode.Text.Trim());
                    MessageBox.Show("تم حذف الحساب بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_ACCOUNT();
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
                if (string.IsNullOrWhiteSpace(txtAccountCode.Text) ||
                    string.IsNullOrWhiteSpace(txtAccountName.Text) ||
                    string.IsNullOrWhiteSpace(txtNotes.Text))
                {
                    MessageBox.Show("الرجاء إكمال جميع البيانات المطلوبة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (isEditMode)
                {
                    // تحديث بيانات الحساب
                    acc.UPDATE_ACCOUNT(
                        txtAccountCode.Text.Trim(),
                        txtAccountName.Text.Trim(),
                        txtNotes.Text.Trim()
                    );

                    MessageBox.Show("تم تحديث بيانات الحساب بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // إضافة حساب جديد
                    acc.ADD_ACCOUNT(
                        txtAccountCode.Text.Trim(),
                        txtAccountName.Text.Trim(),
                        txtNotes.Text.Trim()
                    );

                    MessageBox.Show("تم حفظ بيانات الحساب بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }                
                isEditMode = false;
                isSearchMode = false;
                SetAfterSaveMode();
            }
            catch (Exception ee)
            {
                MessageBox.Show("حدث خطأ أثناء الحفظ: " + ee.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAccountData(DataRow row)
        {
            txtAccountCode.Text = row["id"].ToString();
            txtAccountName.Text = row["name"].ToString();
            txtNotes.Text = row["notes"].ToString();
        }

        private void clear_ACCOUNT()
        {
            txtAccountCode.Clear();
            txtAccountName.Clear();
            txtNotes.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
             if (btnSave.Enabled)
            {
                DialogResult result = MessageBox.Show($"هل تريد الرجوع وعدم حفظ البيانات ؟", "تأكيد الإلغاء", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    clear_ACCOUNT();
                    isEditMode = false;
                    isSearchMode = false;
                    SetNormalMode();
                }
                // إذا اختار "لا"، لا نفعل شيئاً ونبقى في الشاشة
            }
            else if (isSearchMode)
            {
                clear_ACCOUNT();
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

            txtAccountCode.ReadOnly = true;
            txtAccountName.ReadOnly = true;
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

            txtAccountCode.ReadOnly = true;
            txtAccountName.ReadOnly = true;
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
        
            txtAccountCode.ReadOnly = true;
            txtAccountName.ReadOnly = false;
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

            txtAccountCode.ReadOnly = true;
            txtAccountName.ReadOnly = false;
            txtNotes.ReadOnly = false;
        }
        private void SetDeleteMode()
        {                                   
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }
           private void SetSearchMode()
        {
            btnSearch.Enabled = true;
            btnView.Enabled = false;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;

            clear_ACCOUNT();

            txtAccountCode.ReadOnly = false;              
            txtAccountName.ReadOnly = false;            

        }

        private void SetAfterSaveMode()
        {
            SetNormalMode();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
        DateTime currentClickTime = DateTime.Now;
            TimeSpan timeSinceLastClick = currentClickTime - lastClickTime;

            // التحقق من النقر المزدوج (مرتين متتابعتين)
            if (timeSinceLastClick.TotalMilliseconds < DOUBLE_CLICK_INTERVAL)
            {
                // النقر المزدوج: إرجاع بيانات أول عميل
                LoadFirstAccount();
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
                SearchAccount();
            }

        }

        private void SearchAccount()
        {
            try
            {
                // الحصول على جميع الحسابات
                DataTable allAccounts = acc.GET_ALL_ACCOUNTS();

                if (allAccounts == null || allAccounts.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات حسابات", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // البحث بناءً على الحقول المدخلة
                string searchAccountCode = txtAccountCode.Text.Trim();
                string searchAccountName = txtAccountName.Text.Trim();                

                DataRow foundRow = null;

                // البحث في البيانات
                foreach (DataRow row in allAccounts.Rows)
                {
                    bool matches = true;

                    // البحث برقم الحساب
                    if (!string.IsNullOrWhiteSpace(searchAccountCode))
                    {
                        string accountId = row["id"] != DBNull.Value ? row["id"].ToString().Trim().ToUpper() : "";
                        if (accountId.IndexOf(searchAccountCode.Trim().ToUpper()) < 0)
                        {
                            matches = false;
                        }
                    }

                    // البحث باسم الحساب
                    if (matches && !string.IsNullOrWhiteSpace(searchAccountName))
                    {
                        string accountName = row["name"] != DBNull.Value ? row["name"].ToString().Trim().ToUpper() : "";
                        if (accountName.IndexOf(searchAccountName.Trim().ToUpper()) < 0)
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
                    LoadAccountData(foundRow);
                    SetViewMode();
                    isSearchMode = false;
                    
                }
                else
                {
                    MessageBox.Show("لم يتم العثور على حساب يطابق معايير البحث", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء البحث: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFirstAccount()
        {
            try
            {
                DataTable allAccounts = acc.GET_ALL_ACCOUNTS();

                if (allAccounts == null || allAccounts.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات حسابات", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // تحميل بيانات أول حساب
                LoadAccountData(allAccounts.Rows[0]);
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

