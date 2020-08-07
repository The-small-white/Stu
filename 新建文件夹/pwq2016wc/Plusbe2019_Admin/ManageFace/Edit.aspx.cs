using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System;
using System.IO;
using System.Web.Script.Serialization;

public partial class Plusbe2019_ManageUserinfo_Edit : AdminPage
{
    protected Face news = new Face();
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = GetstringKey("action");
        if (action != "save")
        {
            if (!string.IsNullOrEmpty(this.Request["iD"]))
            {

                int _iD = Convert.ToInt32(this.Request["iD"]);
                Face condition = new Face();
                condition.ID = _iD;
                news = TableOperate<Face>.GetRowData(condition);
                iD.Value = Convert.ToString(news.ID);

            }
            else
            {
                iD.Value = "0";
            }
            DataBind();


        }
        else
        {
            Result result = new Result();
            string logbrief = "";
            Face newChannelNews = new Face();
            newChannelNews.ID = 0;
            newChannelNews.AutoForm(this.Page);
            newChannelNews.ExhibitionID = AdminMethod.ExhibitionID;
            
            int _iD;
            if (!string.IsNullOrEmpty(this.Request["iD"]))
            {
                _iD = Convert.ToInt32(this.Request["iD"]);
                TableOperate<Face>.Update(newChannelNews);
                result.msg = "编辑成功，等待返回列表";
                logbrief = "管理员:【" + AdminMethod.AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "编辑了人脸用户";
            }
            else
            {
                newChannelNews.AddTime = DateTime.Now;
                
                
                newChannelNews.OrderID = CloudSQL.GetNowTime();
                _iD = TableOperate<Face>.InsertReturnID(newChannelNews);
                result.msg = "添加成功，等待返回列表";
                logbrief = "管理员:【" + AdminMethod.AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "添加了人脸的用户";
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