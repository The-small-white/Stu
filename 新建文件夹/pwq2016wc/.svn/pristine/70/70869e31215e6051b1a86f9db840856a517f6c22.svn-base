using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

public partial class Plusbe2019_Admin_TableManage_Edit : AdminPage
{
    protected Exhibition news = new Exhibition();
    protected List<Exhibition> m_ExhibitionList;
    protected string m_nowChild = "true";
    protected void Page_Load(object sender, EventArgs e)
    {
        m_ExhibitionList = ExhibitionProvider.SelectAll();
        string action = GetstringKey("action");
        if (action != "save")
        {
            if (!string.IsNullOrEmpty(this.Request["iD"]))
            {
                
                int _iD = Convert.ToInt32(this.Request["iD"]);
                Exhibition condition = new Exhibition();
                condition.ID = _iD;
                news = TableOperate<Exhibition>.GetRowData(condition);
                m_nowChild = Convert.ToString(news.Child).ToLower();
                iD.Value = Convert.ToString(news.ID);
            }
            DataBind();


        }
        else
        {
            Result result = new Result();
            string logbrief = "";
            Exhibition newChannelNews = new Exhibition();
            newChannelNews.ID = 0;
            newChannelNews.AutoForm(this.Page);
            string title = newChannelNews.Name;
            int _iD;
            if (!string.IsNullOrEmpty(this.Request["iD"]))
            {
                _iD = Convert.ToInt32(this.Request["iD"]);
                ExhibitionProvider.Update(newChannelNews);
                result.msg = "编辑成功，等待返回列表";
                logbrief = "管理员:【" + AdminMethod.AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "编辑了为【" + title + "】的展厅架构";
              
            }
            else
            {
                newChannelNews.AddTime = DateTime.Now;
                newChannelNews.AddID = AdminMethod.AdminID;
                _iD = ExhibitionProvider.Insert(newChannelNews);
                result.msg = "添加成功，等待返回列表"; 
                logbrief = "管理员:【" + AdminMethod.AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "添加了为【" + title + "】的展厅架构";
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