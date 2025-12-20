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
        Clas.account acc = new Clas.account();

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
            try
            {
                DataTable dt = acc.GET_ALL_ACCOUNTS();
                
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات للعرض", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Form viewForm = new Form();
                viewForm.Text = "عرض الحسابات";
                viewForm.RightToLeft = RightToLeft.Yes;
                viewForm.RightToLeftLayout = true;
                viewForm.Size = new Size(900, 500);
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
            clear_ACCOUNT();
            try
            {
                txtAccountCode.Text = acc.GET_NEXT_ACCOUNT_CODE();
            }
            catch
            {
                txtAccountCode.Text = "1";
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

                clear_ACCOUNT();
                isEditMode = false;
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
            this.Close();
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

