using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ATEYieldRateStatisticSystem
{
    public partial class frmYRMonitor : Form
    {
        public frmYRMonitor()
        {
            InitializeComponent();
            skinEngine1.SkinFile = p.AppFolder + @"\MacOS.ssk";
        }

        //导入判断网络是否连接的 .dll  
        [DllImport("wininet.dll", EntryPoint = "InternetGetConnectedState")]
        //判断网络状况的方法,返回值true为连接，false为未连接  
        public extern static bool InternetGetConnectedState(out int conState, int reder);


        static int INTERNAL = 300;
        private int iRefreshTime = INTERNAL;
        string LastFresh = "Last Refresh Data Time:";
        string NextFresh = "Next Refresh Data Left(s):";
       

        private void frmYRMonitor_Load(object sender, EventArgs e)
        {
            loadUI();
          
        }

        private void loadUI()
        {
            int n = 0;
            if (InternetGetConnectedState(out n, 0))
            {
                loadAllFR();
                lblLastFreshInfo.Text = LastFresh + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                lblNextFreshInfo.Text = NextFresh + iRefreshTime;
                loadQty("ATE");
                loadQty("FT");
                timer1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Detect your pc is not connect to network,pls retry...", "NOT CONNECT NETWORK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }




        private void loadQty(string mfgtype)
        {
            string sql = "";
            int Qty = -1;
            if (mfgtype.ToUpper() == "ATE")
            {
                sql = "select count(usn) from " + p.DatabaseTable.atedata.ToString() + " where  testtime BETWEEN '" + DateTime.Now.ToString("yyyyMMdd") + "000000" + "' and '" + DateTime.Now.ToString("yyyyMMdd") + "235959" + "'";
            }
            if (mfgtype.ToUpper() == "FT")
            {
                sql = "select count(usn) from " + p.DatabaseTable.ftdata.ToString() + " where  testtime BETWEEN '" + DateTime.Now.ToString("yyyyMMdd") + "000000" + "' and '" + DateTime.Now.ToString("yyyyMMdd") + "235959" + "'";
            }

            Qty = p.queryMysqlCount(p.connString, sql);
            if (mfgtype.ToUpper() == "ATE")
                txtATEQtyInfo.Text = DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00 ~ Now, Production Qty.:" + Qty;
            if (mfgtype .ToUpper () =="FT")
                txtFTQtyInfo.Text = DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00 ~ Now, Production Qty.:" + Qty;
        }

        /// <summary>
        /// 
        /// </summary>
        private void loadAllFR()
        {
            loadFR("ATE");
            loadFR("FT");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="mfgtype">ATE or FT</param>
        private void loadFR(string mfgtype)
        {
            List<string> xData = new List<string>();
            List<double> yData = new List<double>();
            DataSet ds = new DataSet();
            string sql = "";
            if (mfgtype.ToUpper() == "ATE")
                sql = "select sum(case when testresult = 'PASS' then 1 else 0 end)/count(usn) as YieldRate, sum(case when testresult = 'FAIL' then 1 else 0 end)/count(usn) as FailRate  from " + p.DatabaseTable.atedata.ToString() + " where  testtime BETWEEN '" + DateTime.Now.ToString("yyyyMMdd") + "000000" + "' and '" + DateTime.Now.ToString("yyyyMMdd") + "235959" + "'";
            if (mfgtype.ToUpper()  == "FT")
                sql = "select sum(case when testresult = 'PASS' then 1 else 0 end)/count(usn) as YieldRate, sum(case when testresult = 'FAIL' then 1 else 0 end)/count(usn) as FailRate  from " + p.DatabaseTable.ftdata.ToString() + " where  testtime BETWEEN '" + DateTime.Now.ToString("yyyyMMdd") + "000000" + "' and '" + DateTime.Now.ToString("yyyyMMdd") + "235959" + "'";
            queryMysqlShowDataSet(sql, ref ds);
            for (int i = 0; i < ds.Tables["Query"].Rows.Count; i++)
            {
                for (int j = 0; j < ds.Tables["Query"].Columns.Count; j++)
                {
                    //xData.Add(ds.Tables["Query"].Columns[j].ToString() + ":" + string.Format("{0:P}", ds.Tables["Query"].Rows[i][j]));
                    xData.Add(ds.Tables["Query"].Columns[j].ToString());
                    try
                    {
                        yData.Add(Convert.ToDouble(ds.Tables["Query"].Rows[i][j]));
                    }
                    catch (InvalidCastException )
                    {

                        yData.Add(0.000);
                    }
                    catch (Exception ex )
                    {
                        MessageBox.Show(ex.Message);
                    }
                    // MessageBox.Show(ds.Tables["Query"].Rows[i][j].ToString());
                }
            }

            if (mfgtype == "ATE")
            {
                chartATE.Series[0]["PieLabelStyle"] = "Inside";//将文字移到外侧
                chartATE.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
                chartATE.Series[0].Points.DataBindXY(xData, yData);
            }
            if (mfgtype == "FT")
            {
                chartFT.Series[0]["PieLabelStyle"] = "Inside";//将文字移到外侧
                chartFT.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
                chartFT.Series[0].Points.DataBindXY(xData, yData);
            }


        }


        public void queryMysqlShowDataSet(object sql, ref   DataSet ds)
        {
            //DataSet ds = new DataSet();
            List<string> result = new List<string>();
            MySqlConnection conn = new MySqlConnection(p.connString);
            MySqlCommand cmd = new MySqlCommand((string)sql, conn);
            try
            {
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds, "Query");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            iRefreshTime--;
            lblNextFreshInfo.Text = NextFresh + iRefreshTime;
            if (iRefreshTime == 0)
            {
                loadAllFR();
                iRefreshTime = INTERNAL;
                lblLastFreshInfo.Text = LastFresh + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                lblNextFreshInfo.Text = NextFresh + iRefreshTime;

            }
            timer1.Start();
            
        }

        private void chartFT_DoubleClick(object sender, EventArgs e)
        {
          
           if (txtFTQtyInfo.Text.Substring (txtFTQtyInfo.Text.LastIndexOf (':') +1,txtFTQtyInfo.Text.Length -txtFTQtyInfo.Text.LastIndexOf (':')-1) == "0")
            {
                MessageBox.Show("There is no FT Qty. data in the database,can't view F.R. by line.", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void chartATE_DoubleClick(object sender, EventArgs e)
        {
            if (txtATEQtyInfo.Text.Substring(txtATEQtyInfo.Text.LastIndexOf(':') + 1, txtATEQtyInfo.Text.Length - txtATEQtyInfo.Text.LastIndexOf(':') - 1) == "0")
            {
                MessageBox.Show("There is no ATE Qty. data in the database,can't view F.R. by line.", "NO DATA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        
    }
}
