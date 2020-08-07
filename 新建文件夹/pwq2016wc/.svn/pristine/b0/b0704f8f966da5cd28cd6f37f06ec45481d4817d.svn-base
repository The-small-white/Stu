using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

public partial class Plusbe2019_Admin_TableManage_Edit : AdminPage
{
    protected Admin_User news = new Admin_User();
    protected string disabled = "";
    protected List<Exhibition> m_ExhibitionList;
    protected int MyID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        m_ExhibitionList = ExhibitionProvider.SelectAll();
        string action = GetstringKey("action");
        if (action != "save")
        {
            if (!string.IsNullOrEmpty(this.Request["iD"]))
            {

                MyID = Convert.ToInt32(this.Request["iD"]);
                
                Admin_User condition = new Admin_User();
                if (MyID == -1)
                {
                    condition.ID = AdminMethod.AdminID;
                   
                    states.Disabled = true;
                }
                else
                {
                    condition.ID = MyID;
                }
               
                news = TableOperate<Admin_User>.GetRowData(condition);
                iD.Value = Convert.ToString(news.ID);
               
             
                states.Value = Convert.ToString(news.States);
            }
            DataBind();


        }
        else
        {
                Result result = new Result();
                string logbrief = "";
                Admin_User newChannelNews = new Admin_User();
                newChannelNews.ID = 0;
                newChannelNews.AutoForm(this.Page);
                string title = newChannelNews.Name;
               string headpic= Draw.Drawing(newChannelNews.FullName, newChannelNews.FullName + "_" + newChannelNews.Name + ".png");
               newChannelNews.HeadPic = headpic;
               string pass;
                if (!string.IsNullOrEmpty(this.Request["pass"]))
                {

                    pass = Convert.ToString(this.Request["pass"]);
                    pass = Md5JiaMi.JiaMi(pass); // md5加密
                }
                else
                {
                    pass = Convert.ToString(this.Request["oldpass"]);
                }
                newChannelNews.Pass = pass;
                int _iD;
            if (!string.IsNullOrEmpty(this.Request["iD"]))
            {
                _iD = Convert.ToInt32(this.Request["iD"]);
                TableOperate<Admin_User>.Update(newChannelNews);
                result.msg = "编辑成功，等待返回列表";       
                logbrief = "管理员:【" + AdminMethod.AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "编辑了为【" + title + "】的管理员";
            }
            else
            {
                string name = Convert.ToString(Request["name"]);
                name = RequestString.NoHTML(name);
                if (AdminMethod.IsName(name))
                {
                    result.msg = "用户已存在";
                    Response.ContentType = "text/json";
                    Response.Write(new JavaScriptSerializer().Serialize(result));
                    Response.End();
                    return;
                }
                else
                {
                    newChannelNews.AddTime = DateTime.Now;
                    newChannelNews.AddID = AdminMethod.AdminID;
                    newChannelNews.LastLoginTime = DateTime.Now;
                    _iD = TableOperate<Admin_User>.InsertReturnID(newChannelNews);
                    result.msg = "添加成功，等待返回列表";
                    logbrief = "管理员:【" + AdminMethod.AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "添加了为【" + title + "】的管理员";
                }

            }


            if (_iD > 0)
            {
                result.isOk = true;
                Lognet.AddLogin(logbrief);
          
                if ((newChannelNews.Manage != AdminMethod.AdminManages)&&AdminMethod.AdminID==newChannelNews.ID)
                {
                    AdminMethod.UpdataManage(newChannelNews.Manage);
                }
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