using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class Plusbe2019_Admin_TableManage_Manage : AdminAndPage
{
    protected List<ChannelNews> m_tableManageList;
    protected int PCID = 0;
    protected List<ModeChannel> m_ExhibitionList;
    protected void Page_Load(object sender, EventArgs e)
    {
        m_ExhibitionList = ModeChannelProvider.SelectAll();
        ChannelNews condition = new ChannelNews();
        ChannelNews value = new ChannelNews();
        string title = GetstringKey("name");
        PCID = GetIntKey("pcid");
        if (title != "")
        {
            condition.Title = "%" + title + "%";
            condition.AddAttach("Title", "like");
        }
        if (PCID != 0)
        {
            condition.ChannelID = PCID;
        }
        condition.ExhibitionID = AdminMethod.ExhibitionID;
        m_tableManageList = TableOperate<ChannelNews>.SelectByPage(value,condition, "order by  OrderID asc", PageSize, PageIndex, ref Count);
       
        DataBind();
        name.Value = title;
        

    }
    protected string GetStates(int States)
    {
        if (States == 1)
        {
            return "<span class=\"label label-primary\">展示</span>";
        }
        else
        {
            return "<span class=\"label label-danger\">停用</span>";

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