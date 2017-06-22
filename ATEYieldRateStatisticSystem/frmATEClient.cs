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

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(p.TestlogPath.Trim()))
            {
                MessageBox.Show("TestlogPath 不能为空,请点击'Setting'按钮设置路径", "TestlogPath Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTestlogPath.SelectAll();
                txtTestlogPath.Focus();
                return;
            }
        }






        /// <summary>
        /// 檢測WebService的可連通性,可連通返回true，不可連通，返回false
        /// </summary>
        /// <param name="website">WebService的地址</param>
        /// <returns>可連通返回true，不可連通返回false</returns>
        public bool checkWebService(string website)
        {
            Stopwatch sw = new Stopwatch();
            TimeSpan ts = new TimeSpan();
            sw.Start();
            updateMsg(lstStatus, "Start Check WebService");
            //SubFunction.saveLog(Param.logType.SYSLOG.ToString(), "Check Web Service");

            if (p.ATEPlant == p.PlantCode.F721)
                ws.Url = p.SFCS721Webservice;
            if (p.ATEPlant == p.PlantCode.F722)
                ws.Url = p.SFCS722Webservice;
   
            try
            {
                Application.DoEvents();
                ws.Discover();
            }
            catch (Exception e)
            {
                sw.Stop();
                ts = sw.Elapsed;
                updateMsg(lstStatus, "Can't connect WebService,Used time(ms):" + ts.Milliseconds);
                updateMsg(lstStatus, e.Message);

                // SubFunction.saveLog(Param.logType.SYSLOG.ToString(), "Check Web Service NG,Used time(ms):" + ts.Milliseconds + "\r\n" + "Message:".PadLeft(24) + e.Message);

                return false;
            }
            sw.Stop();
            ts = sw.Elapsed;
            //SubFunction.updateMessage(lstStatusCommand, "Check Web Service OK,Used time(ms):" + ts.Milliseconds);
            updateMsg(lstStatus, "Connect WebService success,Used time(ms):" + ts.Milliseconds);
            //SubFunction.saveLog(Param.logType.SYSLOG.ToString(), "Check Web Service OK,Used time(ms):" + ts.Milliseconds);
            return true;
        }

        /// <summary>
        /// 檢查USN站別是否在當前站別,在為true，不在為false
        /// </summary>
        /// <param name="usn">條碼</param>
        /// <param name="stage">站別</param>
        /// <returns>在當前站別為true，不在當前站別為false</returns>
        private bool checkStage(string usn, string stage)
        {

            //  checkWebService(web_Site);

            Stopwatch sw = new Stopwatch();
            TimeSpan ts = new TimeSpan();
            sw.Start();
            //SubFunction.updateMessage(lstStatusCommand, "SFCS:" + usn + ",Stage:" + stage);
            updateMsg(lstStatus, "SFCS:" + usn + ",Stage:" + stage);
            // SubFunction.saveLog(Param.logType.SYSLOG.ToString(), "SFCS:" + usn + ",Stage:" + stage);
            string result = ws.CheckRoute(usn, stage);
            sw.Stop();
            ts = sw.Elapsed;
            if (result.ToUpper() == "OK")
            {
                // SubFunction.updateMessage(lstStatusCommand, result + "Used time(ms):" + ts.Milliseconds);
                updateMsg(lstStatus, result + "Used time(ms):" + ts.Milliseconds);
                //  SubFunction.saveLog(Param.logType.SYSLOG.ToString(), "usn:" + usn + "->" + stage);

                return true;
            }
            else
            {
                // SubFunction.updateMessage(lstStatusCommand, result + "Used time(ms):" + ts.Milliseconds);
                updateMsg(lstStatus, result + "Used time(ms):" + ts.Milliseconds);
                //SubFunction.saveLog(Param.logType.SYSLOG.ToString(), result + "Used time(ms):" + ts.Milliseconds);
                // SubFunction.saveLog(Param.logType.SYSLOG.ToString(), result + "Used time(ms):" + ts.Milliseconds);
                return false;
            }
        }

        private void updateMsg(ListBox listbox, string message)
        {
            if (listbox.Items.Count > 1024)
            {
                //listbox.Items.Clear();
                listbox.Items.RemoveAt(0);
            }
            //SkinListBoxItem item = new SkinListBoxItem();
            string item = string.Empty;
            item = DateTime.Now.ToString("HH:mm:ss") + "->" + @message;

            this.Invoke((EventHandler)(delegate
            {
                listbox.Items.Add(item);
            }));


            if (listbox.Items.Count > 1)
            {
                listbox.TopIndex = listbox.Items.Count - 1;
                listbox.SetSelected(listbox.Items.Count - 1, true);
            }
        }
    }
}
