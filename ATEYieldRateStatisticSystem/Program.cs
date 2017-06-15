using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Edward;
using System.Drawing;
using System.IO;

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
            SplashForm.StartSplash(@".\splash.png", Color.FromArgb(128, 128, 128));
            //Application.Run (new SplashForm());
            // simulating operations at startup '
            if (!p.checkFolder())
            {
                MessageBox.Show("Create app folder fail,program will exit.", "Create Folder Fail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                System.Threading.Thread.Sleep(2000);
                //SplashForm.CloseSplash();
                return;
            }


            if (!File.Exists(@".\IrisSkin4.dll"))
            {
                if (!downloadIrisSkin4())
                {
                    System.Threading.Thread.Sleep(2000); 
                    //SplashForm.CloseSplash();
                    return;
                }
            }

            System.Threading.Thread.Sleep(1000); 
            // close the splash screen'
            SplashForm.CloseSplash();
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
                byte[] template = Properties.Resources.IrisSkin4 ;
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
                    MessageBox.Show (ex.Message);
                    return false;
                }

            }
            return true;
        }



        private static bool downloadSkin()
        {

            return true;
        }
    }
}
