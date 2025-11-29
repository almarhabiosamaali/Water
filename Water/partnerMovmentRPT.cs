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
    public partial class partnerMovmentRPT : Form
    {
        public partnerMovmentRPT()
        {
            InitializeComponent();
        }

        private void btnShowRPT_Click(object sender, EventArgs e)
        {
            if (anly.Checked)
            {
                DataTable dTt = new DataTable();
                Clas.partnersReport pTp = new Clas.partnersReport();
                dTt = pTp.PRINT_ALL_PARTNER_MOVEMENT(p_where().ToString());
                RPT.movementsDTL myRept = new RPT.movementsDTL();
                myRept.DataSourceConnections[0].IntegratedSecurity = false;
                myRept.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.Password);
                myRept.SetDataSource(dTt);
                // myReport.SetParameterValue("@p_whr", p);
                RPT.reportCaller myFom = new RPT.reportCaller();
                myFom.crystalReportViewer1.ReportSource = myRept;
                myFom.ShowDialog();
            }
            else
            {
                DataTable dTt = new DataTable();
                Clas.partnersReport pTp = new Clas.partnersReport();
                dTt = pTp.PRINT_PARTNER_MOVEMENT(p_where().ToString());
                RPT.partnerMovements myRept = new RPT.partnerMovements();
                myRept.DataSourceConnections[0].IntegratedSecurity = false;
                myRept.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.Password);
                myRept.SetDataSource(dTt);
                // myReport.SetParameterValue("@p_whr", p);
                RPT.reportCaller myFom = new RPT.reportCaller();
                myFom.crystalReportViewer1.ReportSource = myRept;
                myFom.ShowDialog();
            }
            
        }

        string p_where ()
        {
            string p = "";
            if (anly.Checked)
            {
                p = p + " and movement_type not in ('CUSTOMER_MOVEMENT')";
                if (txtPartnerID.Text != "")
                    p = p + " and partner_no = '" + txtPartnerID.Text + "'";
            }
            else
            {
                if (txtPartnerID.Text != "")
                    p = p + " and m.partner_no = '" + txtPartnerID.Text + "'";
            }
            
            

            return p;
        }
    }
}
