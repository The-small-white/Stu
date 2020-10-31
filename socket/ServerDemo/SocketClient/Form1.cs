using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketClient
{
    public partial class Form1 : Form
    {

        Socket proxClient = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Socket client = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            try
            {
                //建立远程链接
                client.Connect(textIP.Text, Int32.Parse(textPoint.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败");
              
                throw ex;
            }
            proxClient = client;
            ThreadPool.QueueUserWorkItem(ReceiveData,client);
          

        }
        private void ReceiveData(object state) 
        {
            Socket client = state as Socket;
            byte[] data = new byte[2 * 1024];
            while (true)
            {
                int len = 0;
                try
                {
                    len = client.Receive(data,0,data.Length,SocketFlags.None);
                }
                catch (Exception)
                {

                    throw;
                }
                if (data[0]==1)
                {

                }
                if (data[0]==2)
                {
                    //闪屏
                    Shake();
                }

            }
        
        }

        private void Shake()
        {
            //1.拿到当前窗体坐标
            Point oldLocation = this.Location;
            Random r = new Random();
            for (int i = 0; i < 50; i++)
            {
                this.Location = new Point(r.Next(oldLocation.X-5,oldLocation.X+5),r.Next(oldLocation.Y-5,oldLocation.Y+5));
                Thread.Sleep(50);
                this.Location = oldLocation;
            }
            
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butSend_Click(object sender, EventArgs e)
        {
            string msg = textMsg.Text;
            byte[] data = Encoding.Default.GetBytes(msg);
            //发送消息
            proxClient.Send(data,SocketFlags.None);
        }
    }
}
