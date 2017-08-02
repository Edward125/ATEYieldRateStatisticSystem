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
using System.Threading.Tasks;
using System.Threading;

namespace ATEYieldRateStatisticSystem
{
    public partial class frmYRServer : Form
    {

     //导入判断网络是否连接的 .dll  
     [DllImport("wininet.dll", EntryPoint = "InternetGetConnectedState")]  
     //判断网络状况的方法,返回值true为连接，false为未连接  
      public extern static bool InternetGetConnectedState(out int conState, int reder);  


        public frmYRServer()
        {
            InitializeComponent();
            skinEngine1.SkinFile = p.AppFolder + @"\MacOS.ssk";
        }

        private void frmYRServer_Load(object sender, EventArgs e)
        {
         

            loadUI();
        }

        private void chkUseSql_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseSql.Checked)
            {
                grbQueryOption.Enabled = false;
                txtSql.Enabled = true;
            }
            else
            {
                grbQueryOption.Enabled = true;
                txtSql.Enabled = false;
            }
        }


        private void loadUI()
        {
            //
            this.comboQueryType.SelectedIndex = 0;
            this.comboType.SelectedIndex = 0;
            this.dtpStartTime.Value = DateTime.Now.AddDays(-1);
            int n = 0;
            if (InternetGetConnectedState(out n, 0))
            {
                loadLine(comboLine, this.comboQueryType.Text);
                loadPlant(comboPlant, this.comboQueryType.Text);
                loadModel(comboModel, this.comboQueryType.Text);
                loadUPN(comboUPN, this.comboQueryType.Text);
                loadFixuteID(comboFixtureID, this.comboQueryType.Text);
            }
            else
            {
                MessageBox.Show("Detect your pc is not connect to network,pls retry...", "NOT CONNECT NETWORK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            setListView(lstviewYieldRate, p.QueryType .YieldRate , comboType);
            setListView(lstviewProductionOutput ,p.QueryType.ProductionOutput , comboType);

        }



        private void setListView(ListView listview, p.QueryType querytype,ComboBox mfgtype)
        {
          
            string _mfgtype = mfgtype.Text;
            listview.MultiSelect = false;
            listview.AutoArrange = true;
            listview.GridLines = true;
            listview.FullRowSelect = true;
            listview.Columns.Add("MfgType", 60, HorizontalAlignment.Center);
            listview.Columns.Add("Line", 60, HorizontalAlignment.Center);
            listview.Columns.Add("FixtureID",120, HorizontalAlignment.Center);
            listview.Columns.Add("Time",240 , HorizontalAlignment.Center);
            if (querytype == p.QueryType .YieldRate )
                listview.Columns.Add(querytype.ToString(), 80, HorizontalAlignment.Center);
            if (querytype == p.QueryType .ProductionOutput)
                listview.Columns.Add(querytype.ToString(),120, HorizontalAlignment.Center);
            
            if (querytype == p.QueryType.YieldRate)
            {
                listview.Columns.Add("FPY", 60, HorizontalAlignment.Center);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="combobox"></param>
        private void loadSqlList(string sql, ComboBox combobox)
        {
            //
            List<string> _linelist = new List<string>();
            _linelist = p.queryMySql(p.connString, sql);
            combobox.Items.Clear();
            combobox.Items.Add("----");
            foreach (var item in _linelist)
            {
                combobox.Items.Add(item);
            }
            combobox.Sorted = true;
            combobox.SelectedIndex = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="combobox"></param>
        /// <param name="mfgtype">ATE,FT</param>
        private void loadLine(ComboBox combobox, string mfgtype)
        {
           
            string sql = "SELECT DISTINCT line FROM " + p.DatabaseTable.atedata.ToString();
            if (mfgtype.ToUpper () == "FT")      
                sql = "SELECT DISTINCT line FROM " + p.DatabaseTable.ftdata.ToString();
            loadSqlList(sql, combobox);
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="combobox"></param>
        /// <param name="mfgtype"></param>
        private void loadPlant(ComboBox combobox, string mfgtype)
        {
            string sql = "SELECT DISTINCT plant FROM " + p.DatabaseTable.atedata.ToString();
            if (mfgtype.ToUpper() == "FT")
                sql = "SELECT DISTINCT plant FROM " + p.DatabaseTable.ftdata.ToString();
            loadSqlList(sql, combobox);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="combobox"></param>
        /// <param name="mfgtype"></param>
        /// <param name="plant"></param>
        /// <param name="line"></param>
        private void loadModel(ComboBox combobox, string mfgtype,string plant ="----",string line ="----")
        {
            string sql = "";
            if (plant == "----")
            {
                if (line == "----")
                {
                    sql = "SELECT DISTINCT model FROM " + p.DatabaseTable.atedata.ToString();
                    if (mfgtype.ToUpper() == "FT")
                        sql = "SELECT DISTINCT model FROM " + p.DatabaseTable.ftdata.ToString();
                }
                else
                {
                    sql = "SELECT DISTINCT model FROM " + p.DatabaseTable.atedata.ToString() + " WHERE line = '" + line + "'";
                    if (mfgtype.ToUpper() == "FT")
                        sql = "SELECT DISTINCT model FROM " + p.DatabaseTable.ftdata.ToString()  + " WHERE line = '" + line + "'";
                }               
            }
            else
            {
                if (line == "----")
                {
                    sql = "SELECT DISTINCT model FROM " + p.DatabaseTable.atedata.ToString() + " WHERE plant = '" + plant + "'";
                    if (mfgtype.ToUpper() == "FT")
                        sql = "SELECT DISTINCT model FROM " + p.DatabaseTable.ftdata.ToString() + " WHERE plant = '" + plant + "'";
                }
                else
                {
                    sql = "SELECT DISTINCT model FROM " + p.DatabaseTable.atedata.ToString() + " WHERE plant = '" + plant + "' and line ='" + line +"'";
                    if (mfgtype.ToUpper() == "FT")
                        sql = "SELECT DISTINCT model FROM " + p.DatabaseTable.ftdata.ToString() + " WHERE plant = '" + plant + "' and line ='" + line + "'";
                }
                
            }
            loadSqlList(sql, combobox);
        }





        /// <summary>
        /// 
        /// </summary>
        /// <param name="combobox"></param>
        /// <param name="mfgtype"></param>
        /// <param name="plant"></param>
        /// <param name="line"></param>
        /// <param name="model"></param>
        private void loadUPN(ComboBox combobox, string mfgtype, string plant = "----", string line = "----",string model="----")
        {
            string sql = "";
            if (plant == "----")
            {
                if (line == "----")
                {
                    if (model == "----")
                    {
                        sql = "SELECT DISTINCT upn FROM " + p.DatabaseTable.atedata.ToString();
                        if (mfgtype.ToUpper() == "FT")
                            sql = "SELECT DISTINCT upn FROM " + p.DatabaseTable.ftdata.ToString();
                    }
                    else
                    {
                        sql = "SELECT DISTINCT upn FROM " + p.DatabaseTable.atedata.ToString() + " WHERE model = '" + model + "'";
                        if (mfgtype.ToUpper() == "FT")
                            sql = "SELECT DISTINCT upn FROM " + p.DatabaseTable.ftdata.ToString() + " WHERE model = '" + model + "'";
                    }
                    
                }
                else
                {
                    if (model == "----")
                    {
                        sql = "SELECT DISTINCT upn FROM " + p.DatabaseTable.atedata.ToString() + " WHERE line = '" + line + "'";
                        if (mfgtype.ToUpper() == "FT")
                            sql = "SELECT DISTINCT upn FROM " + p.DatabaseTable.ftdata.ToString() + " WHERE line = '" + line + "'";
                    }
                    else
                    {
                        sql = "SELECT DISTINCT upn FROM " + p.DatabaseTable.atedata.ToString() + " WHERE line = '" + line + "' and  model = '" + model + "'";
                        if (mfgtype.ToUpper() == "FT")
                            sql = "SELECT DISTINCT upn FROM " + p.DatabaseTable.ftdata.ToString() + " WHERE line = '" + line + "' and  model = '" + model + "'";
                    }
                   
                }
            }
            else
            {
                if (line == "----")
                {
                    if (model == "----")
                    {
                        sql = "SELECT DISTINCT upn FROM " + p.DatabaseTable.atedata.ToString() + " WHERE plant = '" + plant + "'";
                        if (mfgtype.ToUpper() == "FT")
                            sql = "SELECT DISTINCT upn FROM " + p.DatabaseTable.ftdata.ToString() + " WHERE plant = '" + plant + "'";
                    }
                    else
                    {
                        sql = "SELECT DISTINCT upn FROM " + p.DatabaseTable.atedata.ToString() + " WHERE plant = '" + plant + "' and model = '" + model + "'";
                        if (mfgtype.ToUpper() == "FT")
                            sql = "SELECT DISTINCT upn FROM " + p.DatabaseTable.ftdata.ToString() + " WHERE plant = '" + plant + "' and model = '" + model + "'";
                    }
                    
                }
                else
                {
                    if (model == "----")
                    {
                        sql = "SELECT DISTINCT upn FROM " + p.DatabaseTable.atedata.ToString() + " WHERE plant = '" + plant + "' and line ='" + line + "'";
                        if (mfgtype.ToUpper() == "FT")
                            sql = "SELECT DISTINCT upn FROM " + p.DatabaseTable.ftdata.ToString() + " WHERE plant = '" + plant + "' and line ='" + line + "'";
                    }
                    else
                    {
                        sql = "SELECT DISTINCT upn FROM " + p.DatabaseTable.atedata.ToString() + " WHERE plant = '" + plant + "' and line ='" + line + "' and model ='" + model + "'";
                        if (mfgtype.ToUpper() == "FT")
                            sql = "SELECT DISTINCT upn FROM " + p.DatabaseTable.ftdata.ToString() + " WHERE plant = '" + plant + "' and line ='" + line + "' and model ='" + model + "'";
                    }
                    
                }

            }
            loadSqlList(sql, combobox);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="combobox"></param>
        /// <param name="mfgtype"></param>
        /// <param name="plant"></param>
        /// <param name="line"></param>
        /// <param name="model"></param>
        /// <param name="upn"></param>
        private void loadFixuteID(ComboBox combobox, string mfgtype, string plant = "----", string line = "----", string model = "----",string upn="----")
        {
            string sql = "";
            if (plant == "----")
            {
                if (line == "----")
                {
                    if (model == "----")
                    {
                        if (upn == "----")
                        {
                            sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.atedata.ToString();
                            if (mfgtype.ToUpper() == "FT")
                                sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.ftdata.ToString();
                        }
                        else
                        {
                            sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.atedata.ToString() + " WHERE upn = '" + upn + "'";
                            if (mfgtype.ToUpper() == "FT")
                                sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.ftdata.ToString() + " WHERE upn = '" + upn + "'";
                        }
                        
                    }
                    else
                    {
                        if (upn == "----")
                        {
                            sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.atedata.ToString() + " WHERE model = '" + model + "' and upn = '" + upn + "'";
                            if (mfgtype.ToUpper() == "FT")
                                sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.ftdata.ToString() + " WHERE model = '" + model + "' and upn = '" + upn + "'";
                        }
                        
                    }

                }
                else
                {
                    if (model == "----")
                    {
                        if (upn == "----")
                        {
                            sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.atedata.ToString() + " WHERE line = '" + line + "'";
                            if (mfgtype.ToUpper() == "FT")
                                sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.ftdata.ToString() + " WHERE line = '" + line + "'";
                        }
                        else
                        {
                            sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.atedata.ToString() + " WHERE line = '" + line + "' and upn = '" + upn + "'";
                            if (mfgtype.ToUpper() == "FT")
                                sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.ftdata.ToString() + " WHERE line = '" + line + "' and upn = '" + upn + "'";

                        }
                        
                    }
                    else
                    {
                        if (upn == "----")
                        {
                            sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.atedata.ToString() + " WHERE line = '" + line + "' and  model = '" + model + "'";
                            if (mfgtype.ToUpper() == "FT")
                                sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.ftdata.ToString() + " WHERE line = '" + line + "' and  model = '" + model + "'";
                        }
                        else
                        {
                            sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.atedata.ToString() + " WHERE line = '" + line + "' and  model = '" + model + "' and upn = '" + upn + "'";
                            if (mfgtype.ToUpper() == "FT")
                                sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.ftdata.ToString() + " WHERE line = '" + line + "' and  model = '" + model + "' and upn = '" + upn + "'";
                        }
                        
                    }

                }
            }
            else
            {
                if (line == "----")
                {
                    if (model == "----")
                    {
                        if (upn == "----")
                        {
                            sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.atedata.ToString() + " WHERE plant = '" + plant + "'";
                            if (mfgtype.ToUpper() == "FT")
                                sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.ftdata.ToString() + " WHERE plant = '" + plant + "'";
                        }
                        else
                        {
                            sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.atedata.ToString() + " WHERE plant = '" + plant + "' and upn = '" + upn + "'";
                            if (mfgtype.ToUpper() == "FT")
                                sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.ftdata.ToString() + " WHERE plant = '" + plant + "' and upn = '" + upn + "'";
                        }

                    }
                    else
                    {
                        if (upn == "----")
                        {
                            sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.atedata.ToString() + " WHERE plant = '" + plant + "' and model = '" + model + "'";
                            if (mfgtype.ToUpper() == "FT")
                                sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.ftdata.ToString() + " WHERE plant = '" + plant + "' and model = '" + model + "'";
                        }
                        else
                        {
                            sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.atedata.ToString() + " WHERE plant = '" + plant + "' and model = '" + model + "' and upn = '" + upn + "'";
                            if (mfgtype.ToUpper() == "FT")
                                sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.ftdata.ToString() + " WHERE plant = '" + plant + "' and model = '" + model + "' and upn = '" + upn + "'";
                        }
                        
                    }

                }
                else
                {
                    if (model == "----")
                    {
                        if (upn == "----")
                        {
                            sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.atedata.ToString() + " WHERE plant = '" + plant + "' and line ='" + line + "'";
                            if (mfgtype.ToUpper() == "FT")
                                sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.ftdata.ToString() + " WHERE plant = '" + plant + "' and line ='" + line + "'";
                        }
                        else
                        {
                            sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.atedata.ToString() + " WHERE plant = '" + plant + "' and line ='" + line + "' and upn = '" + upn + "'";
                            if (mfgtype.ToUpper() == "FT")
                                sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.ftdata.ToString() + " WHERE plant = '" + plant + "' and line ='" + line + "' and upn = '" + upn + "'";
                        }
                        
                    
                    }
                    else
                    {
                        if (upn == "----")
                        {
                            sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.atedata.ToString() + " WHERE plant = '" + plant + "' and line ='" + line + "' and model ='" + model + "'";
                            if (mfgtype.ToUpper() == "FT")
                                sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.ftdata.ToString() + " WHERE plant = '" + plant + "' and line ='" + line + "' and model ='" + model + "'";
                        }
                        else
                        {
                            sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.atedata.ToString() + " WHERE plant = '" + plant + "' and line ='" + line + "' and model ='" + model + "' and upn = '" + upn + "'";
                            if (mfgtype.ToUpper() == "FT")
                                sql = "SELECT DISTINCT fixtureid FROM " + p.DatabaseTable.ftdata.ToString() + " WHERE plant = '" + plant + "' and line ='" + line + "' and model ='" + model + "' and upn = '" + upn + "'";
                        }
                        
                    }

                }

            }
            loadSqlList(sql, combobox);
        }

        private void comboLine_SelectedIndexChanged(object sender, EventArgs e)
        {
           // loadLine(comboLine, this.comboQueryType.Text);
            //loadPlant(comboPlant, this.comboQueryType.Text);
            loadModel(comboModel, this.comboQueryType.Text, this.comboPlant.Text, comboLine.Text);
            loadUPN(comboUPN, this.comboQueryType.Text, this.comboPlant.Text, comboLine.Text);
            loadFixuteID(comboFixtureID, this.comboQueryType.Text, this.comboPlant.Text, comboLine.Text);
        }

        private void comboModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadUPN(comboUPN, this.comboQueryType.Text, this.comboPlant.Text, comboLine.Text, comboModel.Text);
            loadFixuteID(comboFixtureID, this.comboQueryType.Text, this.comboPlant.Text, comboLine.Text, comboModel.Text);
        }
         

        private void comboUPN_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadFixuteID(comboFixtureID, this.comboQueryType.Text, this.comboPlant.Text, comboLine.Text, comboModel.Text, comboUPN.Text);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (chkUseSql.Checked)
            {
                if (string.IsNullOrEmpty(txtSql.Text.Trim()))
                {
                    txtSql.Focus();
                    return;
                }
                else
                {
                    tabMain.SelectedTab = tabUseSql;
                    dgvSqlResult.DataSource = null;
                    Thread t = new Thread(queryMysqlShowDataSet);
                    t.Name = "ReadTestLog";
                    //t.IsBackground = true;
                    t.Start(txtSql.Text.Trim());
                    
                }
            }
            else
            {

            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="connstring"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool queryMySql2DataSet(string connstring, string sql, string keyname, out DataSet ds, out string _message)
        {
            ds = new DataSet();
            _message = "";
            List<string> result = new List<string>();
            MySqlConnection conn = new MySqlConnection(connstring);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            try
            {

                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds, keyname);
                conn.Close();

            }
            catch (Exception ex)
            {
                _message = ex.Message;
                conn.Close();
                return false;

            }
            return true;

        }




        public  void queryMysqlShowDataSet(object sql)
        {
            DataSet ds = new DataSet();            
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
                this.Invoke((EventHandler)(delegate
                {
                    dgvSqlResult.DataSource = ds.Tables["Query"];
                }));
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();       

            }
   
        }

        private void btnQuicklyQuery_Click(object sender, EventArgs e)
        {

            //DateTime startdatevalue = dtpStartTime.Value;
            //DateTime enddatavalue = dtpEndTime.Value;
            //for (DateTime i = startdatevalue; i < enddatavalue; i = i.AddHours(1.0))
            //{
            //    MessageBox.Show(i.ToString("yyyy-MM-dd HH:mm:ss"));

            //}
            
            //DateTime j = startdatevalue.AddHours(1);
            //MessageBox.Show("i:" + startdatevalue.ToString("yyyy-MM-dd HH:mm:ss") + "->j:" + j.ToString("yyyy-MM-dd HH:mm:ss"));

            //if (startdatevalue < enddatavalue)
            //{
            //    MessageBox.Show(true.ToString());
            //}
            //else
            //{
            //    MessageBox.Show(false.ToString());
            //}

           // return;
            //ATE Current Day Yield Rate ->0
            //ATE Current Day Production Output ->1
            //FT Current Day Yield Rate ->2
            //FT Current Day Production Output ->3
            //ATE Yesterday Yield Rate ->4
            //ATE Yesterday Production Output ->5
            //FT Yesterday Yield Rate ->6
            //FT Yesterday Production Output ->7

            lstviewProductionOutput.Items.Clear();
            lstviewYieldRate.Items.Clear();

            switch (comboQuicklyQuery.SelectedIndex)
            {   
                case 0:
                    tabMain.SelectedTab = tabYieldRate;
                    break;
                case 1:
                    tabMain.SelectedTab = tabProduectionOutput;
                    backgroundWorker1.RunWorkerAsync();
                    break;
                case 2:
                    tabMain.SelectedTab = tabYieldRate;
                    break;
                case 3:
                    tabMain.SelectedTab = tabProduectionOutput;
                    break;
                case 4:
                    tabMain.SelectedTab = tabYieldRate;
                    break;
                case 5:
                    tabMain.SelectedTab = tabProduectionOutput;
                    break;
                case 6:
                    tabMain.SelectedTab = tabYieldRate;
                    break;
                case 7:
                    tabMain.SelectedTab = tabProduectionOutput;
                    break;
                default:
                    break;
            }

        }







        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="listview"></param>
        private void loadYieldRate(string sql, ListView listview)
        {
            listview.Items.Clear();
            listview.BeginUpdate();//数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度 

            MySqlConnection conn = new MySqlConnection(p.connString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();




            conn.Close();
            listview.EndUpdate();//结束数据处理，UI界面一次性绘制。

        }

        private void loadProductionOutput(DateTime  startdatevalue,DateTime  enddatatimevalue, ListView listview,string mfgtype)
        {
            listview.Items.Clear();
            string sql = string.Empty;
            List<string> _Line = new List<string>();
            List<string> _FixtureID = new List<string>();
            listview.BeginUpdate();//数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度 
            MySqlConnection conn = new MySqlConnection(p.connString);           
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            // Line
            if (mfgtype.ToUpper() == "ATE")
                sql = "SELECT DISTINCT line from " + p.DatabaseTable.atedata.ToString() + " WHERE testtime BETWEEN '" + startdatevalue.ToString("yyyyMMddHHmmss") + "' and '" + enddatatimevalue.ToString("yyyyMMddHHmmss") + "'";
            if (mfgtype .ToUpper () == "FT")
                sql = "SELECT DISTINCT line from " + p.DatabaseTable.ftdata.ToString() + " WHERE testtime BETWEEN '" + startdatevalue.ToString("yyyyMMddHHmmss") + "' and '" + enddatatimevalue.ToString("yyyyMMddHHmmss") + "'";
            _Line = p.queryMySql(conn, sql);

            //FixtureID
            // Line
            if (mfgtype.ToUpper() == "ATE")
                sql = "SELECT DISTINCT fixtureid from " + p.DatabaseTable.atedata.ToString() + " WHERE testtime BETWEEN '" + startdatevalue.ToString("yyyyMMddHHmmss") + "' and '" + enddatatimevalue.ToString("yyyyMMddHHmmss") + "'";
            if (mfgtype.ToUpper() == "FT")
                sql = "SELECT DISTINCT fixtureid from " + p.DatabaseTable.ftdata.ToString() + " WHERE testtime BETWEEN '" + startdatevalue.ToString("yyyyMMddHHmmss") + "' and '" + enddatatimevalue.ToString("yyyyMMddHHmmss") + "'";
            _FixtureID = p.queryMySql(conn, sql);

            ListViewItem lt = new ListViewItem();

            for ( DateTime i = startdatevalue;  i < enddatatimevalue;  i = startdatevalue.AddHours (1))
            {
                foreach (string line in _Line)
                {
                    foreach (string fixtureid in _FixtureID)
                    {
                        if (mfgtype.ToUpper() == "ATE")
                            sql = "SELECT COUNT(*)  from " + p.DatabaseTable.atedata.ToString() + " WHERE line = '" + line +"' and fixtureid = '" + fixtureid +"' and testresult = 'PASS' and testtime BETWEEN '" + i.ToString("yyyyMMddHHmmss") + "' and '" + i.AddHours (1).ToString("yyyyMMddHHmmss") + "'";
                        if (mfgtype.ToUpper() == "FT")
                             sql = "SELECT COUNT(*)  from " + p.DatabaseTable.ftdata.ToString() + " WHERE line = '" + line +"' and fixtureid = '" + fixtureid +"' and testresult = 'PASS' and testtime BETWEEN '" + i.ToString("yyyyMMddHHmmss") + "' and '" + i.AddHours (1).ToString("yyyyMMddHHmmss") + "'";

                        Int32 qty = 0;
                        // Int32  qty = p.queryMysqlCount(conn, sql);

                        lt = listview.Items.Add(mfgtype);
                        lt.SubItems.Add(line);
                        lt.SubItems.Add(fixtureid);
                        lt.SubItems.Add(i.ToString("yyyy-MM-dd HH:mm:ss") + "~" + i.AddHours(1).ToString("yyyy-MM-dd HH:mm:ss"));
                        lt.SubItems.Add(qty.ToString());
                    }
                }
            }

            conn.Close();
            listview.EndUpdate();//结束数据处理，UI界面一次性绘制。

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //loadProductionOutput(dtpStartTime.Value, dtpEndTime.Value, lstviewProductionOutput, comboType.Text);

            this.Invoke((EventHandler)(delegate
            {
                lstviewProductionOutput.Items.Clear();
                string sql = string.Empty;
                List<string> _Line = new List<string>();
                List<string> _FixtureID = new List<string>();
                lstviewProductionOutput.BeginUpdate();//数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度 
                MySqlConnection conn = new MySqlConnection(p.connString);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                // Line        
                sql = "SELECT DISTINCT line from " + p.DatabaseTable.atedata.ToString() + " WHERE testtime BETWEEN '" + dtpStartTime.Value.ToString("yyyyMMddHHmmss") + "' and '" + dtpEndTime.Value.ToString("yyyyMMddHHmmss") + "'";

                _Line = p.queryMySql(conn, sql);

                //FixtureID
                // Line

                sql = "SELECT DISTINCT fixtureid from " + p.DatabaseTable.atedata.ToString() + " WHERE testtime BETWEEN '" + dtpStartTime.Value.ToString("yyyyMMddHHmmss") + "' and '" + dtpEndTime.Value.ToString("yyyyMMddHHmmss") + "'";
                _FixtureID = p.queryMySql(conn, sql);

                ListViewItem lt = new ListViewItem();

                for (DateTime i = dtpStartTime.Value; i < dtpEndTime.Value; i = dtpStartTime.Value.AddHours(1))
                {
                    foreach (string line in _Line)
                    {
                        foreach (string fixtureid in _FixtureID)
                        {

                            sql = "SELECT COUNT(*)  from " + p.DatabaseTable.atedata.ToString() + " WHERE line = '" + line + "' and fixtureid = '" + fixtureid + "' and testresult = 'PASS' and testtime BETWEEN '" + i.ToString("yyyyMMddHHmmss") + "' and '" + i.AddHours(1).ToString("yyyyMMddHHmmss") + "'";


                            Int32 qty = 0;
                            // Int32  qty = p.queryMysqlCount(conn, sql);

                            lt = lstviewProductionOutput.Items.Add("ATE");
                            lt.SubItems.Add(line);
                            lt.SubItems.Add(fixtureid);
                            lt.SubItems.Add(i.ToString("yyyy-MM-dd HH:mm:ss") + "~" + i.AddHours(1).ToString("yyyy-MM-dd HH:mm:ss"));
                            lt.SubItems.Add(qty.ToString());
                        }
                    }
                }

                conn.Close();
                lstviewProductionOutput.EndUpdate();//结束数据处理，UI界面一次性绘制。 
            }));

          

        }
    }
}
