using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System;
using System.Web.Script.Serialization;
using System.Collections.Generic;
public partial class Plusbe2019_Admin_AreaManageDevice_Edit : AdminPage
{
    protected Device news = new Device();
    protected List<Projector> projectorList;
    protected int TypeID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Projector projectorV = new Projector();
        Projector projectorC = new Projector();
        projectorList = TableOperate<Projector>.Select(projectorV, projectorC);
        TypeID = GetIntKey("tid");
        string action = GetstringKey("action");
        if (action != "save")
        {
            if (!string.IsNullOrEmpty(this.Request["iD"]))
            {
                
                int _iD = Convert.ToInt32(this.Request["iD"]);
                Device condition = new Device();
                condition.ID = _iD;
                news = TableOperate<Device>.GetRowData(condition);              
                iD.Value = Convert.ToString(news.ID);
                State.Value = Convert.ToString(news.State);
                deviceType.Value = Convert.ToString(news.DeviceType);
                charType.Value = Convert.ToString(news.CharType);
                reCharType.Value = Convert.ToString(news.ReCharType);
                protocol.Value = Convert.ToString(news.Protocol);
            }
            DataBind();


        }
        else
        {
            Result result = new Result();
            string logbrief = "";
            Device newChannelNews = new Device();
            newChannelNews.ID = 0;
            newChannelNews.AutoForm(this.Page);
            string Title = newChannelNews.Name;
            int _iD;
            if (!string.IsNullOrEmpty(this.Request["iD"]))
            {
                _iD = Convert.ToInt32(this.Request["iD"]);
                TableOperate<Device>.Update(newChannelNews);
                result.msg = "编辑成功，等待返回列表";
                logbrief = "管理员:【" + AdminMethod.AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "编辑了为【" + Title + "】的设备";

            }
            else
            {
                newChannelNews.AddTime = DateTime.Now;
                newChannelNews.AddID = AdminMethod.AdminID;
                newChannelNews.ExhibitionID = AdminMethod.ExhibitionID;
                newChannelNews.OrderID = CloudSQL.GetNowTime();
                _iD = TableOperate<Device>.InsertReturnID(newChannelNews);
                result.msg = "添加成功，等待返回列表";
                logbrief = "管理员:【" + AdminMethod.AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "添加了为【" + Title + "】的设备";
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
    protected string SetSelected(string value, string oldvalue)
    {
        return value == oldvalue ? "selected=\"selected\"" : "";
    }

}