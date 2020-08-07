using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Dejun.DataProvider.Table;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;
/// <summary>
/// fun 的摘要说明
/// </summary>
public class fun
{
	public fun()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static string tosql(string sSource)
    {
        return sSource.Replace("'","");
    }
    public static string Left(string sSource, int iLength)
    {
        return sSource.Substring(0, iLength > sSource.Length ? sSource.Length : iLength);
    }
    /// <summary>
    /// encrypting string
    /// </summary>
    /// <param name="Password">encrypting string</param>
    /// <param name="Format">format,0 is SHA1,1 is MD5</param>
    /// <returns></returns>
    public static string Encrypt(string Password, int Format)
    {
        string str = "";
        switch (Format)
        {
            case 0:
                str = FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "SHA1");
                break;
            case 1:
                str = FormsAuthentication.HashPasswordForStoringInConfigFile(Password, "MD5");
                break;
        }
        return str;
    }
    public static string GenerateMix(int CodeLength)
    {
        int number;
        StringBuilder result = new StringBuilder();

        System.Random random = new Random();

        for (int i = 0; i < CodeLength; i++)
        {
            number = random.Next();

            if (number % 2 == 0)
                result.Append(((char)('0' + (char)(number % 10))).ToString());
            else
                result.Append(((char)('A' + (char)(number % 26))).ToString());

        }
        return result.ToString();
    }
    public static string pic(string pic, string moren,int b)
    {
        if (pic == "" || pic == null)
        {
            pic = moren;
        }
        else
        {
            if (b == 0)
            {
                pic = SysConfig.ApplicationPath + "UploadImg/" + pic.Split('|')[0];
            }
            else
            {
                pic = SysConfig.ApplicationPath + "MiniUploadImg/" + pic.Split('|')[0];
            }
        }
        return pic;
    }
    public string GenerateMixNo(int CodeLength)
    {
        int number;
        StringBuilder result = new StringBuilder();

        System.Random random = new Random();

        for (int i = 0; i < CodeLength; i++)
        {
            number = random.Next();
            if ((i+1) % 6 == 0 && i!=0 && i!=CodeLength)
                result.Append("-");
            else
            result.Append(((char)('0' + (char)(number % 10))).ToString());
        }
        return result.ToString();
    }

    public enum FileType
    {
        视频 = 1,
        链接 = 2,
        ppt = 3,
        图片 = 4,
        客户端 = 5,
        文档 = 6,
        表格 = 7,
        其它 =-1

    }
    public enum State
    {
        未审核=0,
        已审核=1,
        已共享=2,
        已拒绝=-1,
    }
    /// <summary>
    /// 获取上传文件的类型,1-视频,2-网页,3-ppt,4-图片,5程序 6 文档 7 表格
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public static int GetType(string file)
    {
        if (file == ""||file==null)
        {
            return -1;
        }
        file = file.Split('|')[0];

        int m_playType = 1;
        string fileType = System.IO.Path.GetExtension(file).ToLower();

        if (fileType == ".mp4" || fileType == ".avi" || fileType == ".flv" || fileType == ".f4v" ||
            fileType == ".rmvb" || fileType == ".rm" || fileType == ".asf" || fileType == ".divx" ||
            fileType == ".mpg" || fileType == ".mpeg" || fileType == ".mpe" || fileType == ".wmv" ||
            fileType == ".mkv" || fileType == ".3gp")
        {
            //视频
            m_playType = 1;
        }
        else if (fileType == ".ppt" || fileType == ".pptx" || fileType == ".pot" || fileType == ".pps" || fileType == ".pptm")
        {
            //ppt
            m_playType = 3;
        }
        else if (fileType == ".html" || fileType == ".swf" || fileType == ".htm")
        {
            m_playType = 2;
        }
        else if (file.IndexOf("http://") != -1 || file.IndexOf("https://") != -1)
        {
            m_playType = 2;

        }
        else if (fileType == ".jpg" || fileType == ".png" || fileType == ".bmp" || fileType == ".gif")
        {
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

        else
        {
            m_playType = -1;
        }
        return m_playType;
    }
    public static string CreateValidateNumber(int length)
    {
        int[] randMembers = new int[length];
        int[] validateNums = new int[length];
        string validateNumberStr = "";
        //生成起始序列值
        int seekSeek = unchecked((int)DateTime.Now.Ticks);
        Random seekRand = new Random(seekSeek);
        int beginSeek = (int)seekRand.Next(0, Int32.MaxValue - length * 10000);
        int[] seeks = new int[length];
        for (int i = 0; i < length; i++)
        {
            beginSeek += 10000;
            seeks[i] = beginSeek;
        }
        //生成随机数字
        for (int i = 0; i < length; i++)
        {
            Random rand = new Random(seeks[i]);
            int pownum = 1 * (int)Math.Pow(10, length);
            randMembers[i] = rand.Next(pownum, Int32.MaxValue);
        }
        //抽取随机数字
        for (int i = 0; i < length; i++)
        {
            string numStr = randMembers[i].ToString();
            int numLength = numStr.Length;
            Random rand = new Random();
            int numPosition = rand.Next(0, numLength - 1);
            validateNums[i] = Int32.Parse(numStr.Substring(numPosition, 1));
        }
        //生成验证码
        for (int i = 0; i < length; i++)
        {
            validateNumberStr += validateNums[i].ToString();
        }
        return validateNumberStr;
    }
    /// <summary>
    /// 根据当前Url获取网页的文件名，不带路径和参数
    /// </summary>
    /// <param name="url">Url地址</param>
    /// <returns>返回文件名</returns>
    static public string GetUrlFileName(string url)
    {
        string[] s = url.Split('/');
        string filename = s[s.Length - 1];
        return filename.Split('?')[0];
    }

  

}
