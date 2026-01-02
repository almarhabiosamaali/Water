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
        Clas.partners partners = new Clas.partners();
        Clas.account account = new Clas.account();
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
            try
            {
                // التحقق من نوع الحساب المحدد
                if (cmbAccountType.SelectedIndex == -1)
                {
                    MessageBox.Show("الرجاء اختيار نوع الحساب أولاً", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string accountType = cmbAccountType.SelectedItem.ToString();
                DataTable dt = null;
                string formTitle = "";

                // تحديد نوع البيانات بناءً على اختيار نوع الحساب
                if (accountType == "عميل")
                {
                    dt = customer.GET_ALL_CUSTOMERS();
                    //formTitle = "عرض بيانات العملاء";
                    DataRow row = gridBtnViewHelper.Show(dt, "عرض  بيانات العملاء");
                    if (row != null)
                    {
                        LoadCustomerData(row);
                    }
                }
                else if (accountType == "شريك")
                {
                    dt = partners.GET_ALL_PARTNERS();
                    //formTitle = "عرض بيانات الشركاء";
                    DataRow row = gridBtnViewHelper.Show(dt, "عرض  بيانات الشركاء");
                    if (row != null)
                    {
                        LoadPartnerData(row);
                    }
                }
                else if (accountType == "حساب")
                {
                    dt = account.GET_ALL_ACCOUNTS();
                    //formTitle = "عرض بيانات الحسابات";
                    DataRow row = gridBtnViewHelper.Show(dt, "عرض  بيانات الحسابات");
                    if (row != null)
                    {
                        LoadAccountData(row);
                    }
                }
                else
                {
                    MessageBox.Show("نوع الحساب غير معروف", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات للعرض", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء عرض البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadCustomerData(DataRow row)
        {
            txtCustNo.Text = row["id"].ToString();
        }
        private void LoadPartnerData(DataRow row)
        {
            txtCustNo.Text = row["id"].ToString();
        }
        private void LoadAccountData(DataRow row)
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
