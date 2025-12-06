namespace Water
{
    partial class HardwareInfoForm
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnCopyHardwareID = new System.Windows.Forms.Button();
            this.txtGeneratedDate = new System.Windows.Forms.TextBox();
            this.lblGeneratedDate = new System.Windows.Forms.Label();
            this.txtMACAddress = new System.Windows.Forms.TextBox();
            this.lblMACAddress = new System.Windows.Forms.Label();
            this.txtDiskSerial = new System.Windows.Forms.TextBox();
            this.lblDiskSerial = new System.Windows.Forms.Label();
            this.txtMotherboardSerial = new System.Windows.Forms.TextBox();
            this.lblMotherboardSerial = new System.Windows.Forms.Label();
            this.txtProcessorID = new System.Windows.Forms.TextBox();
            this.lblProcessorID = new System.Windows.Forms.Label();
            this.txtMachineName = new System.Windows.Forms.TextBox();
            this.lblMachineName = new System.Windows.Forms.Label();
            this.txtHardwareID = new System.Windows.Forms.TextBox();
            this.lblHardwareID = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.btnCopyHardwareID);
            this.pnlMain.Controls.Add(this.txtGeneratedDate);
            this.pnlMain.Controls.Add(this.lblGeneratedDate);
            this.pnlMain.Controls.Add(this.txtMACAddress);
            this.pnlMain.Controls.Add(this.lblMACAddress);
            this.pnlMain.Controls.Add(this.txtDiskSerial);
            this.pnlMain.Controls.Add(this.lblDiskSerial);
            this.pnlMain.Controls.Add(this.txtMotherboardSerial);
            this.pnlMain.Controls.Add(this.lblMotherboardSerial);
            this.pnlMain.Controls.Add(this.txtProcessorID);
            this.pnlMain.Controls.Add(this.lblProcessorID);
            this.pnlMain.Controls.Add(this.txtMachineName);
            this.pnlMain.Controls.Add(this.lblMachineName);
            this.pnlMain.Controls.Add(this.txtHardwareID);
            this.pnlMain.Controls.Add(this.lblHardwareID);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMain.Size = new System.Drawing.Size(700, 550);
            this.pnlMain.TabIndex = 0;
            // 
            // btnCopyHardwareID
            // 
            this.btnCopyHardwareID.BackColor = System.Drawing.Color.LightGray;
            this.btnCopyHardwareID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyHardwareID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyHardwareID.Location = new System.Drawing.Point(30, 120);
            this.btnCopyHardwareID.Name = "btnCopyHardwareID";
            this.btnCopyHardwareID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCopyHardwareID.Size = new System.Drawing.Size(100, 30);
            this.btnCopyHardwareID.TabIndex = 15;
            this.btnCopyHardwareID.Text = "نسخ";
            this.btnCopyHardwareID.UseVisualStyleBackColor = false;
            this.btnCopyHardwareID.Click += new System.EventHandler(this.btnCopyHardwareID_Click);
            // 
            // txtGeneratedDate
            // 
            this.txtGeneratedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGeneratedDate.Location = new System.Drawing.Point(30, 480);
            this.txtGeneratedDate.Name = "txtGeneratedDate";
            this.txtGeneratedDate.ReadOnly = true;
            this.txtGeneratedDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtGeneratedDate.Size = new System.Drawing.Size(630, 26);
            this.txtGeneratedDate.TabIndex = 14;
            // 
            // lblGeneratedDate
            // 
            this.lblGeneratedDate.AutoSize = true;
            this.lblGeneratedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGeneratedDate.Location = new System.Drawing.Point(580, 455);
            this.lblGeneratedDate.Name = "lblGeneratedDate";
            this.lblGeneratedDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblGeneratedDate.Size = new System.Drawing.Size(80, 20);
            this.lblGeneratedDate.TabIndex = 13;
            this.lblGeneratedDate.Text = "تاريخ التوليد:";
            // 
            // txtMACAddress
            // 
            this.txtMACAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMACAddress.Location = new System.Drawing.Point(30, 420);
            this.txtMACAddress.Name = "txtMACAddress";
            this.txtMACAddress.ReadOnly = true;
            this.txtMACAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMACAddress.Size = new System.Drawing.Size(630, 26);
            this.txtMACAddress.TabIndex = 12;
            // 
            // lblMACAddress
            // 
            this.lblMACAddress.AutoSize = true;
            this.lblMACAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMACAddress.Location = new System.Drawing.Point(570, 395);
            this.lblMACAddress.Name = "lblMACAddress";
            this.lblMACAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMACAddress.Size = new System.Drawing.Size(90, 20);
            this.lblMACAddress.TabIndex = 11;
            this.lblMACAddress.Text = "عنوان MAC:";
            // 
            // txtDiskSerial
            // 
            this.txtDiskSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiskSerial.Location = new System.Drawing.Point(30, 360);
            this.txtDiskSerial.Name = "txtDiskSerial";
            this.txtDiskSerial.ReadOnly = true;
            this.txtDiskSerial.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDiskSerial.Size = new System.Drawing.Size(630, 26);
            this.txtDiskSerial.TabIndex = 10;
            // 
            // lblDiskSerial
            // 
            this.lblDiskSerial.AutoSize = true;
            this.lblDiskSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiskSerial.Location = new System.Drawing.Point(560, 335);
            this.lblDiskSerial.Name = "lblDiskSerial";
            this.lblDiskSerial.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDiskSerial.Size = new System.Drawing.Size(100, 20);
            this.lblDiskSerial.TabIndex = 9;
            this.lblDiskSerial.Text = "رقم القرص الصلب:";
            // 
            // txtMotherboardSerial
            // 
            this.txtMotherboardSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotherboardSerial.Location = new System.Drawing.Point(30, 300);
            this.txtMotherboardSerial.Name = "txtMotherboardSerial";
            this.txtMotherboardSerial.ReadOnly = true;
            this.txtMotherboardSerial.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMotherboardSerial.Size = new System.Drawing.Size(630, 26);
            this.txtMotherboardSerial.TabIndex = 8;
            // 
            // lblMotherboardSerial
            // 
            this.lblMotherboardSerial.AutoSize = true;
            this.lblMotherboardSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotherboardSerial.Location = new System.Drawing.Point(550, 275);
            this.lblMotherboardSerial.Name = "lblMotherboardSerial";
            this.lblMotherboardSerial.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMotherboardSerial.Size = new System.Drawing.Size(110, 20);
            this.lblMotherboardSerial.TabIndex = 7;
            this.lblMotherboardSerial.Text = "رقم اللوحة الأم:";
            // 
            // txtProcessorID
            // 
            this.txtProcessorID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcessorID.Location = new System.Drawing.Point(30, 240);
            this.txtProcessorID.Name = "txtProcessorID";
            this.txtProcessorID.ReadOnly = true;
            this.txtProcessorID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtProcessorID.Size = new System.Drawing.Size(630, 26);
            this.txtProcessorID.TabIndex = 6;
            // 
            // lblProcessorID
            // 
            this.lblProcessorID.AutoSize = true;
            this.lblProcessorID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcessorID.Location = new System.Drawing.Point(570, 215);
            this.lblProcessorID.Name = "lblProcessorID";
            this.lblProcessorID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblProcessorID.Size = new System.Drawing.Size(90, 20);
            this.lblProcessorID.TabIndex = 5;
            this.lblProcessorID.Text = "رقم المعالج:";
            // 
            // txtMachineName
            // 
            this.txtMachineName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMachineName.Location = new System.Drawing.Point(30, 180);
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.ReadOnly = true;
            this.txtMachineName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMachineName.Size = new System.Drawing.Size(630, 26);
            this.txtMachineName.TabIndex = 4;
            // 
            // lblMachineName
            // 
            this.lblMachineName.AutoSize = true;
            this.lblMachineName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMachineName.Location = new System.Drawing.Point(570, 155);
            this.lblMachineName.Name = "lblMachineName";
            this.lblMachineName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMachineName.Size = new System.Drawing.Size(90, 20);
            this.lblMachineName.TabIndex = 3;
            this.lblMachineName.Text = "اسم الجهاز:";
            // 
            // txtHardwareID
            // 
            this.txtHardwareID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHardwareID.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtHardwareID.Location = new System.Drawing.Point(140, 120);
            this.txtHardwareID.Name = "txtHardwareID";
            this.txtHardwareID.ReadOnly = true;
            this.txtHardwareID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtHardwareID.Size = new System.Drawing.Size(520, 26);
            this.txtHardwareID.TabIndex = 2;
            // 
            // lblHardwareID
            // 
            this.lblHardwareID.AutoSize = true;
            this.lblHardwareID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHardwareID.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblHardwareID.Location = new System.Drawing.Point(560, 95);
            this.lblHardwareID.Name = "lblHardwareID";
            this.lblHardwareID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblHardwareID.Size = new System.Drawing.Size(100, 20);
            this.lblHardwareID.TabIndex = 1;
            this.lblHardwareID.Text = "معرف الجهاز:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTitle.Location = new System.Drawing.Point(200, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTitle.Size = new System.Drawing.Size(300, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "معلومات الجهاز - توليد ملف الترخيص";
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnSaveFile);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 550);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(700, 60);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(30, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSaveFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveFile.ForeColor = System.Drawing.Color.White;
            this.btnSaveFile.Location = new System.Drawing.Point(550, 10);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSaveFile.Size = new System.Drawing.Size(120, 40);
            this.btnSaveFile.TabIndex = 0;
            this.btnSaveFile.Text = "حفظ الملف";
            this.btnSaveFile.UseVisualStyleBackColor = false;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // HardwareInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(700, 610);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HardwareInfoForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "معلومات الجهاز";
            this.Load += new System.EventHandler(this.HardwareInfoForm_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblHardwareID;
        private System.Windows.Forms.TextBox txtHardwareID;
        private System.Windows.Forms.Label lblMachineName;
        private System.Windows.Forms.TextBox txtMachineName;
        private System.Windows.Forms.Label lblProcessorID;
        private System.Windows.Forms.TextBox txtProcessorID;
        private System.Windows.Forms.Label lblMotherboardSerial;
        private System.Windows.Forms.TextBox txtMotherboardSerial;
        private System.Windows.Forms.Label lblDiskSerial;
        private System.Windows.Forms.TextBox txtDiskSerial;
        private System.Windows.Forms.Label lblMACAddress;
        private System.Windows.Forms.TextBox txtMACAddress;
        private System.Windows.Forms.Label lblGeneratedDate;
        private System.Windows.Forms.TextBox txtGeneratedDate;
        private System.Windows.Forms.Button btnCopyHardwareID;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.Button btnCancel;
    }
}

