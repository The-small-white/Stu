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
using Dejun.DataProvider.Table;
using Dejun.DataProvider.Sql2005;
using System.Text;

/// <summary>
/// SysConfig 的摘要说明
/// </summary>
public class SysConfig 
{
    /// <summary>
    /// 页数
    /// </summary>
    public static int PAGESIZE = 10;
    public static int PAGESIZEFront = 3;
    public static int PAGESIZENEW = 20;
    public static int PathLength = 0;
    /// <summary>
    /// 是否使用url重写
    /// </summary>
    public static bool UrlRewriter = false;
    public static int PageContentSize = 2020;//内容分页，一页内容大小
    /// <summary>
    /// 管理目录
    /// </summary>
    public static string AdminPath = ApplicationPath+ "Plusbe2019_Admin/";
    public static string Inspinia = ApplicationPath+ "Plusbe2019_Admin/Inspinia/";
    public static string Hui = ApplicationPath + "Plusbe2019_Admin/Hui/";
    public static string headpicfile = AdminPath + "AdminHeadPic/";
    public static string StrSmtpServer = "smtp.sohu.com";
    public static string StrFrom = "baidaba@sohu.com";
    public static string StrFromPass = "mygoogle";
   
    public static GlobalConfig config=GetWebStates();
    public static string WebTitle = config.WebName;

    /// <summary>
    /// 下拉框是否选中
    /// </summary>
    /// <returns>相等返回"Selected",不等返回空字符串</returns>
    public static string Selected(object value, object oldValue)
    {
        string result = string.Empty;
        if (Convert.ToString(value) == Convert.ToString(oldValue))
            result = "Selected";
        return result;
    }
    public static GlobalConfig GetWebStates()
    {
        GlobalConfig config = new GlobalConfig();
        config.ID = 1;
        return TableOperate<GlobalConfig>.GetRowData(config);
    }
    public static string SetCheckedMore(string equipment, string oldvalue)
    {
        if (equipment == null) return "";
        string[] valueArr = equipment.Split(',');
        for (int i = 0; i < valueArr.Length; i++)
        {
            if (valueArr[i] == oldvalue)
            {
                return "checked";
            }
        }
        return "";
    }
    public static string SubString(string str, int leng)
    {
        if (str != "" && str != null)
        {
            if (str.Length > leng)
            {
                str = str.Substring(0, leng)+"...";
            }
            return str;
        }
        return "";
    }
    //使用C#把发表的时间改为几个月,几天前,几小时前,几分钟前,或几秒前
    //2008年03月15日 星期六 02:35
    public static string DateStringFromNow(DateTime dt)
    {
        TimeSpan span = DateTime.Now - dt;
        if (span.TotalDays > 60)
        {
            return dt.ToShortDateString();
        }
        else
        {
            if (span.TotalDays > 30)
            {
                return
                "1个月前";
            }
            else
            {
                if (span.TotalDays > 14)
                {
                    return
                    "2周前";
                }
                else
                {
                    if (span.TotalDays > 7)
                    {
                        return
                        "1周前";
                    }
                    else
                    {
                        if (span.TotalDays > 1)
                        {
                            return
                            string.Format("{0}天前", (int)Math.Floor(span.TotalDays));
                        }
                        else
                        {
                            if (span.TotalHours > 1)
                            {
                                return
                                string.Format("{0}小时前", (int)Math.Floor(span.TotalHours));
                            }
                            else
                            {
                                if (span.TotalMinutes > 1)
                                {
                                    return
                                    string.Format("{0}分钟前", (int)Math.Floor(span.TotalMinutes));
                                }
                                else
                                {
                                    if (span.TotalSeconds >= 1)
                                    {
                                        return
                                        string.Format("{0}秒前", (int)Math.Floor(span.TotalSeconds));
                                    }
                                    else
                                    {
                                        return
                                        "1秒前";
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    /// <summary>  
    /// 过滤特殊字符  
    /// </summary>  
    /// <param name="s"></param>  
    /// <returns></returns>  
    public static string String2Json(String s)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            char c = s.ToCharArray()[i];
            switch (c)
            {
                case '\"':
                    sb.Append("\\\""); break;
                case '\\':
                    sb.Append("\\\\"); break;
                case '/':
                    sb.Append("\\/"); break;
                case '\b':
                    sb.Append("\\b"); break;
                case '\f':
                    sb.Append("\\f"); break;
                case '\n':
                    sb.Append("\\n"); break;
                case '\r':
                    sb.Append("\\r"); break;
                case '\t':
                    sb.Append("\\t"); break;
                default:
                    if ((c >= 0 && c <= 31) || c == 127)//在ASCⅡ码中，第0～31号及第127号(共33个)是控制字符或通讯专用字符
                    {
                        //TODO
                    }
                    else
                    {
                        sb.Append(c);
                    }
                    break;
            }
        }
        return sb.ToString();
    }

    //C#中使用TimeSpan计算两个时间的差值
    //可以反加两个日期之间任何一个时间单位。
    private string DateDiff(DateTime DateTime1, DateTime DateTime2)
    {
        string dateDiff = null;
        TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
        TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
        TimeSpan ts = ts1.Subtract(ts2).Duration();
        dateDiff = ts.Days.ToString() + "天" + ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分钟" + ts.Seconds.ToString() + "秒";
        return dateDiff;
    }


    //说明：
    /**/
    /*1.DateTime值类型代表了一个从公元0001年1月1日0点0分0秒到公元9999年12月31日23点59分59秒之间的具体日期时刻。因此，你可以用DateTime值类型来描述任何在想象范围之内的时间。一个DateTime值代表了一个具体的时刻
    2.TimeSpan值包含了许多属性与方法，用于访问或处理一个TimeSpan值
    下面的列表涵盖了其中的一部分：
    Add：与另一个TimeSpan值相加。 
    Days:返回用天数计算的TimeSpan值。 
    Duration:获取TimeSpan的绝对值。 
    Hours:返回用小时计算的TimeSpan值 
    Milliseconds:返回用毫秒计算的TimeSpan值。 
    Minutes:返回用分钟计算的TimeSpan值。 
    Negate:返回当前实例的相反数。 
    Seconds:返回用秒计算的TimeSpan值。 
    Subtract:从中减去另一个TimeSpan值。 
    Ticks:返回TimeSpan值的tick数。 
    TotalDays:返回TimeSpan值表示的天数。 
    TotalHours:返回TimeSpan值表示的小时数。 
    TotalMilliseconds:返回TimeSpan值表示的毫秒数。 
    TotalMinutes:返回TimeSpan值表示的分钟数。 
    TotalSeconds:返回TimeSpan值表示的秒数。
    */

    /**/
    /// <summary>
    /// 日期比较
    /// </summary>
    /// <param name="today">当前日期</param>
    /// <param name="writeDate">输入日期</param>
    /// <param name="n">比较天数</param>
    /// <returns>大于天数返回true，小于返回false</returns>
    private bool CompareDate(string today, string writeDate, int n)
    {
        DateTime Today = Convert.ToDateTime(today);
        DateTime WriteDate = Convert.ToDateTime(writeDate);
        WriteDate = WriteDate.AddDays(n);
        if (Today >= WriteDate)
            return false;
        else
            return true;
    }

    /// <summary>
    /// 选择框是否选中
    /// </summary>
    /// <returns>相等返回"Checked",不等返回空字符串</returns>
    public static string Checked(object value, object oldValue)
    {
        string result = string.Empty;
        if (Convert.ToString(value) == Convert.ToString(oldValue))
            result = "Checked";
        return result;
    }
    /// <summary>
    /// 获取程序根目录
    /// </summary>
    public static string ApplicationPath
    {
        get
        {
            string path = HttpContext.Current.Request.ApplicationPath;
            if (path != "/") path = path + "/";
            return path;
        }
    }
    public string SetSelected(string value, string oldvalue)
    {
        return value == oldvalue ? "selected=\"selected\"" : "";
    }

    public string SetChecked(string value, string oldvalue)
    {
        return value == oldvalue ? "checked" : "";
    }
    public enum NewsState
    {
        回收站 =-1,
        未审核 =0,
        已审核 =1,
    }
    public enum CharTypeState
    {
        TCP = 0,
        UDP = 1,
        HTTP = 2,
    }
    public enum ProtocolState
    {
        字符串 = 0,
        十六进制 = 1,
        二进制 = 2,
    }
    public enum FileTypeState
    {
        视频 = 1,
        网址 = 2,
        PPT = 3,
        图片=4,
        SWF=8
    }
    /// <summary>
    /// Sn核对
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public static bool IsTrueSn(int ID,string Sn)
    {
        string TrueSn= Md5JiaMi.JiaMi(ID+"plusbe~!@#$%");
        if (Sn.ToLower() == TrueSn.ToLower())
        {
            return true;
        }
        return false;
    }
    public static int CheckPlayType(string file)
    {
        int m_playType = 1;
        if (file.IndexOf("|") > -1)
        {
            file = file.Split('|')[0];
        }
        string fileType = System.IO.Path.GetExtension(file).ToLower();
        if (fileType == ".mp4" || fileType == ".avi" || fileType == ".flv" || fileType == ".f4v" ||
            fileType == ".rmvb" || fileType == ".rm" || fileType == ".asf" || fileType == ".divx" ||
            fileType == ".mpg" || fileType == ".mpeg" || fileType == ".mpe" || fileType == ".wmv" ||
            fileType == ".mkv" || fileType == ".3gp" || fileType == ".mp3")
        {
            //视频
            m_playType = 1;
        }
        else if (fileType == ".html" || fileType == ".htm")
        {
            m_playType = 2;
        }
        else if (fileType == ".ppt" || fileType == ".pptx" || fileType == ".pot" || fileType == ".pps" || fileType == ".pptm" || fileType == ".ppsx")
        {
            //ppt
            m_playType = 3;
        }
        else if (file.IndexOf("http://") != -1 || file.IndexOf("https://") != -1)
        {
            m_playType = 2;
            //return;
        }
        else if (fileType == ".jpg" || fileType == ".png")
        {
            //图片 flash播放暂时不支持bmp和gif
            m_playType = 4;
        }
        else if (fileType == ".exe")
        {
            m_playType = 5;
        }
        else if (fileType == ".doc" || fileType == ".docx")
        {
            m_playType = 6;
        }
        else if (fileType == ".xls" || fileType == ".xlsx")
        {
            m_playType = 7;
        }

        else if (fileType == ".swf")
        {
            m_playType = 8;
        }
        else
        {
            //其他格式用视频
            m_playType = 1;
        }
        return m_playType;

    }

    public enum ESex
    {
        男 = 0,
        女 = 1,
        未知 = 2,
    }

    public static string GetSn(string id)
    {
        return Md5JiaMi.JiaMi(id+"plusbe~!@#$%2019");
    }

    public static string GetStr(string str, int length)
    {
        return GetSubString(str, length * 2);
    }

    public static string GetStr1(string str, int length)
    {
        return GetSubString(str, length * 2, "...");
    }

    /// <summary>
    /// 截取字符串函数
    /// </summary>
    /// <param name="Str">所要截取的字符串</param>
    /// <param name="Num">截取字符串的长度</param>
    /// <returns></returns>
    public static string GetSubString(string Str, int Num)
    {
        if (Str == null || Str == "")
            return "";
        string outstr = "";
        int n = 0;
        foreach (char ch in Str)
        {
            n += System.Text.Encoding.Default.GetByteCount(ch.ToString());
            if (n > Num)
                break;
            else
                outstr += ch;
        }
        return outstr;
    }

    public static string GetSubString(string Str, int Num, string lastStr)
    {
        if (Str == null || Str == "")
            return "";
        string outstr = "";
        int n = 0;
        foreach (char ch in Str)
        {
            n += System.Text.Encoding.Default.GetByteCount(ch.ToString());
            if (n > Num)
            {
                outstr += lastStr;

                break;
            }
            else
            {
                outstr += ch;
            }
        }
        return outstr;
    }

    public static string[] Split(string content, string splitStr)
    {
        string[] resultString = Regex.Split(content, splitStr, RegexOptions.IgnoreCase);
        return resultString;
    }

    public static string SubString(string sourceStr, string beginStr, string endStr)
    {
        int begin = sourceStr.IndexOf(beginStr);
        if (begin == -1) return "";
        int end = sourceStr.IndexOf(endStr, begin + beginStr.Length);
        if (end == -1 && end == begin + beginStr.Length) return "";

        return sourceStr.Substring(begin + beginStr.Length, end - begin - beginStr.Length);

    }
 
 
    public static string NoHTML(string Htmlstring)

//去除HTML标记
    {

        //删除脚本

        Htmlstring = Regex.Replace(Htmlstring, @"<cript[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);

        //删除HTML

        Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"&am(quot|#34);", "\"", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"&am(amp|#38);", "&am", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"&am(lt|#60);", "<", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"&am(gt|#62);", ">", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"&am(|#160);", " ", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"&am(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"&am(cent|#162);", "\xa2", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"&am(pound|#163);", "\xa3", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"&am(copy|#169);", "\xa9", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"&am#(\d+);", "", RegexOptions.IgnoreCase);

        Htmlstring.Replace("<", "");

        Htmlstring.Replace(">", "");

        Htmlstring.Replace("\r\n", "");

        Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

        return Htmlstring;

    }

}
