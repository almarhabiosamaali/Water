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
        Clas.salePartnersHours partnersHours = new Clas.salePartnersHours();
        Clas.customer customer = new Clas.customer();
        Clas.partners partners = new Clas.partners();

        public SalesForm()
        {
            InitializeComponent();
            InitializeDataGridViewEvents();
            btnView.Click += btnView_Click;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnSave.Click += btnSave_Click;
        }

        private void InitializeDataGridViewEvents()
        {
            // ربط حدث تغيير رقم الفاتورة لتحديث DataGridView
            this.txtSalesCode.TextChanged += TxtSalesCode_TextChanged;
            
            // ربط حدث إضافة صف جديد في DataGridView
            if (this.dataGridView1 != null)
            {
                this.dataGridView1.DefaultValuesNeeded += DataGridView1_DefaultValuesNeeded;
                this.dataGridView1.RowsAdded += DataGridView1_RowsAdded;
                this.dataGridView1.CellBeginEdit += DataGridView1_CellBeginEdit;
                this.dataGridView1.KeyDown += DataGridView1_KeyDown;
                this.dataGridView1.CellEnter += DataGridView1_CellEnter;
            }
        }

        private void TxtSalesCode_TextChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1 == null)
                return;

            string billNo = this.txtSalesCode.Text.Trim();
            
            // تحديث جميع الصفوف الموجودة في DataGridView
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                if (!row.IsNewRow && row.Cells["bill_no"] != null)
                {
                    row.Cells["bill_no"].Value = billNo;
                }
            }
        }

        private void DataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            // عند إضافة صف جديد، يتم ملء حقل رقم الفاتورة تلقائياً
            if (e.Row.Cells["bill_no"] != null)
            {
                e.Row.Cells["bill_no"].Value = this.txtSalesCode.Text.Trim();
            }
        }

        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // عند إضافة صف جديد، تحديث حقل رقم الفاتورة
            string billNo = this.txtSalesCode.Text.Trim();
            
            for (int i = 0; i < e.RowCount; i++)
            {
                int rowIndex = e.RowIndex + i;
                if (rowIndex < this.dataGridView1.Rows.Count)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[rowIndex];
                    if (row.Cells["bill_no"] != null)
                    {
                        row.Cells["bill_no"].Value = billNo;
                    }
                }
            }
        }

        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // عند بدء التحرير في صف جديد، ملء حقل رقم الفاتورة تلقائياً
            if (e.RowIndex >= 0 && e.RowIndex < this.dataGridView1.Rows.Count)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                if (row.IsNewRow && e.ColumnIndex >= 0 && this.dataGridView1.Columns[e.ColumnIndex].Name == "bill_no")
                {
                    row.Cells["bill_no"].Value = this.txtSalesCode.Text.Trim();
                }
            }
        }

        private void DataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            // عند الدخول إلى خلية PartenerId، يمكن فتح قائمة العملاء
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewColumn column = this.dataGridView1.Columns[e.ColumnIndex];
                if (column != null && column.Name == "PartenerId")
                {
                    // يمكن إضافة منطق إضافي هنا إذا لزم الأمر
                }
            }
        }

        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            // عند الضغط على Enter أو F2 في عمود PartenerId، فتح قائمة العملاء
            if (this.dataGridView1.CurrentCell != null && 
                this.dataGridView1.CurrentCell.ColumnIndex >= 0 &&
                this.dataGridView1.CurrentCell.RowIndex >= 0)
            {
                DataGridViewColumn column = this.dataGridView1.Columns[this.dataGridView1.CurrentCell.ColumnIndex];
                
                if (column != null && column.Name == "PartenerId" && 
                    (e.KeyCode == Keys.Enter || e.KeyCode == Keys.F2))
                {
                    e.Handled = true;
                    ShowCustomersList();
                }
            }
        }

        private void ShowCustomersList()
        {
            try
            {
                DataTable dt = partners.GET_ALL_PARTNERS();
                
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
                        LoadPartnerDataToGrid(row);
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

        private void LoadPartnerDataToGrid(DataRow partnerRow)
        {
            if (this.dataGridView1.CurrentCell == null || this.dataGridView1.CurrentCell.RowIndex < 0)
                return;

            int currentRowIndex = this.dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow dgvRow = this.dataGridView1.Rows[currentRowIndex];

            // تعبئة رقم الشريك
            if (dgvRow.Cells["PartenerId"] != null)
            {
                dgvRow.Cells["PartenerId"].Value = partnerRow["id"] != DBNull.Value ? partnerRow["id"].ToString() : "";
            }

            // تعبئة اسم الشريك
            if (dgvRow.Cells["PartenerName"] != null)
            {
                dgvRow.Cells["PartenerName"].Value = partnerRow["name"] != DBNull.Value ? partnerRow["name"].ToString() : "";
            }

            // تعبئة الساعات المتاحة من جدول partners
            if (dgvRow.Cells["HoursAvalible"] != null)
            {
                if (partnerRow["avalibleHours"] != DBNull.Value)
                {
                    dgvRow.Cells["HoursAvalible"].Value = partnerRow["avalibleHours"].ToString();
                }
                else
                {
                    dgvRow.Cells["HoursAvalible"].Value = "";
                }
            }

            // تعبئة الدقائق المتاحة من جدول partners
            if (dgvRow.Cells["MinutesAvalible"] != null)
            {
                if (partnerRow["avalibleMinutes"] != DBNull.Value)
                {
                    dgvRow.Cells["MinutesAvalible"].Value = partnerRow["avalibleMinutes"].ToString();
                }
                else
                {
                    dgvRow.Cells["MinutesAvalible"].Value = "";
                }
            }
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
                   // cmbBillType.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(txtCustomerId.Text) ||
                    numHours.Value <= 0 ||
                    numMinutes.Value <= 0 
                    /*numWaterHourPrice.Value <= 0 ||
                    numDieselHourPrice.Value <= 0 ||
                    numWaterTotal.Value <= 0 ||
                    numDieselTotal.Value <= 0 ||
                    numTotalAmount.Value <= 0 ||
                    numDueAmount.Value < 0 ||
                    numPaidAmount.Value < 0 ||
                    numRemainingAmount.Value < 0*/
                    )
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
                    
                    // تحديث بيانات الشركاء من DataGridView
                    DeletePartnersHoursFromDatabase(txtSalesCode.Text.Trim());
                    SavePartnersHoursFromGrid();
                    //UpdatePartnersHoursFromGrid();
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
                    
                    // حفظ بيانات الشركاء من DataGridView
                    SavePartnersHoursFromGrid();
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

            // تحميل بيانات الشركاء من قاعدة البيانات
            LoadPartnersHoursFromDatabase(txtSalesCode.Text.Trim());
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
            
            // مسح DataGridView
            if (this.dataGridView1 != null)
            {
                this.dataGridView1.DataSource = null;
                this.dataGridView1.Rows.Clear();
            }
        }

        private void LoadPartnersHoursFromDatabase(string billNo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(billNo))
                {
                    if (this.dataGridView1 != null)
                    {
                        this.dataGridView1.DataSource = null;
                        this.dataGridView1.Rows.Clear();
                    }
                    return;
                }

                // الحصول على بيانات الشركاء من قاعدة البيانات
                DataTable dt = partnersHours.GET_ALL_SALE_PARTNER_HOURS(billNo);

                if (this.dataGridView1 != null)
                {
                    // مسح البيانات الحالية
                    this.dataGridView1.Rows.Clear();

                    // إضافة البيانات إلى DataGridView
                    foreach (DataRow row in dt.Rows)
                    {
                        int rowIndex = this.dataGridView1.Rows.Add();
                        DataGridViewRow dgvRow = this.dataGridView1.Rows[rowIndex];

                        // حفظ Id في Tag للصف لاستخدامه لاحقاً في التحديث
                        if (row["Id"] != DBNull.Value)
                        {
                            dgvRow.Tag = row["Id"];
                        }

                        // ملء البيانات في الصف
                        if (dgvRow.Cells["bill_no"] != null)
                        {
                            dgvRow.Cells["bill_no"].Value = row["BillNo"] != DBNull.Value ? row["BillNo"].ToString() : "";
                        }

                        if (dgvRow.Cells["PartenerId"] != null)
                        {
                            dgvRow.Cells["PartenerId"].Value = row["PartnerNumber"] != DBNull.Value ? row["PartnerNumber"].ToString() : "";
                        }

                        if (dgvRow.Cells["PartenerName"] != null)
                        {
                            dgvRow.Cells["PartenerName"].Value = row["PartnerName"] != DBNull.Value ? row["PartnerName"].ToString() : "";
                        }

                        if (dgvRow.Cells["HoursUesed"] != null)
                        {
                            dgvRow.Cells["HoursUesed"].Value = row["HoursCount"] != DBNull.Value ? row["HoursCount"].ToString() : "";
                        }

                        if (dgvRow.Cells["MinutesCount"] != null)
                        {
                            dgvRow.Cells["MinutesCount"].Value = row["MinutesCount"] != DBNull.Value ? row["MinutesCount"].ToString() : "";
                        }

                        if (dgvRow.Cells["HoursAvalible"] != null)
                        {
                            dgvRow.Cells["HoursAvalible"].Value = row["HoursAvalible"] != DBNull.Value ? row["HoursAvalible"].ToString() : "";
                        }

                        if (dgvRow.Cells["MinutesAvalible"] != null)
                        {
                            dgvRow.Cells["MinutesAvalible"].Value = row["MinutesAvalible"] != DBNull.Value ? row["MinutesAvalible"].ToString() : "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل بيانات الشركاء: " + ex.Message, "خطأ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SavePartnersHoursFromGrid()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSalesCode.Text))
                {
                    return; // لا يوجد رقم فاتورة
                }

                string billNo = txtSalesCode.Text.Trim();
                DataGridView dgv = this.dataGridView1;

                if (dgv == null || dgv.Rows.Count == 0)
                {
                    return; // لا توجد بيانات في الجدول
                }

                int idCounter = 1;

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    // تخطي الصف الجديد (NewRow)
                    if (row.IsNewRow)
                        continue;

                    // قراءة البيانات من الصف
                    string partnerNumber = "";
                    string partnerName = "";
                    string hoursCount = "";
                    string minutesCount = "";
                    string hoursAvalible = "";
                    string minutesAvalible = "";
                    string totalHours = "";
                    

                    // قراءة البيانات من الأعمدة
                    if (row.Cells["PartenerId"] != null && row.Cells["PartenerId"].Value != null)
                    {
                        partnerNumber = row.Cells["PartenerId"].Value.ToString().Trim();
                    }

                    if (row.Cells["PartenerName"] != null && row.Cells["PartenerName"].Value != null)
                    {
                        partnerName = row.Cells["PartenerName"].Value.ToString().Trim();
                    }

                    if (row.Cells["HoursUesed"] != null && row.Cells["HoursUesed"].Value != null)
                    {
                        hoursCount = row.Cells["HoursUesed"].Value.ToString().Trim();
                    }

                    if (row.Cells["MinutesCount"] != null && row.Cells["MinutesCount"].Value != null)
                    {
                        minutesCount = row.Cells["MinutesCount"].Value.ToString().Trim();
                    }

                    if (row.Cells["HoursAvalible"] != null && row.Cells["HoursAvalible"].Value != null)
                    {
                        hoursAvalible = row.Cells["HoursAvalible"].Value.ToString().Trim();
                    }

                    if (row.Cells["MinutesAvalible"] != null && row.Cells["MinutesAvalible"].Value != null)
                    {
                        minutesAvalible = row.Cells["MinutesAvalible"].Value.ToString().Trim();
                    }

                    // حساب TotalHours: يمكن أن يكون مجموع HoursUesed و HoursAvalible
                    if (!string.IsNullOrWhiteSpace(hoursCount) && !string.IsNullOrWhiteSpace(hoursAvalible))
                    {
                        try
                        {
                            double hours = 0, avalible = 0;
                            if (double.TryParse(hoursCount, out hours) && double.TryParse(hoursAvalible, out avalible))
                            {
                                totalHours = (hours + avalible).ToString();
                            }
                            else
                            {
                                totalHours = hoursCount;
                            }
                        }
                        catch
                        {
                            totalHours = hoursCount;
                        }
                    }
                    else
                    {
                        totalHours = hoursCount ?? "";
                    }

                    // التحقق من أن البيانات الأساسية موجودة
                    if (true)
                    {
                        try
                        {
                            partnersHours.ADD_SALE_PARTNER_HOURS(
                                billNo,
                                idCounter,
                                partnerNumber ?? "",
                                partnerName ?? "",
                                hoursCount ?? "",
                                minutesCount ?? "",
                                hoursAvalible ?? "",
                                minutesAvalible ?? "",
                                totalHours ?? ""
                            );
                            idCounter++;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"حدث خطأ أثناء حفظ بيانات الشريك في الصف {row.Index + 1}: {ex.Message}", 
                                "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                if (idCounter > 1)
                {
                    MessageBox.Show($"تم حفظ بيانات {idCounter - 1} شريك بنجاح", "نجاح", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء حفظ بيانات الشركاء: " + ex.Message, "خطأ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePartnersHoursFromGrid()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSalesCode.Text))
                {
                    return; // لا يوجد رقم فاتورة
                }

                string billNo = txtSalesCode.Text.Trim();
                DataGridView dgv = this.dataGridView1;

                if (dgv == null || dgv.Rows.Count == 0)
                {
                    return; // لا توجد بيانات في الجدول
                }

                int updatedCount = 0;

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    // تخطي الصف الجديد (NewRow)
                    if (row.IsNewRow)
                        continue;

                    // قراءة البيانات من الصف
                    string partnerNumber = "";
                    string partnerName = "";
                    string hoursCount = "";
                    string minutesCount = "";
                    string hoursAvalible = "";
                    string minutesAvalible = "";
                    string totalHours = "";

                    // قراءة Id من Tag (إذا كان محملاً من قاعدة البيانات) أو استخدام رقم الصف
                    int partnerId = row.Index + 1;
                    if (row.Tag != null && row.Tag is int)
                    {
                        partnerId = (int)row.Tag;
                    }
                    else if (row.Tag != null && int.TryParse(row.Tag.ToString(), out int parsedId))
                    {
                        partnerId = parsedId;
                    }

                    // قراءة البيانات من الأعمدة
                    if (row.Cells["PartenerId"] != null && row.Cells["PartenerId"].Value != null)
                    {
                        partnerNumber = row.Cells["PartenerId"].Value.ToString().Trim();
                    }

                    if (row.Cells["PartenerName"] != null && row.Cells["PartenerName"].Value != null)
                    {
                        partnerName = row.Cells["PartenerName"].Value.ToString().Trim();
                    }

                    if (row.Cells["HoursUesed"] != null && row.Cells["HoursUesed"].Value != null)
                    {
                        hoursCount = row.Cells["HoursUesed"].Value.ToString().Trim();
                    }

                    if (row.Cells["MinutesCount"] != null && row.Cells["MinutesCount"].Value != null)
                    {
                        minutesCount = row.Cells["MinutesCount"].Value.ToString().Trim();
                    }

                    if (row.Cells["HoursAvalible"] != null && row.Cells["HoursAvalible"].Value != null)
                    {
                        hoursAvalible = row.Cells["HoursAvalible"].Value.ToString().Trim();
                    }

                    if (row.Cells["MinutesAvalible"] != null && row.Cells["MinutesAvalible"].Value != null)
                    {
                        minutesAvalible = row.Cells["MinutesAvalible"].Value.ToString().Trim();
                    }

                    // حساب TotalHours
                    if (!string.IsNullOrWhiteSpace(hoursCount) && !string.IsNullOrWhiteSpace(hoursAvalible))
                    {
                        try
                        {
                            double hours = 0, avalible = 0;
                            if (double.TryParse(hoursCount, out hours) && double.TryParse(hoursAvalible, out avalible))
                            {
                                totalHours = (hours + avalible).ToString();
                            }
                            else
                            {
                                totalHours = hoursCount;
                            }
                        }
                        catch
                        {
                            totalHours = hoursCount;
                        }
                    }
                    else
                    {
                        totalHours = hoursCount ?? "";
                    }

                    // تحديث بيانات الشريك
                    try
                    {
                        partnersHours.UPDATE_SALE_PARTNER_HOURS_BY_BILLNO(
                            billNo,
                            partnerId,
                            partnerNumber ?? "",
                            partnerName ?? "",
                            hoursCount ?? "",
                            minutesCount ?? "",
                            hoursAvalible ?? "",
                            minutesAvalible ?? "",
                            totalHours ?? ""
                        );
                        updatedCount++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"حدث خطأ أثناء تحديث بيانات الشريك في الصف {row.Index + 1}: {ex.Message}", 
                            "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                if (updatedCount > 0)
                {
                    MessageBox.Show($"تم تحديث بيانات {updatedCount} شريك بنجاح", "نجاح", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحديث بيانات الشركاء: " + ex.Message, "خطأ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                              
        private void DeletePartnersHoursFromDatabase(string billNo)
        {
            try
            {
                partnersHours.DELETE_SALE_PARTNER_HOURS(billNo);
            }
        
        catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء حذف بيانات الشركاء: " + ex.Message, "خطأ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}

