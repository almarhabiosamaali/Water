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
    public partial class CustomerForm : Form
    {
        private bool isEditMode = false;
        Clas.customer cus = new Clas.customer();

        public CustomerForm()
        {
            InitializeComponent();
            btnView.Click += btnView_Click;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = cus.GET_ALL_CUSTOMERS();
                
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات للعرض", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Form viewForm = new Form();
                viewForm.Text = "عرض العملاء";
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
                        LoadCustomerData(row);
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
            clear_CUSTOMER();
            try
            {
                txtCustomerCode.Text = cus.GET_NEXT_CUSTOMER_CODE();
            }
            catch
            {
                txtCustomerCode.Text = "1";
            }
            txtCustomerCode.Enabled = false;
            btnSave.Text = "حفظ";
           // MessageBox.Show("يمكنك الآن إدخال بيانات عميل جديد", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerCode.Text))
            {
                MessageBox.Show("الرجاء إدخال كود العميل أو اختيار عميل من قائمة العرض", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable dt = cus.VIEW_CUSTOMER(txtCustomerCode.Text.Trim());
                
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("العميل غير موجود", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LoadCustomerData(dt.Rows[0]);
                isEditMode = true;
                txtCustomerCode.Enabled = false;
                btnSave.Text = "تحديث";
              //  MessageBox.Show("يمكنك الآن تعديل بيانات العميل", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerCode.Text))
            {
                MessageBox.Show("الرجاء إدخال كود العميل المراد حذفه", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "هل أنت متأكد من حذف العميل: " + txtCustomerCode.Text + "؟",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    cus.DELETE_CUSTOMER(txtCustomerCode.Text.Trim());
                    MessageBox.Show("تم حذف العميل بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_CUSTOMER();
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
                // التحقق من أن جميع الحقول المطلوبة مملوءة
                if (string.IsNullOrWhiteSpace(txtCustomerCode.Text) ||
                    string.IsNullOrWhiteSpace(txtCustomerName.Text) 
                   // cmbType.SelectedIndex == -1
                    )
                {
                    MessageBox.Show("الرجاء إدخال كود العميل واسم العميل ونوع العميل على الأقل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (isEditMode)
                {
                    // تحديث بيانات العميل
                    cus.UPDATE_CUSTOMER(
                        txtCustomerCode.Text.Trim(),
                        txtCustomerName.Text.Trim(),
                        cmbType.SelectedItem.ToString(),
                        txtPhone.Text.Trim(),
                        txtAddress.Text.Trim(),
                        txtNotes.Text.Trim(),
                        dtpCreatedDate.Value
                    );

                    MessageBox.Show("تم تحديث بيانات العميل بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // إضافة عميل جديد
                    cus.ADD_CUSTOMER(
                        txtCustomerCode.Text.Trim(),
                        txtCustomerName.Text.Trim(),
                        cmbType.SelectedItem.ToString(),
                        txtPhone.Text.Trim(),
                        txtAddress.Text.Trim(),
                        txtNotes.Text.Trim(),
                        dtpCreatedDate.Value
                    );

                    MessageBox.Show("تم حفظ بيانات العميل بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                clear_CUSTOMER();
                isEditMode = false;
                txtCustomerCode.Enabled = true;
                btnSave.Text = "حفظ";
            }
            catch (Exception ee)
            {
                MessageBox.Show("حدث خطأ أثناء الحفظ: " + ee.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCustomerData(DataRow row)
        {
            txtCustomerCode.Text = row["id"].ToString();
            txtCustomerName.Text = row["name"].ToString();
            
            string type = row["type"].ToString();
            if (cmbType.Items.Contains(type))
            {
                cmbType.SelectedItem = type;
            }

            txtPhone.Text = row["phone"] != DBNull.Value ? row["phone"].ToString() : "";
            txtAddress.Text = row["address"] != DBNull.Value ? row["address"].ToString() : "";
            txtNotes.Text = row["notes"] != DBNull.Value ? row["notes"].ToString() : "";
            
            if (row["created_date"] != DBNull.Value)
            {
                dtpCreatedDate.Value = Convert.ToDateTime(row["created_date"]);
            }
            else
            {
                dtpCreatedDate.Value = DateTime.Now;
            }
        }

        private void clear_CUSTOMER()
        {
            txtCustomerCode.Clear();
            txtCustomerName.Clear();
            cmbType.SelectedIndex = -1;
            txtPhone.Clear();
            txtAddress.Clear();
            txtNotes.Clear();
            dtpCreatedDate.Value = DateTime.Now;
        }

   

    }
}

