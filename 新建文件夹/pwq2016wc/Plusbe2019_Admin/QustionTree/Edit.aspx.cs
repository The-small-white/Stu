using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

public partial class Plusbe2019_Admin_TableManage_Edit : AdminPage
{
    protected QuestionType news = new QuestionType();
    protected List<QuestionType> m_ExhibitionList;
    protected string m_nowChild = "true";
    protected void Page_Load(object sender, EventArgs e)
    {
        m_ExhibitionList = QusetionProvider.SelectAll();
        string action = GetstringKey("action");
        if (action != "save")
        {
            if (!string.IsNullOrEmpty(this.Request["iD"]))
            {
                
                int _iD = Convert.ToInt32(this.Request["iD"]);
                QuestionType condition = new QuestionType();
                condition.ID = _iD;
                news = TableOperate<QuestionType>.GetRowData(condition);
                m_nowChild = Convert.ToString(news.Child).ToLower();
                iD.Value = Convert.ToString(news.ID);
            }
            DataBind();


        }
        else
        {
            Result result = new Result();
            string logbrief = "";
            QuestionType newChannelNews = new QuestionType();
            newChannelNews.ID = 0;
            newChannelNews.AutoForm(this.Page);
            string title = newChannelNews.Name;
            int _iD;
            if (!string.IsNullOrEmpty(this.Request["iD"]))
            {
                _iD = Convert.ToInt32(this.Request["iD"]);
                QusetionProvider.Update(newChannelNews);
                result.msg = "编辑成功，等待返回列表";
               
            }
            else
            {
                newChannelNews.AddTime = DateTime.Now;
                newChannelNews.AddID = AdminMethod.AdminID;
                _iD = QusetionProvider.Insert(newChannelNews);
                result.msg = "添加成功，等待返回列表"; 

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