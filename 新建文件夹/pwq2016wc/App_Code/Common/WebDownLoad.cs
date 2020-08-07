using System;
using System.Web;
using System.IO;

/// <summary>
/// 以文件方式下载类
/// </summary>
public class WebDownLoad
{
    /// <summary>
    /// 物理路径下载(文件名直接为原文件的文件名)
    /// </summary>
    /// <param name="filePath">物理路径</param>
    public static void Download(string filePath)
    {
        StartDown(filePath, "");
    }

    /// <summary>
    /// 内存流下载
    /// </summary>
    /// <param name="stream">内存流</param>
    /// <param name="name">下载的文件名,需要写上扩展名</param>
    public static void Download(MemoryStream stream, string name)
    {
        StartDown(stream, name);
    }

    /// <summary>
    /// 物理路径下载
    /// </summary>
    /// <param name="filePath">物理路径</param>
    /// <param name="name">下载后显示的文件名称</param>
    public static void Download(string filePath, string name)
    {
        StartDown(filePath, name);
    }

    /// <summary>
    /// 虚拟路径下载(文件名直接为原文件的文件名)
    /// </summary>
    /// <param name="urlPath">虚拟路径</param>
    public static void DownloadVirtual(string urlPath)
    {
        StartDown(HttpContext.Current.Server.MapPath(urlPath), "");
    }

    /// <summary>
    /// 虚拟路径下载
    /// </summary>
    /// <param name="urlPath">虚拟路径</param>
    /// <param name="name">下载后显示的文件名称</param>
    public static void DownloadVirtual(string urlPath, string name)
    {
        StartDown(HttpContext.Current.Server.MapPath(urlPath), name);
    }

    /// <summary>
    /// 下载文件
    /// </summary>
    /// <param name="filePath">物理路径</param>
    /// <param name="name">下载的文件名</param>
    private static void StartDown(string filePath, string name)
    {
        // 以字符流的方式下载文件  
        FileStream fileStream = new FileStream(filePath, FileMode.Open);
        // 根据int的最大值转换后，能下载的最大文件为刚好2G，超过2G的不能使用此方法
        byte[] bytes = new byte[(int)fileStream.Length];
        fileStream.Read(bytes, 0, bytes.Length);
        fileStream.Close();
        HttpContext.Current.Response.ContentType = "application/octet-stream";

        // 通知浏览器下载而不是打开  //在响应头中加上Content-Disposition , attachment表示以附件形式下载
        if (string.IsNullOrEmpty(name)) name = Path.GetFileName(filePath);
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + name + Path.GetExtension(filePath));
        HttpContext.Current.Response.BinaryWrite(bytes);
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
    }

    /// <summary>
    /// 以内存流方式下载
    /// </summary>
    /// <param name="stream">内存流</param>
    /// <param name="name">下载的文件名,需要写上扩展名</param>
    private static void StartDown(MemoryStream stream,string name)
    {
        HttpContext.Current.Response.ContentType = "application/octet-stream";

        // 通知浏览器下载而不是打开  //在响应头中加上Content-Disposition , attachment表示以附件形式下载
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + name );
        HttpContext.Current.Response.BinaryWrite(stream.ToArray());
        HttpContext.Current.Response.Flush();
        HttpContext.Current.Response.End();
    }
}