using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATEYieldRateStatisticSystem
{
    public partial class frmATEYR : Form
    {
        public frmATEYR()
        {
            InitializeComponent();
        }



        static int INTERNAL = 300;
        private int iRefreshTime = INTERNAL;
        string LastFresh = "Last Refresh Data Time:";
        string NextFresh = "Next Refresh Data Left(s):";

        private void frmATEYR_Load(object sender, EventArgs e)
        {
            loadUI();
            loadAllYR();
            timer1.Start();
        }


        private void loadAllYR()
        {
            loadATEYR("AS2");
            loadATEYR("AS3");
            loadATEYR("AS4");
            loadATEYR("AS5");
            loadATEYR("AS6");
            loadATEYR("AS7");
            loadATEYR("AS8");
            loadATEYR("AS9");
        }

        private void loadUI()
        {
            //
            txtAS2_YR_A.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtAS2_YR_B.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtAS2_YR_D.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtAS2_YR_C.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtAS3_YR_A.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtAS3_YR_B.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtAS3_YR_D.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtAS3_YR_C.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtAS4_YR_A.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtAS4_YR_B.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtAS4_YR_C.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtAS4_YR_D.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtAS5_YR_A.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtAS5_YR_B.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtAS5_YR_C.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtAS5_YR_D.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtAS6_YR_A.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtAS6_YR_B.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtAS6_YR_C.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtAS6_YR_D.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtAS7_YR_A.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtAS7_YR_B.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtAS7_YR_C.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtAS7_YR_D.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtAS8_YR_A.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtAS8_YR_B.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtAS8_YR_C.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtAS8_YR_D.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            txtAS9_YR_A.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtAS9_YR_B.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtAS9_YR_C.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtAS9_YR_D.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            //
            txtAS2_YR_A.Text = "NA";
            txtAS2_YR_A.ForeColor = Color.BlueViolet;
            txtAS2_YR_B.Text = "NA";
            txtAS2_YR_B.ForeColor = Color.BlueViolet;
            txtAS2_YR_D.Text = "NA";
            txtAS2_YR_D.ForeColor = Color.BlueViolet;
            txtAS2_YR_C.Text = "NA";
            txtAS2_YR_C.ForeColor = Color.BlueViolet;

            txtAS3_YR_A.Text = "NA";
            txtAS3_YR_A.ForeColor = Color.BlueViolet;
            txtAS3_YR_B.Text = "NA";
            txtAS3_YR_B.ForeColor = Color.BlueViolet;
            txtAS3_YR_D.Text = "NA";
            txtAS3_YR_D.ForeColor = Color.BlueViolet;
            txtAS3_YR_C.Text = "NA";
            txtAS3_YR_C.ForeColor = Color.BlueViolet;

            txtAS4_YR_A.Text = "NA";
            txtAS4_YR_A.ForeColor = Color.BlueViolet;
            txtAS4_YR_B.Text = "NA";
            txtAS4_YR_B.ForeColor = Color.BlueViolet;
            txtAS4_YR_C.Text = "NA";
            txtAS4_YR_C.ForeColor = Color.BlueViolet;
            txtAS4_YR_D.Text = "NA";
            txtAS4_YR_D.ForeColor = Color.BlueViolet;

            txtAS5_YR_A.Text = "NA";
            txtAS5_YR_A.ForeColor = Color.BlueViolet;
            txtAS5_YR_B.Text = "NA";
            txtAS5_YR_B.ForeColor = Color.BlueViolet;
            txtAS5_YR_C.Text = "NA";
            txtAS5_YR_C.ForeColor = Color.BlueViolet;
            txtAS5_YR_D.Text = "NA";
            txtAS5_YR_D.ForeColor = Color.BlueViolet;

            txtAS6_YR_A.Text = "NA";
            txtAS6_YR_A.ForeColor = Color.BlueViolet;
            txtAS6_YR_B.Text = "NA";
            txtAS6_YR_B.ForeColor = Color.BlueViolet;
            txtAS6_YR_C.Text = "NA";
            txtAS6_YR_C.ForeColor = Color.BlueViolet;
            txtAS6_YR_D.Text = "NA";
            txtAS6_YR_D.ForeColor = Color.BlueViolet;

            txtAS7_YR_A.Text = "NA";
            txtAS7_YR_A.ForeColor = Color.BlueViolet;
            txtAS7_YR_B.Text = "NA";
            txtAS7_YR_B.ForeColor = Color.BlueViolet;
            txtAS7_YR_C.Text = "NA";
            txtAS7_YR_C.ForeColor = Color.BlueViolet;
            txtAS7_YR_D.Text = "NA";
            txtAS7_YR_D.ForeColor = Color.BlueViolet;

            txtAS8_YR_A.Text = "NA";
            txtAS8_YR_A.ForeColor = Color.BlueViolet;
            txtAS8_YR_B.Text = "NA";
            txtAS8_YR_B.ForeColor = Color.BlueViolet;
            txtAS8_YR_C.Text = "NA";
            txtAS8_YR_C.ForeColor = Color.BlueViolet;
            txtAS8_YR_D.Text = "NA";
            txtAS8_YR_D.ForeColor = Color.BlueViolet;

            txtAS9_YR_A.Text = "NA";
            txtAS9_YR_A.ForeColor = Color.BlueViolet;
            txtAS9_YR_B.Text = "NA";
            txtAS9_YR_B.ForeColor = Color.BlueViolet;
            txtAS9_YR_C.Text = "NA";
            txtAS9_YR_C.ForeColor = Color.BlueViolet;
            txtAS9_YR_D.Text = "NA";
            txtAS9_YR_D.ForeColor = Color.BlueViolet;

            //
            lblLastFreshInfo.Text = LastFresh + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            lblNextFreshInfo.Text = NextFresh + iRefreshTime;

        }



        /// <summary>
        /// load ate yr by line
        /// </summary>
        /// <param name="line">line,eg,as2,as3,as4,as5,as6,as7,as8,as9</param>
        private void loadATEYR(string line)
        {
            string sql = "SELECT DISTINCT fixtureid from atedata where line = '" + line + "' and  testtime BETWEEN '" + DateTime.Now.ToString("yyyyMMdd") + "000000" + "' and '" + DateTime.Now.ToString("yyyyMMdd") + "235959" + "'";
            List<string> fixture = new List<string>();
            fixture = p.queryMySql(p.connString, sql);

            if (fixture.Count > 0)
            {
                foreach (string item in fixture)
                {
                    sql = "select sum(case when testresult = 'PASS' then 1 else 0 end)/count(usn) as yr from " + p.DatabaseTable.atedata.ToString() + " where line ='" + line + "' and fixtureid ='" + item + "' and  testtime BETWEEN '" + DateTime.Now.ToString("yyyyMMdd") + "000000" + "' and '" + DateTime.Now.ToString("yyyyMMdd") + "235959" + "'";
                    switch (line.ToUpper().Trim())
                    {
                        case "AS2":                            
                            queryYr4Display(sql, line, item, txtAS2_YR_B, txtAS2_YR_A, txtAS2_YR_C, txtAS2_YR_D);
                           break;
                        case "AS3":                            
                           queryYr4Display(sql, line, item, txtAS3_YR_B, txtAS3_YR_A, txtAS3_YR_C, txtAS3_YR_D);
                            break;
                        case "AS4":
                            queryYr4Display(sql, line, item, txtAS4_YR_B, txtAS4_YR_A, txtAS4_YR_C, txtAS4_YR_D);
                            break;
                        case "AS5":
                            queryYr4Display(sql, line, item, txtAS5_YR_B, txtAS5_YR_A, txtAS5_YR_C, txtAS5_YR_D);
                            break;
                        case "AS6":
                            queryYr4Display(sql, line, item, txtAS6_YR_B, txtAS6_YR_A, txtAS6_YR_C, txtAS6_YR_D);
                            break;
                        case "AS7":
                            queryYr4Display(sql, line, item, txtAS7_YR_B, txtAS7_YR_A, txtAS7_YR_C, txtAS7_YR_D);
                            break;
                        case "AS8":
                            queryYr4Display(sql, line, item, txtAS8_YR_B, txtAS8_YR_A, txtAS8_YR_C, txtAS8_YR_D);
                            break;
                        case "AS9":
                            queryYr4Display(sql, line, item, txtAS9_YR_B, txtAS9_YR_A, txtAS9_YR_C, txtAS9_YR_D);
                            break;
                        default:
                            break;
          
                    }
                }
            }

            // sql = "SELECT line,fixtureid,date_format(testtime,'%Y-%m-%d %H:00:00') as time1 from " + p.DatabaseTable.ftdata.ToString() + " WHERE testtime BETWEEN '" + startdatevalue.ToString("yyyyMMddHHmmss") + "' and '" + enddatatimevalue.ToString("yyyyMMddHHmmss") + "' group by line,fixtureid,time1";
            // sql = "select sum(case when firstpass = 'YES' then 1 else 0 end)/count(usn) as fpy ,sum(case when testresult = 'PASS' then 1 else 0 end)/count(usn) as yr from " + p.DatabaseTable.atedata.ToString() + " where line ='" + ln + "' and fixtureid ='" + fi + "' and testtime BETWEEN '" + st + "' and '" + et + "'";
            //string sql = "SELECT line,fixtureid,date_format(testtime,'%Y-%m-%d %H:00:00') as time1 from " + p.DatabaseTable.ftdata.ToString() + " WHERE  testtime BETWEEN '" + DateTime.Now.ToString("yyyyMMdd") + "000000" + "' and '" + DateTime.Now.ToString("yyyyMMdd") + "235959"  +"' group by line,fixtureid,time1";


        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="yr"></param>
        private void changetextforcolor(TextBox textbox, double yr)
        {
            if (yr >= 0.985)
                textbox.ForeColor = Color.Lime;
            else if (yr >= 0.95)
                textbox.ForeColor = Color.Yellow;
            else
                textbox.ForeColor = Color.Red;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="line"></param>
        /// <param name="fixtureid"></param>
        /// <param name="ate1LB"></param>
        /// <param name="ate1RA"></param>
        /// <param name="ate2LC"></param>
        /// <param name="ate2RD"></param>
        private void queryYr4Display(string sql, string line,string fixtureid, TextBox ate1LB, TextBox ate1RA, TextBox ate2LC, TextBox ate2RD)
        {
            MySqlConnection conn = new MySqlConnection(p.connString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            MySqlDataReader re = cmd.ExecuteReader();
            if (re.HasRows)
            {
                while (re.Read())
                {
                    double o_yr = Convert.ToDouble(re["yr"]);
                    string yr = string.Format("{0:P}", re["yr"]);
                    if (fixtureid.ToUpper().Contains(line +"-ATE1") && fixtureid.ToUpper().EndsWith("-L"))
                    {             
                        ate1LB.Text = yr;
                        changetextforcolor(ate1LB, o_yr);
                     }
                    if (fixtureid.ToUpper().Contains(line +"-ATE1") && fixtureid.ToUpper().EndsWith("-R"))
                    {                       
                        ate1RA.Text = yr;
                        changetextforcolor(ate1RA, o_yr);
                    }
                    if (fixtureid.ToUpper().Contains(line +"-ATE2") && fixtureid.ToUpper().EndsWith("-L"))
                    {
                        ate2LC.Text = yr;
                        changetextforcolor(ate2LC, o_yr);
                    }
                    if (fixtureid.ToUpper().Contains(line  + "-ATE2") && fixtureid.ToUpper().EndsWith("-R"))
                    {
                        ate2RD.Text = yr;
                        changetextforcolor(ate2RD, o_yr);
                    }

                }
            }
            conn.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            iRefreshTime--;
            lblNextFreshInfo.Text = NextFresh + iRefreshTime;
            if (iRefreshTime == 0)
            {
                loadAllYR();
                iRefreshTime = INTERNAL;
                lblLastFreshInfo.Text = LastFresh + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                lblNextFreshInfo.Text = NextFresh + iRefreshTime;

            }
            timer1.Start();
        }
    }
}
