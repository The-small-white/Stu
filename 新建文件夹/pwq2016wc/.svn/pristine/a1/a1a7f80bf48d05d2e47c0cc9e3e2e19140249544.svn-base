using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

public partial class Plusbe2019_Admin_TableManage_Edit : AdminPage
{
    protected SpeechSend news = new SpeechSend();
    protected List<Channel> m_ExhibitionList;
    protected int SpeechID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        m_ExhibitionList = ChannelProvider.SelectAll();
        string action = GetstringKey("action");
        SpeechID = GetIntKey("SpeechID");
        if (action != "save")
        {
            if (!string.IsNullOrEmpty(this.Request["iD"]))
            {
                
                int _iD = Convert.ToInt32(this.Request["iD"]);
                SpeechSend condition = new SpeechSend();
                condition.ID = _iD;
                news = TableOperate<SpeechSend>.GetRowData(condition);
                iD.Value = Convert.ToString(news.ID);
                CharType.Value = news.CharType + "";
                Protocol.Value = news.Protocol + "";
               
            }
            DataBind();


        }
        else
        {
            Result result = new Result();
            string logbrief = "";
            SpeechSend newChannelNews = new SpeechSend();
            newChannelNews.ID = 0;
            newChannelNews.AutoForm(this.Page);
            string Title = newChannelNews.Title;
            int _iD;
            if (!string.IsNullOrEmpty(this.Request["iD"]))
            {
                _iD = Convert.ToInt32(this.Request["iD"]);
                TableOperate<SpeechSend>.Update(newChannelNews);
                result.msg = "编辑成功，等待返回列表";
                logbrief = "管理员:【" + AdminMethod.AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "编辑了为【" + Title + "】的语音指令";
            }
            else
            {
                newChannelNews.AddTime = DateTime.Now;
                newChannelNews.AddID = AdminMethod.AdminID;
     
                _iD = TableOperate<SpeechSend>.InsertReturnID(newChannelNews);
                result.msg = "添加成功，等待返回列表";
                logbrief = "管理员:【" + AdminMethod.AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "添加了为【" + Title + "】的语音指令";
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