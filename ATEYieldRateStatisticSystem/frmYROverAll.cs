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
    public partial class frmYROverAll : Form
    {
        public frmYROverAll()
        {
            InitializeComponent();
            //skinEngine1.SkinFile = p.AppFolder + @"\MacOS.ssk";
        }

        private void frmYROverAll_Load(object sender, EventArgs e)
        {
           
        }

        private void frmYROverAll_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = e.Graphics; //创建画板,这里的画板是由Form提供的.
            //Pen p = new Pen(Color.Blue, 25);//定义了一个蓝色,宽度为的画笔
            ////g.DrawLine(p, 10, 10, 100, 100);//在画板上画直线,起始坐标为(10,10),终点坐标为(100,100)
            //// g.DrawRectangle(p, 10, 10, 100, 100);//在画板上画矩形,起始坐标为(10,10),宽为,高为
            //g.DrawEllipse(p, 10, 10, 250, 250);//在画板上画椭圆,起始坐标为(10,10),外接矩形的宽为,高为
            //g.DrawEllipse(p, 450, 100, 250, 250);//在画板上画椭圆,起始坐标为(10,10),外接矩形的宽为,高为



        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.grpATE .CreateGraphics();
            Rectangle PicRect = this.grpATE .ClientRectangle;
            Pen p = new Pen(Color.Blue, 25);//定义了一个蓝色,宽度为的画笔
            g.DrawEllipse(p, PicRect.Width  / 2, PicRect.Width  / 2, PicRect.Height  / 2, PicRect.Height  / 2);
            
            //Rectangle myRect = new Rectangle(0, 0, PicRect.Width / 3, PicRect.Height);
            //g.DrawRectangle(Pens.Red, myRect);
            //g.FillRectangle(Brushes.Red, myRect);
            //myRect = new Rectangle(PicRect.Width / 3, 0, PicRect.Width / 3, PicRect.Height);
            //g.DrawRectangle(Pens.Green, myRect);
            //g.FillRectangle(Brushes.Green, myRect);
            //myRect = new Rectangle(PicRect.Width / 3 * 2, 0, PicRect.Width / 3, PicRect.Height);
            //g.DrawRectangle(Pens.Blue, myRect);
            //g.FillRectangle(Brushes.Blue, myRect);
        }

    }
}
