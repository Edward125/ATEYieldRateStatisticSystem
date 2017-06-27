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

        bool _connnectWebservice = false; //connect web service result,success=true;fail = false;

        private int TimeoutMillis = 1000; //定时器触发间隔
        System.Threading.Timer m_timer = null;
        List<String> files = new List<string>(); //AutoLog记录待处理文件的队列


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
            loadUI();
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

            this.Text = Application.ProductName + "-ATE Client...(Ver:" + Application.ProductVersion + ")";
            txtAutoLookLogPath.SetWatermark("DbClick here to select AutoLookIyet config file folder path...");
            txtTestlogPath.SetWatermark("DbClick here to select ATE test program testlog file folder path...");
            InitListviewBarcode(lstviewBarcode);
            loadConfig();
            tsslStartTime.Text = "StartTime:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",";

            //lblModelFPY.ForeColor = Color.Red;
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


            
            if (string.IsNullOrEmpty(p.TestlogPath.Trim()))
            {
                MessageBox.Show("TestlogPath can't be empty,press'Setting' to set the config...", "TestlogPath Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                updateMsg(lstStatus, "Error:TestlogPath can't be empty,press'Setting' to set the config...");
                txtTestlogPath.SelectAll();
                txtTestlogPath.Focus();
                return;
            }
            if (!Directory.Exists(p.TestlogPath.Trim()))
            {
                MessageBox.Show("TestlogPath is not exist,pls check...", "TestlogPath Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                updateMsg(lstStatus, "Error:TestlogPath is not exist,pls check...");
                txtTestlogPath.SelectAll();
                txtTestlogPath.Focus();
                return;
            }
            if (!File.Exists(p.AutoLookLogPath.Trim () + @"\Path.ini"))
            {
                updateMsg(lstStatus, "Warning:Not find 'path.ini',can't dynamic wather testlog folder change...");
                updateMsg(lstStatus, "Warning:plsese check the folder:" + p.AutoLookLogPath );
            }
            if (!bgwWebService.IsBusy)
               bgwWebService.RunWorkerAsync();

#if DEBUG
            p.Delay(200);
            SFCS_ws.clsRequestData rq = new SFCS_ws.clsRequestData();
            GetUUData("CN041D5Y7620667P0BQCA00", out rq);
            txtModel.Text = rq.Model;
            tsslModel.Text = "Model:" + rq.Model;
            txtProjectCode.Text = rq.ModelFamily;
            tsslModelFamily.Text = "ModelFamily:" + rq.ModelFamily;
            txtMO.Text = rq.MO;
            tsslMO.Text = "MO:" + rq.MO;
            txtUPN.Text = rq.UPN;
            tsslUPN.Text = "UPN:" + rq.UPN;
#endif
           
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
            if (_rqd  != null)
            {
               updateMsg  (lstStatus , usn  + ",get model info success ,Used time(ms):" + ts.Milliseconds);
               updateMsg(lstStatus, usn +",Model:" +_rqd.Model);
               updateMsg(lstStatus, usn+",ModelFamily:"+ _rqd.ModelFamily);
               updateMsg(lstStatus, usn +",UPN(Config):"+_rqd.UPN);
               updateMsg(lstStatus, usn +",MO:"+ _rqd.MO);

            }
            else
            {
                updateMsg  (lstStatus , "Warning:"+usn +",get model info fail," + "Used time(ms):" + ts.Milliseconds);
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
            if (!files.Contains(e.Name))
            {
                //AutoLogfiles.Add(e.Name);
                files.Add(e.Name);
            }
            mutex.ReleaseMutex();
            //重新设置定时器的触发间隔，并且仅仅触发一次
            m_timer.Change(TimeoutMillis, Timeout.Infinite);
        }

        private void bgwWebService_DoWork(object sender, DoWorkEventArgs e)
        {
            _connnectWebservice  = checkWebService(this.bgwWebService);
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
            listview.Columns.Add("USN", 200, HorizontalAlignment.Center);
            listview.Columns.Add ("TestResult",80,HorizontalAlignment.Center);
            listview.Columns.Add("Stage", 80,HorizontalAlignment.Center);
            listview.Columns.Add("Upload", 80, HorizontalAlignment.Center);

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

    }
}
