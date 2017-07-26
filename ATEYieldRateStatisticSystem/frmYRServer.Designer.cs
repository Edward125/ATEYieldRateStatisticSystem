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
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
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
            this.tabControl1.Location = new System.Drawing.Point(12, 230);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1017, 406);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1009, 379);
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
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.chkUseSql);
            this.groupBox1.Controls.Add(this.txtSql);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboModel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboPlant);
            this.groupBox1.Controls.Add(this.comboType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboLine);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1017, 162);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Query Option";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Line:";
            // 
            // comboLine
            // 
            this.comboLine.FormattingEnabled = true;
            this.comboLine.Location = new System.Drawing.Point(153, 18);
            this.comboLine.Name = "comboLine";
            this.comboLine.Size = new System.Drawing.Size(62, 22);
            this.comboLine.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Plant:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 24);
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
            this.comboType.Location = new System.Drawing.Point(44, 20);
            this.comboType.Name = "comboType";
            this.comboType.Size = new System.Drawing.Size(59, 22);
            this.comboType.TabIndex = 4;
            // 
            // comboPlant
            // 
            this.comboPlant.FormattingEnabled = true;
            this.comboPlant.Location = new System.Drawing.Point(269, 17);
            this.comboPlant.Name = "comboPlant";
            this.comboPlant.Size = new System.Drawing.Size(77, 22);
            this.comboPlant.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(358, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Model:";
            // 
            // comboModel
            // 
            this.comboModel.FormattingEnabled = true;
            this.comboModel.Location = new System.Drawing.Point(406, 17);
            this.comboModel.Name = "comboModel";
            this.comboModel.Size = new System.Drawing.Size(111, 22);
            this.comboModel.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(526, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "UPN:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(564, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(125, 22);
            this.comboBox1.TabIndex = 9;
            // 
            // txtSql
            // 
            this.txtSql.Location = new System.Drawing.Point(89, 92);
            this.txtSql.Multiline = true;
            this.txtSql.Name = "txtSql";
            this.txtSql.Size = new System.Drawing.Size(674, 56);
            this.txtSql.TabIndex = 10;
            // 
            // chkUseSql
            // 
            this.chkUseSql.AutoSize = true;
            this.chkUseSql.Location = new System.Drawing.Point(11, 113);
            this.chkUseSql.Name = "chkUseSql";
            this.chkUseSql.Size = new System.Drawing.Size(64, 18);
            this.chkUseSql.TabIndex = 11;
            this.chkUseSql.Text = "UseSql";
            this.chkUseSql.UseVisualStyleBackColor = true;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(160, 57);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 22);
            this.dtpStart.TabIndex = 12;
            // 
            // frmYRServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 650);
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
        private System.Windows.Forms.DateTimePicker dtpStart;
    }
}