using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Water
{
    public partial class AmountTextBox: UserControl
    {
        public AmountTextBox()
        {
            InitializeComponent();

            
        txtAmount.Text = "0.00";
        txtAmount.TextAlign = HorizontalAlignment.Right;

        txtAmount.KeyPress += TxtAmount_KeyPress;
        txtAmount.Leave += TxtAmount_Leave;
        txtAmount.Enter += TxtAmount_Enter;
        txtAmount.Click += TxtAmount_Enter;

        }
        // خاصية لإرجاع/تعيين القيمة كـ double
        [Browsable(true)]
        public double Value
        {
            get
            {
                double.TryParse(txtAmount.Text, out double v);
                return v;
            }
            set
            {
                txtAmount.Text = value.ToString("N2");
            }
        }

        private void TxtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // السماح فقط بالأرقام و Backspace و النقطة
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }

            // منع إدخال نقطتين
            if (e.KeyChar == '.' && txtAmount.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void TxtAmount_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(txtAmount.Text, out double value))
            {
                txtAmount.Text = value.ToString("N2", System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                txtAmount.Text = "0.00";
            }
        }

        private void TxtAmount_Enter(object sender, EventArgs e)
        {
            txtAmount.SelectAll();
        }

        private void AmountTextBox_Load(object sender, EventArgs e)
        {

        }
    }
}

 /*

using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

public partial class AmountTextBox : UserControl
{
    public AmountTextBox()
    {
        InitializeComponent();

        txtAmount.Text = "0.00";
        txtAmount.TextAlign = HorizontalAlignment.Right;

        txtAmount.KeyPress += TxtAmount_KeyPress;
        txtAmount.Leave += TxtAmount_Leave;
        txtAmount.Enter += TxtAmount_Enter;
        txtAmount.Click += TxtAmount_Enter;
    }

    // خاصية لإرجاع/تعيين القيمة كـ double
    [Browsable(true)]
    public double Value
    {
        get
        {
            double.TryParse(txtAmount.Text, out double v);
            return v;
        }
        set
        {
            txtAmount.Text = value.ToString("N2");
        }
    }

    private void TxtAmount_KeyPress(object sender, KeyPressEventArgs e)
    {
        // السماح فقط بالأرقام و Backspace و النقطة
        if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b')
        {
            e.Handled = true;
        }

        // منع إدخال نقطتين
        if (e.KeyChar == '.' && txtAmount.Text.Contains("."))
        {
            e.Handled = true;
        }
    }

    private void TxtAmount_Leave(object sender, EventArgs e)
    {
        if (double.TryParse(txtAmount.Text, out double value))
        {
            txtAmount.Text = value.ToString("N2", CultureInfo.InvariantCulture);
        }
        else
        {
            txtAmount.Text = "0.00";
        }
    }

    private void TxtAmount_Enter(object sender, EventArgs e)
    {
        txtAmount.SelectAll();
    }
}
*/