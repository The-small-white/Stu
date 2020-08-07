using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Text;
/// <summary>
/// RequestString 的摘要说明
/// </summary>
public class RequestString
{
	public RequestString()
	{

		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 过滤标记
    /// </summary>
    /// <param name="NoHTML">包括HTML，脚本，数据库关键字，特殊字符的源码 </param>
    /// <returns>已经去除标记后的文字</returns>
    public static string NoHTML(string Htmlstring)
    {
        if (Htmlstring == null)
        {
            return "";
        }
        else
        {
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([/r/n])[/s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "/xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "/xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "/xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "/xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(/d+);", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "xp_cmdshell", "", RegexOptions.IgnoreCase);

            //删除与数据库相关的词
            Htmlstring = Regex.Replace(Htmlstring, "select", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "insert", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "delete from", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "count''", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "drop table", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "truncate", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "asc", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "mid", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "char", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "xp_cmdshell", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "exec master", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "net localgroup administrators", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "and", "", RegexOptions.IgnoreCase);

            return Htmlstring;

        }

    }


    /// <summary>
    /// 返回html编码的字符串
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public static string GetHtmlEncodeString(string request)
    {
        return HttpUtility.HtmlEncode(request);
    }

    /// <summary>
    /// 判断是否含有非法字符
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public static string FilterStr(string source)
    {
        Regex reg = new Regex(@"[^\u4E00-\u9FA50-9a-zA-Z_\.]$");
        string result = reg.Replace(source,"");
        //string result = source.Replace(@"[^\u4E00-\u9FA50-9a-zA-Z_\.]{4,20}", "");
        return result;
    }

    public static string EncodeString(string info)
    {
        string key = "Iuz(%&hj7c89H$yuCYBTYR#YZCT5&fvHUFCy76*h%(HiFJ$lhj!y6&(*jkP87jW7";
        SymmetricMethod symmetricMethod = new SymmetricMethod(key);
        return System.Web.HttpUtility.UrlEncode(symmetricMethod.Encrypto(info));
    }

    public static string DecrypString(string info)
    {
        string key = "Iuz(%&hj7c89H$yuCYBTYR#YZCT5&fvHUFCy76*h%(HiFJ$lhj!y6&(*jkP87jW7";
        SymmetricMethod symmetricMethod = new SymmetricMethod(key);
        string str = "";
        try
        {
            str = symmetricMethod.Decrypto(info);
        }
        catch
        {
            str = "错误!";
        }
        
        return str;
    }

    public static string Escape(string s)
    {
        StringBuilder sb = new StringBuilder();
        byte[] ba = System.Text.Encoding.Unicode.GetBytes(s);
        for (int i = 0; i < ba.Length; i += 2)
        {    /**///// BE SURE 2's 
            sb.Append("%u");
            sb.Append(ba[i + 1].ToString("X2"));
            sb.Append(ba[i].ToString("X2"));
        }
        return sb.ToString();

    }
}
