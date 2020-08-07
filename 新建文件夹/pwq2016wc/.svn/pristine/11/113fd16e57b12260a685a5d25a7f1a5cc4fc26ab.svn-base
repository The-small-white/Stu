using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System;
using System.Web.Script.Serialization;

public partial class Plusbe2019_Admin_TableManageReserveDate_Edit : AdminPage
{
    protected ReserveDate news = new ReserveDate();
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = GetstringKey("action");
        if (action != "save")
        {
            if (!string.IsNullOrEmpty(this.Request["iD"]))
            {
                
                int _iD = Convert.ToInt32(this.Request["iD"]);
                ReserveDate condition = new ReserveDate();
                condition.ID = _iD;
                news = TableOperate<ReserveDate>.GetRowData(condition);
                iD.Value = Convert.ToString(news.ID);
            }
            DataBind();


        }
        else
        {
            Result result = new Result();
            string logbrief = "";
            ReserveDate newChannelNews = new ReserveDate();
            newChannelNews.ID = 0;
            newChannelNews.AutoForm(this.Page);
            string Title = newChannelNews.Date;
            int _iD;
            if (!string.IsNullOrEmpty(this.Request["iD"]))
            {
                _iD = Convert.ToInt32(this.Request["iD"]);
                TableOperate<ReserveDate>.Update(newChannelNews);
                result.msg = "编辑成功，等待返回列表";
                logbrief = "管理员:【" + AdminMethod.AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "编辑了为【" + Title + "】的预约时间";
            }
            else
            {
                newChannelNews.AddTime = DateTime.Now;
                newChannelNews.AddID = AdminMethod.AdminID;
                newChannelNews.ExhibitionID = AdminMethod.ExhibitionID;
                newChannelNews.OrderID = CloudSQL.GetNowTime();
                _iD = TableOperate<ReserveDate>.InsertReturnID(newChannelNews);
                result.msg = "添加成功，等待返回列表";
                logbrief = "管理员:【" + AdminMethod.AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "添加了为【" + Title + "】的预约时间";
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