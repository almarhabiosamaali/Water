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
        Clas.period period = new Clas.period();
        bool fromDateEntered = false;
        bool toDateEntered = false;
        public salesBillDTLRPT()
        {
            InitializeComponent();
            dtpFromDate.Format = DateTimePickerFormat.Custom;
            dtpFromDate.CustomFormat = " ";
            dtpToDate.Format = DateTimePickerFormat.Custom;
            dtpToDate.CustomFormat = " ";
            dtpFromDate.ValueChanged += dtpFromDate_ValueChanged;  
            dtpToDate.ValueChanged += dtpToDate_ValueChanged;
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
            List<string> conditions = new List<string>();

            DateTime? fromDate = null;
            DateTime? toDate = null;

            if (!string.IsNullOrEmpty(txtPeriodId.Text))
            {
                conditions.Add("s.period_id = '" + txtPeriodId.Text.Replace("'", "''") + "'");
            }

            if (!string.IsNullOrEmpty(txtBillNo.Text))
            {
                if (!string.IsNullOrEmpty(txtToBillNo.Text))
                {
                    conditions.Add("TRY_CAST(s.bill_no AS INT) >= " + txtBillNo.Text);
                    conditions.Add("TRY_CAST(s.bill_no AS INT) <= " + txtToBillNo.Text);
                }
                else
                {
                    conditions.Add("TRY_CAST(s.bill_no AS INT) = " + txtBillNo.Text);
                }
            }

            if (fromDateEntered)
                fromDate = dtpFromDate.Value.Date;

            if (toDateEntered)
                toDate = dtpToDate.Value.Date;

            if (fromDate != null && toDate != null)
            {
                conditions.Add(
                    "s.created_date BETWEEN '" +
                    fromDate.Value.ToString("yyyy-MM-dd") +
                    "' AND '" +
                    toDate.Value.ToString("yyyy-MM-dd") + "'"
                );
            }

            return string.Join(" AND ", conditions);
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
            txtBillNo.Text = row["bill_no"].ToString();
        }

        private void txtToBillNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 || e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // منع التنقل الافتراضي لـ Enter
                ShowToBillList();
            }
        }
        private void ShowToBillList()
        {
            DataTable dt = sales.GET_ALL_SALES();
            DataRow row = gridBtnViewHelper.Show(dt, "عرض  بيانات فواتير المبيعات الى رقم الفاتورة");
            if (row != null)
            {
                txtToBillNo.Text = row["bill_no"].ToString();
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
    }
}
