using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

public partial class Plusbe2019_Admin_TableManage_Edit : AdminPage
{
    protected Pclist news = new Pclist();
    protected string disabled = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = GetstringKey("action");
        if (action != "save")
        {
            if (!string.IsNullOrEmpty(this.Request["iD"]))
            {
                
                int _iD = Convert.ToInt32(this.Request["iD"]);
                
                Pclist condition = new Pclist();
                condition.ID = _iD;
                news = TableOperate<Pclist>.GetRowData(condition);
                iD.Value = Convert.ToString(news.ID);

            }
            DataBind();


        }
        else
        {
            Result result = new Result();
            

                string logbrief = "";
                Pclist newChannelNews = new Pclist();
                newChannelNews.ID = 0;
                newChannelNews.AutoForm(this.Page);
                string Title = newChannelNews.Title;
            int _iD;
                if (!string.IsNullOrEmpty(this.Request["iD"]))
                {
                    _iD = Convert.ToInt32(this.Request["iD"]);
                    TableOperate<Pclist>.Update(newChannelNews);
                    result.msg = "编辑成功，等待返回列表";
                    logbrief = "管理员:【" + AdminMethod.AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "编辑了为【" + Title + "】的主机";
                }
                else
                {

                    newChannelNews.ExhibitionID = AdminMethod.ExhibitionID;
                    newChannelNews.AddTime = DateTime.Now;
                    newChannelNews.AddID = AdminMethod.AdminID;
                    newChannelNews.LastTime = DateTime.Now;
                    newChannelNews.State = 1;
                    newChannelNews.Version = 0;
                    _iD = TableOperate<Pclist>.InsertReturnID(newChannelNews);
                    result.msg = "添加成功，等待返回列表";
                    logbrief = "管理员:【" + AdminMethod.AdminFullName + "】,在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "添加了为【" + Title + "】的主机";
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