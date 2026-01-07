using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace Water.Clas
{
    public class GridBtnViewHelper
    {           
        public  DataRow Show(DataTable dt,string title = "عرض البيانات")
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("لا توجد بيانات للعرض", "معلومة",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            DataRow selectedRow = null;

            Form viewForm = new Form();
            viewForm.Text = title;
            viewForm.RightToLeft = RightToLeft.Yes;
            viewForm.RightToLeftLayout = true;
            viewForm.Size = new Size(1200, 600);
            viewForm.StartPosition = FormStartPosition.CenterScreen;

            // ================== شريط البحث ==================
            FlowLayoutPanel searchPanel = new FlowLayoutPanel();
            searchPanel.Dock = DockStyle.Top;
            searchPanel.Height = 50;
            searchPanel.Padding = new Padding(10);
            searchPanel.FlowDirection = FlowDirection.RightToLeft;
            searchPanel.WrapContents = false;
            searchPanel.RightToLeft = RightToLeft.No;

            Label lblSearch = new Label();
            lblSearch.Text = "بحث:";
            lblSearch.AutoSize = true;            
            lblSearch.TextAlign = ContentAlignment.MiddleRight;
            lblSearch.Margin = new Padding(5, 10, 5, 0);
            lblSearch.RightToLeft = RightToLeft.Yes;

            TextBox txtSearch = new TextBox();
            txtSearch.Width = 250;
            txtSearch.RightToLeft = RightToLeft.Yes;
            txtSearch.Margin = new Padding(5, 7, 5, 0);
            viewForm.Shown += (s, e) =>
                {
                    txtSearch.Focus();
                };

            searchPanel.Controls.Add(lblSearch);
            searchPanel.Controls.Add(txtSearch);
            // =================================================

            DataView dv = new DataView(dt);

            DataGridView dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            dgv.DataSource = dv;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.RightToLeft = RightToLeft.Yes;

            // البحث
            txtSearch.TextChanged += (s, e) =>
            {
                try
                {
                    string text = txtSearch.Text.Trim();
                    if (string.IsNullOrEmpty(text))
                    {
                        dv.RowFilter = "";
                        return;
                    }

                    List<string> filters = new List<string>();
                    string esc = text.Replace("'", "''");

                    foreach (DataColumn col in dt.Columns)
                    {
                        filters.Add($"CONVERT([{col.ColumnName}], System.String) LIKE '%{esc}%'");
                    }

                    dv.RowFilter = string.Join(" OR ", filters);
                }
                catch
                {
                    dv.RowFilter = "";
                }
            };

            // اختيار الصف
            dgv.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    selectedRow = ((DataRowView)dgv.Rows[e.RowIndex].DataBoundItem).Row;
                    viewForm.Close();
                }
            };

            dgv.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter && dgv.CurrentRow != null)
                {
                    selectedRow = ((DataRowView)dgv.CurrentRow.DataBoundItem).Row;
                    viewForm.Close();
                }
            };

            viewForm.Controls.Add(dgv);
            viewForm.Controls.Add(searchPanel);
            viewForm.ShowDialog();

            return selectedRow;
        }
    }

}
