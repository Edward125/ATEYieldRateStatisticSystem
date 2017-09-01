using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Edward;
using System.Drawing;
using System.IO;
using System.Reflection;
using Shortcut;
using WindowsStartup.Utils;
using Microsoft.Win32;
using System;
using System.IO;

namespace ATEYieldRateStatisticSystem
{
    static class Program
    {

       static  string AppName = "ATEYieldRateStatisticSystem";
       static  string AppFile = Application.ExecutablePath;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!File.Exists(@".\splash.png"))
            {
                //Assembly assem = this.GetType().Assembly;
                Assembly assem = System.Reflection.Assembly.GetEntryAssembly();
                Stream stream = assem.GetManifestResourceStream("ATEYieldRateStatisticSystem.Resources.Splash.png");
                System.Drawing.Image.FromStream(stream).Save("splash.png");
            }

            SplashForm.StartSplash(@".\splash.png", Color.FromArgb(128, 128, 128));
            //Application.Run (new SplashForm());
            // simulating operations at startup '
            if (!p.checkFolder())
            {
                MessageBox.Show("Create app folder fail,program will exit.", "Create Folder Fail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                System.Threading.Thread.Sleep(1000);
                SplashForm.CloseSplash();
                Environment.Exit(0);
            }

            if (!File.Exists(@".\IrisSkin4.dll"))
            {
                if (!downloadIrisSkin4())
                {
                    System.Threading.Thread.Sleep(1000); 
                    SplashForm.CloseSplash();
                    Environment.Exit(0);
                }
            }


            if (!File.Exists(@".\System.Data.SQLite.dll"))
            {
                if (!downloadSqliteDll ())
                {
                    System.Threading.Thread.Sleep(1000);
                    SplashForm.CloseSplash();
                    Environment.Exit(0);
                }
            }

            if (!File.Exists(@".\SQLite.Interop.dll"))
            {
                if (!downloadSqliteInterop ())
                {
                    System.Threading.Thread.Sleep(1000);
                    SplashForm.CloseSplash();
                    Environment.Exit(0);
                }
            }

            if (!File.Exists(@".\MySql.Data.dll"))
            {
                if (!downloadMySqlData())
                {
                    System.Threading.Thread.Sleep(1000);
                    SplashForm.CloseSplash();
                    Environment.Exit(0);
                }
            }


            if (!p.checkDB(p.LocalDB))
            {
                System.Threading.Thread.Sleep(1000);
                SplashForm.CloseSplash();
                Environment.Exit(0);
            }





            if (!File.Exists (p.AppFolder + @"\MacOS.ssk"))
            {
                if (!downloadSkin ())
                {
                    System.Threading.Thread.Sleep(1000);
                    SplashForm.CloseSplash();
                    Environment.Exit(0);
                }
            }
            //MessageBox.Show(p.AppStart.ToString());

            //check ini file
            if (!File.Exists(p.iniFilePath))
                p.createIniFile(p.iniFilePath);
            p.readIniValue(p.iniFilePath);//exits,read ini file

            p.autoSelectConnstring();

          

            //create mysql db
            string result = "";
            if (!p.createDB(p.connstringNoDB, out result))
            {
                if (p.AppStart == p.AppStartModel.ATEClient)
                {
                    MessageBox.Show(result + ",the data will record in the local db.");
                }
                if (p.AppStart == p.AppStartModel.YRServer)
                {
                    MessageBox.Show(result + "the program will exit...");
                    System.Threading.Thread.Sleep(1000);
                    SplashForm.CloseSplash();
                    Environment.Exit(0);
                }

               
            }
            else
            {
                if (!p.createMysqlTable(p.connString, out result))
                {
                    MessageBox.Show(result);

                }
            }

            System.Threading.Thread.Sleep(1000);
            // close the splash screen'
            SplashForm.CloseSplash();

            //創建桌面快捷方式
            //Shortcut.Shortcut.CreateShortcut(Shortcut.Shortcut.GetDeskDir() + "\\ATEYieldRateStatisticSystem.lnk",Application.StartupPath + @"\\ATEYieldRateStatisticSystem", Shortcut.Shortcut.GetDeskDir(), "ATEYieldRateStatisticSystem", AppDomain.CurrentDomain.BaseDirectory + "favicon.ico");
            Shortcut.Shortcut.CreateDesktopShortcut(Application.StartupPath  + "\\ATEYieldRateStatisticSystem.lnk", "ATEYieldRateStatisticSystem");
            
            //創建開機啟動
            //UICmd("正在读取 全局用户开始菜单启动文件夹");
            p.saveLog(DateTime.Now.ToString ("HH:mm:ss") + "->" +"正在读取 全局用户开始菜单启动文件夹");
            string commonStartup = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup);
           // UICmd("CommonStartup：" + commonStartup);
            if (ShortcutTool.Create(commonStartup, AppName, AppFile))
                p.saveLog (DateTime.Now.ToString ("HH:mm:ss") + "->"+"添加 全局用户开始菜单启动 成功");             
            else
                p.saveLog(DateTime.Now.ToString("HH:mm:ss") + "->" + "添加 全局用户开始菜单启动 失败");
            p.saveLog(DateTime.Now.ToString("HH:mm:ss") + "->" + "正在读取 当前用户开始菜单启动文件夹");
            string startup = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            //UICmd("Startup：" + startup);
            p.saveLog(DateTime.Now.ToString("HH:mm:ss") + "->" + "Startup：" + startup);
            if (ShortcutTool.Create(startup, AppName, AppFile))
                //UICmd("添加 当前用户开始菜单启动 成功");
                p.saveLog(DateTime.Now.ToString("HH:mm:ss") + "->" + "添加 当前用户开始菜单启动 成功");
            else
                //UICmd("添加 当前用户开始菜单启动 失败");
                p.saveLog(DateTime.Now.ToString("HH:mm:ss") + "->" + "添加 当前用户开始菜单启动 失败");





            if (p.AppStart == p.AppStartModel.ATEClient)
                Application.Run(new frmATEClient());
            else if (p.AppStart == p.AppStartModel.YRServer)
                //Application.Run(new frmYRMonitor());
                Application.Run(new frmYROverAll());
            //Application.Run(new frmQueryFR());
            //Application.Run(new frmFTYR());
            //Application.Run(new frmYRbyLine());
            else
                Application.Run(new frmMain());
           
        }
        
        /// <summary>
        /// download irisskin4.dll
        /// </summary>
        /// <returns></returns>
        private static  bool  downloadIrisSkin4()
        {
            string filePath = @".\IrisSkin4.dll";

            if (!File.Exists(filePath))
            {
                byte[] template = Properties.Resources.IrisSkin4;
                FileStream stream = new FileStream(filePath, FileMode.Create);
                try
                {
                    stream.Write(template, 0, template.Length);
                    stream.Close();
                    stream.Dispose();
                  //  File.SetAttributes(filePath, FileAttributes.Hidden);
                }
                catch (Exception ex)
                {
                    MessageBox.Show (ex.Message);
                    return false;
                }

            }
            return true;
        }

        private static bool downloadSqliteDll()
        {
            string filePath = @".\System.Data.SQLite.dll";

            if (!File.Exists(filePath))
            {
                byte[] template = Properties.Resources.System_Data_SQLite;
                FileStream stream = new FileStream(filePath, FileMode.Create);
                try
                {
                    stream.Write(template, 0, template.Length);
                    stream.Close();
                    stream.Dispose();
                    //  File.SetAttributes(filePath, FileAttributes.Hidden);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }

            }
            return true;
        }

        private static bool downloadSqliteInterop()
        {
            string filePath = @".\SQLite.Interop.dll";

            if (!File.Exists(filePath))
            {
                byte[] template = Properties.Resources.SQLite_Interop;
                FileStream stream = new FileStream(filePath, FileMode.Create);
                try
                {
                    stream.Write(template, 0, template.Length);
                    stream.Close();
                    stream.Dispose();
                    //  File.SetAttributes(filePath, FileAttributes.Hidden);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }

            }
            return true;
        }


        private static bool downloadMySqlData()
        {
            string filePath = @".\MySql.Data.dll";

            if (!File.Exists(filePath))
            {
                byte[] template = Properties.Resources.MySql_Data;
                FileStream stream = new FileStream(filePath, FileMode.Create);
                try
                {
                    stream.Write(template, 0, template.Length);
                    stream.Close();
                    stream.Dispose();
                    //  File.SetAttributes(filePath, FileAttributes.Hidden);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }

            }
            return true;
        }
        private static bool downloadSkin()
        {
            string filePath = p.AppFolder + @"\MacOS.ssk";

            if (!File.Exists(filePath))
            {
                byte[] template = Properties.Resources.MacOS;
                FileStream stream = new FileStream(filePath, FileMode.Create);
                try
                {
                    stream.Write(template, 0, template.Length);
                    stream.Close();
                    stream.Dispose();
                    File.SetAttributes(filePath, FileAttributes.Hidden);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            return true;

        }
    }
}
