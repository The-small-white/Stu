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
/// 数据库输入检查
/// </summary>
public class CheckInput
{
	public CheckInput()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 获取数字型合法的in的字符串
    /// </summary>
    /// <param name="checkshop"></param>
    /// <returns></returns>
    public static string GetInStr(string checkshop)
    {
        string str = "";
        string[] arr = checkshop.Split(',');
        for (int i = 0; i < arr.Length; i++)
        {
            str += Convert.ToInt32(arr[i]) + ",";
        }

        str = str.Trim(',');
        return str;
    }


    /// <summary>
    /// 获取字符型合法的in的字符串
    /// </summary>
    /// <param name="checkshop"></param>
    /// <returns></returns>
    public static string GetStrInStr(string checkshop)
    {
        if (string.IsNullOrEmpty(checkshop)) return "";
        checkshop = checkshop.Replace("'", "");
        checkshop = checkshop.Trim(',');
        checkshop = checkshop.Replace(",", "','");
        checkshop = "'" + checkshop + "'";
        return checkshop;
    }
}
