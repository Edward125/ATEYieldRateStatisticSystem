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
using System.Resources;
using System.Reflection;
using System.Threading;
using MySql.Data.MySqlClient;

namespace ATEYieldRateStatisticSystem
{
    public partial class frmATEClient : Form
    {
        public frmATEClient()
        {
            InitializeComponent();
            skinEngine1.SkinFile = p.AppFolder + @"\MacOS.ssk";
        }

        public SFCS_ws.WebService ws = new SFCS_ws.WebService();
        bool _connnectWebservice = false; //connect web service result,success=true;fail = false;
        private int TimeoutMillis = 1000; //定时器触发间隔
        System.Threading.Timer m_timer = null;
        List<String> files = new List<string>(); //AutoLog记录待处理文件的队列


        double yr = 0;
        double fpy = 0;



        ///// <summary>
        ///// 防止頁面閃爍
        ///// </summary>
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;
        //        return cp;
        //    }
        //}



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
            try
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
            catch (Exception)
            {

                //throw;
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
           // MessageBox.Show(DateTime.Now.ToString("yyyyMMddHHmmss"));
            loadUI();

          

            if (string.IsNullOrEmpty(txtAutoLookLogPath.Text.Trim()))
                return;
            else
            {
                string inipath = txtAutoLookLogPath.Text.Trim() + @"\path.ini";
                if (System.IO.File.Exists(inipath))
                {
                    getTestlogPathFromAutoLog(inipath);
                }
                else
                {
                    MessageBox.Show("Can't find 'path.ini' file,may be u select a wrong folder.", "Can't Find File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAutoLookLogPath.SelectAll();
                    this.txtAutoLookLogPath.Focus();
                    return;
                }

            }

            PressStartButton();

           // updateFPY();
        }

        /// <summary>
        /// 
        /// </summary>
        private void loadConfig()
        {
            //
            txtAutoLookLogPath.Text = p.AutoLookLogPath;
            txtTestlogPath.Text = p.TestlogPath;
            if (p.ATEPlant == p.PlantCode.F721)
                txtCurrentWebService.Text = p.SFCS721Webservice;
            if (p.ATEPlant == p.PlantCode.F722)
                txtCurrentWebService.Text = p.SFCS722Webservice;
        }



        private void loadUI()
        {
            //窗体放大缩小
            this.Resize += new EventHandler(Form1_Resize);
            X = this.Width;
            Y = this.Height;
            setTag(this);
            Form1_Resize(new object(), new EventArgs());//x,y可在实例化时赋值,最后这句是新加的，在MDI时有用

            string username = Environment.MachineName;

            if (username.Contains('-'))
                p.PCBLine = username.Substring(0, username.LastIndexOf('-'));


            this.Text = Application.ProductName + "-ATE Client...(Ver:" + Application.ProductVersion + ")" + "-" + username + "(Line:" + p.PCBLine + "),IP:" + p.getIP(username, p.IPType.IPV4)[0];

            notifyIcon1.Text = Application.ProductName + "-ATE Client...(Ver:" + Application.ProductVersion + ")";


            txtAutoLookLogPath.SetWatermark("DbClick here to select AutoLookIyet config file folder path...");
            txtTestlogPath.SetWatermark("DbClick here to select ATE test program testlog file folder path...");
            InitListviewBarcode(lstviewBarcode);
            loadConfig();
            tsslStartTime.Text = "StartTime:" + DateTime.Now.ToString("MM-dd HH:mm:ss") + ",";

            //lblModelFPY.ForeColor = Color.Red;
            //

            p.InitATEStageInfo();

            string result = "";
            bool isConnect = p.checkSqlDBIsConnect(p.connString, out result);
            checkSqlDBUIChange(isConnect, result);
    

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            Form f = new frmATEClientSetting();
            //f.ShowDialog();
            if (f.ShowDialog(this) != DialogResult.OK)
                loadConfig();

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
                    getTestlogPathFromAutoLog(inipath);
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

        private void getTestlogPathFromAutoLog(string inipath)
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
                        if (boardpath.EndsWith(@"\"))
                            p.TestlogPath = boardpath + @"testlog\";
                        else
                            p.TestlogPath = boardpath + @"\testlog\";
                        txtTestlogPath.Text = p.TestlogPath;
                    }
                }
            }
            sr.Close();

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
                try
                {
                    Environment.Exit(0);
                }
                catch (Exception)
                {
                    // throw;
                }

            }
            else
                e.Cancel = true;

        }

        private void btnRun_Click(object sender, EventArgs e)
        {       
            if (!PressStartButton())
                return;
#if DEBUG
            return;
            string message = @"SFCF00002: Route error, Please go to PA - PACKING";
            message = @"SFCF01434: Unit: CN0HWGWKWSC007750NASA01 already StoreIn!";
            string stage = p.GetStage(message);
            updateMsg(lstStatus, message + "-->" + stage);
            foreach (var item in p.ATEAfterStage )
            {
                updateMsg(lstStatus, item.StageName + ":" + item.StageValue);
                if (stage == item.StageName)
                {
                    MessageBox.Show("Stage:" + stage + "," + item.StageValue);
                    break;
                }
            }



            //string file1 = @"D:\Edward\ATEYieldRateStatisticSystem\log_140517.log";
            //string[] temp = File.ReadAllLines(file1);
            //MessageBox.Show(temp[temp.Length - 1]);

            return;
            p.Delay(200);
            SFCS_ws.clsRequestData rq = new SFCS_ws.clsRequestData();
            GetUUData("CN063JCXWSC0076Q08LCA01", out rq);
            txtModel.Text = rq.Model;
            tsslModel.Text = "Model:" + rq.Model;
            txtProjectCode.Text = rq.ModelFamily;
            //tsslModelFamily.Text = "ModelFamily:" + rq.ModelFamily;
            txtMO.Text = rq.MO;
            //tsslMO.Text = "MO:" + rq.MO;
            txtUPN.Text = rq.UPN;
            tsslUPN.Text = "UPN:" + rq.UPN;

            //
            string result, bara, barb;
            result = bara = barb = "";

            getLinkUsn("CN0RY2Y1WSC0076Q0DTIA01", out result, out bara, out barb);
            updateMsg(lstStatus, "result:" + result);
            updateMsg(lstStatus, "bara:" + bara);
            updateMsg(lstStatus, "barb:" + barb);
            
            result = bara = barb = "";
            getLinkUsn("CN063JCXWSC0076Q08LCA00", out result, out bara, out barb);
            updateMsg(lstStatus, "result:" + result);
            updateMsg(lstStatus, "bara:" + bara);
            updateMsg(lstStatus, "barb:" + barb);


#endif

        }


        private bool PressStartButton()
        {      
            if (string.IsNullOrEmpty(p.TestlogPath.Trim()))
            {
                MessageBox.Show("TestlogPath can't be empty,press'Setting' to set the config...", "TestlogPath Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                updateMsg(lstStatus, "Error:TestlogPath can't be empty,press'Setting' to set the config...");
                txtTestlogPath.SelectAll();
                txtTestlogPath.Focus();
                return false;
            }
            if (!Directory.Exists(p.TestlogPath.Trim()))
            {
                MessageBox.Show("TestlogPath is not exist,pls check...", "TestlogPath Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                updateMsg(lstStatus, "Error:TestlogPath is not exist,pls check...");
                txtTestlogPath.SelectAll();
                txtTestlogPath.Focus();
                return false;
            }
            if (!File.Exists(p.AutoLookLogPath.Trim() + @"\Path.ini"))
            {
                updateMsg(lstStatus, "Warning:Not find 'path.ini',can't dynamic wather testlog folder change...");
                updateMsg(lstStatus, "Warning:plsese check the folder:" + p.AutoLookLogPath);
            }

            if (string.IsNullOrEmpty(p.BackupPath.Trim()))
            {
                MessageBox.Show("Backup Path can't be empty,press'Setting' to set the config...", "Backup Path Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                updateMsg(lstStatus, "Error:Backup Path can't be empty,press'Setting' to set the config...");
                return false;
            }

            if (!Directory.Exists(p.BackupPath.Trim()))
            {
                MessageBox.Show("Backup Path is not exist,pls check...", "Backup Path Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                updateMsg(lstStatus, "Error:Backup Path  is not exist,press'Setting' to set the config...");
                return false;
            }


            if (!bgwWebService.IsBusy)
                bgwWebService.RunWorkerAsync();

            timerDetectNet.Enabled = true;
            timerDetectNet.Start();
            updateFPY();

            //p.Delay(5000);
           //this.WindowState = FormWindowState.Minimized;


            return true;
        }


        /// <summary>
        /// 檢測WebService的可連通性,可連通返回true，不可連通，返回false
        /// </summary>
        /// <param name="website">WebService的地址</param>
        /// <returns>可連通返回true，不可連通返回false</returns>
        public bool checkWebService(p.PlantCode ateplant)
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
            updateMsg(lstStatus, "Webservice:" + ws.Url);
            try
            {
                Application.DoEvents();
                ws.Discover();
            }
            catch (Exception e)
            {
                sw.Stop();
                ts = sw.Elapsed;
                updateMsg(lstStatus, e.Message);
                updateMsg(lstStatus, "Can't connect WebService,Used time(ms):" + ts.Milliseconds);
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
        /// 檢測WebService的可連通性,可連通返回true，不可連通，返回false
        /// </summary>
        /// <param name="website">WebService的地址</param>
        /// <returns>可連通返回true，不可連通返回false</returns>
        public bool checkWebService(BackgroundWorker bk)
        {
            Stopwatch sw = new Stopwatch();
            TimeSpan ts = new TimeSpan();
            sw.Start();
            this.Invoke((EventHandler)delegate
            {
                updateMsg(lstStatus, "Start Check WebService");
            });

            //SubFunction.saveLog(Param.logType.SYSLOG.ToString(), "Check Web Service");
            if (p.ATEPlant == p.PlantCode.F721)
                ws.Url = p.SFCS721Webservice;
            if (p.ATEPlant == p.PlantCode.F722)
                ws.Url = p.SFCS722Webservice;
            this.Invoke((EventHandler)delegate
            {
                updateMsg(lstStatus, "Webservice:" + ws.Url);
            });

            try
            {
                Application.DoEvents();
                ws.Discover();
            }
            catch (Exception e)
            {
                sw.Stop();
                ts = sw.Elapsed;
                this.Invoke((EventHandler)delegate
                {
                    updateMsg(lstStatus, e.Message);
                    updateMsg(lstStatus, "Can't connect WebService,Used time(ms):" + ts.Milliseconds);
                });

                // SubFunction.saveLog(Param.logType.SYSLOG.ToString(), "Check Web Service NG,Used time(ms):" + ts.Milliseconds + "\r\n" + "Message:".PadLeft(24) + e.Message);

                return false;
            }
            sw.Stop();
            ts = sw.Elapsed;
            //SubFunction.updateMessage(lstStatusCommand, "Check Web Service OK,Used time(ms):" + ts.Milliseconds);
            this.Invoke((EventHandler)delegate
            {
                updateMsg(lstStatus, "Connect WebService success,Used time(ms):" + ts.Milliseconds);
            });

            //SubFunction.saveLog(Param.logType.SYSLOG.ToString(), "Check Web Service OK,Used time(ms):" + ts.Milliseconds);
            return true;
        }


        /// <summary>
        /// 檢查USN站別是否在當前站別,在為true，不在為false
        /// </summary>
        /// <param name="usn">條碼</param>
        /// <param name="stage">站別</param>
        /// <returns>在當前站別為true，不在當前站別為false</returns>
        private bool checkSFCSStage(string usn, string stage)
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


        /// <summary>
        /// 檢查USN站別是否在當前站別,在為true，不在為false
        /// </summary>
        /// <param name="usn">條碼</param>
        /// <param name="stage">站別</param>
        /// <returns>在當前站別為true，不在當前站別為false</returns>
        private bool checkSFCSStage(string usn, string stage, out string sfcsresult)
        {
            //  checkWebService(web_Site);

            sfcsresult = string.Empty;

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
                sfcsresult = result;
                //  SubFunction.saveLog(Param.logType.SYSLOG.ToString(), "usn:" + usn + "->" + stage);

                return true;
            }
            else
            {
                // SubFunction.updateMessage(lstStatusCommand, result + "Used time(ms):" + ts.Milliseconds);
                updateMsg(lstStatus, result + "Used time(ms):" + ts.Milliseconds);
                //SubFunction.saveLog(Param.logType.SYSLOG.ToString(), result + "Used time(ms):" + ts.Milliseconds);
                // SubFunction.saveLog(Param.logType.SYSLOG.ToString(), result + "Used time(ms):" + ts.Milliseconds);
                sfcsresult = result;
                return false;
            }
        }





        /// <summary>
        /// 
        /// </summary>
        /// <param name="usn"></param>
        /// <param name="_rqd"></param>
        /// <returns></returns>
        private bool GetUUData(string usn, out SFCS_ws.clsRequestData _rqd)
        {
            _rqd = new SFCS_ws.clsRequestData();
            Stopwatch sw = new Stopwatch();
            TimeSpan ts = new TimeSpan();
            sw.Start();
            updateMsg(lstStatus, "SFCS:" + usn + ",get model info from sfcs...");
            _rqd = ws.GetUUTData(usn, "TA", _rqd, 1);

            sw.Stop();
            ts = sw.Elapsed;
            if (_rqd != null)
            {
                updateMsg(lstStatus, usn + ",get model info success ,Used time(ms):" + ts.Milliseconds);
                updateMsg(lstStatus, usn + ",Model:" + _rqd.Model);
                updateMsg(lstStatus, usn + ",ModelFamily:" + _rqd.ModelFamily);
                updateMsg(lstStatus, usn + ",UPN(Config):" + _rqd.UPN);
                updateMsg(lstStatus, usn + ",MO:" + _rqd.MO);

            }
            else
            {
                updateMsg(lstStatus, "Warning:" + usn + ",get model info fail," + "Used time(ms):" + ts.Milliseconds);
            }

            return true;
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

            this.Invoke((EventHandler)(delegate
            {
                p.saveLog(item);
            }));

            

            if (listbox.Items.Count > 1)
            {
                listbox.TopIndex = listbox.Items.Count - 1;
                listbox.SetSelected(listbox.Items.Count - 1, true);
            }
        }

        private void initTestLogFileSystemWatcher(FileSystemWatcher fsw)
        {
            fsw.IncludeSubdirectories = false;
            // fsw.EnableRaisingEvents = false;
            fsw.Path = p.TestlogPath;
            fsw.Filter = p.FileFrontFlag + "*" + p.FileExtension;
            fsw.NotifyFilter = NotifyFilters.LastWrite;
            //MessageBox.Show(fsw.Filter);
            if (m_timer == null)
            {
                //设置定时器的回调函数。此时定时器未启动
                m_timer = new System.Threading.Timer(new TimerCallback(OnWatchedTestLogFileChange),
                                             null, Timeout.Infinite, Timeout.Infinite);
            }
        }

        private void initAutoLookFileSystemWatcher(FileSystemWatcher fsw)
        {
            fsw.IncludeSubdirectories = false;
            // fsw.EnableRaisingEvents = false;
            fsw.Path = p.AutoLookLogPath;
            fsw.Filter = "Path.ini";
            fsw.NotifyFilter = NotifyFilters.LastWrite;
            //MessageBox.Show(fsw.Filter);
            if (m_timer == null)
            {
                //设置定时器的回调函数。此时定时器未启动
                m_timer = new System.Threading.Timer(new TimerCallback(OnWatchedAutoLookFileChange),
                                             null, Timeout.Infinite, Timeout.Infinite);
            }

        }


        private void OnWatchedAutoLookFileChange(object state)
        {
            List<String> backup = new List<string>();
            Mutex mutex = new Mutex(false, "FSW");
            mutex.WaitOne();
            backup.AddRange(files);
            files.Clear();
            mutex.ReleaseMutex();
            foreach (string file in backup)
            {
                //MessageBox.Show("File Change", file + " changed");
                this.Invoke((EventHandler)delegate
                {
                    updateMsg(lstStatus, "File Change" + file + " changed");
                    string inipath = txtAutoLookLogPath.Text.Trim() + @"\path.ini";
                    if (System.IO.File.Exists(inipath))
                    {
                        getTestlogPathFromAutoLog(inipath);
                    }
                });
            }
        }

        private void OnWatchedTestLogFileChange(object state)
        {
            List<String> backup = new List<string>();
            Mutex mutex = new Mutex(false, "TestLog");
            mutex.WaitOne();
            backup.AddRange(files);
            files.Clear();
            mutex.ReleaseMutex();
            foreach (string file in backup)
            {
                //MessageBox.Show("File Change", file + " changed");
                this.Invoke((EventHandler)delegate
                {
                    updateMsg(lstStatus, "File Change," + file + " changed");

                    if (file.ToUpper() == "PATH.INI")
                    {
                        string inipath = txtAutoLookLogPath.Text.Trim() + @"\path.ini";
                        if (System.IO.File.Exists(inipath))
                        {
                            getTestlogPathFromAutoLog(inipath);
                        }
                    }
                    else
                    {
                        //readTestLogContent(file);
                        Thread t = new Thread(readTestLogContent);
                        t.Name = "ReadTestLog";
                        //t.IsBackground = true;
                        t.Start(file);
                    }



                   
                    //t.Join();

                    //updateMsg(lstStatus, t.Name + ",start...");

                });

            }

        }

        private void fswTestlog_Changed(object sender, FileSystemEventArgs e)
        {
            //p.Delay(200);
            //updateMsg(lstStatus, "Detect File " + e.ChangeType + ":" + e.FullPath);
            //updateMsg(lstStatus, "The file name is:" + e.Name);
            Mutex mutex = new Mutex(false, "TestLog");
            mutex.WaitOne();
            if (!files.Contains(e.FullPath))
            {
                //AutoLogfiles.Add(e.Name);
                files.Add(e.FullPath);
            }
            mutex.ReleaseMutex();
            //重新设置定时器的触发间隔，并且仅仅触发一次
            m_timer.Change(TimeoutMillis, Timeout.Infinite);
        }

        private void bgwWebService_DoWork(object sender, DoWorkEventArgs e)
        {
            _connnectWebservice = checkWebService(this.bgwWebService);
        }

        private void bgwWebService_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_connnectWebservice)
            {
                //MessageBox.Show("OK");
                btnRun.Enabled = false;
                btnStop.Enabled = true;
                btnSetting.Enabled = false;
                txtAutoLookLogPath.ReadOnly = true;
                txtTestlogPath.ReadOnly = true;

                initTestLogFileSystemWatcher(fswTestlog);
                //
                fswTestlog.EnableRaisingEvents = true;
                updateMsg(lstStatus, "Start to watch :" + p.TestlogPath);
                updateMsg(lstStatus, "监控以" + p.FileFrontFlag + "开头，以" + p.FileExtension + "为扩展名的文件");
                //
                initAutoLookFileSystemWatcher(fswAutoLook);
                //
                fswAutoLook.EnableRaisingEvents = true;
                updateMsg(lstStatus, "Start to watch :" + p.AutoLookLogPath + ",the file is Path.ini");

            }
            else
            {
                //MessageBox.Show("NG");
                btnRun.Enabled = true;
                btnStop.Enabled = false;
                btnSetting.Enabled = true;
                txtAutoLookLogPath.ReadOnly = false;
                txtTestlogPath.ReadOnly = false;

            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            fswAutoLook.EnableRaisingEvents = true;
            updateMsg(lstStatus, "Stop watch:" + p.AutoLookLogPath);
            fswTestlog.EnableRaisingEvents = true;
            updateMsg(lstStatus, "Stop watch:" + p.TestlogPath);
            btnSetting.Enabled = true;
            btnRun.Enabled = true;
            btnStop.Enabled = false;
            txtAutoLookLogPath.ReadOnly = false;
            txtTestlogPath.ReadOnly = false;
            _connnectWebservice = false;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="listview"></param>
        private void InitListviewBarcode(ListView listview)
        {
            listview.Items.Clear();
            listview.MultiSelect = false;
            listview.AutoArrange = true;
            listview.GridLines = true;
            listview.FullRowSelect = true;
            //listview.Columns.Add("ID", 30, HorizontalAlignment.Center);
            //listview.Columns.Add("Plant", 50, HorizontalAlignment.Center);
            listview.Columns.Add("USN", 160, HorizontalAlignment.Center);
            listview.Columns.Add("SEQ", 30, HorizontalAlignment.Center);
            listview.Columns.Add("Model", 80, HorizontalAlignment.Center);
            listview.Columns.Add("MO", 80, HorizontalAlignment.Center);
            listview.Columns.Add("TestResult", 80, HorizontalAlignment.Center);
            listview.Columns.Add("TestTime", 80, HorizontalAlignment.Center);
            listview.Columns.Add("1stPass", 80, HorizontalAlignment.Center);
            listview.Columns.Add("UploadFlag", 80, HorizontalAlignment.Center);

        }

        private void fswAutoLook_Changed(object sender, FileSystemEventArgs e)
        {
            //p.Delay(200);
            //updateMsg(lstStatus, "Detect File " + e.ChangeType + ":" + e.FullPath);
            //updateMsg(lstStatus, "The file name is:" + e.Name);
            //string inipath = txtAutoLookLogPath.Text.Trim() + @"\path.ini";
            //if (System.IO.File.Exists(inipath))
            //{
            //    getTestlogPathFromAutoLog(inipath);
            //}

            Mutex mutex = new Mutex(false, "FSW");
            mutex.WaitOne();
            if (!files.Contains(e.Name))
            {
                files.Add(e.Name);
            }
            mutex.ReleaseMutex();
            //重新设置定时器的触发间隔，并且仅仅触发一次
            m_timer.Change(TimeoutMillis, Timeout.Infinite);

        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        private void readTestLogContent(object file)
        {
            //StreamReader sr = new StreamReader((string)file);
            //string st = string.Empty;
            //while (!sr.EndOfStream)
            //{
            //    st = sr.ReadLine();
            //}
            //sr.Close();


            //if (!File.Exists((string)file))
            //    return;

            string[] temp = File.ReadAllLines((string)file);
            int _lastline = -1; //获取实际最后一行,防止文本最后有空格
            string lastlinestr = string.Empty;
            for (int i = temp.Length - 1; i > 0; i--)
            {
                if (!string.IsNullOrEmpty(temp[i]))
                {
                    lastlinestr = temp[i];
                    _lastline = i;
                    break;
                }
            }

            this.Invoke((EventHandler)delegate
            {

                //
                if (lstviewBarcode.Items.Count > 1000)
                    lstviewBarcode.Items.RemoveAt(0);


#if DEBUG
                updateMsg(lstStatus, lastlinestr);
#endif
                string usn, testresult, testtime, firstpass, getlinkresult;
                usn = testresult = testtime = firstpass = getlinkresult = string.Empty;
                //
                p.DatabaseTable databasetable = p.DatabaseTable.d_localdata;
                dealWithTestLogContent(lastlinestr, out usn, out testresult, out firstpass, out testtime);
                Barcode lastlinebar = new Barcode();
                getLinkUsn(usn, out getlinkresult, out lastlinebar);
                if (getlinkresult == "OK")
                {

                    SFCS_ws.clsRequestData rq = new SFCS_ws.clsRequestData();
                    GetUUData(usn, out rq);



                    //判断是单板还是双板
                    if (lastlinebar.BarType == p.BoardType.Single) //单板
                    {
                        bool _bsfcsupload = false;
                        //Get fixture id
                        // string _FixtureID = getFixtureID(usn, p.BackupPath);
                        string _FIXTUREID, _ERRORCODE, _OPID;
                        readBBBFle(usn, p.BackupPath, out _FIXTUREID, out _ERRORCODE, out _OPID);
                        //SFCS_ws.clsRequestData rq = new SFCS_ws.clsRequestData();
                        //GetUUData(usn, out rq);
                        //
                        ListViewItem lt = new ListViewItem();
                        lt = lstviewBarcode.Items.Add(usn);
                        lt.SubItems.Add("A");
                        lt.SubItems.Add(rq.Model);
                        lt.SubItems.Add(rq.MO);
                        if (testresult == "PASS")
                        {
                            lt.ForeColor = Color.Green;
                            //check stage
                            string sfcsresult = string.Empty;//check stage sfcs result
                            if (!checkSFCSStage(usn, p.ATEStage.StageName, out sfcsresult))
                            {
                                string _stage = p.GetStage(sfcsresult);
                                if (_stage == p.ATEStage.StageName)
                                {
                                    //
                                    //add upload stage
                                    //1,fixtureid 
                                    uploadFixtureID(txtCurrentWebService.Text.Trim(), usn, p.ATEStage.StageName, _FIXTUREID);
                                    updateResult2SFCS(txtCurrentWebService.Text.Trim(), usn, true, _ERRORCODE, false);
                                    _bsfcsupload = true;
                                    //updateMsg(lstStatus, usn + " test pass,router not upload sfcs,need add...");
                                }

                            }

                        }
                        if (testresult == "FAIL")
                            lt.ForeColor = Color.Red;
                        lt.SubItems.Add(testresult);
                        lt.SubItems.Add(testtime);
                        lt.SubItems.Add(firstpass);
                        updateMsg(lstStatus, "start write data to local database...");
                        p.replaceData2DB(databasetable.ToString(), usn, rq.Model, rq.ModelFamily, rq.UPN, rq.MO, "", "A", _FIXTUREID, testresult, testtime, firstpass, _bsfcsupload.ToString());
                        //updateMsg(lstStatus, "end write data to local database...");

                        string result = "";
                        bool isConnect = p.checkSqlDBIsConnect(p.connString, out result);
                        checkSqlDBUIChange(isConnect, result);
                        if (isConnect)
                        {
                            updateMsg(lstStatus, "net db connect,start write data to net database...");
                            p.replaceData2SqlDB(p.connString, p.DatabaseTable.atedata.ToString(), usn, rq.Model, rq.ModelFamily, rq.UPN, rq.MO, "", "A", _FIXTUREID, testresult, testtime, firstpass, _bsfcsupload.ToString());
                        }
                        else
                        {
                            updateMsg(lstStatus, "net db disconnect,start write data to temp database...");
                            p.replaceData2DB(p.DatabaseTable.d_tempdata.ToString(), usn, rq.Model, rq.ModelFamily, rq.UPN, rq.MO, "", "A", _FIXTUREID, testresult, testtime, firstpass, _bsfcsupload.ToString());
                            p.saveTempLog(usn, rq.Model, rq.ModelFamily, rq.UPN, rq.MO, " ", "A", _FIXTUREID, testresult, testtime, firstpass, _bsfcsupload.ToString(), testtime);
                        }
                    }

                    if (lastlinebar.BarType == p.BoardType.Panel)
                    {
                        bool _bsfcsupload = false;
                        //string _FixtureID = getFixtureID(usn, p.BackupPath); //双板也只获取一次                     
                        ////先获取机种信息,无论单双板,机种信息是一样的
                        string _FIXTUREID, _OPID;
                        readBBBFle(usn, p.BackupPath, out _FIXTUREID, out _OPID);
                        //SFCS_ws.clsRequestData rq = new SFCS_ws.clsRequestData();
                        //GetUUData(usn, out rq);
                        if (usn == lastlinebar.BarA)
                        {
            
                            ListViewItem lt = new ListViewItem();
#if DEBUG
                            lt = lstviewBarcode.Items.Add(usn+"-A");
#else
                            lt = lstviewBarcode.Items.Add(usn);
#endif
                            lt.SubItems.Add("A");
                            lt.SubItems.Add(rq.Model);
                            lt.SubItems.Add(rq.MO);
                            if (testresult == "PASS")
                            {
                                lt.ForeColor = Color.Green;
                                string sfcsresult = string.Empty;//check stage sfcs result
                                if (!checkSFCSStage(usn, p.ATEStage.StageName, out sfcsresult))
                                {
                                    string _stage = p.GetStage(sfcsresult);
                                    if (_stage == p.ATEStage.StageName)
                                    {
                                        //
                                        //add upload stage
                                        uploadFixtureID(txtCurrentWebService.Text.Trim(), usn, p.ATEStage.StageName, _FIXTUREID);
                                        updateResult2SFCS(txtCurrentWebService.Text.Trim(), usn, true, "0000", false);
                                        _bsfcsupload = true;
                                        // updateMsg(lstStatus, usn + " test pass,router not upload sfcs,need add...");
                                    }
                                }
                            }
                            if (testresult == "FAIL")
                                lt.ForeColor = Color.Red;
                            lt.SubItems.Add(testresult);
                            lt.SubItems.Add(testtime);
                            lt.SubItems.Add(firstpass);
                            /////
                            updateMsg(lstStatus, "start write data to local database...");
                            p.replaceData2DB(databasetable.ToString(), usn, rq.Model, rq.ModelFamily, rq.UPN, rq.MO, "", "A", _FIXTUREID, testresult, testtime, firstpass, _bsfcsupload.ToString());
                            //updateMsg(lstStatus, "end write data to local database...");
                            string result = "";
                            bool isConnect = p.checkSqlDBIsConnect(p.connString, out result);
                            checkSqlDBUIChange(isConnect, result);
                            if (isConnect)
                            {
                                updateMsg(lstStatus, "net db connect,start write data to net database...");
                                p.replaceData2SqlDB(p.connString, p.DatabaseTable.atedata.ToString(), usn, rq.Model, rq.ModelFamily, rq.UPN, rq.MO, "", "A", _FIXTUREID, testresult, testtime, firstpass, _bsfcsupload.ToString());
                            }
                            else
                            {
                                updateMsg(lstStatus, "net db disconnect,start write data to temp database...");
                                p.replaceData2DB(p.DatabaseTable.d_tempdata.ToString(), usn, rq.Model, rq.ModelFamily, rq.UPN, rq.MO, "", "A", _FIXTUREID, testresult, testtime, firstpass, _bsfcsupload.ToString());
                                p.saveTempLog(usn, rq.Model, rq.ModelFamily, rq.UPN, rq.MO, " ", "A", _FIXTUREID, testresult, testtime, firstpass, _bsfcsupload.ToString(), testtime);
                            }


                            if (testresult == "PASS") // PASS，才去testlog中去获取另外1个条码的信息
                            {
                                dealWithTestLogContent(temp[_lastline - 1], out usn, out testresult, out firstpass, out testtime);
                                
                                //
                                lt = new ListViewItem();
#if DEBUG
                                lt = lstviewBarcode.Items.Add(lastlinebar.BarB + "-B");
#else
                                lt = lstviewBarcode.Items.Add(lastlinebar.BarB);
#endif
                                lt.SubItems.Add("B");
                                lt.SubItems.Add(rq.Model);
                                lt.SubItems.Add(rq.MO);
                                if (testresult == "PASS")
                                {
                                    lt.ForeColor = Color.Green;
                                    string sfcsresult = string.Empty;//check stage sfcs result
                                    if (!checkSFCSStage(lastlinebar.BarB, p.ATEStage.StageName, out sfcsresult))
                                    {
                                        string _stage = p.GetStage(sfcsresult);
                                        if (_stage == p.ATEStage.StageName)
                                        {
                                            //
                                            //add upload stage
                                            uploadFixtureID(txtCurrentWebService.Text.Trim(), lastlinebar.BarB, p.ATEStage.StageName, _FIXTUREID);
                                            updateResult2SFCS(txtCurrentWebService.Text.Trim(), lastlinebar.BarB, true, "0000", false);
                                           // updateMsg(lstStatus, lastlinebar.BarB + " test pass,router not upload sfcs,need add...");
                                            _bsfcsupload = true;
                                        }
                                    }
                                }
                                if (testresult == "FAIL")
                                    lt.ForeColor = Color.Red;
                                lt.SubItems.Add(testresult);
                                lt.SubItems.Add(testtime);
                                lt.SubItems.Add(firstpass);
                                ////
                                updateMsg(lstStatus, "start write data to local database...");
                                p.replaceData2DB(databasetable.ToString(), usn, rq.Model, rq.ModelFamily, rq.UPN, rq.MO, "", "B", _FIXTUREID, testresult, testtime, firstpass, _bsfcsupload.ToString());
                                //updateMsg(lstStatus, "end write data to local database...");
                                result = "";
                                isConnect = p.checkSqlDBIsConnect(p.connString, out result);
                                checkSqlDBUIChange(isConnect, result);
                                if (isConnect)
                                {
                                    updateMsg(lstStatus, "net db connect,start write data to net database...");
                                    p.replaceData2SqlDB (p.connString,p.DatabaseTable.atedata.ToString (), usn, rq.Model, rq.ModelFamily, rq.UPN, rq.MO, "", "B", _FIXTUREID, testresult, testtime, firstpass, _bsfcsupload.ToString());
                                }
                                else
                                {
                                    updateMsg(lstStatus, "net db disconnect,start write data to temp database...");
                                    p.replaceData2DB(p.DatabaseTable.d_tempdata .ToString (), usn, rq.Model, rq.ModelFamily, rq.UPN, rq.MO, "", "B", _FIXTUREID, testresult, testtime, firstpass, _bsfcsupload.ToString());
                                    p.saveTempLog(usn, rq.Model, rq.ModelFamily, rq.UPN, rq.MO, " ", "B", _FIXTUREID, testresult, testtime, firstpass, _bsfcsupload.ToString(), testtime);
                                }
                            }

                        }
                        else // usn = lastlinebar.BarB,需要交换顺序
                        {
                            if (testresult == "FAIL")
                            {
                                ListViewItem lt = new ListViewItem();
#if DEBUG
                                lt = lstviewBarcode.Items.Add(usn + "-B");
#else
                                lt = lstviewBarcode.Items.Add(usn);
#endif
                                lt.SubItems.Add("B");
                                lt.SubItems.Add(rq.Model);
                                lt.SubItems.Add(rq.MO);
                                if (testresult == "PASS")
                                    lt.ForeColor = Color.Green;
                                if (testresult == "FAIL")
                                    lt.ForeColor = Color.Red;
                                lt.SubItems.Add(testresult);
                                lt.SubItems.Add(testtime);
                                lt.SubItems.Add(firstpass);
                            }
                            else //PASS
                            {
                                //先处理A
                                ListViewItem lt = new ListViewItem();
                                dealWithTestLogContent(temp[_lastline - 1], out usn, out testresult, out firstpass, out testtime);
#if DEBUG
                                updateMsg(lstStatus, temp[_lastline - 1]);
#endif
                                //
                                lt = new ListViewItem();
#if DEBUG
                                lt = lstviewBarcode.Items.Add(usn+ "-A");
#else
                                lt = lstviewBarcode.Items.Add(usn);
#endif
                                lt.SubItems.Add("A");
                                lt.SubItems.Add(rq.Model);
                                lt.SubItems.Add(rq.MO);
                                if (testresult == "PASS")
                                {
                                    lt.ForeColor = Color.Green;
                                    string sfcsresult = string.Empty;//check stage sfcs result
                                    if (!checkSFCSStage(usn, p.ATEStage.StageName, out sfcsresult))
                                    {
                                        string _stage = p.GetStage(sfcsresult);
                                        if (_stage == p.ATEStage.StageName)
                                        {
                                            //
                                            //add upload stage
                                            uploadFixtureID(txtCurrentWebService.Text.Trim(), usn, p.ATEStage.StageName, _FIXTUREID);
                                            updateResult2SFCS(txtCurrentWebService.Text.Trim(), usn, true, "0000", false);
                                            //updateMsg(lstStatus, usn + " test pass,router not upload sfcs,need add...");
                                            _bsfcsupload = true;
                                        }

                                    }
                                }
                                if (testresult == "FAIL")
                                    lt.ForeColor = Color.Red;
                                lt.SubItems.Add(testresult);
                                lt.SubItems.Add(testtime);
                                lt.SubItems.Add(firstpass);
                                ////
                                updateMsg(lstStatus, "start write data to local database...");
                                p.replaceData2DB(databasetable.ToString(), usn, rq.Model, rq.ModelFamily, rq.UPN, rq.MO, "", "A", _FIXTUREID, testresult, testtime, firstpass, _bsfcsupload.ToString());
                                //updateMsg(lstStatus, "end write data to local database...");
                                string result = "";
                                bool isConnect = p.checkSqlDBIsConnect(p.connString, out result);
                                checkSqlDBUIChange(isConnect, result);
                                if (isConnect)
                                {
                                    updateMsg(lstStatus, "net db connect,start write data to net database...");
                                    p.replaceData2SqlDB(p.connString, p.DatabaseTable.atedata.ToString(), usn, rq.Model, rq.ModelFamily, rq.UPN, rq.MO, "", "A", _FIXTUREID, testresult, testtime, firstpass, _bsfcsupload.ToString());
                                }
                                else
                                {
                                    updateMsg(lstStatus, "net db disconnect,start write data to temp database...");
                                    p.replaceData2DB(p.DatabaseTable.d_tempdata.ToString(), usn, rq.Model, rq.ModelFamily, rq.UPN, rq.MO, "", "A", _FIXTUREID, testresult, testtime, firstpass, _bsfcsupload.ToString());
                                    p.saveTempLog(usn, rq.Model, rq.ModelFamily, rq.UPN, rq.MO, " ", "A", _FIXTUREID, testresult, testtime, firstpass, _bsfcsupload.ToString(), testtime);
                                }



                                //处理B
                                dealWithTestLogContent(lastlinestr, out usn, out testresult, out firstpass, out testtime);
#if DEBUG
                                lt = lstviewBarcode.Items.Add(lastlinebar.BarB  + "-B");
#else
                                lt = lstviewBarcode.Items.Add(lastlinebar.BarB);
#endif
                                lt.SubItems.Add("B");
                                lt.SubItems.Add(rq.Model);
                                lt.SubItems.Add(rq.MO);
                                if (testresult == "PASS")
                                {
                                    lt.ForeColor = Color.Green;
                                    string sfcsresult = string.Empty;//check stage sfcs result
                                    if (!checkSFCSStage(usn, p.ATEStage.StageName, out sfcsresult))
                                    {
                                        string _stage = p.GetStage(sfcsresult);
                                        if (_stage == p.ATEStage.StageName)
                                        {
                                            //
                                            //add upload stage
                                            uploadFixtureID(txtCurrentWebService.Text.Trim(), lastlinebar.BarB, p.ATEStage.StageName, _FIXTUREID);
                                            updateResult2SFCS(txtCurrentWebService.Text.Trim(), lastlinebar.BarB, true, "0000", false);
                                            //updateMsg(lstStatus, usn + " test pass,router not upload sfcs,need add...");
                                            _bsfcsupload = true;
                                        }
                                    }
                                }
                                if (testresult == "FAIL")
                                    lt.ForeColor = Color.Red;
                                lt.SubItems.Add(testresult);
                                lt.SubItems.Add(testtime);
                                lt.SubItems.Add(firstpass);

                                ////
                                updateMsg(lstStatus, "start write data to local database...");
                                p.replaceData2DB(databasetable.ToString(), usn, rq.Model, rq.ModelFamily, rq.UPN, rq.MO, "", "B", _FIXTUREID, testresult, testtime, firstpass, _bsfcsupload.ToString());
                                //updateMsg(lstStatus, "end write data to local database...");
                                result = "";
                                isConnect = p.checkSqlDBIsConnect(p.connString, out result);
                                checkSqlDBUIChange(isConnect, result);
                                if (isConnect)
                                {
                                    updateMsg(lstStatus, "net db connect,start write data to net database...");
                                    p.replaceData2SqlDB(p.connString, p.DatabaseTable.atedata.ToString(), usn, rq.Model, rq.ModelFamily, rq.UPN, rq.MO, "", "B", _FIXTUREID, testresult, testtime, firstpass, _bsfcsupload.ToString());
                                }
                                else
                                {
                                    updateMsg(lstStatus, "net db disconnect,start write data to temp database...");
                                    p.replaceData2DB(p.DatabaseTable.d_tempdata.ToString(), usn, rq.Model, rq.ModelFamily, rq.UPN, rq.MO, "", "B", _FIXTUREID, testresult, testtime, firstpass, _bsfcsupload.ToString());
                                    p.saveTempLog(usn, rq.Model, rq.ModelFamily,rq.UPN, rq.MO, " ", "B",_FIXTUREID, testresult, testtime ,firstpass,_bsfcsupload.ToString () , testtime);
                                }
                            }
                        }
                    }

                    txtModel.Text = rq.Model;
                    tsslModel.Text = "Model:" + rq.Model;
                    txtProjectCode.Text = rq.ModelFamily;
                    //tsslModelFamily.Text = "ModelFamily:" + rq.ModelFamily;
                    txtMO.Text = rq.MO;
                    //tsslMO.Text = "MO:" + rq.MO;
                    txtUPN.Text = rq.UPN;
                    tsslUPN.Text = "UPN:" + rq.UPN;

                    //
                    updateFPY();

                }
                else
                {
                    updateMsg(lstStatus, getlinkresult);
                    return;
                }

                //lt.SubItems.Add ()
            });
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="stagelist"></param>
        /// <param name="_stage"></param>
        /// <param name="stageresult"></param>
        /// <returns></returns>
        private bool checkATEStage(List<p.STAGE> stagelist, string _stage, out p.STAGE stageresult)
        {
            stageresult = new p.STAGE("");
            foreach (var item in stagelist)
            {
                if (_stage == item.StageName)
                {
                    stageresult = item;
                    return true;
                }
                return false;
            }
            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="loglinestring">testlog 中的一行记录</param>
        /// <param name="usn">该行记录的USN</param>
        /// <param name="testresult">该行记录的测试结果</param>
        /// <param name="firstpass"></param>
        /// <param name="testtime"></param>
        private void dealWithTestLogContent(string loglinestring, out string usn, out string testresult, out string firstpass, out string testtime)
        {
            usn = testresult = firstpass = testtime = string.Empty;
            string[] temp = loglinestring.Trim().Split(' ');
            int icount = 0;
            ListViewItem lt = new ListViewItem();
            for (int i = 0; i < temp.Length; i++)
            {
                if (!string.IsNullOrEmpty(temp[i].Trim()))
                {
                    icount++;
                    //updateMsg(lstStatus, temp[i]);

                    if (icount == 1)
                        usn = temp[i];
                    if (icount == 2)
                    {
                        if (temp[i] == p.FaonFaoffBase)
                            firstpass = "YES";
                        else
                            firstpass = "NO";
                    }
                    if (icount == 3)
                    {
                        if (temp[i] == p.PassFlag)
                            testresult = "PASS";
                        else
                            testresult = "FAIL";

                    }
                    if (icount == 4)
                    {
                        testtime = temp[i];
                        if (testtime.Length == 12 && !testtime.StartsWith("20"))
                            testtime = "20" + testtime;
                    }

                }
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="usn"></param>
        /// <param name="result"></param>
        /// <param name="bara"></param>
        /// <param name="barb"></param>
        private void getLinkUsn(string usn, out string result, out string bara, out string barb)
        {
            result = bara = barb = "";

            string[] bar = ws.GetLinkUSN(usn, ref result);

            if (result == "OK")
            {
                if (bar.Length == 2)
                {
                    bara = bar[0];
                    barb = bar[1];
                }

                if (bar.Length == 1)
                    bara = bar[0];
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usn"></param>
        /// <param name="result"></param>
        /// <param name="_bar"></param>
        private void getLinkUsn(string usn, out string result, out Barcode _bar)
        {
            result = "";
            _bar = new Barcode();
            string[] bar = ws.GetLinkUSN(usn, ref result);
            if (result == "OK")
            {
                if (bar.Length == 2)
                {
                    _bar.BarA = bar[0];
                    _bar.BarB = bar[1];
                    _bar.BarType = p.BoardType.Panel;


#if DEBUG
                    updateMsg(lstStatus, "BarA:" + _bar.BarA);
                    updateMsg(lstStatus, "BarB:" + _bar.BarB);
#endif


                }

                if (bar.Length == 1)
                {
                    _bar.BarType = p.BoardType.Single;
                    _bar.BarA = bar[0];
                    _bar.BarB = string.Empty;
                }
            }

        }



        /// <summary>
        ///  
        /// </summary>
        /// <param name="usn"></param>
        /// <param name="backup"></param>
        /// <returns></returns>
        private string getFixtureID(string usn, string backup)
        {
            string _fixtreuid = string.Empty;
            bool _isNullEmpty = string.IsNullOrEmpty(usn);
            bool _isExist = Directory.Exists(backup);

            if (!_isNullEmpty && _isExist)
            {
                if (!backup.EndsWith(@"\"))
                    backup = backup + @"\";
                string bbbfile = backup + usn + ".BBB";
                bool _bbbIsExist = File.Exists(bbbfile);
                if (_bbbIsExist)
                {
                    StreamReader sr = new StreamReader(bbbfile);
                    string sLine = sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        sLine = sr.ReadLine();
                        if (sLine.ToUpper().StartsWith("FIXTUREID"))
                        {
                            _fixtreuid = sLine.Trim().ToUpper().Replace("FIXTUREID=", "");
                            break;
                        }
                    }
                    sr.Close();
                }
                else
                    updateMsg(lstStatus, usn + ".BBB is not exist in " + backup);
            }
            updateMsg(lstStatus, "USN:" + usn + ",FixtureID:" + _fixtreuid);
            return _fixtreuid;
        }


        /// <summary>
        /// read bbb file content
        /// </summary>
        /// <param name="usn">条码</param>
        /// <param name="backup">BBB文件路径</param>
        /// <param name="fixtureid">治具编号</param>
        /// <param name="errcode">errorcode</param>
        /// <param name="opid">工号</param>
        private void readBBBFle(string usn, string backup, out string fixtureid, out string errcode, out string opid)
        {
            string _fixtreuid = string.Empty;
            string _errcode = string.Empty;
            string _opid = string.Empty;
            bool _isNullEmpty = string.IsNullOrEmpty(usn);
            bool _isExist = Directory.Exists(backup);

            if (!_isNullEmpty && _isExist)
            {
                if (!backup.EndsWith(@"\"))
                    backup = backup + @"\";
                string bbbfile = backup + usn + ".BBB";
                bool _bbbIsExist = File.Exists(bbbfile);
                if (_bbbIsExist)
                {
                    StreamReader sr = new StreamReader(bbbfile);
                    string sLine = sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        sLine = sr.ReadLine();
                        if (sLine.ToUpper().StartsWith("FIXTUREID"))
                        {
                            _fixtreuid = sLine.Trim().ToUpper().Replace("FIXTUREID=", "");
                            updateMsg(lstStatus, "USN:" + usn + ",FIXTUREID:" + _fixtreuid);
                        }

                        if (sLine.ToUpper().StartsWith("ERRORCODE"))
                        {
                            _errcode = sLine.Trim().ToUpper().Replace("ERRORCODE=", "");
                            updateMsg(lstStatus, "USN:" + usn + ",ERRORCODE:" + _errcode);
                        }
                        if (sLine.ToUpper().StartsWith("OPID"))
                        {
                            _opid = sLine.Trim().ToUpper().Replace("OPID=", "");
                            updateMsg(lstStatus, "USN:" + usn + ",OPID:" + _opid);
                        }

                    }
                    sr.Close();
                }
                else
                    updateMsg(lstStatus, usn + ".BBB is not exist in " + backup);
            }

            fixtureid = _fixtreuid;
            errcode = _errcode;
            opid = _opid;
        }



        /// <summary>
        /// read bbb file content
        /// </summary>
        /// <param name="usn">条码</param>
        /// <param name="backup">BBB文件路径</param>
        /// <param name="fixtureid">治具编号</param>
        /// <param name="errcode">errorcode</param>
        /// <param name="opid">工号</param>
        private void readBBBFle(string usn, string backup, out string fixtureid, out string opid)
        {
            string _fixtreuid = string.Empty; 
            string _opid = string.Empty;
            bool _isNullEmpty = string.IsNullOrEmpty(usn);
            bool _isExist = Directory.Exists(backup);

            if (!_isNullEmpty && _isExist)
            {
                if (!backup.EndsWith(@"\"))
                    backup = backup + @"\";
                string bbbfile = backup + usn + ".BBB";
                bool _bbbIsExist = File.Exists(bbbfile);
                if (_bbbIsExist)
                {
                    StreamReader sr = new StreamReader(bbbfile);
                    string sLine = sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        sLine = sr.ReadLine();
                        if (sLine.ToUpper().StartsWith("FIXTUREID"))
                        {
                            _fixtreuid = sLine.Trim().ToUpper().Replace("FIXTUREID=", "");
                            updateMsg(lstStatus, "USN:" + usn + ",FIXTUREID:" + _fixtreuid);
                        }
           
                        if (sLine.ToUpper().StartsWith("OPID"))
                        {
                            _opid = sLine.Trim().ToUpper().Replace("OPID=", "");
                            updateMsg(lstStatus, "USN:" + usn + ",OPID:" + _opid);
                        }

                    }
                    sr.Close();
                }
                else
                    updateMsg(lstStatus, usn + ".BBB is not exist in " + backup);
            }

            fixtureid = _fixtreuid;
            opid = _opid;
        }


        /// <summary>
        ///  將fixtureid和usn綁定，上拋至sfcs
        /// </summary>
        /// <param name="website">web service地址</param>
        /// <param name="usn">條碼</param>
        /// <param name="stage">站別</param>
        /// <param name="fixtureid">治具編號</param>
        private void uploadFixtureID(string website, string usn, string stage, string fixtureid)
        {
            //if (!checkWebService(website))
            //    return;

            string result = string.Empty;
            Stopwatch sw = new Stopwatch();
            TimeSpan ts = new TimeSpan();
            sw.Start();
            result = ws.UploadFixtureID(usn, stage, fixtureid);
            if (result == "OK")
            {
                sw.Stop();
                ts = sw.Elapsed;
                updateMsg(lstStatus, usn + ",Upload FixtureID:" + fixtureid + " OK,time(ms):" + ts.Milliseconds);
                //SubFunction.updateMessage(lstStatusCommand, "upload FixtureID:" + fixtureid + " OK,time(ms):" + ts.Milliseconds);
                //SubFunction.saveLog(Param.logType.SYSLOG.ToString(), "upload FixtureID:" + fixtureid + " OK,time(ms):" + ts.Milliseconds);
            }
            else
            {
                sw.Stop();
                ts = sw.Elapsed;
                updateMsg(lstStatus, usn + ",Upload FixtureID:" + fixtureid + " Fail,time(ms):" + ts.Milliseconds + "," + result);
                //SubFunction.updateMessage(lstStatusCommand, "upload FixtureID:" + fixtureid + " Fail,time(ms):" + ts.Milliseconds + "," + result);
                // SubFunction.saveLog(Param.logType.SYSLOG.ToString(), "upload FixtureID:" + fixtureid + " Fail,time(ms):" + ts.Milliseconds + "," + result);
            }
        }

        /// <summary>
        /// 上拋信息到SFCS
        /// </summary>
        /// <param name="website">web serevice地址</param>
        /// <param name="usn">條碼</param>
        /// <param name="bresult">測試結果，PASS=true，NG=false</param>
        /// <param name="ngitem">測試項目</param>
        /// <param name="bretest">MB重測的標註,重測過=true，沒重測過=false</param>
        private void updateResult2SFCS(string website, string usn, bool bresult, string errcode, bool bretest)//,string testitem)
        {
            string[] trndata = new string[1]; //上拋SFCS的附件信息
            //if (!checkWebService(website))
            //    return;
            string result = string.Empty; //上拋的結果
            string testresult = string.Empty;//測試的結果
            bool bsfcsresult = false;

            if (bresult)
            {
                trndata[0] = usn;
                testresult = "PASS";
            }
            else
            {
                trndata[0] = errcode;
                testresult = "FAIL";
            }
            result = ws.Complete(usn, p.PCBLine, p.ATEStage.StageName, p.ATEStage.StageName, "D1203ABJ0", bresult, trndata);
            if (result == "OK")
            {
                bsfcsresult = true;
                updateMsg(lstStatus, usn + ",upload test result ok");
            }
            else
            {
                bsfcsresult = false;
                updateMsg(lstStatus, usn + ",upload test result fail," + result);
            }

            //save log
            //SubFunction.saveLog(usn, testresult, bretest, bsfcsresult, ngitem);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_isconnect"></param>
        /// <param name="result"></param>
        private void checkSqlDBUIChange(bool _isconnect, string _result)
        {
            if (_isconnect)
            {
                //tsslNetDB.BackColor = Color.Green;
                tsslNetDB.ForeColor = Color.Green;
                tsslNetDB.Text = "CONNECTED";
            }
            else
            {
                updateMsg(lstStatus, "Net sql db can't connect," + _result);
                //tsslNetDB.BackColor = Color.Red;
                tsslNetDB.ForeColor = Color.Red;
                tsslNetDB.Text = "DISCONNECTED";
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_isconnect"></param>
        /// <param name="result"></param>
        private void checkSqlDBUIChange(bool _isconnect)
        {
            if (_isconnect)
            {
                //tsslNetDB.BackColor = Color.Green;
                tsslNetDB.ForeColor = Color.Green;
                tsslNetDB.Text = "CONNECTED";
            }
            else
            { 
                //tsslNetDB.BackColor = Color.Red;
                tsslNetDB.ForeColor = Color.Red;
                tsslNetDB.Text = "DISCONNECTED";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerDetectNet_Tick(object sender, EventArgs e)
        {
            timerDetectNet.Stop();    
             string logpath = p.AppFolder + @"\Temp.log";
             if (File.Exists(logpath)) // 先判定文件是否存在,速度快
             {
                 bool isConnect = p.checkSqlDBIsConnect(p.connString);
                 checkSqlDBUIChange(isConnect);
                 if (isConnect)
                 {
                    List<string> temploglist = p.readTemplog();
                    MySqlConnection conn = new MySqlConnection(p.connString);
                    updateMsg(lstStatus, "start to update temp log data to net database ...");
                    conn.Open();
                   
                    foreach (string  item in temploglist )
                    {                   
                        string _line,_plant,_usn, _model, _modelfamily, _upn, _mo, _mac, _seq, _fixtureid, _testresult, _firstpass, _uploadflag, _cycletime, _testtime, _recordtime, _remark;
                        _line = _plant =_usn = _model = _modelfamily = _upn = _mo = _mac = _seq = _fixtureid = _testresult = _firstpass = _uploadflag = _cycletime = _testtime = _recordtime = _remark = string.Empty;

                        p.dealwithteamploglinestring(item, out _line,out _plant,out _usn, out _model, out _modelfamily,
                            out _upn, out _mo, out _mac, out _seq, out _fixtureid,
                            out _testresult, out _firstpass, out _uploadflag,
                            out _cycletime, out _testtime, out _recordtime, out _remark);

                        MySqlCommand cmd = new MySqlCommand ();
                        cmd.Connection = conn;

                        p.replaceData2SqlDB(cmd, p.DatabaseTable.atedata.ToString(), 
                           _line ,_plant , _usn, _model, _modelfamily,
                            _upn, _mo, _mac, _seq, _fixtureid, _testresult, 
                            _testtime, _firstpass, _uploadflag, _remark, _cycletime);
//                        string sql =@"REPLACE INTO " + p.DatabaseTable.atedata.ToString() +
//@"(line,plant,usn,model,modelfamily,upn,mo,mac,seq,fixtureid,testresult,firstpass,uploadflag,cycletime,testtime,recordtime,remark) VALUES ('" + _line + "','"
//                           + _plant  + "','"
//                           + _usn + "','"
//                           + _model + "','"
//                           + _modelfamily + "','"
//                           + _upn + "','"
//                           + _mo + "','"
//                           + _mac + "','"
//                           + _seq + "','"
//                           + _fixtureid + "','"
//                           + _testresult + "','"
//                           + _firstpass + "','"
//                           + _uploadflag + "','"
//                           + _cycletime + "','"
//                           + _testtime + "','"
//                           + _recordtime + "','"
//                           + _remark + "')";

//                        MySqlCommand cmd = new MySqlCommand(sql, conn);                     
                        
//                        try
//                        {
//                            int i = cmd.ExecuteNonQuery();
//                            //trans.Commit();
//                           // MessageBox.Show(i.ToString());
//                        }
//                        catch (Exception ex)
//                        {
//                           // MessageBox.Show(ex.Message);

//                        }
                    }
                    conn.Close();       
                    updateMsg(lstStatus, "update temp log data to net database is over...");       
   
                 }
            }          
            timerDetectNet.Start();
        }





        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstrun"></param>
        private void updateFPY()
        {

            string sql = "";
            Int32 shifttotal = 0;
            Int32 shiftfistpass = 0;
            Int32 shiftpass = 0;
        
            if (p.StartEndTime == p.StartEndTimeType.Day800)
            {
                if (p.getCurrentShift() == p.Shift.DShift)
                {
                    sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.ToString("yyyyMMdd") + "080000' and '" + DateTime.Now.ToString("yyyyMMdd") + "200000'";
                    shifttotal = p.queryCount(sql);
                    sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.ToString("yyyyMMdd") + "080000' and '" + DateTime.Now.ToString("yyyyMMdd") + "200000' and firstpass = 'YES' and testresult = 'PASS'";
                    shiftfistpass = p.queryCount(sql);
                    sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.ToString("yyyyMMdd") + "080000' and '" + DateTime.Now.ToString("yyyyMMdd") + "200000'  and testresult = 'PASS'";
                    shiftpass = p.queryCount(sql);
                    grbShiftYieldRate.Text = "Day Yield Rate";
                    lblShiftFPY.Text = p.CalcPCT(shiftfistpass, shifttotal);
                    lblShiftYR.Text = p.CalcPCT(shiftpass, shifttotal);
                    //yr = p.CalcPCT(shiftpass, shifttotal);
                    //fpy = p.CalcPCT(shiftfistpass, shifttotal);
                    
                    

                    return;
                }
                if (p.getCurrentShift() == p.Shift.Nshift)
                {
                    sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "200000' and '" + DateTime.Now.ToString("yyyyMMdd") + "080000'";
                    shifttotal = p.queryCount(sql);
                    sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "200000' and '" + DateTime.Now.ToString("yyyyMMdd") + "080000' and firstpass = 'YES' and testresult = 'PASS'";
                    shiftfistpass = p.queryCount(sql);
                    sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "200000' and '" + DateTime.Now.ToString("yyyyMMdd") + "080000'  and testresult = 'PASS'";
                    shiftpass = p.queryCount(sql);
                    grbShiftYieldRate.Text = "Night Yield Rate";
                    lblShiftFPY.Text = p.CalcPCT(shiftfistpass, shifttotal);
                    lblShiftYR.Text = p.CalcPCT(shiftpass, shifttotal);
                    //yr = p.CalcPCT(shiftpass, shifttotal);
                    //fpy = p.CalcPCT(shiftfistpass, shifttotal);
                    return;
                }                
            }

            if (p.StartEndTime == p.StartEndTimeType.Day830 )
            {
                if (p.getCurrentShift() == p.Shift.DShift)
                {
                    sql = "SELECT COUNT(usn) from " +  p.DatabaseTable.d_localdata .ToString () +" WHERE testtime between '" + DateTime.Now.ToString("yyyyMMdd") + "083000' and '" + DateTime.Now.ToString("yyyyMMdd") + "203000'";
                    shifttotal = p.queryCount(sql);
                    sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.ToString("yyyyMMdd") + "083000' and '" + DateTime.Now.ToString("yyyyMMdd") + "203000' and firstpass = 'YES' and testresult = 'PASS'";
                    shiftfistpass = p.queryCount(sql);
                    sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.ToString("yyyyMMdd") + "083000' and '" + DateTime.Now.ToString("yyyyMMdd") + "203000'  and testresult = 'PASS'";
                    shiftpass = p.queryCount(sql);
                    grbShiftYieldRate.Text = "Day Yield Rate";
                    lblShiftFPY.Text = p.CalcPCT(shiftfistpass, shifttotal);
                    lblShiftYR.Text = p.CalcPCT(shiftpass, shifttotal);
                    //yr = p.CalcPCT(shiftpass, shifttotal);
                    //fpy = p.CalcPCT(shiftfistpass, shifttotal);
                    return;
                }
                if (p.getCurrentShift() == p.Shift.Nshift)
                {
                    sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "203000' and '" + DateTime.Now.ToString("yyyyMMdd") + "083000'";
                    shifttotal = p.queryCount(sql);
                    sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "203000' and '" + DateTime.Now.ToString("yyyyMMdd") + "083000' and firstpass = 'YES' and testresult = 'PASS'";
                    shiftfistpass = p.queryCount(sql);
                    sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "203000' and '" + DateTime.Now.ToString("yyyyMMdd") + "083000'  and testresult = 'PASS'";
                    shiftpass = p.queryCount(sql);
                    grbShiftYieldRate.Text = "Night Yield Rate";
                    lblShiftFPY.Text = p.CalcPCT(shiftfistpass, shifttotal);
                    lblShiftYR.Text = p.CalcPCT(shiftpass, shifttotal);
                    //yr = p.CalcPCT(shiftpass, shifttotal);
                    //fpy = p.CalcPCT(shiftfistpass, shifttotal);
                    return;
                }
            }


      


        }

        private void btnChangeShift_Click(object sender, EventArgs e)
        {




            string sql = "";
            Int32 shifttotal = 0;
            Int32 shiftfistpass = 0;
            Int32 shiftpass = 0;

            if (p.StartEndTime == p.StartEndTimeType.Day800)
            {
                if (p.getCurrentShift() == p.Shift.DShift)
                {
                    //sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.ToString("yyyyMMdd") + "080000' and '" + DateTime.Now.ToString("yyyyMMdd") + "200000'";
                    //shifttotal = p.queryCount(sql);
                    //sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.ToString("yyyyMMdd") + "080000' and '" + DateTime.Now.ToString("yyyyMMdd") + "200000' and firstpass = 'YES' and testresult = 'PASS'";
                    //shiftfistpass = p.queryCount(sql);
                    //sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.ToString("yyyyMMdd") + "080000' and '" + DateTime.Now.ToString("yyyyMMdd") + "200000'  and testresult = 'PASS'";
                    //shiftpass = p.queryCount(sql);
                    //grbShiftYieldRate.Text = "Day Yield Rate";


                    sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "200000' and '" + DateTime.Now.ToString("yyyyMMdd") + "080000'";
                    shifttotal = p.queryCount(sql);
                    sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "200000' and '" + DateTime.Now.ToString("yyyyMMdd") + "080000' and firstpass = 'YES' and testresult = 'PASS'";
                    shiftfistpass = p.queryCount(sql);
                    sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "200000' and '" + DateTime.Now.ToString("yyyyMMdd") + "080000'  and testresult = 'PASS'";
                    shiftpass = p.queryCount(sql);
                    grbShiftYieldRate.Text = "Night Yield Rate";


                    lblShiftFPY.Text = p.CalcPCT(shiftfistpass, shifttotal);
                    lblShiftYR.Text = p.CalcPCT(shiftpass, shifttotal);
                    //yr = p.CalcPCT(shiftpass, shifttotal);
                    //fpy = p.CalcPCT(shiftfistpass, shifttotal);
                    return;
                }
                if (p.getCurrentShift() == p.Shift.Nshift)
                {
                    //sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "200000' and '" + DateTime.Now.ToString("yyyyMMdd") + "080000'";
                    //shifttotal = p.queryCount(sql);
                    //sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "200000' and '" + DateTime.Now.ToString("yyyyMMdd") + "080000' and firstpass = 'YES' and testresult = 'PASS'";
                    //shiftfistpass = p.queryCount(sql);
                    //sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "200000' and '" + DateTime.Now.ToString("yyyyMMdd") + "080000'  and testresult = 'PASS'";
                    //shiftpass = p.queryCount(sql);
                    //grbShiftYieldRate.Text = "Night Yield Rate";

                    sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.ToString("yyyyMMdd") + "080000' and '" + DateTime.Now.ToString("yyyyMMdd") + "200000'";
                    shifttotal = p.queryCount(sql);
                    sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.ToString("yyyyMMdd") + "080000' and '" + DateTime.Now.ToString("yyyyMMdd") + "200000' and firstpass = 'YES' and testresult = 'PASS'";
                    shiftfistpass = p.queryCount(sql);
                    sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.ToString("yyyyMMdd") + "080000' and '" + DateTime.Now.ToString("yyyyMMdd") + "200000'  and testresult = 'PASS'";
                    shiftpass = p.queryCount(sql);
                    grbShiftYieldRate.Text = "Day Yield Rate";

                    lblShiftFPY.Text = p.CalcPCT(shiftfistpass, shifttotal);
                    lblShiftYR.Text = p.CalcPCT(shiftpass, shifttotal);
                    //yr = p.CalcPCT(shiftpass, shifttotal);
                    //fpy = p.CalcPCT(shiftfistpass, shifttotal);
                    return;
                }
            }

            if (p.StartEndTime == p.StartEndTimeType.Day830)
            {
                if (p.getCurrentShift() == p.Shift.DShift)
                {
                    //sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.ToString("yyyyMMdd") + "083000' and '" + DateTime.Now.ToString("yyyyMMdd") + "203000'";
                    //shifttotal = p.queryCount(sql);
                    //sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.ToString("yyyyMMdd") + "083000' and '" + DateTime.Now.ToString("yyyyMMdd") + "203000' and firstpass = 'YES' and testresult = 'PASS'";
                    //shiftfistpass = p.queryCount(sql);
                    //sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.ToString("yyyyMMdd") + "083000' and '" + DateTime.Now.ToString("yyyyMMdd") + "203000'  and testresult = 'PASS'";
                    //shiftpass = p.queryCount(sql);
                    //grbShiftYieldRate.Text = "Day Yield Rate";

                    sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "203000' and '" + DateTime.Now.ToString("yyyyMMdd") + "083000'";
                    shifttotal = p.queryCount(sql);
                    sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "203000' and '" + DateTime.Now.ToString("yyyyMMdd") + "083000' and firstpass = 'YES' and testresult = 'PASS'";
                    shiftfistpass = p.queryCount(sql);
                    sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "203000' and '" + DateTime.Now.ToString("yyyyMMdd") + "083000'  and testresult = 'PASS'";
                    shiftpass = p.queryCount(sql);
                    grbShiftYieldRate.Text = "Night Yield Rate";

                    lblShiftFPY.Text = p.CalcPCT(shiftfistpass, shifttotal);
                    lblShiftYR.Text = p.CalcPCT(shiftpass, shifttotal);
                    //yr = p.CalcPCT(shiftpass, shifttotal);
                    //fpy = p.CalcPCT(shiftfistpass, shifttotal);
                    return;
                }
                if (p.getCurrentShift() == p.Shift.Nshift)
                {
                    //sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "203000' and '" + DateTime.Now.ToString("yyyyMMdd") + "083000'";
                    //shifttotal = p.queryCount(sql);
                    //sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "203000' and '" + DateTime.Now.ToString("yyyyMMdd") + "083000' and firstpass = 'YES' and testresult = 'PASS'";
                    //shiftfistpass = p.queryCount(sql);
                    //sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + "203000' and '" + DateTime.Now.ToString("yyyyMMdd") + "083000'  and testresult = 'PASS'";
                    //shiftpass = p.queryCount(sql);
                    //grbShiftYieldRate.Text = "Night Yield Rate";

                    sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.ToString("yyyyMMdd") + "083000' and '" + DateTime.Now.ToString("yyyyMMdd") + "203000'";
                    shifttotal = p.queryCount(sql);
                    sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.ToString("yyyyMMdd") + "083000' and '" + DateTime.Now.ToString("yyyyMMdd") + "203000' and firstpass = 'YES' and testresult = 'PASS'";
                    shiftfistpass = p.queryCount(sql);
                    sql = "SELECT COUNT(usn) from " + p.DatabaseTable.d_localdata.ToString() + " WHERE testtime between '" + DateTime.Now.ToString("yyyyMMdd") + "083000' and '" + DateTime.Now.ToString("yyyyMMdd") + "203000'  and testresult = 'PASS'";
                    shiftpass = p.queryCount(sql);
                    grbShiftYieldRate.Text = "Day Yield Rate";

                    lblShiftFPY.Text = p.CalcPCT(shiftfistpass, shifttotal);
                    lblShiftYR.Text = p.CalcPCT(shiftpass, shifttotal);
                    //yr = p.CalcPCT(shiftpass, shifttotal);
                    //fpy = p.CalcPCT(shiftfistpass, shifttotal);
                    return;
                }
            }




        }


        private void gdrawYR(PaintEventArgs e, double yr, double fpy)
        {

           // Graphics g = e.Graphics; //创建画板,这里的画板是由Form提供的. 
            Graphics g = this.grbShiftYieldRate.CreateGraphics();
            g.Clear(this.BackColor);

            //ate
            Color color = changecolorbyyr(yr);
            //Pen p = new Pen(color, 25);//定义了一个蓝色,宽度为的画笔        
            //g.DrawEllipse(p, 100, 150, 260, 260);//在画板上画椭圆,起始坐标为(10,10),外接矩形的宽为,高为
            //p = new Pen(color, 1);
            //g.DrawRectangle(p, 70, 120, 320, 320);
            System.Drawing.Font font = new System.Drawing.Font("Agency FB", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            SolidBrush brush = new SolidBrush(color);
            g.DrawString(string.Format("{0:P}", yr), font, brush, 10F, 20F);

            //ft
            color = changecolorbyyr(fpy);
            //p = new Pen(color, 25);//定义了一个蓝色,宽度为的画笔   
            //g.DrawEllipse(p, 450, 150, 260, 260);//在画板上画椭圆,起始坐标为(10,10),外接矩形的宽为,高为   
            //p = new Pen(color, 1);
            //g.DrawRectangle(p, 420, 120, 320, 320);
            brush = new SolidBrush(color);
            g.DrawString(string.Format("{0:P}", fpy), font, brush, 30F, 20F);
            //
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="yr"></param>
        /// <returns></returns>
        private Color changecolorbyyr(double yr)
        {
            Color _color = Color.DimGray;

            if (yr >= 0.985)
                _color = Color.Green;
            else if (yr>= 0.95)
                _color = Color.DarkOrange;
            else
                _color = Color.Red;

            if (yr == 0)
                _color = Color.DimGray;

            return _color;
        }

        private void frmATEClient_Paint(object sender, PaintEventArgs e)
        {
            //gdrawYR(e, yr, fpy);
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                notifyIcon1.Visible = false;
                this.ShowInTaskbar = true;
            }  
        }

        private void frmATEClient_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.ShowInTaskbar = false;
                this.notifyIcon1.Visible = true;
            } 
        }

    }  
}
