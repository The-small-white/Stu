using Dejun.DataProvider.Table;
using Dejun.DataProvider.Sql2005;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class FileJson : System.Web.UI.Page
{
    string Json = "false";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["ip"]))
        {
            string IP = Convert.ToString(Request["ip"]);
            Pclist condition = new Pclist();
            condition.IP = IP;
            Pclist pc = TableOperate<Pclist>.GetRowData(condition);
            if (pc.ID > 0)
            {
                Update(pc);
                if (!string.IsNullOrEmpty(Request["v"]))
                {
                    int version = Convert.ToInt32(Request["v"]);
                    if (pc.Version != version)
                    {
                        Json = "{\"NowVersion\": "+pc.Version+ ",\"list\": [";
                        List<News> list = NewsList(pc.ID);
                        for (int i = 0; i < list.Count; i++)
                        {
                            string File = PicSwitch(list[i].Files,list[i].FileType);
                            
                            Json += "{\"Title\": \""+list[i].Title+ "\",\"Id\": "+list[i].ID+",\"File\": \""+ File +
                                    "\",\"Word\": \""+list[i].PicWord+"\",\"Json\": "+ DellNull(list[i].JsonStr)+",\"Tag\": \""+list[i].ModeID+
                                    "\",\"Isjz\": "+list[i].Isjz+ ",\"FileType\": " + list[i].FileType + ",\"Ispingbao\": " +list[i].IsPingBao+"},";
                        }
                        Json = Json.Trim(',');
                        Json += "]}";

                    }
                }
            }
           
        }
        Response.Write(Json.Replace(" ",""));
    }
    protected string DellNull(string str)
    {
        str = str.Replace(" ","");
        if (str == null || str == "")
        {

            str = "{}";
            
            
        }
        return str;
    }
    protected string PicSwitch(string File,int  FileType)
    {
        string files = "";
        if (FileType!=2)
        {
            
            if (File.IndexOf(@":\")>-1)
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
        List<News> list = TableOperate<News>.Select(value,condition,0, "order by  OrderID asc");
        return list;
    }
    protected void Update(Pclist pC_Channel)
    {
            pC_Channel.LastTime = DateTime.Now;
            TableOperate<Pclist>.Update(pC_Channel); 
    }
}