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
            this.lblSalesCode = new System.Windows.Forms.Label();
            this.txtSalesCode = new System.Windows.Forms.TextBox();
            this.lblPeriodId = new System.Windows.Forms.Label();
            this.txtPeriodId = new System.Windows.Forms.TextBox();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.lblHours = new System.Windows.Forms.Label();
            this.numHours = new System.Windows.Forms.NumericUpDown();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.numMinutes = new System.Windows.Forms.NumericUpDown();
            this.lblWaterHourPrice = new System.Windows.Forms.Label();
            this.numWaterHourPrice = new System.Windows.Forms.NumericUpDown();
            this.lblDieselHourPrice = new System.Windows.Forms.Label();
            this.numDieselHourPrice = new System.Windows.Forms.NumericUpDown();
            this.lblWaterTotal = new System.Windows.Forms.Label();
            this.numWaterTotal = new System.Windows.Forms.NumericUpDown();
            this.lblDieselTotal = new System.Windows.Forms.Label();
            this.numDieselTotal = new System.Windows.Forms.NumericUpDown();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.numTotalAmount = new System.Windows.Forms.NumericUpDown();
            this.lblDueAmount = new System.Windows.Forms.Label();
            this.numDueAmount = new System.Windows.Forms.NumericUpDown();
            this.lblPaidAmount = new System.Windows.Forms.Label();
            this.numPaidAmount = new System.Windows.Forms.NumericUpDown();
            this.lblRemainingAmount = new System.Windows.Forms.Label();
            this.numRemainingAmount = new System.Windows.Forms.NumericUpDown();
            this.btnView = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWaterHourPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDieselHourPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWaterTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDieselTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDueAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPaidAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRemainingAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSalesCode
            // 
            this.lblSalesCode.AutoSize = true;
            this.lblSalesCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesCode.Location = new System.Drawing.Point(26, 30);
            this.lblSalesCode.Name = "lblSalesCode";
            this.lblSalesCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSalesCode.Size = new System.Drawing.Size(78, 20);
            this.lblSalesCode.TabIndex = 0;
            this.lblSalesCode.Text = "رقم الفاتورة:";
            // 
            // txtSalesCode
            // 
            this.txtSalesCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesCode.Location = new System.Drawing.Point(131, 27);
            this.txtSalesCode.Name = "txtSalesCode";
            this.txtSalesCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSalesCode.Size = new System.Drawing.Size(263, 26);
            this.txtSalesCode.TabIndex = 1;
            this.txtSalesCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPeriodId
            // 
            this.lblPeriodId.AutoSize = true;
            this.lblPeriodId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodId.Location = new System.Drawing.Point(26, 70);
            this.lblPeriodId.Name = "lblPeriodId";
            this.lblPeriodId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPeriodId.Size = new System.Drawing.Size(68, 20);
            this.lblPeriodId.TabIndex = 2;
            this.lblPeriodId.Text = "كود الفترة:";
            // 
            // txtPeriodId
            // 
            this.txtPeriodId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriodId.Location = new System.Drawing.Point(131, 67);
            this.txtPeriodId.Name = "txtPeriodId";
            this.txtPeriodId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPeriodId.Size = new System.Drawing.Size(263, 26);
            this.txtPeriodId.TabIndex = 3;
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerId.Location = new System.Drawing.Point(26, 110);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCustomerId.Size = new System.Drawing.Size(74, 20);
            this.lblCustomerId.TabIndex = 4;
            this.lblCustomerId.Text = "كود العميل:";
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerId.Location = new System.Drawing.Point(131, 107);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustomerId.Size = new System.Drawing.Size(263, 26);
            this.txtCustomerId.TabIndex = 5;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTime.Location = new System.Drawing.Point(26, 150);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblStartTime.Size = new System.Drawing.Size(75, 20);
            this.lblStartTime.TabIndex = 6;
            this.lblStartTime.Text = "وقت البداية:";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(131, 147);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpStartTime.RightToLeftLayout = true;
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(263, 26);
            this.dtpStartTime.TabIndex = 7;
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndTime.Location = new System.Drawing.Point(26, 190);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblEndTime.Size = new System.Drawing.Size(76, 20);
            this.lblEndTime.TabIndex = 8;
            this.lblEndTime.Text = "وقت النهاية:";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(131, 187);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpEndTime.RightToLeftLayout = true;
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(263, 26);
            this.dtpEndTime.TabIndex = 9;
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHours.Location = new System.Drawing.Point(26, 230);
            this.lblHours.Name = "lblHours";
            this.lblHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblHours.Size = new System.Drawing.Size(60, 20);
            this.lblHours.TabIndex = 10;
            this.lblHours.Text = "الساعات:";
            // 
            // numHours
            // 
            this.numHours.DecimalPlaces = 2;
            this.numHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numHours.Location = new System.Drawing.Point(131, 227);
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
            this.numHours.Size = new System.Drawing.Size(262, 26);
            this.numHours.TabIndex = 11;
            this.numHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutes.Location = new System.Drawing.Point(26, 270);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMinutes.Size = new System.Drawing.Size(51, 20);
            this.lblMinutes.TabIndex = 12;
            this.lblMinutes.Text = "الدقائق:";
            // 
            // numMinutes
            // 
            this.numMinutes.DecimalPlaces = 2;
            this.numMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMinutes.Location = new System.Drawing.Point(131, 267);
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
            this.numMinutes.Size = new System.Drawing.Size(262, 26);
            this.numMinutes.TabIndex = 13;
            this.numMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblWaterHourPrice
            // 
            this.lblWaterHourPrice.AutoSize = true;
            this.lblWaterHourPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaterHourPrice.Location = new System.Drawing.Point(26, 310);
            this.lblWaterHourPrice.Name = "lblWaterHourPrice";
            this.lblWaterHourPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblWaterHourPrice.Size = new System.Drawing.Size(102, 20);
            this.lblWaterHourPrice.TabIndex = 14;
            this.lblWaterHourPrice.Text = "سعر ساعة الماء:";
            // 
            // numWaterHourPrice
            // 
            this.numWaterHourPrice.DecimalPlaces = 2;
            this.numWaterHourPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numWaterHourPrice.Location = new System.Drawing.Point(131, 307);
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
            this.numWaterHourPrice.Size = new System.Drawing.Size(262, 26);
            this.numWaterHourPrice.TabIndex = 15;
            this.numWaterHourPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDieselHourPrice
            // 
            this.lblDieselHourPrice.AutoSize = true;
            this.lblDieselHourPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDieselHourPrice.Location = new System.Drawing.Point(26, 350);
            this.lblDieselHourPrice.Name = "lblDieselHourPrice";
            this.lblDieselHourPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDieselHourPrice.Size = new System.Drawing.Size(111, 20);
            this.lblDieselHourPrice.TabIndex = 16;
            this.lblDieselHourPrice.Text = "سعر ساعة الديزل:";
            // 
            // numDieselHourPrice
            // 
            this.numDieselHourPrice.DecimalPlaces = 2;
            this.numDieselHourPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDieselHourPrice.Location = new System.Drawing.Point(131, 347);
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
            this.numDieselHourPrice.Size = new System.Drawing.Size(262, 26);
            this.numDieselHourPrice.TabIndex = 17;
            this.numDieselHourPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblWaterTotal
            // 
            this.lblWaterTotal.AutoSize = true;
            this.lblWaterTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaterTotal.Location = new System.Drawing.Point(26, 390);
            this.lblWaterTotal.Name = "lblWaterTotal";
            this.lblWaterTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblWaterTotal.Size = new System.Drawing.Size(83, 20);
            this.lblWaterTotal.TabIndex = 18;
            this.lblWaterTotal.Text = "إجمالي الماء:";
            // 
            // numWaterTotal
            // 
            this.numWaterTotal.DecimalPlaces = 2;
            this.numWaterTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numWaterTotal.Location = new System.Drawing.Point(131, 387);
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
            this.numWaterTotal.Size = new System.Drawing.Size(262, 26);
            this.numWaterTotal.TabIndex = 19;
            this.numWaterTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDieselTotal
            // 
            this.lblDieselTotal.AutoSize = true;
            this.lblDieselTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDieselTotal.Location = new System.Drawing.Point(26, 430);
            this.lblDieselTotal.Name = "lblDieselTotal";
            this.lblDieselTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDieselTotal.Size = new System.Drawing.Size(92, 20);
            this.lblDieselTotal.TabIndex = 20;
            this.lblDieselTotal.Text = "إجمالي الديزل:";
            // 
            // numDieselTotal
            // 
            this.numDieselTotal.DecimalPlaces = 2;
            this.numDieselTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDieselTotal.Location = new System.Drawing.Point(131, 427);
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
            this.numDieselTotal.Size = new System.Drawing.Size(262, 26);
            this.numDieselTotal.TabIndex = 21;
            this.numDieselTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(26, 470);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalAmount.Size = new System.Drawing.Size(97, 20);
            this.lblTotalAmount.TabIndex = 22;
            this.lblTotalAmount.Text = "المبلغ الإجمالي:";
            // 
            // numTotalAmount
            // 
            this.numTotalAmount.DecimalPlaces = 2;
            this.numTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTotalAmount.Location = new System.Drawing.Point(131, 467);
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
            this.numTotalAmount.TabIndex = 23;
            this.numTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDueAmount
            // 
            this.lblDueAmount.AutoSize = true;
            this.lblDueAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueAmount.Location = new System.Drawing.Point(26, 510);
            this.lblDueAmount.Name = "lblDueAmount";
            this.lblDueAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDueAmount.Size = new System.Drawing.Size(97, 20);
            this.lblDueAmount.TabIndex = 24;
            this.lblDueAmount.Text = "المبلغ المستحق:";
            // 
            // numDueAmount
            // 
            this.numDueAmount.DecimalPlaces = 2;
            this.numDueAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDueAmount.Location = new System.Drawing.Point(131, 507);
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
            this.numDueAmount.TabIndex = 25;
            this.numDueAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPaidAmount
            // 
            this.lblPaidAmount.AutoSize = true;
            this.lblPaidAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaidAmount.Location = new System.Drawing.Point(26, 550);
            this.lblPaidAmount.Name = "lblPaidAmount";
            this.lblPaidAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPaidAmount.Size = new System.Drawing.Size(92, 20);
            this.lblPaidAmount.TabIndex = 26;
            this.lblPaidAmount.Text = "المبلغ المدفوع:";
            // 
            // numPaidAmount
            // 
            this.numPaidAmount.DecimalPlaces = 2;
            this.numPaidAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPaidAmount.Location = new System.Drawing.Point(131, 547);
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
            this.numPaidAmount.TabIndex = 27;
            this.numPaidAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRemainingAmount
            // 
            this.lblRemainingAmount.AutoSize = true;
            this.lblRemainingAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainingAmount.Location = new System.Drawing.Point(26, 590);
            this.lblRemainingAmount.Name = "lblRemainingAmount";
            this.lblRemainingAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblRemainingAmount.Size = new System.Drawing.Size(87, 20);
            this.lblRemainingAmount.TabIndex = 28;
            this.lblRemainingAmount.Text = "المبلغ المتبقي:";
            // 
            // numRemainingAmount
            // 
            this.numRemainingAmount.DecimalPlaces = 2;
            this.numRemainingAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRemainingAmount.Location = new System.Drawing.Point(131, 587);
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
            this.numRemainingAmount.TabIndex = 29;
            this.numRemainingAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(26, 640);
            this.btnView.Name = "btnView";
            this.btnView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnView.Size = new System.Drawing.Size(74, 40);
            this.btnView.TabIndex = 30;
            this.btnView.Text = "عرض";
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(109, 640);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAdd.Size = new System.Drawing.Size(74, 40);
            this.btnAdd.TabIndex = 31;
            this.btnAdd.Text = "إضافة";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(192, 640);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnEdit.Size = new System.Drawing.Size(74, 40);
            this.btnEdit.TabIndex = 32;
            this.btnEdit.Text = "تعديل";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(276, 640);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDelete.Size = new System.Drawing.Size(74, 40);
            this.btnDelete.TabIndex = 33;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(359, 640);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(74, 40);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // SalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 700);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.numRemainingAmount);
            this.Controls.Add(this.lblRemainingAmount);
            this.Controls.Add(this.numPaidAmount);
            this.Controls.Add(this.lblPaidAmount);
            this.Controls.Add(this.numDueAmount);
            this.Controls.Add(this.lblDueAmount);
            this.Controls.Add(this.numTotalAmount);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.numDieselTotal);
            this.Controls.Add(this.lblDieselTotal);
            this.Controls.Add(this.numWaterTotal);
            this.Controls.Add(this.lblWaterTotal);
            this.Controls.Add(this.numDieselHourPrice);
            this.Controls.Add(this.lblDieselHourPrice);
            this.Controls.Add(this.numWaterHourPrice);
            this.Controls.Add(this.lblWaterHourPrice);
            this.Controls.Add(this.numMinutes);
            this.Controls.Add(this.lblMinutes);
            this.Controls.Add(this.numHours);
            this.Controls.Add(this.lblHours);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.txtCustomerId);
            this.Controls.Add(this.lblCustomerId);
            this.Controls.Add(this.txtPeriodId);
            this.Controls.Add(this.lblPeriodId);
            this.Controls.Add(this.txtSalesCode);
            this.Controls.Add(this.lblSalesCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SalesForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فاتورة المبيعات";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWaterHourPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDieselHourPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWaterTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDieselTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDueAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPaidAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRemainingAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSalesCode;
        private System.Windows.Forms.TextBox txtSalesCode;
        private System.Windows.Forms.Label lblPeriodId;
        private System.Windows.Forms.TextBox txtPeriodId;
        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.NumericUpDown numHours;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.NumericUpDown numMinutes;
        private System.Windows.Forms.Label lblWaterHourPrice;
        private System.Windows.Forms.NumericUpDown numWaterHourPrice;
        private System.Windows.Forms.Label lblDieselHourPrice;
        private System.Windows.Forms.NumericUpDown numDieselHourPrice;
        private System.Windows.Forms.Label lblWaterTotal;
        private System.Windows.Forms.NumericUpDown numWaterTotal;
        private System.Windows.Forms.Label lblDieselTotal;
        private System.Windows.Forms.NumericUpDown numDieselTotal;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.NumericUpDown numTotalAmount;
        private System.Windows.Forms.Label lblDueAmount;
        private System.Windows.Forms.NumericUpDown numDueAmount;
        private System.Windows.Forms.Label lblPaidAmount;
        private System.Windows.Forms.NumericUpDown numPaidAmount;
        private System.Windows.Forms.Label lblRemainingAmount;
        private System.Windows.Forms.NumericUpDown numRemainingAmount;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
    }
}

