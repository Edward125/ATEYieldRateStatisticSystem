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
    public partial class frmYRbyLine : Form
    {
        public frmYRbyLine()
        {
            InitializeComponent();
        }

        static int INTERNAL = 300;
        private int iRefreshTime = INTERNAL;
        string LastFresh = "Last Refresh Data Time:";
        string NextFresh = "Next Refresh Data Left(s):";



        /// <summary>
        /// 防止頁面閃爍
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void frmYRbyLine_Load(object sender, EventArgs e)
        {
            loadUI();
            loadAllYR();
            timer1.Enabled = true;
            timer1.Start();
        }


        private void loadUI()
        {
            //
           // textBox1.Focus();
            //FT as2-1
            txtFTYRAS21A.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS21B.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS21C.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS21D.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS21E.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS21F.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS21G.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS21H.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //FT as2-2
            txtFTYRAS22A.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS22B.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS22C.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS22D.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS22E.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS22F.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS22G.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS22H.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            //FT as3-1
            txtFTYRAS31A.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS31B.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS31C.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS31D.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS31E.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS31F.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS31G.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS31H.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //FT as3-2
            txtFTYRAS32A.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS32B.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS32C.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS32D.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS32E.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS32F.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS32G.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS32H.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            //FT as4-1
            txtFTYRAS41A.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS41B.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS41C.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS41D.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS41E.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS41F.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS41G.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS41H.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //FT as4-2
            txtFTYRAS42A.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS42B.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS42C.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS42D.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS42E.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS42F.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS42G.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS42H.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            //FT as5-1
            txtFTYRAS51A.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS51B.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS51C.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS51D.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS51E.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS51F.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS51G.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS51H.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //FT as5-2
            txtFTYRAS52A.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS52B.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS52C.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS52D.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS52E.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS52F.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS52G.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS52H.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            //FT as6-1
            txtFTYRAS61A.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS61B.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS61C.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS61D.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS61E.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS61F.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS61G.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS61H.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //FT as6-2
            txtFTYRAS62A.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS62B.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS62C.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS62D.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS62E.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS62F.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS62G.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS62H.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            //FT as8-1
            txtFTYRAS81A.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS81B.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS81C.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS81D.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS81E.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS81F.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS81G.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS81H.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //FT as8-2
            txtFTYRAS82A.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS82B.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS82C.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS82D.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS82E.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS82F.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS82G.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS82H.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            //FT as9-1
            txtFTYRAS91A.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS91B.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS91C.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS91D.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS91E.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS91F.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS91G.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS91H.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //FT as9-2
            txtFTYRAS92A.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS92B.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS92C.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS92D.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS92E.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS92F.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS92G.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFTYRAS92H.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            //ate as2
            txtATEYRAS2A.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtATEYRAS2B.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtATEYRAS2C.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtATEYRAS2D.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            //ate as3
            txtATEYRAS3A.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtATEYRAS3B.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtATEYRAS3C.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtATEYRAS3D.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //ate as4
            txtATEYRAS4A.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtATEYRAS4B.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtATEYRAS4C.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtATEYRAS4D.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //ate as5
            txtATEYRAS5A.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtATEYRAS5B.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtATEYRAS5C.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtATEYRAS5D.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //ate as6
            txtATEYRAS6A.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtATEYRAS6B.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtATEYRAS6C.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtATEYRAS6D.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           
            //ate as8
            txtATEYRAS8A.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtATEYRAS8B.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtATEYRAS8C.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtATEYRAS8D.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //ate as9
            txtATEYRAS9A.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtATEYRAS9B.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtATEYRAS9C.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtATEYRAS9D.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           

            
            //
            txtATEYRAS2A.Text = "NA";
            txtATEYRAS2A.ForeColor = Color.BlueViolet;
            txtATEYRAS2B.Text = "NA";
            txtATEYRAS2B.ForeColor = Color.BlueViolet;
            txtATEYRAS2C.Text = "NA";
            txtATEYRAS2C.ForeColor = Color.BlueViolet;
            txtATEYRAS2D.Text = "NA";
            txtATEYRAS2D.ForeColor = Color.BlueViolet;
            //
            txtATEYRAS3A.Text = "NA";
            txtATEYRAS3A.ForeColor = Color.BlueViolet;
            txtATEYRAS3B.Text = "NA";
            txtATEYRAS3B.ForeColor = Color.BlueViolet;
            txtATEYRAS3C.Text = "NA";
            txtATEYRAS3C.ForeColor = Color.BlueViolet;
            txtATEYRAS3D.Text = "NA";
            txtATEYRAS3D.ForeColor = Color.BlueViolet;
            //
            txtATEYRAS4A.Text = "NA";
            txtATEYRAS4A.ForeColor = Color.BlueViolet;
            txtATEYRAS4B.Text = "NA";
            txtATEYRAS4B.ForeColor = Color.BlueViolet;
            txtATEYRAS4C.Text = "NA";
            txtATEYRAS4C.ForeColor = Color.BlueViolet;
            txtATEYRAS4D.Text = "NA";
            txtATEYRAS4D.ForeColor = Color.BlueViolet;
            //
            txtATEYRAS5A.Text = "NA";
            txtATEYRAS5A.ForeColor = Color.BlueViolet;
            txtATEYRAS5B.Text = "NA";
            txtATEYRAS5B.ForeColor = Color.BlueViolet;
            txtATEYRAS5C.Text = "NA";
            txtATEYRAS5C.ForeColor = Color.BlueViolet;
            txtATEYRAS5D.Text = "NA";
            txtATEYRAS5D.ForeColor = Color.BlueViolet;
            //
            txtATEYRAS6A.Text = "NA";
            txtATEYRAS6A.ForeColor = Color.BlueViolet;
            txtATEYRAS6B.Text = "NA";
            txtATEYRAS6B.ForeColor = Color.BlueViolet;
            txtATEYRAS6C.Text = "NA";
            txtATEYRAS6C.ForeColor = Color.BlueViolet;
            txtATEYRAS6D.Text = "NA";
            txtATEYRAS6D.ForeColor = Color.BlueViolet;

            //
            txtATEYRAS8A.Text = "NA";
            txtATEYRAS8A.ForeColor = Color.BlueViolet;
            txtATEYRAS8B.Text = "NA";
            txtATEYRAS8B.ForeColor = Color.BlueViolet;
            txtATEYRAS8C.Text = "NA";
            txtATEYRAS8C.ForeColor = Color.BlueViolet;
            txtATEYRAS8D.Text = "NA";
            txtATEYRAS8D.ForeColor = Color.BlueViolet;

            //
            txtATEYRAS9A.Text = "NA";
            txtATEYRAS9A.ForeColor = Color.BlueViolet;
            txtATEYRAS9B.Text = "NA";
            txtATEYRAS9B.ForeColor = Color.BlueViolet;
            txtATEYRAS9C.Text = "NA";
            txtATEYRAS9C.ForeColor = Color.BlueViolet;
            txtATEYRAS9D.Text = "NA";
            txtATEYRAS9D.ForeColor = Color.BlueViolet;

            //
            txtFTYRAS21A.Text = "NA";
            txtFTYRAS21A.ForeColor = Color.BlueViolet;
            txtFTYRAS21B.Text = "NA";
            txtFTYRAS21B.ForeColor = Color.BlueViolet;
            txtFTYRAS21C.Text = "NA";
            txtFTYRAS21C.ForeColor = Color.BlueViolet;
            txtFTYRAS21D.Text = "NA";
            txtFTYRAS21D.ForeColor = Color.BlueViolet;
            txtFTYRAS21E.Text = "NA";
            txtFTYRAS21E.ForeColor = Color.BlueViolet;
            txtFTYRAS21F.Text = "NA";
            txtFTYRAS21F.ForeColor = Color.BlueViolet;
            txtFTYRAS21G.Text = "NA";
            txtFTYRAS21G.ForeColor = Color.BlueViolet;
            txtFTYRAS21H.Text = "NA";
            txtFTYRAS21H.ForeColor = Color.BlueViolet;
            txtFTYRAS22A.Text = "NA";
            txtFTYRAS22A.ForeColor = Color.BlueViolet;
            txtFTYRAS22B.Text = "NA";
            txtFTYRAS22B.ForeColor = Color.BlueViolet;
            txtFTYRAS22C.Text = "NA";
            txtFTYRAS22C.ForeColor = Color.BlueViolet;
            txtFTYRAS22D.Text = "NA";
            txtFTYRAS22D.ForeColor = Color.BlueViolet;
            txtFTYRAS22E.Text = "NA";
            txtFTYRAS22E.ForeColor = Color.BlueViolet;
            txtFTYRAS22F.Text = "NA";
            txtFTYRAS22F.ForeColor = Color.BlueViolet;
            txtFTYRAS22G.Text = "NA";
            txtFTYRAS22G.ForeColor = Color.BlueViolet;
            txtFTYRAS22H.Text = "NA";
            txtFTYRAS22H.ForeColor = Color.BlueViolet;

            //
            txtFTYRAS31A.Text = "NA";
            txtFTYRAS31A.ForeColor = Color.BlueViolet;
            txtFTYRAS31B.Text = "NA";
            txtFTYRAS31B.ForeColor = Color.BlueViolet;
            txtFTYRAS31C.Text = "NA";
            txtFTYRAS31C.ForeColor = Color.BlueViolet;
            txtFTYRAS31D.Text = "NA";
            txtFTYRAS31D.ForeColor = Color.BlueViolet;
            txtFTYRAS31E.Text = "NA";
            txtFTYRAS31E.ForeColor = Color.BlueViolet;
            txtFTYRAS31F.Text = "NA";
            txtFTYRAS31F.ForeColor = Color.BlueViolet;
            txtFTYRAS31G.Text = "NA";
            txtFTYRAS31G.ForeColor = Color.BlueViolet;
            txtFTYRAS31H.Text = "NA";
            txtFTYRAS31H.ForeColor = Color.BlueViolet;
            txtFTYRAS32A.Text = "NA";
            txtFTYRAS32A.ForeColor = Color.BlueViolet;
            txtFTYRAS32B.Text = "NA";
            txtFTYRAS32B.ForeColor = Color.BlueViolet;
            txtFTYRAS32C.Text = "NA";
            txtFTYRAS32C.ForeColor = Color.BlueViolet;
            txtFTYRAS32D.Text = "NA";
            txtFTYRAS32D.ForeColor = Color.BlueViolet;
            txtFTYRAS32E.Text = "NA";
            txtFTYRAS32E.ForeColor = Color.BlueViolet;
            txtFTYRAS32F.Text = "NA";
            txtFTYRAS32F.ForeColor = Color.BlueViolet;
            txtFTYRAS32G.Text = "NA";
            txtFTYRAS32G.ForeColor = Color.BlueViolet;
            txtFTYRAS32H.Text = "NA";
            txtFTYRAS32H.ForeColor = Color.BlueViolet;

            //
            txtFTYRAS41A.Text = "NA";
            txtFTYRAS41A.ForeColor = Color.BlueViolet;
            txtFTYRAS41B.Text = "NA";
            txtFTYRAS41B.ForeColor = Color.BlueViolet;
            txtFTYRAS41C.Text = "NA";
            txtFTYRAS41C.ForeColor = Color.BlueViolet;
            txtFTYRAS41D.Text = "NA";
            txtFTYRAS41D.ForeColor = Color.BlueViolet;
            txtFTYRAS41E.Text = "NA";
            txtFTYRAS41E.ForeColor = Color.BlueViolet;
            txtFTYRAS41F.Text = "NA";
            txtFTYRAS41F.ForeColor = Color.BlueViolet;
            txtFTYRAS41G.Text = "NA";
            txtFTYRAS41G.ForeColor = Color.BlueViolet;
            txtFTYRAS41H.Text = "NA";
            txtFTYRAS41H.ForeColor = Color.BlueViolet;
            txtFTYRAS42A.Text = "NA";
            txtFTYRAS42A.ForeColor = Color.BlueViolet;
            txtFTYRAS42B.Text = "NA";
            txtFTYRAS42B.ForeColor = Color.BlueViolet;
            txtFTYRAS42C.Text = "NA";
            txtFTYRAS42C.ForeColor = Color.BlueViolet;
            txtFTYRAS42D.Text = "NA";
            txtFTYRAS42D.ForeColor = Color.BlueViolet;
            txtFTYRAS42E.Text = "NA";
            txtFTYRAS42E.ForeColor = Color.BlueViolet;
            txtFTYRAS42F.Text = "NA";
            txtFTYRAS42F.ForeColor = Color.BlueViolet;
            txtFTYRAS42G.Text = "NA";
            txtFTYRAS42G.ForeColor = Color.BlueViolet;
            txtFTYRAS42H.Text = "NA";
            txtFTYRAS42H.ForeColor = Color.BlueViolet;

            //
            txtFTYRAS51A.Text = "NA";
            txtFTYRAS51A.ForeColor = Color.BlueViolet;
            txtFTYRAS51B.Text = "NA";
            txtFTYRAS51B.ForeColor = Color.BlueViolet;
            txtFTYRAS51C.Text = "NA";
            txtFTYRAS51C.ForeColor = Color.BlueViolet;
            txtFTYRAS51D.Text = "NA";
            txtFTYRAS51D.ForeColor = Color.BlueViolet;
            txtFTYRAS51E.Text = "NA";
            txtFTYRAS51E.ForeColor = Color.BlueViolet;
            txtFTYRAS51F.Text = "NA";
            txtFTYRAS51F.ForeColor = Color.BlueViolet;
            txtFTYRAS51G.Text = "NA";
            txtFTYRAS51G.ForeColor = Color.BlueViolet;
            txtFTYRAS51H.Text = "NA";
            txtFTYRAS51H.ForeColor = Color.BlueViolet;
            txtFTYRAS52A.Text = "NA";
            txtFTYRAS52A.ForeColor = Color.BlueViolet;
            txtFTYRAS52B.Text = "NA";
            txtFTYRAS52B.ForeColor = Color.BlueViolet;
            txtFTYRAS52C.Text = "NA";
            txtFTYRAS52C.ForeColor = Color.BlueViolet;
            txtFTYRAS52D.Text = "NA";
            txtFTYRAS52D.ForeColor = Color.BlueViolet;
            txtFTYRAS52E.Text = "NA";
            txtFTYRAS52E.ForeColor = Color.BlueViolet;
            txtFTYRAS52F.Text = "NA";
            txtFTYRAS52F.ForeColor = Color.BlueViolet;
            txtFTYRAS52G.Text = "NA";
            txtFTYRAS52G.ForeColor = Color.BlueViolet;
            txtFTYRAS52H.Text = "NA";
            txtFTYRAS52H.ForeColor = Color.BlueViolet;

            //
            txtFTYRAS61A.Text = "NA";
            txtFTYRAS61A.ForeColor = Color.BlueViolet;
            txtFTYRAS61B.Text = "NA";
            txtFTYRAS61B.ForeColor = Color.BlueViolet;
            txtFTYRAS61C.Text = "NA";
            txtFTYRAS61C.ForeColor = Color.BlueViolet;
            txtFTYRAS61D.Text = "NA";
            txtFTYRAS61D.ForeColor = Color.BlueViolet;
            txtFTYRAS61E.Text = "NA";
            txtFTYRAS61E.ForeColor = Color.BlueViolet;
            txtFTYRAS61F.Text = "NA";
            txtFTYRAS61F.ForeColor = Color.BlueViolet;
            txtFTYRAS61G.Text = "NA";
            txtFTYRAS61G.ForeColor = Color.BlueViolet;
            txtFTYRAS61H.Text = "NA";
            txtFTYRAS61H.ForeColor = Color.BlueViolet;
            txtFTYRAS62A.Text = "NA";
            txtFTYRAS62A.ForeColor = Color.BlueViolet;
            txtFTYRAS62B.Text = "NA";
            txtFTYRAS62B.ForeColor = Color.BlueViolet;
            txtFTYRAS62C.Text = "NA";
            txtFTYRAS62C.ForeColor = Color.BlueViolet;
            txtFTYRAS62D.Text = "NA";
            txtFTYRAS62D.ForeColor = Color.BlueViolet;
            txtFTYRAS62E.Text = "NA";
            txtFTYRAS62E.ForeColor = Color.BlueViolet;
            txtFTYRAS62F.Text = "NA";
            txtFTYRAS62F.ForeColor = Color.BlueViolet;
            txtFTYRAS62G.Text = "NA";
            txtFTYRAS62G.ForeColor = Color.BlueViolet;
            txtFTYRAS62H.Text = "NA";
            txtFTYRAS62H.ForeColor = Color.BlueViolet;

            //
            txtFTYRAS81A.Text = "NA";
            txtFTYRAS81A.ForeColor = Color.BlueViolet;
            txtFTYRAS81B.Text = "NA";
            txtFTYRAS81B.ForeColor = Color.BlueViolet;
            txtFTYRAS81C.Text = "NA";
            txtFTYRAS81C.ForeColor = Color.BlueViolet;
            txtFTYRAS81D.Text = "NA";
            txtFTYRAS81D.ForeColor = Color.BlueViolet;
            txtFTYRAS81E.Text = "NA";
            txtFTYRAS81E.ForeColor = Color.BlueViolet;
            txtFTYRAS81F.Text = "NA";
            txtFTYRAS81F.ForeColor = Color.BlueViolet;
            txtFTYRAS81G.Text = "NA";
            txtFTYRAS81G.ForeColor = Color.BlueViolet;
            txtFTYRAS81H.Text = "NA";
            txtFTYRAS81H.ForeColor = Color.BlueViolet;
            txtFTYRAS82A.Text = "NA";
            txtFTYRAS82A.ForeColor = Color.BlueViolet;
            txtFTYRAS82B.Text = "NA";
            txtFTYRAS82B.ForeColor = Color.BlueViolet;
            txtFTYRAS82C.Text = "NA";
            txtFTYRAS82C.ForeColor = Color.BlueViolet;
            txtFTYRAS82D.Text = "NA";
            txtFTYRAS82D.ForeColor = Color.BlueViolet;
            txtFTYRAS82E.Text = "NA";
            txtFTYRAS82E.ForeColor = Color.BlueViolet;
            txtFTYRAS82F.Text = "NA";
            txtFTYRAS82F.ForeColor = Color.BlueViolet;
            txtFTYRAS82G.Text = "NA";
            txtFTYRAS82G.ForeColor = Color.BlueViolet;
            txtFTYRAS82H.Text = "NA";
            txtFTYRAS82H.ForeColor = Color.BlueViolet;

            //
            txtFTYRAS91A.Text = "NA";
            txtFTYRAS91A.ForeColor = Color.BlueViolet;
            txtFTYRAS91B.Text = "NA";
            txtFTYRAS91B.ForeColor = Color.BlueViolet;
            txtFTYRAS91C.Text = "NA";
            txtFTYRAS91C.ForeColor = Color.BlueViolet;
            txtFTYRAS91D.Text = "NA";
            txtFTYRAS91D.ForeColor = Color.BlueViolet;
            txtFTYRAS91E.Text = "NA";
            txtFTYRAS91E.ForeColor = Color.BlueViolet;
            txtFTYRAS91F.Text = "NA";
            txtFTYRAS91F.ForeColor = Color.BlueViolet;
            txtFTYRAS91G.Text = "NA";
            txtFTYRAS91G.ForeColor = Color.BlueViolet;
            txtFTYRAS91H.Text = "NA";
            txtFTYRAS91H.ForeColor = Color.BlueViolet;
            txtFTYRAS92A.Text = "NA";
            txtFTYRAS92A.ForeColor = Color.BlueViolet;
            txtFTYRAS92B.Text = "NA";
            txtFTYRAS92B.ForeColor = Color.BlueViolet;
            txtFTYRAS92C.Text = "NA";
            txtFTYRAS92C.ForeColor = Color.BlueViolet;
            txtFTYRAS92D.Text = "NA";
            txtFTYRAS92D.ForeColor = Color.BlueViolet;
            txtFTYRAS92E.Text = "NA";
            txtFTYRAS92E.ForeColor = Color.BlueViolet;
            txtFTYRAS92F.Text = "NA";
            txtFTYRAS92F.ForeColor = Color.BlueViolet;
            txtFTYRAS92G.Text = "NA";
            txtFTYRAS92G.ForeColor = Color.BlueViolet;
            txtFTYRAS92H.Text = "NA";
            txtFTYRAS92H.ForeColor = Color.BlueViolet;

            //
            //
            lblLastFreshInfo.Text = LastFresh + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            lblNextFreshInfo.Text = NextFresh + iRefreshTime;

            this.Text = "ATE & FT Overall Yield Rate by Line(" + DateTime.Now.ToString("yyyy-MM-dd") + ")-ver:" + Application.ProductVersion;
        }

        private void loadAllYR()
        {
            loadATEYR("AS2");
            loadATEYR("AS3");
            loadATEYR("AS4");
            loadATEYR("AS5");
            loadATEYR("AS6");           
            loadATEYR("AS8");
            loadATEYR("AS9");
            loadFTYR("AP2");
            loadFTYR("AP3");
            loadFTYR("AP4");
            loadFTYR("AP5");
            loadFTYR("AP6");
            loadFTYR("AP8");
            loadFTYR("AP9");
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
                            queryATEYr4Display(sql, line, item, txtATEYRAS2A, txtATEYRAS2B, txtATEYRAS2C, txtATEYRAS2D);
                            break;
                        case "AS3":
                            queryATEYr4Display(sql, line, item, txtATEYRAS3A, txtATEYRAS3B, txtATEYRAS3C, txtATEYRAS3D);
                            break;
                        case "AS4":
                            queryATEYr4Display(sql, line, item, txtATEYRAS4A, txtATEYRAS4B, txtATEYRAS4C, txtATEYRAS4D);
                            break;
                        case "AS5":
                            queryATEYr4Display(sql, line, item, txtATEYRAS5A, txtATEYRAS5B, txtATEYRAS5C, txtATEYRAS5D);
                            break;
                        case "AS6":
                            queryATEYr4Display(sql, line, item, txtATEYRAS6A, txtATEYRAS6B, txtATEYRAS6C, txtATEYRAS6D);
                            break;
                        case "AS8":
                            queryATEYr4Display(sql, line, item, txtATEYRAS8A, txtATEYRAS8B, txtATEYRAS8C, txtATEYRAS8D);
                            break;
                        case "AS9":
                            queryATEYr4Display(sql, line, item, txtATEYRAS9A, txtATEYRAS9B, txtATEYRAS9C, txtATEYRAS9D);
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
        /// <param name="line">AP2,AP3,AP4,AP5,AP6,AP8,AP9</param>
        private void loadFTYR(string line)
        {
            string sql = "SELECT DISTINCT fixtureid from ftdata where line = '" + line + "' and  testtime BETWEEN '" + DateTime.Now.ToString("yyyyMMdd") + "000000" + "' and '" + DateTime.Now.ToString("yyyyMMdd") + "235959" + "'";
            List<string> fixture = new List<string>();
            fixture = p.queryMySql(p.connString, sql);

            if (fixture.Count > 0)
            {
                foreach (string item in fixture)
                {
                    sql = "select sum(case when testresult = 'PASS' then 1 else 0 end)/count(usn) as yr from " + p.DatabaseTable.ftdata.ToString() + " where line ='" + line + "' and fixtureid ='" + item + "' and  testtime BETWEEN '" + DateTime.Now.ToString("yyyyMMdd") + "000000" + "' and '" + DateTime.Now.ToString("yyyyMMdd") + "235959" + "'";
                    switch (line.ToUpper().Trim())
                    {
                        case "AP2":
                            queryFTAutoYr4Display(sql, line, item, txtFTYRAS21A, txtFTYRAS21B, txtFTYRAS21C, txtFTYRAS21D, txtFTYRAS21E, txtFTYRAS21F, txtFTYRAS21G, txtFTYRAS21H,
                                txtFTYRAS22A, txtFTYRAS22B, txtFTYRAS22C, txtFTYRAS22D, txtFTYRAS22E, txtFTYRAS22F, txtFTYRAS22G, txtFTYRAS22H);
                            break;
                        case "AP3":
                            queryFTAutoYr4Display(sql, line, item, txtFTYRAS31A, txtFTYRAS31B, txtFTYRAS31C, txtFTYRAS31D, txtFTYRAS31E, txtFTYRAS31F, txtFTYRAS31G, txtFTYRAS31H,
                                txtFTYRAS32A, txtFTYRAS32B, txtFTYRAS32C, txtFTYRAS32D, txtFTYRAS32E, txtFTYRAS32F, txtFTYRAS32G, txtFTYRAS32H);
                            break;
                        case "AP4":
                            queryFTAutoYr4Display(sql, line, item, txtFTYRAS41A, txtFTYRAS41B, txtFTYRAS41C, txtFTYRAS41D, txtFTYRAS41E, txtFTYRAS41F, txtFTYRAS41G, txtFTYRAS41H,
                                txtFTYRAS42A, txtFTYRAS42B, txtFTYRAS42C, txtFTYRAS42D, txtFTYRAS42E, txtFTYRAS42F, txtFTYRAS42G, txtFTYRAS42H);
                            break;
                        case "AP5":
                            queryFTManualYr4Display(sql, line, item, txtFTYRAS51A, txtFTYRAS51B, txtFTYRAS51C, txtFTYRAS51D, txtFTYRAS51E, txtFTYRAS51F, txtFTYRAS51G, txtFTYRAS51H,
                                txtFTYRAS52A, txtFTYRAS52B, txtFTYRAS52C, txtFTYRAS52D, txtFTYRAS52E, txtFTYRAS52F, txtFTYRAS52G, txtFTYRAS52H);
                           
                            break;
                        case "AP6":
                            queryFTAutoYr4Display(sql, line, item, txtFTYRAS61A, txtFTYRAS61B, txtFTYRAS61C, txtFTYRAS61D, txtFTYRAS61E, txtFTYRAS61F, txtFTYRAS61G, txtFTYRAS61H,
                                txtFTYRAS62A, txtFTYRAS62B, txtFTYRAS62C, txtFTYRAS62D, txtFTYRAS62E, txtFTYRAS62F, txtFTYRAS62G, txtFTYRAS62H);
                            break;
                        case "AP8":
                            queryFTAutoYr4Display(sql, line, item, txtFTYRAS81A, txtFTYRAS81B, txtFTYRAS81C, txtFTYRAS81D, txtFTYRAS81E, txtFTYRAS81F, txtFTYRAS81G, txtFTYRAS81H,
                                txtFTYRAS82A, txtFTYRAS82B, txtFTYRAS82C, txtFTYRAS82D, txtFTYRAS82E, txtFTYRAS82F, txtFTYRAS82G, txtFTYRAS82H);
                            break;
                        case "AP9":
                            queryFTAutoYr4Display(sql, line, item, txtFTYRAS91A, txtFTYRAS91B, txtFTYRAS91C, txtFTYRAS91D, txtFTYRAS91E, txtFTYRAS91F, txtFTYRAS91G, txtFTYRAS91H,
                                txtFTYRAS92A, txtFTYRAS92B, txtFTYRAS92C, txtFTYRAS92D, txtFTYRAS92E, txtFTYRAS92F, txtFTYRAS92G, txtFTYRAS92H);
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
        private void queryATEYr4Display(string sql, string line, string fixtureid, TextBox ate1LB, TextBox ate1RA, TextBox ate2LC, TextBox ate2RD)
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
                    if (fixtureid.ToUpper().Contains(line + "-ATE1") && fixtureid.ToUpper().EndsWith("-L"))
                    {
                        ate1LB.Text = yr;
                        changetextforcolor(ate1LB, o_yr);
                    }
                    if (fixtureid.ToUpper().Contains(line + "-ATE1") && fixtureid.ToUpper().EndsWith("-R"))
                    {
                        ate1RA.Text = yr;
                        changetextforcolor(ate1RA, o_yr);
                    }
                    if (fixtureid.ToUpper().Contains(line + "-ATE2") && fixtureid.ToUpper().EndsWith("-L"))
                    {
                        ate2LC.Text = yr;
                        changetextforcolor(ate2LC, o_yr);
                    }
                    if (fixtureid.ToUpper().Contains(line + "-ATE2") && fixtureid.ToUpper().EndsWith("-R"))
                    {
                        ate2RD.Text = yr;
                        changetextforcolor(ate2RD, o_yr);
                    }

                }
            }
            conn.Close();
        }




       /// <summary>
       /// 
       /// </summary>
       /// <param name="sql"></param>
       /// <param name="line"></param>
       /// <param name="fixtureid"></param>
       /// <param name="FT1A"></param>
       /// <param name="FT1B"></param>
       /// <param name="FT1C"></param>
       /// <param name="FT1D"></param>
       /// <param name="FT1E"></param>
       /// <param name="FT1F"></param>
       /// <param name="FT1G"></param>
       /// <param name="FT1H"></param>
       /// <param name="FT2A"></param>
       /// <param name="FT2B"></param>
       /// <param name="FT2C"></param>
       /// <param name="FT2D"></param>
       /// <param name="FT2E"></param>
       /// <param name="FT2F"></param>
       /// <param name="FT2G"></param>
       /// <param name="FT2H"></param>
        private void queryFTAutoYr4Display(string sql, string line, string fixtureid, TextBox FT1A,TextBox FT1B,TextBox FT1C,TextBox FT1D,
            TextBox FT1E,TextBox FT1F,TextBox FT1G,TextBox FT1H,TextBox FT2A,TextBox FT2B,TextBox FT2C,TextBox FT2D,TextBox FT2E,
            TextBox FT2F,TextBox FT2G,TextBox FT2H)
            
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
                     double o_yr  = 0.0;
                    try
                    {
                        o_yr = Convert.ToDouble(re["yr"]);
                    }
                    catch (Exception)
                    {

                        o_yr = 0.0;
                    }
                 
                    string yr = string.Format("{0:P}", o_yr );
                    if (fixtureid.ToUpper().Contains(line + "-1-A") )
                    {                      
                        FT1A.Text = yr;
                        changetextforcolor(FT1A, o_yr);
                    }
                    if (fixtureid.ToUpper().Contains(line + "-1-B"))
                    {
                        FT1B.Text = yr;
                        changetextforcolor(FT1B, o_yr);
                    }

                    if (fixtureid.ToUpper().Contains(line + "-1-C"))
                    {
                        FT1C.Text = yr;
                        changetextforcolor(FT1C, o_yr);
                    }

                    if (fixtureid.ToUpper().Contains(line + "-1-D"))
                    {
                        FT1D.Text = yr;
                        changetextforcolor(FT1D, o_yr);
                    }

                    if (fixtureid.ToUpper().Contains(line + "-1-E"))
                    {
                        FT1E.Text = yr;
                        changetextforcolor(FT1E, o_yr);
                    }

                    if (fixtureid.ToUpper().Contains(line + "-1-F"))
                    {
                        FT1F.Text = yr;
                        changetextforcolor(FT1F, o_yr);
                    }

                    if (fixtureid.ToUpper().Contains(line + "-1-G"))
                    {
                        FT1G.Text = yr;
                        changetextforcolor(FT1G, o_yr);
                    }

                    if (fixtureid.ToUpper().Contains(line + "-1-H"))
                    {
                        FT1H.Text = yr;
                        changetextforcolor(FT1H, o_yr);
                    }

                    if (fixtureid.ToUpper().Contains(line + "-2-A"))
                    {
                        FT2A.Text = yr;
                        changetextforcolor(FT2A, o_yr);
                    }
                    if (fixtureid.ToUpper().Contains(line + "-2-B"))
                    {
                        FT2B.Text = yr;
                        changetextforcolor(FT2B, o_yr);
                    }

                    if (fixtureid.ToUpper().Contains(line + "-2-C"))
                    {
                        FT2C.Text = yr;
                        changetextforcolor(FT2C, o_yr);
                    }

                    if (fixtureid.ToUpper().Contains(line + "-2-D"))
                    {
                        FT2D.Text = yr;
                        changetextforcolor(FT2D, o_yr);
                    }

                    if (fixtureid.ToUpper().Contains(line + "-2-E"))
                    {
                        FT2E.Text = yr;
                        changetextforcolor(FT2E, o_yr);
                    }

                    if (fixtureid.ToUpper().Contains(line + "-2-F"))
                    {
                        FT2F.Text = yr;
                        changetextforcolor(FT2F, o_yr);
                    }

                    if (fixtureid.ToUpper().Contains(line + "-2-G"))
                    {
                        FT2G.Text = yr;
                        changetextforcolor(FT2G, o_yr);
                    }

                    if (fixtureid.ToUpper().Contains(line + "-2-H"))
                    {
                        FT2H.Text = yr;
                        changetextforcolor(FT2H, o_yr);
                    }

                }
            }
            conn.Close();
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="line"></param>
        /// <param name="fixtureid"></param>
        /// <param name="FT1"></param>
        /// <param name="FT2"></param>
        /// <param name="FT3"></param>
        /// <param name="FT4"></param>
        /// <param name="FT4"></param>
        /// <param name="FT5"></param>
        /// <param name="FT6"></param>
        /// <param name="FT7"></param>
        /// <param name="FT8"></param>
        /// <param name="FT9"></param>
        /// <param name="FT10"></param>
        /// <param name="FT11"></param>
        /// <param name="FT12"></param>
        /// <param name="FT13"></param>
        /// <param name="FT14"></param>
        private void queryFTManualYr4Display(string sql, string line, string fixtureid, TextBox FT1,TextBox FT2,TextBox FT3,TextBox FT4,TextBox FT5,
            TextBox FT6,TextBox FT7,TextBox FT8,TextBox FT9,TextBox FT10,TextBox FT11,TextBox FT12,TextBox FT13,TextBox FT14,TextBox FT15,TextBox FT16)
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
                    if (fixtureid.ToUpper().Contains(line + "-S1"))
                    {
                        FT1.Text = yr;
                        changetextforcolor(FT1 , o_yr);
                    }

                    if (fixtureid.ToUpper().Contains(line + "-S2"))
                    {
                        FT2.Text = yr;
                        changetextforcolor(FT2, o_yr);
                    }

                    if (fixtureid.ToUpper().Contains(line + "-S3"))
                    {
                        FT3.Text = yr;
                        changetextforcolor(FT3, o_yr);
                    }

                    if (fixtureid.ToUpper().Contains(line + "-S4"))
                    {
                        FT4.Text = yr;
                        changetextforcolor(FT4, o_yr);
                    }

                    if (fixtureid.ToUpper().Contains(line + "-S5"))
                    {
                        FT5.Text = yr;
                        changetextforcolor(FT5, o_yr);
                    }

                    if (fixtureid.ToUpper().Contains(line + "-S6"))
                    {
                        FT6.Text = yr;
                        changetextforcolor(FT6, o_yr);
                    }

                    if (fixtureid.ToUpper().Contains(line + "-S7"))
                    {
                        FT7.Text = yr;
                        changetextforcolor(FT7, o_yr);
                    }

                    if (fixtureid.ToUpper().Contains(line + "-S8"))
                    {
                        FT8.Text = yr;
                        changetextforcolor(FT8, o_yr);
                    }

                    if (fixtureid.ToUpper().Contains(line + "-S9"))
                    {
                        FT9.Text = yr;
                        changetextforcolor(FT9, o_yr);
                    }

                    if (fixtureid.ToUpper().Contains(line + "-S10"))
                    {
                        FT10.Text = yr;
                        changetextforcolor(FT10, o_yr);
                    }

                    if (fixtureid.ToUpper().Contains(line + "-S11"))
                    {
                        FT11.Text = yr;
                        changetextforcolor(FT11, o_yr);
                    }

                    if (fixtureid.ToUpper().Contains(line + "-S12"))
                    {
                        FT12.Text = yr;
                        changetextforcolor(FT12, o_yr);
                    }
                    if (fixtureid.ToUpper().Contains(line + "-S13"))
                    {
                        FT13.Text = yr;
                        changetextforcolor(FT13, o_yr);
                    }

                    if (fixtureid.ToUpper().Contains(line + "-S14"))
                    {
                        FT14.Text = yr;
                        changetextforcolor(FT14, o_yr);
                    }

                    if (fixtureid.ToUpper().Contains(line + "-S15"))
                    {
                        FT15.Text = yr;
                        changetextforcolor(FT15, o_yr);
                    }

                    if (fixtureid.ToUpper().Contains(line + "-S16"))
                    {
                        FT16.Text = yr;
                        changetextforcolor(FT16, o_yr);
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
