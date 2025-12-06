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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.treeViewMain = new System.Windows.Forms.TreeView();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.lblChartTitle = new System.Windows.Forms.Label();
            this.dgvRecentTransactions = new System.Windows.Forms.DataGridView();
            this.lblRecentTransactions = new System.Windows.Forms.Label();
            this.pnlKPICards = new System.Windows.Forms.Panel();
            this.pnlRevenueCard = new System.Windows.Forms.Panel();
            this.lblTotalRevenueAmount = new System.Windows.Forms.Label();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.pnlSalesCard = new System.Windows.Forms.Panel();
            this.lblTotalSalesCount = new System.Windows.Forms.Label();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.pnlCustomersCard = new System.Windows.Forms.Panel();
            this.lblCustomersCount = new System.Windows.Forms.Label();
            this.lblCustomersCard = new System.Windows.Forms.Label();
            this.pnlPartnersCard = new System.Windows.Forms.Panel();
            this.lblPartnersCount = new System.Windows.Forms.Label();
            this.lblPartnersCard = new System.Windows.Forms.Label();
            this.pnlLoginOverlay = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlMainContent.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentTransactions)).BeginInit();
            this.pnlKPICards.SuspendLayout();
            this.pnlRevenueCard.SuspendLayout();
            this.pnlSalesCard.SuspendLayout();
            this.pnlCustomersCard.SuspendLayout();
            this.pnlPartnersCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlHeader.Controls.Add(this.lblUser);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1419, 35);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblUser
            // 
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(1371, 9);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(42, 20);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "المدير";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(14, 2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(151, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "نظام إدارة المياه";
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.White;
            this.pnlSidebar.Controls.Add(this.treeViewMain);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 35);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(286, 746);
            this.pnlSidebar.TabIndex = 1;
            // 
            // treeViewMain
            // 
            this.treeViewMain.BackColor = System.Drawing.Color.White;
            this.treeViewMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewMain.FullRowSelect = true;
            this.treeViewMain.HideSelection = false;
            this.treeViewMain.Location = new System.Drawing.Point(0, 0);
            this.treeViewMain.Name = "treeViewMain";
            this.treeViewMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.treeViewMain.RightToLeftLayout = true;
            this.treeViewMain.Size = new System.Drawing.Size(286, 746);
            this.treeViewMain.TabIndex = 0;
            this.treeViewMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewMain_AfterSelect);
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.AutoSize = true;
            this.pnlMainContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.pnlMainContent.Controls.Add(this.panel1);
            this.pnlMainContent.Controls.Add(this.pnlChart);
            this.pnlMainContent.Controls.Add(this.dgvRecentTransactions);
            this.pnlMainContent.Controls.Add(this.lblRecentTransactions);
            this.pnlMainContent.Controls.Add(this.pnlKPICards);
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(286, 35);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Padding = new System.Windows.Forms.Padding(23, 20, 23, 20);
            this.pnlMainContent.Size = new System.Drawing.Size(1133, 746);
            this.pnlMainContent.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(341, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 177);
            this.panel1.TabIndex = 5;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = global::Water.Properties.Resources.logoWell;
            this.pictureBox2.Location = new System.Drawing.Point(5, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(533, 174);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pnlChart
            // 
            this.pnlChart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlChart.BackColor = System.Drawing.Color.White;
            this.pnlChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChart.Controls.Add(this.lblChartTitle);
            this.pnlChart.Location = new System.Drawing.Point(22, 339);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(400, 280);
            this.pnlChart.TabIndex = 3;
            // 
            // lblChartTitle
            // 
            this.lblChartTitle.AutoSize = true;
            this.lblChartTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartTitle.Location = new System.Drawing.Point(63, 4);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.Size = new System.Drawing.Size(194, 25);
            this.lblChartTitle.TabIndex = 0;
            this.lblChartTitle.Text = "نظرة عامة على المبيعات";
            // 
            // dgvRecentTransactions
            // 
            this.dgvRecentTransactions.AllowUserToAddRows = false;
            this.dgvRecentTransactions.AllowUserToDeleteRows = false;
            this.dgvRecentTransactions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvRecentTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentTransactions.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentTransactions.Location = new System.Drawing.Point(432, 339);
            this.dgvRecentTransactions.Name = "dgvRecentTransactions";
            this.dgvRecentTransactions.ReadOnly = true;
            this.dgvRecentTransactions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvRecentTransactions.RowHeadersWidth = 51;
            this.dgvRecentTransactions.RowTemplate.Height = 24;
            this.dgvRecentTransactions.Size = new System.Drawing.Size(694, 280);
            this.dgvRecentTransactions.TabIndex = 2;
            // 
            // lblRecentTransactions
            // 
            this.lblRecentTransactions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRecentTransactions.AutoSize = true;
            this.lblRecentTransactions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecentTransactions.Location = new System.Drawing.Point(903, 311);
            this.lblRecentTransactions.Name = "lblRecentTransactions";
            this.lblRecentTransactions.Size = new System.Drawing.Size(142, 25);
            this.lblRecentTransactions.TabIndex = 1;
            this.lblRecentTransactions.Text = "المعاملات الأخيرة";
            // 
            // pnlKPICards
            // 
            this.pnlKPICards.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlKPICards.Controls.Add(this.pnlRevenueCard);
            this.pnlKPICards.Controls.Add(this.pnlSalesCard);
            this.pnlKPICards.Controls.Add(this.pnlCustomersCard);
            this.pnlKPICards.Controls.Add(this.pnlPartnersCard);
            this.pnlKPICards.Location = new System.Drawing.Point(25, 189);
            this.pnlKPICards.Name = "pnlKPICards";
            this.pnlKPICards.Size = new System.Drawing.Size(1085, 119);
            this.pnlKPICards.TabIndex = 0;
            // 
            // pnlRevenueCard
            // 
            this.pnlRevenueCard.BackColor = System.Drawing.Color.SkyBlue;
            this.pnlRevenueCard.Controls.Add(this.lblTotalRevenueAmount);
            this.pnlRevenueCard.Controls.Add(this.lblTotalRevenue);
            this.pnlRevenueCard.Font = new System.Drawing.Font("Tahoma", 5F);
            this.pnlRevenueCard.Location = new System.Drawing.Point(23, 20);
            this.pnlRevenueCard.Name = "pnlRevenueCard";
            this.pnlRevenueCard.Size = new System.Drawing.Size(217, 74);
            this.pnlRevenueCard.TabIndex = 3;
            // 
            // lblTotalRevenueAmount
            // 
            this.lblTotalRevenueAmount.AutoSize = true;
            this.lblTotalRevenueAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRevenueAmount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalRevenueAmount.Location = new System.Drawing.Point(59, 36);
            this.lblTotalRevenueAmount.Name = "lblTotalRevenueAmount";
            this.lblTotalRevenueAmount.Size = new System.Drawing.Size(78, 25);
            this.lblTotalRevenueAmount.TabIndex = 1;
            this.lblTotalRevenueAmount.Text = "$2,560";
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.AutoSize = true;
            this.lblTotalRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.Black;
            this.lblTotalRevenue.Location = new System.Drawing.Point(41, 0);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(120, 25);
            this.lblTotalRevenue.TabIndex = 0;
            this.lblTotalRevenue.Text = "إجمالي الإيرادات";
            // 
            // pnlSalesCard
            // 
            this.pnlSalesCard.BackColor = System.Drawing.Color.SkyBlue;
            this.pnlSalesCard.Controls.Add(this.lblTotalSalesCount);
            this.pnlSalesCard.Controls.Add(this.lblTotalSales);
            this.pnlSalesCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlSalesCard.Font = new System.Drawing.Font("Tahoma", 5F);
            this.pnlSalesCard.Location = new System.Drawing.Point(291, 20);
            this.pnlSalesCard.Name = "pnlSalesCard";
            this.pnlSalesCard.Size = new System.Drawing.Size(217, 74);
            this.pnlSalesCard.TabIndex = 2;
            this.pnlSalesCard.Click += new System.EventHandler(this.pnlSalesCard_Click);
            // 
            // lblTotalSalesCount
            // 
            this.lblTotalSalesCount.AutoSize = true;
            this.lblTotalSalesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSalesCount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalSalesCount.Location = new System.Drawing.Point(74, 42);
            this.lblTotalSalesCount.Name = "lblTotalSalesCount";
            this.lblTotalSalesCount.Size = new System.Drawing.Size(48, 25);
            this.lblTotalSalesCount.TabIndex = 1;
            this.lblTotalSalesCount.Text = "128";
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.AutoSize = true;
            this.lblTotalSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSales.ForeColor = System.Drawing.Color.Black;
            this.lblTotalSales.Location = new System.Drawing.Point(49, 7);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(114, 25);
            this.lblTotalSales.TabIndex = 0;
            this.lblTotalSales.Text = "إجمالي المبيعات";
            // 
            // pnlCustomersCard
            // 
            this.pnlCustomersCard.BackColor = System.Drawing.Color.SkyBlue;
            this.pnlCustomersCard.Controls.Add(this.lblCustomersCount);
            this.pnlCustomersCard.Controls.Add(this.lblCustomersCard);
            this.pnlCustomersCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCustomersCard.Font = new System.Drawing.Font("Tahoma", 5F);
            this.pnlCustomersCard.Location = new System.Drawing.Point(555, 20);
            this.pnlCustomersCard.Name = "pnlCustomersCard";
            this.pnlCustomersCard.Size = new System.Drawing.Size(217, 74);
            this.pnlCustomersCard.TabIndex = 1;
            this.pnlCustomersCard.Click += new System.EventHandler(this.pnlCustomersCard_Click);
            // 
            // lblCustomersCount
            // 
            this.lblCustomersCount.AutoSize = true;
            this.lblCustomersCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomersCount.ForeColor = System.Drawing.Color.Black;
            this.lblCustomersCount.Location = new System.Drawing.Point(85, 44);
            this.lblCustomersCount.Name = "lblCustomersCount";
            this.lblCustomersCount.Size = new System.Drawing.Size(36, 25);
            this.lblCustomersCount.TabIndex = 1;
            this.lblCustomersCount.Text = "38";
            // 
            // lblCustomersCard
            // 
            this.lblCustomersCard.AutoSize = true;
            this.lblCustomersCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomersCard.ForeColor = System.Drawing.Color.Black;
            this.lblCustomersCard.Location = new System.Drawing.Point(78, 7);
            this.lblCustomersCard.Name = "lblCustomersCard";
            this.lblCustomersCard.Size = new System.Drawing.Size(56, 25);
            this.lblCustomersCard.TabIndex = 0;
            this.lblCustomersCard.Text = "العملاء";
            // 
            // pnlPartnersCard
            // 
            this.pnlPartnersCard.BackColor = System.Drawing.Color.SkyBlue;
            this.pnlPartnersCard.Controls.Add(this.lblPartnersCount);
            this.pnlPartnersCard.Controls.Add(this.lblPartnersCard);
            this.pnlPartnersCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlPartnersCard.Font = new System.Drawing.Font("Tahoma", 5F);
            this.pnlPartnersCard.Location = new System.Drawing.Point(821, 20);
            this.pnlPartnersCard.Name = "pnlPartnersCard";
            this.pnlPartnersCard.Size = new System.Drawing.Size(217, 74);
            this.pnlPartnersCard.TabIndex = 0;
            this.pnlPartnersCard.Click += new System.EventHandler(this.pnlPartnersCard_Click);
            // 
            // lblPartnersCount
            // 
            this.lblPartnersCount.AutoSize = true;
            this.lblPartnersCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartnersCount.ForeColor = System.Drawing.Color.Black;
            this.lblPartnersCount.Location = new System.Drawing.Point(79, 44);
            this.lblPartnersCount.Name = "lblPartnersCount";
            this.lblPartnersCount.Size = new System.Drawing.Size(36, 25);
            this.lblPartnersCount.TabIndex = 1;
            this.lblPartnersCount.Text = "12";
            // 
            // lblPartnersCard
            // 
            this.lblPartnersCard.AutoSize = true;
            this.lblPartnersCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartnersCard.ForeColor = System.Drawing.Color.Black;
            this.lblPartnersCard.Location = new System.Drawing.Point(63, 10);
            this.lblPartnersCard.Name = "lblPartnersCard";
            this.lblPartnersCard.Size = new System.Drawing.Size(62, 25);
            this.lblPartnersCard.TabIndex = 0;
            this.lblPartnersCard.Text = "الشركاء";
            // 
            // pnlLoginOverlay
            // 
            this.pnlLoginOverlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlLoginOverlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLoginOverlay.Location = new System.Drawing.Point(286, 35);
            this.pnlLoginOverlay.Name = "pnlLoginOverlay";
            this.pnlLoginOverlay.Size = new System.Drawing.Size(1133, 746);
            this.pnlLoginOverlay.TabIndex = 5;
            this.pnlLoginOverlay.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1419, 781);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.pnlLoginOverlay);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlHeader);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نظام إدارة المياه";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlMainContent.ResumeLayout(false);
            this.pnlMainContent.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlChart.ResumeLayout(false);
            this.pnlChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentTransactions)).EndInit();
            this.pnlKPICards.ResumeLayout(false);
            this.pnlRevenueCard.ResumeLayout(false);
            this.pnlRevenueCard.PerformLayout();
            this.pnlSalesCard.ResumeLayout(false);
            this.pnlSalesCard.PerformLayout();
            this.pnlCustomersCard.ResumeLayout(false);
            this.pnlCustomersCard.PerformLayout();
            this.pnlPartnersCard.ResumeLayout(false);
            this.pnlPartnersCard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.TreeView treeViewMain;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Panel pnlKPICards;
        private System.Windows.Forms.Panel pnlPartnersCard;
        private System.Windows.Forms.Label lblPartnersCard;
        private System.Windows.Forms.Label lblPartnersCount;
        private System.Windows.Forms.Panel pnlCustomersCard;
        private System.Windows.Forms.Label lblCustomersCard;
        private System.Windows.Forms.Label lblCustomersCount;
        private System.Windows.Forms.Panel pnlSalesCard;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.Label lblTotalSalesCount;
        private System.Windows.Forms.Panel pnlRevenueCard;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label lblTotalRevenueAmount;
        private System.Windows.Forms.Label lblRecentTransactions;
        private System.Windows.Forms.DataGridView dgvRecentTransactions;
        private System.Windows.Forms.Panel pnlChart;
        private System.Windows.Forms.Label lblChartTitle;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlLoginOverlay;
    }
}
