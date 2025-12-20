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
            this.components = new System.ComponentModel.Container();
            this.lblPeriodCode = new System.Windows.Forms.Label();
            this.txtPeriodCode = new System.Windows.Forms.TextBox();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblBaseDays = new System.Windows.Forms.Label();
            this.lblDowntimeHours = new System.Windows.Forms.Label();
            this.txtDowntimeHours = new System.Windows.Forms.TextBox();
            this.lblExtendedDays = new System.Windows.Forms.Label();
            this.lblTotalHours = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtBaseDays = new System.Windows.Forms.TextBox();
            this.txtDownDays = new System.Windows.Forms.TextBox();
            this.txtTotalHours = new System.Windows.Forms.TextBox();
            this.txtWorkingHours = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPeriodCode
            // 
            this.lblPeriodCode.AutoSize = true;
            this.lblPeriodCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodCode.Location = new System.Drawing.Point(32, 109);
            this.lblPeriodCode.Name = "lblPeriodCode";
            this.lblPeriodCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPeriodCode.Size = new System.Drawing.Size(67, 20);
            this.lblPeriodCode.TabIndex = 0;
            this.lblPeriodCode.Text = "رقم الفترة:";
            // 
            // txtPeriodCode
            // 
            this.txtPeriodCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeriodCode.Location = new System.Drawing.Point(137, 106);
            this.txtPeriodCode.Name = "txtPeriodCode";
            this.txtPeriodCode.ReadOnly = true;
            this.txtPeriodCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPeriodCode.Size = new System.Drawing.Size(263, 26);
            this.txtPeriodCode.TabIndex = 1;
            this.txtPeriodCode.TabStop = false;
            this.txtPeriodCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDate.Location = new System.Drawing.Point(32, 149);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblStartDate.Size = new System.Drawing.Size(80, 20);
            this.lblStartDate.TabIndex = 2;
            this.lblStartDate.Text = "تاريخ البداية:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(137, 146);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpStartDate.RightToLeftLayout = true;
            this.dtpStartDate.Size = new System.Drawing.Size(263, 26);
            this.dtpStartDate.TabIndex = 3;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.Location = new System.Drawing.Point(418, 148);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblEndDate.Size = new System.Drawing.Size(81, 20);
            this.lblEndDate.TabIndex = 4;
            this.lblEndDate.Text = "تاريخ النهاية:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(523, 145);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpEndDate.RightToLeftLayout = true;
            this.dtpEndDate.Size = new System.Drawing.Size(263, 26);
            this.dtpEndDate.TabIndex = 5;
            // 
            // lblBaseDays
            // 
            this.lblBaseDays.AutoSize = true;
            this.lblBaseDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaseDays.Location = new System.Drawing.Point(28, 199);
            this.lblBaseDays.Name = "lblBaseDays";
            this.lblBaseDays.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblBaseDays.Size = new System.Drawing.Size(91, 20);
            this.lblBaseDays.TabIndex = 6;
            this.lblBaseDays.Text = "الأيام الأساسية:";
            // 
            // lblDowntimeHours
            // 
            this.lblDowntimeHours.AutoSize = true;
            this.lblDowntimeHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDowntimeHours.Location = new System.Drawing.Point(27, 243);
            this.lblDowntimeHours.Name = "lblDowntimeHours";
            this.lblDowntimeHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDowntimeHours.Size = new System.Drawing.Size(94, 20);
            this.lblDowntimeHours.TabIndex = 8;
            this.lblDowntimeHours.Text = "ساعات التوقف:";
            // 
            // txtDowntimeHours
            // 
            this.txtDowntimeHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDowntimeHours.Location = new System.Drawing.Point(132, 240);
            this.txtDowntimeHours.Name = "txtDowntimeHours";
            this.txtDowntimeHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDowntimeHours.Size = new System.Drawing.Size(263, 26);
            this.txtDowntimeHours.TabIndex = 9;
            this.txtDowntimeHours.TabStop = false;
            this.txtDowntimeHours.Text = "0";
            // 
            // lblExtendedDays
            // 
            this.lblExtendedDays.AutoSize = true;
            this.lblExtendedDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtendedDays.Location = new System.Drawing.Point(27, 284);
            this.lblExtendedDays.Name = "lblExtendedDays";
            this.lblExtendedDays.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblExtendedDays.Size = new System.Drawing.Size(69, 20);
            this.lblExtendedDays.TabIndex = 10;
            this.lblExtendedDays.Text = "أيام التوقف";
            // 
            // lblTotalHours
            // 
            this.lblTotalHours.AutoSize = true;
            this.lblTotalHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHours.Location = new System.Drawing.Point(418, 196);
            this.lblTotalHours.Name = "lblTotalHours";
            this.lblTotalHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalHours.Size = new System.Drawing.Size(103, 20);
            this.lblTotalHours.TabIndex = 12;
            this.lblTotalHours.Text = "إجمالي الساعات:";
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = global::Water.Properties.Resources.icons8_search_24_8;
            this.btnView.Location = new System.Drawing.Point(244, 51);
            this.btnView.Name = "btnView";
            this.btnView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnView.Size = new System.Drawing.Size(70, 40);
            this.btnView.TabIndex = 14;
            this.btnView.TabStop = false;
            this.toolTip1.SetToolTip(this.btnView, "عرض");
            this.btnView.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::Water.Properties.Resources.icons8_add_24;
            this.btnAdd.Location = new System.Drawing.Point(320, 51);
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
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = global::Water.Properties.Resources.icons8_edit_24_5;
            this.btnEdit.Location = new System.Drawing.Point(396, 51);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnEdit.Size = new System.Drawing.Size(70, 40);
            this.btnEdit.TabIndex = 16;
            this.btnEdit.TabStop = false;
            this.toolTip1.SetToolTip(this.btnEdit, "تعديل");
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Water.Properties.Resources.icons8_delete_24;
            this.btnDelete.Location = new System.Drawing.Point(472, 51);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDelete.Size = new System.Drawing.Size(70, 40);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.TabStop = false;
            this.toolTip1.SetToolTip(this.btnDelete, "حذف");
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Water.Properties.Resources.icons8_save_24_9;
            this.btnSave.Location = new System.Drawing.Point(548, 51);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(70, 40);
            this.btnSave.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnSave, "حفظ");
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // txtBaseDays
            // 
            this.txtBaseDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBaseDays.Location = new System.Drawing.Point(133, 193);
            this.txtBaseDays.Name = "txtBaseDays";
            this.txtBaseDays.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBaseDays.Size = new System.Drawing.Size(262, 26);
            this.txtBaseDays.TabIndex = 7;
            this.txtBaseDays.TabStop = false;
            this.txtBaseDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDownDays
            // 
            this.txtDownDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDownDays.Location = new System.Drawing.Point(132, 281);
            this.txtDownDays.Name = "txtDownDays";
            this.txtDownDays.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDownDays.Size = new System.Drawing.Size(262, 26);
            this.txtDownDays.TabIndex = 11;
            this.txtDownDays.TabStop = false;
            this.txtDownDays.Text = "0";
            this.txtDownDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalHours
            // 
            this.txtTotalHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalHours.Location = new System.Drawing.Point(523, 193);
            this.txtTotalHours.Name = "txtTotalHours";
            this.txtTotalHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalHours.Size = new System.Drawing.Size(262, 26);
            this.txtTotalHours.TabIndex = 13;
            this.txtTotalHours.TabStop = false;
            this.txtTotalHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtWorkingHours
            // 
            this.txtWorkingHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWorkingHours.Location = new System.Drawing.Point(563, 281);
            this.txtWorkingHours.Name = "txtWorkingHours";
            this.txtWorkingHours.ReadOnly = true;
            this.txtWorkingHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtWorkingHours.Size = new System.Drawing.Size(223, 26);
            this.txtWorkingHours.TabIndex = 14;
            this.txtWorkingHours.TabStop = false;
            this.txtWorkingHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(419, 284);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "ساعات العمل الفعلية:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(405, 9);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 23;
            this.label1.Text = "بيانات الفترات";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::Water.Properties.Resources.icons8_exit_24;
            this.btnExit.Location = new System.Drawing.Point(624, 51);
            this.btnExit.Name = "btnExit";
            this.btnExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnExit.Size = new System.Drawing.Size(70, 40);
            this.btnExit.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btnExit, "خروج");
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // PeriodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 377);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtWorkingHours);
            this.Controls.Add(this.txtTotalHours);
            this.Controls.Add(this.txtDownDays);
            this.Controls.Add(this.txtBaseDays);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.lblTotalHours);
            this.Controls.Add(this.lblExtendedDays);
            this.Controls.Add(this.txtDowntimeHours);
            this.Controls.Add(this.lblDowntimeHours);
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
        private System.Windows.Forms.Label lblDowntimeHours;
        private System.Windows.Forms.TextBox txtDowntimeHours;
        private System.Windows.Forms.Label lblExtendedDays;
        private System.Windows.Forms.Label lblTotalHours;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtBaseDays;
        private System.Windows.Forms.TextBox txtDownDays;
        private System.Windows.Forms.TextBox txtTotalHours;
        private System.Windows.Forms.TextBox txtWorkingHours;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnExit;
    }
}


