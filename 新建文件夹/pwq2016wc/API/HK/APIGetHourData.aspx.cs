using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Dejun.DataProvider.Table;
using Dejun.DataProvider.Sql2005;
using System.Web.Script.Serialization;

public partial class Admin_API_APIGetHourData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Result result = new Result();

        Temp temp = new Temp();

        temp._9_10ExitNum = GetSumBySql("ExitNum", 9, 10);
        temp._9_10EnterNum = GetSumBySql("EnterNum", 9, 10);

        temp._10_12ExitNum = GetSumBySql("ExitNum", 10, 12);
        temp._10_12EnterNum = GetSumBySql("EnterNum", 10, 12);

        temp._13_15ExitNum = GetSumBySql("ExitNum", 13, 15);
        temp._13_15EnterNum = GetSumBySql("EnterNum", 13, 15);

        temp._15_16ExitNum = GetSumBySql("ExitNum", 15, 16);
        temp._15_16EnterNum = GetSumBySql("EnterNum", 15, 16);

        temp._16_18ExitNum = GetSumBySql("ExitNum", 16, 18);
        temp._16_18EnterNum = GetSumBySql("EnterNum", 16, 18);

        result.isOk = true;
        result.obj = temp;

        Response.ContentType = "text/json";
        Response.Write(new JavaScriptSerializer().Serialize(result));
        Response.End();
    }
    private long GetSumBySql(string column, int h1, int h2)
    {
        string sql = "select sum(" + column + ")  from PeopleCount where DATEPART(hh, CountTime)>=" + h1 + " and DATEPART(hh, CountTime)<" + h2;
        object o = SQL.ExecuteScalar(SQL.ConnectionStringProfile, CommandType.Text, sql);
        if (o == DBNull.Value) return 0;
        return Convert.ToInt64(o);
    }

    private class Temp
    {
        private long __9_10ExitNum;

        public long _9_10ExitNum
        {
            get { return __9_10ExitNum; }
            set { __9_10ExitNum = value; }
        }
        private long __9_10EnterNum;

        public long _9_10EnterNum
        {
            get { return __9_10EnterNum; }
            set { __9_10EnterNum = value; }
        }

        private long __10_12ExitNum;

        public long _10_12ExitNum
        {
            get { return __10_12ExitNum; }
            set { __10_12ExitNum = value; }
        }
        private long __10_12EnterNum;

        public long _10_12EnterNum
        {
            get { return __10_12EnterNum; }
            set { __10_12EnterNum = value; }
        }

        private long __13_15ExitNum;

        public long _13_15ExitNum
        {
            get { return __13_15ExitNum; }
            set { __13_15ExitNum = value; }
        }
        private long __13_15EnterNum;

        public long _13_15EnterNum
        {
            get { return __13_15EnterNum; }
            set { __13_15EnterNum = value; }
        }

        private long __15_16ExitNum;

        public long _15_16ExitNum
        {
            get { return __15_16ExitNum; }
            set { __15_16ExitNum = value; }
        }
        private long __15_16EnterNum;

        public long _15_16EnterNum
        {
            get { return __15_16EnterNum; }
            set { __15_16EnterNum = value; }
        }

        private long __16_18ExitNum;

        public long _16_18ExitNum
        {
            get { return __16_18ExitNum; }
            set { __16_18ExitNum = value; }
        }
        private long __16_18EnterNum;

        public long _16_18EnterNum
        {
            get { return __16_18EnterNum; }
            set { __16_18EnterNum = value; }
        }
    }
}