namespace VandP_Serial
{
    partial class Form2
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox5_StopBit = new System.Windows.Forms.ComboBox();
            this.comboBox4_DataBit = new System.Windows.Forms.ComboBox();
            this.comboBox3_XiaoYan = new System.Windows.Forms.ComboBox();
            this.comboBox2_Baud = new System.Windows.Forms.ComboBox();
            this.comboBox1_SerialName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(182, 222);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 23);
            this.button2.TabIndex = 35;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(52, 222);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 33;
            this.label5.Text = "停止位";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 32;
            this.label4.Text = "数据位";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 31;
            this.label3.Text = "校验位";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 30;
            this.label2.Text = "波特率";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 29;
            this.label1.Text = "串口";
            // 
            // comboBox5_StopBit
            // 
            this.comboBox5_StopBit.FormattingEnabled = true;
            this.comboBox5_StopBit.Items.AddRange(new object[] {
            "1",
            "2",
            "1.5"});
            this.comboBox5_StopBit.Location = new System.Drawing.Point(100, 180);
            this.comboBox5_StopBit.Name = "comboBox5_StopBit";
            this.comboBox5_StopBit.Size = new System.Drawing.Size(155, 20);
            this.comboBox5_StopBit.TabIndex = 28;
            // 
            // comboBox4_DataBit
            // 
            this.comboBox4_DataBit.FormattingEnabled = true;
            this.comboBox4_DataBit.Items.AddRange(new object[] {
            "8"});
            this.comboBox4_DataBit.Location = new System.Drawing.Point(100, 141);
            this.comboBox4_DataBit.Name = "comboBox4_DataBit";
            this.comboBox4_DataBit.Size = new System.Drawing.Size(155, 20);
            this.comboBox4_DataBit.TabIndex = 27;
            // 
            // comboBox3_XiaoYan
            // 
            this.comboBox3_XiaoYan.FormattingEnabled = true;
            this.comboBox3_XiaoYan.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.comboBox3_XiaoYan.Location = new System.Drawing.Point(100, 100);
            this.comboBox3_XiaoYan.Name = "comboBox3_XiaoYan";
            this.comboBox3_XiaoYan.Size = new System.Drawing.Size(155, 20);
            this.comboBox3_XiaoYan.TabIndex = 26;
            // 
            // comboBox2_Baud
            // 
            this.comboBox2_Baud.FormattingEnabled = true;
            this.comboBox2_Baud.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "57600"});
            this.comboBox2_Baud.Location = new System.Drawing.Point(100, 58);
            this.comboBox2_Baud.Name = "comboBox2_Baud";
            this.comboBox2_Baud.Size = new System.Drawing.Size(155, 20);
            this.comboBox2_Baud.TabIndex = 25;
            // 
            // comboBox1_SerialName
            // 
            this.comboBox1_SerialName.FormattingEnabled = true;
            this.comboBox1_SerialName.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3"});
            this.comboBox1_SerialName.Location = new System.Drawing.Point(100, 17);
            this.comboBox1_SerialName.Name = "comboBox1_SerialName";
            this.comboBox1_SerialName.Size = new System.Drawing.Size(155, 20);
            this.comboBox1_SerialName.TabIndex = 24;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox5_StopBit);
            this.Controls.Add(this.comboBox4_DataBit);
            this.Controls.Add(this.comboBox3_XiaoYan);
            this.Controls.Add(this.comboBox2_Baud);
            this.Controls.Add(this.comboBox1_SerialName);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox5_StopBit;
        private System.Windows.Forms.ComboBox comboBox4_DataBit;
        private System.Windows.Forms.ComboBox comboBox3_XiaoYan;
        private System.Windows.Forms.ComboBox comboBox2_Baud;
        private System.Windows.Forms.ComboBox comboBox1_SerialName;
    }
}