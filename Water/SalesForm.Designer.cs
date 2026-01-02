namespace Water
{
    partial class SalesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtTotalMinutesFromGrid = new System.Windows.Forms.TextBox();
            this.lblTotalMinutesFromGrid = new System.Windows.Forms.Label();
            this.txtTotalHoursFromGrid = new System.Windows.Forms.TextBox();
            this.lblTotalHoursFromGrid = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bill_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartenerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartenerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoursUesed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinutesCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoursAvalible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinutesAvalible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkManwalTime = new System.Windows.Forms.CheckBox();
            this.chkBxCalc = new System.Windows.Forms.CheckBox();
            this.btnDstAmount = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDieselMinutesPrice = new System.Windows.Forms.TextBox();
            this.txtWaterMinutesPrice = new System.Windows.Forms.TextBox();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.txtPriceLevel = new System.Windows.Forms.TextBox();
            this.lblPriceLevl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblCustName = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtRemainingAmount = new System.Windows.Forms.TextBox();
            this.lblRemainingAmount = new System.Windows.Forms.Label();
            this.txtPaidAmount = new System.Windows.Forms.TextBox();
            this.lblPaidAmount = new System.Windows.Forms.Label();
            this.txtDueAmount = new System.Windows.Forms.TextBox();
            this.lblDueAmount = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.txtDieselTotalPrice = new System.Windows.Forms.TextBox();
            this.lblDieselTotal = new System.Windows.Forms.Label();
            this.textWaterTotalPrice = new System.Windows.Forms.TextBox();
            this.lblWaterTotal = new System.Windows.Forms.Label();
            this.txtDieselHourPrice = new System.Windows.Forms.TextBox();
            this.lblDieselHourPrice = new System.Windows.Forms.Label();
            this.txtWaterHourPrice = new System.Windows.Forms.TextBox();
            this.lblWaterHourPrice = new System.Windows.Forms.Label();
            this.txtMinutes = new System.Windows.Forms.TextBox();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.lblHours = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.txtPeriodId = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.txtSalesId = new System.Windows.Forms.TextBox();
            this.cmbBillType = new System.Windows.Forms.ComboBox();
            this.lblBillType = new System.Windows.Forms.Label();
            this.cmbCustomerType = new System.Windows.Forms.ComboBox();
            this.lblCustomerType = new System.Windows.Forms.Label();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.lblPeriodId = new System.Windows.Forms.Label();
            this.lblSalesCode = new System.Windows.Forms.Label();
            this.txtPeriodEndDate = new System.Windows.Forms.TextBox();
            this.lblPeriodEndDate = new System.Windows.Forms.Label();
            this.txtPeriodStartDate = new System.Windows.Forms.TextBox();
            this.lblPeriodStartDate = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtTotalMinutesFromGrid);
            this.tabPage2.Controls.Add(this.lblTotalMinutesFromGrid);
            this.tabPage2.Controls.Add(this.txtTotalHoursFromGrid);
            this.tabPage2.Controls.Add(this.lblTotalHoursFromGrid);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1304, 460);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "حساب الساعات من الشركاء";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtTotalMinutesFromGrid
            // 
            this.txtTotalMinutesFromGrid.Location = new System.Drawing.Point(8, 110);
            this.txtTotalMinutesFromGrid.Name = "txtTotalMinutesFromGrid";
            this.txtTotalMinutesFromGrid.ReadOnly = true;
            this.txtTotalMinutesFromGrid.Size = new System.Drawing.Size(100, 24);
            this.txtTotalMinutesFromGrid.TabIndex = 0;
            this.txtTotalMinutesFromGrid.TabStop = false;
            this.txtTotalMinutesFromGrid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTotalMinutesFromGrid
            // 
            this.lblTotalMinutesFromGrid.Location = new System.Drawing.Point(9, 82);
            this.lblTotalMinutesFromGrid.Name = "lblTotalMinutesFromGrid";
            this.lblTotalMinutesFromGrid.Size = new System.Drawing.Size(120, 23);
            this.lblTotalMinutesFromGrid.TabIndex = 1;
            this.lblTotalMinutesFromGrid.Text = "اجمالي الدقائق :";
            this.lblTotalMinutesFromGrid.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtTotalHoursFromGrid
            // 
            this.txtTotalHoursFromGrid.Location = new System.Drawing.Point(7, 31);
            this.txtTotalHoursFromGrid.Name = "txtTotalHoursFromGrid";
            this.txtTotalHoursFromGrid.ReadOnly = true;
            this.txtTotalHoursFromGrid.Size = new System.Drawing.Size(100, 24);
            this.txtTotalHoursFromGrid.TabIndex = 2;
            this.txtTotalHoursFromGrid.TabStop = false;
            this.txtTotalHoursFromGrid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTotalHoursFromGrid
            // 
            this.lblTotalHoursFromGrid.Location = new System.Drawing.Point(5, 3);
            this.lblTotalHoursFromGrid.Name = "lblTotalHoursFromGrid";
            this.lblTotalHoursFromGrid.Size = new System.Drawing.Size(123, 23);
            this.lblTotalHoursFromGrid.TabIndex = 3;
            this.lblTotalHoursFromGrid.Text = "اجمالي الساعات :";
            this.lblTotalHoursFromGrid.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bill_no,
            this.PartenerId,
            this.PartenerName,
            this.HoursUesed,
            this.MinutesCount,
            this.HoursAvalible,
            this.MinutesAvalible});
            this.dataGridView1.Location = new System.Drawing.Point(160, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 26;
            this.dataGridView1.Size = new System.Drawing.Size(1055, 448);
            this.dataGridView1.TabIndex = 19;
            // 
            // bill_no
            // 
            this.bill_no.HeaderText = "رقم الفاتورة";
            this.bill_no.Name = "bill_no";
            this.bill_no.ReadOnly = true;
            // 
            // PartenerId
            // 
            this.PartenerId.HeaderText = "رقم الشريك";
            this.PartenerId.Name = "PartenerId";
            // 
            // PartenerName
            // 
            this.PartenerName.HeaderText = "اسم الشريك";
            this.PartenerName.Name = "PartenerName";
            this.PartenerName.ReadOnly = true;
            this.PartenerName.Width = 200;
            // 
            // HoursUesed
            // 
            this.HoursUesed.HeaderText = "عدد الساعات";
            this.HoursUesed.Name = "HoursUesed";
            // 
            // MinutesCount
            // 
            this.MinutesCount.HeaderText = "عدد الدقائق";
            this.MinutesCount.Name = "MinutesCount";
            // 
            // HoursAvalible
            // 
            this.HoursAvalible.HeaderText = "الساعات المتاحة";
            this.HoursAvalible.Name = "HoursAvalible";
            this.HoursAvalible.ReadOnly = true;
            // 
            // MinutesAvalible
            // 
            this.MinutesAvalible.HeaderText = "الدقائق المتاحة";
            this.MinutesAvalible.Name = "MinutesAvalible";
            this.MinutesAvalible.ReadOnly = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkManwalTime);
            this.tabPage1.Controls.Add(this.chkBxCalc);
            this.tabPage1.Controls.Add(this.btnDstAmount);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtDieselMinutesPrice);
            this.tabPage1.Controls.Add(this.txtWaterMinutesPrice);
            this.tabPage1.Controls.Add(this.dtpEndTime);
            this.tabPage1.Controls.Add(this.dtpStartTime);
            this.tabPage1.Controls.Add(this.txtPriceLevel);
            this.tabPage1.Controls.Add(this.lblPriceLevl);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dateTimePicker1);
            this.tabPage1.Controls.Add(this.lblCustName);
            this.tabPage1.Controls.Add(this.txtNote);
            this.tabPage1.Controls.Add(this.lblNote);
            this.tabPage1.Controls.Add(this.txtRemainingAmount);
            this.tabPage1.Controls.Add(this.lblRemainingAmount);
            this.tabPage1.Controls.Add(this.txtPaidAmount);
            this.tabPage1.Controls.Add(this.lblPaidAmount);
            this.tabPage1.Controls.Add(this.txtDueAmount);
            this.tabPage1.Controls.Add(this.lblDueAmount);
            this.tabPage1.Controls.Add(this.txtTotalAmount);
            this.tabPage1.Controls.Add(this.lblTotalAmount);
            this.tabPage1.Controls.Add(this.txtDieselTotalPrice);
            this.tabPage1.Controls.Add(this.lblDieselTotal);
            this.tabPage1.Controls.Add(this.textWaterTotalPrice);
            this.tabPage1.Controls.Add(this.lblWaterTotal);
            this.tabPage1.Controls.Add(this.txtDieselHourPrice);
            this.tabPage1.Controls.Add(this.lblDieselHourPrice);
            this.tabPage1.Controls.Add(this.txtWaterHourPrice);
            this.tabPage1.Controls.Add(this.lblWaterHourPrice);
            this.tabPage1.Controls.Add(this.txtMinutes);
            this.tabPage1.Controls.Add(this.lblMinutes);
            this.tabPage1.Controls.Add(this.txtHours);
            this.tabPage1.Controls.Add(this.lblHours);
            this.tabPage1.Controls.Add(this.lblEndTime);
            this.tabPage1.Controls.Add(this.lblStartTime);
            this.tabPage1.Controls.Add(this.txtPeriodId);
            this.tabPage1.Controls.Add(this.txtCustomerName);
            this.tabPage1.Controls.Add(this.txtCustomerId);
            this.tabPage1.Controls.Add(this.txtSalesId);
            this.tabPage1.Controls.Add(this.cmbBillType);
            this.tabPage1.Controls.Add(this.lblBillType);
            this.tabPage1.Controls.Add(this.cmbCustomerType);
            this.tabPage1.Controls.Add(this.lblCustomerType);
            this.tabPage1.Controls.Add(this.lblCustomerId);
            this.tabPage1.Controls.Add(this.lblPeriodId);
            this.tabPage1.Controls.Add(this.lblSalesCode);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1304, 460);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "فاتورة المبيعات";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkManwalTime
            // 
            this.chkManwalTime.AutoSize = true;
            this.chkManwalTime.Enabled = false;
            this.chkManwalTime.Location = new System.Drawing.Point(59, 42);
            this.chkManwalTime.Name = "chkManwalTime";
            this.chkManwalTime.Size = new System.Drawing.Size(149, 21);
            this.chkManwalTime.TabIndex = 87;
            this.chkManwalTime.Text = "ادخال الساعات يدوي";
            this.chkManwalTime.UseVisualStyleBackColor = true;
            this.chkManwalTime.CheckedChanged += new System.EventHandler(this.chkManwalTime_CheckedChanged);
            // 
            // chkBxCalc
            // 
            this.chkBxCalc.AutoSize = true;
            this.chkBxCalc.Enabled = false;
            this.chkBxCalc.Location = new System.Drawing.Point(8, 15);
            this.chkBxCalc.Name = "chkBxCalc";
            this.chkBxCalc.Size = new System.Drawing.Size(229, 21);
            this.chkBxCalc.TabIndex = 86;
            this.chkBxCalc.Text = "احتساب الفاتورة من المبلغ المدفوع";
            this.chkBxCalc.UseVisualStyleBackColor = true;
            this.chkBxCalc.CheckedChanged += new System.EventHandler(this.chkBxCalc_CheckedChanged);
            // 
            // btnDstAmount
            // 
            this.btnDstAmount.Location = new System.Drawing.Point(8, 384);
            this.btnDstAmount.Name = "btnDstAmount";
            this.btnDstAmount.Size = new System.Drawing.Size(69, 30);
            this.btnDstAmount.TabIndex = 84;
            this.btnDstAmount.Text = "احتساب";
            this.btnDstAmount.UseVisualStyleBackColor = true;
            this.btnDstAmount.Visible = false;
            this.btnDstAmount.Click += new System.EventHandler(this.btnDstAmount_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1192, 304);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(104, 20);
            this.label2.TabIndex = 83;
            this.label2.Text = "سعر الديزل / د :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1195, 263);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(95, 20);
            this.label3.TabIndex = 82;
            this.label3.Text = "سعر الماء / د :";
            // 
            // txtDieselMinutesPrice
            // 
            this.txtDieselMinutesPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDieselMinutesPrice.Location = new System.Drawing.Point(1068, 304);
            this.txtDieselMinutesPrice.Name = "txtDieselMinutesPrice";
            this.txtDieselMinutesPrice.ReadOnly = true;
            this.txtDieselMinutesPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDieselMinutesPrice.Size = new System.Drawing.Size(112, 26);
            this.txtDieselMinutesPrice.TabIndex = 81;
            this.txtDieselMinutesPrice.TabStop = false;
            // 
            // txtWaterMinutesPrice
            // 
            this.txtWaterMinutesPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWaterMinutesPrice.Location = new System.Drawing.Point(1068, 260);
            this.txtWaterMinutesPrice.Name = "txtWaterMinutesPrice";
            this.txtWaterMinutesPrice.ReadOnly = true;
            this.txtWaterMinutesPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtWaterMinutesPrice.Size = new System.Drawing.Size(112, 26);
            this.txtWaterMinutesPrice.TabIndex = 80;
            this.txtWaterMinutesPrice.TabStop = false;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "dd/MM/yyyy  hh:mm tt";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(919, 182);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpEndTime.RightToLeftLayout = true;
            this.dtpEndTime.Size = new System.Drawing.Size(187, 24);
            this.dtpEndTime.TabIndex = 13;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "dd/MM/yyyy  hh:mm tt";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(1110, 182);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpStartTime.RightToLeftLayout = true;
            this.dtpStartTime.Size = new System.Drawing.Size(187, 24);
            this.dtpStartTime.TabIndex = 11;
            // 
            // txtPriceLevel
            // 
            this.txtPriceLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriceLevel.Location = new System.Drawing.Point(669, 180);
            this.txtPriceLevel.Name = "txtPriceLevel";
            this.txtPriceLevel.ReadOnly = true;
            this.txtPriceLevel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPriceLevel.Size = new System.Drawing.Size(76, 26);
            this.txtPriceLevel.TabIndex = 16;
            this.txtPriceLevel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPriceLevel_KeyDown);
            // 
            // lblPriceLevl
            // 
            this.lblPriceLevl.AutoSize = true;
            this.lblPriceLevl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceLevl.Location = new System.Drawing.Point(671, 149);
            this.lblPriceLevl.Name = "lblPriceLevl";
            this.lblPriceLevl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPriceLevl.Size = new System.Drawing.Size(97, 20);
            this.lblPriceLevl.TabIndex = 76;
            this.lblPriceLevl.Text = "مستوى التسعيرة";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(888, 51);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 68;
            this.label1.Text = "التاريخ :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy  hh:mm tt";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(641, 48);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePicker1.RightToLeftLayout = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 24);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // lblCustName
            // 
            this.lblCustName.AutoSize = true;
            this.lblCustName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblCustName.Location = new System.Drawing.Point(862, 87);
            this.lblCustName.Name = "lblCustName";
            this.lblCustName.Size = new System.Drawing.Size(73, 20);
            this.lblCustName.TabIndex = 65;
            this.lblCustName.Text = "اسم العميل ";
            // 
            // txtNote
            // 
            this.txtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Location = new System.Drawing.Point(527, 365);
            this.txtNote.Name = "txtNote";
            this.txtNote.ReadOnly = true;
            this.txtNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNote.Size = new System.Drawing.Size(711, 26);
            this.txtNote.TabIndex = 18;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(1244, 367);
            this.lblNote.Name = "lblNote";
            this.lblNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNote.Size = new System.Drawing.Size(43, 20);
            this.lblNote.TabIndex = 70;
            this.lblNote.Text = "البيان:";
            // 
            // txtRemainingAmount
            // 
            this.txtRemainingAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemainingAmount.Location = new System.Drawing.Point(85, 425);
            this.txtRemainingAmount.Name = "txtRemainingAmount";
            this.txtRemainingAmount.ReadOnly = true;
            this.txtRemainingAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRemainingAmount.Size = new System.Drawing.Size(262, 26);
            this.txtRemainingAmount.TabIndex = 64;
            this.txtRemainingAmount.TabStop = false;
            // 
            // lblRemainingAmount
            // 
            this.lblRemainingAmount.AutoSize = true;
            this.lblRemainingAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainingAmount.Location = new System.Drawing.Point(353, 427);
            this.lblRemainingAmount.Name = "lblRemainingAmount";
            this.lblRemainingAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblRemainingAmount.Size = new System.Drawing.Size(87, 20);
            this.lblRemainingAmount.TabIndex = 63;
            this.lblRemainingAmount.Text = "المبلغ المتبقي:";
            // 
            // txtPaidAmount
            // 
            this.txtPaidAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaidAmount.Location = new System.Drawing.Point(85, 385);
            this.txtPaidAmount.Name = "txtPaidAmount";
            this.txtPaidAmount.ReadOnly = true;
            this.txtPaidAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPaidAmount.Size = new System.Drawing.Size(262, 26);
            this.txtPaidAmount.TabIndex = 17;
            this.txtPaidAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDecimal_KeyPress);
            this.txtPaidAmount.Leave += new System.EventHandler(this.txtPaidAmount_Leave);
            // 
            // lblPaidAmount
            // 
            this.lblPaidAmount.AutoSize = true;
            this.lblPaidAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaidAmount.Location = new System.Drawing.Point(353, 387);
            this.lblPaidAmount.Name = "lblPaidAmount";
            this.lblPaidAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPaidAmount.Size = new System.Drawing.Size(92, 20);
            this.lblPaidAmount.TabIndex = 61;
            this.lblPaidAmount.Text = "المبلغ المدفوع:";
            // 
            // txtDueAmount
            // 
            this.txtDueAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDueAmount.Location = new System.Drawing.Point(85, 345);
            this.txtDueAmount.Name = "txtDueAmount";
            this.txtDueAmount.ReadOnly = true;
            this.txtDueAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDueAmount.Size = new System.Drawing.Size(262, 26);
            this.txtDueAmount.TabIndex = 60;
            this.txtDueAmount.TabStop = false;
            // 
            // lblDueAmount
            // 
            this.lblDueAmount.AutoSize = true;
            this.lblDueAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueAmount.Location = new System.Drawing.Point(353, 347);
            this.lblDueAmount.Name = "lblDueAmount";
            this.lblDueAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDueAmount.Size = new System.Drawing.Size(97, 20);
            this.lblDueAmount.TabIndex = 59;
            this.lblDueAmount.Text = "المبلغ المستحق:";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(85, 305);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalAmount.Size = new System.Drawing.Size(262, 26);
            this.txtTotalAmount.TabIndex = 58;
            this.txtTotalAmount.TabStop = false;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(353, 307);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalAmount.Size = new System.Drawing.Size(97, 20);
            this.lblTotalAmount.TabIndex = 57;
            this.lblTotalAmount.Text = "المبلغ الإجمالي:";
            // 
            // txtDieselTotalPrice
            // 
            this.txtDieselTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDieselTotalPrice.Location = new System.Drawing.Point(41, 181);
            this.txtDieselTotalPrice.Name = "txtDieselTotalPrice";
            this.txtDieselTotalPrice.ReadOnly = true;
            this.txtDieselTotalPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDieselTotalPrice.Size = new System.Drawing.Size(184, 26);
            this.txtDieselTotalPrice.TabIndex = 56;
            this.txtDieselTotalPrice.TabStop = false;
            // 
            // lblDieselTotal
            // 
            this.lblDieselTotal.AutoSize = true;
            this.lblDieselTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDieselTotal.Location = new System.Drawing.Point(122, 150);
            this.lblDieselTotal.Name = "lblDieselTotal";
            this.lblDieselTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDieselTotal.Size = new System.Drawing.Size(87, 20);
            this.lblDieselTotal.TabIndex = 55;
            this.lblDieselTotal.Text = "إجمالي الديزل";
            // 
            // textWaterTotalPrice
            // 
            this.textWaterTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textWaterTotalPrice.Location = new System.Drawing.Point(231, 181);
            this.textWaterTotalPrice.Name = "textWaterTotalPrice";
            this.textWaterTotalPrice.ReadOnly = true;
            this.textWaterTotalPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textWaterTotalPrice.Size = new System.Drawing.Size(204, 26);
            this.textWaterTotalPrice.TabIndex = 54;
            this.textWaterTotalPrice.TabStop = false;
            // 
            // lblWaterTotal
            // 
            this.lblWaterTotal.AutoSize = true;
            this.lblWaterTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaterTotal.Location = new System.Drawing.Point(296, 150);
            this.lblWaterTotal.Name = "lblWaterTotal";
            this.lblWaterTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblWaterTotal.Size = new System.Drawing.Size(78, 20);
            this.lblWaterTotal.TabIndex = 53;
            this.lblWaterTotal.Text = "إجمالي الماء";
            // 
            // txtDieselHourPrice
            // 
            this.txtDieselHourPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDieselHourPrice.Location = new System.Drawing.Point(444, 181);
            this.txtDieselHourPrice.Name = "txtDieselHourPrice";
            this.txtDieselHourPrice.ReadOnly = true;
            this.txtDieselHourPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDieselHourPrice.Size = new System.Drawing.Size(100, 26);
            this.txtDieselHourPrice.TabIndex = 52;
            this.txtDieselHourPrice.TabStop = false;
            // 
            // lblDieselHourPrice
            // 
            this.lblDieselHourPrice.AutoSize = true;
            this.lblDieselHourPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDieselHourPrice.Location = new System.Drawing.Point(437, 150);
            this.lblDieselHourPrice.Name = "lblDieselHourPrice";
            this.lblDieselHourPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDieselHourPrice.Size = new System.Drawing.Size(106, 20);
            this.lblDieselHourPrice.TabIndex = 51;
            this.lblDieselHourPrice.Text = "سعر ساعة الديزل";
            // 
            // txtWaterHourPrice
            // 
            this.txtWaterHourPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWaterHourPrice.Location = new System.Drawing.Point(550, 181);
            this.txtWaterHourPrice.Name = "txtWaterHourPrice";
            this.txtWaterHourPrice.ReadOnly = true;
            this.txtWaterHourPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtWaterHourPrice.Size = new System.Drawing.Size(112, 26);
            this.txtWaterHourPrice.TabIndex = 50;
            this.txtWaterHourPrice.TabStop = false;
            // 
            // lblWaterHourPrice
            // 
            this.lblWaterHourPrice.AutoSize = true;
            this.lblWaterHourPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaterHourPrice.Location = new System.Drawing.Point(564, 150);
            this.lblWaterHourPrice.Name = "lblWaterHourPrice";
            this.lblWaterHourPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblWaterHourPrice.Size = new System.Drawing.Size(97, 20);
            this.lblWaterHourPrice.TabIndex = 49;
            this.lblWaterHourPrice.Text = "سعر ساعة الماء";
            // 
            // txtMinutes
            // 
            this.txtMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinutes.Location = new System.Drawing.Point(750, 180);
            this.txtMinutes.Name = "txtMinutes";
            this.txtMinutes.ReadOnly = true;
            this.txtMinutes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMinutes.Size = new System.Drawing.Size(82, 26);
            this.txtMinutes.TabIndex = 15;
            this.txtMinutes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDecimal_KeyPress);
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutes.Location = new System.Drawing.Point(775, 149);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMinutes.Size = new System.Drawing.Size(46, 20);
            this.lblMinutes.TabIndex = 47;
            this.lblMinutes.Text = "الدقائق";
            // 
            // txtHours
            // 
            this.txtHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHours.Location = new System.Drawing.Point(837, 180);
            this.txtHours.Name = "txtHours";
            this.txtHours.ReadOnly = true;
            this.txtHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtHours.Size = new System.Drawing.Size(76, 26);
            this.txtHours.TabIndex = 14;
            this.txtHours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDecimal_KeyPress);
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHours.Location = new System.Drawing.Point(852, 149);
            this.lblHours.Name = "lblHours";
            this.lblHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblHours.Size = new System.Drawing.Size(55, 20);
            this.lblHours.TabIndex = 45;
            this.lblHours.Text = "الساعات";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndTime.Location = new System.Drawing.Point(976, 150);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblEndTime.Size = new System.Drawing.Size(71, 20);
            this.lblEndTime.TabIndex = 43;
            this.lblEndTime.Text = "وقت النهاية";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTime.Location = new System.Drawing.Point(1174, 150);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblStartTime.Size = new System.Drawing.Size(70, 20);
            this.lblStartTime.TabIndex = 41;
            this.lblStartTime.Text = "وقت البداية";
            // 
            // txtPeriodId
            // 
            this.txtPeriodId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriodId.Location = new System.Drawing.Point(359, 14);
            this.txtPeriodId.Name = "txtPeriodId";
            this.txtPeriodId.ReadOnly = true;
            this.txtPeriodId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPeriodId.Size = new System.Drawing.Size(135, 26);
            this.txtPeriodId.TabIndex = 5;
            this.txtPeriodId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPeriodId_KeyDown);
            this.txtPeriodId.Leave += new System.EventHandler(this.txtPeriodId_Leave);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(491, 80);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(350, 24);
            this.txtCustomerName.TabIndex = 66;
            this.txtCustomerName.TabStop = false;
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerId.Location = new System.Drawing.Point(1041, 85);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.ReadOnly = true;
            this.txtCustomerId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustomerId.Size = new System.Drawing.Size(162, 26);
            this.txtCustomerId.TabIndex = 9;
            this.txtCustomerId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerId_KeyDown);
            this.txtCustomerId.Leave += new System.EventHandler(this.txtCustomerId_Leave);
            // 
            // txtSalesId
            // 
            this.txtSalesId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesId.Location = new System.Drawing.Point(1041, 18);
            this.txtSalesId.Name = "txtSalesId";
            this.txtSalesId.ReadOnly = true;
            this.txtSalesId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSalesId.Size = new System.Drawing.Size(162, 26);
            this.txtSalesId.TabIndex = 0;
            this.txtSalesId.TabStop = false;
            this.txtSalesId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbBillType
            // 
            this.cmbBillType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBillType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBillType.FormattingEnabled = true;
            this.cmbBillType.Items.AddRange(new object[] {
            "آجل",
            "نقد"});
            this.cmbBillType.Location = new System.Drawing.Point(708, 14);
            this.cmbBillType.Name = "cmbBillType";
            this.cmbBillType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbBillType.Size = new System.Drawing.Size(133, 28);
            this.cmbBillType.TabIndex = 3;
            // 
            // lblBillType
            // 
            this.lblBillType.AutoSize = true;
            this.lblBillType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillType.Location = new System.Drawing.Point(865, 17);
            this.lblBillType.Name = "lblBillType";
            this.lblBillType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblBillType.Size = new System.Drawing.Size(79, 20);
            this.lblBillType.TabIndex = 36;
            this.lblBillType.Text = "نوع الفاتورة:";
            // 
            // cmbCustomerType
            // 
            this.cmbCustomerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCustomerType.FormattingEnabled = true;
            this.cmbCustomerType.Items.AddRange(new object[] {
            "عميل",
            "شريك"});
            this.cmbCustomerType.Location = new System.Drawing.Point(1068, 50);
            this.cmbCustomerType.Name = "cmbCustomerType";
            this.cmbCustomerType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbCustomerType.Size = new System.Drawing.Size(133, 28);
            this.cmbCustomerType.TabIndex = 7;
            this.cmbCustomerType.SelectedIndexChanged += new System.EventHandler(this.cmbCustomerType_SelectedIndexChanged);
            // 
            // lblCustomerType
            // 
            this.lblCustomerType.AutoSize = true;
            this.lblCustomerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerType.Location = new System.Drawing.Point(1217, 53);
            this.lblCustomerType.Name = "lblCustomerType";
            this.lblCustomerType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCustomerType.Size = new System.Drawing.Size(74, 20);
            this.lblCustomerType.TabIndex = 68;
            this.lblCustomerType.Text = "نوع العميل:";
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerId.Location = new System.Drawing.Point(1214, 84);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCustomerId.Size = new System.Drawing.Size(73, 20);
            this.lblCustomerId.TabIndex = 39;
            this.lblCustomerId.Text = "رقم العميل:";
            // 
            // lblPeriodId
            // 
            this.lblPeriodId.AutoSize = true;
            this.lblPeriodId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodId.Location = new System.Drawing.Point(500, 16);
            this.lblPeriodId.Name = "lblPeriodId";
            this.lblPeriodId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPeriodId.Size = new System.Drawing.Size(67, 20);
            this.lblPeriodId.TabIndex = 37;
            this.lblPeriodId.Text = "رقم الفترة:";
            // 
            // lblSalesCode
            // 
            this.lblSalesCode.AutoSize = true;
            this.lblSalesCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesCode.Location = new System.Drawing.Point(1209, 19);
            this.lblSalesCode.Name = "lblSalesCode";
            this.lblSalesCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSalesCode.Size = new System.Drawing.Size(78, 20);
            this.lblSalesCode.TabIndex = 35;
            this.lblSalesCode.Text = "رقم الفاتورة:";
            // 
            // txtPeriodEndDate
            // 
            this.txtPeriodEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriodEndDate.Location = new System.Drawing.Point(1183, 543);
            this.txtPeriodEndDate.Name = "txtPeriodEndDate";
            this.txtPeriodEndDate.ReadOnly = true;
            this.txtPeriodEndDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPeriodEndDate.Size = new System.Drawing.Size(137, 26);
            this.txtPeriodEndDate.TabIndex = 87;
            this.txtPeriodEndDate.TabStop = false;
            this.txtPeriodEndDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPeriodEndDate
            // 
            this.lblPeriodEndDate.AutoSize = true;
            this.lblPeriodEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodEndDate.Location = new System.Drawing.Point(1140, 548);
            this.lblPeriodEndDate.Name = "lblPeriodEndDate";
            this.lblPeriodEndDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPeriodEndDate.Size = new System.Drawing.Size(37, 20);
            this.lblPeriodEndDate.TabIndex = 86;
            this.lblPeriodEndDate.Text = "الى :";
            // 
            // txtPeriodStartDate
            // 
            this.txtPeriodStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriodStartDate.Location = new System.Drawing.Point(1011, 544);
            this.txtPeriodStartDate.Name = "txtPeriodStartDate";
            this.txtPeriodStartDate.ReadOnly = true;
            this.txtPeriodStartDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPeriodStartDate.Size = new System.Drawing.Size(120, 26);
            this.txtPeriodStartDate.TabIndex = 85;
            this.txtPeriodStartDate.TabStop = false;
            this.txtPeriodStartDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPeriodStartDate
            // 
            this.lblPeriodStartDate.AutoSize = true;
            this.lblPeriodStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodStartDate.Location = new System.Drawing.Point(932, 548);
            this.lblPeriodStartDate.Name = "lblPeriodStartDate";
            this.lblPeriodStartDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPeriodStartDate.Size = new System.Drawing.Size(73, 20);
            this.lblPeriodStartDate.TabIndex = 84;
            this.lblPeriodStartDate.Text = "الفـترة من :";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 54);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1312, 489);
            this.tabControl1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(605, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 24);
            this.label4.TabIndex = 88;
            this.label4.Text = "فاتورة المبيعات";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Water.Properties.Resources.icons8_save_24_9;
            this.btnSave.Location = new System.Drawing.Point(372, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(60, 40);
            this.btnSave.TabIndex = 21;
            this.toolTip1.SetToolTip(this.btnSave, "حفظ");
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Water.Properties.Resources.icons8_delete_24;
            this.btnDelete.Location = new System.Drawing.Point(307, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDelete.Size = new System.Drawing.Size(60, 40);
            this.btnDelete.TabIndex = 44;
            this.btnDelete.TabStop = false;
            this.toolTip1.SetToolTip(this.btnDelete, "حذف");
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::Water.Properties.Resources.icons8_add_241;
            this.btnAdd.Location = new System.Drawing.Point(179, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAdd.Size = new System.Drawing.Size(60, 40);
            this.btnAdd.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnAdd, "إضافة");
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.Enabled = false;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = global::Water.Properties.Resources.icons8_edit_24_5;
            this.btnEdit.Location = new System.Drawing.Point(242, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnEdit.Size = new System.Drawing.Size(60, 40);
            this.btnEdit.TabIndex = 67;
            this.btnEdit.TabStop = false;
            this.toolTip1.SetToolTip(this.btnEdit, "تعديل");
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnView
            // 
            this.btnView.AccessibleDescription = "";
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = global::Water.Properties.Resources.icons8_view_24;
            this.btnView.Location = new System.Drawing.Point(116, 5);
            this.btnView.Name = "btnView";
            this.btnView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnView.Size = new System.Drawing.Size(60, 40);
            this.btnView.TabIndex = 65;
            this.btnView.TabStop = false;
            this.btnView.Tag = "";
            this.btnView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnView, "عرض");
            this.btnView.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.Image = global::Water.Properties.Resources.icons8_exit_24;
            this.btnExit.Location = new System.Drawing.Point(441, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 40);
            this.btnExit.TabIndex = 89;
            this.btnExit.TabStop = false;
            this.toolTip1.SetToolTip(this.btnExit, "خروج");
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.Image = global::Water.Properties.Resources.icons8_search_24_8;
            this.btnSearch.Location = new System.Drawing.Point(41, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 40);
            this.btnSearch.TabIndex = 90;
            this.toolTip1.SetToolTip(this.btnSearch, "بحث");
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // SalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 575);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPeriodEndDate);
            this.Controls.Add(this.lblPeriodEndDate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPeriodStartDate);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblPeriodStartDate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SalesForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فاتورة المبيعات";
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblRemainingAmount;
        private System.Windows.Forms.Label lblPaidAmount;
        private System.Windows.Forms.Label lblDueAmount;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblDieselTotal;
        private System.Windows.Forms.Label lblWaterTotal;
        private System.Windows.Forms.Label lblDieselHourPrice;
        private System.Windows.Forms.Label lblWaterHourPrice;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.TextBox txtPeriodId;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtSalesId;
        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.Label lblPeriodId;
        private System.Windows.Forms.Label lblSalesCode;
        private System.Windows.Forms.ComboBox cmbBillType;
        private System.Windows.Forms.Label lblBillType;
        private System.Windows.Forms.ComboBox cmbCustomerType;
        private System.Windows.Forms.Label lblCustomerType;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label lblCustName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.TextBox txtMinutes;
        private System.Windows.Forms.TextBox txtWaterHourPrice;
        private System.Windows.Forms.TextBox txtDieselHourPrice;
        private System.Windows.Forms.TextBox textWaterTotalPrice;
        private System.Windows.Forms.TextBox txtDieselTotalPrice;
        private System.Windows.Forms.Label lblPriceLevl;
        private System.Windows.Forms.TextBox txtPriceLevel;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.TextBox txtRemainingAmount;
        private System.Windows.Forms.TextBox txtPaidAmount;
        private System.Windows.Forms.TextBox txtDueAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDieselMinutesPrice;
        private System.Windows.Forms.TextBox txtWaterMinutesPrice;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.TextBox txtPeriodEndDate;
        private System.Windows.Forms.Label lblPeriodEndDate;
        private System.Windows.Forms.TextBox txtPeriodStartDate;
        private System.Windows.Forms.Label lblPeriodStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lblTotalHoursFromGrid;
        private System.Windows.Forms.TextBox txtTotalHoursFromGrid;
        private System.Windows.Forms.Label lblTotalMinutesFromGrid;
        private System.Windows.Forms.TextBox txtTotalMinutesFromGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn bill_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartenerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartenerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoursUesed;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinutesCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoursAvalible;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinutesAvalible;
        private System.Windows.Forms.Button btnDstAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkBxCalc;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox chkManwalTime;
        private System.Windows.Forms.Button btnSearch;
    }
}


