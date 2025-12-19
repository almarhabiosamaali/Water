namespace Water
{
    partial class ExpenseForm
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
            this.lblExpenseCode = new System.Windows.Forms.Label();
            this.txtExpenseCode = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblAccountType = new System.Windows.Forms.Label();
            this.cmbAccountType = new System.Windows.Forms.ComboBox();
            this.lblAccountId = new System.Windows.Forms.Label();
            this.txtAccountId = new System.Windows.Forms.TextBox();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblPeriodId = new System.Windows.Forms.Label();
            this.txtPeriodId = new System.Windows.Forms.TextBox();
            this.lblPeriodStartDate = new System.Windows.Forms.Label();
            this.txtPeriodStartDate = new System.Windows.Forms.TextBox();
            this.lblPeriodEndDate = new System.Windows.Forms.Label();
            this.txtPeriodEndDate = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnView = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lblExpenseCode
            // 
            this.lblExpenseCode.AutoSize = true;
            this.lblExpenseCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpenseCode.Location = new System.Drawing.Point(13, 124);
            this.lblExpenseCode.Name = "lblExpenseCode";
            this.lblExpenseCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblExpenseCode.Size = new System.Drawing.Size(70, 20);
            this.lblExpenseCode.TabIndex = 0;
            this.lblExpenseCode.Text = "رقم السند :";
            // 
            // txtExpenseCode
            // 
            this.txtExpenseCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpenseCode.Location = new System.Drawing.Point(118, 121);
            this.txtExpenseCode.Name = "txtExpenseCode";
            this.txtExpenseCode.ReadOnly = true;
            this.txtExpenseCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtExpenseCode.Size = new System.Drawing.Size(263, 26);
            this.txtExpenseCode.TabIndex = 1;
            this.txtExpenseCode.TabStop = false;
            this.txtExpenseCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(438, 172);
            this.lblDate.Name = "lblDate";
            this.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDate.Size = new System.Drawing.Size(51, 20);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "التاريخ:";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(543, 169);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpDate.RightToLeftLayout = true;
            this.dtpDate.Size = new System.Drawing.Size(173, 26);
            this.dtpDate.TabIndex = 4;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(12, 169);
            this.lblType.Name = "lblType";
            this.lblType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblType.Size = new System.Drawing.Size(42, 20);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "النوع:";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "قبض",
            "صرف"});
            this.cmbType.Location = new System.Drawing.Point(117, 166);
            this.cmbType.Name = "cmbType";
            this.cmbType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbType.Size = new System.Drawing.Size(263, 28);
            this.cmbType.TabIndex = 3;
            // 
            // lblAccountType
            // 
            this.lblAccountType.AutoSize = true;
            this.lblAccountType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountType.Location = new System.Drawing.Point(12, 214);
            this.lblAccountType.Name = "lblAccountType";
            this.lblAccountType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAccountType.Size = new System.Drawing.Size(81, 20);
            this.lblAccountType.TabIndex = 6;
            this.lblAccountType.Text = "نوع الحساب:";
            // 
            // cmbAccountType
            // 
            this.cmbAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccountType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAccountType.FormattingEnabled = true;
            this.cmbAccountType.Items.AddRange(new object[] {
            "عميل",
            "شريك",
            "حساب"});
            this.cmbAccountType.Location = new System.Drawing.Point(117, 211);
            this.cmbAccountType.Name = "cmbAccountType";
            this.cmbAccountType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbAccountType.Size = new System.Drawing.Size(263, 28);
            this.cmbAccountType.TabIndex = 5;
            // 
            // lblAccountId
            // 
            this.lblAccountId.AutoSize = true;
            this.lblAccountId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountId.Location = new System.Drawing.Point(12, 258);
            this.lblAccountId.Name = "lblAccountId";
            this.lblAccountId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAccountId.Size = new System.Drawing.Size(80, 20);
            this.lblAccountId.TabIndex = 8;
            this.lblAccountId.Text = "رقم الحساب:";
            // 
            // txtAccountId
            // 
            this.txtAccountId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountId.Location = new System.Drawing.Point(117, 255);
            this.txtAccountId.Name = "txtAccountId";
            this.txtAccountId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAccountId.Size = new System.Drawing.Size(263, 26);
            this.txtAccountId.TabIndex = 6;
            this.txtAccountId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccountId_KeyDown);
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountName.Location = new System.Drawing.Point(438, 258);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAccountName.Size = new System.Drawing.Size(80, 20);
            this.lblAccountName.TabIndex = 10;
            this.lblAccountName.Text = "اسم الحساب:";
            // 
            // txtAccountName
            // 
            this.txtAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountName.Location = new System.Drawing.Point(543, 255);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.ReadOnly = true;
            this.txtAccountName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAccountName.Size = new System.Drawing.Size(263, 26);
            this.txtAccountName.TabIndex = 11;
            this.txtAccountName.TabStop = false;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(9, 315);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAmount.Size = new System.Drawing.Size(45, 20);
            this.lblAmount.TabIndex = 12;
            this.lblAmount.Text = "المبلغ:";
            // 
            // lblPeriodId
            // 
            this.lblPeriodId.AutoSize = true;
            this.lblPeriodId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodId.Location = new System.Drawing.Point(438, 124);
            this.lblPeriodId.Name = "lblPeriodId";
            this.lblPeriodId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPeriodId.Size = new System.Drawing.Size(67, 20);
            this.lblPeriodId.TabIndex = 14;
            this.lblPeriodId.Text = "رقم الفترة:";
            // 
            // txtPeriodId
            // 
            this.txtPeriodId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriodId.Location = new System.Drawing.Point(543, 121);
            this.txtPeriodId.Name = "txtPeriodId";
            this.txtPeriodId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPeriodId.Size = new System.Drawing.Size(74, 26);
            this.txtPeriodId.TabIndex = 2;
            this.txtPeriodId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPeriodId_KeyDown);
            this.txtPeriodId.Leave += new System.EventHandler(this.txtPeriodId_Leave);
            // 
            // lblPeriodStartDate
            // 
            this.lblPeriodStartDate.AutoSize = true;
            this.lblPeriodStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodStartDate.Location = new System.Drawing.Point(681, 121);
            this.lblPeriodStartDate.Name = "lblPeriodStartDate";
            this.lblPeriodStartDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPeriodStartDate.Size = new System.Drawing.Size(35, 20);
            this.lblPeriodStartDate.TabIndex = 26;
            this.lblPeriodStartDate.Text = "من :";
            // 
            // txtPeriodStartDate
            // 
            this.txtPeriodStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriodStartDate.Location = new System.Drawing.Point(734, 121);
            this.txtPeriodStartDate.Name = "txtPeriodStartDate";
            this.txtPeriodStartDate.ReadOnly = true;
            this.txtPeriodStartDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPeriodStartDate.Size = new System.Drawing.Size(120, 26);
            this.txtPeriodStartDate.TabIndex = 27;
            this.txtPeriodStartDate.TabStop = false;
            this.txtPeriodStartDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPeriodEndDate
            // 
            this.lblPeriodEndDate.AutoSize = true;
            this.lblPeriodEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodEndDate.Location = new System.Drawing.Point(860, 121);
            this.lblPeriodEndDate.Name = "lblPeriodEndDate";
            this.lblPeriodEndDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPeriodEndDate.Size = new System.Drawing.Size(37, 20);
            this.lblPeriodEndDate.TabIndex = 28;
            this.lblPeriodEndDate.Text = "الى :";
            // 
            // txtPeriodEndDate
            // 
            this.txtPeriodEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriodEndDate.Location = new System.Drawing.Point(903, 121);
            this.txtPeriodEndDate.Name = "txtPeriodEndDate";
            this.txtPeriodEndDate.ReadOnly = true;
            this.txtPeriodEndDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPeriodEndDate.Size = new System.Drawing.Size(156, 26);
            this.txtPeriodEndDate.TabIndex = 29;
            this.txtPeriodEndDate.TabStop = false;
            this.txtPeriodEndDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(13, 444);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDescription.Size = new System.Drawing.Size(61, 20);
            this.lblDescription.TabIndex = 16;
            this.lblDescription.Text = "ملاحظة :";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(118, 441);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDescription.Size = new System.Drawing.Size(688, 35);
            this.txtDescription.TabIndex = 10;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.Location = new System.Drawing.Point(13, 354);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNotes.Size = new System.Drawing.Size(52, 20);
            this.lblNotes.TabIndex = 18;
            this.lblNotes.Text = "البيـان :";
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(118, 351);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNotes.Size = new System.Drawing.Size(689, 60);
            this.txtNotes.TabIndex = 8;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = global::Water.Properties.Resources.icons8_search_24_8;
            this.btnView.Location = new System.Drawing.Point(375, 35);
            this.btnView.Name = "btnView";
            this.btnView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnView.Size = new System.Drawing.Size(70, 40);
            this.btnView.TabIndex = 20;
            this.btnView.TabStop = false;
            this.toolTip1.SetToolTip(this.btnView, "عرض");
            this.btnView.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::Water.Properties.Resources.icons8_add_24;
            this.btnAdd.Location = new System.Drawing.Point(445, 35);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAdd.Size = new System.Drawing.Size(70, 40);
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
            this.btnEdit.Location = new System.Drawing.Point(514, 35);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnEdit.Size = new System.Drawing.Size(70, 40);
            this.btnEdit.TabIndex = 22;
            this.btnEdit.TabStop = false;
            this.toolTip1.SetToolTip(this.btnEdit, "تعديل");
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Water.Properties.Resources.icons8_delete_24;
            this.btnDelete.Location = new System.Drawing.Point(586, 35);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDelete.Size = new System.Drawing.Size(70, 40);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.TabStop = false;
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.toolTip1.SetToolTip(this.btnDelete, "حذف");
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Water.Properties.Resources.icons8_save_24_9;
            this.btnSave.Location = new System.Drawing.Point(658, 35);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(70, 40);
            this.btnSave.TabIndex = 12;
            this.toolTip1.SetToolTip(this.btnSave, "حفظ");
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(117, 318);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(263, 24);
            this.txtAmount.TabIndex = 7;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(484, 7);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(172, 24);
            this.label1.TabIndex = 30;
            this.label1.Text = "سندات القبض والصرف";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::Water.Properties.Resources.icons8_exit_24;
            this.btnExit.Location = new System.Drawing.Point(728, 35);
            this.btnExit.Name = "btnExit";
            this.btnExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnExit.Size = new System.Drawing.Size(70, 40);
            this.btnExit.TabIndex = 37;
            this.btnExit.TabStop = false;
            this.toolTip1.SetToolTip(this.btnExit, "خروج");
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ExpenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 536);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtPeriodEndDate);
            this.Controls.Add(this.lblPeriodEndDate);
            this.Controls.Add(this.txtPeriodStartDate);
            this.Controls.Add(this.lblPeriodStartDate);
            this.Controls.Add(this.txtPeriodId);
            this.Controls.Add(this.lblPeriodId);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.txtAccountName);
            this.Controls.Add(this.lblAccountName);
            this.Controls.Add(this.txtAccountId);
            this.Controls.Add(this.lblAccountId);
            this.Controls.Add(this.cmbAccountType);
            this.Controls.Add(this.lblAccountType);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtExpenseCode);
            this.Controls.Add(this.lblExpenseCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExpenseForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "السندات ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
     
        private System.Windows.Forms.Label lblExpenseCode;
        private System.Windows.Forms.TextBox txtExpenseCode;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblAccountType;
        private System.Windows.Forms.ComboBox cmbAccountType;
        private System.Windows.Forms.Label lblAccountId;
        private System.Windows.Forms.TextBox txtAccountId;
        private System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblPeriodId;
        private System.Windows.Forms.TextBox txtPeriodId;
        private System.Windows.Forms.Label lblPeriodStartDate;
        private System.Windows.Forms.TextBox txtPeriodStartDate;
        private System.Windows.Forms.Label lblPeriodEndDate;
        private System.Windows.Forms.TextBox txtPeriodEndDate;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ToolTip toolTip1;
        //private AmountTextBox amountTextBox;
    }
}


