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
        Clas.GridBtnViewHelper gridBtnViewHelper = new Clas.GridBtnViewHelper();
        public CustomerForm()
        {
            InitializeComponent();
            btnView.Click += btnView_Click;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnSave.Click += btnSave_Click;
            cmbType.SelectedIndex=0;
            /*if (cmbType == null)
            {
                cmbType.SelectedIndex = 0; 
            }*/
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataTable dt = cus.GET_ALL_CUSTOMERS();
            DataRow row = gridBtnViewHelper.Show(dt, "عرض العملاء");
            if (row != null)
            {
                LoadCustomerData(row);
                SetViewMode();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isEditMode = false;
            clear_CUSTOMER();
            try
            {
                String id= cus.GET_NEXT_CUSTOMER_CODE();
                if (id == "1")
                {
                    txtCustomerCode.Text = "20001";
                }
                else{
                txtCustomerCode.Text = id;
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
                SetEditMode();              
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
                // التحقق من أن جميع الحقول المطلوبة مملوءة
                if (string.IsNullOrWhiteSpace(txtCustomerCode.Text) ||
                    string.IsNullOrWhiteSpace(txtCustomerName.Text) 
                 //  cmbType.SelectedIndex == -1
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
                SetAfterSaveMode();
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
            //cmbType.SelectedIndex =-1 ;
            txtPhone.Clear();
            txtAddress.Clear();
            txtNotes.Clear();
            dtpCreatedDate.Value = DateTime.Now;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
           
             if (btnSave.Enabled)
            {
                DialogResult result = MessageBox.Show($"هل تريد الرجوع وعدم حفظ البيانات ؟", "تأكيد الإلغاء", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    clear_CUSTOMER();
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

