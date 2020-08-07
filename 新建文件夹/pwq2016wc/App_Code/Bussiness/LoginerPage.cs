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
public class LoginerPage : System.Web.UI.Page
{
    public LoginerPage()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    #region 事件处理
    protected override void OnInit(EventArgs e)
    {
        if (User.Identity.IsAuthenticated == false)
        {
            string err = "请您先登录，谢谢！！";
            err = RequestString.EncodeString(err);
            //.
            Response.Redirect("Login.aspx?returnUrl="+this.Request.Url+"&error=" + err);
        }
        base.OnInit(e);

    }
    #endregion 事件处理



}
