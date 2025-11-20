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
        Clas.partner_cost_mst partnerCost = new Clas.partner_cost_mst();
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

            // تحميل بيانات downtime في ComboBox
            LoadDownTimeData();
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
                }

                if (row["endTime"] != DBNull.Value)
                {
                    dtpEndTime.Value = Convert.ToDateTime(row["endTime"]);
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
                DataTable dt = partnerCost.GET_ALL_PARTNER_COST_MST();

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
            txtCostId.Enabled = true;
            btnSave.Text = "حفظ";
            MessageBox.Show("يمكنك الآن إدخال بيانات توزيع تكاليف جديد", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                int costId = Convert.ToInt32(txtCostId.Text.Trim());
                DataTable dt = partnerCost.VIEW_PARTNER_COST_MST(costId);

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
            catch (FormatException)
            {
                MessageBox.Show("الرجاء إدخال رقم تكلفة صحيح", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    int costId = Convert.ToInt32(txtCostId.Text.Trim());
                    partnerCost.DELETE_PARTNER_COST_MST(costId);
                    MessageBox.Show("تم حذف التكلفة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_PARTNER_COST();
                }
                catch (FormatException)
                {
                    MessageBox.Show("الرجاء إدخال رقم تكلفة صحيح", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (string.IsNullOrWhiteSpace(txtCostId.Text))
                {
                    MessageBox.Show("الرجاء إدخال رقم التكلفة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int costId = Convert.ToInt32(txtCostId.Text.Trim());
                int? docType = string.IsNullOrWhiteSpace(txtDocType.Text) ? (int?)null : Convert.ToInt32(txtDocType.Text);
                DateTime? date = dtpDate.Checked ? (DateTime?)dtpDate.Value.Date : null;
                string downTimeId = cmbDownTimeId.SelectedValue != null ? cmbDownTimeId.SelectedValue.ToString() : null;
                string downTimeNote = txtDownTimeNote.Text.Trim();
                int? periodId = string.IsNullOrWhiteSpace(txtPeriodId.Text) ? (int?)null : Convert.ToInt32(txtPeriodId.Text);
                int? dayesCount = string.IsNullOrWhiteSpace(txtDayesCount.Text) ? (int?)null : Convert.ToInt32(txtDayesCount.Text);
                int? hours = string.IsNullOrWhiteSpace(txtHours.Text) ? (int?)null : Convert.ToInt32(txtHours.Text);
                int? minutes = string.IsNullOrWhiteSpace(txtMinutes.Text) ? (int?)null : Convert.ToInt32(txtMinutes.Text);
                DateTime? startTime = dtpStartTime.Checked ? (DateTime?)dtpStartTime.Value : null;
                DateTime? endTime = dtpEndTime.Checked ? (DateTime?)dtpEndTime.Value : null;
                double? amount = string.IsNullOrWhiteSpace(txtAmount.Text) ? (double?)null : Convert.ToDouble(txtAmount.Text);
                string note = txtNote.Text.Trim();

                if (isEditMode)
                {
                    // تحديث بيانات التكلفة
                    partnerCost.UPDATE_PARTNER_COST_MST(
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

                    MessageBox.Show("تم تحديث بيانات التكلفة بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // إضافة تكلفة جديدة
                    partnerCost.ADD_PARTNER_COST_MST(
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
                txtDocType.Text = row["doc_type"].ToString();
            }
            else
            {
                txtDocType.Clear();
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
        }

        private void clear_PARTNER_COST()
        {
            txtCostId.Clear();
            txtDocType.Clear();
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
    }
}

