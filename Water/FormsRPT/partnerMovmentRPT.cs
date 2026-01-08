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
        Clas.partners partners = new Clas.partners();
        Clas.period period = new Clas.period();
        Clas.GridBtnViewHelper gridBtnViewHelper = new Clas.GridBtnViewHelper();
        bool fromDateEntered = false;
        bool toDateEntered = false;
        public partnerMovmentRPT()
        {
            InitializeComponent();
            dtpFromDate.Format = DateTimePickerFormat.Custom;
            dtpFromDate.CustomFormat = " ";
            dtpToDate.Format = DateTimePickerFormat.Custom;
            dtpToDate.CustomFormat = " ";
            dtpFromDate.ValueChanged += dtpFromDate_ValueChanged;
            dtpToDate.ValueChanged += dtpToDate_ValueChanged;   
        }

        private void btnShowRPT_Click(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex == -1)
            {
                MessageBox.Show("يرجى اختيار نوع التقرير ");
                return;
            }

            if (string.IsNullOrEmpty(txtPeriodId.Text))
            {
                MessageBox.Show("يرجى اختيار الفتره " + cmbType.SelectedIndex.ToString());
                return;
            }




            if (cmbType.SelectedIndex == 1)
            {
                DataTable dTt = new DataTable();
                Clas.partnersReport pTp = new Clas.partnersReport();
                dTt = pTp.PRINT_ALL_PARTNER_MOVEMENT(p_where().ToString());
                RPT.partnerMovementDTL myRept = new RPT.partnerMovementDTL();
                myRept.DataSourceConnections[0].IntegratedSecurity = false;
                myRept.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.Password);
                myRept.SetDataSource(dTt);
                // myReport.SetParameterValue("@p_whr", p);
                RPT.reportCaller myFom = new RPT.reportCaller();
                myFom.crystalReportViewer1.ReportSource = myRept;
                myFom.ShowDialog();
            }
            else if (cmbType.SelectedIndex == 0)

            {
                DataTable dTt = new DataTable();
                Clas.partnersReport pTp = new Clas.partnersReport();
                dTt = pTp.PRINT_PARTNER_MOVEMENT(p_where().ToString(), txtPeriodId.Text);
                RPT.partnerMovements myRept = new RPT.partnerMovements();
                myRept.DataSourceConnections[0].IntegratedSecurity = false;
                myRept.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.Password);
                myRept.SetDataSource(dTt);
                // myReport.SetParameterValue("@p_whr", p);
                RPT.reportCaller myFom = new RPT.reportCaller();
                myFom.crystalReportViewer1.ReportSource = myRept;
                myFom.ShowDialog();
            }

            else if (cmbType.SelectedIndex == 2)
            {
                DataTable dTt = new DataTable();
                Clas.partnersReport pTp = new Clas.partnersReport();
                dTt = pTp.PRINT_PARTNER_MOVEMENT(p_where().ToString() , txtPeriodId.Text);
                RPT.partnerTotallHandM myRept = new RPT.partnerTotallHandM();
                myRept.DataSourceConnections[0].IntegratedSecurity = false;
                myRept.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.Password);
                myRept.SetDataSource(dTt);
                // myReport.SetParameterValue("@p_whr", p);
                RPT.reportCaller myFom = new RPT.reportCaller();
                myFom.crystalReportViewer1.ReportSource = myRept;
                myFom.ShowDialog();
            }

        }

        string p_where()
        {
            string p = "";
            DateTime? fromDate=null;
            DateTime? toDate=null;
             if (fromDateEntered)
                {
                    fromDate = dtpFromDate.Value.Date;
                }

                if (toDateEntered)
                {
                    toDate = dtpToDate.Value.Date;
                }
            if (cmbType.SelectedIndex == 1)
            {
                p = p + " and movement_type not in ('CUSTOMER_MOVEMENT','FROM_OWN_BALANCE','RECEIVED_FROM_OTHERS')";

                if (!string.IsNullOrEmpty(txtPeriodId.Text))
                {
                    p += " and period_id = '" + txtPeriodId.Text + "'";
                }


                if (!string.IsNullOrEmpty(txtPartnerID.Text))
                {
                    p = p + " and partner_no = '" + txtPartnerID.Text + "'";
                }

               

                if (fromDate != null && toDate != null)
                {
                    p += " and date between '"
                        + fromDate.Value.ToString("yyyy-MM-dd")
                        + "' and '"
                        + toDate.Value.ToString("yyyy-MM-dd")
                        + "'";
                }
            }

         else
            {

                if (!string.IsNullOrEmpty(txtPeriodId.Text))
                {
                    p += " and m.period_id = '" + txtPeriodId.Text + "'";
                }


                if (!string.IsNullOrEmpty(txtPartnerID.Text))
                {
                    p = p + " and m.partner_no = '" + txtPartnerID.Text + "'";
                }


                if (fromDate != null && toDate != null)
                {
                    p += " and m.date between '"
                        + fromDate.Value.ToString("yyyy-MM-dd")
                        + "' and '"
                        + toDate.Value.ToString("yyyy-MM-dd")
                        + "'";
                }
            }



            return p;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPartnerID_KeyDown(object sender, KeyEventArgs e)
        {
          if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // منع التنقل الافتراضي لـ Enter
                ShowPartnerList();
            }

        }
          private void ShowPartnerList()
        {            
            DataTable dt = partners.GET_ALL_PARTNERS("1");
            DataRow row = gridBtnViewHelper.Show(dt, "عرض  بيانات الشركاء");
            if (row != null)
            {
                LoadPartnerData(row);
            }
        }
     private void LoadPartnerData(DataRow row)
        {
            // ملء رقم الحساب/العميل/الشريك
            if (row["id"] != DBNull.Value)
            {
                txtPartnerID.Text = row["id"].ToString();
            }
            else
            {
                txtPartnerID.Clear();
            }
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
                dtpFromDate.Value = Convert.ToDateTime(row["start_date"]);
                dtpToDate.Value = Convert.ToDateTime(row["end_date"]);
            }
        }       
        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            fromDateEntered = true;
            dtpFromDate.Format = DateTimePickerFormat.Short;
        }
        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            toDateEntered = true;
            dtpToDate.Format = DateTimePickerFormat.Short;
        }
    }
}
