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
    public partial class frmYRServer : Form
    {
        public frmYRServer()
        {
            InitializeComponent();
            skinEngine1.SkinFile = p.AppFolder + @"\MacOS.ssk";
        }

        private void frmYRServer_Load(object sender, EventArgs e)
        {

        }
    }
}
