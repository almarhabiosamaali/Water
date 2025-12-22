namespace Water
{
    partial class partnerMovmentRPT
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
            this.txtPartnerID = new System.Windows.Forms.TextBox();
            this.btnShowRPT = new System.Windows.Forms.Button();
            this.txtPeriodId = new System.Windows.Forms.TextBox();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPartnerID
            // 
            this.txtPartnerID.Location = new System.Drawing.Point(142, 83);
            this.txtPartnerID.Name = "txtPartnerID";
            this.txtPartnerID.Size = new System.Drawing.Size(212, 22);
            this.txtPartnerID.TabIndex = 0;
            this.txtPartnerID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartnerID_KeyDown);
            // 
            // btnShowRPT
            // 
            this.btnShowRPT.Location = new System.Drawing.Point(439, 4);
            this.btnShowRPT.Name = "btnShowRPT";
            this.btnShowRPT.Size = new System.Drawing.Size(80, 40);
            this.btnShowRPT.TabIndex = 1;
            this.btnShowRPT.Text = "طباعة";
            this.toolTip1.SetToolTip(this.btnShowRPT, "طباعة");
            this.btnShowRPT.UseVisualStyleBackColor = true;
            this.btnShowRPT.Click += new System.EventHandler(this.btnShowRPT_Click);
            // 
            // txtPeriodId
            // 
            this.txtPeriodId.Location = new System.Drawing.Point(630, 76);
            this.txtPeriodId.Name = "txtPeriodId";
            this.txtPeriodId.Size = new System.Drawing.Size(198, 22);
            this.txtPeriodId.TabIndex = 3;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(142, 139);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.RightToLeftLayout = true;
            this.dtpFromDate.Size = new System.Drawing.Size(212, 22);
            this.dtpFromDate.TabIndex = 4;
            this.dtpFromDate.Value = new System.DateTime(2025, 1, 1, 3, 13, 0, 0);
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(630, 132);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.RightToLeftLayout = true;
            this.dtpToDate.Size = new System.Drawing.Size(198, 22);
            this.dtpToDate.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 83);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "رقم الشريك :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 139);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "من تاريخ :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(538, 137);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(58, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "الى تاريخ :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(534, 79);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(60, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "رقم الفترة :";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::Water.Properties.Resources.icons8_exit_24;
            this.btnExit.Location = new System.Drawing.Point(526, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnExit.Size = new System.Drawing.Size(80, 40);
            this.btnExit.TabIndex = 25;
            this.toolTip1.SetToolTip(this.btnExit, "خروج");
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "اجمالي",
            "تحليلي",
            "اجمالي ساعات و فلوس"});
            this.cmbType.Location = new System.Drawing.Point(745, 21);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(220, 24);
            this.cmbType.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(667, 28);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "نوع التقرير";
            // 
            // partnerMovmentRPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 342);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.txtPeriodId);
            this.Controls.Add(this.btnShowRPT);
            this.Controls.Add(this.txtPartnerID);
            this.Name = "partnerMovmentRPT";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "partnerMovmentRPT";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPartnerID;
        private System.Windows.Forms.Button btnShowRPT;
        private System.Windows.Forms.TextBox txtPeriodId;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label1;
    }
}