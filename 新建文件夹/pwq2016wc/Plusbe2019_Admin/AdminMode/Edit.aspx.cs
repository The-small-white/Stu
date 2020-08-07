using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

public partial class Plusbe2019_Admin_TableManage_Edit : AdminPage
{
    protected Channel news = new Channel();
    protected List<Channel> m_ExhibitionList;
    protected string m_nowChild = "true";
    protected int pid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        m_ExhibitionList = ChannelProvider.SelectAll();
        string action = GetstringKey("action");
        pid = GetIntKey("pid");
        if (action!= "save")
        {
            if (!string.IsNullOrEmpty(this.Request["iD"]))
            {
                
                int _iD = Convert.ToInt32(this.Request["iD"]);
                Channel condition = new Channel();
                condition.ID = _iD;
                news = TableOperate<Channel>.GetRowData(condition);
                m_nowChild = Convert.ToString(news.Child).ToLower();
                iD.Value = Convert.ToString(news.ID);
            }
            DataBind();


        }
        else
        {
            Result result = new Result();
            string logbrief = "";
            Channel newChannelNews = new Channel();
            newChannelNews.ID = 0;
            newChannelNews.AutoForm(this.Page);
            string Title = newChannelNews.Name;
            int _iD;
            if (!string.IsNullOrEmpty(this.Request["iD"]))
            {
                _iD = Convert.ToInt32(this.Request["iD"]);
                ChannelProvider.Update(newChannelNews);
                result.msg = "编辑成功，等待返回列表";
                logbrief = "管理员:【" + AdminMethod.AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "编辑了为【" + Title + "】的场景模式";
            }
            else
            {
                newChannelNews.AddTime = DateTime.Now;
                newChannelNews.AddID = AdminMethod.AdminID;
                newChannelNews.ExhibitionID = AdminMethod.ExhibitionID;
                _iD = ChannelProvider.Insert(newChannelNews);
                result.msg = "添加成功，等待返回列表";
                logbrief = "管理员:【" + AdminMethod.AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "添加了为【" + Title + "】的场景模式";
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