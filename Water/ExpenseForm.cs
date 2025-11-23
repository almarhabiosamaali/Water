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
        Clas.expense exp = new Clas.expense();

        public ExpenseForm()
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
                DataTable dt = exp.GET_ALL_EXPENSES();
                
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات للعرض", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Form viewForm = new Form();
                viewForm.Text = "عرض القيود";
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
                        LoadExpenseData(row);
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
            clear_EXPENSE();
            txtExpenseCode.Enabled = true;
            btnSave.Text = "حفظ";
            MessageBox.Show("يمكنك الآن إدخال بيانات قيد جديد", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                txtExpenseCode.Enabled = false;
                btnSave.Text = "تحديث";
                MessageBox.Show("يمكنك الآن تعديل بيانات القيد", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    exp.DELETE_EXPENSE(txtExpenseCode.Text.Trim());
                    MessageBox.Show("تم حذف القيد بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_EXPENSE();
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
                    //Convert.ToDouble(txtAmount.Text) <= 0 ||
                    string.IsNullOrWhiteSpace(txtPeriodId.Text) ||
                    string.IsNullOrWhiteSpace(txtDescription.Text) ||
                    string.IsNullOrWhiteSpace(txtNotes.Text))
                {
                    MessageBox.Show("الرجاء إكمال جميع البيانات المطلوبة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (isEditMode)
                {
                    // تحديث بيانات القيد
                    exp.UPDATE_EXPENSE(
                        txtExpenseCode.Text.Trim(),
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
                    exp.ADD_POST(
                            "update",                                      // action
                            "2",                                           // doc_type (فاتورة مثلاً)
                            txtExpenseCode.Text.Trim(),                       // doc_no
                            cmbType.SelectedItem != null ? cmbType.SelectedItem.ToString() : "",                                            // doc_no_type (لو عندك كومبو أو قيمة.. حطها هنا)
                            txtPeriodId.Text.Trim(),                                            // period_id  (لو عندك فترة محاسبية.. حطها هنا)
                            cmbAccountType.SelectedItem.ToString(),                                        // cus_part_type (نوع العميل/الشريك - غيّرها حسب تصميمك)
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
                    exp.ADD_POST(
                            "insert",                                      // action
                            "2",                                           // doc_type (فاتورة مثلاً)
                            txtExpenseCode.Text.Trim(),                       // doc_no
                            cmbType.SelectedItem != null ? cmbType.SelectedItem.ToString() : "",                                            // doc_no_type (لو عندك كومبو أو قيمة.. حطها هنا)
                            txtPeriodId.Text.Trim(),                                            // period_id  (لو عندك فترة محاسبية.. حطها هنا)
                            cmbAccountType.SelectedItem.ToString(),                                        // cus_part_type (نوع العميل/الشريك - غيّرها حسب تصميمك)
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
                txtExpenseCode.Enabled = true;
                btnSave.Text = "حفظ";
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

            txtPeriodId.Text = row["period_id"].ToString();
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
            txtAmount.Text = "0";
            txtPeriodId.Clear();
            txtDescription.Clear();
            txtNotes.Clear();
        }

        private void GoFocus(object sender, EventArgs e)
        {
            txtAmount.Select(0, txtAmount.Text.Length);
        }
    }
}

