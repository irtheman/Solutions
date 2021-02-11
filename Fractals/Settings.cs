using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractals
{
    public partial class Settings : Form
    {
        private Form1 parent;

        public Settings(Form1 frm)
        {
            InitializeComponent();

            parent = frm;
            nudMax.Value = parent.MaxIterations;
            txtReal.Text = parent.Z0.Real.ToString();
            txtImag.Text = parent.Z0.Imaginary.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parent.MaxIterations = (int) nudMax.Value;
            
            double real, imag;
            double.TryParse(txtReal.Text, out real);
            double.TryParse(txtImag.Text, out imag);
            parent.Z0 = new Complex(real, imag);

            Close();
        }
    }
}
