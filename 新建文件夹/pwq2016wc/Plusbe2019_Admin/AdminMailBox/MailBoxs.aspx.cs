using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class Plusbe2019_Admin_MailBoxs : AdminAndPage
{
    protected List<Mailbox> list;
    protected void Page_Load(object sender, EventArgs e)
    {
        Mailbox condition = new Mailbox();
        string title = GetstringKey("msg");
        if (title != "")
        {
            condition.Msg = "%" + title + "%";
            condition.AddAttach("Msg", "like");
        }
        condition.ReceiveID = AdminMethod.AdminID;
        Mailbox value = new Mailbox();
        list = TableOperate<Mailbox>.SelectByPage(value,condition, "order by  States asc", PageSize, PageIndex, ref Count);
       
        DataBind();
        msg.Value = title;
    }
    protected string GetStates(Mailbox mailbox)
    {
        if (mailbox.States == 0)
        {
            //<span class="label label-warning pull-right">验证邮件</span>
            return "<span id=\"box_"+mailbox.ID+"\" class=\"label label-warning pull-right\">未读</span>";
        }
        else if (mailbox.States == 2)
        {
            return "<span class=\"label label-danger\">重点</span>";

        }
        else
        {
            return "";
        }
    }
}