using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace MyFirstSqlServer
{
    public partial class ServiceTest : ServiceBase
    {
        SqlConnection conn = new SqlConnection("server=.;Initial Catalog=PlusbeCloud;User ID=Plusbe_Cloud;Password=plusbemygoogle2019");
        public ServiceTest()
        {
            InitializeComponent();
            timer1.Start();
        }
        protected override void OnStart(string[] args)
        {
            timer1.Start();
        }

        protected override void OnStop()
        {
            timer1.Stop();
        }
        public int update()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Fault  set Name='1' WHERE ID=5 ", conn);
            if (dataExist("Fault", "ID", "5"))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (SqlException e)
                {
                    conn.Close();
                    return e.Number;
                }
                return 1;
            }
            else
            {
                conn.Close();
                return 0;
            }
        }

        /// <summary>
        /// 判断数据是否存在于数据库中
        /// </summary>
        /// <param name="sheetName">表名称</param>
        /// <param name="columnName">列名称</param>
        /// <param name="data">查找数据名称</param>
        /// <returns></returns>
        private bool dataExist(string sheetName, string columnName, string data)
        {
            //conn.Open();//打开数据库
            SqlCommand myCmd = new SqlCommand("select count(*) from " + sheetName + " where " + columnName + "='" + data + "'", conn);
            //int n = myCmd.ExecuteNonQuery();
            int n = int.Parse(myCmd.ExecuteScalar().ToString());
            //conn.Close();

            if (n > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            update();

        }
    }
}
