using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.Services;
using System.Diagnostics;
using System.IO;
using Edward;

namespace ATEYieldRateStatisticSystem
{
    public partial class frmATEClient : Form
    {
        public frmATEClient()
        {
            InitializeComponent();
            skinEngine1.SkinFile =p.AppFolder + @"\MacOS.ssk";
        }

        SFCS_ws.WebService ws = new SFCS_ws.WebService();


        #region 窗体放大缩小

        private float X;
        private float Y;

        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                    setTag(con);
            }
        }
        private void setControls(float newx, float newy, Control cons)
        {
            foreach (Control con in cons.Controls)
            {

                string[] mytag = con.Tag.ToString().Split(new char[] { ':' });
                float a = Convert.ToSingle(mytag[0]) * newx;
                con.Width = (int)a;
                a = Convert.ToSingle(mytag[1]) * newy;
                con.Height = (int)(a);
                a = Convert.ToSingle(mytag[2]) * newx;
                con.Left = (int)(a);
                a = Convert.ToSingle(mytag[3]) * newy;
                con.Top = (int)(a);
                Single currentSize = Convert.ToSingle(mytag[4]) * Math.Min(newx, newy);
                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                if (con.Controls.Count > 0)
                {
                    setControls(newx, newy, con);
                }
            }

        }

        void Form1_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / X;
            float newy = this.Height / Y;
            setControls(newx, newy, this);
            // this.Text = this.Width.ToString() + " " + this.Height.ToString();

        }

        #endregion

        private void frmATEClient_Load(object sender, EventArgs e)
        {
            //窗体放大缩小
            this.Resize += new EventHandler(Form1_Resize);
            X = this.Width;
            Y = this.Height;
            setTag(this);
            Form1_Resize(new object(), new EventArgs());//x,y可在实例化时赋值,最后这句是新加的，在MDI时有用

            //
            txtAutoLookLogPath.Text = p.AutoLookLogPath;
            txtTestlogPath.Text = p.TestlogPath;

            if (p.ATEPlant == p.PlantCode.F721)
                txtCurrentWebService.Text = p.SFCS721Webservice;
            if (p.ATEPlant == p.PlantCode.F722)
                txtCurrentWebService.Text = p.SFCS722Webservice;
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            Form f = new frmATEClientSetting();
            f.ShowDialog();
        }

        private void txtAutoLookLogPath_DoubleClick(object sender, EventArgs e)
        {
            p.openFolder(txtAutoLookLogPath);
            if (string.IsNullOrEmpty(txtAutoLookLogPath.Text.Trim()))
                return;
            else
            {
                string inipath = txtAutoLookLogPath.Text.Trim() + @"\path.ini";
                if (System.IO.File.Exists(inipath))
                {
                    string line = string.Empty;
                    string boardpath = string.Empty;

                    StreamReader sr = new StreamReader(inipath);
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        if (!line.StartsWith("!"))
                        {
                            if (line.ToUpper().Contains("#BoardPath#".ToUpper()))
                            {
                                boardpath = line.Replace("#BoardPath#:", "");
                                p.TestlogPath = boardpath + @"testlog\";
                                txtTestlogPath.Text = p.TestlogPath;

                            }
                        }
                    }
                    sr.Close();
                }
                else
                {
                    MessageBox.Show("Can't find 'path.ini' file,may be u select a wrong folder.", "Can't Find File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAutoLookLogPath.SelectAll();
                    this.txtAutoLookLogPath.Focus();
                    return;
                }

            }
        }

        private void txtAutoLookLogPath_TextChanged(object sender, EventArgs e)
        {
            p.AutoLookLogPath = this.txtAutoLookLogPath.Text.Trim();
            IniFile.IniWriteValue(p.IniSection.ATEConfig.ToString(), "AutoLookLogPath", p.AutoLookLogPath, p.iniFilePath);
        }

        private void txtTestlogPath_TextChanged(object sender, EventArgs e)
        {
            p.TestlogPath = this.txtTestlogPath.Text.Trim();
            IniFile.IniWriteValue(p.IniSection.ATEConfig.ToString(), "TestlogPath", p.TestlogPath, p.iniFilePath);
        }

        private void txtTestlogPath_DoubleClick(object sender, EventArgs e)
        {
            p.openFolder(txtTestlogPath);
        }

        private void frmATEClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to exit the program?if YES,the test data will not be collected by the program...", "Exit or Not", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else
                e.Cancel = true;
            
        }
    }
}
