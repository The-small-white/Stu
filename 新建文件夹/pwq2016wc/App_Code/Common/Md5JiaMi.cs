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
/// Md5加密
/// </summary>
public class Md5JiaMi
{
    public Md5JiaMi()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public static string JiaMi(string str)
    {
        String hai;
        hai = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
        return hai;
    }
}