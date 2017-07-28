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
            }
            else
            {
                MessageBox.Show("Detect your pc is not connect to network,pls retry...", "NOT CONNECT NETWORK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                    sql = "SELECT DISTINCT model FROM " + p.DatabaseTable.atedata.ToString() + "WHERE line = '" + line + "'";
                    if (mfgtype.ToUpper() == "FT")
                        sql = "SELECT DISTINCT model FROM " + p.DatabaseTable.ftdata.ToString()  + "WHERE line = '" + line + "'";
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
                        sql = "SELECT DISTINCT upn FROM " + p.DatabaseTable.atedata.ToString() + "WHERE model = '" + model + "'";
                        if (mfgtype.ToUpper() == "FT")
                            sql = "SELECT DISTINCT upn FROM " + p.DatabaseTable.ftdata.ToString() + "WHERE model = '" + model + "'";
                    }
                    
                }
                else
                {
                    if (model == "----")
                    {
                        sql = "SELECT DISTINCT upn FROM " + p.DatabaseTable.atedata.ToString() + "WHERE line = '" + line + "'";
                        if (mfgtype.ToUpper() == "FT")
                            sql = "SELECT DISTINCT upn FROM " + p.DatabaseTable.ftdata.ToString() + "WHERE line = '" + line + "'";
                    }
                    else
                    {
                        sql = "SELECT DISTINCT upn FROM " + p.DatabaseTable.atedata.ToString() + "WHERE line = '" + line + "' and  model = '" + model + "'";
                        if (mfgtype.ToUpper() == "FT")
                            sql = "SELECT DISTINCT upn FROM " + p.DatabaseTable.ftdata.ToString() + "WHERE line = '" + line + "' and  model = '" + model + "'";
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
    }
}
