using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
namespace VandP_Serial
{
    
    public partial class Form1 : Form
    {
        public static bool isDpower = true;
        SerialTool DPower_Serial = new SerialTool();//数字源
        SerialTool Physical_Serial = new SerialTool();//物理串口

        private System.Threading.Timer m_timerCmdSendPower = null;//串口监听


        public ArrayList m_arrayList_Digital = new ArrayList();//来自数字化接收：用物理串口将该内容发出
        public ArrayList m_arrayList_Physical = new ArrayList();//来自物理串口的接收：用数字源串口将该内容发出
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        //委托显示方法一：
        public delegate void display(string Info, RichTextBox control);
        public void showInfo(string message, RichTextBox RichTexBox)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new display(showInfo), new object[] { message, RichTexBox });
                }
                else
                {
                    RichTexBox.AppendText(message + "\r\n");
                }
            }
            catch { }

        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //数字源串口
                iniFileTool.iniPath = System.Windows.Forms.Application.StartupPath + "\\Config.ini";

                String comPortName = iniFileTool.ReadIniData("Digital", "串口", "COM2");
                int baudRate = int.Parse(iniFileTool.ReadIniData("Digital", "波特率", "57600"));
                string parity = iniFileTool.ReadIniData("Digital", "校验位", "None");
                int dataBits = int.Parse(iniFileTool.ReadIniData("Digital", "数据位", "8"));
                string StopBits = iniFileTool.ReadIniData("Digital", "停止位", "2");
                if (DPower_Serial.setSerialPort(comPortName, baudRate, parity, dataBits, StopBits) == false)
                {
                    RTB_Digital.AppendText("打开数字源通讯端口失败！！"+"\r\n");
                    return;
                }
                else
                { RTB_Digital.AppendText("打开数字源通讯端口成功"+"\r\n"); }
                //物理串口
                comPortName = iniFileTool.ReadIniData("Physical", "串口", "COM1");
                baudRate = int.Parse(iniFileTool.ReadIniData("Physical", "波特率", "57600"));
                parity = iniFileTool.ReadIniData("Physical", "校验位", "None");
                dataBits = int.Parse(iniFileTool.ReadIniData("Physical", "数据位", "8"));
                StopBits = iniFileTool.ReadIniData("Physical", "停止位", "2");
                if (Physical_Serial.setSerialPort(comPortName, baudRate, parity, dataBits, StopBits) == false)
                {
                    RTB_Physical.AppendText("打开上行物理通讯端口失败！！"+"\r\n");
                    return;
                }
                else { RTB_Physical.AppendText("打开上行物理通讯端口成功"+"\r\n"); }
                m_timerCmdSendPower = new System.Threading.Timer(new TimerCallback(Comunication), null, 600, 500);//500ms               

            }
            catch(Exception exc)
            { MessageBox.Show(exc.ToString()); }
        }



        public int RecDelayTime = 5000;//ms
        public int SendTimes = 1;//次
        public int RecToSendTime = 200;//ms
        /// <summary>
        /// 处理报文交换
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public void Comunication(object obj)
        {
            try
            {
                while (true)
                {
                    //先停掉定时器,处理完后再开始
                    m_timerCmdSendPower.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
                    Thread.Sleep(100);
                    if (Physical_Serial.buffer.Count > 0)
                    {
                        byte[] receive = new byte[Physical_Serial.buffer.Count];
                        Physical_Serial.buffer.CopyTo(receive, 0);
                        m_arrayList_Physical.Add(receive);
                        break;
                    }
                }

                if (m_arrayList_Physical.Count > 0)//物理串口：接收缓存有数据的话
                {
                    //先停掉定时器,处理完后再开始
                    m_timerCmdSendPower.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);

                    byte[] cmds;
                    byte[] bTransmitCmd = m_arrayList_Physical[0] as byte[];
                    //使用数字源串口发送出去                   
                    DPower_Serial.buffer.Clear();
                    DPower_Serial.ReceiveEventFlag = false;
                    int dataNum = 0;
                    for (int i = 0; i < SendTimes; i++)
                    {
                        int j = 0;
                        DPower_Serial.buffer.Clear();
                        DPower_Serial.SendData(bTransmitCmd, 0, bTransmitCmd.Length);
                        Thread.Sleep(100);//加一个100ms延时:原本是10ms延时，或者没有延时，这两种情况都会造成来自数字源回复de 报文，上位机会接收不全
                        showInfo("TX:" + DataConvert.byteToHexStr(bTransmitCmd), RTB_Digital);//不太合法
                        Application.DoEvents();
                        while (j++ < (RecDelayTime / 10))
                        {
                            Thread.Sleep(10);
                            if (DPower_Serial.buffer.Count > 0)
                            {
                                byte[] receive = new byte[DPower_Serial.buffer.Count];
                                DPower_Serial.buffer.CopyTo(receive, 0);
                                m_arrayList_Digital.Add(receive);
                                break;
                            }

                        }
                      
                    }
                }


                if (m_arrayList_Digital.Count > 0)//数字源串口：接收缓存有数据的话
                {
                    //先停掉定时器,处理完后再开始
                    m_timerCmdSendPower.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);

                    byte[] cmds;
                    byte[] bTransmitCmd = m_arrayList_Digital[0] as byte[];
                    //使用物理串口发送出去                  
                    Physical_Serial.buffer.Clear();
                    Physical_Serial.ReceiveEventFlag = false;

                    for (int i = 0; i < SendTimes; i++)
                    {
                        int j = 0;
                        Physical_Serial.buffer.Clear();
                        Physical_Serial.SendData(bTransmitCmd, 0, bTransmitCmd.Length);
                        showInfo("TX:" + DataConvert.byteToHexStr(bTransmitCmd), RTB_Physical);
                        Application.DoEvents();
                        /*  多余部分：不用等着检测软件的报文，上面有Wile(true)就行
                        //while (j++ < (RecDelayTime / 10))
                        //{
                        //    Thread.Sleep(10);
                        //    if (Physical_Serial.buffer.Count > 0)
                        //    {
                        //        byte[] receive = new byte[Physical_Serial.buffer.Count];
                        //        Physical_Serial.buffer.CopyTo(receive, 0);
                        //        m_arrayList_Physical.Add(receive);
                        //        break;
                        //    }

                        //}
                         */
                    }
                }

            }
            catch { }
            finally
            {
                m_arrayList_Physical.Clear();
                m_arrayList_Digital.Clear();

                Physical_Serial.buffer.Clear();
                m_timerCmdSendPower.Change(20, 20);
            }
        }      

        private void button1_Click(object sender, EventArgs e)
        {
            isDpower = true;
            Form2 Digital = new Form2();
            Digital.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isDpower = false;
            Form2 Physical = new Form2();
            Physical.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RTB_Digital.Clear();
            RTB_Physical.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Physical_Serial.closePort();
            DPower_Serial.closePort();
        }
    }
}
