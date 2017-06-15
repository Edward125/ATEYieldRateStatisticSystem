using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Edward;
using System.Windows.Forms;
namespace ATEYieldRateStatisticSystem
{
    public  class p
    {

        #region 参数

        public static string AppFolder = @".\ATEYieldRate";
        public static string iniFilePath = AppFolder + @"\ATEYieldRate.ini";
        public static AppStartModel AppStart;

        //ATE Client
        public static string SFCSWebservice = @"http://10.62.201.100/Tester.WebService/WebService.asmx"; //default
        public static string AutoLookLogPath = string.Empty;
        public static string TestlogPath = string.Empty;
        public static string PassFlag = "0000";//default
        public static string FileFrontFlag = "log";
        public static string FaonFaoffBase = "0";//default 
        // public static string StartEndTime = "1";//default
        public static string FileExtension = ".log";//default
        public static StartEndTimeType StartEndTime = StartEndTimeType.Day830;
        public static LogType Log = LogType.SystemLog; //default


        #endregion

        #region enum


        public enum AppStartModel
        {
            NotSet,
            FTClient,//收集FT良率数据端,在FICT电脑上运行
            YRServer,//查看良率端
            ATEClient//收集ATE良率数据端,在ATE电脑上运行
            
        }

        public enum IniSection
        {
            SysConfig,
            ATEConfig
        }

        enum StartEndTimeType
        {
            Day800,
            Day830
        }

        enum LogType
        {
            SystemLog,        //系统事件发生记录log
            SqlTempLog,       //无法连接到数据库时,需要上传到数据库的本地log
            BarcodeUploadLog  //检测到上抛未成功,手动上抛的log
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
            IniFile.IniWriteValue(IniSection.ATEConfig .ToString(), "SFCSWebService", SFCSWebservice , iniFilePath);
            IniFile.IniWriteValue(IniSection.ATEConfig .ToString(), "AutoLookLogPath", AutoLookLogPath, iniFilePath);
            IniFile.IniWriteValue(IniSection.ATEConfig .ToString(), "TestLogPath", TestlogPath, iniFilePath);
            IniFile.IniWriteValue(IniSection.ATEConfig .ToString(), "PassFlag", PassFlag, iniFilePath);
            IniFile.IniWriteValue(IniSection.ATEConfig .ToString(), "FileFrontFlag", FileFrontFlag, iniFilePath);
            IniFile.IniWriteValue(IniSection.ATEConfig .ToString(), "FaonFaoffBase", FaonFaoffBase, iniFilePath);
            IniFile.IniWriteValue(IniSection.ATEConfig .ToString(), "FileExtension", FileExtension, iniFilePath);
            IniFile.IniWriteValue(IniSection.ATEConfig.ToString(), "StartEndTime", StartEndTime.ToString(), iniFilePath);
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

            SFCSWebservice  = IniFile.IniReadValue(IniSection.ATEConfig .ToString (),    "WebService", iniFilePath).Trim();
            AutoLookLogPath = IniFile.IniReadValue(IniSection.ATEConfig .ToString (), "AutoLookLogPath", iniFilePath).Trim();
            TestlogPath = IniFile.IniReadValue(IniSection.ATEConfig.ToString(), "TestlogPath", iniFilePath).Trim();
            PassFlag = IniFile.IniReadValue(IniSection.ATEConfig.ToString(), "PassFlag", iniFilePath).Trim().ToUpper();
            FileFrontFlag = IniFile.IniReadValue(IniSection.ATEConfig.ToString(), "FileFrontFlag", iniFilePath).Trim();
            FaonFaoffBase = IniFile.IniReadValue(IniSection.ATEConfig.ToString(), "FaonFaoffBase", iniFilePath).Trim();
            FileExtension = IniFile.IniReadValue(IniSection.ATEConfig.ToString(), "FileExtension", iniFilePath).Trim();
            //(Colors)Enum.Parse(typeof(Colors), "Red")            
            StartEndTime = (StartEndTimeType)Enum.Parse(typeof(StartEndTimeType), IniFile.IniReadValue(IniSection.ATEConfig.ToString(), "StartEndTime", iniFilePath));

        }


    }
}
