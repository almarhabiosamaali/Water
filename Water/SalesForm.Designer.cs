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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bill_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartenerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartenerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoursUesed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinutesCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoursAvalible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinutesAvalible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.numRemainingAmount = new System.Windows.Forms.NumericUpDown();
            this.lblRemainingAmount = new System.Windows.Forms.Label();
            this.numPaidAmount = new System.Windows.Forms.NumericUpDown();
            this.lblPaidAmount = new System.Windows.Forms.Label();
            this.numDueAmount = new System.Windows.Forms.NumericUpDown();
            this.lblDueAmount = new System.Windows.Forms.Label();
            this.numTotalAmount = new System.Windows.Forms.NumericUpDown();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.numDieselTotal = new System.Windows.Forms.NumericUpDown();
            this.lblDieselTotal = new System.Windows.Forms.Label();
            this.numWaterTotal = new System.Windows.Forms.NumericUpDown();
            this.lblWaterTotal = new System.Windows.Forms.Label();
            this.numDieselHourPrice = new System.Windows.Forms.NumericUpDown();
            this.lblDieselHourPrice = new System.Windows.Forms.Label();
            this.numWaterHourPrice = new System.Windows.Forms.NumericUpDown();
            this.lblWaterHourPrice = new System.Windows.Forms.Label();
            this.numMinutes = new System.Windows.Forms.NumericUpDown();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.numHours = new System.Windows.Forms.NumericUpDown();
            this.lblHours = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.txtPeriodId = new System.Windows.Forms.TextBox();
            this.txtSalesCode = new System.Windows.Forms.TextBox();
            this.cmbBillType = new System.Windows.Forms.ComboBox();
            this.lblBillType = new System.Windows.Forms.Label();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.lblPeriodId = new System.Windows.Forms.Label();
            this.lblSalesCode = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.lblCustName = new System.Windows.Forms.Label();
            this.textCustomName = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.txtMinutes = new System.Windows.Forms.TextBox();
            this.txtWaterHourPrice = new System.Windows.Forms.TextBox();
            this.txtDieselHourPrice = new System.Windows.Forms.TextBox();
            this.textWaterTotalPrice = new System.Windows.Forms.TextBox();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRemainingAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPaidAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDueAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDieselTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWaterTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDieselHourPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWaterHourPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1304, 497);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "حساب الساعات من الشركاء";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.dataGridView1.Location = new System.Drawing.Point(0, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 26;
            this.dataGridView1.Size = new System.Drawing.Size(1105, 471);
            this.dataGridView1.TabIndex = 0;
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
            this.tabPage1.Controls.Add(this.textWaterTotalPrice);
            this.tabPage1.Controls.Add(this.txtDieselHourPrice);
            this.tabPage1.Controls.Add(this.txtWaterHourPrice);
            this.tabPage1.Controls.Add(this.txtMinutes);
            this.tabPage1.Controls.Add(this.txtHours);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dateTimePicker1);
            this.tabPage1.Controls.Add(this.textCustomName);
            this.tabPage1.Controls.Add(this.lblCustName);
            this.tabPage1.Controls.Add(this.numRemainingAmount);
            this.tabPage1.Controls.Add(this.lblRemainingAmount);
            this.tabPage1.Controls.Add(this.numPaidAmount);
            this.tabPage1.Controls.Add(this.lblPaidAmount);
            this.tabPage1.Controls.Add(this.numDueAmount);
            this.tabPage1.Controls.Add(this.lblDueAmount);
            this.tabPage1.Controls.Add(this.numTotalAmount);
            this.tabPage1.Controls.Add(this.lblTotalAmount);
            this.tabPage1.Controls.Add(this.numDieselTotal);
            this.tabPage1.Controls.Add(this.lblDieselTotal);
            this.tabPage1.Controls.Add(this.numWaterTotal);
            this.tabPage1.Controls.Add(this.lblWaterTotal);
            this.tabPage1.Controls.Add(this.numDieselHourPrice);
            this.tabPage1.Controls.Add(this.lblDieselHourPrice);
            this.tabPage1.Controls.Add(this.numWaterHourPrice);
            this.tabPage1.Controls.Add(this.lblWaterHourPrice);
            this.tabPage1.Controls.Add(this.numMinutes);
            this.tabPage1.Controls.Add(this.lblMinutes);
            this.tabPage1.Controls.Add(this.numHours);
            this.tabPage1.Controls.Add(this.lblHours);
            this.tabPage1.Controls.Add(this.dtpEndTime);
            this.tabPage1.Controls.Add(this.lblEndTime);
            this.tabPage1.Controls.Add(this.dtpStartTime);
            this.tabPage1.Controls.Add(this.lblStartTime);
            this.tabPage1.Controls.Add(this.txtCustomerId);
            this.tabPage1.Controls.Add(this.txtPeriodId);
            this.tabPage1.Controls.Add(this.txtSalesCode);
            this.tabPage1.Controls.Add(this.cmbBillType);
            this.tabPage1.Controls.Add(this.lblBillType);
            this.tabPage1.Controls.Add(this.lblCustomerId);
            this.tabPage1.Controls.Add(this.lblPeriodId);
            this.tabPage1.Controls.Add(this.lblSalesCode);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1304, 497);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "فاتورة المبيعات";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // numRemainingAmount
            // 
            this.numRemainingAmount.DecimalPlaces = 2;
            this.numRemainingAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRemainingAmount.Location = new System.Drawing.Point(41, 425);
            this.numRemainingAmount.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numRemainingAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numRemainingAmount.Name = "numRemainingAmount";
            this.numRemainingAmount.Size = new System.Drawing.Size(262, 26);
            this.numRemainingAmount.TabIndex = 64;
            this.numRemainingAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRemainingAmount
            // 
            this.lblRemainingAmount.AutoSize = true;
            this.lblRemainingAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainingAmount.Location = new System.Drawing.Point(309, 427);
            this.lblRemainingAmount.Name = "lblRemainingAmount";
            this.lblRemainingAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblRemainingAmount.Size = new System.Drawing.Size(87, 20);
            this.lblRemainingAmount.TabIndex = 63;
            this.lblRemainingAmount.Text = "المبلغ المتبقي:";
            // 
            // numPaidAmount
            // 
            this.numPaidAmount.DecimalPlaces = 2;
            this.numPaidAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPaidAmount.Location = new System.Drawing.Point(41, 385);
            this.numPaidAmount.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numPaidAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numPaidAmount.Name = "numPaidAmount";
            this.numPaidAmount.Size = new System.Drawing.Size(262, 26);
            this.numPaidAmount.TabIndex = 62;
            this.numPaidAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPaidAmount
            // 
            this.lblPaidAmount.AutoSize = true;
            this.lblPaidAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaidAmount.Location = new System.Drawing.Point(309, 387);
            this.lblPaidAmount.Name = "lblPaidAmount";
            this.lblPaidAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPaidAmount.Size = new System.Drawing.Size(92, 20);
            this.lblPaidAmount.TabIndex = 61;
            this.lblPaidAmount.Text = "المبلغ المدفوع:";
            // 
            // numDueAmount
            // 
            this.numDueAmount.DecimalPlaces = 2;
            this.numDueAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDueAmount.Location = new System.Drawing.Point(41, 345);
            this.numDueAmount.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numDueAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numDueAmount.Name = "numDueAmount";
            this.numDueAmount.Size = new System.Drawing.Size(262, 26);
            this.numDueAmount.TabIndex = 60;
            this.numDueAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDueAmount
            // 
            this.lblDueAmount.AutoSize = true;
            this.lblDueAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueAmount.Location = new System.Drawing.Point(309, 347);
            this.lblDueAmount.Name = "lblDueAmount";
            this.lblDueAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDueAmount.Size = new System.Drawing.Size(97, 20);
            this.lblDueAmount.TabIndex = 59;
            this.lblDueAmount.Text = "المبلغ المستحق:";
            // 
            // numTotalAmount
            // 
            this.numTotalAmount.DecimalPlaces = 2;
            this.numTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTotalAmount.Location = new System.Drawing.Point(41, 305);
            this.numTotalAmount.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numTotalAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numTotalAmount.Name = "numTotalAmount";
            this.numTotalAmount.Size = new System.Drawing.Size(262, 26);
            this.numTotalAmount.TabIndex = 58;
            this.numTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(309, 307);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalAmount.Size = new System.Drawing.Size(97, 20);
            this.lblTotalAmount.TabIndex = 57;
            this.lblTotalAmount.Text = "المبلغ الإجمالي:";
            // 
            // numDieselTotal
            // 
            this.numDieselTotal.DecimalPlaces = 2;
            this.numDieselTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDieselTotal.Location = new System.Drawing.Point(41, 181);
            this.numDieselTotal.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numDieselTotal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numDieselTotal.Name = "numDieselTotal";
            this.numDieselTotal.Size = new System.Drawing.Size(184, 26);
            this.numDieselTotal.TabIndex = 56;
            this.numDieselTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDieselTotal
            // 
            this.lblDieselTotal.AutoSize = true;
            this.lblDieselTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDieselTotal.Location = new System.Drawing.Point(122, 150);
            this.lblDieselTotal.Name = "lblDieselTotal";
            this.lblDieselTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDieselTotal.Size = new System.Drawing.Size(92, 20);
            this.lblDieselTotal.TabIndex = 55;
            this.lblDieselTotal.Text = "إجمالي الديزل:";
            // 
            // numWaterTotal
            // 
            this.numWaterTotal.DecimalPlaces = 2;
            this.numWaterTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numWaterTotal.Location = new System.Drawing.Point(231, 181);
            this.numWaterTotal.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numWaterTotal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numWaterTotal.Name = "numWaterTotal";
            this.numWaterTotal.Size = new System.Drawing.Size(204, 26);
            this.numWaterTotal.TabIndex = 54;
            this.numWaterTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblWaterTotal
            // 
            this.lblWaterTotal.AutoSize = true;
            this.lblWaterTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaterTotal.Location = new System.Drawing.Point(296, 150);
            this.lblWaterTotal.Name = "lblWaterTotal";
            this.lblWaterTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblWaterTotal.Size = new System.Drawing.Size(83, 20);
            this.lblWaterTotal.TabIndex = 53;
            this.lblWaterTotal.Text = "إجمالي الماء:";
            // 
            // numDieselHourPrice
            // 
            this.numDieselHourPrice.DecimalPlaces = 2;
            this.numDieselHourPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDieselHourPrice.Location = new System.Drawing.Point(444, 181);
            this.numDieselHourPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numDieselHourPrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numDieselHourPrice.Name = "numDieselHourPrice";
            this.numDieselHourPrice.Size = new System.Drawing.Size(100, 26);
            this.numDieselHourPrice.TabIndex = 52;
            this.numDieselHourPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDieselHourPrice
            // 
            this.lblDieselHourPrice.AutoSize = true;
            this.lblDieselHourPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDieselHourPrice.Location = new System.Drawing.Point(437, 150);
            this.lblDieselHourPrice.Name = "lblDieselHourPrice";
            this.lblDieselHourPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDieselHourPrice.Size = new System.Drawing.Size(111, 20);
            this.lblDieselHourPrice.TabIndex = 51;
            this.lblDieselHourPrice.Text = "سعر ساعة الديزل:";
            // 
            // numWaterHourPrice
            // 
            this.numWaterHourPrice.DecimalPlaces = 2;
            this.numWaterHourPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numWaterHourPrice.Location = new System.Drawing.Point(550, 181);
            this.numWaterHourPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numWaterHourPrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numWaterHourPrice.Name = "numWaterHourPrice";
            this.numWaterHourPrice.Size = new System.Drawing.Size(112, 26);
            this.numWaterHourPrice.TabIndex = 50;
            this.numWaterHourPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblWaterHourPrice
            // 
            this.lblWaterHourPrice.AutoSize = true;
            this.lblWaterHourPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaterHourPrice.Location = new System.Drawing.Point(564, 150);
            this.lblWaterHourPrice.Name = "lblWaterHourPrice";
            this.lblWaterHourPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblWaterHourPrice.Size = new System.Drawing.Size(102, 20);
            this.lblWaterHourPrice.TabIndex = 49;
            this.lblWaterHourPrice.Text = "سعر ساعة الماء:";
            // 
            // numMinutes
            // 
            this.numMinutes.DecimalPlaces = 2;
            this.numMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMinutes.Location = new System.Drawing.Point(669, 181);
            this.numMinutes.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numMinutes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numMinutes.Name = "numMinutes";
            this.numMinutes.Size = new System.Drawing.Size(82, 26);
            this.numMinutes.TabIndex = 48;
            this.numMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutes.Location = new System.Drawing.Point(694, 150);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMinutes.Size = new System.Drawing.Size(51, 20);
            this.lblMinutes.TabIndex = 47;
            this.lblMinutes.Text = "الدقائق:";
            // 
            // numHours
            // 
            this.numHours.DecimalPlaces = 2;
            this.numHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numHours.Location = new System.Drawing.Point(760, 181);
            this.numHours.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numHours.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numHours.Name = "numHours";
            this.numHours.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numHours.Size = new System.Drawing.Size(76, 26);
            this.numHours.TabIndex = 46;
            this.numHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHours.Location = new System.Drawing.Point(771, 150);
            this.lblHours.Name = "lblHours";
            this.lblHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblHours.Size = new System.Drawing.Size(60, 20);
            this.lblHours.TabIndex = 45;
            this.lblHours.Text = "الساعات:";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "dd/MM/yyyy mm:hh tt";
            this.dtpEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(842, 181);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpEndTime.RightToLeftLayout = true;
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(219, 26);
            this.dtpEndTime.TabIndex = 40;
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndTime.Location = new System.Drawing.Point(885, 150);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblEndTime.Size = new System.Drawing.Size(76, 20);
            this.lblEndTime.TabIndex = 43;
            this.lblEndTime.Text = "وقت النهاية:";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "dd/MM/yyyy mm:hh tt";
            this.dtpStartTime.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(1077, 181);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(227, 26);
            this.dtpStartTime.TabIndex = 39;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTime.Location = new System.Drawing.Point(1174, 150);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblStartTime.Size = new System.Drawing.Size(75, 20);
            this.lblStartTime.TabIndex = 41;
            this.lblStartTime.Text = "وقت البداية:";
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerId.Location = new System.Drawing.Point(367, 18);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustomerId.Size = new System.Drawing.Size(205, 26);
            this.txtCustomerId.TabIndex = 37;
            // 
            // txtPeriodId
            // 
            this.txtPeriodId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriodId.Location = new System.Drawing.Point(940, 75);
            this.txtPeriodId.Name = "txtPeriodId";
            this.txtPeriodId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPeriodId.Size = new System.Drawing.Size(263, 26);
            this.txtPeriodId.TabIndex = 38;
            // 
            // txtSalesCode
            // 
            this.txtSalesCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesCode.Location = new System.Drawing.Point(1041, 18);
            this.txtSalesCode.Name = "txtSalesCode";
            this.txtSalesCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSalesCode.Size = new System.Drawing.Size(162, 26);
            this.txtSalesCode.TabIndex = 35;
            this.txtSalesCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.cmbBillType.TabIndex = 36;
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
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerId.Location = new System.Drawing.Point(1214, 74);
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
            this.lblPeriodId.Location = new System.Drawing.Point(578, 20);
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
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(951, 552);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(74, 40);
            this.btnSave.TabIndex = 69;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(865, 552);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDelete.Size = new System.Drawing.Size(74, 40);
            this.btnDelete.TabIndex = 68;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(781, 552);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnEdit.Size = new System.Drawing.Size(74, 40);
            this.btnEdit.TabIndex = 67;
            this.btnEdit.Text = "تعديل";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(698, 552);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAdd.Size = new System.Drawing.Size(74, 40);
            this.btnAdd.TabIndex = 66;
            this.btnAdd.Text = "إضافة";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(615, 552);
            this.btnView.Name = "btnView";
            this.btnView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnView.Size = new System.Drawing.Size(74, 40);
            this.btnView.TabIndex = 65;
            this.btnView.Text = "عرض";
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1312, 526);
            this.tabControl1.TabIndex = 2;
            // 
            // lblCustName
            // 
            this.lblCustName.AutoSize = true;
            this.lblCustName.Location = new System.Drawing.Point(772, 84);
            this.lblCustName.Name = "lblCustName";
            this.lblCustName.Size = new System.Drawing.Size(81, 17);
            this.lblCustName.TabIndex = 65;
            this.lblCustName.Text = "اسم العميل ";
            // 
            // textCustomName
            // 
            this.textCustomName.Location = new System.Drawing.Point(401, 77);
            this.textCustomName.Name = "textCustomName";
            this.textCustomName.ReadOnly = true;
            this.textCustomName.Size = new System.Drawing.Size(350, 24);
            this.textCustomName.TabIndex = 66;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy mm:hh tt";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(8, 20);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 24);
            this.dateTimePicker1.TabIndex = 67;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(214, 23);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 68;
            this.label1.Text = "التاريخ :";
            // 
            // txtHours
            // 
            this.txtHours.Location = new System.Drawing.Point(760, 213);
            this.txtHours.Name = "txtHours";
            this.txtHours.Size = new System.Drawing.Size(100, 24);
            this.txtHours.TabIndex = 69;
            // 
            // txtMinutes
            // 
            this.txtMinutes.Location = new System.Drawing.Point(669, 213);
            this.txtMinutes.Name = "txtMinutes";
            this.txtMinutes.Size = new System.Drawing.Size(85, 24);
            this.txtMinutes.TabIndex = 70;
            // 
            // txtWaterHourPrice
            // 
            this.txtWaterHourPrice.Location = new System.Drawing.Point(548, 213);
            this.txtWaterHourPrice.Name = "txtWaterHourPrice";
            this.txtWaterHourPrice.Size = new System.Drawing.Size(114, 24);
            this.txtWaterHourPrice.TabIndex = 71;
            // 
            // txtDieselHourPrice
            // 
            this.txtDieselHourPrice.Location = new System.Drawing.Point(444, 213);
            this.txtDieselHourPrice.Name = "txtDieselHourPrice";
            this.txtDieselHourPrice.Size = new System.Drawing.Size(100, 24);
            this.txtDieselHourPrice.TabIndex = 72;
            // 
            // textWaterTotalPrice
            // 
            this.textWaterTotalPrice.Location = new System.Drawing.Point(231, 213);
            this.textWaterTotalPrice.Name = "textWaterTotalPrice";
            this.textWaterTotalPrice.Size = new System.Drawing.Size(204, 24);
            this.textWaterTotalPrice.TabIndex = 73;
            // 
            // SalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 700);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SalesForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فاتورة المبيعات";
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRemainingAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPaidAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDueAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDieselTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWaterTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDieselHourPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWaterHourPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.NumericUpDown numRemainingAmount;
        private System.Windows.Forms.Label lblRemainingAmount;
        private System.Windows.Forms.NumericUpDown numPaidAmount;
        private System.Windows.Forms.Label lblPaidAmount;
        private System.Windows.Forms.NumericUpDown numDueAmount;
        private System.Windows.Forms.Label lblDueAmount;
        private System.Windows.Forms.NumericUpDown numTotalAmount;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.NumericUpDown numDieselTotal;
        private System.Windows.Forms.Label lblDieselTotal;
        private System.Windows.Forms.NumericUpDown numWaterTotal;
        private System.Windows.Forms.Label lblWaterTotal;
        private System.Windows.Forms.NumericUpDown numDieselHourPrice;
        private System.Windows.Forms.Label lblDieselHourPrice;
        private System.Windows.Forms.NumericUpDown numWaterHourPrice;
        private System.Windows.Forms.Label lblWaterHourPrice;
        private System.Windows.Forms.NumericUpDown numMinutes;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.NumericUpDown numHours;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.TextBox txtPeriodId;
        private System.Windows.Forms.TextBox txtSalesCode;
        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.Label lblPeriodId;
        private System.Windows.Forms.Label lblSalesCode;
        private System.Windows.Forms.ComboBox cmbBillType;
        private System.Windows.Forms.Label lblBillType;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn bill_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartenerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartenerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoursUesed;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinutesCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoursAvalible;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinutesAvalible;
        private System.Windows.Forms.Label lblCustName;
        private System.Windows.Forms.TextBox textCustomName;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.TextBox txtMinutes;
        private System.Windows.Forms.TextBox txtWaterHourPrice;
        private System.Windows.Forms.TextBox txtDieselHourPrice;
        private System.Windows.Forms.TextBox textWaterTotalPrice;
    }
}

