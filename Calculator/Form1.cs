using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCong_Click(object sender, EventArgs e)
        {
            int a, b, ketQua;
            a = int.Parse(txtSTN.Text);
            b = int.Parse(txtSTH.Text);
            Calculation c = new Calculation(a,b);
            ketQua = c.Execute("+");
            txtKQ.Text = ketQua.ToString();
        }

        private void btnLuyThua_Click(object sender, EventArgs e)
        {
            int n;
            double x, ketQua;
            n = int.Parse(txtSTH.Text);
            x = int.Parse(txtSTN.Text);

            ketQua = Calculation.Power(x, n);
            txtKQ.Text = ketQua.ToString();
        }
    }
}
