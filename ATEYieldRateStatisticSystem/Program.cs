using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Edward;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace ATEYieldRateStatisticSystem
{
    static class Program
    {
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

            System.Threading.Thread.Sleep(1000); 
            // close the splash screen'
            SplashForm.CloseSplash();

            //create mysql db
            string result = "";
            if (!p.createDB(p.connstringNoDB , out result))
                MessageBox.Show(result);
            else
            {
                if (!p.createMysqlTable(p.connString, out result))
                {
                    MessageBox.Show(result);

                 }
            }

          

            p.objConn = new MySql.Data.MySqlClient.MySqlConnection(p.connString);
            try
            {
                p.objConn.OpenAsync();
            }
            catch (Exception)
            {
                
                throw;
            }

            //
            if (p.AppStart == p.AppStartModel.ATEClient)
                Application.Run(new frmATEClient());
            else if (p.AppStart == p.AppStartModel.YRServer)
                Application.Run(new frmYRServer());
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


        /// <summary>
        /// download skin file
        /// </summary>
        /// <returns></returns>
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
