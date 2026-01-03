using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace Water
{
    public partial class Cust_Account_FRM : Form
    {
        public Cust_Account_FRM()
        {
            InitializeComponent();
        }

        private void Cust_Account_FRM_Load(object sender, EventArgs e)
        {
           
            var rpt = new Cust_AccountPROC();   // هذا الكلاس يجب أن يكون متولّد أوتوماتيك
                                                // لو عندك DataSet أو DataTable:
                                                // rpt.SetDataSource(myDataTableOrDataSet);
            crystalReportViewer1.ReportSource = rpt;
        }
    }

   
}
