namespace ATEYieldRateStatisticSystem
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnYRServer = new System.Windows.Forms.Button();
            this.btnATEClient = new System.Windows.Forms.Button();
            this.btnFTClient = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFTClient);
            this.groupBox1.Controls.Add(this.btnATEClient);
            this.groupBox1.Controls.Add(this.btnYRServer);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(540, 141);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "pls select the application run model";
            // 
            // btnYRServer
            // 
            this.btnYRServer.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYRServer.Location = new System.Drawing.Point(37, 48);
            this.btnYRServer.Name = "btnYRServer";
            this.btnYRServer.Size = new System.Drawing.Size(141, 65);
            this.btnYRServer.TabIndex = 0;
            this.btnYRServer.Text = "Y.R. Server";
            this.toolTip1.SetToolTip(this.btnYRServer, "查看整个良率状态，报表输出等");
            this.btnYRServer.UseVisualStyleBackColor = true;
            // 
            // btnATEClient
            // 
            this.btnATEClient.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnATEClient.Location = new System.Drawing.Point(205, 48);
            this.btnATEClient.Name = "btnATEClient";
            this.btnATEClient.Size = new System.Drawing.Size(141, 65);
            this.btnATEClient.TabIndex = 1;
            this.btnATEClient.Text = "ATE Client";
            this.toolTip1.SetToolTip(this.btnATEClient, "监控ATE测试状态，将测试数据上抛到数据库");
            this.btnATEClient.UseVisualStyleBackColor = true;
            // 
            // btnFTClient
            // 
            this.btnFTClient.Enabled = false;
            this.btnFTClient.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFTClient.Location = new System.Drawing.Point(370, 48);
            this.btnFTClient.Name = "btnFTClient";
            this.btnFTClient.Size = new System.Drawing.Size(141, 65);
            this.btnFTClient.TabIndex = 2;
            this.btnFTClient.Text = "FT Client";
            this.btnFTClient.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 177);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFTClient;
        private System.Windows.Forms.Button btnATEClient;
        private System.Windows.Forms.Button btnYRServer;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

