namespace Water
{
    partial class PeriodForm
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
            this.lblPeriodCode = new System.Windows.Forms.Label();
            this.txtPeriodCode = new System.Windows.Forms.TextBox();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblBaseDays = new System.Windows.Forms.Label();
            this.numBaseDays = new System.Windows.Forms.NumericUpDown();
            this.lblDowntimeHours = new System.Windows.Forms.Label();
            this.txtDowntimeHours = new System.Windows.Forms.TextBox();
            this.lblExtendedDays = new System.Windows.Forms.Label();
            this.numExtendedDays = new System.Windows.Forms.NumericUpDown();
            this.lblTotalHours = new System.Windows.Forms.Label();
            this.numTotalHours = new System.Windows.Forms.NumericUpDown();
            this.btnView = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numBaseDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExtendedDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalHours)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPeriodCode
            // 
            this.lblPeriodCode.AutoSize = true;
            this.lblPeriodCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodCode.Location = new System.Drawing.Point(30, 30);
            this.lblPeriodCode.Name = "lblPeriodCode";
            this.lblPeriodCode.Size = new System.Drawing.Size(100, 20);
            this.lblPeriodCode.TabIndex = 0;
            this.lblPeriodCode.Text = "كود الفترة:";
            this.lblPeriodCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // txtPeriodCode
            // 
            this.txtPeriodCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriodCode.Location = new System.Drawing.Point(150, 27);
            this.txtPeriodCode.Name = "txtPeriodCode";
            this.txtPeriodCode.Size = new System.Drawing.Size(300, 26);
            this.txtPeriodCode.TabIndex = 1;
            this.txtPeriodCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDate.Location = new System.Drawing.Point(30, 70);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(100, 20);
            this.lblStartDate.TabIndex = 2;
            this.lblStartDate.Text = "تاريخ البداية:";
            this.lblStartDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(150, 67);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(300, 26);
            this.dtpStartDate.TabIndex = 3;
            this.dtpStartDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpStartDate.RightToLeftLayout = true;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.Location = new System.Drawing.Point(30, 110);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(100, 20);
            this.lblEndDate.TabIndex = 4;
            this.lblEndDate.Text = "تاريخ النهاية:";
            this.lblEndDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(150, 107);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(300, 26);
            this.dtpEndDate.TabIndex = 5;
            this.dtpEndDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpEndDate.RightToLeftLayout = true;
            // 
            // lblBaseDays
            // 
            this.lblBaseDays.AutoSize = true;
            this.lblBaseDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaseDays.Location = new System.Drawing.Point(30, 150);
            this.lblBaseDays.Name = "lblBaseDays";
            this.lblBaseDays.Size = new System.Drawing.Size(100, 20);
            this.lblBaseDays.TabIndex = 6;
            this.lblBaseDays.Text = "الأيام الأساسية:";
            this.lblBaseDays.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // numBaseDays
            // 
            this.numBaseDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBaseDays.Location = new System.Drawing.Point(150, 147);
            this.numBaseDays.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numBaseDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numBaseDays.Name = "numBaseDays";
            this.numBaseDays.Size = new System.Drawing.Size(300, 26);
            this.numBaseDays.TabIndex = 7;
            this.numBaseDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDowntimeHours
            // 
            this.lblDowntimeHours.AutoSize = true;
            this.lblDowntimeHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDowntimeHours.Location = new System.Drawing.Point(30, 190);
            this.lblDowntimeHours.Name = "lblDowntimeHours";
            this.lblDowntimeHours.Size = new System.Drawing.Size(100, 20);
            this.lblDowntimeHours.TabIndex = 8;
            this.lblDowntimeHours.Text = "ساعات التوقف:";
            this.lblDowntimeHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // txtDowntimeHours
            // 
            this.txtDowntimeHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDowntimeHours.Location = new System.Drawing.Point(150, 187);
            this.txtDowntimeHours.Name = "txtDowntimeHours";
            this.txtDowntimeHours.Size = new System.Drawing.Size(300, 26);
            this.txtDowntimeHours.TabIndex = 9;
            this.txtDowntimeHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // lblExtendedDays
            // 
            this.lblExtendedDays.AutoSize = true;
            this.lblExtendedDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtendedDays.Location = new System.Drawing.Point(30, 230);
            this.lblExtendedDays.Name = "lblExtendedDays";
            this.lblExtendedDays.Size = new System.Drawing.Size(100, 20);
            this.lblExtendedDays.TabIndex = 10;
            this.lblExtendedDays.Text = "الأيام الممتدة:";
            this.lblExtendedDays.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // numExtendedDays
            // 
            this.numExtendedDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numExtendedDays.Location = new System.Drawing.Point(150, 227);
            this.numExtendedDays.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numExtendedDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numExtendedDays.Name = "numExtendedDays";
            this.numExtendedDays.Size = new System.Drawing.Size(300, 26);
            this.numExtendedDays.TabIndex = 11;
            this.numExtendedDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalHours
            // 
            this.lblTotalHours.AutoSize = true;
            this.lblTotalHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHours.Location = new System.Drawing.Point(30, 270);
            this.lblTotalHours.Name = "lblTotalHours";
            this.lblTotalHours.Size = new System.Drawing.Size(100, 20);
            this.lblTotalHours.TabIndex = 12;
            this.lblTotalHours.Text = "إجمالي الساعات:";
            this.lblTotalHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // numTotalHours
            // 
            this.numTotalHours.DecimalPlaces = 2;
            this.numTotalHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTotalHours.Location = new System.Drawing.Point(150, 267);
            this.numTotalHours.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numTotalHours.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numTotalHours.Name = "numTotalHours";
            this.numTotalHours.Size = new System.Drawing.Size(300, 26);
            this.numTotalHours.TabIndex = 13;
            this.numTotalHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(30, 320);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(85, 40);
            this.btnView.TabIndex = 14;
            this.btnView.Text = "عرض";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(125, 320);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 40);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "إضافة";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(220, 320);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(85, 40);
            this.btnEdit.TabIndex = 16;
            this.btnEdit.Text = "تعديل";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(315, 320);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 40);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(410, 320);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 40);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // PeriodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 380);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.numTotalHours);
            this.Controls.Add(this.lblTotalHours);
            this.Controls.Add(this.numExtendedDays);
            this.Controls.Add(this.lblExtendedDays);
            this.Controls.Add(this.txtDowntimeHours);
            this.Controls.Add(this.lblDowntimeHours);
            this.Controls.Add(this.numBaseDays);
            this.Controls.Add(this.lblBaseDays);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.txtPeriodCode);
            this.Controls.Add(this.lblPeriodCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PeriodForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إدخال بيانات الفترة";
            ((System.ComponentModel.ISupportInitialize)(this.numBaseDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExtendedDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalHours)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPeriodCode;
        private System.Windows.Forms.TextBox txtPeriodCode;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblBaseDays;
        private System.Windows.Forms.NumericUpDown numBaseDays;
        private System.Windows.Forms.Label lblDowntimeHours;
        private System.Windows.Forms.TextBox txtDowntimeHours;
        private System.Windows.Forms.Label lblExtendedDays;
        private System.Windows.Forms.NumericUpDown numExtendedDays;
        private System.Windows.Forms.Label lblTotalHours;
        private System.Windows.Forms.NumericUpDown numTotalHours;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
    }
}

