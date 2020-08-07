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
/// 管理员验证和分页
/// </summary>
public class AdminAndPage : PagingPage
{
	public AdminAndPage()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    #region 事件处理
    protected override void OnInit(EventArgs e)
    {
        
        if (!AdminMethod.IsAuthenticated&& IsCSRF())
        {
            Response.Redirect(SysConfig.AdminPath+"login.aspx");
        }
      
        base.OnInit(e);

    }
    protected bool IsCSRF()
    {
        string CSRF = ConfigurationManager.AppSettings["CSRF"].ToString();
        if (CSRF != "")
        {
            if (Request.UrlReferrer != null)
            {
                if (Request.UrlReferrer.ToString().IndexOf(CSRF) > -1)
                {
                    return true;
                }
            }
            return false;
        }
        return true;

    }
    #endregion 事件处理

    private string m_mrUrl = "Manage.aspx";

    /// <summary>
    /// 默认返回url
    /// </summary>
    public string MrUrl
    {
        get { return m_mrUrl; }
        set { m_mrUrl = value; }
    }
    /// <summary>
    /// 获取string类型的请求值
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    protected string GetstringKey(string key)
    {
        if (!string.IsNullOrEmpty(this.Request[key]))
        {
            string stringKey = Convert.ToString(this.Request[key]);
            stringKey = RequestString.NoHTML(stringKey);
            return stringKey;

        }
        return "";
    }
    /// <summary>
    /// 获取int类型的请求值
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    protected int GetIntKey(string key)
    {
        if (!string.IsNullOrEmpty(this.Request[key]))
        {
            string stringKey = Convert.ToString(this.Request[key]);
            stringKey = RequestString.NoHTML(stringKey);

            return Convert.ToInt32(stringKey);

        }
        return 0;
    }
    /// <summary>
    /// 返回上级目录
    /// </summary>
    protected string ReturnUrl
    {
        get
        {
            if (string.IsNullOrEmpty(this.Request["reurl"]))
            {
                return this.Request.Path.Replace(this.Request.Url.Segments[this.Request.Url.Segments.Length - 1], "") + MrUrl;
            }
            else
            {
                return this.Request["reurl"].ToString();
            }
        }
    }

    /// <summary>
    ///  获取当前UrlEncode编码的上级目录
    /// </summary>
    protected string ReturnEncodeUrl
    {
        get
        {
                return HttpUtility.UrlEncode(ReturnUrl);
        }
    }


    /// <summary>
    /// 获取当前UrlEncode编码的URL
    /// </summary>
    protected string NowEncodeUrl
    {
        get
        {
            string url = HttpContext.Current.Request.Url.PathAndQuery;
            string m_returnUrl = HttpUtility.UrlEncode(url);
            return m_returnUrl;
        }
    }

    /// <summary>
    /// 获取当前URL
    /// </summary>
    protected string NowUrl
    {
        get
        {
            return HttpContext.Current.Request.Url.PathAndQuery;
        }
    }







}
