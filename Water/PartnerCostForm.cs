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
    public partial class PartnerCostForm : Form
    {
        private bool isEditMode = false;
        Clas.partner_cost_mst partner_Cost_mst = new Clas.partner_cost_mst();
        Clas.partner_cost_dtl partner_Cost_dtl = new Clas.partner_cost_dtl();
        Clas.downtime downtime = new Clas.downtime();
        Clas.period period = new Clas.period();

        public PartnerCostForm()
        {
            InitializeComponent();
            btnView.Click += btnView_Click;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnSave.Click += btnSave_Click;

            // ربط حدث اختيار رقم التوقف
            cmbDownTimeId.SelectedIndexChanged += cmbDownTimeId_SelectedIndexChanged;
            cmbDownTimeId.KeyDown += cmbDownTimeId_KeyDown;

            // ربط أحداث حساب الساعات والدقائق تلقائياً
            dtpStartTime.ValueChanged += DateTimePicker_ValueChanged;
            dtpEndTime.ValueChanged += DateTimePicker_ValueChanged;

            // ربط أحداث DataGridView والزر
            btnDistributeAmount.Click += btnDistributeAmount_Click;

            // تحميل بيانات downtime في ComboBox
            LoadDownTimeData();

            // تهيئة DataGridView
            InitializeDataGridView();
        }

        private void LoadDownTimeData()
        {
            try
            {
                DataTable dt = downtime.GET_ALL_DOWNTIMES();
                cmbDownTimeId.DataSource = dt;
                cmbDownTimeId.DisplayMember = "id";
                cmbDownTimeId.ValueMember = "id";
                cmbDownTimeId.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل بيانات التوقف: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbDownTimeId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.Enter)
            {
                ShowDownTimeList();
            }
        }

        private void ShowDownTimeList()
        {
            try
            {
                DataTable dt = downtime.GET_ALL_DOWNTIMES();

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات للعرض", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Form viewForm = new Form();
                viewForm.Text = "اختر رقم التوقف";
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
                        LoadDownTimeDataToForm(row);
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

        private void cmbDownTimeId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDownTimeId.SelectedIndex >= 0 && cmbDownTimeId.SelectedValue != null)
            {
                try
                {
                    string downTimeId = cmbDownTimeId.SelectedValue.ToString();
                    DataTable dt = downtime.VIEW_DOWNTIME(downTimeId);
                    if (dt.Rows.Count > 0)
                    {
                        LoadDownTimeDataToForm(dt.Rows[0]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("حدث خطأ أثناء تحميل بيانات التوقف: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadDownTimeDataToForm(DataRow row)
        {
            try
            {
                cmbDownTimeId.Text = row["id"].ToString();

                if (row["period_id"] != DBNull.Value)
                {
                    txtPeriodId.Text = row["period_id"].ToString();
                }

                if (row["date"] != DBNull.Value)
                {
                    dtpDate.Value = Convert.ToDateTime(row["date"]);
                    dtpDate.Checked = true;
                }
                else
                {
                    dtpDate.Checked = false;
                }

                if (row["dayesCount"] != DBNull.Value)
                {
                    txtDayesCount.Text = row["dayesCount"].ToString();
                }

                if (row["hours"] != DBNull.Value)
                {
                    txtHours.Text = row["hours"].ToString();
                }

                if (row["minutes"] != DBNull.Value)
                {
                    txtMinutes.Text = row["minutes"].ToString();
                }

                if (row["startTime"] != DBNull.Value)
                {
                    dtpStartTime.Value = Convert.ToDateTime(row["startTime"]);
                    dtpStartTime.Checked = true;
                }
                else
                {
                    dtpStartTime.Checked = false;
                }

                if (row["endTime"] != DBNull.Value)
                {
                    dtpEndTime.Value = Convert.ToDateTime(row["endTime"]);
                    dtpEndTime.Checked = true;
                }
                else
                {
                    dtpEndTime.Checked = false;
                }

                if (row["amount"] != DBNull.Value)
                {
                    txtAmount.Text = row["amount"].ToString();
                }

                if (row["note"] != DBNull.Value)
                {
                    txtDownTimeNote.Text = row["note"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            CalculateTimeDifference();
        }

        private void CalculateTimeDifference()
        {
            try
            {
                if (dtpStartTime == null || dtpEndTime == null)
                    return;

                TimeSpan timeDifference = dtpEndTime.Value - dtpStartTime.Value;

                if (timeDifference.TotalSeconds < 0)
                {
                    txtHours.Clear();
                    txtMinutes.Clear();
                    return;
                }

                double totalHoursDecimal = timeDifference.TotalHours;
                int hours = (int)Math.Floor(totalHoursDecimal);
                double fractionalHours = totalHoursDecimal - hours;
                double minutesDecimal = fractionalHours * 60;
                int minutes = (int)Math.Round(minutesDecimal);

                txtHours.Text = hours.ToString();
                txtMinutes.Text = minutes.ToString();
            }
            catch
            {
                // في حالة الخطأ، لا نفعل شيئاً
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = partner_Cost_mst.GET_ALL_PARTNER_COST_MST();

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات للعرض", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Form viewForm = new Form();
                viewForm.Text = "عرض توزيع التكاليف بين الشركاء";
                viewForm.RightToLeft = RightToLeft.Yes;
                viewForm.RightToLeftLayout = true;
                viewForm.Size = new Size(1400, 600);
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
                        LoadPartnerCostData(row);
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
            clear_PARTNER_COST();
            try
            {
                txtCostId.Text = partner_Cost_mst.GET_NEXT_PARTNERCOST_CODE();
            }
            catch
            {
                txtCostId.Text = "1";
            }
            btnSave.Text = "حفظ";
            btnSave.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCostId.Text))
            {
                MessageBox.Show("الرجاء إدخال رقم التكلفة أو اختيار تكلفة من قائمة العرض", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string costId = txtCostId.Text.Trim();
                DataTable dt = partner_Cost_mst.VIEW_PARTNER_COST_MST(costId);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("لم يتم العثور على بيانات التكلفة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LoadPartnerCostData(dt.Rows[0]);
                isEditMode = true;
                txtCostId.Enabled = false;
                btnSave.Text = "تحديث";
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCostId.Text))
            {
                MessageBox.Show("الرجاء إدخال رقم التكلفة أو اختيار تكلفة من قائمة العرض", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("هل أنت متأكد من حذف هذه التكلفة؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string costId = txtCostId.Text.Trim();
                    partner_Cost_mst.DELETE_PARTNER_COST_MST(costId);
                    partner_Cost_mst.DELETE_POST("delete","3",costId);
                    partner_Cost_dtl.DELETE_POST("delete","5",costId);
                    MessageBox.Show("تم حذف التكلفة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_PARTNER_COST();
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
               /*  if (string.IsNullOrWhiteSpace(txtCostId.Text))
                {
                    MessageBox.Show("الرجاء إدخال رقم التكلفة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                } */

                string costId = txtCostId.Text.Trim();
                string docType = string.IsNullOrWhiteSpace(cmpDocType.Text) ? null : cmpDocType.Text.Trim();
                DateTime? date = dtpDate.Checked ? (DateTime?)dtpDate.Value.Date : null;
                string downTimeId = cmbDownTimeId.SelectedValue != null ? cmbDownTimeId.SelectedValue.ToString() : null;
                string downTimeNote = txtDownTimeNote.Text.Trim();
                string periodId = string.IsNullOrWhiteSpace(txtPeriodId.Text) ? null : txtPeriodId.Text.Trim();
                int? dayesCount = string.IsNullOrWhiteSpace(txtDayesCount.Text) ? (int?)null : Convert.ToInt32(txtDayesCount.Text);
                int? hours = string.IsNullOrWhiteSpace(txtHours.Text) ? (int?)null : Convert.ToInt32(txtHours.Text);
                int? minutes = string.IsNullOrWhiteSpace(txtMinutes.Text) ? (int?)null : Convert.ToInt32(txtMinutes.Text);
                DateTime? startTime = dtpStartTime.Checked ? (DateTime?)dtpStartTime.Value : null;
                DateTime? endTime = dtpEndTime.Checked ? (DateTime?)dtpEndTime.Value : null;
                double? amount = string.IsNullOrWhiteSpace(txtAmount.Text) ? (double?)null : Convert.ToDouble(txtAmount.Text);
                string note = txtNote.Text.Trim();

                if (isEditMode)
                {
                    partner_Cost_mst.DELETE_POST("delete","3",costId);
                    // تحديث بيانات التكلفة
                    partner_Cost_mst.UPDATE_PARTNER_COST_MST(
                        costId,
                        docType,
                        date,
                        downTimeId,
                        downTimeNote,
                        periodId,
                        dayesCount,
                        hours,
                        minutes,
                        startTime,
                        endTime,
                        amount,
                        note
                    );
                     partner_Cost_mst.ADD_POST(
                    "insert", 
                    "3", 
                    txtCostId.Text.Trim(),
                     "توقف", 
                     txtPeriodId.Text.Trim(),
                      "3",
                       "100011",
                        "حساب التوقف",
                           string.IsNullOrWhiteSpace(txtAmount.Text)
                                ? 0: (int)Convert.ToDouble(txtAmount.Text), 
                                0,
                          dtpDate.Value.Date,
                           dtpStartTime.Value.Date,
                             dtpEndTime.Value,
                              string.IsNullOrWhiteSpace(txtHours.Text)
                                ? 0: (int)Convert.ToDouble(txtHours.Text),
                               string.IsNullOrWhiteSpace(txtMinutes.Text)
                                ? 0: (int)Convert.ToDouble(txtMinutes.Text), 
                             note, 
                             "1"
                             );

                    // حفظ تفاصيل الشركاء
                    SavePartnerCostDetails(costId);

                    MessageBox.Show("تم تحديث بيانات التكلفة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // إضافة تكلفة جديدة
                    partner_Cost_mst.ADD_PARTNER_COST_MST(
                        costId,
                        docType,
                        date,
                        downTimeId,
                        downTimeNote,
                        periodId,
                        dayesCount,
                        hours,
                        minutes,
                        startTime,
                        endTime,
                        amount,
                        note
                    );
                    partner_Cost_mst.ADD_POST(
                    "insert", 
                    "3", 
                    txtCostId.Text.Trim(),
                     "توقف", 
                     txtPeriodId.Text.Trim(),
                      "3",
                       "100011",
                        "حساب التوقف",
                           string.IsNullOrWhiteSpace(txtAmount.Text)
                                ? 0: (int)Convert.ToDouble(txtAmount.Text), 
                                0,
                          dtpDate.Value.Date,
                           dtpStartTime.Value.Date,
                             dtpEndTime.Value,
                              string.IsNullOrWhiteSpace(txtHours.Text)
                                ? 0: (int)Convert.ToDouble(txtHours.Text),
                               string.IsNullOrWhiteSpace(txtMinutes.Text)
                                ? 0: (int)Convert.ToDouble(txtMinutes.Text), 
                             note, 
                             "1"
                             ); 
                    // حفظ تفاصيل الشركاء
                    SavePartnerCostDetails(costId);

                    MessageBox.Show("تم حفظ بيانات التكلفة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                clear_PARTNER_COST();
                isEditMode = false;
                txtCostId.Enabled = true;
                btnSave.Text = "حفظ";
            }
            catch (FormatException)
            {
                MessageBox.Show("الرجاء إدخال قيم رقمية صحيحة في الحقول الرقمية", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ee)
            {
                MessageBox.Show("حدث خطأ أثناء الحفظ: " + ee.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPartnerCostData(DataRow row)
        {
            txtCostId.Text = row["cost_id"].ToString();

             if (row["doc_type"] != DBNull.Value)
            {
                cmpDocType.Text = row["doc_type"].ToString();
            }
            else
            {
                cmpDocType.SelectedIndex = -1;
            } 

            if (row["date"] != DBNull.Value)
            {
                dtpDate.Value = Convert.ToDateTime(row["date"]);
                dtpDate.Checked = true;
            }
            else
            {
                dtpDate.Checked = false;
            }

            if (row["down_timeId"] != DBNull.Value)
            {
                cmbDownTimeId.Text = row["down_timeId"].ToString();
            }
            else
            {
                cmbDownTimeId.SelectedIndex = -1;
            }

            if (row["down_timeNote"] != DBNull.Value)
            {
                txtDownTimeNote.Text = row["down_timeNote"].ToString();
            }
            else
            {
                txtDownTimeNote.Clear();
            }

            if (row["period_id"] != DBNull.Value)
            {
                txtPeriodId.Text = row["period_id"].ToString();
            }
            else
            {
                txtPeriodId.Clear();
            }

            if (row["dayesCount"] != DBNull.Value)
            {
                txtDayesCount.Text = row["dayesCount"].ToString();
            }
            else
            {
                txtDayesCount.Clear();
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

            if (row["startTime"] != DBNull.Value)
            {
                dtpStartTime.Value = Convert.ToDateTime(row["startTime"]);
                dtpStartTime.Checked = true;
            }
            else
            {
                dtpStartTime.Checked = false;
            }

            if (row["endTime"] != DBNull.Value)
            {
                dtpEndTime.Value = Convert.ToDateTime(row["endTime"]);
                dtpEndTime.Checked = true;
            }
            else
            {
                dtpEndTime.Checked = false;
            }

            if (row["amount"] != DBNull.Value)
            {
                txtAmount.Text = row["amount"].ToString();
            }
            else
            {
                txtAmount.Clear();
            }

            if (row["note"] != DBNull.Value)
            {
                txtNote.Text = row["note"].ToString();
            }
            else
            {
                txtNote.Clear();
            }

            // تحميل تفاصيل الشركاء
            string costId = row["cost_id"].ToString();
            LoadPartnerCostDetails(costId);
        }

        private void clear_PARTNER_COST()
        {
            txtCostId.Clear();
            /*  txtDocType.Clear(); */
            cmpDocType.SelectedIndex = -1;
            dtpDate.Value = DateTime.Now;
            dtpDate.Checked = false;
            cmbDownTimeId.SelectedIndex = -1;
            txtDownTimeNote.Clear();
            txtPeriodId.Clear();
            txtDayesCount.Clear();
            txtHours.Clear();
            txtMinutes.Clear();
            dtpStartTime.Value = DateTime.Now;
            dtpStartTime.Checked = false;
            dtpEndTime.Value = DateTime.Now;
            dtpEndTime.Checked = false;
            txtAmount.Clear();
            txtNote.Clear();
            dgvPartners.Rows.Clear();
        }

        private void txtNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            // يسمح بالأرقام والـ Backspace فقط
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
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

        // تهيئة DataGridView
        private void InitializeDataGridView()
        {
            dgvPartners.AutoGenerateColumns = false;
            dgvPartners.AllowUserToAddRows = true;
            dgvPartners.AllowUserToDeleteRows = true;
            dgvPartners.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPartners.MultiSelect = false;
            dgvPartners.RightToLeft = RightToLeft.Yes;

            // إضافة الأعمدة
            dgvPartners.Columns.Clear();

            DataGridViewTextBoxColumn colPartnerId = new DataGridViewTextBoxColumn();
            colPartnerId.Name = "partner_id";
            colPartnerId.HeaderText = "رقم الشريك";
            colPartnerId.Width = 100;
            colPartnerId.ReadOnly = true;
            dgvPartners.Columns.Add(colPartnerId);

            DataGridViewTextBoxColumn colPartnerName = new DataGridViewTextBoxColumn();
            colPartnerName.Name = "partner_name";
            colPartnerName.HeaderText = "اسم الشريك";
            colPartnerName.Width = 200;
            colPartnerName.ReadOnly = true;
            dgvPartners.Columns.Add(colPartnerName);

            DataGridViewTextBoxColumn colAllocatedHours = new DataGridViewTextBoxColumn();
            colAllocatedHours.Name = "allocated_hours";
            colAllocatedHours.HeaderText = "الساعات المخصصة";
            colAllocatedHours.Width = 120;
            colAllocatedHours.ReadOnly = true;
            dgvPartners.Columns.Add(colAllocatedHours);

            DataGridViewTextBoxColumn colMinutes = new DataGridViewTextBoxColumn();
            colMinutes.Name = "minutes";
            colMinutes.HeaderText = "الدقائق";
            colMinutes.Width = 100;
            colMinutes.ReadOnly = true;
            dgvPartners.Columns.Add(colMinutes);

            DataGridViewTextBoxColumn colAllocatedAmount = new DataGridViewTextBoxColumn();
            colAllocatedAmount.Name = "allocated_amount";
            colAllocatedAmount.HeaderText = "المبلغ المخصص";
            colAllocatedAmount.Width = 150;
            colAllocatedAmount.ReadOnly = true;
            dgvPartners.Columns.Add(colAllocatedAmount);

            DataGridViewTextBoxColumn colNote = new DataGridViewTextBoxColumn();
            colNote.Name = "note";
            colNote.HeaderText = "ملاحظات";
            colNote.Width = 200;
            dgvPartners.Columns.Add(colNote);
        }

        private void btnDistributeAmount_Click(object sender, EventArgs e)
        {
            try
            {
                // التحقق من وجود رقم التوقف
                if (cmbDownTimeId.SelectedValue == null && string.IsNullOrWhiteSpace(cmbDownTimeId.Text))
                {
                    MessageBox.Show("الرجاء اختيار رقم التوقف أولاً", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string downTimeId = cmbDownTimeId.SelectedValue != null ? cmbDownTimeId.SelectedValue.ToString() : cmbDownTimeId.Text;

                // استدعاء الـ Stored Procedure
                DataTable dt = partner_Cost_dtl.AllocateDowntimeAmountToPartners(downTimeId);

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات للعرض", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // عرض البيانات في DataGridView
                dgvPartners.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    int rowIndex = dgvPartners.Rows.Add();
                    DataGridViewRow dgvRow = dgvPartners.Rows[rowIndex];

                    // تعبئة رقم الشريك
                    if (row["partner_id"] != DBNull.Value)
                    {
                        dgvRow.Cells["partner_id"].Value = row["partner_id"].ToString();
                    }

                    // تعبئة اسم الشريك
                    if (row["name"] != DBNull.Value)
                    {
                        dgvRow.Cells["partner_name"].Value = row["name"].ToString();
                    }

                    // تعبئة الساعات المخصصة
                    if (row["allocated_hours"] != DBNull.Value)
                    {
                        dgvRow.Cells["allocated_hours"].Value = row["allocated_hours"].ToString();
                    }

                    // تعبئة الدقائق
                    if (row["minutes"] != DBNull.Value)
                    {
                        dgvRow.Cells["minutes"].Value = row["minutes"].ToString();
                    }

                    // تعبئة المبلغ المخصص
                    if (row["allocated_amount"] != DBNull.Value)
                    {
                        dgvRow.Cells["allocated_amount"].Value = row["allocated_amount"].ToString();
                    }
                }
                btnSave.Enabled = true;
                MessageBox.Show("تم توزيع المبلغ بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء توزيع المبلغ: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // تحميل تفاصيل الشركاء من قاعدة البيانات
        private void LoadPartnerCostDetails(string costId)
        {
            try
            {
                DataTable dt = partner_Cost_dtl.VIEW_PARTNER_COST_DTL(costId);
                dgvPartners.Rows.Clear();
                
                foreach (DataRow row in dt.Rows)
                {
                    int rowIndex = dgvPartners.Rows.Add();
                    DataGridViewRow dgvRow = dgvPartners.Rows[rowIndex];

                    if (row["partner_id"] != DBNull.Value)
                    {
                        dgvRow.Cells["partner_id"].Value = row["partner_id"].ToString();
                    }

                    if (row["partner_name"] != DBNull.Value)
                    {
                        dgvRow.Cells["partner_name"].Value = row["partner_name"].ToString();
                    }

                    if (row["allocated_hours"] != DBNull.Value)
                    {
                        dgvRow.Cells["allocated_hours"].Value = row["allocated_hours"].ToString();
                    }

                    if (row["minutes"] != DBNull.Value)
                    {
                        dgvRow.Cells["minutes"].Value = row["minutes"].ToString();
                    }

                    if (row["allocated_amount"] != DBNull.Value)
                    {
                        dgvRow.Cells["allocated_amount"].Value = row["allocated_amount"].ToString();
                    }

                    if (row["note"] != DBNull.Value)
                    {
                        dgvRow.Cells["note"].Value = row["note"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل تفاصيل الشركاء: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // حفظ تفاصيل الشركاء في قاعدة البيانات
        private void SavePartnerCostDetails(string costId)
        {
            try
            {
                // حذف التفاصيل القديمة
                partner_Cost_dtl.DELETE_ALL_PARTNER_COST_DTL_BY_COST_ID(costId);
                partner_Cost_dtl.DELETE_POST("delete","5",costId);
                // إضافة التفاصيل الجديدة
                string docType = string.IsNullOrWhiteSpace(cmpDocType.Text) ? null : cmpDocType.Text.Trim();

                foreach (DataGridViewRow row in dgvPartners.Rows)
                {
                    if (row.IsNewRow) continue;

                    string partnerId = "";
                    string partnerName = "";
                    int? allocatedHours = null;
                    int? minutes = null;
                    double? allocatedAmount = null;
                    string note = "";

                    if (row.Cells["partner_id"].Value != null && !string.IsNullOrWhiteSpace(row.Cells["partner_id"].Value.ToString()))
                    {
                        partnerId = row.Cells["partner_id"].Value.ToString();
                    }

                    if (row.Cells["partner_name"].Value != null)
                    {
                        partnerName = row.Cells["partner_name"].Value.ToString();
                    }

                    if (row.Cells["allocated_hours"].Value != null && !string.IsNullOrWhiteSpace(row.Cells["allocated_hours"].Value.ToString()))
                    {
                        allocatedHours = Convert.ToInt32(row.Cells["allocated_hours"].Value);
                    }

                    if (row.Cells["minutes"].Value != null && !string.IsNullOrWhiteSpace(row.Cells["minutes"].Value.ToString()))
                    {
                        minutes = Convert.ToInt32(row.Cells["minutes"].Value);
                    }

                    if (row.Cells["allocated_amount"].Value != null && !string.IsNullOrWhiteSpace(row.Cells["allocated_amount"].Value.ToString()))
                    {
                        allocatedAmount = Convert.ToDouble(row.Cells["allocated_amount"].Value);
                    }

                    if (row.Cells["note"].Value != null)
                    {
                        note = row.Cells["note"].Value.ToString();
                    }

                    if (!string.IsNullOrWhiteSpace(partnerId) || !string.IsNullOrWhiteSpace(partnerName))
                    {
                        partner_Cost_dtl.ADD_PARTNER_COST_DTL(
                            costId,
                            partnerId,
                            docType,
                            partnerName,
                            allocatedHours,
                            minutes,
                            allocatedAmount,
                            note
                        );
                        
                         partner_Cost_dtl.ADD_POST(
                            "insert", //action
                             "5", //doc_type
                             txtCostId.Text.Trim(), //doc_no
                             cmpDocType.Text, //doc_no_type
                              txtPeriodId.Text.Trim(), //period_id
                              "2",//cus_part_type
                               partnerId,//cus_part_no
                             partnerName,//cus_part_name
                              string.IsNullOrWhiteSpace(allocatedAmount.Value.ToString())
                                ? 0
                                : Convert.ToDouble(allocatedAmount.Value), //dr_amt
                                0.0,//cr_amt
                                 dtpDate.Value.Date,//date
                                     note,//note
                                      "1"//user_id
                                      );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء حفظ تفاصيل الشركاء: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
    }
}

