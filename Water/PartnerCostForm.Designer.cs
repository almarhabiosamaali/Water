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
            this.txtDocType = new System.Windows.Forms.TextBox();
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
            this.lblAmount = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartners)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCostId
            // 
            this.lblCostId.AutoSize = true;
            this.lblCostId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostId.Location = new System.Drawing.Point(26, 24);
            this.lblCostId.Name = "lblCostId";
            this.lblCostId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCostId.Size = new System.Drawing.Size(43, 20);
            this.lblCostId.TabIndex = 0;
            this.lblCostId.Text = "رقم  :";
            // 
            // txtCostId
            // 
            this.txtCostId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostId.Location = new System.Drawing.Point(122, 21);
            this.txtCostId.Name = "txtCostId";
            this.txtCostId.ReadOnly = true;
            this.txtCostId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCostId.Size = new System.Drawing.Size(100, 26);
            this.txtCostId.TabIndex = 1;
            this.txtCostId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCostId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // lblDocType
            // 
            this.lblDocType.AutoSize = true;
            this.lblDocType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocType.Location = new System.Drawing.Point(228, 24);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDocType.Size = new System.Drawing.Size(77, 20);
            this.lblDocType.TabIndex = 2;
            this.lblDocType.Text = "نوع المستند:";
            // 
            // txtDocType
            // 
            this.txtDocType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocType.Location = new System.Drawing.Point(324, 21);
            this.txtDocType.Name = "txtDocType";
            this.txtDocType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDocType.Size = new System.Drawing.Size(100, 26);
            this.txtDocType.TabIndex = 3;
            this.txtDocType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(430, 24);
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
            this.dtpDate.Location = new System.Drawing.Point(487, 21);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpDate.RightToLeftLayout = true;
            this.dtpDate.Size = new System.Drawing.Size(200, 26);
            this.dtpDate.TabIndex = 5;
            // 
            // lblDownTimeId
            // 
            this.lblDownTimeId.AutoSize = true;
            this.lblDownTimeId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownTimeId.Location = new System.Drawing.Point(693, 24);
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
            this.cmbDownTimeId.Location = new System.Drawing.Point(794, 21);
            this.cmbDownTimeId.Name = "cmbDownTimeId";
            this.cmbDownTimeId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbDownTimeId.Size = new System.Drawing.Size(200, 28);
            this.cmbDownTimeId.TabIndex = 7;
            // 
            // lblDownTimeNote
            // 
            this.lblDownTimeNote.AutoSize = true;
            this.lblDownTimeNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownTimeNote.Location = new System.Drawing.Point(26, 56);
            this.lblDownTimeNote.Name = "lblDownTimeNote";
            this.lblDownTimeNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDownTimeNote.Size = new System.Drawing.Size(98, 20);
            this.lblDownTimeNote.TabIndex = 8;
            this.lblDownTimeNote.Text = "ملاحظة التوقف:";
            // 
            // txtDownTimeNote
            // 
            this.txtDownTimeNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDownTimeNote.Location = new System.Drawing.Point(152, 53);
            this.txtDownTimeNote.Name = "txtDownTimeNote";
            this.txtDownTimeNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDownTimeNote.Size = new System.Drawing.Size(842, 26);
            this.txtDownTimeNote.TabIndex = 9;
            // 
            // lblPeriodId
            // 
            this.lblPeriodId.AutoSize = true;
            this.lblPeriodId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodId.Location = new System.Drawing.Point(26, 88);
            this.lblPeriodId.Name = "lblPeriodId";
            this.lblPeriodId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPeriodId.Size = new System.Drawing.Size(67, 20);
            this.lblPeriodId.TabIndex = 10;
            this.lblPeriodId.Text = "رقم الفترة:";
            // 
            // txtPeriodId
            // 
            this.txtPeriodId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriodId.Location = new System.Drawing.Point(107, 85);
            this.txtPeriodId.Name = "txtPeriodId";
            this.txtPeriodId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPeriodId.Size = new System.Drawing.Size(100, 26);
            this.txtPeriodId.TabIndex = 11;
            this.txtPeriodId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // lblDayesCount
            // 
            this.lblDayesCount.AutoSize = true;
            this.lblDayesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDayesCount.Location = new System.Drawing.Point(213, 88);
            this.lblDayesCount.Name = "lblDayesCount";
            this.lblDayesCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDayesCount.Size = new System.Drawing.Size(67, 20);
            this.lblDayesCount.TabIndex = 12;
            this.lblDayesCount.Text = "عدد الأيام:";
            // 
            // txtDayesCount
            // 
            this.txtDayesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDayesCount.Location = new System.Drawing.Point(299, 85);
            this.txtDayesCount.Name = "txtDayesCount";
            this.txtDayesCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDayesCount.Size = new System.Drawing.Size(97, 26);
            this.txtDayesCount.TabIndex = 13;
            this.txtDayesCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHours.Location = new System.Drawing.Point(405, 88);
            this.lblHours.Name = "lblHours";
            this.lblHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblHours.Size = new System.Drawing.Size(86, 20);
            this.lblHours.TabIndex = 14;
            this.lblHours.Text = "عدد الساعات:";
            // 
            // txtHours
            // 
            this.txtHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHours.Location = new System.Drawing.Point(489, 85);
            this.txtHours.Name = "txtHours";
            this.txtHours.ReadOnly = true;
            this.txtHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtHours.Size = new System.Drawing.Size(74, 26);
            this.txtHours.TabIndex = 15;
            this.txtHours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutes.Location = new System.Drawing.Point(595, 88);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMinutes.Size = new System.Drawing.Size(77, 20);
            this.lblMinutes.TabIndex = 16;
            this.lblMinutes.Text = "عدد الدقائق:";
            // 
            // txtMinutes
            // 
            this.txtMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinutes.Location = new System.Drawing.Point(689, 85);
            this.txtMinutes.Name = "txtMinutes";
            this.txtMinutes.ReadOnly = true;
            this.txtMinutes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMinutes.Size = new System.Drawing.Size(79, 26);
            this.txtMinutes.TabIndex = 17;
            this.txtMinutes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTime.Location = new System.Drawing.Point(795, 88);
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
            this.dtpStartTime.Location = new System.Drawing.Point(896, 85);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpStartTime.RightToLeftLayout = true;
            this.dtpStartTime.Size = new System.Drawing.Size(200, 26);
            this.dtpStartTime.TabIndex = 19;
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndTime.Location = new System.Drawing.Point(26, 120);
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
            this.dtpEndTime.Location = new System.Drawing.Point(122, 117);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpEndTime.RightToLeftLayout = true;
            this.dtpEndTime.Size = new System.Drawing.Size(200, 26);
            this.dtpEndTime.TabIndex = 21;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(328, 120);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAmount.Size = new System.Drawing.Size(45, 20);
            this.lblAmount.TabIndex = 22;
            this.lblAmount.Text = "المبلغ:";
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(394, 117);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAmount.Size = new System.Drawing.Size(200, 26);
            this.txtAmount.TabIndex = 23;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDecimal_KeyPress);
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(600, 120);
            this.lblNote.Name = "lblNote";
            this.lblNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNote.Size = new System.Drawing.Size(66, 20);
            this.lblNote.TabIndex = 24;
            this.lblNote.Text = "ملاحظات:";
            // 
            // txtNote
            // 
            this.txtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Location = new System.Drawing.Point(672, 117);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNote.Size = new System.Drawing.Size(322, 60);
            this.txtNote.TabIndex = 25;
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(239, 200);
            this.btnView.Name = "btnView";
            this.btnView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnView.Size = new System.Drawing.Size(74, 40);
            this.btnView.TabIndex = 26;
            this.btnView.Text = "عرض";
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(322, 200);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAdd.Size = new System.Drawing.Size(74, 40);
            this.btnAdd.TabIndex = 27;
            this.btnAdd.Text = "إضافة";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(405, 200);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnEdit.Size = new System.Drawing.Size(74, 40);
            this.btnEdit.TabIndex = 28;
            this.btnEdit.Text = "تعديل";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(489, 200);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDelete.Size = new System.Drawing.Size(74, 40);
            this.btnDelete.TabIndex = 29;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(572, 200);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(74, 40);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // dgvPartners
            // 
            this.dgvPartners.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartners.Location = new System.Drawing.Point(26, 260);
            this.dgvPartners.Name = "dgvPartners";
            this.dgvPartners.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvPartners.Size = new System.Drawing.Size(968, 300);
            this.dgvPartners.TabIndex = 31;
            // 
            // btnDistributeAmount
            // 
            this.btnDistributeAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDistributeAmount.Location = new System.Drawing.Point(26, 200);
            this.btnDistributeAmount.Name = "btnDistributeAmount";
            this.btnDistributeAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDistributeAmount.Size = new System.Drawing.Size(120, 40);
            this.btnDistributeAmount.TabIndex = 33;
            this.btnDistributeAmount.Text = "توزيع المبلغ";
            this.btnDistributeAmount.UseVisualStyleBackColor = true;
            // 
            // PartnerCostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 601);
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
            this.Controls.Add(this.lblAmount);
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
            this.Controls.Add(this.txtDocType);
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
        private System.Windows.Forms.TextBox txtDocType;
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
        private System.Windows.Forms.Label lblAmount;
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
    }
}

