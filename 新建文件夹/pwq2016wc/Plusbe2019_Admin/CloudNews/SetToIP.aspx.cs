using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

public partial class Plusbe2019_Admin_TableManage_Edit : AdminPage
{
    protected News news = new News();
    protected void Page_Load(object sender, EventArgs e)
    {
        int ID = 0;
        string action = GetstringKey("action");
        if (action == "save")
        {

            Result result = new Result();
            string logbrief = "";
            News newChannelNews = new News();
            int _ModeID = GetIntKey("ModeID");
            int _PCID = GetIntKey("PCID");
            ID = GetIntKey("iD");
            if (_ModeID != 0 && _PCID != 0 && ID != 0)
            {
                newChannelNews = GetShare(ID);
                newChannelNews.NoID();
                newChannelNews.AddTime = DateTime.Now;
                newChannelNews.AddID = AdminMethod.AdminID;
                newChannelNews.ExhibitionID = AdminMethod.ExhibitionID;
                newChannelNews.TypeID = 0;
                newChannelNews.IsShare = 0;
                newChannelNews.OldID = 0;
                newChannelNews.ModeID = _ModeID;
                newChannelNews.PcID = _PCID;
                newChannelNews.OrderID = CloudSQL.GetNowTime();
                int Sid = TableOperate<News>.InsertReturnID(newChannelNews);
                if (Sid > 0)
                {
                    CloudSQL.UpdataVesion(_PCID);
                    result.isOk = true;
                    result.msg = "资源调用成功！";
                    logbrief = "管理员:【" + AdminMethod.AdminFullName + "】,在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "调用了【" + newChannelNews.Title + "】资源";
                    Lognet.AddLogin(logbrief);
                    AddUsing(Sid);
                    
                }
                else
                {
                    result.msg = "资源调用失败！";
                }
            }
            Response.ContentType = "text/json";
            Response.Write(new JavaScriptSerializer().Serialize(result));
            Response.End();
        }
        else
        {
            ID = GetIntKey("iD");
            iD.Value = ID + "";
            
        }
        DataBind();
    }
    /// <summary>
    /// 资源调用
    /// </summary>
    /// <param name="ID"></param>
    protected void AddUsing(int ID)
    {
        CloudUsing condition = new CloudUsing();
        condition.NewsID = ID;
        CloudUsing cloud = TableOperate<CloudUsing>.GetRowData(condition);
        if (cloud.ID > 0)
        {
            condition.Count = cloud.Count + 1;
            TableOperate<CloudUsing>.Update(condition);
        }
        else
        {
            condition.Count = 1;
            condition.AddTime = DateTime.Now;
            TableOperate<CloudUsing>.Insert(condition);
        }
    }
    protected News GetShare(int ID)
    {
        News condition = new News();
        condition.ID = ID;
        return TableOperate<News>.GetRowData(condition);
    }
}