using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Web;

public partial class Plusbe2019_Admin_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Headers.Remove("Server");
        
        GlobalConfig condition = new GlobalConfig();
        condition.ID = 1;
        GlobalConfig global = TableOperate<GlobalConfig>.GetRowData(condition);
        if (global.ID > 0)
        {
            if (global.UserIP == 1 && !AdminMethod.IsWhite())
            {
                Response.Redirect("/ErrorPage/NOIP.html");
                return;
            }
        }

        try
        {
            Result result = new Result();
           
            string action = RequestString.NoHTML(Convert.ToString(Request["action"]));
            if (action == "save")
            {
                string isCheck = Convert.ToString(HttpContext.Current.Session["isCheck"]);
                if (isCheck == "")
                {
                    Random random = new Random();
                    result.isOk = false;
                    result.msg = "请先验证验证码！！！" + random.Next(1000) ;
                }
                else
                {
                    string username = ""; string pass = "";
                    if (!string.IsNullOrEmpty(Request["username"]))
                    {
                        username = RequestString.NoHTML(Request["username"]);
                    }
                    if (!string.IsNullOrEmpty(Request["usermima"]))
                    {
                        pass = RequestString.NoHTML(Request["usermima"]);
                    }
                    if (username != "" && pass != "")
                    {
                        if (!IsLoginError())//超过三次清空验证码重新验证
                        {
                            HttpContext.Current.Session["isCheck"] = null;
                            result.isOk = false;
                            result.msg = "错误次数太多请一分钟后重试！！！";
                        }
                        else
                        {
                            bool IsSuccess = AdminMethod.VerifyPwd(username, pass);
                            if (IsSuccess)
                            {
                                HttpContext.Current.Session["isCheck"] = null;
                                HttpContext.Current.Session["LoginCount"] = null;
                                HttpContext.Current.Session["lastTime"] = null;
                                result.isOk = true;
                                result.url = "index.aspx";
                            }
                            else
                            {
                                //ClientScript.RegisterStartupScript(GetType(), "message", "<script>layer.msg('账号或密码错误！！！', { offset: 't', anim: 6});</script>");
                                //return;
                                result.isOk = false;
                                result.msg = "账号或密码错误！！！";
                                loglock();
                            }
                        }



                    }
                }

                Response.ContentType = "application/json";
                Response.Write(JsonConvert.SerializeObject(result));
                Response.End();


            }
            else if (action == "loginout")
            {
                AdminMethod.LoginOut();
                Response.Redirect("login.aspx");
            }
            else
            {
                HttpContext.Current.Session["LoginCount"] = null;
                HttpContext.Current.Session["lastTime"] = null;
                HttpContext.Current.Session["isCheck"] = null;
            }
        }
        catch (Exception ex)
        {

        }
        
       


    }
    protected void loglock()
    {
       
        if (LoginCount==-1)
        {
            HttpContext.Current.Session["LoginCount"] = 1;
            HttpContext.Current.Session["lastTime"] = DateTime.Now;

        }
        else
        {
            HttpContext.Current.Session["LoginCount"] = LoginCount + 1;
            HttpContext.Current.Session["lastTime"] = DateTime.Now;
        }
       
    }
    protected bool IsLoginError()
    {
        if (LoginCount > 3)
        {
            DateTime dt = Convert.ToDateTime(HttpContext.Current.Session["lastTime"]);
            TimeSpan ts1 = DateTime.Now-dt;
            Debug.WriteLine(LoginCount+"---" +ts1.Seconds);
            if (ts1.TotalSeconds < 60)
            {
                return false;
            }
            else
            {
                HttpContext.Current.Session["LoginCount"] = null;
                HttpContext.Current.Session["lastTime"] = null;
                HttpContext.Current.Session["isCheck"] = null;
            }
        }
        return true;
        
    }
    public static int LoginCount
    {
        get
        {
            string loginCount = Convert.ToString(HttpContext.Current.Session["LoginCount"]);
            if (string.IsNullOrEmpty(loginCount))
            {
                return -1;
            }
            else
            {
                int adminLevel = (Convert.ToInt32(loginCount));
                return adminLevel;
            }

        }

    }
}