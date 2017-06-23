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
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fswTestlog = new System.IO.FileSystemWatcher();
            this.fswAutoLook = new System.IO.FileSystemWatcher();
            this.bgwWebService = new System.ComponentModel.BackgroundWorker();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProjectCode = new System.Windows.Forms.TextBox();
            this.txtUPN = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMO = new System.Windows.Forms.TextBox();
            this.lstviewBarcode = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fswTestlog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fswAutoLook)).BeginInit();
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
            this.groupBox1.Location = new System.Drawing.Point(18, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 268);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Barcode Status";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstStatus);
            this.groupBox2.Location = new System.Drawing.Point(18, 418);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(702, 227);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "History Message";
            // 
            // lstStatus
            // 
            this.lstStatus.FormattingEnabled = true;
            this.lstStatus.ItemHeight = 14;
            this.lstStatus.Location = new System.Drawing.Point(6, 21);
            this.lstStatus.Name = "lstStatus";
            this.lstStatus.Size = new System.Drawing.Size(690, 200);
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
            this.groupBox3.Size = new System.Drawing.Size(702, 133);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "CurrentWebService";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "TestlogPath";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "AutoLookLogPath";
            // 
            // txtCurrentWebService
            // 
            this.txtCurrentWebService.Location = new System.Drawing.Point(125, 92);
            this.txtCurrentWebService.Name = "txtCurrentWebService";
            this.txtCurrentWebService.ReadOnly = true;
            this.txtCurrentWebService.Size = new System.Drawing.Size(490, 22);
            this.txtCurrentWebService.TabIndex = 5;
            // 
            // txtTestlogPath
            // 
            this.txtTestlogPath.Location = new System.Drawing.Point(125, 60);
            this.txtTestlogPath.Name = "txtTestlogPath";
            this.txtTestlogPath.Size = new System.Drawing.Size(490, 22);
            this.txtTestlogPath.TabIndex = 4;
            this.txtTestlogPath.TextChanged += new System.EventHandler(this.txtTestlogPath_TextChanged);
            this.txtTestlogPath.DoubleClick += new System.EventHandler(this.txtTestlogPath_DoubleClick);
            // 
            // txtAutoLookLogPath
            // 
            this.txtAutoLookLogPath.Location = new System.Drawing.Point(125, 27);
            this.txtAutoLookLogPath.Name = "txtAutoLookLogPath";
            this.txtAutoLookLogPath.Size = new System.Drawing.Size(490, 22);
            this.txtAutoLookLogPath.TabIndex = 3;
            this.txtAutoLookLogPath.TextChanged += new System.EventHandler(this.txtAutoLookLogPath_TextChanged);
            this.txtAutoLookLogPath.DoubleClick += new System.EventHandler(this.txtAutoLookLogPath_DoubleClick);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStop.Location = new System.Drawing.Point(621, 89);
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
            this.btnRun.Location = new System.Drawing.Point(621, 57);
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
            this.btnSetting.Location = new System.Drawing.Point(621, 23);
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
            this.groupBox4.Location = new System.Drawing.Point(487, 151);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(233, 268);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Model Info.";
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
            this.fswAutoLook.SynchronizingObject = this;
            // 
            // bgwWebService
            // 
            this.bgwWebService.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwWebService_DoWork);
            this.bgwWebService.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwWebService_RunWorkerCompleted);
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(86, 29);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(133, 22);
            this.txtModel.TabIndex = 1;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "ProjectCode:";
            // 
            // txtProjectCode
            // 
            this.txtProjectCode.Location = new System.Drawing.Point(86, 54);
            this.txtProjectCode.Name = "txtProjectCode";
            this.txtProjectCode.Size = new System.Drawing.Size(133, 22);
            this.txtProjectCode.TabIndex = 4;
            // 
            // txtUPN
            // 
            this.txtUPN.Location = new System.Drawing.Point(86, 80);
            this.txtUPN.Name = "txtUPN";
            this.txtUPN.Size = new System.Drawing.Size(133, 22);
            this.txtUPN.TabIndex = 5;
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 14);
            this.label7.TabIndex = 7;
            this.label7.Text = "MO:";
            // 
            // txtMO
            // 
            this.txtMO.Location = new System.Drawing.Point(86, 106);
            this.txtMO.Name = "txtMO";
            this.txtMO.Size = new System.Drawing.Size(133, 22);
            this.txtMO.TabIndex = 8;
            // 
            // lstviewBarcode
            // 
            this.lstviewBarcode.Location = new System.Drawing.Point(6, 19);
            this.lstviewBarcode.Name = "lstviewBarcode";
            this.lstviewBarcode.Size = new System.Drawing.Size(451, 240);
            this.lstviewBarcode.TabIndex = 0;
            this.lstviewBarcode.UseCompatibleStateImageBehavior = false;
            this.lstviewBarcode.View = System.Windows.Forms.View.Details;
            // 
            // frmATEClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 657);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmATEClient";
            this.Text = "frmATEClient";
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
            this.ResumeLayout(false);

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
    }
}