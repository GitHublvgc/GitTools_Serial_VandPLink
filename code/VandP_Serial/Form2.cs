using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VandP_Serial
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string section = "";
                if (Form1.isDpower)
                { section = "Digital"; }
                else
                { section = "Physical"; }
                iniFileTool.iniPath = Application.StartupPath + "\\config.ini";

                iniFileTool.WriteIniData(section, "串口", comboBox1_SerialName.Text);
                iniFileTool.WriteIniData(section, "波特率", comboBox2_Baud.Text);
                iniFileTool.WriteIniData(section, "校验位", comboBox3_XiaoYan.Text);
                iniFileTool.WriteIniData(section, "数据位", comboBox4_DataBit.Text);
                iniFileTool.WriteIniData(section, "停止位", comboBox5_StopBit.Text);
                MessageBox.Show("保存成功");
            }
            catch { }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                string section = "";
                if (Form1.isDpower)
                { section = "Digital"; }
                else
                { section = "Physical"; }
                iniFileTool.iniPath = Application.StartupPath + "\\config.ini";

                comboBox1_SerialName.Text = iniFileTool.ReadIniData(section, "串口", "COM1");
                comboBox2_Baud.Text = iniFileTool.ReadIniData(section, "波特率", "9600");
                comboBox3_XiaoYan.Text = iniFileTool.ReadIniData(section, "校验位", "None");
                comboBox4_DataBit.Text = iniFileTool.ReadIniData(section, "数据位", "8");
                comboBox5_StopBit.Text = iniFileTool.ReadIniData(section, "停止位", "1");
            }
            catch (Exception exc)
            { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
