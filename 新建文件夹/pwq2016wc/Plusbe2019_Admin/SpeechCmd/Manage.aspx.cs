using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class Plusbe2019_Admin_TableManage_Manage : AdminAndPage
{
    protected List<SpeechSend> m_tableManageList;
    protected int SpeechID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        SpeechSend condition = new SpeechSend();
        SpeechSend value = new SpeechSend();
        string title = GetstringKey("name");
        SpeechID = GetIntKey("SpeechID");
        if (title != "")
        {
            condition.Title = "%" + title + "%";
            condition.AddAttach("Title", "like");
        }

        condition.SpeechID = SpeechID;

        m_tableManageList = TableOperate<SpeechSend>.SelectByPage(value,condition, "order by  id desc", PageSize, PageIndex, ref Count);
       
        DataBind();
        name.Value = title;
        

    }
    protected string GetStates(int States)
    {
        if (States == 1)
        {
            return "<span class=\"label label-primary\">已审核</span>";
        }
        else
        {
            return "<span class=\"label label-danger\">未审核</span>";

        }
    }
    protected string GetShare(int States)
    {
        if (States == 1)
        {
            return "<span class=\"label label-primary\">已分享</span>";
        }
        else
        {
            return "<span class=\"label label-danger\">未分享</span>";

        }
    }
}