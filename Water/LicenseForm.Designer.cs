namespace Water
{
    partial class LicenseForm
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
            this.txtIssueDate = new System.Windows.Forms.TextBox();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.txtExpiryDate = new System.Windows.Forms.TextBox();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.txtHardwareID = new System.Windows.Forms.TextBox();
            this.lblHardwareID = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSelectLicenseFile = new System.Windows.Forms.Button();
            this.btnGenerateHardwareInfo = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.txtIssueDate);
            this.pnlMain.Controls.Add(this.lblIssueDate);
            this.pnlMain.Controls.Add(this.txtExpiryDate);
            this.pnlMain.Controls.Add(this.lblExpiryDate);
            this.pnlMain.Controls.Add(this.txtHardwareID);
            this.pnlMain.Controls.Add(this.lblHardwareID);
            this.pnlMain.Controls.Add(this.txtMessage);
            this.pnlMain.Controls.Add(this.lblMessage);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMain.Size = new System.Drawing.Size(600, 400);
            this.pnlMain.TabIndex = 0;
            // 
            // txtIssueDate
            // 
            this.txtIssueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIssueDate.Location = new System.Drawing.Point(30, 320);
            this.txtIssueDate.Name = "txtIssueDate";
            this.txtIssueDate.ReadOnly = true;
            this.txtIssueDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIssueDate.Size = new System.Drawing.Size(530, 26);
            this.txtIssueDate.TabIndex = 8;
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.AutoSize = true;
            this.lblIssueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueDate.Location = new System.Drawing.Point(480, 295);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblIssueDate.Size = new System.Drawing.Size(80, 20);
            this.lblIssueDate.TabIndex = 7;
            this.lblIssueDate.Text = "تاريخ الإصدار:";
            // 
            // txtExpiryDate
            // 
            this.txtExpiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpiryDate.Location = new System.Drawing.Point(30, 260);
            this.txtExpiryDate.Name = "txtExpiryDate";
            this.txtExpiryDate.ReadOnly = true;
            this.txtExpiryDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtExpiryDate.Size = new System.Drawing.Size(530, 26);
            this.txtExpiryDate.TabIndex = 6;
            // 
            // lblExpiryDate
            // 
            this.lblExpiryDate.AutoSize = true;
            this.lblExpiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpiryDate.Location = new System.Drawing.Point(480, 235);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblExpiryDate.Size = new System.Drawing.Size(80, 20);
            this.lblExpiryDate.TabIndex = 5;
            this.lblExpiryDate.Text = "تاريخ الانتهاء:";
            // 
            // txtHardwareID
            // 
            this.txtHardwareID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHardwareID.Location = new System.Drawing.Point(30, 200);
            this.txtHardwareID.Name = "txtHardwareID";
            this.txtHardwareID.ReadOnly = true;
            this.txtHardwareID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtHardwareID.Size = new System.Drawing.Size(530, 26);
            this.txtHardwareID.TabIndex = 4;
            // 
            // lblHardwareID
            // 
            this.lblHardwareID.AutoSize = true;
            this.lblHardwareID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHardwareID.Location = new System.Drawing.Point(480, 175);
            this.lblHardwareID.Name = "lblHardwareID";
            this.lblHardwareID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblHardwareID.Size = new System.Drawing.Size(80, 20);
            this.lblHardwareID.TabIndex = 3;
            this.lblHardwareID.Text = "معرف الجهاز:";
            // 
            // txtMessage
            // 
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(30, 120);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(530, 40);
            this.txtMessage.TabIndex = 2;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(480, 95);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMessage.Size = new System.Drawing.Size(80, 20);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "الحالة:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTitle.Location = new System.Drawing.Point(180, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTitle.Size = new System.Drawing.Size(240, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "حالة الترخيص";
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlButtons.Controls.Add(this.btnExit);
            this.pnlButtons.Controls.Add(this.btnSelectLicenseFile);
            this.pnlButtons.Controls.Add(this.btnGenerateHardwareInfo);
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 400);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(600, 60);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.IndianRed;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(30, 10);
            this.btnExit.Name = "btnExit";
            this.btnExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSelectLicenseFile
            // 
            this.btnSelectLicenseFile.BackColor = System.Drawing.Color.Orange;
            this.btnSelectLicenseFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectLicenseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectLicenseFile.ForeColor = System.Drawing.Color.White;
            this.btnSelectLicenseFile.Location = new System.Drawing.Point(140, 10);
            this.btnSelectLicenseFile.Name = "btnSelectLicenseFile";
            this.btnSelectLicenseFile.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSelectLicenseFile.Size = new System.Drawing.Size(140, 40);
            this.btnSelectLicenseFile.TabIndex = 2;
            this.btnSelectLicenseFile.Text = "اختر ملف الترخيص";
            this.btnSelectLicenseFile.UseVisualStyleBackColor = false;
            this.btnSelectLicenseFile.Click += new System.EventHandler(this.btnSelectLicenseFile_Click);
            // 
            // btnGenerateHardwareInfo
            // 
            this.btnGenerateHardwareInfo.BackColor = System.Drawing.Color.Teal;
            this.btnGenerateHardwareInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateHardwareInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateHardwareInfo.ForeColor = System.Drawing.Color.White;
            this.btnGenerateHardwareInfo.Location = new System.Drawing.Point(290, 10);
            this.btnGenerateHardwareInfo.Name = "btnGenerateHardwareInfo";
            this.btnGenerateHardwareInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnGenerateHardwareInfo.Size = new System.Drawing.Size(140, 40);
            this.btnGenerateHardwareInfo.TabIndex = 1;
            this.btnGenerateHardwareInfo.Text = "معلومات الجهاز";
            this.btnGenerateHardwareInfo.UseVisualStyleBackColor = false;
            this.btnGenerateHardwareInfo.Click += new System.EventHandler(this.btnGenerateHardwareInfo_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(440, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClose.Size = new System.Drawing.Size(120, 40);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "موافق";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // LicenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(600, 460);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LicenseForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "حالة الترخيص";
            this.Load += new System.EventHandler(this.LicenseForm_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lblHardwareID;
        private System.Windows.Forms.TextBox txtHardwareID;
        private System.Windows.Forms.Label lblExpiryDate;
        private System.Windows.Forms.TextBox txtExpiryDate;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.TextBox txtIssueDate;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnGenerateHardwareInfo;
        private System.Windows.Forms.Button btnSelectLicenseFile;
        private System.Windows.Forms.Button btnExit;
    }
}

