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
    public partial class SalesForm : Form
    {
        private bool isEditMode = false;
        Clas.sales sal = new Clas.sales();
        private System.Windows.Forms.Label lblBillType;
        private System.Windows.Forms.ComboBox cmbBillType;

        public SalesForm()
        {
            InitializeComponent();
            InitializeBillTypeField();
            btnView.Click += btnView_Click;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnSave.Click += btnSave_Click;
        }


        private void InitializeBillTypeField()
        {
            this.lblBillType = new System.Windows.Forms.Label();
            this.cmbBillType = new System.Windows.Forms.ComboBox();
            
            this.lblBillType.AutoSize = true;
            this.lblBillType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillType.Location = new System.Drawing.Point(30, 70);
            this.lblBillType.Name = "lblBillType";
            this.lblBillType.Size = new System.Drawing.Size(100, 20);
            this.lblBillType.TabIndex = 100;
            this.lblBillType.Text = "نوع الفاتورة:";
            this.lblBillType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            this.cmbBillType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBillType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBillType.FormattingEnabled = true;
            this.cmbBillType.Items.AddRange(new object[] { "آجل", "نقد" });
            this.cmbBillType.Location = new System.Drawing.Point(150, 67);
            this.cmbBillType.Name = "cmbBillType";
            this.cmbBillType.Size = new System.Drawing.Size(300, 28);
            this.cmbBillType.TabIndex = 101;
            this.cmbBillType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            this.Controls.Add(this.lblBillType);
            this.Controls.Add(this.cmbBillType);

            // تعديل مواضع العناصر الأخرى
            this.lblPeriodId.Location = new System.Drawing.Point(30, 110);
            this.txtPeriodId.Location = new System.Drawing.Point(150, 107);
            this.lblCustomerId.Location = new System.Drawing.Point(30, 150);
            this.txtCustomerId.Location = new System.Drawing.Point(150, 147);
            this.lblStartTime.Location = new System.Drawing.Point(30, 190);
            this.dtpStartTime.Location = new System.Drawing.Point(150, 187);
            this.lblEndTime.Location = new System.Drawing.Point(30, 230);
            this.dtpEndTime.Location = new System.Drawing.Point(150, 227);
            this.lblHours.Location = new System.Drawing.Point(30, 270);
            this.numHours.Location = new System.Drawing.Point(150, 267);
            this.lblMinutes.Location = new System.Drawing.Point(30, 310);
            this.numMinutes.Location = new System.Drawing.Point(150, 307);
            this.lblWaterHourPrice.Location = new System.Drawing.Point(30, 350);
            this.numWaterHourPrice.Location = new System.Drawing.Point(150, 347);
            this.lblDieselHourPrice.Location = new System.Drawing.Point(30, 390);
            this.numDieselHourPrice.Location = new System.Drawing.Point(150, 387);
            this.lblWaterTotal.Location = new System.Drawing.Point(30, 430);
            this.numWaterTotal.Location = new System.Drawing.Point(150, 427);
            this.lblDieselTotal.Location = new System.Drawing.Point(30, 470);
            this.numDieselTotal.Location = new System.Drawing.Point(150, 467);
            this.lblTotalAmount.Location = new System.Drawing.Point(30, 510);
            this.numTotalAmount.Location = new System.Drawing.Point(150, 507);
            this.lblDueAmount.Location = new System.Drawing.Point(30, 550);
            this.numDueAmount.Location = new System.Drawing.Point(150, 547);
            this.lblPaidAmount.Location = new System.Drawing.Point(30, 590);
            this.numPaidAmount.Location = new System.Drawing.Point(150, 587);
            this.lblRemainingAmount.Location = new System.Drawing.Point(30, 630);
            this.numRemainingAmount.Location = new System.Drawing.Point(150, 627);
            this.btnView.Location = new System.Drawing.Point(30, 680);
            this.btnAdd.Location = new System.Drawing.Point(125, 680);
            this.btnEdit.Location = new System.Drawing.Point(220, 680);
            this.btnDelete.Location = new System.Drawing.Point(315, 680);
            this.btnSave.Location = new System.Drawing.Point(410, 680);

            this.ClientSize = new System.Drawing.Size(520, 740);
        }


        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = sal.GET_ALL_SALES();
                
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات للعرض", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Form viewForm = new Form();
                viewForm.Text = "عرض المبيعات";
                viewForm.RightToLeft = RightToLeft.Yes;
                viewForm.RightToLeftLayout = true;
                viewForm.Size = new Size(1400, 700);
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
                        LoadSalesData(row);
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
            clear_SALES();
            txtSalesCode.Enabled = true;
            btnSave.Text = "حفظ";
            MessageBox.Show("يمكنك الآن إدخال بيانات فاتورة جديدة", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSalesCode.Text))
            {
                MessageBox.Show("الرجاء إدخال كود الفاتورة أو اختيار فاتورة من قائمة العرض", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable dt = sal.VIEW_SALES(txtSalesCode.Text.Trim());
                
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("الفاتورة غير موجودة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LoadSalesData(dt.Rows[0]);
                isEditMode = true;
                txtSalesCode.Enabled = false;
                btnSave.Text = "تحديث";
                MessageBox.Show("يمكنك الآن تعديل بيانات الفاتورة", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSalesCode.Text))
            {
                MessageBox.Show("الرجاء إدخال كود الفاتورة المراد حذفها", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "هل أنت متأكد من حذف الفاتورة: " + txtSalesCode.Text + "؟",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    sal.DELETE_SALES(txtSalesCode.Text.Trim());
                    MessageBox.Show("تم حذف الفاتورة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_SALES();
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
                if (string.IsNullOrWhiteSpace(txtSalesCode.Text) ||
                    cmbBillType.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(txtCustomerId.Text) ||
                    numHours.Value <= 0 ||
                    numMinutes.Value <= 0 ||
                    numWaterHourPrice.Value <= 0 ||
                    numDieselHourPrice.Value <= 0 ||
                    numWaterTotal.Value <= 0 ||
                    numDieselTotal.Value <= 0 ||
                    numTotalAmount.Value <= 0 ||
                    numDueAmount.Value < 0 ||
                    numPaidAmount.Value < 0 ||
                    numRemainingAmount.Value < 0)
                {
                    MessageBox.Show("الرجاء إكمال جميع البيانات المطلوبة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // التحقق من أن وقت النهاية بعد وقت البداية
                if (dtpEndTime.Value < dtpStartTime.Value)
                {
                    MessageBox.Show("وقت النهاية يجب أن يكون بعد وقت البداية", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (isEditMode)
                {
                    // تحديث بيانات الفاتورة
                    sal.UPDATE_SALES(
                        txtSalesCode.Text.Trim(),
                        cmbBillType.SelectedItem.ToString(),
                        txtPeriodId.Text.Trim(),
                        txtCustomerId.Text.Trim(),
                        dtpStartTime.Value,
                        dtpEndTime.Value,
                        (double)numHours.Value,
                        (double)numMinutes.Value,
                        (double)numWaterHourPrice.Value,
                        (double)numDieselHourPrice.Value,
                        (double)numWaterTotal.Value,
                        (double)numDieselTotal.Value,
                        (double)numTotalAmount.Value,
                        (double)numDueAmount.Value,
                        (double)numPaidAmount.Value,
                        (double)numRemainingAmount.Value
                    );

                    MessageBox.Show("تم تحديث بيانات الفاتورة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // إضافة فاتورة جديدة
                    sal.ADD_SALES(
                        txtSalesCode.Text.Trim(),
                        cmbBillType.SelectedItem.ToString(),
                        txtPeriodId.Text.Trim(),
                        txtCustomerId.Text.Trim(),
                        dtpStartTime.Value,
                        dtpEndTime.Value,
                        (double)numHours.Value,
                        (double)numMinutes.Value,
                        (double)numWaterHourPrice.Value,
                        (double)numDieselHourPrice.Value,
                        (double)numWaterTotal.Value,
                        (double)numDieselTotal.Value,
                        (double)numTotalAmount.Value,
                        (double)numDueAmount.Value,
                        (double)numPaidAmount.Value,
                        (double)numRemainingAmount.Value
                    );

                    MessageBox.Show("تم حفظ بيانات الفاتورة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                clear_SALES();
                isEditMode = false;
                txtSalesCode.Enabled = true;
                btnSave.Text = "حفظ";
            }
            catch (SqlException sqlEx)
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

        private void LoadSalesData(DataRow row)
        {
            txtSalesCode.Text = row["id"].ToString();
            
            string billType = row["bill_type"].ToString();
            if (cmbBillType.Items.Contains(billType))
            {
                cmbBillType.SelectedItem = billType;
            }

            if (row["period_id"] != DBNull.Value)
            {
                txtPeriodId.Text = row["period_id"].ToString();
            }
            else
            {
                txtPeriodId.Clear();
            }

            txtCustomerId.Text = row["customer_id"].ToString();
            
            if (row["start_time"] != DBNull.Value)
            {
                dtpStartTime.Value = Convert.ToDateTime(row["start_time"]);
            }

            if (row["end_time"] != DBNull.Value)
            {
                dtpEndTime.Value = Convert.ToDateTime(row["end_time"]);
            }

            if (row["hours"] != DBNull.Value)
            {
                numHours.Value = Convert.ToDecimal(row["hours"]);
            }

            if (row["minutes"] != DBNull.Value)
            {
                numMinutes.Value = Convert.ToDecimal(row["minutes"]);
            }

            if (row["water_hour_price"] != DBNull.Value)
            {
                numWaterHourPrice.Value = Convert.ToDecimal(row["water_hour_price"]);
            }

            if (row["diesel_hour_price"] != DBNull.Value)
            {
                numDieselHourPrice.Value = Convert.ToDecimal(row["diesel_hour_price"]);
            }

            if (row["water_total"] != DBNull.Value)
            {
                numWaterTotal.Value = Convert.ToDecimal(row["water_total"]);
            }

            if (row["diesel_total"] != DBNull.Value)
            {
                numDieselTotal.Value = Convert.ToDecimal(row["diesel_total"]);
            }

            if (row["total_amount"] != DBNull.Value)
            {
                numTotalAmount.Value = Convert.ToDecimal(row["total_amount"]);
            }

            if (row["due_amount"] != DBNull.Value)
            {
                numDueAmount.Value = Convert.ToDecimal(row["due_amount"]);
            }

            if (row["paid_amount"] != DBNull.Value)
            {
                numPaidAmount.Value = Convert.ToDecimal(row["paid_amount"]);
            }

            if (row["remaining_amount"] != DBNull.Value)
            {
                numRemainingAmount.Value = Convert.ToDecimal(row["remaining_amount"]);
            }

        }

        private void clear_SALES()
        {
            txtSalesCode.Clear();
            cmbBillType.SelectedIndex = -1;
            txtPeriodId.Clear();
            txtCustomerId.Clear();
            dtpStartTime.Value = DateTime.Now;
            dtpEndTime.Value = DateTime.Now;
            numHours.Value = 0;
            numMinutes.Value = 0;
            numWaterHourPrice.Value = 0;
            numDieselHourPrice.Value = 0;
            numWaterTotal.Value = 0;
            numDieselTotal.Value = 0;
            numTotalAmount.Value = 0;
            numDueAmount.Value = 0;
            numPaidAmount.Value = 0;
            numRemainingAmount.Value = 0;
        }

    }
}

