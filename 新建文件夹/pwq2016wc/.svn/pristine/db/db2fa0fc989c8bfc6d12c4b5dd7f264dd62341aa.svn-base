using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;


public partial class channellist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int rootID = 0;
        Channel v = new Channel();
        Channel condition = new Channel();
        if (!string.IsNullOrEmpty(this.Request["rootID"]))
        {
            rootID = Convert.ToInt32(Request["rootID"]);
        }
        string sn = RequestString.NoHTML(Convert.ToString(this.Request["sn"]));
       
        List<Channel> list = ChannelProvider.SelectByRootID(rootID);
        string json = "{\"list\":[";
        for (int i = 0; i < list.Count; i++)
        {
            json += "{\"ID\":" + list[i].ID + ", \"name\":\"" + list[i].Name + "\", \"ParentID\":\"" + list[i].ParentID + "\", \"Depth\":\"" + list[i].Depth + "\", \"RootID\":\"" + list[i].RootID + "\",\"News\":"+GetNews(list[i].ID)+"},";
        }
        json = json.Trim(',');
        json += "]}";
        Response.Write(json);
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