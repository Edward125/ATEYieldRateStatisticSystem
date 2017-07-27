namespace ATEYieldRateStatisticSystem
{
    partial class frmYRServer
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tssmFile = new System.Windows.Forms.ToolStripMenuItem();
            this.exportATEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportFTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queryATEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queryFTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboLine = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboType = new System.Windows.Forms.ComboBox();
            this.comboPlant = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboModel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtSql = new System.Windows.Forms.TextBox();
            this.chkUseSql = new System.Windows.Forms.CheckBox();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.grbQueryOption = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.grbQuicklyQuery = new System.Windows.Forms.GroupBox();
            this.comboQuicklyQuery = new System.Windows.Forms.ComboBox();
            this.btnQuicklyQuery = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.comboQueryType = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grbQueryOption.SuspendLayout();
            this.grbQuicklyQuery.SuspendLayout();
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssmFile,
            this.queryToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1041, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tssmFile
            // 
            this.tssmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportATEToolStripMenuItem,
            this.exportFTToolStripMenuItem,
            this.reStartToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.tssmFile.Name = "tssmFile";
            this.tssmFile.Size = new System.Drawing.Size(39, 21);
            this.tssmFile.Text = "File";
            // 
            // exportATEToolStripMenuItem
            // 
            this.exportATEToolStripMenuItem.Name = "exportATEToolStripMenuItem";
            this.exportATEToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportATEToolStripMenuItem.Text = "Export ATE";
            // 
            // exportFTToolStripMenuItem
            // 
            this.exportFTToolStripMenuItem.Name = "exportFTToolStripMenuItem";
            this.exportFTToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportFTToolStripMenuItem.Text = "Export FT";
            // 
            // reStartToolStripMenuItem
            // 
            this.reStartToolStripMenuItem.Name = "reStartToolStripMenuItem";
            this.reStartToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.reStartToolStripMenuItem.Text = "ReStart";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // queryToolStripMenuItem
            // 
            this.queryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.queryATEToolStripMenuItem,
            this.queryFTToolStripMenuItem});
            this.queryToolStripMenuItem.Name = "queryToolStripMenuItem";
            this.queryToolStripMenuItem.Size = new System.Drawing.Size(55, 21);
            this.queryToolStripMenuItem.Text = "Query";
            // 
            // queryATEToolStripMenuItem
            // 
            this.queryATEToolStripMenuItem.Name = "queryATEToolStripMenuItem";
            this.queryATEToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.queryATEToolStripMenuItem.Text = "Query ATE";
            // 
            // queryFTToolStripMenuItem
            // 
            this.queryFTToolStripMenuItem.Name = "queryFTToolStripMenuItem";
            this.queryFTToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.queryFTToolStripMenuItem.Text = "Query FT";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(256, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(773, 483);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(765, 456);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(834, 469);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.grbQuicklyQuery);
            this.groupBox1.Controls.Add(this.grbQueryOption);
            this.groupBox1.Controls.Add(this.chkUseSql);
            this.groupBox1.Controls.Add(this.txtSql);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 489);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Query Setting";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Line:";
            // 
            // comboLine
            // 
            this.comboLine.FormattingEnabled = true;
            this.comboLine.Location = new System.Drawing.Point(151, 41);
            this.comboLine.Name = "comboLine";
            this.comboLine.Size = new System.Drawing.Size(62, 22);
            this.comboLine.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Plant:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Type:";
            // 
            // comboType
            // 
            this.comboType.FormattingEnabled = true;
            this.comboType.Items.AddRange(new object[] {
            "ATE",
            "FT"});
            this.comboType.Location = new System.Drawing.Point(47, 41);
            this.comboType.Name = "comboType";
            this.comboType.Size = new System.Drawing.Size(59, 22);
            this.comboType.TabIndex = 4;
            // 
            // comboPlant
            // 
            this.comboPlant.FormattingEnabled = true;
            this.comboPlant.Location = new System.Drawing.Point(55, 69);
            this.comboPlant.Name = "comboPlant";
            this.comboPlant.Size = new System.Drawing.Size(158, 22);
            this.comboPlant.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Model:";
            // 
            // comboModel
            // 
            this.comboModel.FormattingEnabled = true;
            this.comboModel.Location = new System.Drawing.Point(55, 97);
            this.comboModel.Name = "comboModel";
            this.comboModel.Size = new System.Drawing.Size(158, 22);
            this.comboModel.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "UPN:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(55, 128);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(159, 22);
            this.comboBox1.TabIndex = 9;
            // 
            // txtSql
            // 
            this.txtSql.Enabled = false;
            this.txtSql.Location = new System.Drawing.Point(6, 265);
            this.txtSql.Multiline = true;
            this.txtSql.Name = "txtSql";
            this.txtSql.Size = new System.Drawing.Size(226, 88);
            this.txtSql.TabIndex = 10;
            // 
            // chkUseSql
            // 
            this.chkUseSql.AutoSize = true;
            this.chkUseSql.Location = new System.Drawing.Point(9, 241);
            this.chkUseSql.Name = "chkUseSql";
            this.chkUseSql.Size = new System.Drawing.Size(64, 18);
            this.chkUseSql.TabIndex = 11;
            this.chkUseSql.Text = "UseSql";
            this.chkUseSql.UseVisualStyleBackColor = true;
            this.chkUseSql.CheckedChanged += new System.EventHandler(this.chkUseSql_CheckedChanged);
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(73, 156);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(140, 22);
            this.dtpStartTime.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 14);
            this.label6.TabIndex = 13;
            this.label6.Text = "StartTime:";
            // 
            // grbQueryOption
            // 
            this.grbQueryOption.Controls.Add(this.comboQueryType);
            this.grbQueryOption.Controls.Add(this.label8);
            this.grbQueryOption.Controls.Add(this.dtpEndTime);
            this.grbQueryOption.Controls.Add(this.label7);
            this.grbQueryOption.Controls.Add(this.comboType);
            this.grbQueryOption.Controls.Add(this.label6);
            this.grbQueryOption.Controls.Add(this.comboLine);
            this.grbQueryOption.Controls.Add(this.label1);
            this.grbQueryOption.Controls.Add(this.dtpStartTime);
            this.grbQueryOption.Controls.Add(this.label2);
            this.grbQueryOption.Controls.Add(this.label3);
            this.grbQueryOption.Controls.Add(this.comboPlant);
            this.grbQueryOption.Controls.Add(this.comboBox1);
            this.grbQueryOption.Controls.Add(this.label4);
            this.grbQueryOption.Controls.Add(this.label5);
            this.grbQueryOption.Controls.Add(this.comboModel);
            this.grbQueryOption.Location = new System.Drawing.Point(6, 21);
            this.grbQueryOption.Name = "grbQueryOption";
            this.grbQueryOption.Size = new System.Drawing.Size(226, 214);
            this.grbQueryOption.TabIndex = 14;
            this.grbQueryOption.TabStop = false;
            this.grbQueryOption.Text = "Query Option";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 14);
            this.label7.TabIndex = 14;
            this.label7.Text = "EndTime:";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(72, 185);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(140, 22);
            this.dtpEndTime.TabIndex = 15;
            // 
            // grbQuicklyQuery
            // 
            this.grbQuicklyQuery.Controls.Add(this.btnQuicklyQuery);
            this.grbQuicklyQuery.Controls.Add(this.comboQuicklyQuery);
            this.grbQuicklyQuery.Location = new System.Drawing.Point(9, 399);
            this.grbQuicklyQuery.Name = "grbQuicklyQuery";
            this.grbQuicklyQuery.Size = new System.Drawing.Size(226, 83);
            this.grbQuicklyQuery.TabIndex = 15;
            this.grbQuicklyQuery.TabStop = false;
            this.grbQuicklyQuery.Text = "Quickly Query";
            // 
            // comboQuicklyQuery
            // 
            this.comboQuicklyQuery.FormattingEnabled = true;
            this.comboQuicklyQuery.Location = new System.Drawing.Point(13, 17);
            this.comboQuicklyQuery.Name = "comboQuicklyQuery";
            this.comboQuicklyQuery.Size = new System.Drawing.Size(202, 22);
            this.comboQuicklyQuery.TabIndex = 0;
            // 
            // btnQuicklyQuery
            // 
            this.btnQuicklyQuery.Location = new System.Drawing.Point(9, 43);
            this.btnQuicklyQuery.Name = "btnQuicklyQuery";
            this.btnQuicklyQuery.Size = new System.Drawing.Size(204, 36);
            this.btnQuicklyQuery.TabIndex = 1;
            this.btnQuicklyQuery.Text = "Quickly Query";
            this.btnQuicklyQuery.UseVisualStyleBackColor = true;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(9, 359);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(223, 36);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 14);
            this.label8.TabIndex = 16;
            this.label8.Text = "Query Type:";
            // 
            // comboQueryType
            // 
            this.comboQueryType.FormattingEnabled = true;
            this.comboQueryType.Items.AddRange(new object[] {
            "Yield Rate",
            "Production Output"});
            this.comboQueryType.Location = new System.Drawing.Point(86, 15);
            this.comboQueryType.Name = "comboQueryType";
            this.comboQueryType.Size = new System.Drawing.Size(126, 22);
            this.comboQueryType.TabIndex = 17;
            // 
            // frmYRServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 531);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmYRServer";
            this.Text = "frmYRServer";
            this.Load += new System.EventHandler(this.frmYRServer_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbQueryOption.ResumeLayout(false);
            this.grbQueryOption.PerformLayout();
            this.grbQuicklyQuery.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tssmFile;
        private System.Windows.Forms.ToolStripMenuItem exportATEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportFTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem queryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem queryATEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem queryFTToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboPlant;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboModel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox chkUseSql;
        private System.Windows.Forms.TextBox txtSql;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grbQueryOption;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.GroupBox grbQuicklyQuery;
        private System.Windows.Forms.ComboBox comboQuicklyQuery;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnQuicklyQuery;
        private System.Windows.Forms.ComboBox comboQueryType;
        private System.Windows.Forms.Label label8;
    }
}