namespace Water
{
    partial class PartnerCostForm
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
            this.lblCostId = new System.Windows.Forms.Label();
            this.txtCostId = new System.Windows.Forms.TextBox();
            this.lblDocType = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDownTimeId = new System.Windows.Forms.Label();
            this.cmbDownTimeId = new System.Windows.Forms.ComboBox();
            this.lblDownTimeNote = new System.Windows.Forms.Label();
            this.txtDownTimeNote = new System.Windows.Forms.TextBox();
            this.lblPeriodId = new System.Windows.Forms.Label();
            this.txtPeriodId = new System.Windows.Forms.TextBox();
            this.lblDayesCount = new System.Windows.Forms.Label();
            this.txtDayesCount = new System.Windows.Forms.TextBox();
            this.lblHours = new System.Windows.Forms.Label();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.txtMinutes = new System.Windows.Forms.TextBox();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnView = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvPartners = new System.Windows.Forms.DataGridView();
            this.btnDistributeAmount = new System.Windows.Forms.Button();
            this.cmpDocType = new System.Windows.Forms.ComboBox();
            this.txtPeriodEndDate = new System.Windows.Forms.TextBox();
            this.lblPeriodEndDate = new System.Windows.Forms.Label();
            this.txtPeriodStartDate = new System.Windows.Forms.TextBox();
            this.lblPeriodStartDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartners)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCostId
            // 
            this.lblCostId.AutoSize = true;
            this.lblCostId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostId.Location = new System.Drawing.Point(24, 68);
            this.lblCostId.Name = "lblCostId";
            this.lblCostId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCostId.Size = new System.Drawing.Size(43, 20);
            this.lblCostId.TabIndex = 0;
            this.lblCostId.Text = "رقم  :";
            // 
            // txtCostId
            // 
            this.txtCostId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostId.Location = new System.Drawing.Point(123, 65);
            this.txtCostId.Name = "txtCostId";
            this.txtCostId.ReadOnly = true;
            this.txtCostId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCostId.Size = new System.Drawing.Size(100, 26);
            this.txtCostId.TabIndex = 0;
            this.txtCostId.TabStop = false;
            this.txtCostId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCostId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // lblDocType
            // 
            this.lblDocType.AutoSize = true;
            this.lblDocType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocType.Location = new System.Drawing.Point(344, 62);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDocType.Size = new System.Drawing.Size(77, 20);
            this.lblDocType.TabIndex = 2;
            this.lblDocType.Text = "نوع المستند:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(563, 62);
            this.lblDate.Name = "lblDate";
            this.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDate.Size = new System.Drawing.Size(51, 20);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "التاريخ:";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(620, 59);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpDate.RightToLeftLayout = true;
            this.dtpDate.Size = new System.Drawing.Size(200, 26);
            this.dtpDate.TabIndex = 3;
            // 
            // lblDownTimeId
            // 
            this.lblDownTimeId.AutoSize = true;
            this.lblDownTimeId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownTimeId.Location = new System.Drawing.Point(16, 101);
            this.lblDownTimeId.Name = "lblDownTimeId";
            this.lblDownTimeId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDownTimeId.Size = new System.Drawing.Size(75, 20);
            this.lblDownTimeId.TabIndex = 6;
            this.lblDownTimeId.Text = "رقم التوقف:";
            // 
            // cmbDownTimeId
            // 
            this.cmbDownTimeId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDownTimeId.FormattingEnabled = true;
            this.cmbDownTimeId.Location = new System.Drawing.Point(121, 98);
            this.cmbDownTimeId.Name = "cmbDownTimeId";
            this.cmbDownTimeId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbDownTimeId.Size = new System.Drawing.Size(158, 28);
            this.cmbDownTimeId.TabIndex = 4;
            // 
            // lblDownTimeNote
            // 
            this.lblDownTimeNote.AutoSize = true;
            this.lblDownTimeNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownTimeNote.Location = new System.Drawing.Point(332, 104);
            this.lblDownTimeNote.Name = "lblDownTimeNote";
            this.lblDownTimeNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDownTimeNote.Size = new System.Drawing.Size(77, 20);
            this.lblDownTimeNote.TabIndex = 8;
            this.lblDownTimeNote.Text = "بيان التوقف:";
            // 
            // txtDownTimeNote
            // 
            this.txtDownTimeNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDownTimeNote.Location = new System.Drawing.Point(424, 101);
            this.txtDownTimeNote.Multiline = true;
            this.txtDownTimeNote.Name = "txtDownTimeNote";
            this.txtDownTimeNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDownTimeNote.Size = new System.Drawing.Size(765, 35);
            this.txtDownTimeNote.TabIndex = 0;
            this.txtDownTimeNote.TabStop = false;
            // 
            // lblPeriodId
            // 
            this.lblPeriodId.AutoSize = true;
            this.lblPeriodId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodId.Location = new System.Drawing.Point(834, 62);
            this.lblPeriodId.Name = "lblPeriodId";
            this.lblPeriodId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPeriodId.Size = new System.Drawing.Size(67, 20);
            this.lblPeriodId.TabIndex = 10;
            this.lblPeriodId.Text = "رقم الفترة:";
            // 
            // txtPeriodId
            // 
            this.txtPeriodId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriodId.Location = new System.Drawing.Point(925, 56);
            this.txtPeriodId.Name = "txtPeriodId";
            this.txtPeriodId.ReadOnly = true;
            this.txtPeriodId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPeriodId.Size = new System.Drawing.Size(100, 26);
            this.txtPeriodId.TabIndex = 0;
            this.txtPeriodId.TabStop = false;
            this.txtPeriodId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // lblDayesCount
            // 
            this.lblDayesCount.AutoSize = true;
            this.lblDayesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDayesCount.Location = new System.Drawing.Point(18, 195);
            this.lblDayesCount.Name = "lblDayesCount";
            this.lblDayesCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDayesCount.Size = new System.Drawing.Size(67, 20);
            this.lblDayesCount.TabIndex = 12;
            this.lblDayesCount.Text = "عدد الأيام:";
            // 
            // txtDayesCount
            // 
            this.txtDayesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDayesCount.Location = new System.Drawing.Point(121, 195);
            this.txtDayesCount.Name = "txtDayesCount";
            this.txtDayesCount.ReadOnly = true;
            this.txtDayesCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDayesCount.Size = new System.Drawing.Size(97, 26);
            this.txtDayesCount.TabIndex = 0;
            this.txtDayesCount.TabStop = false;
            this.txtDayesCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHours.Location = new System.Drawing.Point(230, 198);
            this.lblHours.Name = "lblHours";
            this.lblHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblHours.Size = new System.Drawing.Size(86, 20);
            this.lblHours.TabIndex = 14;
            this.lblHours.Text = "عدد الساعات:";
            // 
            // txtHours
            // 
            this.txtHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHours.Location = new System.Drawing.Point(314, 195);
            this.txtHours.Name = "txtHours";
            this.txtHours.ReadOnly = true;
            this.txtHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtHours.Size = new System.Drawing.Size(74, 26);
            this.txtHours.TabIndex = 0;
            this.txtHours.TabStop = false;
            this.txtHours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutes.Location = new System.Drawing.Point(420, 198);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMinutes.Size = new System.Drawing.Size(77, 20);
            this.lblMinutes.TabIndex = 16;
            this.lblMinutes.Text = "عدد الدقائق:";
            // 
            // txtMinutes
            // 
            this.txtMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinutes.Location = new System.Drawing.Point(514, 195);
            this.txtMinutes.Name = "txtMinutes";
            this.txtMinutes.ReadOnly = true;
            this.txtMinutes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMinutes.Size = new System.Drawing.Size(79, 26);
            this.txtMinutes.TabIndex = 0;
            this.txtMinutes.TabStop = false;
            this.txtMinutes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTime.Location = new System.Drawing.Point(16, 152);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblStartTime.Size = new System.Drawing.Size(75, 20);
            this.lblStartTime.TabIndex = 18;
            this.lblStartTime.Text = "وقت البداية:";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "dd/MM/yyyy hh:mm tt";
            this.dtpStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(117, 149);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpStartTime.RightToLeftLayout = true;
            this.dtpStartTime.Size = new System.Drawing.Size(200, 26);
            this.dtpStartTime.TabIndex = 0;
            this.dtpStartTime.TabStop = false;
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndTime.Location = new System.Drawing.Point(331, 155);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblEndTime.Size = new System.Drawing.Size(76, 20);
            this.lblEndTime.TabIndex = 20;
            this.lblEndTime.Text = "وقت النهاية:";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "dd/MM/yyyy hh:mm tt";
            this.dtpEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(424, 152);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpEndTime.RightToLeftLayout = true;
            this.dtpEndTime.Size = new System.Drawing.Size(200, 26);
            this.dtpEndTime.TabIndex = 0;
            this.dtpEndTime.TabStop = false;
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(282, 311);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAmount.Size = new System.Drawing.Size(200, 26);
            this.txtAmount.TabIndex = 0;
            this.txtAmount.TabStop = false;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDecimal_KeyPress);
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(18, 237);
            this.lblNote.Name = "lblNote";
            this.lblNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNote.Size = new System.Drawing.Size(66, 20);
            this.lblNote.TabIndex = 24;
            this.lblNote.Text = "التفاصيل :";
            // 
            // txtNote
            // 
            this.txtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Location = new System.Drawing.Point(117, 237);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNote.Size = new System.Drawing.Size(785, 60);
            this.txtNote.TabIndex = 25;
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(169, 2);
            this.btnView.Name = "btnView";
            this.btnView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnView.Size = new System.Drawing.Size(74, 40);
            this.btnView.TabIndex = 0;
            this.btnView.TabStop = false;
            this.btnView.Text = "عرض";
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(252, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAdd.Size = new System.Drawing.Size(74, 40);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "إضافة";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(335, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnEdit.Size = new System.Drawing.Size(74, 40);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.TabStop = false;
            this.btnEdit.Text = "تعديل";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(419, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDelete.Size = new System.Drawing.Size(74, 40);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(502, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(74, 40);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // dgvPartners
            // 
            this.dgvPartners.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartners.Location = new System.Drawing.Point(111, 345);
            this.dgvPartners.Name = "dgvPartners";
            this.dgvPartners.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvPartners.Size = new System.Drawing.Size(1068, 346);
            this.dgvPartners.TabIndex = 31;
            // 
            // btnDistributeAmount
            // 
            this.btnDistributeAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDistributeAmount.Location = new System.Drawing.Point(113, 304);
            this.btnDistributeAmount.Name = "btnDistributeAmount";
            this.btnDistributeAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDistributeAmount.Size = new System.Drawing.Size(120, 40);
            this.btnDistributeAmount.TabIndex = 6;
            this.btnDistributeAmount.Text = "توزيع المبلغ";
            this.btnDistributeAmount.UseVisualStyleBackColor = true;
            // 
            // cmpDocType
            // 
            this.cmpDocType.FormattingEnabled = true;
            this.cmpDocType.Items.AddRange(new object[] {
            "توقف",
            "قيد يومية"});
            this.cmpDocType.Location = new System.Drawing.Point(425, 61);
            this.cmpDocType.Name = "cmpDocType";
            this.cmpDocType.Size = new System.Drawing.Size(121, 24);
            this.cmpDocType.TabIndex = 2;
            // 
            // txtPeriodEndDate
            // 
            this.txtPeriodEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriodEndDate.Location = new System.Drawing.Point(856, 697);
            this.txtPeriodEndDate.Name = "txtPeriodEndDate";
            this.txtPeriodEndDate.ReadOnly = true;
            this.txtPeriodEndDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPeriodEndDate.Size = new System.Drawing.Size(137, 26);
            this.txtPeriodEndDate.TabIndex = 0;
            this.txtPeriodEndDate.TabStop = false;
            this.txtPeriodEndDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPeriodEndDate
            // 
            this.lblPeriodEndDate.AutoSize = true;
            this.lblPeriodEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodEndDate.Location = new System.Drawing.Point(1002, 699);
            this.lblPeriodEndDate.Name = "lblPeriodEndDate";
            this.lblPeriodEndDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPeriodEndDate.Size = new System.Drawing.Size(37, 20);
            this.lblPeriodEndDate.TabIndex = 90;
            this.lblPeriodEndDate.Text = "الى :";
            // 
            // txtPeriodStartDate
            // 
            this.txtPeriodStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriodStartDate.Location = new System.Drawing.Point(1045, 696);
            this.txtPeriodStartDate.Name = "txtPeriodStartDate";
            this.txtPeriodStartDate.ReadOnly = true;
            this.txtPeriodStartDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPeriodStartDate.Size = new System.Drawing.Size(120, 26);
            this.txtPeriodStartDate.TabIndex = 0;
            this.txtPeriodStartDate.TabStop = false;
            this.txtPeriodStartDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPeriodStartDate
            // 
            this.lblPeriodStartDate.AutoSize = true;
            this.lblPeriodStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodStartDate.Location = new System.Drawing.Point(781, 699);
            this.lblPeriodStartDate.Name = "lblPeriodStartDate";
            this.lblPeriodStartDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPeriodStartDate.Size = new System.Drawing.Size(69, 20);
            this.lblPeriodStartDate.TabIndex = 88;
            this.lblPeriodStartDate.Text = "الفترة من :";
            // 
            // PartnerCostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 727);
            this.Controls.Add(this.txtPeriodEndDate);
            this.Controls.Add(this.lblPeriodEndDate);
            this.Controls.Add(this.txtPeriodStartDate);
            this.Controls.Add(this.lblPeriodStartDate);
            this.Controls.Add(this.cmpDocType);
            this.Controls.Add(this.btnDistributeAmount);
            this.Controls.Add(this.dgvPartners);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.txtMinutes);
            this.Controls.Add(this.lblMinutes);
            this.Controls.Add(this.txtHours);
            this.Controls.Add(this.lblHours);
            this.Controls.Add(this.txtDayesCount);
            this.Controls.Add(this.lblDayesCount);
            this.Controls.Add(this.txtPeriodId);
            this.Controls.Add(this.lblPeriodId);
            this.Controls.Add(this.txtDownTimeNote);
            this.Controls.Add(this.lblDownTimeNote);
            this.Controls.Add(this.cmbDownTimeId);
            this.Controls.Add(this.lblDownTimeId);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblDocType);
            this.Controls.Add(this.txtCostId);
            this.Controls.Add(this.lblCostId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PartnerCostForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "توزيع التكاليف بين الشركاء";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartners)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCostId;
        private System.Windows.Forms.TextBox txtCostId;
        private System.Windows.Forms.Label lblDocType;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDownTimeId;
        private System.Windows.Forms.ComboBox cmbDownTimeId;
        private System.Windows.Forms.Label lblDownTimeNote;
        private System.Windows.Forms.TextBox txtDownTimeNote;
        private System.Windows.Forms.Label lblPeriodId;
        private System.Windows.Forms.TextBox txtPeriodId;
        private System.Windows.Forms.Label lblDayesCount;
        private System.Windows.Forms.TextBox txtDayesCount;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.TextBox txtMinutes;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvPartners;
        private System.Windows.Forms.Button btnDistributeAmount;
        private System.Windows.Forms.ComboBox cmpDocType;
        private System.Windows.Forms.TextBox txtPeriodEndDate;
        private System.Windows.Forms.Label lblPeriodEndDate;
        private System.Windows.Forms.TextBox txtPeriodStartDate;
        private System.Windows.Forms.Label lblPeriodStartDate;
    }
}

