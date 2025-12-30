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
using System.Globalization;

namespace Water
{
    public partial class SalesForm : Form
    {
        private bool isEditMode = false;
        private bool isLoadingCustomerFromList = false; // للتحكم في عدم فتح القائمة تلقائياً عند تحميل البيانات
        private bool isLoadingPriceLevel = false; // للتحكم في عدم استدعاء الحدث تلقائياً عند تحميل بيانات التسعيرة
        Clas.sales sal = new Clas.sales();
        Clas.salePartnersHours partnersHours = new Clas.salePartnersHours();
        Clas.customer customer = new Clas.customer();
        Clas.partners partners = new Clas.partners();
        Clas.pricing pricing = new Clas.pricing();
        Clas.period period = new Clas.period();
        private bool isLoadingPeriodFromList = false; // للتحكم في عدم فتح القائمة تلقائياً عند تحميل البيانات
        Clas.GridBtnViewHelper gridBtnViewHelper = new Clas.GridBtnViewHelper();
        public SalesForm()
        {
            InitializeComponent();
            InitializeDataGridViewEvents();
            btnView.Click += btnView_Click;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnSave.Click += btnSave_Click;



            // ربط أحداث حساب الساعات والدقائق تلقائياً
            dtpStartTime.ValueChanged += DateTimePicker_ValueChanged;
            dtpEndTime.ValueChanged += DateTimePicker_ValueChanged;

            // ربط أحداث حساب الإجماليات تلقائياً
            txtHours.TextChanged += CalculateTotals_TextChanged;
            txtMinutes.TextChanged += CalculateTotals_TextChanged;
            txtWaterHourPrice.TextChanged += CalculateTotals_TextChanged;
            txtDieselHourPrice.TextChanged += CalculateTotals_TextChanged;
            txtWaterMinutesPrice.TextChanged += CalculateTotals_TextChanged;
            txtDieselMinutesPrice.TextChanged += CalculateTotals_TextChanged;
            txtPaidAmount.TextChanged += CalculateRemainingAmount_TextChanged;
            txtDueAmount.TextChanged += CalculateRemainingAmount_TextChanged;

            // ربط أحداث رقم الفترة           
            txtPeriodId.Leave += txtPeriodId_Leave;

            // ربط حدث تغيير مستوى التسعيرة        
            txtPriceLevel.Leave += txtPriceLevel_Leave;

            // تهيئة ComboBox نوع العميل
            if (cmbCustomerType != null)
            {
                cmbCustomerType.SelectedIndex = 0; 
            }
        }

        private void InitializeDataGridViewEvents()
        {
            // ربط حدث تغيير رقم الفاتورة لتحديث DataGridView
            this.txtSalesId.TextChanged += TxtSalesCode_TextChanged;

            // ربط حدث إضافة صف جديد في DataGridView
            if (this.dataGridView1 != null)
            {
                this.dataGridView1.DefaultValuesNeeded += DataGridView1_DefaultValuesNeeded;
                this.dataGridView1.RowsAdded += DataGridView1_RowsAdded;
                this.dataGridView1.CellBeginEdit += DataGridView1_CellBeginEdit;
                this.dataGridView1.KeyDown += DataGridView1_KeyDown;
                this.dataGridView1.CellEnter += DataGridView1_CellEnter;
                this.dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
                this.dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;
            }
        }

        private void TxtSalesCode_TextChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1 == null)
                return;

            string billNo = this.txtSalesId.Text.Trim();

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
                e.Row.Cells["bill_no"].Value = this.txtSalesId.Text.Trim();
            }
        }

        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // عند إضافة صف جديد، تحديث حقل رقم الفاتورة
            string billNo = this.txtSalesId.Text.Trim();

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
                    row.Cells["bill_no"].Value = this.txtSalesId.Text.Trim();
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
                    ShowPartnersList();
                }
            }
        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // التحقق من أن التحرير كان في عمود PartenerId
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            DataGridViewColumn column = this.dataGridView1.Columns[e.ColumnIndex];
            if (column == null || column.Name != "PartenerId")
                return;

            // الحصول على الصف الحالي
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            if (row == null || row.IsNewRow)
                return;

            // الحصول على رقم الشريك المدخل
            if (row.Cells["PartenerId"] == null || row.Cells["PartenerId"].Value == null)
                return;

            string partnerId = row.Cells["PartenerId"].Value.ToString().Trim();
            if (string.IsNullOrWhiteSpace(partnerId))
            {
                // إذا كان الحقل فارغاً، مسح اسم الشريك
                if (row.Cells["PartenerName"] != null)
                {
                    row.Cells["PartenerName"].Value = "";
                }
                return;
            }

            try
            {
                // التحقق من عدم تكرار رقم الشريك
                foreach (DataGridViewRow otherRow in this.dataGridView1.Rows)
                {
                    // تخطي الصف الحالي والصف الجديد
                    if (otherRow.Index == e.RowIndex || otherRow.IsNewRow)
                        continue;

                    // قراءة رقم الشريك من الصف الآخر
                    if (otherRow.Cells["PartenerId"] != null && otherRow.Cells["PartenerId"].Value != null)
                    {
                        string otherPartnerId = otherRow.Cells["PartenerId"].Value.ToString().Trim();
                        
                        // إذا كان نفس رقم الشريك، عرض رسالة خطأ
                        if (otherPartnerId == partnerId)
                        {
                            MessageBox.Show("تم إدخال هذا الشريك مسبقاً. لا يمكن تكرار نفس الشريك", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            
                            // مسح رقم الشريك واسمه
                            row.Cells["PartenerId"].Value = "";
                            if (row.Cells["PartenerName"] != null)
                            {
                                row.Cells["PartenerName"].Value = "";
                            }
                            
                            // إعادة التركيز على خلية PartenerId
                            this.dataGridView1.CurrentCell = row.Cells["PartenerId"];
                            return;
                        }
                    }
                }

                // البحث عن الشريك في قاعدة البيانات
                DataTable dt = partners.VIEW_PARTNER(partnerId);

                if (dt != null && dt.Rows.Count > 0)
                {
                    // تحميل اسم الشريك
                    DataRow partnerRow = dt.Rows[0];
                    string partnerName = partnerRow["name"] != DBNull.Value ? partnerRow["name"].ToString() : "";

                    // تعبئة اسم الشريك في العمود
                    if (row.Cells["PartenerName"] != null)
                    {
                        row.Cells["PartenerName"].Value = partnerName;
                    }

                    // تعبئة الساعات المتاحة إذا كانت موجودة
                    if (row.Cells["HoursAvalible"] != null && partnerRow["avalibleHours"] != DBNull.Value)
                    {
                        row.Cells["HoursAvalible"].Value = partnerRow["avalibleHours"].ToString();
                    }

                    if (row.Cells["MinutesAvalible"] != null && partnerRow["avalibleMinutes"] != DBNull.Value)
                    {
                        row.Cells["MinutesAvalible"].Value = partnerRow["avalibleMinutes"].ToString();
                    }
                }
                else
                {
                    // الشريك غير موجود
                    MessageBox.Show("رقم الشريك غير موجود", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                    // مسح اسم الشريك
                    if (row.Cells["PartenerName"] != null)
                    {
                        row.Cells["PartenerName"].Value = "";
                    }

                    // إعادة التركيز على خلية PartenerId
                    this.dataGridView1.CurrentCell = row.Cells["PartenerId"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء البحث عن الشريك: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowPartnersList()
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
                 dgv.KeyDown += (s, args) =>
                {
                    if (args.KeyCode == Keys.Enter && dgv.CurrentRow != null && dgv.CurrentRow.Index >= 0)
                    {
                        DataRow row = dt.Rows[dgv.CurrentRow.Index];
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

            private void txtDecimal_KeyPress(object sender, KeyPressEventArgs e)
            {
                // يسمح بالأرقام والنقطة والـ Backspace فقط
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }

                // يمنع إدخال أكثر من نقطة واحدة
                TextBox txt = sender as TextBox;
                if (e.KeyChar == '.' && txt != null && txt.Text.Contains("."))
                {
                    e.Handled = true;
                }
            }


        private void LoadPartnerDataToGrid(DataRow partnerRow)
        {
            if (this.dataGridView1.CurrentCell == null || this.dataGridView1.CurrentCell.RowIndex < 0)
                return;

            int currentRowIndex = this.dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow dgvRow = this.dataGridView1.Rows[currentRowIndex];

            string partnerId = partnerRow["id"] != DBNull.Value ? partnerRow["id"].ToString() : "";

            // التحقق من عدم تكرار رقم الشريك قبل التعبئة
            if (!string.IsNullOrWhiteSpace(partnerId))
            {
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    // تخطي الصف الحالي والصف الجديد
                    if (row.Index == currentRowIndex || row.IsNewRow)
                        continue;

                    // قراءة رقم الشريك من الصف الآخر
                    if (row.Cells["PartenerId"] != null && row.Cells["PartenerId"].Value != null)
                    {
                        string otherPartnerId = row.Cells["PartenerId"].Value.ToString().Trim();
                        
                        // إذا كان نفس رقم الشريك، عرض رسالة خطأ
                        if (otherPartnerId == partnerId)
                        {
                            MessageBox.Show("تم إدخال هذا الشريك مسبقاً. لا يمكن تكرار نفس الشريك", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // لا نملأ البيانات
                        }
                    }
                }
            }

            // تعبئة رقم الشريك
            if (dgvRow.Cells["PartenerId"] != null)
            {
                dgvRow.Cells["PartenerId"].Value = partnerId;
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

        private void txtCustomerId_KeyDown(object sender, KeyEventArgs e)
        {
            // عند الضغط على Enter أو F2 في حقل رقم العميل، فتح قائمة العملاء
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.F2)
            {
                e.Handled = true;
                e.SuppressKeyPress = true; // منع معالجة المفتاح بشكل افتراضي
                isLoadingCustomerFromList = true; // تعطيل التحقق التلقائي مؤقتاً
                ShowCustomersList();
                isLoadingCustomerFromList = false; // إعادة تفعيل التحقق
            }
        }

        private void txtCustomerId_Leave(object sender, EventArgs e)
        {
            // إذا كان يتم تحميل البيانات من القائمة، لا نتحقق مرة أخرى
            if (isLoadingCustomerFromList)
                return;

            // التحقق من وجود العميل/الشريك/الحساب عند الانتقال من الحقل
            if (txtCustomerId == null || string.IsNullOrWhiteSpace(txtCustomerId.Text))
                return;

            try
            {
                string customerId = txtCustomerId.Text.Trim();
                DataTable dt = null;

                // تحديد نوع البيانات بناءً على اختيار نوع العميل
                if (cmbCustomerType != null && cmbCustomerType.SelectedIndex == 1) // شريك
                {
                    dt = partners.VIEW_PARTNER(customerId);
                }
                else // عميل (افتراضي)
                {
                    dt = customer.VIEW_CUSTOMER(customerId);
                }

                // التحقق من وجود البيانات
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("رقم العميل/الشريك غير موجود", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCustomerId.Focus();
                    return;
                }

                // تحميل بيانات العميل/الشريك
                LoadCustomerDataToBill(dt.Rows[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء التحقق من رقم العميل: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCustomerId.Focus();
            }
        }
        private void ShowCustomersList()
        {
            try
            {
                DataTable dt = null;
                string formTitle = "";

                // تحديد نوع البيانات بناءً على اختيار نوع العميل
                if (cmbCustomerType != null && cmbCustomerType.SelectedIndex == 1) // شريك
                {
                    dt = partners.GET_ALL_PARTNERS();
                    formTitle = "عرض بيانات الشركاء";
                }
                else // عميل (افتراضي)
                {
                    dt = customer.GET_ALL_CUSTOMERS();
                    formTitle = "عرض بيانات العملاء";
                }

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات للعرض", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // تصفية البيانات بناءً على الرقم المدخل في txtCustomerId (إذا كان موجود)
                string searchId = txtCustomerId != null ? txtCustomerId.Text.Trim() : "";
                if (!string.IsNullOrWhiteSpace(searchId))
                {
                    // تصفية الصفوف التي تحتوي على الرقم المدخل في عمود id
                    DataTable filteredDt = dt.Clone();
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["id"] != DBNull.Value && row["id"].ToString().Contains(searchId))
                        {
                            filteredDt.ImportRow(row);
                        }
                    }
                    dt = filteredDt;
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات تطابق الرقم المدخل", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        isLoadingCustomerFromList = true; // تعطيل التحقق التلقائي
                        LoadCustomerDataToBill(row);
                        isLoadingCustomerFromList = false; // إعادة تفعيل التحقق
                        viewForm.Close();
                    }
                };
                 dgv.KeyDown += (s, args) =>
                {
                    if (args.KeyCode == Keys.Enter && dgv.CurrentRow != null && dgv.CurrentRow.Index >= 0)
                    {
                        DataRow row = dt.Rows[dgv.CurrentRow.Index];
                        isLoadingCustomerFromList = true; // تعطيل التحقق التلقائي
                        LoadCustomerDataToBill(row);
                        isLoadingCustomerFromList = false; // إعادة تفعيل التحقق
                        viewForm.Close();
                    }
                };

                // إضافة حدث النقر مرة واحدة (بدلاً من النقر المزدوج فقط)
               /*  dgv.CellClick += (s, args) =>
                {
                    if (args.RowIndex >= 0)
                    {
                        DataRow row = dt.Rows[args.RowIndex];
                        isLoadingCustomerFromList = true; // تعطيل التحقق التلقائي
                        LoadCustomerDataToBill(row);
                        isLoadingCustomerFromList = false; // إعادة تفعيل التحقق
                        viewForm.Close();
                    }
                }; */

                viewForm.Controls.Add(dgv);
                viewForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء عرض البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadCustomerDataToBill(DataRow customerRow)
        {
            // تعبئة رقم العميل/الشريك في حقل txtCustomerId
            if (txtCustomerId != null)
            {
                txtCustomerId.Text = customerRow["id"] != DBNull.Value ? customerRow["id"].ToString() : "";
            }

            // تعبئة اسم العميل/الشريك في TextBox
            if (txtCustomerName != null)
            {
                txtCustomerName.Text = customerRow["name"] != DBNull.Value ? customerRow["name"].ToString() : "";
            }
        }

        private void cmbCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // عند تغيير نوع العميل، مسح الحقول
            if (txtCustomerId != null)
            {
                txtCustomerId.Clear();
            }
            if (txtCustomerName != null)
            {
                txtCustomerName.Clear();
            }
        }


        private void txtPriceLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.F2)
            {
                e.Handled = true;
                ShowPriceingList();
            }
        }
        private void ShowPriceingList()
        {
            try
            {
                DataTable dt = pricing.GET_ALL_PRICINGS();

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات للعرض", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Form viewForm = new Form();
                viewForm.Text = "عرض مستويات التسعيرة";
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
                        LoadPriceingDataToBill(row);
                        viewForm.Close();
                    }
                };
                 dgv.KeyDown += (s, args) =>
                {
                    if (args.KeyCode == Keys.Enter && dgv.CurrentRow != null && dgv.CurrentRow.Index >= 0)
                    {
                        DataRow row = dt.Rows[dgv.CurrentRow.Index];
                        LoadPriceingDataToBill(row);
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
        private void LoadPriceingDataToBill(DataRow priceingRow)
        {
            if (txtPriceLevel != null)
            {
                txtPriceLevel.Text = priceingRow["PriceLevleId"] != DBNull.Value ? priceingRow["PriceLevleId"].ToString() : "";
            }
            if (txtWaterHourPrice != null)
            {
                txtWaterHourPrice.Text = priceingRow["WaterHourPrice"] != DBNull.Value ? priceingRow["WaterHourPrice"].ToString() : "";
            }
            if (txtDieselHourPrice != null)
            {
                txtDieselHourPrice.Text = priceingRow["DieselHourPrice"] != DBNull.Value ? priceingRow["DieselHourPrice"].ToString() : "";
            }
            if (txtWaterMinutesPrice != null)
            {
                txtWaterMinutesPrice.Text = priceingRow["WaterMinutePrice"] != DBNull.Value ? priceingRow["WaterMinutePrice"].ToString() : "";
            }
            if (txtDieselMinutesPrice != null)
            {
                txtDieselMinutesPrice.Text = priceingRow["DieselMinutePrice"] != DBNull.Value ? priceingRow["DieselMinutePrice"].ToString() : "";
            }
        }

        private void txtPriceLevel_TextChanged(object sender, EventArgs e)
        {
            // تجنب استدعاء الحدث عند تحميل البيانات تلقائياً
            if (isLoadingPriceLevel)
                return;

            // عند تغيير قيمة مستوى التسعيرة، تحميل بيانات التسعيرة تلقائياً
            if (txtPriceLevel == null || string.IsNullOrWhiteSpace(txtPriceLevel.Text))
            {
                return;
            }

            try
            {
                string priceLevelId = txtPriceLevel.Text.Trim();
                DataTable dt = pricing.GET_ALL_PRICINGS();
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    // البحث عن مستوى التسعيرة المطابق
                    DataRow[] foundRows = dt.Select($"PriceLevleId = '{priceLevelId}'");
                    
                    if (foundRows.Length > 0)
                    {
                        isLoadingPriceLevel = true;
                        try
                        {
                            // تحميل بيانات التسعيرة
                            LoadPriceingDataToBill(foundRows[0]);
                            
                            // إعادة حساب الإجماليات
                            CalculateTotals_TextChanged(null, null);
                        }
                        finally
                        {
                            isLoadingPriceLevel = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // في حالة الخطأ، لا نفعل شيئاً (تجاهل الخطأ)
                // MessageBox.Show("حدث خطأ أثناء تحميل بيانات التسعيرة: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int is_check = 0;
        private void txtPriceLevel_Leave(object sender, EventArgs e)
        {
            // عند مغادرة حقل مستوى التسعيرة، التحقق من صحة القيمة
            if (txtPriceLevel == null || string.IsNullOrWhiteSpace(txtPriceLevel.Text))
            {
                return;
            }

            try
            {
                string priceLevelId = txtPriceLevel.Text.Trim();
                DataTable dt = pricing.GET_ALL_PRICINGS();
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    // البحث عن مستوى التسعيرة المطابق
                    DataRow[] foundRows = dt.Select($"PriceLevleId = '{priceLevelId}'");
                    
                    if (foundRows.Length == 0)
                    {
                        // مستوى التسعيرة غير موجود
                        MessageBox.Show("مستوى التسعيرة المدخل غير موجود", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPriceLevel.Focus();
                        return;
                    }
                    
                    // تحميل بيانات التسعيرة
                    LoadPriceingDataToBill(foundRows[0]);
                    
                    // إعادة حساب الإجماليات
                    CalculateTotals_TextChanged(null, null);
                    if(chkBxCalc.Checked)
                    {
                        is_check = 1;
                        chkBxCalc.Checked = false;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء التحقق من مستوى التسعيرة: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void btnView_Click(object sender, EventArgs e)
        {          

            DataTable dt = sal.GET_ALL_SALES();
            DataRow row = gridBtnViewHelper.Show(dt, "عرض المبيعات");
            if (row != null)
            {
                LoadSalesData(row);
                SetViewMode();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isEditMode = false;
            clear_SALES();
            try
            {
                txtSalesId.Text = sal.GET_NEXT_SALES_CODE();
            }
            catch
            {
                txtSalesId.Text = "1";
            }          
            SetAddMode();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSalesId.Text))
            {
                MessageBox.Show("الرجاء إدخال كود الفاتورة أو اختيار فاتورة من قائمة العرض", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable dt = sal.VIEW_SALES(txtSalesId.Text.Trim());

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("الفاتورة غير موجودة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LoadSalesData(dt.Rows[0]);
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
            if (string.IsNullOrWhiteSpace(txtSalesId.Text))
            {
                MessageBox.Show("الرجاء إدخال كود الفاتورة المراد حذفها", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "هل أنت متأكد من حذف الفاتورة: " + txtSalesId.Text + "؟",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    sal.DELETE_SALES(txtSalesId.Text.Trim());
                    sal.DELETE_POST("delete", "1", txtSalesId.Text.Trim());
                    sal.DELETE_POST("delete", "4", txtSalesId.Text.Trim());
                    DeletePartnersHoursFromDatabase(txtSalesId.Text.Trim());
                    MessageBox.Show("تم حذف الفاتورة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_SALES();
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
                if (string.IsNullOrWhiteSpace(txtSalesId.Text) ||
                    string.IsNullOrWhiteSpace(txtCustomerId.Text) ||
                    string.IsNullOrWhiteSpace(txtPeriodId.Text) ||
                    string.IsNullOrWhiteSpace(txtPriceLevel.Text) ||
                    string.IsNullOrWhiteSpace(txtHours.Text) ||
                    string.IsNullOrWhiteSpace(txtMinutes.Text)
                    )
                {
                    MessageBox.Show("الرجاء إكمال جميع البيانات المطلوبة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int hours = Convert.ToInt32(txtHours.Text);
                int minuts = Convert.ToInt32(txtMinutes.Text);
                if( hours <= 0 && minuts <= 0 )
                {
                    MessageBox.Show("يرجى تحديد عدد الساعات او الدقائق المستخدمة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // التحقق من أن وقت النهاية بعد وقت البداية
                 if (dtpEndTime.Value < dtpStartTime.Value)
                {
                    MessageBox.Show("وقت النهاية يجب أن يكون بعد وقت البداية", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                // التحقق من بيانات الشركاء قبل حفظ الفاتورة
                ValidatePartnersHoursData();

                // تحديد نوع العميل/الشريك
                string cusPartType = "";
                if (cmbCustomerType != null && cmbCustomerType.SelectedIndex == 1) // شريك
                {
                    cusPartType = "2";
                }
                else // عميل
                {
                    cusPartType = "1";
                }

                if (isEditMode)
                {
                    sal.DELETE_POST("delete", "1", txtSalesId.Text.Trim());
                    sal.DELETE_POST("delete", "4", txtSalesId.Text.Trim());
                    // تحديث بيانات الفاتورة
                    sal.UPDATE_SALES(
                        txtSalesId.Text.Trim(),
                        "1", // doc_type = 1
                        txtPeriodId.Text.Trim(),
                        txtCustomerId.Text.Trim(),
                        txtCustomerName != null ? txtCustomerName.Text.Trim() : "", // cus_part_name
                        cusPartType, // cus_part_type
                        dtpStartTime.Value,
                        dtpEndTime.Value,
                        string.IsNullOrWhiteSpace(txtHours.Text) ? 0 : Convert.ToDouble(txtHours.Text),
                        string.IsNullOrWhiteSpace(txtMinutes.Text) ? 0 : Convert.ToDouble(txtMinutes.Text),
                        string.IsNullOrWhiteSpace(txtWaterHourPrice.Text) ? 0 : Convert.ToDouble(txtWaterHourPrice.Text),
                        string.IsNullOrWhiteSpace(txtDieselHourPrice.Text) ? 0 : Convert.ToDouble(txtDieselHourPrice.Text),
                        string.IsNullOrWhiteSpace(txtWaterMinutesPrice.Text) ? 0 : Convert.ToDouble(txtWaterMinutesPrice.Text),
                        string.IsNullOrWhiteSpace(txtDieselMinutesPrice.Text) ? 0 : Convert.ToDouble(txtDieselMinutesPrice.Text),
                        GetDieselUsedInHour(),
                        GetDieselUsedInMinute(),
                        string.IsNullOrWhiteSpace(textWaterTotalPrice.Text) ? 0 : Convert.ToDouble(textWaterTotalPrice.Text),
                        string.IsNullOrWhiteSpace(txtDieselTotalPrice.Text) ? 0 : Convert.ToDouble(txtDieselTotalPrice.Text),
                        string.IsNullOrWhiteSpace(txtTotalAmount.Text) ? 0 : Convert.ToDouble(RemoveFormatting(txtTotalAmount.Text)),
                        string.IsNullOrWhiteSpace(txtDueAmount.Text) ? 0 : Convert.ToDouble(RemoveFormatting(txtDueAmount.Text)),
                        string.IsNullOrWhiteSpace(txtPaidAmount.Text) ? 0 : Convert.ToDouble(RemoveFormatting(txtPaidAmount.Text)),
                        string.IsNullOrWhiteSpace(txtRemainingAmount.Text) ? 0 : Convert.ToDouble(RemoveFormatting(txtRemainingAmount.Text)),
                        cmbBillType.SelectedItem != null ? cmbBillType.SelectedItem.ToString() : "",
                        txtPriceLevel.Text.Trim(),
                      //  string.IsNullOrWhiteSpace(txtPriceLevel.Text) ? "" : txtPriceLevel.Text.Trim(),
                        DateTime.Now,
                        txtNote != null ? txtNote.Text.Trim() : "", // note
                        chkBxCalc != null && chkBxCalc.Checked ? 1 : 0 // isCalcFrmPayidAmt
                    );
                    AddPostFormSales();

                   // MessageBox.Show("تم تحديث بيانات الفاتورة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // تحديث بيانات الشركاء من DataGridView
                    DeletePartnersHoursFromDatabase(txtSalesId.Text.Trim());
                    SavePartnersHoursFromGrid();
                    //UpdatePartnersHoursFromGrid();
                }
                else
                {
                    // إضافة فاتورة جديدة
                    sal.ADD_SALES(
                        txtSalesId.Text.Trim(),
                        "1", // doc_type = 1
                        txtPeriodId.Text.Trim(),
                        txtCustomerId.Text.Trim(),
                        txtCustomerName != null ? txtCustomerName.Text.Trim() : "", // cus_part_name
                        cusPartType, // cus_part_type
                        dtpStartTime.Value,
                        dtpEndTime.Value,
                        string.IsNullOrWhiteSpace(txtHours.Text) ? 0 : Convert.ToDouble(txtHours.Text),
                        string.IsNullOrWhiteSpace(txtMinutes.Text) ? 0 : Convert.ToDouble(txtMinutes.Text),
                        string.IsNullOrWhiteSpace(txtWaterHourPrice.Text) ? 0 : Convert.ToDouble(txtWaterHourPrice.Text),
                        string.IsNullOrWhiteSpace(txtDieselHourPrice.Text) ? 0 : Convert.ToDouble(txtDieselHourPrice.Text),
                        string.IsNullOrWhiteSpace(txtWaterMinutesPrice.Text) ? 0 : Convert.ToDouble(txtWaterMinutesPrice.Text),
                        string.IsNullOrWhiteSpace(txtDieselMinutesPrice.Text) ? 0 : Convert.ToDouble(txtDieselMinutesPrice.Text),
                        GetDieselUsedInHour(),
                        GetDieselUsedInMinute(),
                        string.IsNullOrWhiteSpace(textWaterTotalPrice.Text) ? 0 : Convert.ToDouble(textWaterTotalPrice.Text),
                        string.IsNullOrWhiteSpace(txtDieselTotalPrice.Text) ? 0 : Convert.ToDouble(txtDieselTotalPrice.Text),
                        string.IsNullOrWhiteSpace(txtTotalAmount.Text) ? 0 : Convert.ToDouble(RemoveFormatting(txtTotalAmount.Text)),
                        string.IsNullOrWhiteSpace(txtDueAmount.Text) ? 0 : Convert.ToDouble(RemoveFormatting(txtDueAmount.Text)),
                        string.IsNullOrWhiteSpace(txtPaidAmount.Text) ? 0 : Convert.ToDouble(RemoveFormatting(txtPaidAmount.Text)),
                        string.IsNullOrWhiteSpace(txtRemainingAmount.Text) ? 0 : Convert.ToDouble(RemoveFormatting(txtRemainingAmount.Text)),
                        cmbBillType.SelectedItem != null ? cmbBillType.SelectedItem.ToString() : "",
                        txtPriceLevel.Text.Trim(),
                        //string.IsNullOrWhiteSpace(txtPriceLevel.Text) ? "" : txtPriceLevel.Text.Trim(),
                        DateTime.Now,
                        txtNote != null ? txtNote.Text.Trim() : "", // note
                        chkBxCalc != null && chkBxCalc.Checked ? 1 : 0 // isCalcFrmPayidAmt
                    );
                    AddPostFormSales();
                    SavePartnersHoursFromGrid();
                }

                clear_SALES();
                isEditMode = false;
                SetAfterSaveMode();              
                tabControl1.SelectedIndex = 0;               

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
                // التحقق من نوع الخطأ
                if (ee.Message.Contains("يجب إدخال تفاصيل الساعات"))
                {
                    // رسالة واضحة للتحقق من البيانات
                    tabControl1.SelectedIndex = 1;
                   dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[1];
                    MessageBox.Show("يجب إدخال تفاصيل الساعات للشركاء", "تنبيه", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);                    
                }
                else
                {
                    // رسالة خطأ عامة للأخطاء الأخرى
                    MessageBox.Show("حدث خطأ أثناء الحفظ: " + ee.Message, "خطأ", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadSalesData(DataRow row)
        {
            txtSalesId.Text = row["bill_no"].ToString();

            string billType = row["bill_type"].ToString();
            if (cmbBillType.Items.Contains(billType))
            {
                cmbBillType.SelectedItem = billType;
            }

            // تحميل نوع العميل/الشريك
            if (cmbCustomerType != null)
            {
                if (row["cus_part_type"] != DBNull.Value)
                {
                    string cusPartType = row["cus_part_type"].ToString();
                    if (cusPartType == "2") // شريك
                    {
                        cmbCustomerType.SelectedIndex = 1;
                    }
                    else // عميل
                    {
                        cmbCustomerType.SelectedIndex = 0;
                    }
                }
                else
                {
                    cmbCustomerType.SelectedIndex = 0; // افتراضي: عميل
                }
            }

            if (row["cus_part_no"] != DBNull.Value)
            {
                txtCustomerId.Text = row["cus_part_no"].ToString();
            }
            else
            {
                txtCustomerId.Clear();
            }

            // تحميل اسم العميل/الشريك من الصف مباشرة
            if (txtCustomerName != null)
            {
                if (row["cus_part_name"] != DBNull.Value)
                {
                    txtCustomerName.Text = row["cus_part_name"].ToString();
                }
                else
                {
                    txtCustomerName.Clear();
                }
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
                        LoadPeriodDataToBill(periodDt.Rows[0]);
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
                txtHours.Text = row["hours"].ToString();
            }
            else
            {
                txtHours.Clear();
            }

            if (row["minutes"] != DBNull.Value)
            {
                txtMinutes.Text = row["minutes"].ToString();
            }
            else
            {
                txtMinutes.Clear();
            }

            if (row["water_hour_price"] != DBNull.Value)
            {
                txtWaterHourPrice.Text = row["water_hour_price"].ToString();
            }
            else
            {
                txtWaterHourPrice.Clear();
            }

            if (row["diesel_hour_price"] != DBNull.Value)
            {
                txtDieselHourPrice.Text = row["diesel_hour_price"].ToString();
            }
            else
            {
                txtDieselHourPrice.Clear();
            }

            if (row["water_Minutes_price"] != DBNull.Value)
            {
                txtWaterMinutesPrice.Text = row["water_Minutes_price"].ToString();
            }
            else
            {
                txtWaterMinutesPrice.Clear();
            }

            if (row["diesel_Minutes_price"] != DBNull.Value)
            {
                txtDieselMinutesPrice.Text = row["diesel_Minutes_price"].ToString();
            }
            else
            {
                txtDieselMinutesPrice.Clear();
            }

            if (row["lvlPrice"] != DBNull.Value)
            {
                txtPriceLevel.Text = row["lvlPrice"].ToString();
            }
            else
            {
                txtPriceLevel.Clear();
            }

            if (row["water_total"] != DBNull.Value)
            {
                textWaterTotalPrice.Text = FormatNumber(row["water_total"]);
            }
            else
            {
                textWaterTotalPrice.Clear();
            }

            if (row["diesel_total"] != DBNull.Value)
            {
                txtDieselTotalPrice.Text = FormatNumber(row["diesel_total"]);
            }
            else
            {
                txtDieselTotalPrice.Clear();
            }

            if (row["total_amount"] != DBNull.Value)
            {
                txtTotalAmount.Text = FormatNumber(row["total_amount"]);
            }
            else
            {
                txtTotalAmount.Clear();
            }

            if (row["due_amount"] != DBNull.Value)
            {
                txtDueAmount.Text = FormatNumber(row["due_amount"]);
            }
            else
            {
                txtDueAmount.Clear();
            }

            if (row["paid_amount"] != DBNull.Value)
            {
                txtPaidAmount.Text = FormatNumber(row["paid_amount"]);
            }
            else
            {
                txtPaidAmount.Clear();
            }

            if (row["remaining_amount"] != DBNull.Value)
            {
                txtRemainingAmount.Text = FormatNumber(row["remaining_amount"]);
            }
            else
            {
                txtRemainingAmount.Clear();
            }

            // تحميل البيان
            if (txtNote != null)
            {
                if (row["note"] != DBNull.Value)
                {
                    txtNote.Text = row["note"].ToString();
                }
                else
                {
                    txtNote.Clear();
                }
            }

            // تحميل قيمة isCalcFrmPayidAmt
            if (chkBxCalc != null)
            {
                if (row["isCalcFrmPayidAmt"] != DBNull.Value)
                {
                    int isCalc = Convert.ToInt32(row["isCalcFrmPayidAmt"]);
                    chkBxCalc.Checked = (isCalc == 1);
                }
                else
                {
                    chkBxCalc.Checked = false;
                }
            }

            // تحميل بيانات الشركاء من قاعدة البيانات
            LoadPartnersHoursFromDatabase(txtSalesId.Text.Trim());
        }

        private void clear_SALES()
        {
            txtSalesId.Clear();
            cmbBillType.SelectedIndex = -1;
            if (cmbCustomerType != null)
            {
                cmbCustomerType.SelectedIndex = 0;
            }
            txtCustomerId.Clear();
            if (txtCustomerName != null)
            {
                txtCustomerName.Clear();
            }
            if(chkBxCalc != null)
            {
                chkBxCalc.Checked = false;
            }
            if(chkManwalTime != null)
            {
                chkManwalTime.Checked = false;
            }

            txtPeriodId.Clear();
            if (txtPeriodStartDate != null)
                txtPeriodStartDate.Clear();
            if (txtPeriodEndDate != null)
                txtPeriodEndDate.Clear();
            dtpStartTime.Value = DateTime.Now;
            dtpEndTime.Value = DateTime.Now;
            txtHours.Clear();
            txtMinutes.Clear();
            txtWaterHourPrice.Clear();
            txtDieselHourPrice.Clear();
            txtWaterMinutesPrice.Clear();
            txtDieselMinutesPrice.Clear();
            txtPriceLevel.Clear();
            textWaterTotalPrice.Clear();
            txtDieselTotalPrice.Clear();
            txtTotalAmount.Clear();
            txtDueAmount.Clear();
            txtPaidAmount.Clear();
            txtRemainingAmount.Clear();
            if (chkBxCalc != null)
            {
                chkBxCalc.Checked = false;
            }
            txtTotalHoursFromGrid.Clear();
            txtTotalMinutesFromGrid.Clear();
            if (txtNote != null)
            {
                txtNote.Clear();
            }

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

        // التحقق من بيانات الشركاء قبل الحفظ
        private void ValidatePartnersHoursData()
        {
            DataGridView dgv = this.dataGridView1;
            
            if (dgv == null)
            {
                throw new Exception("يجب إدخال تفاصيل الساعات للشركاء");
                
            }
            
            // التحقق من وجود بيانات صحيحة في DataGridView
            bool hasValidPartnerData = false;
            
            foreach (DataGridViewRow row in dgv.Rows)
            {
                // تخطي الصف الجديد (NewRow)
                if (row.IsNewRow)
                    continue;
                
                // التحقق من وجود بيانات صحيحة في الصف
                bool hasPartnerId = row.Cells["PartenerId"] != null && 
                                  row.Cells["PartenerId"].Value != null && 
                                  !string.IsNullOrWhiteSpace(row.Cells["PartenerId"].Value.ToString().Trim());
                
                bool hasHours = row.Cells["HoursUesed"] != null && 
                              row.Cells["HoursUesed"].Value != null && 
                              !string.IsNullOrWhiteSpace(row.Cells["HoursUesed"].Value.ToString().Trim());
                
                bool hasMinutes = row.Cells["MinutesCount"] != null && 
                                row.Cells["MinutesCount"].Value != null && 
                                !string.IsNullOrWhiteSpace(row.Cells["MinutesCount"].Value.ToString().Trim());
                
                // إذا كان هناك رقم شريك و (ساعات أو دقائق)
                if (hasPartnerId && (hasHours || hasMinutes))
                {
                    hasValidPartnerData = true;
                    break;
                }
            }
            
            if (!hasValidPartnerData)
            {                
                throw new Exception("يجب إدخال تفاصيل الساعات للشركاء");
            }
            
            // التحقق من عدم تكرار نفس الشريك
            Dictionary<string, int> partnerCount = new Dictionary<string, int>();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow)
                    continue;
                
                // قراءة رقم الشريك
                string partnerId = "";
                if (row.Cells["PartenerId"] != null && row.Cells["PartenerId"].Value != null)
                {
                    partnerId = row.Cells["PartenerId"].Value.ToString().Trim();
                }
                
                // إذا كان هناك رقم شريك، نتحقق من التكرار
                if (!string.IsNullOrWhiteSpace(partnerId))
                {
                    if (partnerCount.ContainsKey(partnerId))
                    {
                        partnerCount[partnerId]++;
                    }
                    else
                    {
                        partnerCount[partnerId] = 1;
                    }
                }
            }
            
            // التحقق من وجود شركاء مكررين
            foreach (var kvp in partnerCount)
            {
                if (kvp.Value > 1)
                {
                    string partnerName = "";
                    // محاولة الحصول على اسم الشريك من أول صف يحتوي على هذا الرقم
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.IsNewRow)
                            continue;
                        
                        if (row.Cells["PartenerId"] != null && row.Cells["PartenerId"].Value != null)
                        {
                            string rowPartnerId = row.Cells["PartenerId"].Value.ToString().Trim();
                            if (rowPartnerId == kvp.Key)
                            {
                                if (row.Cells["PartenerName"] != null && row.Cells["PartenerName"].Value != null)
                                {
                                    partnerName = row.Cells["PartenerName"].Value.ToString().Trim();
                                }
                                break;
                            }
                        }
                    }
                    
                    string errorMsg = $"تم إدخال الشريك رقم {kvp.Key}";
                    if (!string.IsNullOrWhiteSpace(partnerName))
                    {
                        errorMsg += $" ({partnerName})";
                    }
                    errorMsg += $" {kvp.Value} مرات. لا يمكن تكرار نفس الشريك.";
                    throw new Exception(errorMsg);
                }
            }
            
            // التحقق من أن الساعات والدقائق المدخلة لا تتجاوز المتاحة
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow)
                    continue;
                
                // قراءة الساعات المدخلة والمتاحة
                double hoursUsed = 0;
                double hoursAvailable = 0;
                
                if (row.Cells["HoursUesed"] != null && row.Cells["HoursUesed"].Value != null)
                {
                    string hoursUsedStr = row.Cells["HoursUesed"].Value.ToString().Trim();
                    if (!string.IsNullOrWhiteSpace(hoursUsedStr))
                    {
                        double.TryParse(hoursUsedStr, out hoursUsed);
                    }
                }
                
                // قراءة الساعات المتاحة (إذا كانت فارغة تعتبر 0)
                if (row.Cells["HoursAvalible"] != null && row.Cells["HoursAvalible"].Value != null)
                {
                    string hoursAvailableStr = row.Cells["HoursAvalible"].Value.ToString().Trim();
                    if (!string.IsNullOrWhiteSpace(hoursAvailableStr))
                    {
                        double.TryParse(hoursAvailableStr, out hoursAvailable);
                    }
                }
                
                // قراءة الدقائق المدخلة والمتاحة
                double minutesUsed = 0;
                double minutesAvailable = 0;
                
                if (row.Cells["MinutesCount"] != null && row.Cells["MinutesCount"].Value != null)
                {
                    string minutesUsedStr = row.Cells["MinutesCount"].Value.ToString().Trim();
                    if (!string.IsNullOrWhiteSpace(minutesUsedStr))
                    {
                        double.TryParse(minutesUsedStr, out minutesUsed);
                    }
                }
                
                // قراءة الدقائق المتاحة (إذا كانت فارغة تعتبر 0)
                if (row.Cells["MinutesAvalible"] != null && row.Cells["MinutesAvalible"].Value != null)
                {
                    string minutesAvailableStr = row.Cells["MinutesAvalible"].Value.ToString().Trim();
                    if (!string.IsNullOrWhiteSpace(minutesAvailableStr))
                    {
                        double.TryParse(minutesAvailableStr, out minutesAvailable);
                    }
                }
                
                // تحويل الساعات والدقائق إلى إجمالي دقائق للمقارنة
                // المدخلة: تحويل الساعات إلى دقائق + الدقائق
                double totalMinutesUsed = (hoursUsed * 60) + minutesUsed;
                
                // المتاحة: تحويل الساعات إلى دقائق + الدقائق
                double totalMinutesAvailable = (hoursAvailable * 60) + minutesAvailable;
                
                // التحقق من أن الإجمالي المدخل لا يتجاوز المتاح
                if (totalMinutesUsed > totalMinutesAvailable)
                {
                    string partnerName = "";
                    if (row.Cells["PartenerName"] != null && row.Cells["PartenerName"].Value != null)
                    {
                        partnerName = row.Cells["PartenerName"].Value.ToString().Trim();
                    }
                    
                    string partnerId = "";
                    if (row.Cells["PartenerId"] != null && row.Cells["PartenerId"].Value != null)
                    {
                        partnerId = row.Cells["PartenerId"].Value.ToString().Trim();
                    }
                    
                    // عرض القيم بشكل واضح (ساعات ودقائق)
                    string usedDisplay = $"{hoursUsed} ساعة و {minutesUsed} دقيقة";
                    string availableDisplay = $"{hoursAvailable} ساعة و {minutesAvailable} دقيقة";
                    
                    string errorMsg = $"الوقت المدخل ({usedDisplay}) أكبر من الوقت المتاح ({availableDisplay})";
                    if (!string.IsNullOrWhiteSpace(partnerName))
                    {
                        errorMsg += $" للشريك: {partnerName}";
                    }
                    else if (!string.IsNullOrWhiteSpace(partnerId))
                    {
                        errorMsg += $" للشريك رقم: {partnerId}";
                    }
                    throw new Exception(errorMsg);
                }
            }
            
            // حساب إجمالي الساعات والدقائق من DataGridView
            double totalHoursFromGrid = 0;
            double totalMinutesFromGrid = 0;
            
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow)
                    continue;
                
                // قراءة الساعات
                if (row.Cells["HoursUesed"] != null && row.Cells["HoursUesed"].Value != null)
                {
                    string hoursStr = row.Cells["HoursUesed"].Value.ToString().Trim();
                    if (!string.IsNullOrWhiteSpace(hoursStr))
                    {
                        if (double.TryParse(hoursStr, out double hours))
                        {
                            totalHoursFromGrid += hours;
                        }
                    }
                }
                
                // قراءة الدقائق
                if (row.Cells["MinutesCount"] != null && row.Cells["MinutesCount"].Value != null)
                {
                    string minutesStr = row.Cells["MinutesCount"].Value.ToString().Trim();
                    if (!string.IsNullOrWhiteSpace(minutesStr))
                    {
                        if (double.TryParse(minutesStr, out double minutes))
                        {
                            totalMinutesFromGrid += minutes;
                        }
                    }
                }
            }
            
            // تحويل الدقائق الزائدة (كل 60 دقيقة = ساعة واحدة) إلى ساعات للقيم من Grid
            if (totalMinutesFromGrid >= 60)
            {
                int additionalHours = (int)(totalMinutesFromGrid / 60);
                totalHoursFromGrid += additionalHours;
                totalMinutesFromGrid = totalMinutesFromGrid % 60;
            }
            
            // قراءة إجمالي الساعات والدقائق من الفاتورة
            double totalHoursFromInvoice = 0;
            double totalMinutesFromInvoice = 0;
            
            if (!string.IsNullOrWhiteSpace(txtHours.Text))
            {
                double.TryParse(txtHours.Text, out totalHoursFromInvoice);
            }
            
            if (!string.IsNullOrWhiteSpace(txtMinutes.Text))
            {
                double.TryParse(txtMinutes.Text, out totalMinutesFromInvoice);
            }
            // التحقق من المطابقة
            if (Math.Abs(totalHoursFromGrid - totalHoursFromInvoice) > 0.01 || 
                Math.Abs(totalMinutesFromGrid - totalMinutesFromInvoice) > 0.01)
            {
                string errorMsg = $"إجمالي الساعات والدقائق من الشركاء لاتساوي عدد الساعات والدقائق في الفاتورة.\n\n";
                throw new Exception(errorMsg);
            }
        }

        private void SavePartnersHoursFromGrid()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSalesId.Text))
                {
                    throw new Exception("لا يوجد رقم فاتورة");
                }

                string billNo = txtSalesId.Text.Trim();
                DataGridView dgv = this.dataGridView1;

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
                            // تحويل القيم من string إلى int?
                            int? hoursCountInt = null;
                            int? minutesCountInt = null;
                            int? hoursAvalibleInt = null;
                            int? minutesAvalibleInt = null;
                            int? totalHoursInt = null;

                            if (!string.IsNullOrWhiteSpace(hoursCount))
                            {
                                int temp;
                                if (int.TryParse(hoursCount, out temp))
                                    hoursCountInt = temp;
                            }

                            if (!string.IsNullOrWhiteSpace(minutesCount))
                            {
                                int temp;
                                if (int.TryParse(minutesCount, out temp))
                                    minutesCountInt = temp;
                            }

                            if (!string.IsNullOrWhiteSpace(hoursAvalible))
                            {
                                int temp;
                                if (int.TryParse(hoursAvalible, out temp))
                                    hoursAvalibleInt = temp;
                            }

                            if (!string.IsNullOrWhiteSpace(minutesAvalible))
                            {
                                int temp;
                                if (int.TryParse(minutesAvalible, out temp))
                                    minutesAvalibleInt = temp;
                            }

                            if (!string.IsNullOrWhiteSpace(totalHours))
                            {
                                int temp;
                                if (int.TryParse(totalHours, out temp))
                                    totalHoursInt = temp;
                            }

                            partnersHours.ADD_SALE_PARTNER_HOURS(
                                billNo,
                                idCounter,
                                partnerNumber ?? "",
                                partnerName ?? "",
                                hoursCountInt,
                                minutesCountInt,
                                hoursAvalibleInt,
                                minutesAvalibleInt,
                                totalHoursInt
                            );

                            // إضافة POST للشريك
                            double hoursValue = 0;
                            double minutesValue = 0;
                            double.TryParse(hoursCount, out hoursValue);
                            double.TryParse(minutesCount, out minutesValue);

                            // حساب cr_amt = (ساعات * سعر ساعة الماء) + (دقائق * سعر دقيقة الماء)
                            double waterHourPrice = string.IsNullOrWhiteSpace(txtWaterHourPrice.Text)
                                ? 0
                                : Convert.ToDouble(txtWaterHourPrice.Text);
                            double waterMinutesPrice = string.IsNullOrWhiteSpace(txtWaterMinutesPrice.Text)
                                ? 0
                                : Convert.ToDouble(txtWaterMinutesPrice.Text);

                            double cr_amt = (hoursValue * waterHourPrice) + (minutesValue * waterMinutesPrice);

                            partnersHours.ADD_POST(
                                "insert",                                      // action
                                "4",                                           // doc_type
                                billNo,                                        // doc_no
                                idCounter.ToString(),                           // doc_no_type
                                txtPeriodId.Text.Trim(),                       // period_id
                                "2",                                     // cus_part_type
                                partnerNumber ?? "",                           // cus_part_no
                                partnerName ?? "",                              // cus_part_name
                                0,                                             // dr_amt
                                cr_amt,                                        // cr_amt (ساعات ودقائق * سعر الماء)
                                dtpStartTime.Value.Date,                      // date
                                DateTime.MinValue,                            // start_time (فارغ)
                                DateTime.MinValue,                              // end_time (فارغ)
                                (int)hoursValue,                               // hours
                                (int)minutesValue,                             // minutes
                                waterHourPrice,                                // water_hour_price
                                0,                                             // diesel_hour_price
                                waterMinutesPrice,                             // water_Minutes_price
                                0,                                             // diesel_Minutes_price
                                cr_amt,                                        // water_total
                                0,                                             // diesel_total
                                cr_amt,                                        // total_amount
                                $"شريك: {partnerName}",                        // note
                                ""                                             // user_id
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
                  //  MessageBox.Show($"تم حفظ بيانات {idCounter - 1} شريك بنجاح", "نجاح",
                  MessageBox.Show("تم حفظ بيانات الفاتورة بنجاح", "نجاح",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // إعادة رمي الاستثناء للتعامل معه في btnSave_Click
                // لا نعرض رسالة هنا لتجنب التكرار
                throw;
            }
        }

        private void UpdatePartnersHoursFromGrid()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSalesId.Text))
                {
                    return; // لا يوجد رقم فاتورة
                }

                string billNo = txtSalesId.Text.Trim();
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
                        // تحويل القيم من string إلى int?
                        int? hoursCountInt = null;
                        int? minutesCountInt = null;
                        int? hoursAvalibleInt = null;
                        int? minutesAvalibleInt = null;
                        int? totalHoursInt = null;

                        if (!string.IsNullOrWhiteSpace(hoursCount))
                        {
                            int temp;
                            if (int.TryParse(hoursCount, out temp))
                                hoursCountInt = temp;
                        }

                        if (!string.IsNullOrWhiteSpace(minutesCount))
                        {
                            int temp;
                            if (int.TryParse(minutesCount, out temp))
                                minutesCountInt = temp;
                        }

                        if (!string.IsNullOrWhiteSpace(hoursAvalible))
                        {
                            int temp;
                            if (int.TryParse(hoursAvalible, out temp))
                                hoursAvalibleInt = temp;
                        }

                        if (!string.IsNullOrWhiteSpace(minutesAvalible))
                        {
                            int temp;
                            if (int.TryParse(minutesAvalible, out temp))
                                minutesAvalibleInt = temp;
                        }

                        if (!string.IsNullOrWhiteSpace(totalHours))
                        {
                            int temp;
                            if (int.TryParse(totalHours, out temp))
                                totalHoursInt = temp;
                        }

                        partnersHours.UPDATE_SALE_PARTNER_HOURS_BY_BILLNO(
                            billNo,
                            partnerId,
                            partnerNumber ?? "",
                            partnerName ?? "",
                            hoursCountInt,
                            minutesCountInt,
                            hoursAvalibleInt,
                            minutesAvalibleInt,
                            totalHoursInt
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

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            // حساب الفرق بين وقت البداية ووقت النهاية 
               
                  if (dtpStartTime == null || dtpEndTime == null)
                        return;

                    // نحسب الفرق
                    bool ok = CalculateCustomWorkTime(dtpStartTime.Value,
                                                    dtpEndTime.Value,
                                                    out int hours,
                                                    out int minutes);

                    // إذا لا يوجد خطأ → اعرض القيم
                    txtHours.Text = hours.ToString();
                    txtMinutes.Text = minutes.ToString("00");

                    // إعادة حساب الإجماليات (إذا عندك منطق آخر)
                    CalculateTotals_TextChanged(null, null);
        }


        public bool CalculateCustomWorkTime(DateTime start, DateTime end,
                                            out int hours, out int minutes)
            {
                hours = 0;
                minutes = 0;

                // لو وقت النهاية قبل البداية نرجع false
                if (end < start)
                {
                    return false;
                }

                // 1) الفرق الطبيعي
                TimeSpan diff = end - start;

                // 2) تحويل كل الوقت إلى دقائق
                int totalMinutes = (int)diff.TotalMinutes;

                // 3) استخراج الساعات والدقائق
                hours = totalMinutes / 60;
                minutes = totalMinutes % 60;

                return true;
            }



        


        private double GetDieselUsedInHour()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtPriceLevel.Text))
                {
                    DataTable pricingData = pricing.VIEW_PRICING(txtPriceLevel.Text.Trim());
                    if (pricingData.Rows.Count > 0)
                    {
                        DataRow row = pricingData.Rows[0];
                        if (row["DieselUsedHour"] != DBNull.Value)
                        {
                            return Convert.ToDouble(row["DieselUsedHour"]);
                        }
                    }
                }
            }
            catch
            {
                // في حالة الخطأ، نعيد 0
            }
            return 0;
        }

        private double GetDieselUsedInMinute()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtPriceLevel.Text))
                {
                    DataTable pricingData = pricing.VIEW_PRICING(txtPriceLevel.Text.Trim());
                    if (pricingData.Rows.Count > 0)
                    {
                        DataRow row = pricingData.Rows[0];
                        if (row["DieselUsedMinute"] != DBNull.Value)
                        {
                            return Convert.ToDouble(row["DieselUsedMinute"]);
                        }
                    }
                }
            }
            catch
            {
                // في حالة الخطأ، نعيد 0
            }
            return 0;
        }

        // دالة لتنسيق الأرقام بفواصل الآلاف
        private string FormatNumber(object value)
        {
            if (value == null || value == DBNull.Value)
                return "";
            
            if (double.TryParse(value.ToString().Replace(",", ""), out double num))
            {
                return num.ToString("N0", new CultureInfo("en-US"));
            }
            return value.ToString();
        }

        // دالة لإزالة التنسيق من الأرقام
        private string RemoveFormatting(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return "";
            return value.Replace(",", "").Trim();
        }

        // حساب إجمالي الماء والديزل والإجمالي الكلي
        private void CalculateTotals_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // حساب إجمالي الماء
                double waterTotal = CalculateWaterTotal();
                textWaterTotalPrice.Text = FormatNumber(waterTotal);

                // حساب إجمالي الديزل
                double dieselTotal = CalculateDieselTotal();
                txtDieselTotalPrice.Text = FormatNumber(dieselTotal);

                // حساب الإجمالي الكلي الأساسي (بدون خصم)
                double totalAmount = waterTotal + dieselTotal;
                txtTotalAmount.Text = FormatNumber(totalAmount);

                // حساب المبلغ المستحق والمتبقي (مع تطبيق الخصم)
                CalculateRemainingAmount();
            }
            catch
            {
                // في حالة الخطأ، نترك الحقول فارغة
            }
        }

        // حساب إجمالي الماء
        private double CalculateWaterTotal()
        {
            try
            {
                double hours = string.IsNullOrWhiteSpace(txtHours.Text) ? 0 : Convert.ToDouble(txtHours.Text);
                double minutes = string.IsNullOrWhiteSpace(txtMinutes.Text) ? 0 : Convert.ToDouble(txtMinutes.Text);
                double waterHourPrice = string.IsNullOrWhiteSpace(txtWaterHourPrice.Text) ? 0 : Convert.ToDouble(txtWaterHourPrice.Text);
                double waterMinutePrice = string.IsNullOrWhiteSpace(txtWaterMinutesPrice.Text) ? 0 : Convert.ToDouble(txtWaterMinutesPrice.Text);

                // إجمالي الماء = (سعر الساعة × عدد الساعات) + (سعر الدقيقة × عدد الدقائق)
                double total = (waterHourPrice * hours) + (waterMinutePrice * minutes);
                return total;
            }
            catch
            {
                return 0;
            }
        }

        // حساب إجمالي الديزل
        private double CalculateDieselTotal()
        {
            try
            {
                double hours = string.IsNullOrWhiteSpace(txtHours.Text) ? 0 : Convert.ToDouble(txtHours.Text);
                double minutes = string.IsNullOrWhiteSpace(txtMinutes.Text) ? 0 : Convert.ToDouble(txtMinutes.Text);
                double dieselHourPrice = string.IsNullOrWhiteSpace(txtDieselHourPrice.Text) ? 0 : Convert.ToDouble(txtDieselHourPrice.Text);
                double dieselMinutePrice = string.IsNullOrWhiteSpace(txtDieselMinutesPrice.Text) ? 0 : Convert.ToDouble(txtDieselMinutesPrice.Text);

                // إجمالي الديزل = (سعر الساعة × عدد الساعات) + (سعر الدقيقة × عدد الدقائق)
                double total = (dieselHourPrice * hours) + (dieselMinutePrice * minutes);
                return total;
            }
            catch
            {
                return 0;
            }
        }

        // حساب المتبقي
        private void CalculateRemainingAmount_TextChanged(object sender, EventArgs e)
        {
            CalculateRemainingAmount();
        }

        private void CalculateRemainingAmount()
        {
            try
            {
                double totalAmount = string.IsNullOrWhiteSpace(txtTotalAmount.Text) ? 0 : Convert.ToDouble(RemoveFormatting(txtTotalAmount.Text));
                double paidAmount = string.IsNullOrWhiteSpace(txtPaidAmount.Text) ? 0 : Convert.ToDouble(RemoveFormatting(txtPaidAmount.Text));

                // حساب خصومات الشركاء (إذا كان نوع العميل = شريك)
                double totalDiscounts = CalculateTotalPartnerDiscounts();

                // المبلغ المستحق = الإجمالي الكلي - الخصم
                double dueAmount = totalAmount - totalDiscounts;
                txtDueAmount.Text = FormatNumber(dueAmount);

                // المتبقي = المبلغ المستحق - المدفوع
                double remainingAmount = dueAmount - paidAmount;
                txtRemainingAmount.Text = FormatNumber(remainingAmount);
            }
            catch
            {
                // في حالة الخطأ، نترك الحقل فارغاً
            }
        }
        

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // التحقق من أن التغيير في عمود HoursUesed أو MinutesCount
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                DataGridViewColumn column = this.dataGridView1.Columns[e.ColumnIndex];
                if (column == null)
                    return;

                // التحقق من أن التغيير في عمود الساعات أو الدقائق المستخدمة
                if (column.Name == "HoursUesed" || column.Name == "MinutesCount")
                {
                    // حساب إجمالي الساعات والدقائق من DataGridView
                    CalculateTotalHoursAndMinutesFromGrid();
                }
                
                if (column.Name != "HoursUesed" && column.Name != "MinutesCount")
                    return;

                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                if (row.IsNewRow)
                    return;

                // التحقق من الشروط: نوع العميل = "شريك" وأن PartenerId = txtCustomerId
                if (cmbCustomerType == null || cmbCustomerType.SelectedIndex != 1) // 1 = شريك
                    return;

                if (string.IsNullOrWhiteSpace(txtCustomerId.Text))
                    return;

                // قراءة PartenerId من الصف الحالي
                string partnerId = "";
                if (row.Cells["PartenerId"] != null && row.Cells["PartenerId"].Value != null)
                {
                    partnerId = row.Cells["PartenerId"].Value.ToString().Trim();
                }

                // التحقق من أن PartenerId = txtCustomerId (نفس الشريك)
                if (partnerId != txtCustomerId.Text.Trim())
                    return;

                // قراءة الساعات والدقائق المستخدمة من الصف الحالي
                double hoursUsed = 0;
                double minutesUsed = 0;

                if (row.Cells["HoursUesed"] != null && row.Cells["HoursUesed"].Value != null)
                {
                    if (!double.TryParse(row.Cells["HoursUesed"].Value.ToString(), out hoursUsed))
                        hoursUsed = 0;
                }

                if (row.Cells["MinutesCount"] != null && row.Cells["MinutesCount"].Value != null)
                {
                    if (!double.TryParse(row.Cells["MinutesCount"].Value.ToString(), out minutesUsed))
                        minutesUsed = 0;
                }

                // قراءة أسعار الماء من الفاتورة
                double waterHourPrice = 0;
                double waterMinutesPrice = 0;

                if (!string.IsNullOrWhiteSpace(txtWaterHourPrice.Text))
                {
                    if (!double.TryParse(txtWaterHourPrice.Text, out waterHourPrice))
                        waterHourPrice = 0;
                }

                if (!string.IsNullOrWhiteSpace(txtWaterMinutesPrice.Text))
                {
                    if (!double.TryParse(txtWaterMinutesPrice.Text, out waterMinutesPrice))
                        waterMinutesPrice = 0;
                }

                // حساب المبلغ المخصوم لهذا الصف: (الساعات × سعر ساعة الماء) + (الدقائق × سعر دقيقة الماء)
                double discountAmount = (hoursUsed * waterHourPrice) + (minutesUsed * waterMinutesPrice);

                // إعادة حساب الإجماليات مع تطبيق الخصومات من جميع الصفوف
                // (لأنه قد يكون هناك عدة صفوف للشريك نفسه)
                CalculateTotals_TextChanged(null, null);
                
                // حساب إجمالي الساعات والدقائق من DataGridView
                CalculateTotalHoursAndMinutesFromGrid();
            }
            catch (Exception ex)
            {
                // في حالة الخطأ، لا نفعل شيئاً لتجنب تعطيل العملية
            }
        }
        
        // حساب إجمالي الساعات والدقائق من DataGridView
        private void CalculateTotalHoursAndMinutesFromGrid()
        {
            try
            {
                double totalHours = 0;
                double totalMinutes = 0;
                
                if (this.dataGridView1 != null)
                {
                    foreach (DataGridViewRow row in this.dataGridView1.Rows)
                    {
                        // تخطي الصف الجديد (NewRow)
                        if (row.IsNewRow)
                            continue;
                        
                        // قراءة الساعات
                        if (row.Cells["HoursUesed"] != null && row.Cells["HoursUesed"].Value != null)
                        {
                            string hoursStr = row.Cells["HoursUesed"].Value.ToString().Trim();
                            if (!string.IsNullOrWhiteSpace(hoursStr))
                            {
                                if (double.TryParse(hoursStr, out double hours))
                                {
                                    totalHours += hours;
                                }
                            }
                        }
                        
                        // قراءة الدقائق
                        if (row.Cells["MinutesCount"] != null && row.Cells["MinutesCount"].Value != null)
                        {
                            string minutesStr = row.Cells["MinutesCount"].Value.ToString().Trim();
                            if (!string.IsNullOrWhiteSpace(minutesStr))
                            {
                                if (double.TryParse(minutesStr, out double minutes))
                                {
                                    totalMinutes += minutes;
                                }
                            }
                        }
                    }
                }
                
                // تحويل الدقائق الزائدة (كل 60 دقيقة = ساعة واحدة) إلى ساعات
                if (totalMinutes >= 60)
                {
                    // حساب عدد الساعات الإضافية من الدقائق
                    int additionalHours = (int)(totalMinutes / 60);
                    totalHours += additionalHours;
                    
                    // حساب الدقائق المتبقية بعد التحويل
                    totalMinutes = totalMinutes % 60;
                }
                
                // عرض الإجماليات في الحقول
                if (txtTotalHoursFromGrid != null)
                {
                    txtTotalHoursFromGrid.Text = totalHours.ToString();
                }
                
                if (txtTotalMinutesFromGrid != null)
                {
                    txtTotalMinutesFromGrid.Text = totalMinutes.ToString();
                }
            }
            catch
            {
                // في حالة الخطأ، لا نفعل شيئاً
            }
        }

        // حساب إجمالي الخصومات من جميع صفوف الشركاء المطابقة للشروط
        private double CalculateTotalPartnerDiscounts()
        {
            double totalDiscounts = 0;

            try
            {
                // التحقق من الشروط الأساسية
                if (cmbCustomerType == null || cmbCustomerType.SelectedIndex != 1) // 1 = شريك
                    return 0;

                if (string.IsNullOrWhiteSpace(txtCustomerId.Text))
                    return 0;

                // قراءة أسعار الماء من الفاتورة
                double waterHourPrice = 0;
                double waterMinutesPrice = 0;

                if (!string.IsNullOrWhiteSpace(txtWaterHourPrice.Text))
                {
                    if (!double.TryParse(txtWaterHourPrice.Text, out waterHourPrice))
                        waterHourPrice = 0;
                }

                if (!string.IsNullOrWhiteSpace(txtWaterMinutesPrice.Text))
                {
                    if (!double.TryParse(txtWaterMinutesPrice.Text, out waterMinutesPrice))
                        waterMinutesPrice = 0;
                }

                // حساب الخصومات من جميع الصفوف
                if (this.dataGridView1 != null)
                {
                    foreach (DataGridViewRow row in this.dataGridView1.Rows)
                    {
                        if (row.IsNewRow)
                            continue;

                        // قراءة PartenerId من الصف
                        string partnerId = "";
                        if (row.Cells["PartenerId"] != null && row.Cells["PartenerId"].Value != null)
                        {
                            partnerId = row.Cells["PartenerId"].Value.ToString().Trim();
                        }

                        // التحقق من أن PartenerId = txtCustomerId
                        if (partnerId != txtCustomerId.Text.Trim())
                            continue;

                        // قراءة الساعات والدقائق المستخدمة
                        double hoursUsed = 0;
                        double minutesUsed = 0;

                        if (row.Cells["HoursUesed"] != null && row.Cells["HoursUesed"].Value != null)
                        {
                            if (!double.TryParse(row.Cells["HoursUesed"].Value.ToString(), out hoursUsed))
                                hoursUsed = 0;
                        }

                        if (row.Cells["MinutesCount"] != null && row.Cells["MinutesCount"].Value != null)
                        {
                            if (!double.TryParse(row.Cells["MinutesCount"].Value.ToString(), out minutesUsed))
                                minutesUsed = 0;
                        }

                        // حساب المبلغ المخصوم لهذا الصف
                        double discountAmount = (hoursUsed * waterHourPrice) + (minutesUsed * waterMinutesPrice);
                        totalDiscounts += discountAmount;
                    }
                }
            }
            catch
            {
                // في حالة الخطأ، نعيد 0
            }

            return totalDiscounts;
        }

       /* private void txtPeriodId_KeyDown(object sender, KeyEventArgs e)
        {
               if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // منع التنقل الافتراضي لـ Enter
                // استخدام الكلاس المساعد الموحد
                Clas.PeriodHelper.ShowPeriodsList(txtPeriodId, txtPeriodStartDate, txtPeriodEndDate);
            }
        }*/

       
        public void AddPostFormSales()
        {
            string cusPartType = "";
            if (cmbCustomerType != null && cmbCustomerType.SelectedIndex == 1) // شريك
            {
                cusPartType = "2";
            }
            else // عميل
            {
                cusPartType = "1";
            }
            sal.ADD_POST(
                    "insert",                                      // action
                    "1",                                           // doc_type (فاتورة مثلاً)
                    txtSalesId.Text.Trim(),                        // doc_no
                    cmbBillType.SelectedItem != null ? cmbBillType.SelectedItem.ToString() : "",                                            // doc_no_type (لو عندك كومبو أو قيمة.. حطها هنا)
                    txtPeriodId.Text.Trim(),                                            // period_id  (لو عندك فترة محاسبية.. حطها هنا)
                    cusPartType,                                        // cus_part_type (نوع العميل/الشريك - غيّرها حسب تصميمك)
                    txtCustomerId.Text.Trim(),                     // cus_part_no
                    txtCustomerName.Text.Trim(),                   // cus_part_name (لو ما عندك كنترول للاسم خله "")
                    string.IsNullOrWhiteSpace(txtDueAmount.Text)
                        ? 0
                        : Convert.ToDouble(RemoveFormatting(txtDueAmount.Text)),   // dr_amt
                string.IsNullOrWhiteSpace(txtPaidAmount.Text)
                        ? 0
                        : Convert.ToDouble(RemoveFormatting(txtPaidAmount.Text)),                                             // cr_amt (أو بدّل بينهم حسب طبيعة القيد)
                    dateTimePicker1.Value.Date,                       // date
                    dtpStartTime.Value,                            // start_time (DateTime)
                    dtpEndTime.Value,                              // end_time   (DateTime)
                    string.IsNullOrWhiteSpace(txtHours.Text)
                        ? 0
                        : (int)Convert.ToDouble(txtHours.Text),    // hours
                    string.IsNullOrWhiteSpace(txtMinutes.Text)
                        ? 0
                        : (int)Convert.ToDouble(txtMinutes.Text),  // minutes
                    string.IsNullOrWhiteSpace(txtWaterHourPrice.Text)
                        ? 0
                        : Convert.ToDouble(txtWaterHourPrice.Text),       // water_hour_price
                    string.IsNullOrWhiteSpace(txtDieselHourPrice.Text)
                        ? 0
                        : Convert.ToDouble(txtDieselHourPrice.Text),      // diesel_hour_price
                    string.IsNullOrWhiteSpace(txtWaterMinutesPrice.Text)
                        ? 0
                        : Convert.ToDouble(txtWaterMinutesPrice.Text),    // water_Minutes_price
                    string.IsNullOrWhiteSpace(txtDieselMinutesPrice.Text)
                        ? 0
                        : Convert.ToDouble(txtDieselMinutesPrice.Text),   // diesel_Minutes_price
                    string.IsNullOrWhiteSpace(textWaterTotalPrice.Text)
                        ? 0
                        : Convert.ToDouble(RemoveFormatting(textWaterTotalPrice.Text)),     // water_total
                    string.IsNullOrWhiteSpace(txtDieselTotalPrice.Text)
                        ? 0
                        : Convert.ToDouble(RemoveFormatting(txtDieselTotalPrice.Text)),     // diesel_total
                    string.IsNullOrWhiteSpace(txtTotalAmount.Text)
                        ? 0
                        : Convert.ToDouble(RemoveFormatting(txtTotalAmount.Text)),          // total_amount
                    txtNote.Text.Trim(),                                            // note
                    ""                          // user_id
                );
        }

        private void txtPaidAmount_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(txtPaidAmount.Text, out double value))
            {
                txtPaidAmount.Text = value.ToString("N2");  // مثل 1,250.00
            }
        }

        private void txtPeriodId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                isLoadingPeriodFromList = true;
                Clas.PeriodHelper.ShowPeriodsList(txtPeriodId, txtPeriodStartDate, txtPeriodEndDate);
                isLoadingPeriodFromList = false;
            }
        }

        private void txtPeriodId_Leave(object sender, EventArgs e)
        {
            // إذا كان يتم تحميل البيانات من القائمة، لا نتحقق مرة أخرى
            if (isLoadingPeriodFromList)
                return;

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
                LoadPeriodDataToBill(dt.Rows[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء التحقق من رقم الفترة: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPeriodId.Focus();
            }
        }

        // دالة لتحميل بيانات الفترة وعرضها في الحقول
        private void LoadPeriodDataToBill(DataRow row)
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

        private void btnDstAmount_Click(object sender, EventArgs e)
        {
            double padMdasel = (Convert.ToDouble(txtPaidAmount.Text) - Convert.ToDouble(txtDieselTotalPrice.Text));
            if (padMdasel >= 0)
            {
                this.calculat_Distribution(padMdasel);
            }
            else
            {
                MessageBox.Show("يجب ان يكون المبلغ المدفوع اكبر من اجمالي قيمه الديزل لكي يتم الاحتساب");
            }
            
            
        }


        private void calculat_Distribution (double total_water)
        {
            double hours = string.IsNullOrWhiteSpace(txtHours.Text) ? 0 : Convert.ToDouble(txtHours.Text);
            double minutes = string.IsNullOrWhiteSpace(txtMinutes.Text) ? 0 : Convert.ToDouble(txtMinutes.Text);
            double total_h_m = ((hours * 60) + minutes);
            double m_price = Math.Round(total_water / total_h_m, 3);
            double h_price = Math.Round(m_price * 60, 3);

            txtWaterHourPrice.Text = h_price.ToString();
            txtWaterMinutesPrice.Text = m_price.ToString();

        }

        private void chkBxCalc_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkBxCalc.Checked)
            {
                if(is_check != 1)
                    txtPriceLevel.Clear();
                btnDstAmount.Visible = false;
                
                is_check = 0;
            }
            else
            {
                btnDstAmount.Visible = true;
            }
           // btnDstAmount.Visible = chkBxCalc.Checked;
            //txtPriceLevel.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
           
             if (btnSave.Enabled)
            {
                DialogResult result = MessageBox.Show($"هل تريد الرجوع وعدم حفظ البيانات ؟", "تأكيد الإلغاء", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    clear_SALES();
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

            txtCustomerId.ReadOnly = true;
            txtPeriodId.ReadOnly = true;
            txtPriceLevel.ReadOnly = true;
            txtNote.ReadOnly = true;
            txtPaidAmount.ReadOnly = true;
            chkBxCalc.Enabled = false;
            chkManwalTime.Enabled = false;
        }

        private void SetViewMode()
        {
            btnView.Enabled = true;
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;

            txtCustomerId.ReadOnly = true;
            txtPeriodId.ReadOnly = true;
            txtPriceLevel.ReadOnly = true;
            txtNote.ReadOnly = true;
            txtPaidAmount.ReadOnly = true;
             chkBxCalc.Enabled = false;
            chkManwalTime.Enabled = false;
        }

        private void SetAddMode()
        {
            btnSave.Enabled = true;
            btnView.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = false;

            txtCustomerId.ReadOnly = false;
            txtPeriodId.ReadOnly = false;
            txtPriceLevel.ReadOnly = false;
            txtNote.ReadOnly = false;
            txtPaidAmount.ReadOnly = false;
            txtSalesId.Focus();
            cmbBillType.SelectedIndex = 0;
             chkBxCalc.Enabled = true;
            chkManwalTime.Enabled = true;
        }

        private void SetEditMode()
        {
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnView.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;

            txtCustomerId.ReadOnly = true;
            txtPeriodId.ReadOnly = false;
            txtPriceLevel.ReadOnly = false;
            txtNote.ReadOnly = false;
            txtPaidAmount.ReadOnly = false;
             chkBxCalc.Enabled = true;
            chkManwalTime.Enabled = true;
        }

        private void SetAfterSaveMode()
        {          
            SetNormalMode();
        }
          private void SetDeleteMode()
        {    
               SetNormalMode();
        }

        private void chkManwalTime_CheckedChanged(object sender, EventArgs e)
        {
            if(chkManwalTime.Checked)
            {
                txtHours.ReadOnly = false;
                txtMinutes.ReadOnly = false;
            }
            else
            {
                txtHours.ReadOnly = true;
                txtMinutes.ReadOnly = true;
            }
        }
    }
}

