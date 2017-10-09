namespace ATEYieldRateStatisticSystem
{
    partial class frmATEClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmATEClient));
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstviewBarcode = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstStatus = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCurrentWebService = new System.Windows.Forms.TextBox();
            this.txtTestlogPath = new System.Windows.Forms.TextBox();
            this.txtAutoLookLogPath = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtMO = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUPN = new System.Windows.Forms.TextBox();
            this.txtProjectCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fswTestlog = new System.IO.FileSystemWatcher();
            this.fswAutoLook = new System.IO.FileSystemWatcher();
            this.bgwWebService = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslStartTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslModel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslUPN = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslNetDB = new System.Windows.Forms.ToolStripStatusLabel();
            this.grbShiftYieldRate = new System.Windows.Forms.GroupBox();
            this.lblShiftYR = new System.Windows.Forms.Label();
            this.lblShiftFPY = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.timerDetectNet = new System.Windows.Forms.Timer(this.components);
            this.btnChangeShift = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fswTestlog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fswAutoLook)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.grbShiftYieldRate.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.lstviewBarcode);
            this.groupBox1.Location = new System.Drawing.Point(18, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(669, 221);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Barcode Status";
            // 
            // lstviewBarcode
            // 
            this.lstviewBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstviewBarcode.Location = new System.Drawing.Point(6, 19);
            this.lstviewBarcode.Name = "lstviewBarcode";
            this.lstviewBarcode.Size = new System.Drawing.Size(657, 196);
            this.lstviewBarcode.TabIndex = 0;
            this.lstviewBarcode.UseCompatibleStateImageBehavior = false;
            this.lstviewBarcode.View = System.Windows.Forms.View.Details;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstStatus);
            this.groupBox2.Location = new System.Drawing.Point(18, 361);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(669, 229);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "History Message";
            // 
            // lstStatus
            // 
            this.lstStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstStatus.FormattingEnabled = true;
            this.lstStatus.ItemHeight = 14;
            this.lstStatus.Location = new System.Drawing.Point(6, 21);
            this.lstStatus.Name = "lstStatus";
            this.lstStatus.ScrollAlwaysVisible = true;
            this.lstStatus.Size = new System.Drawing.Size(657, 200);
            this.lstStatus.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtCurrentWebService);
            this.groupBox3.Controls.Add(this.txtTestlogPath);
            this.groupBox3.Controls.Add(this.txtAutoLookLogPath);
            this.groupBox3.Controls.Add(this.btnStop);
            this.groupBox3.Controls.Add(this.btnRun);
            this.groupBox3.Controls.Add(this.btnSetting);
            this.groupBox3.Location = new System.Drawing.Point(18, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(534, 117);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "CurrentWebService";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "TestlogPath";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "AutoLookLogPath";
            // 
            // txtCurrentWebService
            // 
            this.txtCurrentWebService.Location = new System.Drawing.Point(125, 81);
            this.txtCurrentWebService.Name = "txtCurrentWebService";
            this.txtCurrentWebService.ReadOnly = true;
            this.txtCurrentWebService.Size = new System.Drawing.Size(319, 22);
            this.txtCurrentWebService.TabIndex = 5;
            // 
            // txtTestlogPath
            // 
            this.txtTestlogPath.Location = new System.Drawing.Point(125, 52);
            this.txtTestlogPath.Name = "txtTestlogPath";
            this.txtTestlogPath.Size = new System.Drawing.Size(319, 22);
            this.txtTestlogPath.TabIndex = 4;
            this.txtTestlogPath.TextChanged += new System.EventHandler(this.txtTestlogPath_TextChanged);
            this.txtTestlogPath.DoubleClick += new System.EventHandler(this.txtTestlogPath_DoubleClick);
            // 
            // txtAutoLookLogPath
            // 
            this.txtAutoLookLogPath.Location = new System.Drawing.Point(125, 22);
            this.txtAutoLookLogPath.Name = "txtAutoLookLogPath";
            this.txtAutoLookLogPath.Size = new System.Drawing.Size(319, 22);
            this.txtAutoLookLogPath.TabIndex = 3;
            this.txtAutoLookLogPath.TextChanged += new System.EventHandler(this.txtAutoLookLogPath_TextChanged);
            this.txtAutoLookLogPath.DoubleClick += new System.EventHandler(this.txtAutoLookLogPath_DoubleClick);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStop.Location = new System.Drawing.Point(451, 78);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 31);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRun
            // 
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRun.Location = new System.Drawing.Point(451, 46);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 27);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSetting.Location = new System.Drawing.Point(451, 12);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(75, 28);
            this.btnSetting.TabIndex = 0;
            this.btnSetting.Text = "Setting...";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtMO);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtUPN);
            this.groupBox4.Controls.Add(this.txtProjectCode);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtModel);
            this.groupBox4.Controls.Add(this.pictureBox1);
            this.groupBox4.Location = new System.Drawing.Point(928, 164);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(233, 268);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Model Info.";
            // 
            // txtMO
            // 
            this.txtMO.Location = new System.Drawing.Point(86, 106);
            this.txtMO.Name = "txtMO";
            this.txtMO.Size = new System.Drawing.Size(133, 22);
            this.txtMO.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 14);
            this.label7.TabIndex = 7;
            this.label7.Text = "MO:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 14);
            this.label6.TabIndex = 6;
            this.label6.Text = "UPN:";
            // 
            // txtUPN
            // 
            this.txtUPN.Location = new System.Drawing.Point(86, 80);
            this.txtUPN.Name = "txtUPN";
            this.txtUPN.Size = new System.Drawing.Size(133, 22);
            this.txtUPN.TabIndex = 5;
            // 
            // txtProjectCode
            // 
            this.txtProjectCode.Location = new System.Drawing.Point(86, 54);
            this.txtProjectCode.Name = "txtProjectCode";
            this.txtProjectCode.Size = new System.Drawing.Size(133, 22);
            this.txtProjectCode.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "ProjectCode:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "Model:";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(86, 29);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(133, 22);
            this.txtModel.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(221, 240);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // fswTestlog
            // 
            this.fswTestlog.EnableRaisingEvents = true;
            this.fswTestlog.SynchronizingObject = this;
            this.fswTestlog.Changed += new System.IO.FileSystemEventHandler(this.fswTestlog_Changed);
            // 
            // fswAutoLook
            // 
            this.fswAutoLook.EnableRaisingEvents = true;
            this.fswAutoLook.NotifyFilter = System.IO.NotifyFilters.LastWrite;
            this.fswAutoLook.SynchronizingObject = this;
            this.fswAutoLook.Changed += new System.IO.FileSystemEventHandler(this.fswAutoLook_Changed);
            // 
            // bgwWebService
            // 
            this.bgwWebService.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwWebService_DoWork);
            this.bgwWebService.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwWebService_RunWorkerCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStartTime,
            this.tsslModel,
            this.tsslUPN,
            this.tsslNetDB});
            this.statusStrip1.Location = new System.Drawing.Point(0, 594);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(699, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslStartTime
            // 
            this.tsslStartTime.Name = "tsslStartTime";
            this.tsslStartTime.Size = new System.Drawing.Size(66, 17);
            this.tsslStartTime.Text = "StartTime:";
            // 
            // tsslModel
            // 
            this.tsslModel.Name = "tsslModel";
            this.tsslModel.Size = new System.Drawing.Size(49, 17);
            this.tsslModel.Text = "Model:";
            // 
            // tsslUPN
            // 
            this.tsslUPN.Name = "tsslUPN";
            this.tsslUPN.Size = new System.Drawing.Size(37, 17);
            this.tsslUPN.Text = "UPN:";
            // 
            // tsslNetDB
            // 
            this.tsslNetDB.Name = "tsslNetDB";
            this.tsslNetDB.Size = new System.Drawing.Size(49, 17);
            this.tsslNetDB.Text = "NetDB:";
            // 
            // grbShiftYieldRate
            // 
            this.grbShiftYieldRate.Controls.Add(this.btnChangeShift);
            this.grbShiftYieldRate.Controls.Add(this.lblShiftYR);
            this.grbShiftYieldRate.Controls.Add(this.lblShiftFPY);
            this.grbShiftYieldRate.Controls.Add(this.label11);
            this.grbShiftYieldRate.Controls.Add(this.label10);
            this.grbShiftYieldRate.Location = new System.Drawing.Point(558, 11);
            this.grbShiftYieldRate.Name = "grbShiftYieldRate";
            this.grbShiftYieldRate.Size = new System.Drawing.Size(129, 117);
            this.grbShiftYieldRate.TabIndex = 4;
            this.grbShiftYieldRate.TabStop = false;
            this.grbShiftYieldRate.Text = "YiedRate";
            // 
            // lblShiftYR
            // 
            this.lblShiftYR.AutoSize = true;
            this.lblShiftYR.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShiftYR.ForeColor = System.Drawing.Color.Red;
            this.lblShiftYR.Location = new System.Drawing.Point(60, 51);
            this.lblShiftYR.Name = "lblShiftYR";
            this.lblShiftYR.Size = new System.Drawing.Size(49, 19);
            this.lblShiftYR.TabIndex = 7;
            this.lblShiftYR.Text = "0.00%";
            // 
            // lblShiftFPY
            // 
            this.lblShiftFPY.AutoSize = true;
            this.lblShiftFPY.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShiftFPY.ForeColor = System.Drawing.Color.Red;
            this.lblShiftFPY.Location = new System.Drawing.Point(60, 23);
            this.lblShiftFPY.Name = "lblShiftFPY";
            this.lblShiftFPY.Size = new System.Drawing.Size(49, 19);
            this.lblShiftFPY.TabIndex = 6;
            this.lblShiftFPY.Text = "0.00%";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 14);
            this.label11.TabIndex = 3;
            this.label11.Text = "Shift YR:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 14);
            this.label10.TabIndex = 2;
            this.label10.Text = "Shift FPY:";
            // 
            // timerDetectNet
            // 
            this.timerDetectNet.Interval = 2000;
            this.timerDetectNet.Tick += new System.EventHandler(this.timerDetectNet_Tick);
            // 
            // btnChangeShift
            // 
            this.btnChangeShift.Location = new System.Drawing.Point(9, 77);
            this.btnChangeShift.Name = "btnChangeShift";
            this.btnChangeShift.Size = new System.Drawing.Size(100, 32);
            this.btnChangeShift.TabIndex = 8;
            this.btnChangeShift.Text = "ChangeShift";
            this.btnChangeShift.UseVisualStyleBackColor = true;
            // 
            // frmATEClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 616);
            this.Controls.Add(this.grbShiftYieldRate);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmATEClient";
            this.Text = "S";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmATEClient_FormClosing);
            this.Load += new System.EventHandler(this.frmATEClient_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fswTestlog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fswAutoLook)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grbShiftYieldRate.ResumeLayout(false);
            this.grbShiftYieldRate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCurrentWebService;
        private System.Windows.Forms.TextBox txtTestlogPath;
        private System.Windows.Forms.TextBox txtAutoLookLogPath;
        private System.Windows.Forms.ListBox lstStatus;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.IO.FileSystemWatcher fswTestlog;
        private System.IO.FileSystemWatcher fswAutoLook;
        private System.ComponentModel.BackgroundWorker bgwWebService;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtUPN;
        private System.Windows.Forms.TextBox txtProjectCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.ListView lstviewBarcode;
        private System.Windows.Forms.TextBox txtMO;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslModel;
        private System.Windows.Forms.ToolStripStatusLabel tsslUPN;
        private System.Windows.Forms.ToolStripStatusLabel tsslStartTime;
        private System.Windows.Forms.GroupBox grbShiftYieldRate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblShiftYR;
        private System.Windows.Forms.Label lblShiftFPY;
        private System.Windows.Forms.ToolStripStatusLabel tsslNetDB;
        private System.Windows.Forms.Timer timerDetectNet;
        private System.Windows.Forms.Button btnChangeShift;
    }
}