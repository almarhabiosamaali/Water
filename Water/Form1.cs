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
        private Panel currentActivePanel = null; // لتتبع العنصر النشط في القائمة
        Clas.partners partners = new Clas.partners();
        Clas.customer customer = new Clas.customer();
        Clas.sales sales = new Clas.sales();
        Clas.partner_cost_mst partner_cost_mst = new Clas.partner_cost_mst();
        Clas.period period = new Clas.period();
        Clas.downtime downtime = new Clas.downtime();
        Clas.expense expense = new Clas.expense();
        Clas.pricing pricing = new Clas.pricing();

        public Form1()
        {
            InitializeComponent();
            LoadDashboardData();
            InitializeReportsTree();
        }

        // تهيئة شجرة التقارير
        private void InitializeReportsTree()
        {
            treeViewReports.Nodes.Clear();
            
            // إضافة عقدة رئيسية "التقارير"
            TreeNode rootNode = new TreeNode("التقارير");
            rootNode.Tag = "ROOT"; 
            
            // إضافة تقارير الشركاء
            TreeNode partnerReportNode = new TreeNode("تقارير الشركاء");
            partnerReportNode.Tag = "PARTNER_REPORT";
            rootNode.Nodes.Add(partnerReportNode);
            
            // إضافة تقارير الحركة
            TreeNode movementReportNode = new TreeNode("تقارير الحركة");
            movementReportNode.Tag = "MOVEMENT_REPORT";
            rootNode.Nodes.Add(movementReportNode);
            
            // إضافة تقارير العملاء
            TreeNode customerReportNode = new TreeNode("تقارير العملاء");
            customerReportNode.Tag = "CUSTOMER_REPORT";
            rootNode.Nodes.Add(customerReportNode);

            // إضافة تقارير المبيعات
            TreeNode salesBillNode = new TreeNode("تقارير المبيعات");
            salesBillNode.Tag = "SALES_REPORT";
            rootNode.Nodes.Add(salesBillNode);

            treeViewReports.Nodes.Add(rootNode);
            rootNode.Expand(); // توسيع العقدة الرئيسية
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
                        SetActiveMenuItem(menuItem);
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
                
                // إخفاء Dashboard عند فتح النموذج
                pnlMainContent.Visible = false;
                
                form.Show();
                form.BringToFront();
                SetActiveMenuItem(menuItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء فتح النموذج: " + ex.Message + "\n\n" + ex.StackTrace, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // تعيين العنصر النشط في القائمة
        private void SetActiveMenuItem(Panel menuItem)
        {
            // إزالة التمييز من العنصر السابق
            if (currentActivePanel != null)
            {
                currentActivePanel.BackColor = Color.White;
                // تحديث لون النص للعنصر السابق
                foreach (Control ctrl in currentActivePanel.Controls)
                {
                    if (ctrl is Label)
                    {
                        ctrl.ForeColor = Color.Black;
                    }
                }
            }

            // تمييز العنصر الجديد
            if (menuItem != null)
            {
                menuItem.BackColor = Color.FromArgb(59, 130, 246); // أزرق
                // تحديث لون النص للعنصر الجديد
                foreach (Control ctrl in menuItem.Controls)
                {
                    if (ctrl is Label)
                    {
                        ctrl.ForeColor = Color.White;
                    }
                }
                currentActivePanel = menuItem;
            }
        }

        // أحداث القائمة
        private void pnlDashboard_Click(object sender, EventArgs e)
        {
            // إغلاق جميع النماذج المفتوحة
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
            // إظهار Dashboard
            pnlMainContent.Visible = true;
            SetActiveMenuItem(pnlDashboard);
        }

        private void pnlPartners_Click(object sender, EventArgs e)
        {
            PartnersForm form = new PartnersForm();
            OpenFormAsMDI(form, pnlPartners);
        }

        private void pnlCustomers_Click(object sender, EventArgs e)
        {
            CustomerForm form = new CustomerForm();
            OpenFormAsMDI(form, pnlCustomers);
        }

        private void pnlSales_Click(object sender, EventArgs e)
        {
            SalesForm form = new SalesForm();
            OpenFormAsMDI(form, pnlSales);
        }

        private void pnlReports_Click(object sender, EventArgs e)
        {
            // إظهار/إخفاء شجرة التقارير
            if (treeViewReports.Visible)
            {
                // إخفاء الشجرة
                treeViewReports.Visible = false;
                treeViewReports.Height = 0;
                // نقل pnlSettings إلى موقعه الأصلي
                //pnlSettings.Location = new Point(0, 300);
            }
            else
            {
                // إظهار الشجرة
                treeViewReports.Visible = true;
                // حساب ارتفاع الشجرة بناءً على عدد العقد
                int treeHeight = treeViewReports.Nodes[0].GetNodeCount(true) * 25 + 20; // 25 بكسل لكل عقدة + 20 للهامش
                treeViewReports.Height = treeHeight;
                // نقل pnlSettings لأسفل
              //  pnlSettings.Location = new Point(0, 300 + treeHeight);
            }
        }

        // حدث اختيار عقدة في شجرة التقارير
        private void treeViewReports_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null || e.Node.Tag.ToString() == "ROOT")
                return;

            string reportType = e.Node.Tag.ToString();
            Form reportForm = null;

            switch (reportType)
            {
                case "PARTNER_REPORT":
                    reportForm = new partnerMovmentRPT();
                    break;
                case "MOVEMENT_REPORT":
                    reportForm = new allMovementRPT();
                    break;
                case "CUSTOMER_REPORT":
                    reportForm = new customerMovementRPT();
                    break;
                case "SALES_REPORT":
                    reportForm = new salesBillDTLRPT();
                    break;
            }

            if (reportForm != null)
            {
                reportForm.MdiParent = this;
                reportForm.FormBorderStyle = FormBorderStyle.Sizable;
                reportForm.MaximizeBox = true;
                reportForm.MinimizeBox = true;
                reportForm.StartPosition = FormStartPosition.Manual;
                reportForm.WindowState = FormWindowState.Maximized;
                pnlMainContent.Visible = false;
                reportForm.Show();
                reportForm.BringToFront();
            }
        }

        private void pnlSettings_Click(object sender, EventArgs e)
        {
            // يمكن فتح نافذة الإعدادات
            MessageBox.Show("الإعدادات", "الإعدادات", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // أحداث إضافية للوصول السريع من KPI Cards
        private void pnlPartnersCard_Click(object sender, EventArgs e)
        {
            pnlPartners_Click(sender, e);
        }

        private void pnlCustomersCard_Click(object sender, EventArgs e)
        {
            pnlCustomers_Click(sender, e);
        }

        private void pnlSalesCard_Click(object sender, EventArgs e)
        {
            pnlSales_Click(sender, e);
        }
    }
}
