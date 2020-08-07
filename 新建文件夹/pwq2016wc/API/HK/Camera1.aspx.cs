using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class API_HK_Camera : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string msg = "";
        try
        {
            int EnterNum = GetSumBySql("select sum(EnterNum) from PeopleCount");


            DateTime beginDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime endDate = beginDate.AddMonths(1);
            int DayEnterNum = GetSumBySql("select sum(EnterNum) from PeopleCount where  CountTime>='" + beginDate + "' and CountTime<'" + endDate + "'");
            msg = "{\"state\":\"true\", \"EnterNum\":\""+EnterNum+ "\", \"NowMonth\":\"" + DayEnterNum + "\"}";
        }
        catch
        {
            msg = "{\"state\":\"false\", \"msg\":\"获取异常\"}";
        }
        Response.Write(msg);
       

    }
    private int GetSumBySql(string sql)
    {
        object o = SQL.ExecuteScalar(SQL.ConnectionStringProfile, CommandType.Text, sql);
        if (o == DBNull.Value) return 0;
        return Convert.ToInt32(o);
    }
}