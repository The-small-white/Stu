using System;
using System.IO;
using System.Net;

/// <summary>
/// 发送Get/Post命令
/// </summary>
public static class HttpHelp
{
    #region Get方法

    /// <summary>
    /// 发送Get请求,默认text/plain
    /// </summary>
    /// <param name="url">url地址(包括参数)</param>
    /// <returns></returns>
    public static string Get(string url)
    {
        return Get(url, "text/plain", 60000, "utf-8");
    }

    /// <summary>
    /// 发送Get请求
    /// </summary>
    /// <param name="url">url地址(包括参数)</param>
    /// <param name="contentType">文本类型(常用:text/plain  multipart/form-data  application/json  text/xml  application/x-www-form-urlencoded)</param>
    /// <returns>响应内容</returns>
    public static string Get(string url, string contentType)
    {
        return Get(url, contentType, 60000, "");
    }

    /// <summary>
    /// 发送Get请求
    /// </summary>
    /// <param name="url">url地址(包括参数)</param>    
    /// <param name="contentType">文本类型(常用:text/plain  multipart/form-data  application/json  text/xml  application/x-www-form-urlencoded)</param>
    /// <param name="timeout">超时时间(单位毫秒)</param>
    /// <returns>响应内容</returns>
    public static string Get(string url, string contentType, int timeout)
    {
        return Get(url, contentType, timeout, "");
    }

    /// <summary>
    /// 发送Get请求
    /// </summary>
    /// <param name="url">url地址(包括参数)</param>    
    /// <param name="contentType">文本类型(常用:text/plain  multipart/form-data  application/json  text/xml  application/x-www-form-urlencoded)</param>
    /// <param name="encode">编码类型(例:utf-8)</param>
    /// <param name="timeout">超时时间(单位毫秒)</param>
    /// <returns>响应内容</returns>
    public static string Get(string url, string contentType, int timeout, string encode)
    {
        HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
        if (!string.IsNullOrEmpty(encode))
            request.ContentType = contentType + ";charset=" + encode;
        else
            request.ContentType = contentType;

        request.Method = "GET";
        request.Timeout = timeout;

        return ReadResponse(request);
    }

    /// <summary>
    /// 发送Get请求并返回响应流,默认text/plain
    /// </summary>
    /// <param name="url">url地址(包括参数)</param>
    /// <returns></returns>
    public static Stream GetResponseStream(string url)
    {
        return GetResponseStream(url, "text/plain", 60000, "");
    }

    /// <summary>
    /// 发送Get请求并返回响应流
    /// </summary>
    /// <param name="url">url地址(包括参数)</param>
    /// <param name="contentType">文本类型(常用:text/plain  multipart/form-data  application/json  text/xml  application/x-www-form-urlencoded)</param>
    /// <returns>响应内容</returns>
    public static Stream GetResponseStream(string url, string contentType)
    {
        return GetResponseStream(url, contentType, 60000, "");
    }

    /// <summary>
    /// 发送Get请求并返回响应流
    /// </summary>
    /// <param name="url">url地址(包括参数)</param>    
    /// <param name="contentType">文本类型(常用:text/plain  multipart/form-data  application/json  text/xml  application/x-www-form-urlencoded)</param>
    /// <param name="timeout">超时时间(单位毫秒)</param>
    /// <returns>响应内容</returns>
    public static Stream GetResponseStream(string url, string contentType, int timeout)
    {
        return GetResponseStream(url, contentType, timeout, "");
    }

    /// <summary>
    /// 发送Get请求,并返回响应流
    /// </summary>
    /// <param name="url">url地址(包括参数)</param>    
    /// <param name="contentType">文本类型(常用:text/plain  multipart/form-data  application/json  text/xml  application/x-www-form-urlencoded)</param>
    /// <param name="encode">编码类型(例:utf-8)</param>
    /// <param name="timeout">超时时间(单位毫秒)</param>
    /// <returns>响应内容</returns>
    public static Stream GetResponseStream(string url, string contentType, int timeout, string encode)
    {
        HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
        if (!string.IsNullOrEmpty(encode))
            request.ContentType = contentType + ";charset=" + encode;
        else
            request.ContentType = contentType;

        request.Method = "GET";
        request.Timeout = timeout;

        return GetStreamByResponse(request);
    }

    /// <summary>
    /// 发送Get请求并返回Response,默认text/plain
    /// </summary>
    /// <param name="url">url地址(包括参数)</param>
    /// <returns></returns>
    public static HttpWebResponse GetResponse(string url)
    {
        return GetResponse(url, "text/plain", 60000, "");
    }

    /// <summary>
    /// 发送Get请求并返回Response
    /// </summary>
    /// <param name="url">url地址(包括参数)</param>
    /// <param name="contentType">文本类型(常用:text/plain  multipart/form-data  application/json  text/xml  application/x-www-form-urlencoded)</param>
    /// <returns>响应内容</returns>
    public static HttpWebResponse GetResponse(string url, string contentType)
    {
        return GetResponse(url, contentType, 60000, "");
    }

    /// <summary>
    /// 发送Get请求并返回Response
    /// </summary>
    /// <param name="url">url地址(包括参数)</param>    
    /// <param name="contentType">文本类型(常用:text/plain  multipart/form-data  application/json  text/xml  application/x-www-form-urlencoded)</param>
    /// <param name="timeout">超时时间(单位毫秒)</param>
    /// <returns>响应内容</returns>
    public static HttpWebResponse GetResponse(string url, string contentType, int timeout)
    {
        return GetResponse(url, contentType, timeout, "");
    }

    /// <summary>
    /// 发送Get请求,并返回Response
    /// </summary>
    /// <param name="url">url地址(包括参数)</param>    
    /// <param name="contentType">文本类型(常用:text/plain  multipart/form-data  application/json  text/xml  application/x-www-form-urlencoded)</param>
    /// <param name="encode">编码类型(例:utf-8)</param>
    /// <param name="timeout">超时时间(单位毫秒)</param>
    /// <returns>响应内容</returns>
    public static HttpWebResponse GetResponse(string url, string contentType, int timeout, string encode)
    {
        HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
        if (!string.IsNullOrEmpty(encode))
            request.ContentType = contentType + ";charset=" + encode;
        else
            request.ContentType = contentType;

        request.Method = "GET";
        request.Timeout = timeout;

        return GetHttpWebResponse(request);
    }


    #endregion

    #region Post方法

    /// <summary>
    /// 发送Post请求(以json格式发送数据)
    /// </summary>
    /// <param name="url">url地址</param>
    /// <param name="data">发送的数据(必须json格式)</param>
    /// <returns>响应内容</returns>
    public static string PostJson(string url, string data)
    {
        return Post(url, data, "application/json", "", 60000);
    }

    /// <summary>
    /// 发送Post请求(以json格式发送数据)
    /// </summary>
    /// <param name="url">url地址</param>
    /// <param name="data">发送的数据(必须json格式)</param>
    /// <param name="encode">编码类型(例:utf-8),可为空</param>
    /// <returns响应内容></returns>
    public static string PostJson(string url, string data, string encode)
    {
        return Post(url, data, "application/json", encode, 60000);
    }

    /// <summary>
    /// 发送Post请求(以json格式发送数据)
    /// </summary>
    /// <param name="url">url地址</param>
    /// <param name="data">发送的数据(必须json格式)</param>
    /// <param name="encode">编码类型(例:utf-8),可为空</param>
    /// <param name="timeout">超时时间</param>
    /// <returns>响应内容</returns>
    public static string PostJson(string url, string data, string encode, int timeout)
    {
        return Post(url, data, "application/json", encode, timeout);
    }

    /// <summary>
    /// 发送Post请求
    /// </summary>
    /// <param name="url">url地址</param>
    /// <param name="contentType">文本类型(常用:text/plain  multipart/form-data  application/json  text/xml  application/x-www-form-urlencoded)</param>
    /// <param name="data">发送的数据</param>
    /// <returns>响应内容</returns>
    public static string Post(string url, string data, string contentType)
    {
        return Post(url, data, contentType, "", 60000);
    }

    /// <summary>
    /// 发送Post请求
    /// </summary>
    /// <param name="url">url地址</param>
    /// <param name="contentType">文本类型(常用:text/plain  multipart/form-data  application/json  text/xml  application/x-www-form-urlencoded)</param>
    /// <param name="data">发送的数据</param>
    /// <param name="timeout">超时时间(单位毫秒)</param>
    /// <returns>响应内容</returns>
    public static string Post(string url, string data, string contentType, string encode)
    {
        return Post(url, data, contentType, encode, 60000);
    }

    /// <summary>
    /// 发送Post请求
    /// </summary>
    /// <param name="url">url地址</param>
    /// <param name="contentType">文本类型(常用:text/plain  multipart/form-data  application/json  text/xml  application/x-www-form-urlencoded)</param>
    /// <param name="data">发送的数据</param>
    /// <param name="encode">编码类型(例:utf-8),可为空</param>
    /// <param name="timeout">超时时间(单位毫秒)</param>
    /// <returns>响应内容</returns>
    public static string Post(string url, string data, string contentType, string encode, int timeout)
    {
        HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
        request.Method = "POST";
        request.Timeout = timeout;
        if (!string.IsNullOrEmpty(encode))
            request.ContentType = contentType + ";charset=" + encode;
        else
            request.ContentType = contentType;

        return PostHelp(data, request);
    }

    //把post发送数据,接收数据的公共部分提取出来
    private static string PostHelp(string data, HttpWebRequest request)
    {
        byte[] dataArray = System.Text.Encoding.UTF8.GetBytes(data);
        request.ContentLength = dataArray.Length;

        Stream requestStream = request.GetRequestStream();
        requestStream.Write(dataArray, 0, dataArray.Length);
        requestStream.Flush();
        requestStream.Close();
        return ReadResponse(request);
    }

    #endregion

    #region 下载响应流中的文件

    /// <summary>
    /// 下载Response流中的文件
    /// </summary>
    /// <param name="response">响应</param>
    /// <param name="filePath">需要存储的文件全地址</param>
    public static void DownFileFromResponse(HttpWebResponse response, string filePath)
    {
        using (Stream responseStream = response.GetResponseStream())
        {
            //创建本地文件写入流
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                byte[] data = new byte[1024];
                int size = responseStream.Read(data, 0, (int)data.Length);
                while (size > 0)
                {
                    fs.Write(data, 0, size);
                    size = responseStream.Read(data, 0, (int)data.Length);
                }
            }
        }
    }

    /// <summary>
    /// 从响应头中获取文件名,注意该方法内部未释放Response,需在外部释放
    /// </summary>
    /// <param name="response">响应</param>
    /// <returns></returns>
    public static string GetFileNameFromResponse(HttpWebResponse response)
    {
        string fileinfo = response.Headers["Content-Disposition"];
        string mathkey = "filename=";
        return fileinfo.Substring(fileinfo.LastIndexOf(mathkey)).Replace(mathkey, "").Replace("\"", "");
    } 

    #endregion

    /// <summary>
    /// 根据请求读取响应内容
    /// </summary>
    /// <param name="request">请求</param>
    /// <returns></returns>
    public static string ReadResponse(HttpWebRequest request)
    {
        HttpWebResponse response;
        try
        {
            response = request.GetResponse() as HttpWebResponse;
        }
        catch (Exception ex)
        {
            throw ex;
        }

        if (response.StatusCode == HttpStatusCode.OK)
        {
            using (Stream responseStream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        return null;
    }

    /// <summary>
    /// 根据请求返回响应流
    /// </summary>
    /// <param name="request">请求</param>
    /// <returns></returns>
    public static Stream GetStreamByResponse(HttpWebRequest request)
    {
        HttpWebResponse response;
        try
        {
            response = request.GetResponse() as HttpWebResponse;
        }
        catch (Exception ex)
        {
            throw ex;
        }

        if (response.StatusCode == HttpStatusCode.OK)
        {
            return response.GetResponseStream();
        }
        return null;
    }

    /// <summary>
    /// 根据请求返回Response
    /// </summary>
    /// <param name="request">请求</param>
    /// <returns></returns>
    public static HttpWebResponse GetHttpWebResponse(HttpWebRequest request)
    {
        HttpWebResponse response;
        try
        {
            response = request.GetResponse() as HttpWebResponse;
        }
        catch (Exception ex)
        {
            throw ex;
        }

        if (response.StatusCode == HttpStatusCode.OK)
        {
            return response;
        }
        return null;
    }
}