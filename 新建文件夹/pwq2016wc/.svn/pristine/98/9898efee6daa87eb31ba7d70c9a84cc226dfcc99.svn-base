using System;
using System.Collections.Generic;
using System.Web;
using System.IO;


/// <summary>
/// Download 的摘要说明
/// </summary>
public class Download
{
    public Download()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// 下载文件虚拟路径
    /// </summary>
    /// <param name="filePath">被下载的文件的虚拟路径</param>
    /// <param name="fileName">下载后呈现的文件名</param>
    /// <returns></returns>
    public static bool DownloadUrl(string urlPath, string fileName)
    {
        try
        {
            FileStream fileStream = new FileStream(HttpContext.Current.Server.MapPath(urlPath), FileMode.Open);
            if (fileStream.Length > int.MaxValue)
            {
                return false;
            }

            byte[] bytes = new byte[(int)fileStream.Length];
            fileStream.Read(bytes, 0, bytes.Length);
            fileStream.Close();

            // 通知浏览器下载而不是打开,在响应头中加上Content-Disposition , attachment表示以附件形式下载
            HttpContext.Current.Response.ContentType = "application/octet-stream"; ;
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName));
            HttpContext.Current.Response.BinaryWrite(bytes);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();

            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// 下载文件,绝对路径
    /// </summary>
    /// <param name="urlPath">被下载的文件的绝对路径</param>
    /// <param name="fileName">下载后呈现的文件名</param>
    /// <returns></returns>
    public static bool DownloadMapurl(string filePath, string fileName)
    {
        try
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            if (fileStream.Length > int.MaxValue)
            {
                return false;
            }

            byte[] bytes = new byte[(int)fileStream.Length];
            fileStream.Read(bytes, 0, bytes.Length);
            fileStream.Close();

            // 通知浏览器下载而不是打开,在响应头中加上Content-Disposition , attachment表示以附件形式下载
            HttpContext.Current.Response.ContentType = "application/octet-stream"; ;
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName));
            HttpContext.Current.Response.BinaryWrite(bytes);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();

            return true;
        }
        catch
        {
            return false;
        }
    }
}