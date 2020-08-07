using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;

public partial class Plusbe2019_Admin_WebSiteSet : AdminPage
{
    protected GlobalConfig config = new GlobalConfig();
    private string _FileType;  // 允许上传文件的类型。
    private string _FileDir;  // 文件存储位置。
    private string _UploadInfo;  // 文件上传的返回信息。
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = GetstringKey("action");
        if (!string.IsNullOrEmpty(this.Request["ext"]))
        {
            #region 初始参数变量
            //初始参数
            _FileDir = "/";
            _FileType = ".exe";
            string datepath = _FileDir;//存储路径
            #endregion
            #region 前期 文件类型大小判断
            int intFileExtPoint = Request.Files[0].FileName.LastIndexOf("."); //存储最后一个 . 号的位置
            string strFileExtName = Request.Files[0].FileName.Substring(intFileExtPoint + 1).ToLower();  // 获取要上传的文件的后缀名。
            if (_FileType != "*")
            {
                if (_FileType.ToLower().IndexOf(strFileExtName.ToLower().Trim()) == -1)  // 判断要上传的文件类型的是否在允许的范围内。
                {
                    _UploadInfo = "不允许上传的文件类型(允许的类型：" + _FileType + ")";
                    Response.Write("{\"status\" : 0,\"chunked\" : false, \"hasError\" : true, \"f_ext\" : \"" + _UploadInfo + "\"}");
                    return;  // 返回文件上传状态和信息
                }
            }
            #endregion
            Request.Files[0].SaveAs(Server.MapPath("~/" + "ZkplayTemp" + "." + Request["ext"]));
            Response.Write("{\"status\":1, \"path\": \"" + "/" + "ZkplayTemp" + Request["ext"] + "\",\"chunked\" : false, \"hasError\" : false, \"f_ext\" : \"" + "ZkplayTemp" + Request["ext"] + "\"}");
            Response.End();
        }
        else if (action == "Ver")
        {
             Result result = new Result();
            GlobalConfig newChannelNews = new GlobalConfig();
            newChannelNews.ID = 0;
            newChannelNews.Version = Convert.ToInt32(this.Request["index"])+1;
            newChannelNews.AutoForm(this.Page);
            int _iD=0;
            if (!string.IsNullOrEmpty(this.Request["iD"]))
            {
                _iD = Convert.ToInt32(this.Request["iD"]);
                TableOperate<GlobalConfig>.Update(newChannelNews);
                result.msg = "更新成功";
            }
            if (_iD > 0)
            {
                result.isOk = true;
               
            }
            else
            {
                result.msg = "更新失败";
            }
            Response.ContentType = "text/json";
            Response.Write(new JavaScriptSerializer().Serialize(result));
            Response.End();
        }
        else if (action != "save")
        {
            GlobalConfig condition = new GlobalConfig();
            condition.ID = 1;
            config = TableOperate<GlobalConfig>.GetRowData(condition);
            DataBind();
        }
        else
        {
            Result result = new Result();
            GlobalConfig newChannelNews = new GlobalConfig();
            newChannelNews.ID = 0;
            newChannelNews.AutoForm(this.Page);
            int _iD=0;
            if (!string.IsNullOrEmpty(this.Request["iD"]))
            {
                _iD = Convert.ToInt32(this.Request["iD"]);
                TableOperate<GlobalConfig>.Update(newChannelNews);
                result.msg = "设置成功";
            }
            if (_iD > 0)
            {
                result.isOk = true;
               
            }
            else
            {
                result.msg = "操作失败";
            }
            Response.ContentType = "text/json";
            Response.Write(new JavaScriptSerializer().Serialize(result));
            Response.End();
        }
    }
}