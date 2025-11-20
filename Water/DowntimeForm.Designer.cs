namespace Water
{
    partial class DowntimeForm
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
            this.lblDowntimeCode = new System.Windows.Forms.Label();
            this.txtDowntimeCode = new System.Windows.Forms.TextBox();
            this.lblPeriodId = new System.Windows.Forms.Label();
            this.txtPeriodId = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblHours = new System.Windows.Forms.Label();
            this.numHours = new System.Windows.Forms.NumericUpDown();
            this.lblDayesCount = new System.Windows.Forms.Label();
            this.numDayesCount = new System.Windows.Forms.NumericUpDown();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.numMinutes = new System.Windows.Forms.NumericUpDown();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.lblAmount = new System.Windows.Forms.Label();
            this.numAmount = new System.Windows.Forms.NumericUpDown();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnView = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDayesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDowntimeCode
            // 
            this.lblDowntimeCode.AutoSize = true;
            this.lblDowntimeCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDowntimeCode.Location = new System.Drawing.Point(30, 30);
            this.lblDowntimeCode.Name = "lblDowntimeCode";
            this.lblDowntimeCode.Size = new System.Drawing.Size(100, 20);
            this.lblDowntimeCode.TabIndex = 0;
            this.lblDowntimeCode.Text = "كود التوقف:";
            this.lblDowntimeCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // txtDowntimeCode
            // 
            this.txtDowntimeCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDowntimeCode.Location = new System.Drawing.Point(150, 27);
            this.txtDowntimeCode.Name = "txtDowntimeCode";
            this.txtDowntimeCode.Size = new System.Drawing.Size(300, 26);
            this.txtDowntimeCode.TabIndex = 1;
            this.txtDowntimeCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // lblPeriodId
            // 
            this.lblPeriodId.AutoSize = true;
            this.lblPeriodId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodId.Location = new System.Drawing.Point(30, 70);
            this.lblPeriodId.Name = "lblPeriodId";
            this.lblPeriodId.Size = new System.Drawing.Size(100, 20);
            this.lblPeriodId.TabIndex = 2;
            this.lblPeriodId.Text = "كود الفترة:";
            this.lblPeriodId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // txtPeriodId
            // 
            this.txtPeriodId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriodId.Location = new System.Drawing.Point(150, 67);
            this.txtPeriodId.Name = "txtPeriodId";
            this.txtPeriodId.Size = new System.Drawing.Size(300, 26);
            this.txtPeriodId.TabIndex = 3;
            this.txtPeriodId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(30, 110);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(100, 20);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "التاريخ:";
            this.lblDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(150, 107);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(300, 26);
            this.dtpDate.TabIndex = 5;
            this.dtpDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpDate.RightToLeftLayout = true;
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHours.Location = new System.Drawing.Point(30, 150);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(100, 20);
            this.lblHours.TabIndex = 6;
            this.lblHours.Text = "الساعات:";
            this.lblHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // numHours
            // 
            this.numHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numHours.Location = new System.Drawing.Point(150, 147);
            this.numHours.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numHours.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numHours.Name = "numHours";
            this.numHours.Size = new System.Drawing.Size(300, 26);
            this.numHours.TabIndex = 7;
            this.numHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDayesCount
            // 
            this.lblDayesCount.AutoSize = true;
            this.lblDayesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDayesCount.Location = new System.Drawing.Point(30, 190);
            this.lblDayesCount.Name = "lblDayesCount";
            this.lblDayesCount.Size = new System.Drawing.Size(100, 20);
            this.lblDayesCount.TabIndex = 8;
            this.lblDayesCount.Text = "عدد الأيام:";
            this.lblDayesCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // numDayesCount
            // 
            this.numDayesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDayesCount.Location = new System.Drawing.Point(150, 187);
            this.numDayesCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numDayesCount.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numDayesCount.Name = "numDayesCount";
            this.numDayesCount.Size = new System.Drawing.Size(300, 26);
            this.numDayesCount.TabIndex = 9;
            this.numDayesCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutes.Location = new System.Drawing.Point(30, 230);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(100, 20);
            this.lblMinutes.TabIndex = 10;
            this.lblMinutes.Text = "الدقائق:";
            this.lblMinutes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // numMinutes
            // 
            this.numMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMinutes.Location = new System.Drawing.Point(150, 227);
            this.numMinutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numMinutes.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numMinutes.Name = "numMinutes";
            this.numMinutes.Size = new System.Drawing.Size(300, 26);
            this.numMinutes.TabIndex = 11;
            this.numMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTime.Location = new System.Drawing.Point(30, 270);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(100, 20);
            this.lblStartTime.TabIndex = 12;
            this.lblStartTime.Text = "وقت البداية:";
            this.lblStartTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Location = new System.Drawing.Point(150, 267);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(300, 26);
            this.dtpStartTime.TabIndex = 13;
            this.dtpStartTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpStartTime.RightToLeftLayout = true;
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndTime.Location = new System.Drawing.Point(30, 310);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(100, 20);
            this.lblEndTime.TabIndex = 14;
            this.lblEndTime.Text = "وقت النهاية:";
            this.lblEndTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Location = new System.Drawing.Point(150, 307);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(300, 26);
            this.dtpEndTime.TabIndex = 15;
            this.dtpEndTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpEndTime.RightToLeftLayout = true;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(30, 350);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(100, 20);
            this.lblAmount.TabIndex = 16;
            this.lblAmount.Text = "المبلغ:";
            this.lblAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // numAmount
            // 
            this.numAmount.DecimalPlaces = 2;
            this.numAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAmount.Location = new System.Drawing.Point(150, 347);
            this.numAmount.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numAmount.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numAmount.Name = "numAmount";
            this.numAmount.Size = new System.Drawing.Size(300, 26);
            this.numAmount.TabIndex = 17;
            this.numAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(30, 390);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(100, 20);
            this.lblNote.TabIndex = 18;
            this.lblNote.Text = "ملاحظات:";
            this.lblNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // txtNote
            // 
            this.txtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Location = new System.Drawing.Point(150, 387);
            this.txtNote.MaxLength = 255;
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(300, 60);
            this.txtNote.TabIndex = 19;
            this.txtNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(30, 470);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(85, 40);
            this.btnView.TabIndex = 20;
            this.btnView.Text = "عرض";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(125, 470);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 40);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Text = "إضافة";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(220, 470);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(85, 40);
            this.btnEdit.TabIndex = 22;
            this.btnEdit.Text = "تعديل";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(315, 470);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 40);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(410, 470);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 40);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // DowntimeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 530);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.numAmount);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.numMinutes);
            this.Controls.Add(this.lblMinutes);
            this.Controls.Add(this.numDayesCount);
            this.Controls.Add(this.lblDayesCount);
            this.Controls.Add(this.numHours);
            this.Controls.Add(this.lblHours);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtPeriodId);
            this.Controls.Add(this.lblPeriodId);
            this.Controls.Add(this.txtDowntimeCode);
            this.Controls.Add(this.lblDowntimeCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DowntimeForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إدخال بيانات التوقف";
            ((System.ComponentModel.ISupportInitialize)(this.numHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDayesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDowntimeCode;
        private System.Windows.Forms.TextBox txtDowntimeCode;
        private System.Windows.Forms.Label lblPeriodId;
        private System.Windows.Forms.TextBox txtPeriodId;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.NumericUpDown numHours;
        private System.Windows.Forms.Label lblDayesCount;
        private System.Windows.Forms.NumericUpDown numDayesCount;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.NumericUpDown numMinutes;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.NumericUpDown numAmount;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
    }
}

