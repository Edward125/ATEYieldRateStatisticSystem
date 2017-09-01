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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLastFreshInfo = new System.Windows.Forms.Label();
            this.lblNextFreshInfo = new System.Windows.Forms.Label();
            this.grpATE = new System.Windows.Forms.GroupBox();
            this.txtATEQtyInfo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpFT = new System.Windows.Forms.GroupBox();
            this.txtFTQtyInfo = new System.Windows.Forms.TextBox();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.grpATE.SuspendLayout();
            this.grpFT.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblLastFreshInfo);
            this.groupBox1.Controls.Add(this.lblNextFreshInfo);
            this.groupBox1.Location = new System.Drawing.Point(184, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 50);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Last Refresh Data Time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(317, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Next Refresh Time Left:";
            // 
            // lblLastFreshInfo
            // 
            this.lblLastFreshInfo.AutoSize = true;
            this.lblLastFreshInfo.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastFreshInfo.Location = new System.Drawing.Point(16, 71);
            this.lblLastFreshInfo.Name = "lblLastFreshInfo";
            this.lblLastFreshInfo.Size = new System.Drawing.Size(143, 17);
            this.lblLastFreshInfo.TabIndex = 2;
            this.lblLastFreshInfo.Text = "Last Refresh Data Time:";
            // 
            // lblNextFreshInfo
            // 
            this.lblNextFreshInfo.AutoSize = true;
            this.lblNextFreshInfo.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextFreshInfo.Location = new System.Drawing.Point(293, 71);
            this.lblNextFreshInfo.Name = "lblNextFreshInfo";
            this.lblNextFreshInfo.Size = new System.Drawing.Size(141, 17);
            this.lblNextFreshInfo.TabIndex = 3;
            this.lblNextFreshInfo.Text = "Next Refresh Time Left:";
            // 
            // grpATE
            // 
            this.grpATE.Controls.Add(this.txtATEQtyInfo);
            this.grpATE.Controls.Add(this.label1);
            this.grpATE.Location = new System.Drawing.Point(45, 84);
            this.grpATE.Name = "grpATE";
            this.grpATE.Size = new System.Drawing.Size(383, 413);
            this.grpATE.TabIndex = 8;
            this.grpATE.TabStop = false;
            // 
            // txtATEQtyInfo
            // 
            this.txtATEQtyInfo.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtATEQtyInfo.Location = new System.Drawing.Point(8, 429);
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
            this.label1.Location = new System.Drawing.Point(116, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "ATE Overall Yield Rate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(103, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "FT Overall Yield Rate";
            // 
            // grpFT
            // 
            this.grpFT.Controls.Add(this.txtFTQtyInfo);
            this.grpFT.Controls.Add(this.label2);
            this.grpFT.Location = new System.Drawing.Point(434, 84);
            this.grpFT.Name = "grpFT";
            this.grpFT.Size = new System.Drawing.Size(378, 413);
            this.grpFT.TabIndex = 9;
            this.grpFT.TabStop = false;
            // 
            // txtFTQtyInfo
            // 
            this.txtFTQtyInfo.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFTQtyInfo.Location = new System.Drawing.Point(7, 428);
            this.txtFTQtyInfo.Name = "txtFTQtyInfo";
            this.txtFTQtyInfo.ReadOnly = true;
            this.txtFTQtyInfo.Size = new System.Drawing.Size(365, 25);
            this.txtFTQtyInfo.TabIndex = 8;
            this.txtFTQtyInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 34);
            this.button1.TabIndex = 11;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmYROverAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 520);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpATE);
            this.Controls.Add(this.grpFT);
            this.Name = "frmYROverAll";
            this.Text = "frmYROverAll";
            this.Load += new System.EventHandler(this.frmYROverAll_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmYROverAll_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpATE.ResumeLayout(false);
            this.grpATE.PerformLayout();
            this.grpFT.ResumeLayout(false);
            this.grpFT.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLastFreshInfo;
        private System.Windows.Forms.Label lblNextFreshInfo;
        private System.Windows.Forms.GroupBox grpATE;
        private System.Windows.Forms.TextBox txtATEQtyInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpFT;
        private System.Windows.Forms.TextBox txtFTQtyInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.Button button1;

    }
}