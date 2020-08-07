using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

public partial class Plusbe2019_Admin_ManageNews_Edit : AdminPage
{
    protected News news = new News();
    protected List<Channel> m_ExhibitionList;
    protected List<ModeChannel> m_ExhibitionList1;
    protected int PCID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        m_ExhibitionList = ChannelProvider.SelectAll();
        m_ExhibitionList1 = ModeChannelProvider.SelectAll();
        string action = GetstringKey("action");
        PCID = GetIntKey("pcid");
        if (action != "save")
        {
            if (!string.IsNullOrEmpty(this.Request["iD"]))
            {
                
                int _iD = Convert.ToInt32(this.Request["iD"]);
                News condition = new News();
                condition.ID = _iD;
                news = TableOperate<News>.GetRowData(condition);
                iD.Value = Convert.ToString(news.ID);
                state.Value = Convert.ToString(news.State);
            }
            DataBind();


        }
        else
        {
            Result result = new Result();
            string logbrief = "";
            try
            {
               
            News newChannelNews = new News();
            newChannelNews.ID = 0;
            newChannelNews.AutoForm(this.Page);
            newChannelNews.FileType = SysConfig.CheckPlayType(newChannelNews.Files);
            if (newChannelNews.JsonStr == "" || newChannelNews.JsonStr == null)
            {
                newChannelNews.JsonStr = "{\"type\": \"google\",\"data\": \"\"}";
            }
           
                string oldFiles = GetstringKey("oldFiles");
                if (oldFiles != newChannelNews.Files && newChannelNews.FileType == 4)
                {
                    string piczip = CloudSQL.GetPicZip(newChannelNews.Files, news.Files1);
                    newChannelNews.Files1 = piczip;
                }
           
           
            string Title = newChannelNews.Title;
            int _iD;
            if (!string.IsNullOrEmpty(this.Request["iD"]))
            {
                _iD = Convert.ToInt32(this.Request["iD"]);
                newChannelNews.AddTime = DateTime.Now;
                TableOperate<News>.Update(newChannelNews);
                result.msg = "编辑成功，等待返回列表";
                logbrief = "管理员:【" + AdminMethod.AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "编辑了资源【" + Title + "】";
            }
            else
            {
                newChannelNews.AddTime = DateTime.Now;
                newChannelNews.AddID = AdminMethod.AdminID;
                newChannelNews.ExhibitionID = AdminMethod.ExhibitionID;
                newChannelNews.TypeID = 0;
                newChannelNews.IsShare = 0;
                newChannelNews.OldID = 0;
                newChannelNews.OrderID = CloudSQL.GetNowTime();
                _iD = TableOperate<News>.InsertReturnID(newChannelNews);
                result.msg = "添加成功，等待返回列表";
                logbrief = "管理员:【" + AdminMethod.AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "添加了资源【" + Title + "】";

            }
            
            if (_iD > 0)
            {
                result.isOk = true;
                Lognet.AddLogin(logbrief);
                if (newChannelNews.State == 1)
                {
                    CloudSQL.UpdataVesion(newChannelNews.PcID);
                }


            }
            else
            {
                result.msg = "操作失败";
            }
            }
            catch(Exception ex)
            {
                result.isOk = false;
                result.msg = "操作失败";
            }
            Response.ContentType = "text/json";
            Response.Write(new JavaScriptSerializer().Serialize(result));
            Response.End();
        }
        DataBind();
    }

}