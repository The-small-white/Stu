using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// UsersMethod 的摘要说明
/// </summary>
public class UsersMethod
{
    Page page;
    public UsersMethod(Page page)
	{
        this.page = page;//读取调用的页面
	}
    public int UserID
    {
        get
        {
            HttpCookie cookie = page.Request.Cookies["userid"];
            if (cookie == null)
            {
                return -1;
            }
            else
            {
                if (cookie.Value == "") return -1;
                return Convert.ToInt32(cookie.Value);
            }
        }
        set
        {
            HttpCookie cookie = new HttpCookie("userid");
            //设定此cookies值
            //设定cookie的生命周期，在这里定义为一个小时
            DateTime expiresTime = DateTime.Now.AddHours(1);
            cookie.Expires = expiresTime;
            cookie.Value = value + "";

            //加入此cookie
            page.Response.Cookies.Add(cookie);
        }
    }

    public string UserName
    {
        get
        {
            HttpCookie cookie = page.Request.Cookies["username"];
            if (cookie == null)
            {
                return "";
            }
            else
            {
                return cookie.Value;
            }
        }
        set
        {
            HttpCookie cookie = new HttpCookie("username");
            //设定此cookies值
            //设定cookie的生命周期，在这里定义为一个小时
            DateTime expiresTime = DateTime.Now.AddHours(1);
            cookie.Expires = expiresTime;
            cookie.Value = value;

            //加入此cookie
            page.Response.Cookies.Add(cookie);
        }
    }
    public int CityID
    {
        get
        {
            HttpCookie cookie = page.Request.Cookies["CityID"];
            if (cookie == null)
            {
                return -1;
            }
            else
            {
                if (cookie.Value == "") return -1;
                return Convert.ToInt32(cookie.Value);
            }
        }
        set
        {
            HttpCookie cookie = new HttpCookie("CityID");
            //设定此cookies值
            //设定cookie的生命周期，在这里定义为一个小时
            DateTime expiresTime = DateTime.Now.AddHours(1);
            cookie.Expires = expiresTime;
            cookie.Value = value + "";

            //加入此cookie
            page.Response.Cookies.Add(cookie);
        }
    }
    public void Clear()
    {
        HttpCookie cookie = new HttpCookie("username");
        //设定此cookies值
        //设定cookie的生命周期，在这里定义为一个小时
        DateTime expiresTime = new DateTime(1900, 1, 1, 0, 0, 0, 0);
        cookie.Expires = expiresTime;
        cookie.Value = "";
        //加入此cookie
        page.Response.Cookies.Add(cookie);
    }
}
