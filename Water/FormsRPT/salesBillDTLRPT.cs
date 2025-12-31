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
    public partial class salesBillDTLRPT : Form
    {
        Clas.sales sales = new Clas.sales();
        Clas.GridBtnViewHelper gridBtnViewHelper = new Clas.GridBtnViewHelper();
        public salesBillDTLRPT()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            DataTable dTt = new DataTable();
            Clas.allReportRPT pTp = new Clas.allReportRPT();
            dTt = pTp.PRINT_SALES_BILL(p_where().ToString());
            RPT.salesBillDTL myRept = new RPT.salesBillDTL();
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
            if (!string.IsNullOrEmpty(txtBillNO.Text))
            {
                p = p + " s.bill_no = '" + txtBillNO.Text + "'";
            }

            return p;
        } 


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBillNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // منع التنقل الافتراضي لـ Enter
                ShowBillList();
            }
        }
        private void ShowBillList()
        {
            DataTable dt = sales.GET_ALL_SALES();
            DataRow row = gridBtnViewHelper.Show(dt, "عرض  بيانات فواتير المبيعات");
            if (row != null)
            {
                LoadBillData(row);
            }
        }
        private void LoadBillData(DataRow row)
        {
            txtBillNO.Text = row["bill_no"].ToString();
        }
    }
}
