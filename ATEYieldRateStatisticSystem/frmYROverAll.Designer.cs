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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLastFreshInfo = new System.Windows.Forms.Label();
            this.lblNextFreshInfo = new System.Windows.Forms.Label();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.txtATEQtyInfo = new System.Windows.Forms.TextBox();
            this.txtFTQtyInfo = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblLastFreshInfo);
            this.groupBox1.Controls.Add(this.lblNextFreshInfo);
            this.groupBox1.Location = new System.Drawing.Point(128, 23);
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
            // skinEngine1
            // 
            this.skinEngine1.@__DrawButtonFocusRectangle = true;
            this.skinEngine1.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEngine1.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEngine1.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // txtATEQtyInfo
            // 
            this.txtATEQtyInfo.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtATEQtyInfo.Location = new System.Drawing.Point(83, 474);
            this.txtATEQtyInfo.Name = "txtATEQtyInfo";
            this.txtATEQtyInfo.ReadOnly = true;
            this.txtATEQtyInfo.Size = new System.Drawing.Size(300, 25);
            this.txtATEQtyInfo.TabIndex = 12;
            this.txtATEQtyInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFTQtyInfo
            // 
            this.txtFTQtyInfo.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFTQtyInfo.Location = new System.Drawing.Point(436, 474);
            this.txtFTQtyInfo.Name = "txtFTQtyInfo";
            this.txtFTQtyInfo.ReadOnly = true;
            this.txtFTQtyInfo.Size = new System.Drawing.Size(300, 25);
            this.txtFTQtyInfo.TabIndex = 13;
            this.txtFTQtyInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmYROverAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 520);
            this.Controls.Add(this.txtFTQtyInfo);
            this.Controls.Add(this.txtATEQtyInfo);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmYROverAll";
            this.Text = "frmYROverAll";
            this.Load += new System.EventHandler(this.frmYROverAll_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmYROverAll_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLastFreshInfo;
        private System.Windows.Forms.Label lblNextFreshInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.TextBox txtATEQtyInfo;
        private System.Windows.Forms.TextBox txtFTQtyInfo;
        private System.Windows.Forms.Timer timer1;

    }
}