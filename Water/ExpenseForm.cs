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
    public partial class ExpenseForm : Form
    {
        private bool isEditMode = false;
        private bool isSearchMode = false; 
        private DateTime lastClickTime = DateTime.MinValue; // آخر وقت للنقر
        private const int DOUBLE_CLICK_INTERVAL = 500; 
        Clas.expense exp = new Clas.expense();
        Clas.customer customer = new Clas.customer();
        Clas.partners partners = new Clas.partners();
        Clas.account account = new Clas.account();
        Clas.period period = new Clas.period();
        Clas.GridBtnViewHelper gridBtnViewHelper = new Clas.GridBtnViewHelper();
        public ExpenseForm()
        {
            InitializeComponent();
            btnView.Click += btnView_Click;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnSave.Click += btnSave_Click;
           // btnSearch.Click += btnSearch_Click;
            // ربط أحداث F2 و Enter على حقل رقم الفترة لعرض قائمة الفترات
            //txtPeriodId.KeyDown += txtPeriodId_KeyDown;
            txtPeriodId.Leave += txtPeriodId_Leave;
            
            // ربط أحداث F2 و Enter على حقل رقم الحساب لعرض قائمة الحسابات/العملاء/الشركاء
            //txtAccountId.KeyDown += txtAccountId_KeyDown;
            txtAccountId.Leave += txtAccountId_Leave;
        }

        private void btnView_Click(object sender, EventArgs e)
        {            
            DataTable dt = exp.GET_ALL_EXPENSES();
            DataRow row = gridBtnViewHelper.Show(dt, "عرض القيود");
            if (row != null)
            {
                LoadExpenseData(row);
                isSearchMode = false;
                SetViewMode();
            }
        }
       

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isEditMode = false;
            isSearchMode = false;
            
            // الحصول على رقم القيد التالي أولاً
            string nextExpenseCode = "";
            try
            {
                nextExpenseCode = exp.GET_NEXT_EXPENSE_CODE();
            }
            catch
            {
                nextExpenseCode = "1";
            }
            
            // تعيين وضع الإضافة (سيقوم بمسح الحقول)
            SetAddMode();
            
            // إعادة تعيين رقم القيد بعد مسح الحقول
            txtExpenseCode.Text = nextExpenseCode;
         //   MessageBox.Show("يمكنك الآن إدخال بيانات قيد جديد", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtExpenseCode.Text))
            {
                MessageBox.Show("الرجاء إدخال كود القيد أو اختيار قيد من قائمة العرض", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable dt = exp.VIEW_EXPENSE(txtExpenseCode.Text.Trim());
                
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("القيد غير موجود", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LoadExpenseData(dt.Rows[0]);
                isEditMode = true;
                isSearchMode = false;
                SetEditMode();
                
               // MessageBox.Show("يمكنك الآن تعديل بيانات القيد", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtExpenseCode.Text))
            {
                MessageBox.Show("الرجاء إدخال كود القيد المراد حذفه", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "هل أنت متأكد من حذف القيد: " + txtExpenseCode.Text + "؟",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    exp.DELETE_POST("delete", "2", txtExpenseCode.Text.Trim());
                    exp.DELETE_EXPENSE(txtExpenseCode.Text.Trim());
                    MessageBox.Show("تم حذف القيد بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_EXPENSE();
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
                if (string.IsNullOrWhiteSpace(txtExpenseCode.Text) ||
                    cmbType.SelectedIndex == -1 ||
                    cmbAccountType.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(txtAccountId.Text) ||
                    string.IsNullOrWhiteSpace(txtAccountName.Text) ||
                    string.IsNullOrWhiteSpace(txtAmount.Text) ||
                    string.IsNullOrWhiteSpace(txtPeriodId.Text) ||
                    string.IsNullOrWhiteSpace(txtNotes.Text))
                {
                    MessageBox.Show("الرجاء إكمال جميع البيانات المطلوبة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (isEditMode)
                {
                    exp.DELETE_POST("delete", "2", txtExpenseCode.Text.Trim());
                    exp.UPDATE_EXPENSE(
                        txtExpenseCode.Text.Trim(),
                        "2", // doc_type = 2 (قيمة ثابتة)
                        dtpDate.Value.Date,
                        cmbType.SelectedItem.ToString(),
                        cmbAccountType.SelectedItem.ToString(),
                        txtAccountId.Text.Trim(),
                        txtAccountName.Text.Trim(),
                        Convert.ToDouble(txtAmount.Text),
                      //  (double)txtAmount.Text,
                        txtPeriodId.Text.Trim(),
                        txtDescription.Text.Trim(),
                        txtNotes.Text.Trim()
                    );
                    double dr = 0;
                        double cr = 0;
                        
                        if (cmbType.Text == "صرف")
                        {
                            dr = Convert.ToDouble(txtAmount.Text);  // مدين
                            cr = 0;
                        }
                        else if (cmbType.Text == "قبض")
                        {
                            cr = Convert.ToDouble(txtAmount.Text);  // دائن
                            dr = 0;
                        }

                    string cusPartType = "";
                    if (cmbAccountType != null && cmbAccountType.SelectedIndex == 1) // شريك
                    {
                        cusPartType = "2";
                    }
                    else if (cmbAccountType != null && cmbAccountType.SelectedIndex == 0) //عميل
                    {
                        cusPartType = "1";
                    }
                    else // عميل
                    {
                        cusPartType = "3";
                    }
                    exp.ADD_POST(
                            "insert",                                      // action
                            "2",                                           // doc_type (فاتورة مثلاً)
                            txtExpenseCode.Text.Trim(),                       // doc_no
                            cmbType.SelectedItem != null ? cmbType.SelectedItem.ToString() : "",                                            // doc_no_type (لو عندك كومبو أو قيمة.. حطها هنا)
                            txtPeriodId.Text.Trim(),                                            // period_id  (لو عندك فترة محاسبية.. حطها هنا)
                            cusPartType,                                        // cus_part_type (نوع العميل/الشريك - غيّرها حسب تصميمك)
                            txtAccountId.Text.Trim(),                     // cus_part_no
                            txtAccountName.Text.Trim(),
                            dr,
                            cr,
                            dtpDate.Value.Date,
                            txtNotes.Text.Trim(),                                         // note
                            "1"                       // user_id (المستخدم المسجل الدخول)
                        );

                    MessageBox.Show("تم تحديث بيانات القيد بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // إضافة قيد جديد
                    exp.ADD_EXPENSE(
                        txtExpenseCode.Text.Trim(),
                        "2", // doc_type = 2 (قيمة ثابتة)
                        dtpDate.Value.Date,
                        cmbType.SelectedItem.ToString(),
                        cmbAccountType.SelectedItem.ToString(),
                        txtAccountId.Text.Trim(),
                        txtAccountName.Text.Trim(),
                        Convert.ToDouble(txtAmount.Text),
                        txtPeriodId.Text.Trim(),
                        txtDescription.Text.Trim(),
                        txtNotes.Text.Trim()
                    );
                        double dr = 0;
                        double cr = 0;

                        if (cmbType.Text == "صرف")
                        {
                            dr = Convert.ToDouble(txtAmount.Text);  // مدين
                        cr = 0;
                        }
                        else if (cmbType.Text == "قبض")
                        {
                            cr = Convert.ToDouble(txtAmount.Text);  // دائن
                        dr = 0;
                        }
                    string cusPartType = "";
                    if (cmbAccountType != null && cmbAccountType.SelectedIndex == 1) // شريك
                    {
                        cusPartType = "2";
                    }
                    else if (cmbAccountType != null && cmbAccountType.SelectedIndex == 0) //عميل
                    {
                        cusPartType = "1";
                    }
                    else // عميل
                    {
                        cusPartType = "3";
                    }
                    exp.ADD_POST(
                            "insert",                                      // action
                            "2",                                           // doc_type (فاتورة مثلاً)
                            txtExpenseCode.Text.Trim(),                       // doc_no
                            cmbType.SelectedItem != null ? cmbType.SelectedItem.ToString() : "",                                            // doc_no_type (لو عندك كومبو أو قيمة.. حطها هنا)
                            txtPeriodId.Text.Trim(),                                            // period_id  (لو عندك فترة محاسبية.. حطها هنا)
                            cusPartType,                                        // cus_part_type (نوع العميل/الشريك - غيّرها حسب تصميمك)
                            txtAccountId.Text.Trim(),                     // cus_part_no
                            txtAccountName.Text.Trim(),
                            dr,
                            cr,
                            dtpDate.Value.Date,
                            txtNotes.Text.Trim(),                                         // note
                            "1"                       // user_id (المستخدم المسجل الدخول)
                        );

                    MessageBox.Show("تم حفظ بيانات القيد بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                clear_EXPENSE();
                isEditMode = false;
                isSearchMode = false;                
                SetAfterSaveMode();
            }
            
                catch (System.Data.SqlClient.SqlException sqlEx)
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

        private void LoadExpenseData(DataRow row)
        {
            txtExpenseCode.Text = row["id"].ToString();
            
            if (row["date"] != DBNull.Value)
            {
                dtpDate.Value = Convert.ToDateTime(row["date"]);
            }

            string type = row["type"].ToString();
            if (cmbType.Items.Contains(type))
            {
                cmbType.SelectedItem = type;
            }

            string accountType = row["Account_Type"].ToString();
            if (cmbAccountType.Items.Contains(accountType))
            {
                cmbAccountType.SelectedItem = accountType;
            }

            txtAccountId.Text = row["account_id"].ToString();
            txtAccountName.Text = row["Account_name"].ToString();

            if (row["amount"] != DBNull.Value)
            {
                txtAmount.Text = row["amount"].ToString();
            }

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
                        LoadPeriodDataToExpenses(periodDt.Rows[0]);
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

            txtDescription.Text = row["description"].ToString();
            txtNotes.Text = row["notes"].ToString();
        }

        private void clear_EXPENSE()
        {
            txtExpenseCode.Clear();
            dtpDate.Value = DateTime.Now;
            cmbType.SelectedIndex = -1;
            cmbAccountType.SelectedIndex = -1;
            txtAccountId.Clear();
            txtAccountName.Clear();
            txtAmount.Clear();
            txtPeriodId.Clear();
            txtPeriodStartDate.Clear();
            txtPeriodEndDate.Clear();
            txtDescription.Clear();
            txtNotes.Clear();
            txtPeriodStartDate.Clear();
            txtPeriodEndDate.Clear();
        }

        private void GoFocus(object sender, EventArgs e)
        {
            txtAmount.Select(0, txtAmount.Text.Length);
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(txtAmount.Text, out double value))
            {
                txtAmount.Text = value.ToString("");  // مثل 1,250.00
            }
        }

        private void txtPeriodId_KeyDown(object sender, KeyEventArgs e)
        {
            // عرض قائمة الفترات عند الضغط على F2 أو Enter
            if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // منع التنقل الافتراضي لـ Enter
                // استخدام الكلاس المساعد الموحد
                Clas.PeriodHelper.ShowPeriodsList(txtPeriodId, txtPeriodStartDate, txtPeriodEndDate);
            }
        }

        private void txtAccountId_KeyDown(object sender, KeyEventArgs e)
        {
            // عرض قائمة الحسابات/العملاء/الشركاء عند الضغط على F2 أو Enter
            if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // منع التنقل الافتراضي لـ Enter
                ShowAccountList();
            }
        }

        private void ShowAccountList()
        {
            try
            {
                // التحقق من نوع الحساب المحدد
                if (cmbAccountType.SelectedIndex == -1)
                {
                    MessageBox.Show("الرجاء اختيار نوع الحساب أولاً", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string accountType = cmbAccountType.SelectedItem.ToString();
                DataTable dt = null;
                string formTitle = "";

                // تحديد نوع البيانات بناءً على اختيار نوع الحساب
                if (accountType == "عميل")
                {
                    dt = customer.GET_ALL_CUSTOMERS();
                    formTitle = "عرض بيانات العملاء";
                }
                else if (accountType == "شريك")
                {
                    dt = partners.GET_ALL_PARTNERS();
                    formTitle = "عرض بيانات الشركاء";
                }
                else if (accountType == "حساب")
                {
                    dt = account.GET_ALL_ACCOUNTS();
                    formTitle = "عرض بيانات الحسابات";
                }
                else
                {
                    MessageBox.Show("نوع الحساب غير معروف", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات للعرض", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Form viewForm = new Form();
                viewForm.Text = formTitle;
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
                        LoadAccountData(row);
                        viewForm.Close();
                    }
                };
                dgv.KeyDown += (s, args) =>
                {
                    if (args.KeyCode == Keys.Enter && dgv.CurrentRow != null && dgv.CurrentRow.Index >= 0)
                    {
                        DataRow row = dt.Rows[dgv.CurrentRow.Index];
                        LoadAccountData(row);
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

        private void LoadAccountData(DataRow row)
        {
            // ملء رقم الحساب/العميل/الشريك
            if (row["id"] != DBNull.Value)
            {
                txtAccountId.Text = row["id"].ToString();
            }
            else
            {
                txtAccountId.Clear();
            }

            // ملء اسم الحساب/العميل/الشريك
            if (row["name"] != DBNull.Value)
            {
                txtAccountName.Text = row["name"].ToString();
            }
            else
            {
                txtAccountName.Clear();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
         if (btnSave.Enabled)
            {
                DialogResult result = MessageBox.Show($"هل تريد الرجوع وعدم حفظ البيانات ؟", "تأكيد الإلغاء", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    clear_EXPENSE();
                    isEditMode = false;
                    isSearchMode = false;
                    SetNormalMode();
                }
                // إذا اختار "لا"، لا نفعل شيئاً ونبقى في الشاشة
            }
            else if (isSearchMode)
            {
                clear_EXPENSE();
                isEditMode = false;
                isSearchMode = false;
                SetNormalMode();
            }
            else
            {                
                this.Close();
            }
        }
        

        private void txtPeriodId_Leave(object sender, EventArgs e)
        {        
            // التحقق من وجود رقم الفترة عند الانتقال من الحقل
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
                LoadPeriodDataToExpenses(dt.Rows[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء التحقق من رقم الفترة: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPeriodId.Focus();
            }
        }
        private void LoadPeriodDataToExpenses(DataRow row)
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

        private void txtAccountId_Leave(object sender, EventArgs e)
        {
            if(isSearchMode)
            {
                return;
            }
            // التحقق من وجود رقم الحساب/العميل/الشريك عند الانتقال من الحقل
            if (txtAccountId == null || string.IsNullOrWhiteSpace(txtAccountId.Text))
            {
                // مسح اسم الحساب إذا كان الحقل فارغاً
                if (txtAccountName != null)
                    txtAccountName.Clear();
                return;
            }

            // التحقق من اختيار نوع الحساب
            if (cmbAccountType == null || cmbAccountType.SelectedIndex == -1)
            {
                MessageBox.Show("الرجاء اختيار نوع الحساب أولاً", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAccountType.Focus();
                return;
            }

            try
            {
                string accountId = txtAccountId.Text.Trim();
                string accountType = cmbAccountType.SelectedItem.ToString();
                DataTable dt = null;

                // تحديد نوع البيانات بناءً على اختيار نوع الحساب
                if (accountType == "عميل")
                {
                    dt = customer.VIEW_CUSTOMER(accountId);
                }
                else if (accountType == "شريك")
                {
                    dt = partners.VIEW_PARTNER(accountId);
                }
                else if (accountType == "حساب")
                {
                    dt = account.VIEW_ACCOUNT(accountId);
                }
                else
                {
                    MessageBox.Show("نوع الحساب غير معروف", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAccountId.Focus();
                    return;
                }

                // التحقق من وجود البيانات
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show($"رقم {accountType} غير موجود", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbAccountType.Focus();
                    // مسح اسم الحساب
                    if (txtAccountName != null)
                        txtAccountName.Clear();
                    return;
                }

                // تحميل بيانات الحساب/العميل/الشريك
                LoadAccountData(dt.Rows[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء التحقق من رقم الحساب: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAccountId.Focus();
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

            txtExpenseCode.ReadOnly = true;
            cmbType.SelectedIndex = -1;
            cmbAccountType.SelectedIndex = -1;
            txtAccountId.ReadOnly = true;
            txtAccountName.ReadOnly = true;
            txtAmount.ReadOnly = true;
            txtPeriodId.ReadOnly = true;
            txtDescription.ReadOnly = true;
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

            txtExpenseCode.ReadOnly = true;
            txtAccountId.ReadOnly = true;
            txtAccountName.ReadOnly = true;
            txtAmount.ReadOnly = true;
            txtPeriodId.ReadOnly = true;
            txtDescription.ReadOnly = true;
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

            clear_EXPENSE();

            txtExpenseCode.ReadOnly = true;                        
            txtAccountId.ReadOnly = false;
            txtAccountName.ReadOnly = false;
            txtAmount.ReadOnly = false;
            txtPeriodId.ReadOnly = false;
            txtDescription.ReadOnly = false;
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

            txtExpenseCode.ReadOnly = true;
            txtAccountId.ReadOnly = true;
            txtAccountName.ReadOnly = true;
            txtAmount.ReadOnly = false;
            txtPeriodId.ReadOnly = false;
            txtDescription.ReadOnly = false;
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

            clear_EXPENSE();

            txtExpenseCode.ReadOnly = false;
            cmbType.SelectedIndex = -1;
            cmbAccountType.SelectedIndex = -1;
            txtAccountId.ReadOnly = false;
            txtAccountName.ReadOnly = false;
            txtAmount.ReadOnly = false;
            txtPeriodId.ReadOnly = false;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {                     
            DateTime currentClickTime = DateTime.Now;
            TimeSpan timeSinceLastClick = currentClickTime - lastClickTime;

            // نقرتين متتاليتين → أول فاتورة
            if (timeSinceLastClick.TotalMilliseconds < DOUBLE_CLICK_INTERVAL)
            {
                LoadFirstExpense();
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
            SearchExpense();
        }

         private void SearchExpense()
        {
            try
            {
                // الحصول على جميع القيود
                DataTable allExpenses = exp.GET_ALL_EXPENSES();

                if (allExpenses == null || allExpenses.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات قيود", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // البحث بناءً على الحقول المدخلة
                string searchExpenseCode = txtExpenseCode.Text.Trim();
                string searchExpenseType = cmbType.SelectedIndex >= 0 ? cmbType.SelectedItem.ToString().Trim() : "";
                string searchAccountType = cmbAccountType.SelectedIndex >= 0 ? cmbAccountType.SelectedItem.ToString().Trim() : "";
                string searchAccountId = txtAccountId.Text.Trim();
                string searchAccountName = txtAccountName.Text.Trim(); 
                string searchAmount = txtAmount.Text.Trim();               

                DataRow foundRow = null;

                // البحث في البيانات
                foreach (DataRow row in allExpenses.Rows)
                {
                    bool matches = true;

                    // البحث برقم القيد
                    if (!string.IsNullOrWhiteSpace(searchExpenseCode))
                    {
                        string expenseId = row["id"] != DBNull.Value ? row["id"].ToString().Trim().ToUpper() : "";
                        if (expenseId.IndexOf(searchExpenseCode.Trim().ToUpper()) < 0)
                        {
                            matches = false;
                        }
                    }
                     // البحث بنوع القيد
                    if (matches && !string.IsNullOrWhiteSpace(searchExpenseType))
                    {
                        string expenseType = row["type"] != DBNull.Value ? row["type"].ToString().Trim().ToUpper() : "";
                        if (expenseType.IndexOf(searchExpenseType.Trim().ToUpper()) < 0)
                        {
                            matches = false;
                        }
                    }
                     // البحث بنوع الحساب
                    if (matches && !string.IsNullOrWhiteSpace(searchAccountType))
                    {
                        string accountType = row["Account_Type"] != DBNull.Value ? row["Account_Type"].ToString().Trim().ToUpper() : "";
                        if (accountType.IndexOf(searchAccountType.Trim().ToUpper()) < 0)
                        {
                            matches = false;
                        }
                    }
                     // البحث برقم الحساب
                    if (matches && !string.IsNullOrWhiteSpace(searchAccountId))
                    {
                        string accountId = row["account_id"] != DBNull.Value ? row["account_id"].ToString().Trim().ToUpper() : "";
                        if (accountId.IndexOf(searchAccountId.Trim().ToUpper()) < 0)
                        {
                            matches = false;
                        }
                    }
                    // البحث باسم الحساب/العميل/الشريك
                    if (matches && !string.IsNullOrWhiteSpace(searchAccountName))
                    {
                        string accountName = row["Account_name"] != DBNull.Value ? row["Account_name"].ToString().Trim().ToUpper() : "";
                        if (accountName.IndexOf(searchAccountName.Trim().ToUpper()) < 0)
                        {
                            matches = false;
                        }
                    }
                    // البحث بالمبلغ
                    if (matches && !string.IsNullOrWhiteSpace(searchAmount))
                    {
                        try
                        {
                            double searchAmountValue = Convert.ToDouble(searchAmount);
                            if (row["amount"] != DBNull.Value)
                            {
                                double amountValue = Convert.ToDouble(row["amount"]);
                                if (Math.Abs(searchAmountValue - amountValue) > 0.01) // مقارنة مع تحمل صغير للأخطاء العشرية
                                {
                                    matches = false;
                                }
                            }
                            else
                            {
                                matches = false;
                            }
                        }
                        catch
                        {
                            // إذا كان المبلغ غير صحيح، تجاهل هذا الشرط
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
                    LoadExpenseData(foundRow);
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

        private void LoadFirstExpense()
        {
            try
            {
                DataTable allExpenses = exp.GET_ALL_EXPENSES();

                if (allExpenses == null || allExpenses.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات السندات", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // تحميل بيانات أول سند
                LoadExpenseData(allExpenses.Rows[0]);
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

