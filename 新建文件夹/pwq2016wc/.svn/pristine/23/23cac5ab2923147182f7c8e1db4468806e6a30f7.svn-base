using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;

/// <summary>
/// EmailStmp 的摘要说明
/// </summary>
public class EmailStmp
{
    public EmailStmp()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    #region 发送邮件
    /// <summary>
    /// 发送邮件
    /// </summary>
    /// <param name="email"></param>
    /// <param name="emailMix"></param>
    public static Boolean SendEmail(string email, string strBody, string strTitle)
    {
        if (string.IsNullOrEmpty(email)) return false;

        if (email.IndexOf("@") == -1) return false;




        return true;

    }
    #endregion 发送取回密码邮件

    #region 发送邮件接口
    /// <summary>
    /// 发送邮件接口
    /// </summary>
    /// <param name="strSmtpServer">邮件服务器，例如：mail.mycompany.com</param>
    /// <param name="strFrom">用来发送邮件的email，例如：you@yourcompany.com</param>
    /// <param name="strFromPass">用来发送邮件的rmail密码</param>
    /// <param name="strto">发送地址email</param>
    /// <param name="strSubject">邮件标题</param>
    /// <param name="strBody">邮件内容</param>
    protected static Boolean SendSMTPEMail(string strSmtpServer, string strFrom, string strFromPass, string strto, string strSubject, string strBody)
    {
        //       mail.To = "me@mycompany.com"; 
        //mail.From = "you@yourcompany.com"; 
        //SmtpMail.SmtpServer = "mail.mycompany.com";  
        try
        {
            System.Net.Mail.SmtpClient client = new SmtpClient(strSmtpServer);
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(strFrom, strFromPass);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            System.Net.Mail.MailMessage message = new MailMessage(strFrom, strto, strSubject, strBody);
            //System.Net.Mail.MailMessage message = new MailMessage(strFrom, strto);
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;

            client.Send(message);
        }
        catch 
        {
        }
        return true;
    }
    #endregion 发送邮件接口
}
