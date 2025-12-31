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
    public partial class allMovementRPT : Form
    {
        Clas.customer customer = new Clas.customer();
        Clas.period period = new Clas.period();
        Clas.GridBtnViewHelper gridBtnViewHelper = new Clas.GridBtnViewHelper();
        public allMovementRPT()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            DataTable dTt = new DataTable();
            Clas.allReportRPT pTp = new Clas.allReportRPT();
            dTt = pTp.PRINT_ALL_MOVEMENT(p_where().ToString());
            RPT.allMovementDTL myRept = new RPT.allMovementDTL();
            myRept.DataSourceConnections[0].IntegratedSecurity = false;
            myRept.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.Password);
            myRept.SetDataSource(dTt);
            // myReport.SetParameterValue("@p_whr", p);
            RPT.reportCaller myFom = new RPT.reportCaller();
            myFom.crystalReportViewer1.ReportSource = myRept;
            myFom.ShowDialog();
        }

        string p_where()
        {
            string p = "";

            if (!string.IsNullOrEmpty(txtCustNo.Text))
            {
                p += " and cus_part_no = '" + txtCustNo.Text + "'";
            }
            if (!string.IsNullOrEmpty(txtPeriodId.Text))
            {
                p += " and period_id = '" + txtPeriodId.Text + "'";
            }

            if (dtpFromDate.Value != null && dtpToDate.Value != null)
            {
                p += " and date between '"
                    + dtpFromDate.Value.ToString("yyyy-MM-dd")
                    + "' and '"
                    + dtpToDate.Value.ToString("yyyy-MM-dd")
                    + "'";
            }

            return p;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCustNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // منع التنقل الافتراضي لـ Enter
                ShowCustomerList();
            }   
        }
        private void ShowCustomerList()
        {
            DataTable dt = customer.GET_ALL_CUSTOMERS();
            DataRow row = gridBtnViewHelper.Show(dt, "عرض  بيانات العملاء");
            if (row != null)
            {
                LoadCustomerData(row);
            }
        }
        private void LoadCustomerData(DataRow row)
        {
            txtCustNo.Text = row["id"].ToString();
        }
        private void txtPeriodId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // منع التنقل الافتراضي لـ Enter
                ShowPeriodList();
            }
        }
        private void ShowPeriodList()
        {
            DataTable dt = period.GET_ALL_PERIODS();
            DataRow row = gridBtnViewHelper.Show(dt, "عرض  بيانات الفترات");
            if (row != null)
            {
                txtPeriodId.Text = row["id"].ToString();
            }
        }
        private void LoadPeriodData(DataRow row)
        {
            txtPeriodId.Text = row["id"].ToString();
        }
    }
}
