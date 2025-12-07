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
    public partial class SetServer : Form
    {
        public SetServer()
        {

            InitializeComponent();
            txtServer.Text = Properties.Settings.Default.Server;
            txtDatabase.Text = Properties.Settings.Default.Database;
            txtID.Text = Properties.Settings.Default.ID;
            txtPWD.Text = Properties.Settings.Default.Password;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.Server = txtServer.Text;
            Properties.Settings.Default.Database = txtDatabase.Text;
            
            Properties.Settings.Default.ID = txtID.Text;
            Properties.Settings.Default.Password = txtPWD.Text;
            
            Properties.Settings.Default.Save();
            MessageBox.Show("تم الحفظ بنجاح");
        }
    }
}
