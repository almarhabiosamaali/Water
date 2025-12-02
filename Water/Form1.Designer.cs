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
            this.pnlReports = new System.Windows.Forms.Panel();
            this.treeViewReports = new System.Windows.Forms.TreeView();
            this.lblReports = new System.Windows.Forms.Label();
            this.pnlSales = new System.Windows.Forms.Panel();
            this.lblSales = new System.Windows.Forms.Label();
            this.pnlCustomers = new System.Windows.Forms.Panel();
            this.lblCustomers = new System.Windows.Forms.Label();
            this.pnlPartners = new System.Windows.Forms.Panel();
            this.lblPartners = new System.Windows.Forms.Label();
            this.pnlDashboard = new System.Windows.Forms.Panel();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.pnlMainContent = new System.Windows.Forms.Panel();
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlHeader.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlReports.SuspendLayout();
            this.pnlSales.SuspendLayout();
            this.pnlCustomers.SuspendLayout();
            this.pnlPartners.SuspendLayout();
            this.pnlDashboard.SuspendLayout();
            this.pnlMainContent.SuspendLayout();
            this.pnlChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentTransactions)).BeginInit();
            this.pnlKPICards.SuspendLayout();
            this.pnlRevenueCard.SuspendLayout();
            this.pnlSalesCard.SuspendLayout();
            this.pnlCustomersCard.SuspendLayout();
            this.pnlPartnersCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.pnlHeader.Size = new System.Drawing.Size(1242, 35);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(1200, 9);
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
            this.lblTitle.Location = new System.Drawing.Point(12, 2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(151, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "نظام إدارة المياه";
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.White;
            this.pnlSidebar.Controls.Add(this.pnlSales);
            this.pnlSidebar.Controls.Add(this.treeViewReports);
            this.pnlSidebar.Controls.Add(this.pnlCustomers);
            this.pnlSidebar.Controls.Add(this.pnlPartners);
            this.pnlSidebar.Controls.Add(this.pnlDashboard);
            this.pnlSidebar.Controls.Add(this.pnlReports);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 35);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(250, 746);
            this.pnlSidebar.TabIndex = 1;
            // 
            // pnlReports
            // 
            this.pnlReports.BackColor = System.Drawing.Color.White;
            this.pnlReports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlReports.Controls.Add(this.lblReports);
            this.pnlReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlReports.Location = new System.Drawing.Point(3, 255);
            this.pnlReports.Name = "pnlReports";
            this.pnlReports.Size = new System.Drawing.Size(243, 41);
            this.pnlReports.TabIndex = 4;
            this.pnlReports.Click += new System.EventHandler(this.pnlReports_Click);
            // 
            // treeViewReports
            // 
            this.treeViewReports.BackColor = System.Drawing.Color.White;
            this.treeViewReports.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewReports.FullRowSelect = true;
            this.treeViewReports.HideSelection = false;
            this.treeViewReports.Location = new System.Drawing.Point(3, 303);
            this.treeViewReports.Name = "treeViewReports";
            this.treeViewReports.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.treeViewReports.RightToLeftLayout = true;
            this.treeViewReports.Size = new System.Drawing.Size(243, 41);
            this.treeViewReports.TabIndex = 6;
            this.treeViewReports.Visible = false;
            this.treeViewReports.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewReports_AfterSelect);
            // 
            // lblReports
            // 
            this.lblReports.AutoSize = true;
            this.lblReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReports.Location = new System.Drawing.Point(183, 0);
            this.lblReports.Name = "lblReports";
            this.lblReports.Size = new System.Drawing.Size(55, 24);
            this.lblReports.TabIndex = 0;
            this.lblReports.Text = "التقارير";
            this.lblReports.Click += new System.EventHandler(this.pnlReports_Click);
            // 
            // pnlSales
            // 
            this.pnlSales.BackColor = System.Drawing.Color.White;
            this.pnlSales.Controls.Add(this.lblSales);
            this.pnlSales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlSales.Location = new System.Drawing.Point(0, 200);
            this.pnlSales.Name = "pnlSales";
            this.pnlSales.Size = new System.Drawing.Size(250, 50);
            this.pnlSales.TabIndex = 3;
            this.pnlSales.Click += new System.EventHandler(this.pnlSales_Click);
            // 
            // lblSales
            // 
            this.lblSales.AutoSize = true;
            this.lblSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSales.Location = new System.Drawing.Point(190, 15);
            this.lblSales.Name = "lblSales";
            this.lblSales.Size = new System.Drawing.Size(60, 24);
            this.lblSales.TabIndex = 0;
            this.lblSales.Text = "المبيعات";
            this.lblSales.Click += new System.EventHandler(this.pnlSales_Click);
            // 
            // pnlCustomers
            // 
            this.pnlCustomers.BackColor = System.Drawing.Color.White;
            this.pnlCustomers.Controls.Add(this.lblCustomers);
            this.pnlCustomers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCustomers.Location = new System.Drawing.Point(0, 150);
            this.pnlCustomers.Name = "pnlCustomers";
            this.pnlCustomers.Size = new System.Drawing.Size(250, 50);
            this.pnlCustomers.TabIndex = 2;
            this.pnlCustomers.Click += new System.EventHandler(this.pnlCustomers_Click);
            // 
            // lblCustomers
            // 
            this.lblCustomers.AutoSize = true;
            this.lblCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomers.Location = new System.Drawing.Point(190, 15);
            this.lblCustomers.Name = "lblCustomers";
            this.lblCustomers.Size = new System.Drawing.Size(51, 24);
            this.lblCustomers.TabIndex = 0;
            this.lblCustomers.Text = "العملاء";
            this.lblCustomers.Click += new System.EventHandler(this.pnlCustomers_Click);
            // 
            // pnlPartners
            // 
            this.pnlPartners.BackColor = System.Drawing.Color.White;
            this.pnlPartners.Controls.Add(this.lblPartners);
            this.pnlPartners.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlPartners.Location = new System.Drawing.Point(0, 100);
            this.pnlPartners.Name = "pnlPartners";
            this.pnlPartners.Size = new System.Drawing.Size(250, 50);
            this.pnlPartners.TabIndex = 1;
            this.pnlPartners.Click += new System.EventHandler(this.pnlPartners_Click);
            // 
            // lblPartners
            // 
            this.lblPartners.AutoSize = true;
            this.lblPartners.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartners.Location = new System.Drawing.Point(190, 15);
            this.lblPartners.Name = "lblPartners";
            this.lblPartners.Size = new System.Drawing.Size(56, 24);
            this.lblPartners.TabIndex = 0;
            this.lblPartners.Text = "الشركاء";
            this.lblPartners.Click += new System.EventHandler(this.pnlPartners_Click);
            // 
            // pnlDashboard
            // 
            this.pnlDashboard.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlDashboard.Controls.Add(this.lblDashboard);
            this.pnlDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlDashboard.Location = new System.Drawing.Point(0, 50);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Size = new System.Drawing.Size(250, 50);
            this.pnlDashboard.TabIndex = 0;
            this.pnlDashboard.Click += new System.EventHandler(this.pnlDashboard_Click);
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboard.ForeColor = System.Drawing.Color.White;
            this.lblDashboard.Location = new System.Drawing.Point(160, 15);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(80, 24);
            this.lblDashboard.TabIndex = 0;
            this.lblDashboard.Text = "لوحة التحكم";
            this.lblDashboard.Click += new System.EventHandler(this.pnlDashboard_Click);
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.pnlMainContent.Controls.Add(this.pictureBox1);
            this.pnlMainContent.Controls.Add(this.pnlChart);
            this.pnlMainContent.Controls.Add(this.dgvRecentTransactions);
            this.pnlMainContent.Controls.Add(this.lblRecentTransactions);
            this.pnlMainContent.Controls.Add(this.pnlKPICards);
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(250, 35);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMainContent.Size = new System.Drawing.Size(992, 746);
            this.pnlMainContent.TabIndex = 2;
            // 
            // pnlChart
            // 
            this.pnlChart.BackColor = System.Drawing.Color.White;
            this.pnlChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChart.Controls.Add(this.lblChartTitle);
            this.pnlChart.Location = new System.Drawing.Point(20, 339);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(350, 280);
            this.pnlChart.TabIndex = 3;
            // 
            // lblChartTitle
            // 
            this.lblChartTitle.AutoSize = true;
            this.lblChartTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartTitle.Location = new System.Drawing.Point(55, 4);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.Size = new System.Drawing.Size(194, 25);
            this.lblChartTitle.TabIndex = 0;
            this.lblChartTitle.Text = "نظرة عامة على المبيعات";
            // 
            // dgvRecentTransactions
            // 
            this.dgvRecentTransactions.AllowUserToAddRows = false;
            this.dgvRecentTransactions.AllowUserToDeleteRows = false;
            this.dgvRecentTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentTransactions.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentTransactions.Location = new System.Drawing.Point(379, 339);
            this.dgvRecentTransactions.Name = "dgvRecentTransactions";
            this.dgvRecentTransactions.ReadOnly = true;
            this.dgvRecentTransactions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvRecentTransactions.RowHeadersWidth = 51;
            this.dgvRecentTransactions.RowTemplate.Height = 24;
            this.dgvRecentTransactions.Size = new System.Drawing.Size(607, 280);
            this.dgvRecentTransactions.TabIndex = 2;
            // 
            // lblRecentTransactions
            // 
            this.lblRecentTransactions.AutoSize = true;
            this.lblRecentTransactions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecentTransactions.Location = new System.Drawing.Point(791, 311);
            this.lblRecentTransactions.Name = "lblRecentTransactions";
            this.lblRecentTransactions.Size = new System.Drawing.Size(142, 25);
            this.lblRecentTransactions.TabIndex = 1;
            this.lblRecentTransactions.Text = "المعاملات الأخيرة";
            // 
            // pnlKPICards
            // 
            this.pnlKPICards.Controls.Add(this.pnlRevenueCard);
            this.pnlKPICards.Controls.Add(this.pnlSalesCard);
            this.pnlKPICards.Controls.Add(this.pnlCustomersCard);
            this.pnlKPICards.Controls.Add(this.pnlPartnersCard);
            this.pnlKPICards.Location = new System.Drawing.Point(23, 189);
            this.pnlKPICards.Name = "pnlKPICards";
            this.pnlKPICards.Size = new System.Drawing.Size(949, 119);
            this.pnlKPICards.TabIndex = 0;
            // 
            // pnlRevenueCard
            // 
            this.pnlRevenueCard.BackColor = System.Drawing.Color.SkyBlue;
            this.pnlRevenueCard.Controls.Add(this.lblTotalRevenueAmount);
            this.pnlRevenueCard.Controls.Add(this.lblTotalRevenue);
            this.pnlRevenueCard.Font = new System.Drawing.Font("Tahoma", 5F);
            this.pnlRevenueCard.Location = new System.Drawing.Point(20, 20);
            this.pnlRevenueCard.Name = "pnlRevenueCard";
            this.pnlRevenueCard.Size = new System.Drawing.Size(190, 74);
            this.pnlRevenueCard.TabIndex = 3;
            // 
            // lblTotalRevenueAmount
            // 
            this.lblTotalRevenueAmount.AutoSize = true;
            this.lblTotalRevenueAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRevenueAmount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalRevenueAmount.Location = new System.Drawing.Point(52, 36);
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
            this.lblTotalRevenue.Location = new System.Drawing.Point(36, 0);
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
            this.pnlSalesCard.Location = new System.Drawing.Point(255, 20);
            this.pnlSalesCard.Name = "pnlSalesCard";
            this.pnlSalesCard.Size = new System.Drawing.Size(190, 74);
            this.pnlSalesCard.TabIndex = 2;
            this.pnlSalesCard.Click += new System.EventHandler(this.pnlSalesCard_Click);
            // 
            // lblTotalSalesCount
            // 
            this.lblTotalSalesCount.AutoSize = true;
            this.lblTotalSalesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSalesCount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalSalesCount.Location = new System.Drawing.Point(65, 42);
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
            this.lblTotalSales.Location = new System.Drawing.Point(43, 7);
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
            this.pnlCustomersCard.Location = new System.Drawing.Point(486, 20);
            this.pnlCustomersCard.Name = "pnlCustomersCard";
            this.pnlCustomersCard.Size = new System.Drawing.Size(190, 74);
            this.pnlCustomersCard.TabIndex = 1;
            this.pnlCustomersCard.Click += new System.EventHandler(this.pnlCustomersCard_Click);
            // 
            // lblCustomersCount
            // 
            this.lblCustomersCount.AutoSize = true;
            this.lblCustomersCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomersCount.ForeColor = System.Drawing.Color.Black;
            this.lblCustomersCount.Location = new System.Drawing.Point(74, 44);
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
            this.lblCustomersCard.Location = new System.Drawing.Point(68, 7);
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
            this.pnlPartnersCard.Location = new System.Drawing.Point(718, 20);
            this.pnlPartnersCard.Name = "pnlPartnersCard";
            this.pnlPartnersCard.Size = new System.Drawing.Size(190, 74);
            this.pnlPartnersCard.TabIndex = 0;
            this.pnlPartnersCard.Click += new System.EventHandler(this.pnlPartnersCard_Click);
            // 
            // lblPartnersCount
            // 
            this.lblPartnersCount.AutoSize = true;
            this.lblPartnersCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartnersCount.ForeColor = System.Drawing.Color.Black;
            this.lblPartnersCount.Location = new System.Drawing.Point(69, 44);
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
            this.lblPartnersCard.Location = new System.Drawing.Point(55, 10);
            this.lblPartnersCard.Name = "lblPartnersCard";
            this.lblPartnersCard.Size = new System.Drawing.Size(62, 25);
            this.lblPartnersCard.TabIndex = 0;
            this.lblPartnersCard.Text = "الشركاء";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Water.Properties.Resources.logoWell;
            this.pictureBox1.Location = new System.Drawing.Point(250, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(447, 189);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 781);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlHeader);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نظام إدارة المياه";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlReports.ResumeLayout(false);
            this.pnlReports.PerformLayout();
            this.pnlSales.ResumeLayout(false);
            this.pnlSales.PerformLayout();
            this.pnlCustomers.ResumeLayout(false);
            this.pnlCustomers.PerformLayout();
            this.pnlPartners.ResumeLayout(false);
            this.pnlPartners.PerformLayout();
            this.pnlDashboard.ResumeLayout(false);
            this.pnlDashboard.PerformLayout();
            this.pnlMainContent.ResumeLayout(false);
            this.pnlMainContent.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlDashboard;
        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Panel pnlPartners;
        private System.Windows.Forms.Label lblPartners;
        private System.Windows.Forms.Panel pnlCustomers;
        private System.Windows.Forms.Label lblCustomers;
        private System.Windows.Forms.Panel pnlSales;
        private System.Windows.Forms.Label lblSales;
        private System.Windows.Forms.Panel pnlReports;
        private System.Windows.Forms.Label lblReports;
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
        private System.Windows.Forms.TreeView treeViewReports;
        private System.Windows.Forms.PictureBox pictu    }
}
