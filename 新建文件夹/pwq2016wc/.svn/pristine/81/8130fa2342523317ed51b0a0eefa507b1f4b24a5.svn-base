using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dejun.DataProvider.Table;
using Dejun.DataProvider.Sql2005;
using System.Text;
using System.Text.RegularExpressions;

public partial class VersionXml : System.Web.UI.Page
{
    protected int GroupID = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.Request["ip"]))
        {
            string ip = this.Request["ip"];
            int version = Convert.ToInt32(this.Request["v"]);//文件版本控制
            
            Pclist condition = new Pclist();
            condition.IP = ip;
            Pclist channel = TableOperate<Pclist>.GetRowData(condition);

            if ((channel.Version == version || channel.ID == 0))
            {
                Response.Write("false");
                return;

            }
            else
            {
                Response.Write("<?xml version=\"1.0\"?>\r\n<Config xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n");
              
                View_News conditionNews = new View_News();
                View_News vNews = new View_News();
                conditionNews.PcID = channel.ID;
                conditionNews.State = 1;
                List<View_News> m_newsList = TableOperate<View_News>.Select(vNews, conditionNews, 0, " order by  OrderID asc ");
                string str = "<FileList>\r\n";

                for (int i = 0; i < m_newsList.Count; i++)
                {
                    string files = m_newsList[i].Files;
        
                    string item = "<NetFile>\r\n";
                    item += "<ID>" + m_newsList[i].ID + "</ID>\r\n";
                    item += "<Title>" + Del(m_newsList[i].Title) + "</Title>\r\n";
                    item += "<File>" + Del(files) + "</File>\r\n";
                    item += "<Word>" + Del(m_newsList[i].PicWord) + "</Word>\r\n";
                    item += "<Tag>" + m_newsList[i].ModeID + "</Tag>\r\n";
                    item += "<FileType>" + m_newsList[i].FileType + "</FileType>\r\n";
                    item += "<ISrh>false</ISrh>\r\n";
                    item += "<IsJz>false</IsJz>\r\n";
                    item += "<Bejson>" + Del(m_newsList[i].JsonStr) + "</Bejson>\r\n";
                    item += "</NetFile>\r\n";
                    str += item;
                }
                str += "</FileList>\r\n";

                Response.Write("<NeedUpdate>true</NeedUpdate>\r\n");
                Response.Write("<NowVersion>" + channel.Version + "</NowVersion>\r\n");
                Response.Write(str);
                Response.Write("</Config>");
            }
        }
        else
        {
            Response.Write("false");
 

        }
    }
    protected string Del(string msg)
    {
        if (msg != null && msg != "")
        {
            msg = "<![CDATA[" + msg.Replace(" ", "") + "]]>";
        }
        else
        {
            msg="";
        }
        return msg;
    }
}