using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

public partial class Plusbe2019_Admin_ManageNews_Edit : AdminPage
{
    protected ChannelNews news = new ChannelNews();
    protected List<Channel> m_ExhibitionList;
    protected int PCID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        m_ExhibitionList = ChannelProvider.SelectAll();
        string action = GetstringKey("action");
        PCID = GetIntKey("pcid");
        if (action != "save")
        {
            if (!string.IsNullOrEmpty(this.Request["iD"]))
            {
                
                int _iD = Convert.ToInt32(this.Request["iD"]);
                ChannelNews condition = new ChannelNews();
                condition.ID = _iD;
                news = TableOperate<ChannelNews>.GetRowData(condition);
                iD.Value = Convert.ToString(news.ID);
               
            }
            DataBind();


        }
        else
        {
            Result result = new Result();
            string logbrief = "";
            ChannelNews newChannelNews = new ChannelNews();
            newChannelNews.ID = 0;
            newChannelNews.AutoForm(this.Page);
           
            string Title = newChannelNews.Title;
            int _iD;
            if (!string.IsNullOrEmpty(this.Request["iD"]))
            {
                _iD = Convert.ToInt32(this.Request["iD"]);
                TableOperate<ChannelNews>.Update(newChannelNews);
                result.msg = "编辑成功，等待返回列表";
                //logbrief = "管理员:【" + AdminMethod.AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "编辑了资源【" + Title + "】";
            }
            else
            {
                newChannelNews.AddTime = DateTime.Now;
                newChannelNews.AddID = AdminMethod.AdminID;
                newChannelNews.ExhibitionID = AdminMethod.ExhibitionID;
                newChannelNews.OrderID = CloudSQL.GetNowTime();
                _iD = TableOperate<ChannelNews>.InsertReturnID(newChannelNews);
                result.msg = "添加成功，等待返回列表";
                //logbrief = "管理员:【" + AdminMethod.AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "添加了资源【" + Title + "】";

            }
            
            if (_iD > 0)
            {
                result.isOk = true;
                Lognet.AddLogin(logbrief);
               


            }
            else
            {
                result.msg = "操作失败";
            }
            Response.ContentType = "text/json";
            Response.Write(new JavaScriptSerializer().Serialize(result));
            Response.End();
        }
        DataBind();
    }

}