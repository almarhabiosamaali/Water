using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Water
{
    public partial class Form1 : Form
    {
        Clas.partners partners = new Clas.partners();
        Clas.customer customer = new Clas.customer();
        Clas.sales sales = new Clas.sales();
        Clas.partner_cost_mst partner_cost_mst = new Clas.partner_cost_mst();
        Clas.period period = new Clas.period();
        Clas.downtime downtime = new Clas.downtime();
        Clas.expense expense = new Clas.expense();
        Clas.pricing pricing = new Clas.pricing();

        // معلومات المستخدم المسجل دخوله
        public string LoggedInUserId { get; private set; }
        public string LoggedInUserName { get; private set; }
        public string LoggedInUserType { get; private set; }

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // إظهار Panel رمادي شفاف يغطي Form1 بالكامل
            pnlLoginOverlay.Visible = true;
            pnlLoginOverlay.BringToFront();

            // عرض شاشة تسجيل الدخول كـ modal popup في الوسط
            LoginForm loginForm = new LoginForm();
            loginForm.StartPosition = FormStartPosition.CenterParent;
            
            DialogResult result = loginForm.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                // تسجيل الدخول ناجح
                LoggedInUserId = loginForm.LoggedInUserId;
                LoggedInUserName = loginForm.LoggedInUserName;
                LoggedInUserType = loginForm.LoggedInUserType;

                // تحديث اسم المستخدم في الـ Header
                if (!string.IsNullOrEmpty(LoggedInUserName))
                {
                    lblUser.Text = LoggedInUserName;
                }

                // إخفاء Panel الرمادي
                pnlLoginOverlay.Visible = false;

                // تحميل البيانات
                LoadDashboardData();
                InitializeMainTree();
                
                // إضافة حدث للتحقق من الشاشات المفتوحة عند إغلاق أي شاشة
                this.MdiChildActivate += Form1_MdiChildActivate;
            }
            else
            {
                // تم الإلغاء أو فشل تسجيل الدخول - إغلاق التطبيق
                Application.Exit();
            }
        }
        
        // حدث يتم استدعاؤه عند تغيير الشاشة النشطة أو إغلاق شاشة
        private void Form1_MdiChildActivate(object sender, EventArgs e)
        {
            // التحقق من عدم وجود شاشات مفتوحة
            if (this.MdiChildren.Length == 0)
            {
                pnlMainContent.Visible = true;
            }
        }

        // تهيئة الشجرة الرئيسية
        private void InitializeMainTree()
        {
            treeViewMain.Nodes.Clear();
            
            // عقدة التهيئة
            TreeNode initNode = new TreeNode("التهيئة");
            initNode.Tag = "INIT_ROOT";
            
            TreeNode periodNode = new TreeNode("الفترات");
            periodNode.Tag = "PERIOD";
            initNode.Nodes.Add(periodNode);
            
            TreeNode pricingNode = new TreeNode("التسعيرة");
            pricingNode.Tag = "PRICING";
            initNode.Nodes.Add(pricingNode);
            
            TreeNode partnersNode = new TreeNode("بيانات الشركاء");
            partnersNode.Tag = "PARTNERS";
            initNode.Nodes.Add(partnersNode);
            
            TreeNode customersNode = new TreeNode("بيانات العملاء");
            customersNode.Tag = "CUSTOMERS";
            initNode.Nodes.Add(customersNode);
            
            TreeNode accountsNode = new TreeNode("بيانات الحسابات");
            accountsNode.Tag = "ACCOUNTS";
            initNode.Nodes.Add(accountsNode);
            
            // عقدة العمليات
            TreeNode operationsNode = new TreeNode("العمليات");
            operationsNode.Tag = "OPERATIONS_ROOT";
            
            TreeNode salesInvoiceNode = new TreeNode("فاتورة المبيعات");
            salesInvoiceNode.Tag = "SALES_INVOICE";
            operationsNode.Nodes.Add(salesInvoiceNode);
            
            TreeNode voucherNode = new TreeNode("السندات");
            voucherNode.Tag = "VOUCHER";
            operationsNode.Nodes.Add(voucherNode);
            
            TreeNode downtimeNode = new TreeNode("التوقفات");
            downtimeNode.Tag = "DOWNTIME";
            operationsNode.Nodes.Add(downtimeNode);
            
            TreeNode costAllocationNode = new TreeNode("توزيع التكاليف");
            costAllocationNode.Tag = "COST_ALLOCATION";
            operationsNode.Nodes.Add(costAllocationNode);
            
            // عقدة التقارير
            TreeNode reportsNode = new TreeNode("التقارير");
            reportsNode.Tag = "REPORTS_ROOT";
            
            TreeNode partnerReportNode = new TreeNode("تقارير الشركاء");
            partnerReportNode.Tag = "PARTNER_REPORT";
            reportsNode.Nodes.Add(partnerReportNode);
            
            TreeNode customerReportNode = new TreeNode("تقارير العملاء");
            customerReportNode.Tag = "CUSTOMER_REPORT";
            reportsNode.Nodes.Add(customerReportNode);
            
            TreeNode movementReportNode = new TreeNode("تقارير الحركة");
            movementReportNode.Tag = "MOVEMENT_REPORT";
            reportsNode.Nodes.Add(movementReportNode);
            
            TreeNode salesReportNode = new TreeNode("تقارير المبيعات");
            salesReportNode.Tag = "SALES_REPORT";
            reportsNode.Nodes.Add(salesReportNode);
            
            // إضافة جميع العقد الرئيسية
            treeViewMain.Nodes.Add(initNode);
            treeViewMain.Nodes.Add(operationsNode);
            treeViewMain.Nodes.Add(reportsNode);
            
        }

        // تحميل بيانات Dashboard (حقيقية من قاعدة البيانات)
        private void LoadDashboardData()
        {
            try
            {
                // تحميل عدد الشركاء
                DataTable partnersDt = partners.GET_ALL_PARTNERS();
                int partnersCount = partnersDt != null ? partnersDt.Rows.Count : 0;
                lblPartnersCount.Text = partnersCount.ToString();

                // تحميل عدد العملاء
                DataTable customersDt = customer.GET_ALL_CUSTOMERS();
                int customersCount = customersDt != null ? customersDt.Rows.Count : 0;
                lblCustomersCount.Text = customersCount.ToString();

                // تحميل بيانات المبيعات
                DataTable salesDt = sales.GET_ALL_SALES();
                int salesCount = salesDt != null ? salesDt.Rows.Count : 0;
                lblTotalSalesCount.Text = salesCount.ToString();

                // حساب إجمالي الإيرادات
                double totalRevenue = 0;
                if (salesDt != null && salesDt.Rows.Count > 0)
                {
                    foreach (DataRow row in salesDt.Rows)
                    {
                        if (row["total_amount"] != DBNull.Value)
                        {
                            double amount = 0;
                            if (double.TryParse(row["total_amount"].ToString(), out amount))
                            {
                                totalRevenue += amount;
                            }
                        }
                    }
                }
                lblTotalRevenueAmount.Text = FormatNumber(totalRevenue);

                // تحميل بيانات المعاملات الأخيرة
                LoadRecentTransactions(salesDt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل بيانات Dashboard: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // دالة لتنسيق الأرقام بفواصل الآلاف
        private string FormatNumber(double value)
        {
            return value.ToString("N0", new CultureInfo("en-US"));
        }

        // تحميل المعاملات الأخيرة
        private void LoadRecentTransactions(DataTable salesData)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Date", typeof(string));
                dt.Columns.Add("Customer", typeof(string));
                dt.Columns.Add("Amount", typeof(string));
                dt.Columns.Add("Remaining Amount", typeof(string));

                if (salesData != null && salesData.Rows.Count > 0)
                {
                    // ترتيب البيانات حسب التاريخ (الأحدث أولاً) واختيار آخر 5 معاملات
                    DataView dv = new DataView(salesData);
                    dv.Sort = "created_date DESC";
                    DataTable sortedDt = dv.ToTable();

                    int count = Math.Min(5, sortedDt.Rows.Count); // آخر 5 معاملات
                    for (int i = 0; i < count; i++)
                    {
                        DataRow row = sortedDt.Rows[i];
                        string date = row["created_date"] != DBNull.Value 
                            ? Convert.ToDateTime(row["created_date"]).ToString("yyyy-MM-dd") 
                            : "";
                        string customerName = row["cus_part_name"] != DBNull.Value 
                            ? row["cus_part_name"].ToString() 
                            : "";
                        string amount = row["total_amount"] != DBNull.Value 
                            ? FormatNumber(Convert.ToDouble(row["total_amount"])) 
                            : "0.00";
                        string remainingAmount = row["remaining_amount"] != DBNull.Value && 
                        Convert.ToDouble(row["remaining_amount"]) > 0 ? FormatNumber(Convert.ToDouble(row["remaining_amount"])) 
                            : "0.00";

                        dt.Rows.Add(date, customerName, amount, remainingAmount);
                    }
                }

                dgvRecentTransactions.DataSource = dt;
                dgvRecentTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل المعاملات الأخيرة: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // دالة مساعدة لفتح النماذج كـ MDI Children
        private void OpenFormAsMDI(Form form, Panel menuItem)
        {
            try
            {
                // إغلاق النموذج المفتوح مسبقاً إذا كان موجوداً
                foreach (Form childForm in this.MdiChildren)
                {
                    if (childForm.GetType() == form.GetType())
                    {
                        childForm.Activate();
                        childForm.BringToFront();
                        return;
                    }
                }

                // تعديل إعدادات النموذج ليعمل كـ MDI Child
                // يجب تعيين MdiParent أولاً قبل أي إعدادات أخرى
                form.MdiParent = this;
                form.FormBorderStyle = FormBorderStyle.Sizable;
                form.MaximizeBox = true;
                form.MinimizeBox = true;
                form.StartPosition = FormStartPosition.Manual; // تغيير StartPosition
                form.WindowState = FormWindowState.Maximized;
                
                // إضافة حدث FormClosed لإظهار Dashboard عند إغلاق الشاشة
                form.FormClosed += (s, args) =>
                {
                    // استخدام BeginInvoke لتنفيذ الكود بعد إغلاق النموذج بالكامل
                    this.BeginInvoke(new Action(() =>
                    {
                        // التحقق من عدم وجود شاشات أخرى مفتوحة
                        if (this.MdiChildren.Length == 0)
                        {
                            pnlMainContent.Visible = true;
                        }
                    }));
                };
                
                // إخفاء Dashboard عند فتح النموذج
                pnlMainContent.Visible = false;
                
                form.Show();
                form.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء فتح النموذج: " + ex.Message + "\n\n" + ex.StackTrace, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // حدث اختيار عقدة في الشجرة الرئيسية
        private void treeViewMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null)
                return;

            string nodeTag = e.Node.Tag.ToString();
            
            // تجاهل العقد الرئيسية (ROOT nodes)
            if (nodeTag.Contains("_ROOT") || nodeTag == "INIT_ROOT" || nodeTag == "OPERATIONS_ROOT" || nodeTag == "REPORTS_ROOT")
                return;

            Form formToOpen = null;

            switch (nodeTag)
            {
                // التهيئة
                case "PERIOD":
                    formToOpen = new PeriodForm();
                    break;
                case "PRICING":
                    formToOpen = new PricingForm();
                    break;
                case "PARTNERS":
                    formToOpen = new PartnersForm();
                    break;
                case "CUSTOMERS":
                    formToOpen = new CustomerForm();
                    break;
                case "ACCOUNTS":
                    formToOpen = new AccountForm();
                    break;
                
                // العمليات
                case "SALES_INVOICE":
                    formToOpen = new SalesForm();
                    break;
                case "VOUCHER":
                    formToOpen = new ExpenseForm();
                    break;
                case "DOWNTIME":
                    formToOpen = new DowntimeForm();
                    break;
                case "COST_ALLOCATION":
                    formToOpen = new PartnerCostForm();
                    break;
                
                // التقارير
                case "PARTNER_REPORT":
                    formToOpen = new partnerMovmentRPT();
                    break;
                case "CUSTOMER_REPORT":
                    formToOpen = new customerMovementRPT();
                    break;
                case "MOVEMENT_REPORT":
                    formToOpen = new allMovementRPT();
                    break;
                case "SALES_REPORT":
                    formToOpen = new salesBillDTLRPT();
                    break;
            }

            if (formToOpen != null)
            {
                OpenFormAsMDI(formToOpen, null);
            }
        }

        // أحداث إضافية للوصول السريع من KPI Cards
        private void pnlPartnersCard_Click(object sender, EventArgs e)
        {
            // البحث عن عقدة الشركاء وفتحها
            foreach (TreeNode node in treeViewMain.Nodes)
            {
                if (node.Tag != null && node.Tag.ToString() == "INIT_ROOT")
                {
                    foreach (TreeNode childNode in node.Nodes)
                    {
                        if (childNode.Tag != null && childNode.Tag.ToString() == "PARTNERS")
                        {
                            treeViewMain.SelectedNode = childNode;
                            treeViewMain_AfterSelect(treeViewMain, new TreeViewEventArgs(childNode));
                            break;
                        }
                    }
                    break;
                }
            }
        }

        private void pnlCustomersCard_Click(object sender, EventArgs e)
        {
            // البحث عن عقدة العملاء وفتحها
            foreach (TreeNode node in treeViewMain.Nodes)
            {
                if (node.Tag != null && node.Tag.ToString() == "INIT_ROOT")
                {
                    foreach (TreeNode childNode in node.Nodes)
                    {
                        if (childNode.Tag != null && childNode.Tag.ToString() == "CUSTOMERS")
                        {
                            treeViewMain.SelectedNode = childNode;
                            treeViewMain_AfterSelect(treeViewMain, new TreeViewEventArgs(childNode));
                            break;
                        }
                    }
                    break;
                }
            }
        }

        private void pnlSalesCard_Click(object sender, EventArgs e)
        {
            // البحث عن عقدة فاتورة المبيعات وفتحها
            foreach (TreeNode node in treeViewMain.Nodes)
            {
                if (node.Tag != null && node.Tag.ToString() == "OPERATIONS_ROOT")
                {
                    foreach (TreeNode childNode in node.Nodes)
                    {
                        if (childNode.Tag != null && childNode.Tag.ToString() == "SALES_INVOICE")
                        {
                            treeViewMain.SelectedNode = childNode;
                            treeViewMain_AfterSelect(treeViewMain, new TreeViewEventArgs(childNode));
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }
}
