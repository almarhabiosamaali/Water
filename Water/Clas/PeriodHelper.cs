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
    public static class PeriodHelper
    {
        private static bool isShowing = false; // لمنع الاستدعاء المتكرر

        /// <summary>
        /// عرض قائمة الفترات وملء الحقول عند الاختيار
        /// </summary>
        /// <param name="periodIdTextBox">TextBox رقم الفترة</param>
        /// <param name="periodStartDateTextBox">TextBox بداية الفترة (اختياري - null إذا لم يكن موجود)</param>
        /// <param name="periodEndDateTextBox">TextBox نهاية الفترة (اختياري - null إذا لم يكن موجود)</param>
        public static void ShowPeriodsList(TextBox periodIdTextBox, TextBox periodStartDateTextBox = null, TextBox periodEndDateTextBox = null)
        {
            // منع الاستدعاء المتكرر
            if (isShowing)
                return;

            try
            {
                isShowing = true;
                period per = new period();
                DataTable dt = per.GET_ALL_PERIODS();
                
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد فترات للعرض", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Form viewForm = new Form();
                viewForm.Text = "اختر الفترة";
                viewForm.RightToLeft = RightToLeft.Yes;
                viewForm.RightToLeftLayout = true;
                viewForm.Size = new Size(800, 500);
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
                        LoadPeriodData(row, periodIdTextBox, periodStartDateTextBox, periodEndDateTextBox);
                        viewForm.Close();
                        // إزالة التركيز من TextBox لمنع استدعاء الأحداث مرة أخرى
                        if (periodIdTextBox != null && periodIdTextBox.CanFocus)
                        {
                            periodIdTextBox.Focus();
                        }
                    }
                };
                
                // إضافة إمكانية الاختيار بالضغط على Enter في DataGridView
                dgv.KeyDown += (s, args) =>
                {
                    if (args.KeyCode == Keys.Enter && dgv.CurrentRow != null && dgv.CurrentRow.Index >= 0)
                    {
                        DataRow row = dt.Rows[dgv.CurrentRow.Index];
                        LoadPeriodData(row, periodIdTextBox, periodStartDateTextBox, periodEndDateTextBox);
                        viewForm.Close();
                        if (periodIdTextBox != null && periodIdTextBox.CanFocus)
                        {
                            periodIdTextBox.Focus();
                        }
                    }
                };

                viewForm.Controls.Add(dgv);
                viewForm.ShowDialog();
                isShowing = false; // إعادة تعيين العلامة بعد إغلاق النافذة
            }
            catch (Exception ex)
            {
                isShowing = false; // إعادة تعيين العلامة في حالة الخطأ
                MessageBox.Show("حدث خطأ أثناء عرض الفترات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ملء بيانات الفترة في الحقول المحددة
        /// </summary>
        private static void LoadPeriodData(DataRow row, TextBox periodIdTextBox, TextBox periodStartDateTextBox, TextBox periodEndDateTextBox)
        {
            // ملء رقم الفترة
            if (periodIdTextBox != null)
            {
                periodIdTextBox.Text = row["id"] != DBNull.Value ? row["id"].ToString() : "";
            }
            
            // ملء بداية الفترة
            if (periodStartDateTextBox != null)
            {
                if (row["start_date"] != DBNull.Value)
                {
                    periodStartDateTextBox.Text = Convert.ToDateTime(row["start_date"]).ToString("dd/MM/yyyy");
                }
                else
                {
                    periodStartDateTextBox.Clear();
                }
            }
            
            // ملء نهاية الفترة
            if (periodEndDateTextBox != null)
            {
                if (row["end_date"] != DBNull.Value)
                {
                    periodEndDateTextBox.Text = Convert.ToDateTime(row["end_date"]).ToString("dd/MM/yyyy");
                }
                else
                {
                    periodEndDateTextBox.Clear();
                }
            }
        }
    }
}

