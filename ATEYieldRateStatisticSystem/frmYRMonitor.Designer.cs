namespace ATEYieldRateStatisticSystem
{
    partial class frmYRMonitor
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYRMonitor));
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.chartATE = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartFT = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblLastFreshInfo = new System.Windows.Forms.Label();
            this.lblNextFreshInfo = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.grpATE = new System.Windows.Forms.GroupBox();
            this.txtATEQtyInfo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpFT = new System.Windows.Forms.GroupBox();
            this.txtFTQtyInfo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chartATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartFT)).BeginInit();
            this.grpATE.SuspendLayout();
            this.grpFT.SuspendLayout();
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
            // chartATE
            // 
            chartArea1.Name = "ChartArea1";
            this.chartATE.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chartATE.Legends.Add(legend1);
            this.chartATE.Location = new System.Drawing.Point(8, 22);
            this.chartATE.Name = "chartATE";
            this.chartATE.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.IsValueShownAsLabel = true;
            series1.IsVisibleInLegend = false;
            series1.Label = "#VALX:#VAL{P}";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartATE.Series.Add(series1);
            this.chartATE.Size = new System.Drawing.Size(365, 350);
            this.chartATE.TabIndex = 0;
            this.chartATE.Text = "chart1";
            this.toolTip1.SetToolTip(this.chartATE, "Double Click Here to View Y.R. by line");
            this.chartATE.DoubleClick += new System.EventHandler(this.chartATE_DoubleClick);
            // 
            // chartFT
            // 
            chartArea2.Name = "ChartArea1";
            this.chartFT.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.chartFT.Legends.Add(legend2);
            this.chartFT.Location = new System.Drawing.Point(6, 21);
            this.chartFT.Name = "chartFT";
            this.chartFT.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.IsValueShownAsLabel = true;
            series2.Label = "#VALX #VAL{P}";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartFT.Series.Add(series2);
            this.chartFT.Size = new System.Drawing.Size(365, 350);
            this.chartFT.TabIndex = 1;
            this.chartFT.Text = "chart2";
            this.toolTip1.SetToolTip(this.chartFT, "Double Click Here to View Y.R. by line");
            this.chartFT.DoubleClick += new System.EventHandler(this.chartFT_DoubleClick);
            // 
            // lblLastFreshInfo
            // 
            this.lblLastFreshInfo.AutoSize = true;
            this.lblLastFreshInfo.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastFreshInfo.Location = new System.Drawing.Point(16, 21);
            this.lblLastFreshInfo.Name = "lblLastFreshInfo";
            this.lblLastFreshInfo.Size = new System.Drawing.Size(143, 17);
            this.lblLastFreshInfo.TabIndex = 2;
            this.lblLastFreshInfo.Text = "Last Refresh Data Time:";
            // 
            // lblNextFreshInfo
            // 
            this.lblNextFreshInfo.AutoSize = true;
            this.lblNextFreshInfo.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextFreshInfo.Location = new System.Drawing.Point(293, 21);
            this.lblNextFreshInfo.Name = "lblNextFreshInfo";
            this.lblNextFreshInfo.Size = new System.Drawing.Size(141, 17);
            this.lblNextFreshInfo.TabIndex = 3;
            this.lblNextFreshInfo.Text = "Next Refresh Time Left:";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // grpATE
            // 
            this.grpATE.Controls.Add(this.txtATEQtyInfo);
            this.grpATE.Controls.Add(this.label1);
            this.grpATE.Controls.Add(this.chartATE);
            this.grpATE.Location = new System.Drawing.Point(12, 73);
            this.grpATE.Name = "grpATE";
            this.grpATE.Size = new System.Drawing.Size(383, 413);
            this.grpATE.TabIndex = 4;
            this.grpATE.TabStop = false;
            // 
            // txtATEQtyInfo
            // 
            this.txtATEQtyInfo.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtATEQtyInfo.Location = new System.Drawing.Point(8, 379);
            this.txtATEQtyInfo.Name = "txtATEQtyInfo";
            this.txtATEQtyInfo.ReadOnly = true;
            this.txtATEQtyInfo.Size = new System.Drawing.Size(365, 25);
            this.txtATEQtyInfo.TabIndex = 7;
            this.txtATEQtyInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(112, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "ATE Overall Yield Rate";
            // 
            // grpFT
            // 
            this.grpFT.Controls.Add(this.txtFTQtyInfo);
            this.grpFT.Controls.Add(this.label2);
            this.grpFT.Controls.Add(this.chartFT);
            this.grpFT.Location = new System.Drawing.Point(401, 73);
            this.grpFT.Name = "grpFT";
            this.grpFT.Size = new System.Drawing.Size(378, 413);
            this.grpFT.TabIndex = 5;
            this.grpFT.TabStop = false;
            // 
            // txtFTQtyInfo
            // 
            this.txtFTQtyInfo.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFTQtyInfo.Location = new System.Drawing.Point(7, 378);
            this.txtFTQtyInfo.Name = "txtFTQtyInfo";
            this.txtFTQtyInfo.ReadOnly = true;
            this.txtFTQtyInfo.Size = new System.Drawing.Size(365, 25);
            this.txtFTQtyInfo.TabIndex = 8;
            this.txtFTQtyInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(112, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "FT Overall Yield Rate";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblLastFreshInfo);
            this.groupBox1.Controls.Add(this.lblNextFreshInfo);
            this.groupBox1.Location = new System.Drawing.Point(151, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 50);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // frmYRMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 497);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpFT);
            this.Controls.Add(this.grpATE);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmYRMonitor";
            this.Text = "frmYRMonitor";
            this.Load += new System.EventHandler(this.frmYRMonitor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartFT)).EndInit();
            this.grpATE.ResumeLayout(false);
            this.grpATE.PerformLayout();
            this.grpFT.ResumeLayout(false);
            this.grpFT.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartATE;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFT;
        private System.Windows.Forms.Label lblLastFreshInfo;
        private System.Windows.Forms.Label lblNextFreshInfo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox grpATE;
        private System.Windows.Forms.GroupBox grpFT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtATEQtyInfo;
        private System.Windows.Forms.TextBox txtFTQtyInfo;
        private System.Windows.Forms.ToolTip toolTip1;

    }
}