using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Edward;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using System.Data.SQLite;
using System.Data;


namespace ATEYieldRateStatisticSystem
{
    public  class p
    {

        #region 参数

        public static string AppFolder = @".\ATEYieldRate";
        public static string iniFilePath = AppFolder + @"\ATEYieldRate.ini";
        public static AppStartModel AppStart;
        
        //
        public static string LocalDB = AppFolder + @"\DB.sqlite";        
        public static string LocalDBConnectionString = "Data Source=" + LocalDB;

        //ATE Client
        //public static string SFCSWebservice = @"http://10.62.201.100/Tester.WebService/WebService.asmx"; //default
        public static string AutoLookLogPath = string.Empty;
        public static string TestlogPath = string.Empty;
        public static string BackupPath = string.Empty;
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
        //public static List<string> ATEBeforStage = new List<string>();
        public static STAGE ATEStage;
        //public static List<string> ATEAfterStage = new List<string>();
        public static List<STAGE> ATEBeforeStage = new List<STAGE>();
        public static List<STAGE> ATEAfterStage = new List<STAGE>();
        public static List<STAGE> ATEOtherStage = new List<STAGE>();
        public static string ATEFixtureID = string.Empty;

        //
        public static string PCBLine = string.Empty;
        
        #endregion


        #region StageList

            //AA
           public  static STAGE AA = new STAGE("AA");          
            //AO
           public static STAGE AO = new STAGE("AO");
            //AB
           public static STAGE AB = new STAGE("AB");     
            //AC
           public static STAGE AC = new STAGE("AC");      
            //AD
           public static STAGE AD = new STAGE("AD"); 
            //AG
           public static STAGE AG = new STAGE("AG");        
            //AL
           public static STAGE AL = new STAGE("AL");
           //AY
           public static STAGE AY = new STAGE("AY");
           //AZ
           public static STAGE AZ = new STAGE("AZ");
           //CJ
           public static STAGE CJ = new STAGE("CJ");
           //CS
           public static STAGE CS = new STAGE("CS");
           //EA
           public static STAGE EA = new STAGE("EA");
           //FA
           public static STAGE FA = new STAGE("FA");
           //IB
           public static STAGE IB = new STAGE("IB");
           //IC
           public static STAGE IC = new STAGE("IC");
           //ID
           public static STAGE ID = new STAGE("ID");
           //IE
           public static STAGE IE = new STAGE("IE");
           //IF
           public static STAGE IF = new STAGE("IF");
           //IG
           public static STAGE IG = new STAGE("IG");
           //PA
           public static STAGE PA = new STAGE("PA");
        //QA
           public static STAGE QA = new STAGE("QA");
           //QB 
           public static STAGE QB = new STAGE("QB");
           //QC
           public static STAGE QC = new STAGE("QC");
           //QD
           public static STAGE QD = new STAGE("QD");
           //QE
           public static STAGE QE = new STAGE("QE");
           //QF
           public static STAGE QF = new STAGE("QF");
           //QG
           public static STAGE QG = new STAGE("QG");
           //QH
           public static STAGE QH = new STAGE("QH");
           //RA
           public static STAGE RA = new STAGE("RA");
           //RC
           public static STAGE RC = new STAGE("RC");
           //RD
           public static STAGE RD = new STAGE("RD");
           //RE
           public static STAGE RE = new STAGE("RE");
           //RF
           public static STAGE RF = new STAGE("RF");
           //RG
           public static STAGE RG = new STAGE("RG");
           //RH
           public static STAGE RH = new STAGE("RH");
           //RI
           public static STAGE RI = new STAGE("RI");
           //RJ
           public static STAGE RJ = new STAGE("RJ");
           //RK
           public static STAGE RK = new STAGE("RK");
           //SA
           public static STAGE SA = new STAGE("SA");
           //SB
           public static STAGE SB = new STAGE("SB");
           //ST
           public static STAGE ST = new STAGE("ST");
           //TA
           public static STAGE TA = new STAGE("TA");
           //TB
           public static STAGE TB = new STAGE("TB");
           //TC
           public static STAGE TC = new STAGE("TC");
           //TD
           public static STAGE TD = new STAGE("TD");
           //TE
           public static STAGE TE = new STAGE("TE");
           //TF
           public static STAGE TF = new STAGE("TF");
           //TG
           public static STAGE TG = new STAGE("TG");
           //TH
           public static STAGE TH = new STAGE("TH");
           //TI
           public static STAGE TI = new STAGE("TI");
           //TJ
           public static STAGE TJ = new STAGE("TJ");
           //TK
           public static STAGE TK = new STAGE("TK");
           //TL
           public static STAGE TL = new STAGE("TL");
           //TY
           public static STAGE TY = new STAGE("TY");
           //ZL
           public static STAGE ZL = new STAGE("ZL");
           //ZM
           public static STAGE ZM = new STAGE("ZM");


        

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

      public enum DatabaseTable
      {
          d_localdata,
          d_tempdata
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
            IniFile.IniWriteValue(IniSection.ATEConfig.ToString(), "BackupPath", BackupPath, iniFilePath);
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
            BackupPath = IniFile.IniReadValue(IniSection.ATEConfig.ToString(), "BackupPath", inifilepath).Trim();
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

        /// <summary>
        /// 
        /// </summary>
        public static  void InitATEStageInfo()
        {
            //AA
           AA.StageValue = @"SMT_input(BOT)";
            //AO   
           AO.StageValue = @"INPUT";
            //AB  
           AB.StageValue = @"System Auto Assign";
            //AC
           AC.StageValue = @"Swap";
            //AD
           AD.StageValue = @"DIP_Touch_Up";
            //AG
           AG.StageValue = @"SMT_TOP";
            //AL
           AL.StageValue = @"PC CHANGE MO STAGE";
            //AY
           AY.StageValue = @"SCTSTNCL top online";
            //AZ
           AZ.StageValue = @"SCTSTNCL bot online";
            //CJ
           AZ.StageValue = @"TLINE TE STAGE";
            //CS
          CS.StageValue = @"CHECK SAMPLE TEST";
            //EA
          EA.StageValue = @"REWORK";
            //FA
          FA.StageValue = @"X_ray";
            //IB
          IB.StageValue = @"DIP_VI";
            //IC
          IC.StageValue = @"DIP_FINAL";
            //ID
          ID.StageValue = @"SMT_RB";
            //IE
          IE.StageValue = @"SMT_VIB";
            //IF
          IF.StageValue = @"SMT_RT";
            //IG
          IG.StageValue = @"SMT_VIT";
            //PA
          PA.StageValue = @"PACKING";
            //QA
          QA.StageValue = @"AQPP";
            //QB
          QB.StageValue = @"PQC";
            //QC
          QC.StageValue = @"OOB";
            //QD
          QD.StageValue = @"F/A OOB";
            //QE
          QE.StageValue = @"F/B OOB";
            //QF
          QF.StageValue = @"Solder A FQC";
            //QG
          QG.StageValue = @"Solder B FQC";
            //QH
          QH.StageValue = @"QC Force";
            //RA
          RA.StageValue = @"SMT Sorting";
            //RC
          RC.StageValue = "DIP Sorting";
            //RD
          RD.StageValue = @"On-line Repair";
            //RE
          RE.StageValue = @"Repair QC";
            //RF
          RF.StageValue = @"BGA";
            //RG
          RG.StageValue = @"Feedback";
            //RH
          RH.StageValue = @"Off-line Repair";
            //RI
          RI.StageValue = @"Clean MB";
            //RJ
          RJ.StageValue = @"DOA Repair";
            //RK
          RK.StageValue = @"FA DOA CHECKIN";
            //SA
          SA.StageValue = @"STOREIN";
            //SB
          SB.StageValue = @"SPI BOT";
            //ST
          ST.StageValue = @"SPI TOP";
            //TA
          TA.StageValue = @"DIP_ATE";
            //TB
          TB.StageValue = @"SMT_ICT";
            //TC
          TC.StageValue = @"DIP_ICT";
            //TD
          TD.StageValue = @"DIP_Function_A";
            //TE
          TE.StageValue = @"DIP_Function_B";
            //TF
          TF.StageValue = @"DIP_Function_L3";
            //TG
          TG.StageValue = @"DIP_Function_CSD";
            //TH
          TH.StageValue = @"DIP_Function_CSD";
            //TI
          TI.StageValue = @"READ FOR AOIA FILE";
            //TJ
          TJ.StageValue = @"READ FOR AOIB FILE";
            //TK
          TK.StageValue = @"AOIB(AOI B Side)";
            //TL
          TL.StageValue = @"AOIA(AOI A Side)";
            //TY
          TY.StageValue = @"DIP_Function_CSD";
            //ZL
          ZL.StageValue = @"MDMS";
            //ZM
          ZM.StageValue = @"Already Store-in";

            //
          ATEBeforeStage.Add(AA);
          ATEBeforeStage.Add(ID);
          ATEBeforeStage.Add(TL);
          ATEBeforeStage.Add(AG);
          ATEBeforeStage.Add(IF);
          ATEBeforeStage.Add(TK);
          ATEBeforeStage.Add(IB);
          //
          ATEStage = TA;
          //
          ATEAfterStage.Add(TD);
          ATEAfterStage.Add(IC);
          ATEAfterStage.Add(QD);
          ATEAfterStage.Add(PA);
          ATEAfterStage.Add(ZM);

            //
           ATEOtherStage.Add(AO);
           ATEOtherStage.Add(AB);
           ATEOtherStage.Add(AC);
           ATEOtherStage.Add(AD);
           ATEOtherStage.Add(AL);
           ATEOtherStage.Add(AY);
           ATEOtherStage.Add(AZ);
           ATEOtherStage.Add(CJ);
           ATEOtherStage.Add(CS);
           ATEOtherStage.Add(EA);
           ATEOtherStage.Add(FA);
           ATEOtherStage.Add(IE);
           ATEOtherStage.Add(IF);
           ATEOtherStage.Add(IG);
           ATEOtherStage.Add(PA);
           ATEOtherStage.Add(QA);
           ATEOtherStage.Add(QB);
           ATEOtherStage.Add(QC);
           ATEOtherStage.Add(QE);
           ATEOtherStage.Add(QF);
           ATEOtherStage.Add(QG);
           ATEOtherStage.Add(QH);
           ATEOtherStage.Add(RC);
           ATEOtherStage.Add(RD);
           ATEOtherStage.Add(RE);
           ATEOtherStage.Add(RF);
           ATEOtherStage.Add(RG);
           ATEOtherStage.Add(RH);
           ATEOtherStage.Add(RI);
           ATEOtherStage.Add(RJ);
           ATEOtherStage.Add(RK);
           ATEOtherStage.Add(SA);
           ATEOtherStage.Add(SB);
           ATEOtherStage.Add(ST);
           ATEOtherStage.Add(TA);
           ATEOtherStage.Add(TB);
           ATEOtherStage.Add(TC);
           ATEOtherStage.Add(TE);
           ATEOtherStage.Add(TF);
           ATEOtherStage.Add(TG);
           ATEOtherStage.Add(TH);
           ATEOtherStage.Add(TI);
           ATEOtherStage.Add(TJ);
           ATEOtherStage.Add(TY);
           ATEOtherStage.Add(ZL);
          // ATEOtherStage.Add(ZM);
        }
        

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



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sfcsresult"></param>
        /// <returns></returns>
        public static string  GetStage(string sfcsresult)
        {
            string _stage = string.Empty;
            if (!string.IsNullOrEmpty(sfcsresult))
            {
                if (sfcsresult.ToLower().Contains(@"already StoreIn".ToLower()))
                    _stage = "ZM";
                else
                {
                    string[] s = sfcsresult.Split(' ');
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (s[i].ToLower().Trim() == "to")
                        {
                            _stage = s[i + 1];
                            break;
                        }
                    }
                }               
            }
            return _stage;
        }


        /// <summary>
        /// 
        /// </summary>
        public class STAGE
        {
            //private readonly string _name = "";
            public string StageName { set; get; }
            public string StageValue { set; get; }

            public STAGE(string stagename)
            {
                StageName = stagename;
            }
        }

        /// <summary>
        /// check db file ,if not exits,create it
        /// </summary>
        /// <param name="_dbfile">db file path</param>
        /// <returns></returns>
        public static bool checkDB(string _dbfile)
        {
            if (!File.Exists(_dbfile))
            {
                try
                {
                    SQLiteConnection.CreateFile(_dbfile);
                    if (!createAllTable())
                    {
                        File.Delete(_dbfile);
                        Environment.Exit(0);
                    }
                    return true;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Create DB Fail." + ex.Message, "Create DB Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }


            }
            return true;
        }

        // string sql = "create table highscores (name varchar(20), score int)";
        /// <summary>
        /// create table 
        /// </summary>
        /// <param name="sql">sql</param>
        /// <returns>create ok,return true;create ng,return false</returns>
        public static bool createTable(string sql,string connectionstring)
        {
            SQLiteConnection conn = new SQLiteConnection(connectionstring);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Connect to database fail," + ex.Message);
                return false;
            }

            try
            {
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Create TABLE fail," + ex.Message);
                conn.Close();
                return false;

            }
            return true;
        }


        /// <summary>
        /// AUTOINCREMENT
        /// </summary>
        /// <returns></returns>
        public static bool createLocalTable()
        {
            //string sql = "CREATE TABLE salespeople ( id INTEGER PRIMARY KEY";
            string sql = @"CREATE TABLE IF NOT EXISTS d_localdata(
id INTEGER  PRIMARY KEY AUTOINCREMENT,
line varchar(3),
plant varchar(4),
usn varchar(20),
model varchar(20),
modelfamily varchar(20),
upn varchar(20),
mo varchar(20),
mac varchar(12),
seq varchar(1),
fixtureid varchar(40),
testresult varchar(4),
firstpass varchar(4),
uploadflag varchar(4),
cycletime varchar(10),
testtime varchar(14),
recordtime varchar(14),
remark varchar(255)
)";

            if (p.createTable(sql, p.LocalDBConnectionString))
                return true;
            else
                return false;
        }

        public static bool createTempTable()
        {
            string sql = @"CREATE TABLE IF NOT EXISTS d_tempdata(
id INTEGER  PRIMARY KEY AUTOINCREMENT,
line varchar(3),
plant varchar(4),
usn varchar(20),
model varchar(20),
modelfamily varchar(20),
upn varchar(20),
mo varchar(20),
mac varchar(12),
seq varchar(1),
fixtureid varchar(40),
testresult varchar(4),
firstpass varchar(4),
uploadflag varchar(4),
cycletime varchar(10),
testtime varchar(14),
recordtime varchar(14),
remark varchar(255)
)";

            if (p.createTable(sql, p.LocalDBConnectionString))
                return true;
            else
                return false;
        }


        public static bool createAllTable()
        {
            if (!createLocalTable ())
                return false ;
            if (!createTempTable())
                return false;
            return true;

        }


        public static bool replaceData2DB(string _tablename,string _usn,
            string _model,string _modelfamily,string _upn,string _mo,
            string _mac,string _seq,string _fixtureid,string _testresult,string _testtime,
            string _firstpass,string _uploadflag,string _remark = "",
            string _cycletime="0")           
    
        {

            SQLiteConnection conn = new SQLiteConnection(p.LocalDBConnectionString);
             using (SQLiteCommand cmd = new SQLiteCommand())
             {
                 conn.Open();
                 cmd.Connection = conn;    
                 SQLiteTransaction trans = conn.BeginTransaction();
                 cmd.Transaction = trans;
                 cmd.CommandText =
                     "REPLACE INTO " + _tablename + @" VALUES (
@_id,
@_line,
@_pant,
@_usn,
@_model,
@_modelfamily,
@_upn,
@_mo,
@_mac,
@_seq,
@_fixtureid,
@_testresult,
@_firstpass,
@_uploadflag,
@_cycletime,
@_testtime,
@_recordtime
@_remark
)";
                 cmd.Parameters.Add(new SQLiteParameter(@"_id", DbType.Int32));
                 cmd.Parameters.Add(new SQLiteParameter(@"_line", DbType.String));
                 cmd.Parameters.Add(new SQLiteParameter(@"_plant", DbType.String));
                 cmd.Parameters.Add(new SQLiteParameter(@"_usn", DbType.String));
                 cmd.Parameters.Add(new SQLiteParameter(@"_model", DbType.String));
                 cmd.Parameters.Add(new SQLiteParameter(@"_modelfamily", DbType.String));
                 cmd.Parameters.Add(new SQLiteParameter(@"_upn", DbType.String));
                 cmd.Parameters.Add(new SQLiteParameter(@"_mo", DbType.String));
                 cmd.Parameters.Add(new SQLiteParameter(@"_mac", DbType.String));
                 cmd.Parameters.Add(new SQLiteParameter(@"_seq", DbType.String));
                 cmd.Parameters.Add(new SQLiteParameter(@"_fixtureid", DbType.String));
                 cmd.Parameters.Add(new SQLiteParameter(@"_testresult", DbType.String));
                 cmd.Parameters.Add(new SQLiteParameter(@"_firstpass", DbType.String));
                 cmd.Parameters.Add(new SQLiteParameter(@"_uploadflag", DbType.String));
                 cmd.Parameters.Add(new SQLiteParameter(@"_cycletime", DbType.String));
                 cmd.Parameters.Add(new SQLiteParameter(@"_testtime", DbType.String));               
                 cmd.Parameters.Add(new SQLiteParameter(@"_recordtime", DbType.String));
                 cmd.Parameters.Add(new SQLiteParameter(@"_remark", DbType.String));
                 //
                 cmd.Parameters[@"_id"] .Value = null;
                 cmd.Parameters[@"_line"].Value  = p.PCBLine;
                 cmd.Parameters[@"_plant"] .Value = p.ATEPlant;
                 cmd.Parameters[@"_usn"].Value = _usn;
                 cmd.Parameters[@"_model"].Value = _model;
                 cmd.Parameters[@"_modelfaily"].Value = _modelfamily;
                 cmd.Parameters[@"_upn"].Value = _upn;
                 cmd.Parameters[@"_mo"].Value = _mo;
                 cmd.Parameters[@"_mac"].Value = _mac;
                 cmd.Parameters[@"_seq"].Value = _seq;
                 cmd.Parameters[@"_fixtureid"].Value = _fixtureid;
                 cmd.Parameters[@"_testresult"].Value = _testresult;
                 cmd.Parameters[@"_firstpass"].Value = _firstpass;
                 cmd.Parameters[@"_uploadflag"].Value = _uploadflag;
                 cmd.Parameters[@"_cycletime"].Value = _cycletime;
                 cmd.Parameters[@"_testtime"].Value = _testtime;
                 cmd.Parameters[@"_recordtime"].Value = DateTime.Now.ToString("yyyyMMddHHmmss");
                 cmd.Parameters[@"_remark"].Value = _remark;
                 cmd.ExecuteNonQuery();
                 trans.Commit();
             }
             conn.Close();

            return true;
        }

    }
}
