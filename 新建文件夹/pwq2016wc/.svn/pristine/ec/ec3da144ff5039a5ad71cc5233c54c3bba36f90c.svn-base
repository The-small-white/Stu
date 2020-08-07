using System;
using System.Collections.Generic;
using System.Web;


/// <summary>
/// 返回结果
/// </summary>
public class Result
{
    public Result()
    { }

    public Result(bool isOk)
    {
        this.isOk = isOk;
    }

    public Result(object obj)
    {
        this.isOk = true;
        this.obj = obj;
    }

    public Result(string msg)
    {
        this.isOk = false;
        this.msg = msg;
    }

    public Result(bool isOk, string msg)
    {
        this.isOk = isOk;
        this.msg = msg;
    }

    public Result(bool isOk, string msg, object obj)
    {
        this.isOk = isOk;
        this.msg = msg;
        this.obj = obj;
    }

    private string _msg;
    /// <summary>
    /// 消息
    /// </summary>
    public string msg
    {
        get { return _msg; }
        set { _msg = value; }
    }
    private string _url;
    public string url
    {
        get { return _url; }
        set { _url = value; }
    }

    private bool _isOk;
    /// <summary>
    /// 是否成功
    /// </summary>
    public bool isOk
    {
        get { return _isOk; }
        set { _isOk = value; }
    }

    private object _obj;
    /// <summary>
    /// 数据
    /// </summary>
    public object obj
    {
        get { return _obj; }
        set { _obj = value; }
    }
}