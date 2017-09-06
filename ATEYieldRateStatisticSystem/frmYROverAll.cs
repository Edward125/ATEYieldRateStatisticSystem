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
    public partial class frmYROverAll : Form
    {
        public frmYROverAll()
        {
            InitializeComponent();
            skinEngine1.SkinFile = p.AppFolder + @"\MacOS.ssk";
        }

        double ateyr = 0;
        double ftyr = 0;


        //导入判断网络是否连接的 .dll  
        [DllImport("wininet.dll", EntryPoint = "InternetGetConnectedState")]
        //判断网络状况的方法,返回值true为连接，false为未连接  
        public extern static bool InternetGetConnectedState(out int conState, int reder);


        static int INTERNAL = 300;
        private int iRefreshTime = INTERNAL;
        string LastFresh = "Last Refresh Data Time:";
        string NextFresh = "Next Refresh Data Left(s):";

        private void frmYROverAll_Load(object sender, EventArgs e)
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
                //loadAllFR();
                loadQty("ATE");
                loadQty("FT");
                this.Invalidate();
                timer1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Detect your pc is not connect to network,pls retry...", "NOT CONNECT NETWORK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void frmYROverAll_Paint(object sender, PaintEventArgs e)
        {
            ////Graphics g = e.Graphics; //创建画板,这里的画板是由Form提供的.            
            ////Pen p = new Pen(Color.Blue, 25);//定义了一个蓝色,宽度为的画笔         
            ////g.DrawEllipse(p, 100, 150, 260, 260);//在画板上画椭圆,起始坐标为(10,10),外接矩形的宽为,高为
            ////g.DrawEllipse(p, 450, 150, 260, 260);//在画板上画椭圆,起始坐标为(10,10),外接矩形的宽为,高为
            ////p = new Pen(Color.Blue , 1);
            ////g.DrawRectangle(p, 70, 120, 320, 320);
            ////g.DrawRectangle(p, 420, 120, 320, 320);
            ////System.Drawing.Font font = new System.Drawing.Font("Agency FB", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ////SolidBrush brush = new SolidBrush(Color.Blue);
            ////g.DrawString("99.99%", font, brush, 140F, 230F);
            ////g.DrawString("99.99%", font, brush, 490F, 230F);


           // Graphics g = e.Graphics; //创建画板,这里的画板是由Form提供的. 
           // Font  font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           //SolidBrush  brush = new SolidBrush(Color.Black);
           // g.DrawString("ATE Overall Yield Rate", font, brush, 150F, 100F);
           // g.DrawString("FT Overall Yield Rate", font, brush, 500F, 100F);


            //if (ateyr >= 0.985)
            //    gdrawYR(e, "ATE",Color.Green, ateyr);
            //else if (ateyr >= 0.95)
            //    gdrawYR(e, "ATE",Color.DarkOrange , ateyr);
            //else if (ateyr > 0)
            //    gdrawYR(e, "ATE",Color.Red, ateyr);
            //else
            //    gdrawYR(e,"ATE", Color.DimGray , ateyr );

            //if (ftyr >= 0.985)
            //    gdrawYR(e, "FT", Color.Green, ateyr);
            //else if (ftyr >= 0.95)
            //    gdrawYR(e, "FT", Color.DarkOrange, ateyr);
            //else if (ftyr > 0)
            //    gdrawYR(e, "FT", Color.Red, ateyr);
            //else
            //    gdrawYR(e, "FT", Color.DimGray, ateyr);
            gdrawYR(e, ateyr, ftyr);

        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (ateyr < 1)
                ateyr = ateyr + 0.005;
            else
                ateyr = 0.9400;

            this.Invalidate();
            //Graphics g = this.grpATE .CreateGraphics();
            //Rectangle PicRect = this.grpATE .ClientRectangle;
            //Pen p = new Pen(Color.Blue, 25);//定义了一个蓝色,宽度为的画笔
            ////g.DrawEllipse(p, PicRect.Width  / 2, PicRect.Width  / 2, PicRect.Height  / 2, PicRect.Height  / 2);
            //g.DrawEllipse( p,PicRect.Width/7, PicRect.Height/7 , PicRect.Height/4 *3, PicRect.Width /4*3);
            //g = this.grpFT.CreateGraphics();
            //PicRect = this.grpFT.ClientRectangle;
            //g.DrawEllipse(p, PicRect.Width / 7, PicRect.Height / 7, PicRect.Height / 4 * 3, PicRect.Width / 4 * 3);

            //g.Clear(this.BackColor);           
            //gDraw(grpATE, Color.Blue);
           // gDraw(grpFT, Color.Blue);
        }







        private void gdrawYR(PaintEventArgs e, double ateyr,double ftyr)
        {

            Graphics g = e.Graphics; //创建画板,这里的画板是由Form提供的. 
            g.Clear(this.BackColor);

            //ate
            Color color = changecolorbyyr(ateyr);
            Pen p = new Pen(color, 25);//定义了一个蓝色,宽度为的画笔        
            g.DrawEllipse(p, 100, 150, 260, 260);//在画板上画椭圆,起始坐标为(10,10),外接矩形的宽为,高为
            p = new Pen(color, 1);
            g.DrawRectangle(p, 70, 120, 320, 320);
            System.Drawing.Font font = new System.Drawing.Font("Agency FB", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            SolidBrush brush = new SolidBrush(color);
            g.DrawString(string.Format("{0:P}", ateyr), font, brush, 135F, 240F);

            //ft
            color = changecolorbyyr(ftyr);
            p = new Pen(color, 25);//定义了一个蓝色,宽度为的画笔   
            g.DrawEllipse(p, 450, 150, 260, 260);//在画板上画椭圆,起始坐标为(10,10),外接矩形的宽为,高为   
            p = new Pen(color, 1);
            g.DrawRectangle(p, 420, 120, 320, 320);
             brush = new SolidBrush(color);
            g.DrawString(string.Format("{0:P}", ftyr ) , font, brush, 485F, 240F);
            //
            font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            brush = new SolidBrush(Color.Black);    
            g.DrawString("ATE Overall Yield Rate", font, brush, 150F, 100F);
            g.DrawString("FT Overall Yield Rate", font, brush, 500F, 100F);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="area"></param>
        /// <param name="color"></param>
        private void gDraw(GroupBox  area, Color color)
        {
            Graphics g = area.CreateGraphics();
            g.Clear(this.BackColor);
            Rectangle PicRect = area.ClientRectangle;
            Pen p = new Pen(color , 30);//定义了一个蓝色,宽度为的画笔
            g.DrawEllipse(p, PicRect.Width / 7, PicRect.Height / 7, PicRect.Height / 4 * 3, PicRect.Width / 4 * 3);
           
           System.Drawing.Font font =  new System.Drawing.Font("Agency FB", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           SolidBrush brush = new SolidBrush (Color.Blue );
           g.DrawString("99.99%", font, brush, 180F, 200F);
        }

        private void grpATE_Paint(object sender, PaintEventArgs e)
        {
           // gDraw(grpATE, Color.Blue);
            //gDraw(grpFT, Color.Blue);
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
            if (mfgtype.ToUpper() == "FT")
                txtFTQtyInfo.Text = DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00 ~ Now, Production Qty.:" + Qty;
        }

        /// <summary>
        /// 
        /// </summary>
        private void loadAllFR()
        {
            loadFR("ATE", out ateyr);
            loadFR("FT", out ftyr);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="mfgtype">ATE or FT</param>
        private void loadFR(string mfgtype,out double yr)
        {

            double _yr = 0;
            DataSet ds = new DataSet();
            string sql = "";
            if (mfgtype.ToUpper() == "ATE")
                sql = "select sum(case when testresult = 'PASS' then 1 else 0 end)/count(usn) as YieldRate from " + p.DatabaseTable.atedata.ToString() + " where  testtime BETWEEN '" + DateTime.Now.ToString("yyyyMMdd") + "000000" + "' and '" + DateTime.Now.ToString("yyyyMMdd") + "235959" + "'";
            if (mfgtype.ToUpper() == "FT")
                sql = "select sum(case when testresult = 'PASS' then 1 else 0 end)/count(usn) as YieldRate from " + p.DatabaseTable.ftdata.ToString() + " where  testtime BETWEEN '" + DateTime.Now.ToString("yyyyMMdd") + "000000" + "' and '" + DateTime.Now.ToString("yyyyMMdd") + "235959" + "'";
            queryMysqlShowDataSet(sql, ref ds);
            for (int i = 0; i < ds.Tables["Query"].Rows.Count; i++)
            {
                for (int j = 0; j < ds.Tables["Query"].Columns.Count; j++)
                {
                    //xData.Add(ds.Tables["Query"].Columns[j].ToString() + ":" + string.Format("{0:P}", ds.Tables["Query"].Rows[i][j]));
                   // xData.Add(ds.Tables["Query"].Columns[j].ToString());
                    try
                    {
                       // yData.Add(Convert.ToDouble(ds.Tables["Query"].Rows[i][j]));
                        _yr = Convert.ToDouble(ds.Tables["Query"].Rows[i][j]);
                    }
                    catch (InvalidCastException)
                    {

                       // yData.Add(0.000);
                        _yr = 0.00;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    // MessageBox.Show(ds.Tables["Query"].Rows[i][j].ToString());
                   
                }
            }

            yr = _yr;

            //if (mfgtype == "ATE")
            //{
            //    chartATE.Series[0]["PieLabelStyle"] = "Inside";//将文字移到外侧
            //    chartATE.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            //    chartATE.Series[0].Points.DataBindXY(xData, yData);
            //}
            //if (mfgtype == "FT")
            //{
            //    chartFT.Series[0]["PieLabelStyle"] = "Inside";//将文字移到外侧
            //    chartFT.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            //    chartFT.Series[0].Points.DataBindXY(xData, yData);
            //}


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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="yr"></param>
        /// <returns></returns>
        private Color changecolorbyyr(double yr)
        {
            Color _color = Color.DimGray;

            if (yr >= 0.985)
                _color = Color.Green;
            else if (ateyr >= 0.95)
                _color = Color.DarkOrange;
            else  
                _color = Color.Red;
          
            if (yr == 0)
                  _color = Color.DimGray; 

            return _color;
        }
    }
}
