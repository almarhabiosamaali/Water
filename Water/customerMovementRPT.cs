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
    public partial class customerMovementRPT : Form
    {
        public customerMovementRPT()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            DataTable dTt = new DataTable();
            Clas.allReportRPT pTp = new Clas.allReportRPT();
            dTt = pTp.PRINT_CUSTOMER_MOVEMENT(p_where().ToString());
            RPT.customerMovementDTL myRept = new RPT.customerMovementDTL();
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

    }
}
