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
/// AdminPage 的摘要说明
/// </summary>
public class AdminPage : System.Web.UI.Page
{
    public AdminPage()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    #region 事件处理
    protected override void OnInit(EventArgs e)
    {
       // HttpContext.Current.Response.Headers.Remove("Server");
        if (!AdminMethod.IsAuthenticated&& IsCSRF())
        {
            Response.Redirect(SysConfig.AdminPath+"login.aspx");
        }
        

        base.OnInit(e);

    }
    /// <summary>
    /// 设置域名白名单
    /// </summary>
    /// <returns></returns>
    protected bool IsCSRF()
    {
        string CSRF = ConfigurationManager.AppSettings["CSRF"].ToString();
        if (CSRF != "")
        {
            if (Request.UrlReferrer != null)
            {
                if (Request.UrlReferrer.ToString().IndexOf(CSRF)>-1)
                {
                    return true;
                }
            }
            return false;
        }
        return true;
        
    }
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
    #endregion 事件处理

    //private string m_mrUrl="manage.aspx";

    ///// <summary>
    ///// 默认返回url
    ///// </summary>
    //public string MrUrl
    //{
    //    get { return m_mrUrl; }
    //    set { m_mrUrl = value; }
    //}

    ///// <summary>
    ///// 返回上级目录
    ///// </summary>
    //protected  string ReturnUrl
    //{
    //    get
    //    {
    //        if (string.IsNullOrEmpty(this.Request["reurl"]))
    //        {
    //            return this.Request.Path.Replace(this.Request.Url.Segments[this.Request.Url.Segments.Length - 1], "") + MrUrl;
    //        }
    //        else
    //        {
    //            return this.Request["reurl"].ToString();
    //        }
    //    }
    //}

    /// <summary>
    ///  获取当前UrlEncode编码的上级目录
    /// </summary>
    //protected string ReturnEncodeUrl
    //{
    //    get
    //    {
    //        if (string.IsNullOrEmpty(this.Request["reurl"]))
    //        {
    //            return HttpUtility.UrlEncode(this.Request.Path.Replace(this.Request.Url.Segments[this.Request.Url.Segments.Length - 1], "") + MrUrl);
    //        }
    //        else
    //        {
    //            return HttpUtility.UrlEncode(this.Request["reurl"].ToString());
    //        }
    //    }
    //}


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


    protected string getFileHtml(string fileStr, string ziDuanName)
    {
        return getFileHtml(fileStr, ziDuanName, false);
    }
    protected string getFileHtml(string fileStr, string ziDuanName, bool bshow)
    {
        if (string.IsNullOrEmpty(fileStr))
        {
            return "";
        }
        string html = "";
        string[] fileArr = fileStr.Split('|');
        if (fileArr.Length == 3)
        {
            string[] fileName = fileArr[0].Split(',');

            string[] showName = fileArr[1].Split(',');
            string[] addTime = fileArr[2].Split(',');
            if (fileName.Length == showName.Length && fileName.Length == addTime.Length)
            {
                for (int i = 0; i < fileName.Length; i++)
                {
                    html += GetItemHtml("UploadFiles/"+fileName[i], showName[i], addTime[i], ziDuanName, bshow);
                }
            }
        }
        return html;
    }

    protected string GetItemHtml(string fileName, string showName, string addTime, string ziDuanName, bool bshow)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            return "";
        }
        string fileExtension = System.IO.Path.GetExtension(fileName).ToLower();
        string info = @"<div class=""file-box filesCollectinons "">
                        <div class=""file"">
                            <a href=""javascript:void(0)"">
                                <span class=""corner""></span>
                                {文件DIV}
                            </a>
                            <div class=""file-name"">
                                {显示文件名}
                                <br /> 
                                {删除}
                                
                                
                                <abbr style=""float: right"">{上传时间}</abbr>
                            </div>
 
                            <input type=""hidden"" name=""{字段名}_fileName"" value=""{文件地址}"" />
                            <input type=""hidden"" name=""{字段名}_showName"" value=""{显示名}"" />
                            <input type=""hidden"" name=""{字段名}_addTime"" value=""{上传时间}"" />
                        </div>
                    </div>";
        info = info.Replace("{文件DIV}", GetDivHtml(fileName, showName, fileExtension));
        info = info.Replace("{显示文件名}", showName);
        info = info.Replace("{上传时间}", addTime);
        info = info.Replace("{字段名}", ziDuanName);
        info = info.Replace("{文件地址}", fileName);
        info = info.Replace("{显示名}", showName);
        if (bshow)
        {
            info = info.Replace("{删除}", "");
        }
        else
        {
            info = info.Replace("{删除}", @"<a onclick=""deleteFile(this);"" href=""javascript:void(0)"" class=""deleteFile"">删除</a>");
        }

        //<a target=""_blank"" href=""https://view.officeapps.live.com/op/view.aspx?src=oa.cloud.plusbe.com{文件地址}"">预览</a>
        //info = info.Replace("{预览}", GetYuLan(fileExtension, fileName));
        return info;
    }

    //根据文件名获取对应的div
    protected string GetDivHtml(string newName, string oldName, string fileExtension)
    {
        string div = string.Empty;
        string fileName = "../../" + newName;
        if (fileExtension == ".jpg" || fileExtension == ".png" || fileExtension == ".gif" || fileExtension == ".bmp")
        {
            string thumbnailPath = "../../" + newName;
            div = "<div class=\"lightBoxGallery image\" > <a href=\"" + fileName + "\" title=\"\" data-gallery=\"\">";
            div += "    <img style=\"margin:0px;height:100px !important;\" src=\"" + thumbnailPath + "\"></a>  </div>";
           // div = "<div class=\"image\"><img alt=\"image\" class=\"img-responsive\" data-src=\"" + fileName + "\" src=\"" + thumbnailPath + "\"></div>";
        }
        else//非图片
        {
            //div = "<div class=\"icon\" data-src=\"" + fileName + "\"><i class=\"";
            switch (fileExtension)
            {
                case ".mov":
                case ".mp4":
                    //div = "<div class=\"icon video\" data-src=\"" + fileName + "\"><i class=\"";
                    //div += "img-responsive fa fa-film";

                    div = "<div class=\"lightBoxGallery icon video\" > <a href=\"" + fileName + "\" type=\"video/mp4\" title=\"\" data-gallery=\"\">";
                    div += "<i class=\"img-responsive fa fa-film\"></i></a></div>";

                    break;

                case ".xls":
                case ".xlsx":
                    div = "<div class=\"icon\" data-src=\"" + fileName + "\"><a target=\"_blank\" href=\"" + GetYuLan(fileExtension, newName) + "\"><i class=\"fa fa-file-excel-o\"></i></div>";
                    break;


                case ".doc":
                case ".docx":
                    div = "<div class=\"icon\" data-src=\"" + fileName + "\"><a target=\"_blank\" href=\"" + GetYuLan(fileExtension, newName) + "\"><i class=\"fa fa-file-word-o\"></i></div>";
                    break;

                case ".ppt":
                case ".pptx":
                    div = "<div class=\"icon\" data-src=\"" + fileName + "\"><a target=\"_blank\" href=\"" + GetYuLan(fileExtension, newName) + "\"><i class=\"fa fa-file-powerpoint-o\"></i></div>";
                    break;


                default:
                    div += "fa fa-file";
                    div = "<div class=\"icon\" data-src=\"" + fileName + "\"><a target=\"_blank\" href=\"" + GetYuLan(fileExtension, newName) + "\"><i class=\"fa fa-file\"></i></div>";
                    break;
            }
            //div += "\"></i></div>";
        }
        return div;
    }


    protected string GetYuLan(string ext, string fileName)
    {
        string result = "";
        if (ext == ".xls" || ext == ".xlsx" || ext == ".doc" || ext == ".docx" || ext == ".ppt" || ext == ".pptx")
        {
            string host = HttpContext.Current.Request.Url.Host;
            string url = host + "/UploadFiles/" + fileName;
            url = HttpUtility.UrlEncode(url);
            result = "https://view.officeapps.live.com/op/view.aspx?src=" + url + "";
        }
        else if (ext == ".pdf")
        {
            result = "/UploadFiles/" + fileName;
        }
        else
        {
            result = "../DownLoad.ashx?name=" + fileName;
        }
        return result;
    }

    /// <summary>
    /// 检查列表权限
    /// </summary>
    /// <param name="tableName"></param>
    /// <returns></returns>
    protected bool CheckListPermission(string tableName)
    {
        if (AdminMethod.HasManage("admin") || AdminMethod.HasManage(tableName) || AdminMethod.HasManage("guanli") || AdminMethod.HasManage("cwsh") || AdminMethod.HasManage("caiwu"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected bool CheckDelPermission(string tableName, int adminID, int state)
    {
        //管理员可以删除，用户可以删除自己未审核的单子
        if (AdminMethod.HasManage("admin") || AdminMethod.HasManage("tableName"))
        {
            return true;
            // || AdminMethod.HasManage(tableName)
        }
        else if (AdminMethod.AdminID == adminID && state == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //protected string GetYuLan(string ext, string fileName)
    //{
    //    string result = "";
    //    if (ext == ".xls" || ext == ".xlsx" || ext == ".doc" || ext == ".docx" || ext == ".ppt" || ext == ".pptx")
    //    {
    //        string host = HttpContext.Current.Request.Url.Host;
    //        string url = host + "/UploadFiles/" + fileName;
    //        url = HttpUtility.UrlEncode(url);
    //        result = "<a target=\"_blank\" href=\"https://view.officeapps.live.com/op/view.aspx?src=" + url + "\">预览</a>";
    //    }
    //    return result;
    //}
}
