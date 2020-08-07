<%@ WebHandler Language="C#" Class="APIPeopleCount" %>

using System;
using System.Web;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System.Data;
using System.Web.Script.Serialization;

public class APIPeopleCount : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/json";

        Result result = new Result();

        List<Camera> cameraList = TableOperate<Camera>.Select();
        List<TempPeopleCount> tempPeopleCountList = new List<TempPeopleCount>();

        foreach (Camera item in cameraList)
        {
            TempPeopleCount temp = new TempPeopleCount();
            temp.CameraId = item.ID;
            temp.CameraMac = item.MacAddress;
            temp.CameraName = item.Name;
            temp.CameraIp = item.IPAddress;

            temp.YearEnterNum = GetCountPeopleNum(item.ID, "year", "EnterNum");
            temp.MonthEnterNum = GetCountPeopleNum(item.ID, "month", "EnterNum");
            temp.WeekEnterNum = GetCountPeopleNum(item.ID, "week", "EnterNum");
            temp.DayEnterNum = GetCountPeopleNum(item.ID, "day", "EnterNum");

            temp.YearExitNum = GetCountPeopleNum(item.ID, "year", "ExitNum");
            temp.MonthExitNum = GetCountPeopleNum(item.ID, "month", "ExitNum");
            temp.WeekExitNum = GetCountPeopleNum(item.ID, "week", "ExitNum");
            temp.DayExitNum = GetCountPeopleNum(item.ID, "day", "ExitNum");

            //temp.TotalEnterNum = GetTotalNum("EnterNum");
            //temp.TotalExitNum = GetTotalNum("ExitNum");
            //temp.Hour_24 = GetSumFromHower(item.ID);
            //temp.Week_7 = GetSumFromWeek(item.ID);

            tempPeopleCountList.Add(temp);
        }

        if (tempPeopleCountList.Count > 0)
        {
            result.isOk = true;
            result.msg = "人流统计";
            result.url = "";
            result.obj = tempPeopleCountList;
        }
        else
        {
            result.msg = "无数据";
        }

        JavaScriptSerializer js = new JavaScriptSerializer();
        context.Response.Write(js.Serialize(result));
    }

    private int GetCountPeopleNum(int cameraId, string dateType, string column)
    {
        DateTime date = DateTime.Now;
        string sql = string.Empty;

        DateTime beginDate = new DateTime();
        DateTime endDate = new DateTime(); ;

        switch (dateType)
        {
            case "year":
                beginDate = new DateTime(date.Year, 1, 1);
                endDate = beginDate.AddYears(1);
                break;

            case "month":
                beginDate = new DateTime(date.Year, date.Month, 1);
                endDate = beginDate.AddMonths(1);
                break;

            case "day":
                beginDate = new DateTime(date.Year, date.Month, date.Day);
                endDate = beginDate.AddDays(1);
                break;

            case "week":
                date = date.AddDays(-7);
                beginDate = new DateTime(date.Year, date.Month, date.Day);
                endDate = beginDate.AddDays(8);
                break;

            default: return 0;
        }

        sql = "select sum(" + column + ") from PeopleCount where CameraID=" + cameraId + " and CountTime>='" + beginDate + "' and CountTime<'" + endDate + "'";
        return GetSumBySql(sql);
    }

    /// <summary>
    /// 获取从此时开始包括现在的过去24小时的出入人数详情
    /// </summary>
    /// <param name="cameraId">摄像头ID</param>
    /// <returns></returns>
    private List<DateValue> GetSumFromHower(int cameraId)
    {
        List<DateValue> list = new List<DateValue>();
        DateTime now = DateTime.Now;

        for (int i = 23; i > -1; i--)
        {
            DateTime beginDate, endDate;
            beginDate = new DateTime(now.AddHours(-i).Year, now.AddHours(-i).Month, now.AddHours(-i).Day, now.AddHours(-i).Hour, 0, 0);
            endDate = beginDate.AddHours(1);

            DateValue temp = new DateValue();
            temp.Date = beginDate.ToString("yyyy-MM-dd HH:mm:ss");
            temp.EnterNum = GetSumBySql("select sum(EnterNum) from PeopleCount where CameraID=" + cameraId + " and CountTime>='" + beginDate + "' and CountTime<'" + endDate + "'");
            temp.ExitNum = GetSumBySql("select sum(ExitNum) from PeopleCount where CameraID=" + cameraId + " and CountTime>='" + beginDate + "' and CountTime<'" + endDate + "'");
            list.Add(temp);
        }

        return list;
    }

    /// <summary>
    /// 获取从今天开始包括今天的过去7天的出入人数详情
    /// </summary>
    /// <param name="cameraId">摄像头ID</param>
    /// <returns></returns>
    private List<DateValue> GetSumFromWeek(int cameraId)
    {
        List<DateValue> list = new List<DateValue>();
        DateTime now = DateTime.Now;

        for (int i = 6; i > -1; i--)
        {
            DateTime beginDate, endDate;
            beginDate = new DateTime(now.AddDays(-i).Year, now.AddDays(-i).Month, now.AddDays(-i).Day);
            endDate = beginDate.AddDays(1);

            DateValue temp = new DateValue();
            temp.Date = beginDate.ToString("yyyy-MM-dd");
            temp.EnterNum = GetSumBySql("select sum(EnterNum) from PeopleCount where CameraID=" + cameraId + " and CountTime>='" + beginDate + "' and CountTime<'" + endDate + "'");
            temp.ExitNum = GetSumBySql("select sum(ExitNum) from PeopleCount where CameraID=" + cameraId + " and CountTime>='" + beginDate + "' and CountTime<'" + endDate + "'");

            list.Add(temp);

            //中恒独有开始
            //下面这个if嵌到是中恒独有的.是在后台设置了开始参观之后,会把今天的所有数据保存至缓存,然后在这里输出的时候减去
            //为了不影响其他数据,把这个减去后的数据保存在一个不存在的日期中(比今天大一天的时间)
            //表示今天
            if (beginDate.Date == DateTime.Now.Date)
            {
                //表示当前是有参观人员的
                if (Convert.ToString(HttpRuntime.Cache["peopleCount-isStart"]) == "true")
                {
                    int enterNum = 0;
                    int exitNum = 0;
                    int.TryParse(Convert.ToString(HttpRuntime.Cache["peopleCount-enterNum"]), out enterNum);
                    int.TryParse(Convert.ToString(HttpRuntime.Cache["peopleCount-exitNum"]), out exitNum);

                    DateValue t = new DateValue();
                    t.Date = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                    t.EnterNum = temp.EnterNum - enterNum;
                    t.ExitNum = temp.ExitNum - exitNum;
                    list.Add(t);
                }
            }
            //中恒独有到此结束
        }
        return list;
    }

    private int GetSumBySql(string sql)
    {
        object o = SQL.ExecuteScalar(SQL.ConnectionStringProfile, CommandType.Text, sql);
        if (o == DBNull.Value) return 0;
        return Convert.ToInt32(o);
    }

    private int GetTotalNum(string column)
    {
        string sql = "select sum(" + column + ") from PeopleCount";
        return GetSumBySql(sql);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    private class DateValue
    {
        private string date;

        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        private int enterNum;

        public int EnterNum
        {
            get { return enterNum; }
            set { enterNum = value; }
        }

        private int exitNum;

        public int ExitNum
        {
            get { return exitNum; }
            set { exitNum = value; }
        }
    }

    private class TempPeopleCount
    {
        private int cameraId;
        public int CameraId
        {
            get { return cameraId; }
            set { cameraId = value; }
        }

        private string cameraName;
        public string CameraName
        {
            get { return cameraName; }
            set { cameraName = value; }
        }

        private string cameraIp;
        public string CameraIp
        {
            get { return cameraIp; }
            set { cameraIp = value; }
        }

        private string cameraMac;
        public string CameraMac
        {
            get { return cameraMac; }
            set { cameraMac = value; }
        }

        private int yearEnterNum;
        public int YearEnterNum
        {
            get { return yearEnterNum; }
            set { yearEnterNum = value; }
        }

        private int monthEnterNum;
        public int MonthEnterNum
        {
            get { return monthEnterNum; }
            set { monthEnterNum = value; }
        }

        private int weekEnterNum;
        public int WeekEnterNum
        {
            get { return weekEnterNum; }
            set { weekEnterNum = value; }
        }

        private int weekExitNum;
        public int WeekExitNum
        {
            get { return weekExitNum; }
            set { weekExitNum = value; }
        }

        private int dayEnterNum;
        public int DayEnterNum
        {
            get { return dayEnterNum; }
            set { dayEnterNum = value; }
        }

        private int yearExitNum;
        public int YearExitNum
        {
            get { return yearExitNum; }
            set { yearExitNum = value; }
        }

        private int monthExitNum;
        public int MonthExitNum
        {
            get { return monthExitNum; }
            set { monthExitNum = value; }
        }

        private int dayExitNum;
        public int DayExitNum
        {
            get { return dayExitNum; }
            set { dayExitNum = value; }
        }

        private List<DateValue> hour_24;
        public List<DateValue> Hour_24
        {
            get { return hour_24; }
            set { hour_24 = value; }
        }

        private List<DateValue> week_7;
        public List<DateValue> Week_7
        {
            get { return week_7; }
            set { week_7 = value; }
        }

        private int totalExitNum;
        public int TotalExitNum
        {
            get { return totalExitNum; }
            set { totalExitNum = value; }
        }

        private int totalEnterNum;
        public int TotalEnterNum
        {
            get { return totalEnterNum; }
            set { totalEnterNum = value; }
        }
    }
}
