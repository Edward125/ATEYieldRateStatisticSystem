namespace ATEYieldRateStatisticSystem
{
    partial class frmYROverAll
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYROverAll));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLastFreshInfo = new System.Windows.Forms.Label();
            this.lblNextFreshInfo = new System.Windows.Forms.Label();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblATEQtyInfo = new System.Windows.Forms.Label();
            this.lblFTQtyInfo = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.queryConMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.条件查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.当日YRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.queryConMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblLastFreshInfo);
            this.groupBox1.Controls.Add(this.lblNextFreshInfo);
            this.groupBox1.Location = new System.Drawing.Point(128, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 50);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // lblLastFreshInfo
            // 
            this.lblLastFreshInfo.AutoSize = true;
            this.lblLastFreshInfo.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastFreshInfo.Location = new System.Drawing.Point(40, 20);
            this.lblLastFreshInfo.Name = "lblLastFreshInfo";
            this.lblLastFreshInfo.Size = new System.Drawing.Size(143, 17);
            this.lblLastFreshInfo.TabIndex = 11;
            this.lblLastFreshInfo.Text = "Last Refresh Data Time:";
            // 
            // lblNextFreshInfo
            // 
            this.lblNextFreshInfo.AutoSize = true;
            this.lblNextFreshInfo.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextFreshInfo.Location = new System.Drawing.Point(317, 20);
            this.lblNextFreshInfo.Name = "lblNextFreshInfo";
            this.lblNextFreshInfo.Size = new System.Drawing.Size(141, 17);
            this.lblNextFreshInfo.TabIndex = 12;
            this.lblNextFreshInfo.Text = "Next Refresh Time Left:";
            // 
            // skinEngine1
            // 
            this.skinEngine1.@__DrawButtonFocusRectangle = true;
            this.skinEngine1.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEngine1.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEngine1.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(856, 63);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 14;
            // 
            // lblATEQtyInfo
            // 
            this.lblATEQtyInfo.AutoSize = true;
            this.lblATEQtyInfo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblATEQtyInfo.Location = new System.Drawing.Point(61, 450);
            this.lblATEQtyInfo.Name = "lblATEQtyInfo";
            this.lblATEQtyInfo.Size = new System.Drawing.Size(49, 19);
            this.lblATEQtyInfo.TabIndex = 15;
            this.lblATEQtyInfo.Text = "label1";
            // 
            // lblFTQtyInfo
            // 
            this.lblFTQtyInfo.AutoSize = true;
            this.lblFTQtyInfo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFTQtyInfo.Location = new System.Drawing.Point(416, 451);
            this.lblFTQtyInfo.Name = "lblFTQtyInfo";
            this.lblFTQtyInfo.Size = new System.Drawing.Size(49, 19);
            this.lblFTQtyInfo.TabIndex = 16;
            this.lblFTQtyInfo.Text = "label1";
            // 
            // queryConMS
            // 
            this.queryConMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.条件查询ToolStripMenuItem,
            this.当日YRToolStripMenuItem});
            this.queryConMS.Name = "queryConMS";
            this.queryConMS.Size = new System.Drawing.Size(153, 70);
            // 
            // 条件查询ToolStripMenuItem
            // 
            this.条件查询ToolStripMenuItem.Name = "条件查询ToolStripMenuItem";
            this.条件查询ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.条件查询ToolStripMenuItem.Text = "条件查询";
            this.条件查询ToolStripMenuItem.Click += new System.EventHandler(this.条件查询ToolStripMenuItem_Click);
            // 
            // 当日YRToolStripMenuItem
            // 
            this.当日YRToolStripMenuItem.Name = "当日YRToolStripMenuItem";
            this.当日YRToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.当日YRToolStripMenuItem.Text = "当日YR";
            this.当日YRToolStripMenuItem.Click += new System.EventHandler(this.当日YRToolStripMenuItem_Click);
            // 
            // frmYROverAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 489);
            this.ContextMenuStrip = this.queryConMS;
            this.Controls.Add(this.lblFTQtyInfo);
            this.Controls.Add(this.lblATEQtyInfo);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmYROverAll";
            this.Text = "frmYROverAll";
            this.toolTip1.SetToolTip(this, "Dbclick here to view ATE & FT Y.R. by line");
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmYROverAll_FormClosing);
            this.Load += new System.EventHandler(this.frmYROverAll_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmYROverAll_Paint);
            this.DoubleClick += new System.EventHandler(this.frmYROverAll_DoubleClick);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.queryConMS.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLastFreshInfo;
        private System.Windows.Forms.Label lblNextFreshInfo;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblATEQtyInfo;
        private System.Windows.Forms.Label lblFTQtyInfo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip queryConMS;
        private System.Windows.Forms.ToolStripMenuItem 条件查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 当日YRToolStripMenuItem;

    }
}