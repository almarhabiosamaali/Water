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
        Clas.partners partner = new Clas.partners();

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
            try
            {
                DataTable dt = partner.GET_ALL_PARTNERS();
                
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات للعرض", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Form viewForm = new Form();
                viewForm.Text = "عرض الشركاء";
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
                        LoadPartnerData(row);
                        viewForm.Close();
                    }
                };

                viewForm.Controls.Add(dgv);
                viewForm.ShowDialog();
                /*txtPartnerName.Enabled = false;
                txtAllocatedHours.Enabled = false;
                txtMinutes.Enabled = false;
                txtAvalibleHours.Enabled = false;
                txtAvalibleMinutes.Enabled = false;
                txtPhone.Enabled = false;
                txtAddress.Enabled = false;
                txtNotes.Enabled = false;
                dtpDate.Enabled = false;
                btnSave.Enabled = false;*/
             
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء عرض البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isEditMode = false;
            clear_PARTNER();
            try
            {
                txtPartnerCode.Text = partner.GET_NEXT_PARTNER_CODE();
            }
            catch
            {
                txtPartnerCode.Text = "1";
            }
            //txtPartnerCode.Enabled = false;
            btnSave.Text = "حفظ";
           // MessageBox.Show("يمكنك الآن إدخال بيانات شريك جديد", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                DataTable dt = partner.VIEW_PARTNER(txtPartnerCode.Text.Trim());
                
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("الشريك غير موجود", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LoadPartnerData(dt.Rows[0]);
                isEditMode = true;
                //txtPartnerCode.Enabled = false;
                //btnSave.Enabled = true;
                btnSave.Text = "تحديث";
              //  MessageBox.Show("يمكنك الآن تعديل بيانات الشريك", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                txtPartnerCode.Enabled = true;
                btnSave.Text = "حفظ";
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

    }
}

