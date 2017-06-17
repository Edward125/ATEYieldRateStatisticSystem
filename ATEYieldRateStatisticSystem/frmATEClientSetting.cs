using Edward;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATEYieldRateStatisticSystem
{
    public partial class frmATEClientSetting : Form
    {
        public frmATEClientSetting()
        {
            InitializeComponent();
        }





        private void LoadData2UI()
        {
            this.txtAutoLookLogPath.Text = p.AutoLookLogPath.Trim();
            this.txtTestlogPath.Text = p.TestlogPath.Trim();
            //MessageBox.Show(p.ATEPlant.ToString());

            comboPlantCode.Text = p.ATEPlant.ToString();
            if (p.ATEPlant == p.PlantCode.F721)
                txtWebService.Text = p.SFCS721Webservice;
            if (p.ATEPlant == p.PlantCode.F722)
                txtWebService.Text = p.SFCS722Webservice;

            this.combPassFlag.Text = p.PassFlag.ToUpper().Trim();
            this.txtFileFrontFlag.Text = p.FileFrontFlag.Trim();
            this.txtFileExtension.Text = p.FileExtension.Trim();
            if (p.FaonFaoffBase == "0")
                rab0.Checked = true;
            if (p.FaonFaoffBase == "1")
                rab1.Checked = true;
            if (p.StartEndTime == p.StartEndTimeType.Day830)
                rabDay830.Checked = true;
            if (p.StartEndTime == p.StartEndTimeType.Day800)
                rabDay800.Checked = true;
            //
            rab0.Text = "0 " + p.PassFlag;
            rab1.Text = "1 " + p.PassFlag;
        }

        private void frmATEClientSetting_Load(object sender, EventArgs e)
        {
            LoadData2UI();
        }

        private void combPassFlag_SelectedIndexChanged(object sender, EventArgs e)
        {
            p.PassFlag = combPassFlag.Text.Trim().ToUpper();
            IniFile.IniWriteValue(p.IniSection.ATEConfig .ToString (), "PassFlag", p.PassFlag, p.iniFilePath);
            //
            rab0.Text = "0 " + p.PassFlag;
            rab1.Text = "1 " + p.PassFlag;
        }

        private void txtAutoLookLogPath_DoubleClick(object sender, EventArgs e)
        {
            p.openFolder(txtAutoLookLogPath);
            if (string.IsNullOrEmpty(txtAutoLookLogPath.Text.Trim()))
                return;
            else
            {
                string inipath = txtAutoLookLogPath.Text.Trim() + @"\path.ini";
                if (System.IO.File.Exists(inipath))
                {
                    string line = string.Empty;
                    string boardpath = string.Empty;

                    StreamReader sr = new StreamReader(inipath);
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        if (!line.StartsWith("!"))
                        {
                            if (line.ToUpper().Contains("#BoardPath#".ToUpper()))
                            {
                                boardpath = line.Replace("#BoardPath#:", "");
                                p.TestlogPath = boardpath + @"testlog\";
                                txtTestlogPath.Text = p.TestlogPath;

                            }
                        }
                    }
                    sr.Close();

                }

            }
        }

        private void txtAutoLookLogPath_TextChanged(object sender, EventArgs e)
        {
            p.AutoLookLogPath = this.txtAutoLookLogPath.Text.Trim();
            IniFile.IniWriteValue(p.IniSection.ATEConfig.ToString (), "AutoLookLogPath", p.AutoLookLogPath, p.iniFilePath);
        }

        private void txtTestlogPath_DoubleClick(object sender, EventArgs e)
        {
           p.openFolder(txtTestlogPath);
        }

        private void txtFileFrontFlag_TextChanged(object sender, EventArgs e)
        {
            p.FileFrontFlag = this.txtFileFrontFlag.Text.Trim();
            IniFile.IniWriteValue(p.IniSection.ATEConfig.ToString(), "FileFrontFlag", p.FileFrontFlag, p.iniFilePath);
        }

        private void txtFileExtension_TextChanged(object sender, EventArgs e)
        {
            if (!txtFileExtension.Text.Trim().StartsWith("."))
                txtFileExtension.Text = "." + txtFileExtension.Text.Trim();
            IniFile.IniWriteValue(p.IniSection.ATEConfig.ToString(), "FileExtension", p.FileExtension, p.iniFilePath);
        }

        private void txtWebService_TextChanged(object sender, EventArgs e)
        {

            if (comboPlantCode.SelectedIndex == -1)
            {
                MessageBox.Show("pls select PlantCode first.", "Don't Select PlantCode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboPlantCode.Focus();
                return;
            }

            if (p.ATEPlant == p.PlantCode.F721 )
            {
               p.SFCS721Webservice  = this.txtWebService.Text.Trim();
               IniFile.IniWriteValue(p.IniSection.WebService.ToString (), "SFCS721Webservice", p.SFCS721Webservice, p.iniFilePath);
            }

            if (p.ATEPlant == p.PlantCode.F722)
            {
                p.SFCS722Webservice = this.txtWebService.Text.Trim();
                IniFile.IniWriteValue(p.IniSection.WebService.ToString(), "SFCS722Webservice", p.SFCS722Webservice, p.iniFilePath);
            }
         
        }

        private void comboPlantCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            p.ATEPlant = (p.PlantCode)Enum.Parse(typeof(p.PlantCode), comboPlantCode.Text );
            IniFile.IniWriteValue(p.IniSection.ATEConfig.ToString(), "ATEPlant", p.ATEPlant.ToString (), p.iniFilePath);
            if (p.ATEPlant == p.PlantCode.F721)
              txtWebService .Text  = p.SFCS721Webservice;
            if (p.ATEPlant == p.PlantCode.F722)
                txtWebService.Text = p.SFCS722Webservice;

        }


    }
}
