using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATEYieldRateStatisticSystem
{
    public partial class frmATEYR : Form
    {
        public frmATEYR()
        {
            InitializeComponent();
        }

        private void frmATEYR_Load(object sender, EventArgs e)
        {
            //new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //label5.Font = new System.Drawing.Font("Agency FB", FontStyle.Bold);
            label5.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.ForeColor = Color.Green;
            textBox1.ReadOnly = true;
            
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
