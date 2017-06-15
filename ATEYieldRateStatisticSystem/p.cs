using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Edward;
namespace ATEYieldRateStatisticSystem
{
    public  class p
    {

        #region 参数

        public static string AppFolder = @".\ATEYieldRate";
        public static string iniFilePath = AppFolder + @"\ATEYieldRate.ini";
        public static AppStartModel AppStart;

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

         
        }


    }
}
