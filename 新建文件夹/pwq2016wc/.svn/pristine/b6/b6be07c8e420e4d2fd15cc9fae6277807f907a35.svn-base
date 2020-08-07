using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

public partial class Plusbe2019_Admin_ManageNews_Edit : AdminPage
{
    protected QuestionBank news = new QuestionBank();
    protected List<QuestionType> m_ExhibitionList;
 
    protected void Page_Load(object sender, EventArgs e)
    {
        m_ExhibitionList = QusetionProvider.SelectAll();
        string action = GetstringKey("action");
      
        if (action != "save")
        {
            if (!string.IsNullOrEmpty(this.Request["iD"]))
            {
                
                int _iD = Convert.ToInt32(this.Request["iD"]);
                QuestionBank condition = new QuestionBank();
                condition.ID = _iD;
                news = TableOperate<QuestionBank>.GetRowData(condition);
                iD.Value = Convert.ToString(news.ID);
                
            }
            DataBind();


        }
        else
        {
            Result result = new Result();
            string logbrief = "";
            QuestionBank newChannelNews = new QuestionBank();
            newChannelNews.ID = 0;
            newChannelNews.AutoForm(this.Page);
           
            string Title = newChannelNews.Title;
            int _iD;
            if (!string.IsNullOrEmpty(this.Request["iD"]))
            {
                _iD = Convert.ToInt32(this.Request["iD"]);
                TableOperate<QuestionBank>.Update(newChannelNews);
                result.msg = "编辑成功，等待返回列表";
                logbrief = "管理员:【" + AdminMethod.AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "编辑了题库【" + Title + "】";
            }
            else
            {
                newChannelNews.AddTime = DateTime.Now;
                newChannelNews.AddID = AdminMethod.AdminID;
                newChannelNews.ExhibitionID = AdminMethod.ExhibitionID;
               
                newChannelNews.OrderID = CloudSQL.GetNowTime();
                _iD = TableOperate<QuestionBank>.InsertReturnID(newChannelNews);
                result.msg = "添加成功，等待返回列表";
                logbrief = "管理员:【" + AdminMethod.AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "添加了题库【" + Title + "】";

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
    protected string GetList()
    {
        string str = "";
        if (news.Answer != null && news.Answer != "")
        {
            string[] answeArry = news.Answer.Split(',');
            string[] trueArry = news.TrueList.Split(',');
            for (int i = 0; i < answeArry.Length; i++)
            {
                str += "<div class=\"form-group\">";
                str += "<label class=\"col-sm-2 control-label\"></label>";
                str += "<div class=\"col-sm-10\">";
                str += "<div class=\"input-group m-b\">";
                str += "<span class=\"input-group-addon\">";
                str += "<input type=\"hidden\" value=\"" + trueArry[i] + "\" name=\"truelist\" />";
                str += "<input type=\"checkbox\" name=\"box\" " + Chenck(trueArry[i]) + " >正确</span > ";
                str += "<input type=\"text\" class=\"form-control required\" data-name=\"选项\" name=\"answer\" value=\"" + answeArry[i] + "\">";
                str += "<span class=\"input-group-addon\" onclick=\"del(this);\">删除</span>";
                str += "</div>";
                str += " </div>";
                str += " </div>";
            }
        }
        return str;
    }
    protected string Chenck(string states)
    {
        if (states == "1")
        {
            return "checked='checked'";
        }
        return "";
    }

}