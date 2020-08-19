using CodeBuild.Model;
using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class ibeaconapi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string act = "";
        if (!string.IsNullOrEmpty(this.Request["act"]))
        {
            act = Convert.ToString(Request["act"]);
        }
        string json = "";
        if (act == "getcount")
        {
            UserVistCount condition = new UserVistCount();
            condition.ID = 1;
            UserVistCount value = TableOperate<UserVistCount>.GetRowData(condition);
          
             int nowcount = 0;
            if (value.AddTime.Date == DateTime.Now.Date)
            {
                nowcount = value.NowDayCount;
            }
            else
            {
                nowcount = 0;
            }
                json += "{\"ID\":" + value.ID + ", \"AllCount\":\"" + value.Count + "\", \"NowDayCount\":\"" + nowcount + "\", \"StopTime\":\"" + value.StopTime + "\"}";
        }
        else if (act == "now")
        {
            #region MyRegion
            // json = "{\"list\":[";
            // List<IBeaconGateWay> list = TableOperate<IBeaconGateWay>.Select();
            // View_iBeaconNow condition = new View_iBeaconNow();
            // View_iBeaconNow value = new View_iBeaconNow();
            //// condition.AddConditon(" and DateDiff(dd,LastTime,getdate())=0");//今天
            // condition.AddConditon("and UserID!=0");//排除非绑定
            // List<View_iBeaconNow> ibeaconlist = TableOperate<View_iBeaconNow>.Select(value, condition);
            // for (int i = 0; i < list.Count; i++)
            // {
            //     json += "{\"ID\":" + list[i].ID + ", \"name\":\"" + list[i].DevName + "\", \"Count\":\"" + GetCount(ibeaconlist, list[i].ID) + "\"},";
            // }
            // json = json.Trim(',');
            // json += "]}";
            //  json = StortJson(json); 
            #endregion
            json = "{\"list\":[";
            List<IBeaconGateWay> list = TableOperate<IBeaconGateWay>.Select();
            for (int i = 0; i < list.Count; i++)
            {
                json += "{\"ID\":" + list[i].ID + ", \"name\":\"" + list[i].DevName + "\", \"Count\":\"" + list[i].X + "\"},";
            }
            json = json.Trim(',');
            json += "]}";
        }
        else if (act == "data")
        {
             json = "{\"list\":[";
            List<IBeaconGateWay> list = TableOperate<IBeaconGateWay>.Select();
            IBeaconData condition = new IBeaconData();
            IBeaconData value = new IBeaconData();
            if (!string.IsNullOrEmpty(Request["now"]))
            {
                condition.AddConditon(" and DateDiff(dd,LastTime,getdate())=0");//今天
            }
            if (!string.IsNullOrEmpty(Request["userid"]))//获取用户的
            {
                int userID = Convert.ToInt32(Request["userid"]);
                condition.UserID = userID;
            }
            condition.AddConditon("and UserID!=0");//排除非绑定
            List<IBeaconData> ibeaconlist = TableOperate<IBeaconData>.Select(value, condition);
            for (int i = 0; i < list.Count; i++)
            {
                json += "{\"ID\":" + list[i].ID + ", \"name\":\"" + list[i].DevName + "\", \"stopTime\":\"" + GetStopTime(ibeaconlist, list[i].ID) + "\", \"Count\":\"" + list[i].X + "\"},";
            }
            json = json.Trim(',');
            json += "]}";
        }
        else if (act == "rest")
        {
            string sql = "UPDATE IBeaconDev SET UserID = 0 WHERE ID >0";
            TableOperate<IBeaconDev>.Execute(sql);
        }
       
        

        Response.Write(json);
    }
    public string StortJson(string json)
    {
        var dic = JsonConvert.DeserializeObject<SortedDictionary<string, object>>(json);
        SortedDictionary<string, object> Count = new SortedDictionary<string, object>(dic);
        Count.OrderBy(m => m.Key);//升序 把Key换成Value 就是对Value进行排序
                                      //keyValues.OrderByDescending(m => m.Key);//降序
        return JsonConvert.SerializeObject(Count);
    }
         protected int GetStopTime(List<IBeaconData> list, int GetWayID)
    {
        int count = 0 ;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].GateWayID == GetWayID)
            {
                count += list[i].StopTime;
            }
        }
        if (count == 0)
        {
            count = GetDcount(GetWayID);
        }
        return count;
    }
    protected int GetDcount(int ID)
    {
        IBeaconGateWay condition = new IBeaconGateWay();
        condition.ID = ID;
        IBeaconGateWay way = TableOperate<IBeaconGateWay>.GetRowData(condition);
        if (way.ID > 0)
        {
            return way.H;
        }
        return 1;
    }
    protected int GetCount(List<View_iBeaconNow> list, int GetWayID)
    {
        int count = 0;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].GateWayID == GetWayID)
            {
                count += 1;
            }
        }
        return count;
    }
    protected string GetNews(int ChannelID)
    {
        string jsonstr = "[";
        ChannelNews value = new ChannelNews();
        ChannelNews condition = new ChannelNews();
        condition.ChannelID = ChannelID;
        List<ChannelNews> list = TableOperate<ChannelNews>.Select(value,condition,0,"order by id desc");
        for (int i = 0; i < list.Count; i++)
        {
            jsonstr += "{\"ID\":" + list[i].ID + ", \"TypeID\":\"" + list[i].TypeID + "\", \"Title\":\"" + list[i].Title + "\", \"Brief\":\"" + list[i].Brief + "\", \"Files\":\"UploadFiles/" + list[i].Files + "\", \"AddTime\":\"" + list[i].AddTime + "\"},";
        }
        jsonstr = jsonstr.Trim(',');
        jsonstr += "]";
        return jsonstr;
    }
}