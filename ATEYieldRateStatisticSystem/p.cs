using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Edward;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;


namespace ATEYieldRateStatisticSystem
{
    public  class p
    {

        #region 参数

        public static string AppFolder = @".\ATEYieldRate";
        public static string iniFilePath = AppFolder + @"\ATEYieldRate.ini";
        public static AppStartModel AppStart;

        //ATE Client
        //public static string SFCSWebservice = @"http://10.62.201.100/Tester.WebService/WebService.asmx"; //default
        public static string AutoLookLogPath = string.Empty;
        public static string TestlogPath = string.Empty;
        public static string PassFlag = "0000";//default
        public static string FileFrontFlag = "log";
        public static string FaonFaoffBase = "1";//default 
        // public static string StartEndTime = "1";//default
        public static string FileExtension = ".log";//default
        public static StartEndTimeType StartEndTime = StartEndTimeType.Day830;
        public static LogType Log = LogType.SystemLog; //default
        public static PlantCode ATEPlant = PlantCode.F721;
        public static string SFCS721Webservice =  @"http://10.62.201.100/Tester.WebService/WebService.asmx"; //default
        public static string SFCS722Webservice = @"http://10.62.201.77/Tester.WebService/WebService.asmx"; //default
        public static string TEST721Webservice = @"http://172.0.1.172/Tester.WebService/WebService.asmx"; //default
        public static string TEST722Webservice = @"http://172.0.1.171/Tester.WebService/WebService.asmx"; //default

        #endregion

        #region enum


        public enum AppStartModel
        {
            NotSet,
            FTClient,//收集FT良率数据端,在FICT电脑上运行
            YRServer,//查看良率端
            ATEClient//收集ATE良率数据端,在ATE电脑上运行
          
            
        }


        public enum PlantCode
        {
            F721,
            F722
        }

        public enum IniSection
        {
            SysConfig,
            ATEConfig,
            WebService
        }

       public  enum StartEndTimeType
        {
            Day800,
            Day830
        }

       public  enum LogType
        {
            SystemLog,        //系统事件发生记录log
            SqlTempLog,       //无法连接到数据库时,需要上传到数据库的本地log
            BarcodeUploadLog  //检测到上抛未成功,手动上抛的log
        }

      public  enum BoardType
       {
           Single,
           Panel
       }



        #endregion

        /// <summary>
        /// check app folder
        /// </summary>
        /// <returns></returns>
        public static bool checkFolder()
        {

            if (!Directory.Exists(AppFolder))
            {

                try
                {
                    Directory.CreateDirectory(AppFolder);
                }
                catch (Exception )
                {

                    return false;
                }
  

            }

            return true;
        }

        /// <summary>
        /// create ini file
        /// </summary>
        /// <param name="inifilepath">ini file path </param>
        public static void createIniFile(string inifilepath)
        {
            IniFile.CreateIniFile(inifilepath);
            //File.SetAttributes(inifilepath, FileAttributes.Hidden);
            IniFile.IniWriteValue(IniSection.SysConfig.ToString(), "AppStart", p.AppStart.ToString(), inifilepath);
            IniFile.IniWriteValue(IniSection.SysConfig.ToString(), "Version", Application.ProductVersion.ToString(), iniFilePath);
            //
            //IniFile.IniWriteValue(IniSection.ATEConfig .ToString(), "SFCSWebService", SFCSWebservice , iniFilePath);
            IniFile.IniWriteValue(IniSection.ATEConfig.ToString(), "ATEPlant", ATEPlant.ToString() , iniFilePath);
            IniFile.IniWriteValue(IniSection.ATEConfig .ToString(), "AutoLookLogPath", AutoLookLogPath, iniFilePath);
            IniFile.IniWriteValue(IniSection.ATEConfig .ToString(), "TestLogPath", TestlogPath, iniFilePath);
            IniFile.IniWriteValue(IniSection.ATEConfig .ToString(), "PassFlag", PassFlag, iniFilePath);
            IniFile.IniWriteValue(IniSection.ATEConfig .ToString(), "FileFrontFlag", FileFrontFlag, iniFilePath);
            IniFile.IniWriteValue(IniSection.ATEConfig .ToString(), "FaonFaoffBase", FaonFaoffBase, iniFilePath);
            IniFile.IniWriteValue(IniSection.ATEConfig .ToString(), "FileExtension", FileExtension, iniFilePath);
            IniFile.IniWriteValue(IniSection.ATEConfig.ToString(), "StartEndTime", StartEndTime.ToString(), iniFilePath);
            //
            IniFile.IniWriteValue(IniSection.WebService.ToString(), "SFCS721Webservice", SFCS721Webservice, inifilepath);
            IniFile.IniWriteValue(IniSection.WebService.ToString(), "SFCS722Webservice", SFCS722Webservice, inifilepath);
            IniFile.IniWriteValue(IniSection.WebService.ToString(), "TEST721Webservice", TEST721Webservice, inifilepath);
            IniFile.IniWriteValue(IniSection.WebService.ToString(), "TEST722Webservice", TEST722Webservice, inifilepath);

        }

        /// <summary>
        /// read ini file value 
        /// </summary>
        /// <param name="inifilepath">ini file path</param>
        public static void readIniValue(string inifilepath)
        {
            string _tempValue = IniFile.IniReadValue(IniSection.SysConfig.ToString(), "AppStart", inifilepath);
            if (!string.IsNullOrEmpty(_tempValue))
                AppStart = (AppStartModel)Enum.Parse(typeof(AppStartModel), _tempValue);

            //SFCSWebservice  = IniFile.IniReadValue(IniSection.ATEConfig .ToString (), "WebService", iniFilePath).Trim();
           _tempValue =  IniFile.IniReadValue(IniSection.ATEConfig.ToString(), "ATEPlant", iniFilePath).Trim();

           if (!string.IsNullOrEmpty(_tempValue))
               ATEPlant = (PlantCode)Enum.Parse(typeof(PlantCode), _tempValue);

            AutoLookLogPath = IniFile.IniReadValue(IniSection.ATEConfig .ToString (), "AutoLookLogPath", iniFilePath).Trim();
            TestlogPath = IniFile.IniReadValue(IniSection.ATEConfig.ToString(), "TestlogPath", iniFilePath).Trim();
            PassFlag = IniFile.IniReadValue(IniSection.ATEConfig.ToString(), "PassFlag", iniFilePath).Trim().ToUpper();
            FileFrontFlag = IniFile.IniReadValue(IniSection.ATEConfig.ToString(), "FileFrontFlag", iniFilePath).Trim();
            FaonFaoffBase = IniFile.IniReadValue(IniSection.ATEConfig.ToString(), "FaonFaoffBase", iniFilePath).Trim();
            FileExtension = IniFile.IniReadValue(IniSection.ATEConfig.ToString(), "FileExtension", iniFilePath).Trim();
            //(Colors)Enum.Parse(typeof(Colors), "Red")            
            StartEndTime = (StartEndTimeType)Enum.Parse(typeof(StartEndTimeType), IniFile.IniReadValue(IniSection.ATEConfig.ToString(), "StartEndTime", iniFilePath));
            //
            SFCS721Webservice = IniFile.IniReadValue(IniSection.WebService.ToString(), "SFCS721Webservice ", iniFilePath).Trim();
            SFCS722Webservice = IniFile.IniReadValue(IniSection.WebService.ToString(), "SFCS722Webservice ", iniFilePath).Trim();
            TEST721Webservice = IniFile.IniReadValue(IniSection.WebService.ToString(), "TEST721Webservice ", iniFilePath).Trim();
            TEST721Webservice = IniFile.IniReadValue(IniSection.WebService.ToString(), "TEST721Webservice ", iniFilePath).Trim();


        }

        /// <summary>
        /// open folder
        /// </summary>
        /// <param name="textbox"></param>
        public static  void openFolder(TextBox textbox)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
                textbox.Text = fbd.SelectedPath;

        }


        #region 延時子程式

        /// <summary>
        /// 延時子程序
        /// </summary>
        /// <param name="interval">延時的時間，單位毫秒</param>
        public static  void Delay(double interval)
        {
            DateTime time = DateTime.Now;
            double span = interval * 10000;
            while (DateTime.Now.Ticks - time.Ticks < span)
            {
                Application.DoEvents();
            }

        }

        #endregion



        private static  string PublicResourceFileName = Application.ProductName + ".Resources";
        /// <summary>
        /// 从资源文件中读取一个资源 
        /// </summary>
        /// <param name="resFile">资源文件名称 命名空间+文件名称</param>
        /// <param name="resName">要读取的资源名称</param>
        /// <returns>返回一个资源 读取失败返回NULL</returns>
        public static  System.Object ReadFromResourceFile(String resName)
        {
            try
            {
                Assembly myAssembly;
                myAssembly = Assembly.GetExecutingAssembly();
                System.Resources.ResourceManager rm = new
                  System.Resources.ResourceManager(PublicResourceFileName, myAssembly);
                return rm.GetObject(resName);
            }
            catch (Exception)
            {
                return null;
            }
        }



        /// <summary>
        /// 获取资源图片
        /// </summary>
        /// <param name="name">文件名</param>
        /// <returns>资源图片</returns>
        public static  Bitmap GetResourceImage(String name)
        {
            Object tempbitmap = null;
            tempbitmap = ReadFromResourceFile(name);
            if (tempbitmap.GetType().Equals(typeof(Bitmap)))
            {
                return (Bitmap)tempbitmap;
            }
            return null;
        }


        /// <summary>
        /// 设置ListItem的字体大小,颜色
        /// </summary>
        /// <param name="li">需要设置的那一项</param>
        /// <param name="fontSize">字体大小,如9</param>
        public static void SetListItemFont(ListViewItem li, int fontSize)//Color fontColor)
        {
            System.Drawing.Font myFont;
            string strName = "Calibri";
            FontStyle myFontStyle;
            int sngSize;
            sngSize = fontSize;
            //int intColorR = 255;
            //int intColorG = 0;
            //int intColorB = 0;
            myFontStyle = FontStyle.Bold;
            Color myColor;
            myColor = Color.Red;
            //myColor = fontColo

            FontFamily myFontFamily;
            myFontFamily = new FontFamily(strName);
            myFont = new Font(myFontFamily, sngSize, myFontStyle, GraphicsUnit.Point);
            li.Font = myFont;
        }


    }
}
