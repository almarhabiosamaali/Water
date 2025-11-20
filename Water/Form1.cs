using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Water
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.ShowDialog();
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            AccountForm accountForm = new AccountForm();
            accountForm.ShowDialog();
        }

        private void btnDowntime_Click(object sender, EventArgs e)
        {
            DowntimeForm downtimeForm = new DowntimeForm();
            downtimeForm.ShowDialog();
        }

        private void btnExpenses_Click(object sender, EventArgs e)
        {
            ExpenseForm expenseForm = new ExpenseForm();
            expenseForm.ShowDialog();
        }

        private void btnPeriods_Click(object sender, EventArgs e)
        {
            PeriodForm periodForm = new PeriodForm();
            periodForm.ShowDialog();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            SalesForm salesForm = new SalesForm();
            salesForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PricingForm tt = new PricingForm();
            tt.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PartnersForm pp = new PartnersForm();
            pp.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PartnerCostForm ppt = new PartnerCostForm();
            ppt.ShowDialog();
        }
    }
}
