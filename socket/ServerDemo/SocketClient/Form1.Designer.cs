namespace SocketClient
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.butSend = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textPoint = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textMsg = new System.Windows.Forms.TextBox();
            this.textIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // butSend
            // 
            this.butSend.Location = new System.Drawing.Point(393, 383);
            this.butSend.Name = "butSend";
            this.butSend.Size = new System.Drawing.Size(75, 23);
            this.butSend.TabIndex = 10;
            this.butSend.Text = "发送消息";
            this.butSend.UseVisualStyleBackColor = true;
            this.butSend.Click += new System.EventHandler(this.butSend_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(571, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "链接";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textPoint
            // 
            this.textPoint.Location = new System.Drawing.Point(423, 14);
            this.textPoint.Name = "textPoint";
            this.textPoint.Size = new System.Drawing.Size(100, 21);
            this.textPoint.TabIndex = 5;
            this.textPoint.Text = "7788";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(137, 52);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(429, 309);
            this.textBox1.TabIndex = 6;
            // 
            // textMsg
            // 
            this.textMsg.Location = new System.Drawing.Point(137, 383);
            this.textMsg.Name = "textMsg";
            this.textMsg.Size = new System.Drawing.Size(200, 21);
            this.textMsg.TabIndex = 7;
            // 
            // textIP
            // 
            this.textIP.Location = new System.Drawing.Point(210, 14);
            this.textIP.Name = "textIP";
            this.textIP.Size = new System.Drawing.Size(100, 21);
            this.textIP.TabIndex = 8;
            this.textIP.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(376, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "端口：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "服务器地址：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 417);
            this.Controls.Add(this.butSend);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textPoint);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textMsg);
            this.Controls.Add(this.textIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button butSend;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textPoint;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textMsg;
        private System.Windows.Forms.TextBox textIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

