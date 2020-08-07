using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;

public partial class Plusbe2019_Admin_ManageNews_Share : AdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = GetstringKey("action");
        int ID = GetIntKey("id");
        int States = GetIntKey("states");
        Result result = new Result();
        JavaScriptSerializer js = new JavaScriptSerializer();
        if (action == "share")
        {
            News condition = new News();
            condition.ID = ID;
            News news = TableOperate<News>.GetRowData(condition);
            if (news.ID > 0)
            {
                int id = 0;
                if (States == 1)//分享
                {
                    if (news.IsShare == 1)
                    {
                        result.msg = "该资源已分享过！";
                    }
                    else
                    {
                        id = Insert(news);
                        condition.IsShare = 1;
                        result.isOk = true;
                        result.msg = "分享成功";
                        string logbrief = "管理员:【" + AdminMethod.AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "分享了资源【" + news.Title + "】";
                        Lognet.AddLogin(logbrief);

                    }

                }
                else//取消分享
                {
                    if (news.IsShare == 1)
                    {
                        id = DeleteShare(news.ID);
                        condition.IsShare = 0;
                        result.isOk = true;
                        result.msg = "取消成功！";
                        string logbrief = "管理员:【" + AdminMethod.AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "取消分享资源【" + news.Title + "】";
                        Lognet.AddLogin(logbrief);
                    }
                    else
                    {
                        result.msg = "该文件还未分享！";
                    }
                }
                if (id > 0)
                {
                    condition.ID = news.ID;
                    TableOperate<News>.Update(condition);

                }
                else
                {
                    result.isOk = false;

                }

            }
        }
        else if (action == "shenhe")
        {
            News condition = new News();
            condition.ID = ID;
            News news = TableOperate<News>.GetRowData(condition);
            if (news.ID > 0)
            {
                if (news.State == States)
                {
                    result.isOk = false;
                    if (States == 1)
                    {
                        result.msg = "该资源已是展示状态！";
                    }
                    else
                    {
                        result.msg = "该资源已是停用状态！";
                    }
                }
                else
                {
                    condition.State = States;
                    condition.ID = news.ID;
                    int id= TableOperate<News>.Update(condition);
                    if (id > 0)
                    {
                        result.msg = "操作成功！";
                        result.isOk = true;
                    }

                }
               
            }
        }
        Response.ContentType = "text/json";
        Response.Write(js.Serialize(result));
        Response.End();

    }
    /// <summary>
    /// 分享到资源池
    /// </summary>
    /// <param name="news"></param>
    /// <returns></returns>
    protected int Insert(News news)
    {
        if (news.IsShare == 1)
        {
            return 0;
        }
        //public void NoID()
        //{
        //    iD_initialized = false;
        //}
        News newNews = new News();
        newNews = news;
        newNews.NoID();
        newNews.ShareTime = DateTime.Now;
        newNews.TypeID = 1;
        newNews.AddID = AdminMethod.AdminID;
        newNews.OldID = news.ID;
        newNews.OrderID = CloudSQL.GetNowTime();
        int _ID = TableOperate<News>.InsertReturnID(newNews);
        return _ID;
    }
    /// <summary>
    /// 删除分享的文件
    /// </summary>
    /// <param name="_ID"></param>
    /// <returns></returns>
    protected int DeleteShare(int _ID)
    {
        News condition = new News();
        condition.OldID = _ID;
        condition.TypeID = 1;
        News news = TableOperate<News>.GetRowData(condition);
        if (news.ID > 0)
        {
           return TableOperate<News>.Delete(condition);
        }
        return 0;
    }
}