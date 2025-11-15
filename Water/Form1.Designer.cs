namespace Water
{
    partial class Form1
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
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnAccounts = new System.Windows.Forms.Button();
            this.btnDowntime = new System.Windows.Forms.Button();
            this.btnExpenses = new System.Windows.Forms.Button();
            this.btnPeriods = new System.Windows.Forms.Button();
            this.btnSales = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCustomers
            // 
            this.btnCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomers.Location = new System.Drawing.Point(30, 30);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(200, 50);
            this.btnCustomers.TabIndex = 0;
            this.btnCustomers.Text = "العملاء";
            this.btnCustomers.UseVisualStyleBackColor = true;
            this.btnCustomers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnAccounts
            // 
            this.btnAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccounts.Location = new System.Drawing.Point(250, 30);
            this.btnAccounts.Name = "btnAccounts";
            this.btnAccounts.Size = new System.Drawing.Size(200, 50);
            this.btnAccounts.TabIndex = 1;
            this.btnAccounts.Text = "الحسابات";
            this.btnAccounts.UseVisualStyleBackColor = true;
            this.btnAccounts.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAccounts.Click += new System.EventHandler(this.btnAccounts_Click);
            // 
            // btnDowntime
            // 
            this.btnDowntime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDowntime.Location = new System.Drawing.Point(470, 30);
            this.btnDowntime.Name = "btnDowntime";
            this.btnDowntime.Size = new System.Drawing.Size(200, 50);
            this.btnDowntime.TabIndex = 2;
            this.btnDowntime.Text = "التوقف";
            this.btnDowntime.UseVisualStyleBackColor = true;
            this.btnDowntime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDowntime.Click += new System.EventHandler(this.btnDowntime_Click);
            // 
            // btnExpenses
            // 
            this.btnExpenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpenses.Location = new System.Drawing.Point(30, 100);
            this.btnExpenses.Name = "btnExpenses";
            this.btnExpenses.Size = new System.Drawing.Size(200, 50);
            this.btnExpenses.TabIndex = 3;
            this.btnExpenses.Text = "القيود اليومية";
            this.btnExpenses.UseVisualStyleBackColor = true;
            this.btnExpenses.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnExpenses.Click += new System.EventHandler(this.btnExpenses_Click);
            // 
            // btnPeriods
            // 
            this.btnPeriods.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPeriods.Location = new System.Drawing.Point(250, 100);
            this.btnPeriods.Name = "btnPeriods";
            this.btnPeriods.Size = new System.Drawing.Size(200, 50);
            this.btnPeriods.TabIndex = 4;
            this.btnPeriods.Text = "الفترات";
            this.btnPeriods.UseVisualStyleBackColor = true;
            this.btnPeriods.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPeriods.Click += new System.EventHandler(this.btnPeriods_Click);
            // 
            // btnSales
            // 
            this.btnSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSales.Location = new System.Drawing.Point(470, 100);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(200, 50);
            this.btnSales.TabIndex = 5;
            this.btnSales.Text = "المبيعات";
            this.btnSales.UseVisualStyleBackColor = true;
            this.btnSales.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 180);
            this.Controls.Add(this.btnSales);
            this.Controls.Add(this.btnPeriods);
            this.Controls.Add(this.btnExpenses);
            this.Controls.Add(this.btnDowntime);
            this.Controls.Add(this.btnAccounts);
            this.Controls.Add(this.btnCustomers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نظام إدارة المياه";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnAccounts;
        private System.Windows.Forms.Button btnDowntime;
        private System.Windows.Forms.Button btnExpenses;
        private System.Windows.Forms.Button btnPeriods;
        private System.Windows.Forms.Button btnSales;
    }
}

