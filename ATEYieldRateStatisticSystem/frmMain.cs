using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Edward;

namespace ATEYieldRateStatisticSystem
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            skinEngine1.SkinFile = p.AppFolder + @"\MacOS.ssk";
            this.Text = "First run,select the application run model...(Ver:" + Application.ProductVersion + ")";
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void btnYRServer_Click(object sender, EventArgs e)
        {
            p.AppStart = p.AppStartModel.YRServer;
            IniFile.IniWriteValue(p.IniSection.SysConfig.ToString(), "AppStart", p.AppStart.ToString(), p.iniFilePath);
            this.Hide();
            Form f = new frmYRServer();
            f.Show();
        }

        private void btnATEClient_Click(object sender, EventArgs e)
        {
            p.AppStart = p.AppStartModel.ATEClient;
            IniFile.IniWriteValue(p.IniSection.SysConfig.ToString(), "AppStart", p.AppStart.ToString(), p.iniFilePath);
            this.Hide();
            Form  f = new frmATEClient();
            f.Show();
        }

        private void btnFTClient_Click(object sender, EventArgs e)
        {

        }
    }
}
