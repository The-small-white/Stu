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
public class PagingPage : System.Web.UI.Page
{
    public PagingPage()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    #region 获取当前页数
    /// <summary>
    /// 获取当前页数
    /// </summary>
    protected int PageIndex
    {
        get
        {
            if (string.IsNullOrEmpty(this.Request.QueryString["page"]))
            { return 1; }
            int pageIndex = Convert.ToInt32(this.Request.QueryString["page"]);
            if (pageIndex < 1) pageIndex = 1;
            return pageIndex;
        }
    }
    #endregion


    #region 获取查询字符串

    /// <summary>
    /// 获取查询字符串
    /// </summary>
    protected string Query
    {
        get
        {
            string query = this.Request["q"];

            if (string.IsNullOrEmpty(query))
            {
                return "";
            }
            else
            {
                query = HttpUtility.HtmlEncode(query);
                return query;
            }
        }
    }

    #endregion

    /// <summary>
    /// 每页数量
    /// </summary>
    protected int PageSize = SysConfig.PAGESIZE;

    /// <summary>
    /// 条数
    /// </summary>
    protected int Count = -1;


    /// <summary>
    /// 获取页总数
    /// </summary> 
    protected int PageCount
    {
        get
        {
            int pageCount = (Count + PageSize - 1) / PageSize;
            return pageCount;
        }
    }


    /// <summary>
    /// 获取页总数
    /// </summary> 
    protected string PageAddress
    {
        get
        {
            string url = this.Request.Path.ToString();
            //url = HttpUtility.(url);
            //
            //url = HttpUtility.UrlDecode(url);
            string q = this.Request.QueryString.ToString();
            string q1 = this.Request.Form.ToString();

            q += "&" + q1;
            q = q.Trim('&');

            if(!string.IsNullOrEmpty(this.Request.QueryString.ToString()))
            {
                url += "?" + q;
            }
            string pageStr = this.Request.Url.Query;
            //pageStr = HttpUtility.HtmlDecode(pageStr);
            //this.Request.Url.Segments
            if (url.IndexOf("?") == -1)
            {
                url += "?";
            }
            else if (pageStr.IndexOf("page=") == -1)
            {
                url += "&";
            }
            else
            {
                System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"\?page=[\s\S]+$", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@"page=[\s\S]+&", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@"&page=[\s\S]+$", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                //System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@"&page=[\s\S]+&", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                url = regex1.Replace(url, "");
                url = regex2.Replace(url, "");
                url = regex3.Replace(url, "");
                url = url.Replace("page=", "");
                
                if (url.IndexOf("?") == -1)
                {
                    url += "?";
                }
                else
                {
                    url += "&";
                }
            }
            if (url.ToLower().IndexOf("newcount") == -1)
            {
                url += "newcount=" + Count + "&";
            }
            return url;
        }
    }

    /// <summary>
    /// 获取分页文本
    /// </summary>
    /// <param name="style">分页样式</param>
    /// <returns></returns>
    protected string GetPagingHtml()
    {
        return PagingSystem.SevenStyle8(PageIndex, PageCount, PageAddress);


    }

    protected int NewCount
    {
        get
        {
            if (string.IsNullOrEmpty(this.Request["NewCount"]))
            {
                return -1;
            }
            else
            {
                return Convert.ToInt32(this.Request["NewCount"]);
            }
        }
    }
}
