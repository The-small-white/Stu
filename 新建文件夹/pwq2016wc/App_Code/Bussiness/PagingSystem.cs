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
public class PagingSystem
{

    /// <summary>
    /// 类时Eico翻页样式:上一页 1 2 3 4  下一页
    /// </summary>
    /// <param name="page">当前页</param>
    /// <param name="pageCount">页总数</param>
    /// <param name="pageAddress">页面的url，?或&结尾</param>
    /// <returns></returns>
    public static string SevenStyle8(int page, int pageCount, string pageAddress)
    {
        if (page < 1) { page = 1; }
        if (pageCount < 0) { page = 0; }
        string str = @"
<script type=""text/javascript"">
function GotoPage()
{
	var nowPage =document.getElementById('_page').value;
	this.location.href ='" + pageAddress + @"page='+nowPage ;
}


</script>
";                                          // <ul class="pagination pull-right">
                                         //<li class="footable-page-arrow disabled"><a data-page="first" href="#first">«</a></li>
                                         //<li class="footable-page-arrow disabled"><a data-page="prev" href="#prev">‹</a></li>
                                         //<li class="footable-page active"><a data-page="0" href="#">1</a></li>
                                         //<li class="footable-page-arrow disabled"><a data-page="next" href="#next">›</a></li>
                                         // <li class="footable-page-arrow disabled"><a data-page="last" href="#last">»</a></li></ul>


        if (page >= 1)
        {
            str += @"<ul class=""pagination pull-right"">";
            str += @"<li class=""footable-page-arrow ""><a  data-page=""first""  href=""" + pageAddress + @"page=" + 1+ @""">«</a></li>";  //首页
            str += @"<li class=""footable-page-arrow ""><a  data-page=""prev""  href=""" + pageAddress + @"page=" + (page - 1) + @""">‹</a></li>";  //上一页

        }
        if (pageCount < 6) //10以下，直接列出就好了
        {
            for (int i = 1; i <= pageCount; i++)
            {
                if (i == page)
                {
                    str += @"<li class=""footable-page active""><a href=""" + pageAddress + @"page=" + i + @""" data-page="+i+@""">" + i + "</a></li>";  //页数显示

                }
                else
                {
                    str += @"<li class=""footable-page ""><a href=""" + pageAddress + @"page=" + i + @""" data-page=" + i + @""">" + i + "</a></li>";  //页数显示

                }
            }
            if (pageCount == 0)
            {

                str += @"<li class=""footable-page active""><a href=""" + pageAddress + @"page=" + page + @"""  >" + page + "</a></li>";  //页数显示
            }
        }
        else
        {
            if (page < 5)
            {
                for (int i = 1; i <= 5; i++)
                {
                    if (i == page)
                    {

                        str += @"<li class=""footable-page active""><a href=""" + pageAddress + @"page=" + i + @"""  >" + i + "</a></li>";  //页数显示
                    }
                    else
                    {

                        str += @"<li class=""footable-page""><a   href=""" + pageAddress + @"page=" + i + @""">" + i + "</a></li>";  //页数显示
                    }
                }

                str += @"<li class=""footable-page""><a  href=""" + pageAddress + @"page=" + 6 + @""">...</a></li>";

                str += @"<li class=""footable-page""><a   href=""" + pageAddress + @"page=" + (pageCount - 1) + @""">" + (pageCount - 1) + "</a></li>";  //页数显示
             
                str += @"<li class=""footable-page""><a   href=""" + pageAddress + @"page=" + pageCount + @""">" + pageCount + "</a></li>";  //页数显示
            }
            else if (pageCount - page < 5)
            {
                //str += @"<li class=""footable-page""><a    href=""" + pageAddress + @"page=" + 1 + @""">" + 1 + "</a></li>";  //页数显示
                //str += @"<li class=""footable-page""><a    href=""" + pageAddress + @"page=" + 2 + @""">" + 2 + "</a></li>";  //页数显示

                str += @"<li class=""footable-page""><a  href=""" + pageAddress + @"page=" + (page - 1) + @""">...</a></li>";
                for (int i = 6; i > -1; i--)
                {

                    int p = pageCount - i;
                    if (p == page)
                    {

                        str += @"<li class=""footable-page active""><a href=""" + pageAddress + @"page=" + p + @"""  >" + p + "</a></li>";  //页数显示
                    }
                    else
                    {

                        str += @"<li class=""footable-page ""><a href=""" + pageAddress + @"page=" + p + @"""  >" + p + "</a></li>";  //页数显示

                    }
                }


            }
            else // 正常情况下
            {
                str += @"<li class=""footable-page""><a  href=""" + pageAddress + @"page=" + 1 + @""">" + 1 + "</a></li>";  //页数显示
                str += @"<li class=""footable-page""><a  href=""" + pageAddress + @"page=" + 2 + @""">" + 2 + "</a></li>";  //页数显示

                str += @"<li class=""footable-page""><a   href=""" + pageAddress + @"page=" + (page - 2) + @""">" + (page - 2) + "</a></li>";  //页数显示
                str += @"<li class=""footable-page""><a   href=""" + pageAddress + @"page=" + (page - 1) + @""">" + (page - 1) + "</a></li>";  //页数显示

                str += @"<li class=""footable-page""><a href=""" + pageAddress + @"page=" + page + @"""  >" + page + "</a></li>";  //页数显示

                str += @"<li class=""footable-page""><a   href=""" + pageAddress + @"page=" + (page + 1) + @""">" + (page + 1) + "</a></li>";  //页数显示
                str += @"<li class=""footable-page""><a    href=""" + pageAddress + @"page=" + (page + 2) + @""">" + (page + 2) + "</a></li>";  //页数显示

                str += @"<li class=""footable-page""><a  href=""" + pageAddress + @"page=" + (page + 3) + @""">...</a></li>";

                str += @"<li class=""footable-page""><a    href=""" + pageAddress + @"page=" + (pageCount - 1) + @""">" + (pageCount - 1) + "</a></li>";  //页数显示

                str += @"<li class=""footable-page""><a    href=""" + pageAddress + @"page=" + pageCount + @""">" + pageCount + "</a></li>";  //页数显示
            }


        }

        if (page < pageCount)
        {
            str += @"<li class=""footable-page-arrow""><a   href=""" + pageAddress + @"page=" + (page + 1) + @""">›</a></li>"; //下一页

        }
            str += @"<li class=""footable-page-arrow""><a   href=""" + pageAddress + @"page=" + (pageCount) + @""">»</a></li></ul>";
        
        
       
        return str;

    }

}
