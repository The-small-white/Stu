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
/// Pages 的摘要说明
/// </summary>
public class PagingSystemHtml
{

    #region 拍拍网的分页样式
    /// <summary>
    /// 拍拍网的分页方法: 上一页  1 2 … 5 6 *7* 8 9… 11  12  下一页   转到 []页 Go
    /// </summary>
    /// <param name="page">当前页</param>
    /// <param name="pageCount">总的页数</param>
    /// <param name="pageAddress">页面的url，?或&结尾</param>
    /// <param name="path">图片存放的路径，包括page_next.gif和before.gif</param>
    /// <returns>分页的html代码</returns>
    public static string PaiPaiStyle(int page, int pageCount, string pageAddress, string path)
    {
        if (page < 1) { page = 1; }
        if (pageCount < 0) { page = 0; }
        string str = @"
            <style type=""text/css"">
<!--
.paginator { font: 11px Arial, Helvetica, sans-serif;;padding:10px 20px 10px 0; margin: 0px; text-align:right}
.paginator a, .pageList .this-page {padding: 1px 6px; border: solid 1px #ddd; background: #fff; text-decoration: none;margin-right:2px}
.paginator a:visited {padding: 1px 6px; border: solid 1px #ddd; background: #fff; text-decoration: none;}
.paginator .break {padding: 1px 6px; border:none;text-decoration: none;}
.paginator .this-page {padding: 1px 6px;font-weight: bold; font-size: 13px;border:none}
.paginator a:hover {color: #fff; background: #ffa501;border-color:#ffa501;text-decoration: none;}
-->
</style>
<script type=""text/javascript"">
function GotoPage()
{
    
	var nowPage =document.getElementById('page').value;
    var pageAddress = '" + pageAddress + @"';
    if(nowPage > 1)
    {
        pageAddress = pageAddress.replace(/{&@Page}/g, nowPage);
    }
    else
    {
        pageAddress = pageAddress.replace(/{&@Page}/g, "");
    }
 
    this.location.href = pageAddress ;
    //{@pageCount:--" + pageCount + @"} //{@nowPage:--" + page + @"}
}

</script>

";//css 样式表加js

        str += @"  <table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" align=""right"">
      <tr>
        <td align=""right""><div class=""paginator"">";
        if (page > 1)
        {
            str += @"<a href=""" + Replace(pageAddress, "{&@Page}", page - 1) + @"""><img src='" + path + "before.gif' border='0' align='absmiddle' alt='上一页' style='cursor: pointer' hspace='5' /></a>";  //上一页
        }
        if (pageCount < 10) //10以下，直接列出就好了
        {
            for (int i = 1; i <= pageCount; i++)
            {
                if (i == page)
                {
                    str += @"<span class='this-page'>" + i + "</span>";  //页数显示
                }
                else
                {
                    str += @"<a href=""" + Replace(pageAddress, "{&@Page}",i)  + @""">" + i + "</a>";  //页数显示

                }
            }
            if (pageCount == 0)
            {
                str += @"<span class='this-page'>" + page + "</span>";  //页数显示
            }
            // str += @"<a href="""+pageAddress+@"id="+(page - 1)+@""">89</a><span class='this-page'>90</span>";  //页数显示
        }
        else
        {
            if (page < 5)
            {
                for (int i = 1; i <= 7; i++)
                {
                    if (i == page)
                    {
                        str += @"<span class='this-page'>" + i + "</span>";  //页数显示
                    }
                    else
                    {
                        str += @"<a href=""" + Replace(pageAddress, "{&@Page}",i) + @""">" + i + "</a>";  //页数显示

                    }
                }
                

                str += "...";
                str += @"<a href=""" + Replace(pageAddress, "{&@Page}", pageCount - 1) + @""">" + (pageCount - 1) + "</a>";
                str += @"<a href=""" + Replace(pageAddress, "{&@Page}", pageCount ) + @""">" + pageCount + "</a>";
            }
            else if (pageCount - page < 5)
            {
                str += @"<a href=""" + Replace(pageAddress, "{&@Page}",   1) + @""">" + 1 + "</a>";
                str += @"<a href=""" + Replace(pageAddress, "{&@Page}", 2) + @""">" + 2 + "</a>";
                str += "...";
                for (int i = 6; i > -1; i--)
                {

                    int p = pageCount - i;
                    if (p == page)
                    {
                        str += @"<span class='this-page'>" + p + "</span>";  //页数显示
                    }
                    else
                    {
                        str += @"<a href=""" + Replace(pageAddress, "{&@Page}", p) + @""">" + p + "</a>";  //页数显示

                    }
                }


            }
            else // 正常情况下
            {

                str += @"<a href=""" + Replace(pageAddress, "{&@Page}", 1) + @""">" + 1 + "</a>";
                str += @"<a href=""" + Replace(pageAddress, "{&@Page}", 2) + @""">" + 2 + "</a>";
                str += "...";
                str += @"<a href=""" + Replace(pageAddress, "{&@Page}", page - 2) + @""">" + (page - 2) + "</a>";
                str += @"<a href=""" + Replace(pageAddress, "{&@Page}", page - 1) + @""">" + (page - 1) + "</a>";
                str += @"<span class='this-page'>" + page + "</span>";
                str += @"<a href=""" + Replace(pageAddress, "{&@Page}", page + 1) + @""">" + (page + 1) + "</a>";
                str += @"<a href=""" + Replace(pageAddress, "{&@Page}", page + 2) + @""">" + (page + 2) + "</a>";
                str += "...";
                str += @"<a href=""" + Replace(pageAddress, "{&@Page}", pageCount - 1) + @""">" + (pageCount - 1) + "</a>";
                str += @"<a href=""" + Replace(pageAddress, "{&@Page}", pageCount ) + @""">" + pageCount + "</a>";
            }

        }
        if (page < pageCount)
        {
            str += @"<a href=""" + Replace(pageAddress, "{&@Page}", (page + 1) ) + @"""><img src='" + path + "page_next.gif' align='absmiddle' border='0' alt='下一页' style='cursor: pointer' hspace='5' /></a>"; //下一页
        }
        str += @"</div></td>
        <td>到第 <input size='4' id='page' name='page'  style='width:20px;height:12px'> 页 <input name=""gopage""  type=""button"" value=""查 看"" onClick=""GotoPage();"" style='height:20px' />
        </td>
      </tr>
    </table>";

        return str;
    }
    #endregion

    #region 上一页 下一页 模式
    /// <summary>
    /// 样式：首页 上一页 下一页 末页 1/132 到第__页  查看
    /// </summary>
    /// <param name="page">当前页</param>
    /// <param name="pageCount">页总数</param>
    /// <param name="pageAddress">页面的url，?或&结尾</param>
    /// <returns></returns>
    public static string DownUpStyle(int pageIndex, int pageCount, string pageAddress)
    {

        string str = @"<script type=""text/javascript"">
                    function GotoPage()
                    {
	                    var nowPage =document.getElementById('page').value;
                        var pageAddress = '" + pageAddress + @"';
                            if(nowPage > 1)
    {
        pageAddress = pageAddress.replace(/{&@Page}/g, nowPage);
    }
    else
    {
        pageAddress = pageAddress.replace(/{&@Page}/g, "");
    }
                        this.location.href = pageAddress ;
                        //{@pageCount:--" + pageCount + @"} //{@nowPage:--" + pageIndex + @"}
                    }

                    </script>";


        

        if (pageIndex > 1)
        {
            str += "<a href=\"" + Replace(pageAddress, "{&@Page}", 1) + "\">首页</a>&nbsp;&nbsp;";
            str += "<a href=\"" + Replace(pageAddress, "{&@Page}", pageIndex - 1) + "\">上一页</a>&nbsp;&nbsp;";
        }
        else
        {
            str += "上一页&nbsp;&nbsp;";
        }

        if (pageIndex < pageCount)
        {
            str += "<a href=\"" + Replace(pageAddress, "{&@Page}", pageIndex + 1) + "\">下一页</a>";
            str += "&nbsp;&nbsp;<a href=\"" + Replace(pageAddress, "{&@Page}", pageCount ) + "\">末页</a>";
        }
        else
        {
            str += "下一页";
        }
        //str += "&nbsp;&nbsp;" + pageIndex + "/" + pageCount;
        //str += "到第 <input size='4' id='page' name='page'  style='width:20px;height:12px'> 页 <input name=\"gopage\"  type=\"button\" value=\"查 看\" onClick=\"GotoPage();\" style='height:20px' />";
        return str;
    }
    #endregion

    #region 类时GOOGLE翻页样式

    /// <summary>
    /// 类时GOOGLE翻页样式:上一页 1 2 3 4 5 6 7 8 9 10 11 下一页
    /// </summary>
    /// <param name="page">当前页</param>
    /// <param name="pageCount">页总数</param>
    /// <param name="pageAddress">页面的url，?或&结尾</param>
    /// <returns></returns>
    public static string GoogleStyle(int pageIndex, int pageCount, string pageAddress)
    {

        string pageHtml = @"<script type=""text/javascript"">
                        //{@pageCount:--" + pageCount + @"} //{@nowPage:--" + pageIndex + @"}
                    </script>";

        int previousPagesCount = 4;

        if (pageIndex > 1)
        {
            pageHtml += "<a href=\"" + Replace(pageAddress, "{&@Page}", pageIndex - 1) + "\">上一页</a>&nbsp;&nbsp;";
        }
        
        for (int i = pageIndex - 1; i >= 0 && i >= pageIndex - previousPagesCount; i--)
        {
            int step = i - pageIndex;
            pageHtml += PagingItemHtml(pageAddress, pageIndex, true);

        }

        pageHtml += PagingItemHtml(pageAddress, pageIndex, false);

        int nextPagesCount = 4;
        for (int i = pageIndex + 1; i <= pageCount && i <= pageIndex + nextPagesCount; i++)
        {
            int step = i - pageIndex;

            pageHtml += PagingItemHtml(pageAddress, pageIndex, true);

        }

        if (pageIndex < pageCount)
        {
            pageHtml += "&nbsp;&nbsp;<a href=\"" + Replace(pageAddress, "{&@Page}", pageIndex + 1) + "\">下一页</a>";
        }

        return pageHtml;
    }
    

    private static string PagingItemHtml(string pageAddress, int pageIndex, bool active)
    {
        if (active)
            return " <a href=\""  +Replace(pageAddress, "{&@Page}", pageIndex ) + "\" class=\"p_act\" onfocus=\"this.blur()\">" + pageIndex + "</a> ";

        else
            return " <b>" + pageIndex + "</b> ";
    }
    #endregion

    #region 下拉选择翻页
    /// <summary>
    /// 样式：每页20条记录 共2页   共27条记录     跳转到 12 页 ,没有上一页和下一页
    /// </summary>
    /// <param name="pageSize"></param>
    /// <param name="count"></param>
    /// <param name="page"></param>
    /// <param name="pageAddress"></param>
    /// <returns></returns>
    public static string SelectPageStyle(int pageSize, int count, int page, string pageAddress)
    {
        int pageCount = (count + pageSize - 1) / pageSize;
        if (page < 1) { page = 1; }
        if (pageCount < 0) { page = 0; }
        string str = @"<script type=""text/javascript"">

                    function GotoPage()
                    {
	                    var nowPage =document.getElementById('page').value;
                        var pageAddress = '" + pageAddress + @"';
                            if(nowPage > 1)
    {
        pageAddress = pageAddress.replace(/{&@Page}/g, nowPage);
    }
    else
    {
        pageAddress = pageAddress.replace(/{&@Page}/g, "");
    }
                        this.location.href = pageAddress ;
                        //{@pageCount:--" + pageCount + @"} //{@nowPage:--" + page + @"}
                    }

                    </script>";
        str += "<table height=\"35\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" border=\"0\"><tr>";

        str += "<td width=\"50%\">每页<span class=\"font-red\">" + pageSize + "</span>条记录 共<span class=\"font-red\">" + pageCount + "</span>页 &nbsp;&nbsp;共<span class=\"font-red\">" + count + "</span>条记录</td>";

        str += "<td align=\"right\">&nbsp; &nbsp; 跳转到 <select onchange=\"GotoPage(this.value)\" name=\"select2\">";

        for (int i = 1; i < pageCount + 1; i++)
        {
            str += "<option value=\"" + i + "\" ";
            if (i == page)
            {
                str += "selected";
            }
            str += ">" + i + "</option>";
        }

        str += "</select> 页 </td>";

        str += "</tr></table>";


        return str;
    }
    #endregion


    #region 类时Eico翻页样式

    /// <summary>
    /// 类时Eico翻页样式:＜ 1 2 3 4  ＞
    /// </summary>
    /// <param name="page">当前页</param>
    /// <param name="pageCount">页总数</param>
    /// <param name="pageAddress">页面的url，?或&结尾</param>
    /// <returns></returns>
    public static string EicoStyle(int pageIndex, int pageCount, string pageAddress)
    {
        string pageHtml = @"<script type=""text/javascript"">
                        //{@pageCount:--" + pageCount + @"} //{@nowPage:--" + pageIndex + @"}
                    </script>";

         pageHtml += "<p><span id=\"index_page_down\">";
        int previousPagesCount = 2;

        if (pageIndex > 1)
        {
            pageHtml += "<a href=\"" + Replace(pageAddress, "{&@Page}", pageIndex - 1) + "\" title=\"pageup\" class=\"pageup\" onfocus=\"this.blur()\"><img src=\"images/pageup.gif\" alt=\"pageup\" /></a>";
        }

        for (int i = pageIndex - 1; i >= 1 && i >= pageIndex - previousPagesCount; i--)
        {
            //int step = i - pageIndex;
            pageHtml += PagingItemHtml(pageAddress, i, true);

        }

        pageHtml += PagingItemHtml(pageAddress, pageIndex, false);

        int nextPagesCount = 2;
        for (int i = pageIndex + 1; i <= pageCount && i <= pageIndex + nextPagesCount; i++)
        {
            //int step = i - pageIndex;

            pageHtml += PagingItemHtml(pageAddress, i, true);

        }

        if (pageIndex < pageCount)
        {
            pageHtml += "<a href=\"" + Replace(pageAddress, "{&@Page}", pageIndex + 1) + "\" title=\"pagedown\" class=\"pagedown\" onfocus=\"this.blur()\"><img src=\"images/pagedown.gif\" alt=\"pagedown\" /></a>";
        }
        pageHtml += "</span></p>";
        return pageHtml;
    }
    #endregion

    #region 类时360翻页样式

    /// <summary>
    /// 类时Eico翻页样式:上一页 1 2 3 4  下一页
    /// </summary>
    /// <param name="page">当前页</param>
    /// <param name="pageCount">页总数</param>
    /// <param name="pageAddress">页面的url，?或&结尾</param>
    /// <returns></returns>
    public static string ThreeStyle(int page, int pageCount, string pageAddress)
    {
        if (page < 1) { page = 1; }
        if (pageCount < 0) { page = 0; }
        string str = @"
<script type=""text/javascript"">
 

                    function GotoPage()
                    {
	                    var nowPage =document.getElementById('page').value;
                        var pageAddress = '" + pageAddress + @"';
                            if(nowPage > 1)
    {
        pageAddress = pageAddress.replace(/{&@Page}/g, nowPage);
    }
    else
    {
        pageAddress = pageAddress.replace(/{&@Page}/g, "");
    }
                        this.location.href = pageAddress ;
                        //{@pageCount:--" + pageCount + @"} //{@nowPage:--" + page + @"}
                    }


</script>
<style>
li{list-style-type:none}
a{text-decoration:none;}
.sch_foot{height:21px; }
.sch_foo1{height:21px; width:auto; float:left; line-height:21px;}
.sch_foo1 ul li{float:left; height:18px; width:18px; background:#eaeaea; border:solid 1px #2b2b2b; line-height:18px; text-align:center; margin-right:5px; color:#040404;}
.sch_foo1 ul li a{color:#040404;}
.sch_foo2{float:right; line-height:21px; width:180px; text-align:right}
.sch_i{padding:1px 0; width:35px; margin:-1px 5px 0 0; height:21px; line-height:21px}
.sch_foo2 ul li{float:left;}
.sch_foo2 img{margin-top:2px; margin-left:5px;}
.sch_foot{color:#54595d;}
</style>


";//css 样式表加js

        //        <div class="pages"><span>共<font>1678</font>条评论</span><b>1</b><a 

        //href="">2</a><a href="">3</a><a href="">4</a><a href="">5</a>...<a 

        //href="">168</a><a href="">下一页>></a></div>
        str += "<div class=\"sch_foot\">";
        str += "<div class=\"sch_foo1\">";
        str += "<ul>";
        if (page > 1)
        {
            str += @"<li style=""width:23px;""><a href=""" + Replace(pageAddress, "{&@Page}", page - 1) + @"""><</a></li>";  //上一页
        }
        else
        {
            str += "<li style=\"width:23px; border-color:#b6b6b6; color:#b6b6b6;\"><</li>";
        }
        if (pageCount < 9) //10以下，直接列出就好了
        {
            for (int i = 1; i <= pageCount; i++)
            {
                if (i == page)
                {
                    //str += @"<b>" + i + "</b>";  //页数显示
                    str += @"<li style=""background:#7c2a2a;"">" + Replace(pageAddress, "{&@Page}",i) + "</li>";  //页数显示

                }
                else
                {
                    str += @"<li><a href=""" + Replace(pageAddress, "{&@Page}",i) + @""">" + i + "</a></li>";  //页数显示

                }
            }
            if (pageCount == 0)
            {
                //str += @"<b>" + page + "</b>";  //页数显示
                str += @"<li style=""background:#7c2a2a;"">" + page + "</li>";  //页数显示
            }
            // str += @"<a href="""+pageAddress+@"id="+(page - 1)+@""">89</a><span class='this-page'>90</span>";  //页数显示
        }
        else
        {
            if (page < 5)
            {
                for (int i = 1; i <= 7; i++)
                {
                    if (i == page)
                    {
                        //str += @"<b>" + i + "</b>";  //页数显示
                        str += @"<li style=""background:#7c2a2a;"">" + i + "</li>";  //页数显示
                    }
                    else
                    {
                        str += @"<li><a href=""" + Replace(pageAddress, "{&@Page}",i) + @""">" + i + "</a></li>";  //页数显示

                    }
                }
                str += "<li>...</li>";
                str += @"<li><a href=""" + Replace(pageAddress, "{&@Page}", pageCount - 1) + @""">" + (pageCount - 1) + "</a></li>";
                str += @"<li><a href=""" + Replace(pageAddress, "{&@Page}", pageCount ) + @""">" + pageCount + "</a></li>";
            }
            else if (pageCount - page < 5)
            {
                str += @"<li><a href=""" + Replace(pageAddress, "{&@Page}", 1) + @""">" + 1 + "</a></li>";
                str += @"<li><a href=""" + Replace(pageAddress, "{&@Page}", 2) + @""">" + 2 + "</a></li>";
                str += "<li>...</li>";
                for (int i = 6; i > -1; i--)
                {

                    int p = pageCount - i;
                    if (p == page)
                    {
                        //str += @"<span>" + p + "</span>";  //页数显示
                        str += @"<li style=""background:#7c2a2a;""><a href="""  + Replace(pageAddress, "{&@Page}", p) + @""" >" + p + "</a></li>";  //页数显示

                    }
                    else
                    {
                        str += @"<li><a href=""" + Replace(pageAddress, "{&@Page}", p ) + @""">" + p + "</a></li>";  //页数显示

                    }
                }


            }
            else // 正常情况下
            {

                str += @"<li style=""background:#7c2a2a;"">" + 1 + "</li>";
                str += @"<li><a href=""" + Replace(pageAddress, "{&@Page}", 2) + @""">" + 2 + "</a></li>";
                str += "<li>...</li>";
                str += @"<li><a href=""" + Replace(pageAddress, "{&@Page}", page - 2) + @""">" + (page - 2) + "</a></li>";
                str += @"<li><a href=""" + Replace(pageAddress, "{&@Page}", page - 1) + @""">" + (page - 1) + "</a></li>";
                //str += @"<span>" + page + "</span>";
                str += @"<li><a href=""" + Replace(pageAddress, "{&@Page}", page ) + @""" class=""on"">" + page + "</a></li>";
                str += @"<li><a href=""" + Replace(pageAddress, "{&@Page}", page + 1) + @""">" + (page + 1) + "</a></li>";
                str += @"<li><a href=""" + Replace(pageAddress, "{&@Page}", page + 2) + @""">" + (page + 2) + "</a></li>";
                str += "<li>...</li>";
                str += @"<li><a href=""" + Replace(pageAddress, "{&@Page}", pageCount - 1) + @""">" + (pageCount - 1) + "</a></li>";
                str += @"<li><a href=""" + Replace(pageAddress, "{&@Page}", pageCount ) + @""">" + pageCount + "</a></li>";
            }

        }
        if (page < pageCount)
        {
            str += @"<li style=""width:23px;""><a href=""" + Replace(pageAddress, "{&@Page}", page + 1 ) + @""">></a></li>"; //下一页
        }
        else
        {
            str += "<li style=\"width:23px; border-color:#b6b6b6; color:#b6b6b6;\">></li>";
        }
        str += @"
            </ul></div>
            <div class=""sch_foo2"">
            <ul>
        <li>跳转：</li><li> <input class=""sch_i"" id='page' name='page'  style='width:30px;height:14px'></li> <li> 页</li> <li><input name=""gopage"" src=""icon/85_15.png""  type=""image""  onClick=""GotoPage();"" /></li>
        </ul>
            </div>
        </div>";
        return str;

    }
    #endregion


    protected static string Replace(string str, string oldStr, int page)
    {
        if (page == 1)
        {
            return str.Replace(oldStr, "");
        }
        else
        {
            return str.Replace(oldStr, "_" + page);
        }
    }
}
