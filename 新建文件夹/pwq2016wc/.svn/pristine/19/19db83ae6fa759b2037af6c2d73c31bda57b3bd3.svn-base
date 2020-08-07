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
/// function 的摘要说明
/// </summary>
public class IndexFunction :Page
{
	public IndexFunction()
	{
 
    }
		//
		// TODO：保持超链接的合法性
		//
       public string SafeRequest(string str)
        {
            str = str.Trim();
            str = str.Replace("'", "''");
            str = str.Replace(";", "；");
            str = str.Replace("select", "Ｓelect");
            return str;
        }
        //
        // TODO：保持超链接的合法性
        //
    public string qString(string s)
    { 
        if (System.Web.HttpContext.Current.Request.QueryString[s] != null)
        {
            return System.Web.HttpContext.Current.Request.QueryString[s].ToString();
        }
        return string.Empty;
    }




	
}

