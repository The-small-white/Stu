using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace ServerDemo
{
    public partial class Form1 : Form
    {
        //储存链接记录
        List<Socket> clientList = new List<Socket>();
        public Form1()
        {
            InitializeComponent();
            //禁止跨线程访问
            // CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //创建Socket
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //绑定ip和端口号
            server.Bind(new IPEndPoint(IPAddress.Parse(textIP.Text.Trim()), Int32.Parse(textPoint.Text.Trim())));
            //监听挂起链接（最大长度为10）
            server.Listen(10);
            //创建线程池调用链接Socket方法         
            ThreadPool.QueueUserWorkItem(new WaitCallback(AcceptSocketClient),server);
            MessageBox.Show("启动成功");

        }

        /// <summary>
        /// 创建新链接
        /// </summary>
        /// <param name="obj"></param>
        private void AcceptSocketClient(object obj)
        {
            Socket server = obj as Socket;
            while (true)
            {
                //创建新连接 接受客户端链接
                Socket client = server.Accept();
                //将新链接添加到list中记录
                clientList.Add(client);
                AppendToManinBoardText(string.Format("客户端链接上来了：{0}", client.LocalEndPoint));
                //用新线程调用接收方法
                ThreadPool.QueueUserWorkItem(ReceiveData, client);
            }
        }
        /// <summary>
        /// 不停接收客户端数据
        /// </summary>
        /// <param name="state"></param>
        private void ReceiveData(object state)
        {
            Socket client = state as Socket;
            byte[] data = new byte[2 * 1024];
            while (true)
            {
                int len = 0;
                try
                {
                    len = client.Receive(data, SocketFlags.None);//接收到的字节数
                    string msg = Encoding.Default.GetString(data, 0, len);

                    DateTime t = DateTime.Now;

                    AppendToManinBoardText(string.Format("客户端：{0}", msg));
                    AppendToManinBoardText(string.Format("时间：{0}", t));
                }
                catch (Exception ex)
                {
                    AppendToManinBoardText(string.Format("客户端：{0}非正常退出了", client.LocalEndPoint));
                    //从list中移除异常记录
                    clientList.Remove(client);
                    //关闭链接
                    if (client.Connected)
                    {
                        client.Shutdown(SocketShutdown.Both);
                        client.Close();
                    }
                    return;
                }
                if (len <= 0)
                {
                    clientList.Remove(client);
                    //关闭链接
                    if (client.Connected)
                    {
                        client.Shutdown(SocketShutdown.Both);
                        client.Close();
                    }
                    return;
                }            
            }
        }
        /// <summary>
        /// 处理跨线程访问(同时访问同一控件时)
        /// </summary>
        /// <param name="txt"></param>
        private void AppendToManinBoardText(string txt)
        {
            //如果被异步调用了
            if (textBox1.InvokeRequired)
            {
                //开启一个新调用
                textBox1.BeginInvoke(new Action<string>((s) => { textBox1.Text = s + "\r\n" + textBox1.Text; }), txt);
            }
            else
            {
                textBox1.Text = txt + "\r\n" + textBox1.Text;
            }
        }
        /// <summary>
        /// 发送按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            
            //循环已存在的socket链接
            foreach (Socket proxSocket in clientList)
            {
                //先判断是否链接
                if (proxSocket.Connected)
                {
                    //1.把原始字符串转换成字节数组
                    string msg = textMsg.Text;
                    byte[] data = Encoding.Default.GetBytes(msg);
                    //2.对原始字节数组加上协议头部字节
                    byte[] result = new byte[data.Length + 1];
                    result[0] = 1;
                    //3.把原始的字节数组放到最终数组中
                    Buffer.BlockCopy(data, 0, result, 1, data.Length);
                    proxSocket.Send(result, 0, result.Length, SocketFlags.None);
                 //   proxSocket.Send(data , 0, data.Length, SocketFlags.None);

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //循环已存在的socket链接
            foreach (Socket proxSocket in clientList)
            {
                //先判断是否链接
                if (proxSocket.Connected)
                {
                    //1.把原始字符串转换成字节数组
                    string msg ="抖动窗口";
                    byte[] data = Encoding.Default.GetBytes(msg);
                    //2.对原始字节数组加上协议头部字节
                    byte[] result = new byte[data.Length + 1];
                    result[0] = 2;
                    //3.把原始的字节数组放到最终数组中
                    Buffer.BlockCopy(data, 0, result, 1, data.Length);
                    proxSocket.Send(result, 0, result.Length, SocketFlags.None);



                    //发送协议头为2
                    //proxSocket.Send(new byte[] { 2 }, SocketFlags.None);
                }


            }
        }
    }
}
