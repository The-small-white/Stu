using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;

public partial class U3dFiles : System.Web.UI.Page
{
    string FileJson = "";
    string ChannelJson = "";
    int Version = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(Request["pid"]))
            {
                int Pid = Convert.ToInt32(Request["pid"]);
                ChannelJson = GetChannelJson(Pid);
            }
            if (!string.IsNullOrEmpty(Request["ip"]))
            {
                string IP = Convert.ToString(Request["ip"]);
                Pclist condition = new Pclist();
                condition.IP = IP;
                Pclist pc = TableOperate<Pclist>.GetRowData(condition);
                if (pc.ID > 0)
                {
                    Update(pc);
                    Version = pc.Version;
                    List<News> list = NewsList(pc.ID);
                    for (int i = 0; i < list.Count; i++)
                    {
                        string File = PicSwitch(list[i].Files, list[i].FileType);

                        FileJson += "{\"Title\": \"" + list[i].Title + "\",\"ID\": " + list[i].ID + ",\"File\": \"" + File + "\",\"Pic\": \"" + NullPic(list[i].Pic) + "\",\"Brief1\": \"" + Null(list[i].Brief1) + "\",\"Brief2\": \"" + Null(list[i].Brief2) +
                                "\",\"Word\": \"" + Null(list[i].Brief) + "\",\"Json\": " + DellNull(list[i].JsonStr) + ",\"Tag\": \"" + list[i].ModeID + "\",\"ChannlID\": \"" + list[i].ChannelID +
                                "\",\"Isjz\": " + list[i].Isjz + ",\"FileType\": " + list[i].FileType + ",\"Ispingbao\": " + list[i].IsPingBao + ",\"LastTime\": \"" + list[i].AddTime + "\"},";
                    }
                    FileJson = FileJson.Trim(',');
                }

            }
            string Json = "{\"state\":\"true\", \"Channellist\":[" + ChannelJson + "]," + "\"NowVersion\": " + Version + ",\"list\": [" + FileJson + "]}";
            //Json = SysConfig.String2Json(Json);
            Response.Write(Json); return;
        }
        catch(Exception ex)
        {
            string error = "{\"state\":\"false\", \"msg\":\"请求失败"+ex.ToString()+"\"}";
            Response.Write(error); return;
        }

    }


    /// <summary>
    /// 获取PID栏目
    /// </summary>
    /// <param name="Pid"></param>
    /// <returns></returns>
    protected string GetChannelJson(int Pid)
    {
        string json = "";
        List<ModeChannel> list1 = ModeChannelProvider.GetMyID(Pid);
        List<ModeChannel> list = ModeChannelProvider.SelectByParentID(Pid);
        for (int i = 0; i < list1.Count; i++)
        {
            json += "{\"ID\":" + list1[i].ID + ", \"Name\":\"" + list1[i].Name +"\", \"Brief\":\"" + Null(list1[i].Brief) + "\", \"OrderID\":\"" + list1[i].OrderID + "\", \"IsChild\":\"" + list1[i].Child.ToString() + "\", \"ParentID\":\"" + list1[i].ParentID + "\", \"Depth\":\"" + list1[i].Depth + "\", \"RootID\":\"" + list1[i].RootID + "\",\"News\":" + GetNews(list1[i].ID) + "},";
        }
        for (int i = 0; i < list.Count; i++)
        {
            json += "{\"ID\":" + list[i].ID + ", \"Name\":\"" + list[i].Name  +"\", \"Brief\":\"" + Null(list[i].Brief) +"\", \"OrderID\":\"" + list[i].OrderID + "\", \"IsChild\":\"" + list[i].Child.ToString()+ "\", \"ParentID\":\"" + list[i].ParentID + "\", \"Depth\":\"" + list[i].Depth + "\", \"RootID\":\"" + list[i].RootID + "\",\"News\":" + GetNews(list[i].ID) + "},";
        }
        json = json.Trim(',');
      
        return json;
    }
    protected string GetNews(int ChannelID)
    {
        string jsonstr = "[";
        ChannelNews value = new ChannelNews();
        ChannelNews condition = new ChannelNews();
        condition.ChannelID = ChannelID;
        List<ChannelNews> list = TableOperate<ChannelNews>.Select(value, condition, 0, "order by OrderID asc");
        for (int i = 0; i < list.Count; i++)
        {
            jsonstr += "{\"ID\":" + list[i].ID + ", \"TypeID\":\"" + list[i].TypeID + "\", \"Title\":\"" + list[i].Title + "\", \"Brief\":\"" + Null(list[i].Brief) + "\", \"Files\":\"" + GetFiles(list[i].Files) + "\", \"AddTime\":\"" + list[i].AddTime + "\"},";
        }
        jsonstr = jsonstr.Trim(',');
        jsonstr += "]";
        return jsonstr;
    }    protected string GetFiles(string Files)
    {
        string jsonstr = "";
        string[] list = Files.Split('|');
        for (int i = 0; i < list.Length; i++)
        {
            jsonstr += "UploadFiles/"+list[i]+"|";
        }
        jsonstr = jsonstr.Trim('|');
        return jsonstr;
    }

    protected string NullPic(string str)
    {
        if (str != null&&str!="")
        {
            str = "UploadFiles/"+str;

            str = str.Replace(" ", "");
        }
        else
        {
            str = "";
        }
        return str;
    }
    protected string Null(string str)
    {
        if (str != null)
        {
            //str = SysConfig.String2Json(str);
            str = str.Replace("\r", "").Replace("\n", "");
            str = str.Replace(" ", "");
            str = str.Replace("\"","\\\"");
        }
        else
        {
            str = "";
        }
        return str;
    }
    protected string DellNull(string str)
    {
        str = str.Replace(" ", "");
        if (str == null || str == "")
        {

            str = "{}";


        }
        return str;
    }
    protected string PicSwitch(string File, int FileType)
    {
        string files = "";
        if (FileType != 2)
        {

            if (File.IndexOf(@":\") > -1)
            {
                files = File;
            }
            else
            {
                string[] filearry = File.Split('|');
                if (filearry.Length > 0)
                {
                    for (int i = 0; i < filearry.Length; i++)
                    {

                        files += "UploadFiles/" + filearry[i] + "|";

                    }
                    files = files.TrimEnd('|');
                }
                else
                {
                    files = File;
                }
            }
        }
        else
        {
            files = File;
        }

        files = files.Replace("\\", "/");

        return files;

    }
    protected List<News> NewsList(int PCID)
    {
        News condition = new News();
        condition.PcID = PCID;
        condition.TypeID = 0;
        condition.State = 1;
        News value = new News();
        List<News> list = TableOperate<News>.Select(value, condition, 0, "order by  OrderID asc");
        return list;
    }
    protected void Update(Pclist pC_Channel)
    {
        pC_Channel.LastTime = DateTime.Now;
        TableOperate<Pclist>.Update(pC_Channel);
    }
}