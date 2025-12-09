namespace Water
{
    partial class PricingForm
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
            this.lblPriceLevelId = new System.Windows.Forms.Label();
            this.txtPriceLevelId = new System.Windows.Forms.TextBox();
            this.lblLevelName = new System.Windows.Forms.Label();
            this.txtLevelName = new System.Windows.Forms.TextBox();
            this.lblPricingDate = new System.Windows.Forms.Label();
            this.dtpPricingDate = new System.Windows.Forms.DateTimePicker();
            this.lblDieselHourPrice = new System.Windows.Forms.Label();
            this.txtDieselHourPrice = new System.Windows.Forms.TextBox();
            this.lblDieselMinutePrice = new System.Windows.Forms.Label();
            this.txtDieselMinutePrice = new System.Windows.Forms.TextBox();
            this.lblDieselUsedHour = new System.Windows.Forms.Label();
            this.txtDieselUsedHour = new System.Windows.Forms.TextBox();
            this.lblDieselUsedMinute = new System.Windows.Forms.Label();
            this.txtDieselUsedMinute = new System.Windows.Forms.TextBox();
            this.lblWaterHourPrice = new System.Windows.Forms.Label();
            this.txtWaterHourPrice = new System.Windows.Forms.TextBox();
            this.lblWaterMinutePrice = new System.Windows.Forms.Label();
            this.txtWaterMinutePrice = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lblPriceLevelId
            // 
            this.lblPriceLevelId.AutoSize = true;
            this.lblPriceLevelId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceLevelId.Location = new System.Drawing.Point(26, 109);
            this.lblPriceLevelId.Name = "lblPriceLevelId";
            this.lblPriceLevelId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPriceLevelId.Size = new System.Drawing.Size(113, 20);
            this.lblPriceLevelId.TabIndex = 0;
            this.lblPriceLevelId.Text = "رقم مستوى السعر:";
            // 
            // txtPriceLevelId
            // 
            this.txtPriceLevelId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriceLevelId.Location = new System.Drawing.Point(155, 106);
            this.txtPriceLevelId.Name = "txtPriceLevelId";
            this.txtPriceLevelId.ReadOnly = true;
            this.txtPriceLevelId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPriceLevelId.Size = new System.Drawing.Size(100, 26);
            this.txtPriceLevelId.TabIndex = 0;
            this.txtPriceLevelId.TabStop = false;
            this.txtPriceLevelId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLevelName
            // 
            this.lblLevelName.AutoSize = true;
            this.lblLevelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevelName.Location = new System.Drawing.Point(30, 141);
            this.lblLevelName.Name = "lblLevelName";
            this.lblLevelName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblLevelName.Size = new System.Drawing.Size(84, 20);
            this.lblLevelName.TabIndex = 2;
            this.lblLevelName.Text = "اسم المستوى:";
            // 
            // txtLevelName
            // 
            this.txtLevelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLevelName.Location = new System.Drawing.Point(155, 138);
            this.txtLevelName.Name = "txtLevelName";
            this.txtLevelName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLevelName.Size = new System.Drawing.Size(222, 26);
            this.txtLevelName.TabIndex = 1;
            // 
            // lblPricingDate
            // 
            this.lblPricingDate.AutoSize = true;
            this.lblPricingDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPricingDate.Location = new System.Drawing.Point(595, 106);
            this.lblPricingDate.Name = "lblPricingDate";
            this.lblPricingDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPricingDate.Size = new System.Drawing.Size(51, 20);
            this.lblPricingDate.TabIndex = 4;
            this.lblPricingDate.Text = "التاريخ:";
            // 
            // dtpPricingDate
            // 
            this.dtpPricingDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPricingDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPricingDate.Location = new System.Drawing.Point(659, 103);
            this.dtpPricingDate.Name = "dtpPricingDate";
            this.dtpPricingDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpPricingDate.RightToLeftLayout = true;
            this.dtpPricingDate.Size = new System.Drawing.Size(263, 26);
            this.dtpPricingDate.TabIndex = 2;
            // 
            // lblDieselHourPrice
            // 
            this.lblDieselHourPrice.AutoSize = true;
            this.lblDieselHourPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDieselHourPrice.Location = new System.Drawing.Point(447, 176);
            this.lblDieselHourPrice.Name = "lblDieselHourPrice";
            this.lblDieselHourPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDieselHourPrice.Size = new System.Drawing.Size(112, 20);
            this.lblDieselHourPrice.TabIndex = 6;
            this.lblDieselHourPrice.Text = "سعر الديزل / س :";
            // 
            // txtDieselHourPrice
            // 
            this.txtDieselHourPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDieselHourPrice.Location = new System.Drawing.Point(572, 173);
            this.txtDieselHourPrice.Name = "txtDieselHourPrice";
            this.txtDieselHourPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDieselHourPrice.Size = new System.Drawing.Size(166, 26);
            this.txtDieselHourPrice.TabIndex = 4;
            this.txtDieselHourPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // lblDieselMinutePrice
            // 
            this.lblDieselMinutePrice.AutoSize = true;
            this.lblDieselMinutePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDieselMinutePrice.Location = new System.Drawing.Point(701, 359);
            this.lblDieselMinutePrice.Name = "lblDieselMinutePrice";
            this.lblDieselMinutePrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDieselMinutePrice.Size = new System.Drawing.Size(104, 20);
            this.lblDieselMinutePrice.TabIndex = 8;
            this.lblDieselMinutePrice.Text = "سعر الديزل / د :";
            // 
            // txtDieselMinutePrice
            // 
            this.txtDieselMinutePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDieselMinutePrice.Location = new System.Drawing.Point(698, 388);
            this.txtDieselMinutePrice.Name = "txtDieselMinutePrice";
            this.txtDieselMinutePrice.ReadOnly = true;
            this.txtDieselMinutePrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDieselMinutePrice.Size = new System.Drawing.Size(175, 26);
            this.txtDieselMinutePrice.TabIndex = 9;
            this.txtDieselMinutePrice.TabStop = false;
            this.txtDieselMinutePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // lblDieselUsedHour
            // 
            this.lblDieselUsedHour.AutoSize = true;
            this.lblDieselUsedHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDieselUsedHour.Location = new System.Drawing.Point(30, 207);
            this.lblDieselUsedHour.Name = "lblDieselUsedHour";
            this.lblDieselUsedHour.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDieselUsedHour.Size = new System.Drawing.Size(124, 20);
            this.lblDieselUsedHour.TabIndex = 10;
            this.lblDieselUsedHour.Text = "استهلاك ديزل / س :";
            // 
            // txtDieselUsedHour
            // 
            this.txtDieselUsedHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDieselUsedHour.Location = new System.Drawing.Point(155, 204);
            this.txtDieselUsedHour.Name = "txtDieselUsedHour";
            this.txtDieselUsedHour.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDieselUsedHour.Size = new System.Drawing.Size(171, 26);
            this.txtDieselUsedHour.TabIndex = 5;
            this.txtDieselUsedHour.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // lblDieselUsedMinute
            // 
            this.lblDieselUsedMinute.AutoSize = true;
            this.lblDieselUsedMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDieselUsedMinute.Location = new System.Drawing.Point(401, 359);
            this.lblDieselUsedMinute.Name = "lblDieselUsedMinute";
            this.lblDieselUsedMinute.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDieselUsedMinute.Size = new System.Drawing.Size(121, 20);
            this.lblDieselUsedMinute.TabIndex = 12;
            this.lblDieselUsedMinute.Text = "استهلاك ديزل / د  :";
            // 
            // txtDieselUsedMinute
            // 
            this.txtDieselUsedMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDieselUsedMinute.Location = new System.Drawing.Point(405, 388);
            this.txtDieselUsedMinute.Name = "txtDieselUsedMinute";
            this.txtDieselUsedMinute.ReadOnly = true;
            this.txtDieselUsedMinute.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDieselUsedMinute.Size = new System.Drawing.Size(202, 26);
            this.txtDieselUsedMinute.TabIndex = 13;
            this.txtDieselUsedMinute.TabStop = false;
            this.txtDieselUsedMinute.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // lblWaterHourPrice
            // 
            this.lblWaterHourPrice.AutoSize = true;
            this.lblWaterHourPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaterHourPrice.Location = new System.Drawing.Point(30, 173);
            this.lblWaterHourPrice.Name = "lblWaterHourPrice";
            this.lblWaterHourPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblWaterHourPrice.Size = new System.Drawing.Size(107, 20);
            this.lblWaterHourPrice.TabIndex = 14;
            this.lblWaterHourPrice.Text = "سعر الساعة ماء :";
            // 
            // txtWaterHourPrice
            // 
            this.txtWaterHourPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWaterHourPrice.Location = new System.Drawing.Point(155, 170);
            this.txtWaterHourPrice.Name = "txtWaterHourPrice";
            this.txtWaterHourPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtWaterHourPrice.Size = new System.Drawing.Size(171, 26);
            this.txtWaterHourPrice.TabIndex = 3;
            this.txtWaterHourPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // lblWaterMinutePrice
            // 
            this.lblWaterMinutePrice.AutoSize = true;
            this.lblWaterMinutePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaterMinutePrice.Location = new System.Drawing.Point(151, 359);
            this.lblWaterMinutePrice.Name = "lblWaterMinutePrice";
            this.lblWaterMinutePrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblWaterMinutePrice.Size = new System.Drawing.Size(104, 20);
            this.lblWaterMinutePrice.TabIndex = 16;
            this.lblWaterMinutePrice.Text = "سعر الدقيقة ماء :";
            // 
            // txtWaterMinutePrice
            // 
            this.txtWaterMinutePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWaterMinutePrice.Location = new System.Drawing.Point(141, 388);
            this.txtWaterMinutePrice.Name = "txtWaterMinutePrice";
            this.txtWaterMinutePrice.ReadOnly = true;
            this.txtWaterMinutePrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtWaterMinutePrice.Size = new System.Drawing.Size(198, 26);
            this.txtWaterMinutePrice.TabIndex = 17;
            this.txtWaterMinutePrice.TabStop = false;
            this.txtWaterMinutePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeric_KeyPress);
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.Location = new System.Drawing.Point(30, 259);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNotes.Size = new System.Drawing.Size(66, 20);
            this.lblNotes.TabIndex = 18;
            this.lblNotes.Text = "ملاحظات:";
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(155, 256);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNotes.Size = new System.Drawing.Size(767, 60);
            this.txtNotes.TabIndex = 6;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::Water.Properties.Resources.icons8_exit_24;
            this.btnExit.Location = new System.Drawing.Point(637, 40);
            this.btnExit.Name = "btnExit";
            this.btnExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnExit.Size = new System.Drawing.Size(70, 40);
            this.btnExit.TabIndex = 30;
            this.toolTip1.SetToolTip(this.btnExit, "خروج");
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Water.Properties.Resources.icons8_save_24_9;
            this.btnSave.Location = new System.Drawing.Point(561, 40);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(70, 40);
            this.btnSave.TabIndex = 29;
            this.toolTip1.SetToolTip(this.btnSave, "حفظ");
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::Water.Properties.Resources.icons8_delete_24;
            this.btnDelete.Location = new System.Drawing.Point(485, 40);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDelete.Size = new System.Drawing.Size(70, 40);
            this.btnDelete.TabIndex = 28;
            this.toolTip1.SetToolTip(this.btnDelete, "حذف");
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = global::Water.Properties.Resources.icons8_edit_24_5;
            this.btnEdit.Location = new System.Drawing.Point(409, 40);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnEdit.Size = new System.Drawing.Size(70, 40);
            this.btnEdit.TabIndex = 27;
            this.toolTip1.SetToolTip(this.btnEdit, "تعديل");
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::Water.Properties.Resources.icons8_add_24;
            this.btnAdd.Location = new System.Drawing.Point(333, 40);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAdd.Size = new System.Drawing.Size(70, 40);
            this.btnAdd.TabIndex = 26;
            this.toolTip1.SetToolTip(this.btnAdd, "إضافة");
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = global::Water.Properties.Resources.icons8_search_24_8;
            this.btnView.Location = new System.Drawing.Point(257, 40);
            this.btnView.Name = "btnView";
            this.btnView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnView.Size = new System.Drawing.Size(70, 40);
            this.btnView.TabIndex = 25;
            this.toolTip1.SetToolTip(this.btnView, "عرض");
            this.btnView.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(442, 7);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(118, 25);
            this.label1.TabIndex = 31;
            this.label1.Text = "شاشة التسعيرة";
            // 
            // PricingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 422);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtWaterMinutePrice);
            this.Controls.Add(this.lblWaterMinutePrice);
            this.Controls.Add(this.txtWaterHourPrice);
            this.Controls.Add(this.lblWaterHourPrice);
            this.Controls.Add(this.txtDieselUsedMinute);
            this.Controls.Add(this.lblDieselUsedMinute);
            this.Controls.Add(this.txtDieselUsedHour);
            this.Controls.Add(this.lblDieselUsedHour);
            this.Controls.Add(this.txtDieselMinutePrice);
            this.Controls.Add(this.lblDieselMinutePrice);
            this.Controls.Add(this.txtDieselHourPrice);
            this.Controls.Add(this.lblDieselHourPrice);
            this.Controls.Add(this.dtpPricingDate);
            this.Controls.Add(this.lblPricingDate);
            this.Controls.Add(this.txtLevelName);
            this.Controls.Add(this.lblLevelName);
            this.Controls.Add(this.txtPriceLevelId);
            this.Controls.Add(this.lblPriceLevelId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PricingForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مستويات الأسعار";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPriceLevelId;
        private System.Windows.Forms.TextBox txtPriceLevelId;
        private System.Windows.Forms.Label lblLevelName;
        private System.Windows.Forms.TextBox txtLevelName;
        private System.Windows.Forms.Label lblPricingDate;
        private System.Windows.Forms.DateTimePicker dtpPricingDate;
        private System.Windows.Forms.Label lblDieselHourPrice;
        private System.Windows.Forms.TextBox txtDieselHourPrice;
        private System.Windows.Forms.Label lblDieselMinutePrice;
        private System.Windows.Forms.TextBox txtDieselMinutePrice;
        private System.Windows.Forms.Label lblDieselUsedHour;
        private System.Windows.Forms.TextBox txtDieselUsedHour;
        private System.Windows.Forms.Label lblDieselUsedMinute;
        private System.Windows.Forms.TextBox txtDieselUsedMinute;
        private System.Windows.Forms.Label lblWaterHourPrice;
        private System.Windows.Forms.TextBox txtWaterHourPrice;
        private System.Windows.Forms.Label lblWaterMinutePrice;
        private System.Windows.Forms.TextBox txtWaterMinutePrice;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

