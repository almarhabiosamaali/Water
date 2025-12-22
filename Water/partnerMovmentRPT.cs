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
        public partnerMovmentRPT()
        {
            InitializeComponent();
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
                RPT.partnerMovementDTL1 myRept = new RPT.partnerMovementDTL1();
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

            else if (cmbType.SelectedIndex == 2)
            {
                DataTable dTt = new DataTable();
                Clas.partnersReport pTp = new Clas.partnersReport();
                dTt = pTp.PRINT_PARTNER_MOVEMENT(p_where().ToString());
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
                

                if (dtpFromDate.Value != null && dtpToDate.Value != null)
                {
                    p += " and date between '"
                        + dtpFromDate.Value.ToString("yyyy-MM-dd")
                        + "' and '"
                        + dtpToDate.Value.ToString("yyyy-MM-dd")
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


                if (dtpFromDate.Value != null && dtpToDate.Value != null)
                {
                    p += " and m.date between '"
                        + dtpFromDate.Value.ToString("yyyy-MM-dd")
                        + "' and '"
                        + dtpToDate.Value.ToString("yyyy-MM-dd")
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
            try
            {
            
                DataTable dt = partners.GET_ALL_PARTNERS();
                String formTitle = "عرض بيانات الشركاء";

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات للعرض", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Form viewForm = new Form();
                viewForm.Text = formTitle;
                viewForm.RightToLeft = RightToLeft.Yes;
                viewForm.RightToLeftLayout = true;
                viewForm.Size = new Size(1200, 600);
                viewForm.StartPosition = FormStartPosition.CenterScreen;

                DataGridView dgv = new DataGridView();
                dgv.Dock = DockStyle.Fill;
                dgv.DataSource = dt;
                dgv.ReadOnly = true;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.MultiSelect = false;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.RightToLeft = RightToLeft.Yes;

                dgv.CellDoubleClick += (s, args) =>
                {
                    if (args.RowIndex >= 0)
                    {
                        DataRow row = dt.Rows[args.RowIndex];
                        LoadPartnerData(row);
                        viewForm.Close();
                    }
                };
                dgv.KeyDown += (s, args) =>
                {
                    if (args.KeyCode == Keys.Enter && dgv.CurrentRow != null && dgv.CurrentRow.Index >= 0)
                    {
                        DataRow row = dt.Rows[dgv.CurrentRow.Index];
                        LoadPartnerData(row);
                        viewForm.Close();
                    }
                };

                viewForm.Controls.Add(dgv);
                viewForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء عرض البيانات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
