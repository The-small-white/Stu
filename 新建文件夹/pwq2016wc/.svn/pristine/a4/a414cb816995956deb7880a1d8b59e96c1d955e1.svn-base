using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class Plusbe2019_Admin_TableManage_Manage : AdminAndPage
{
    protected List<View_News> m_tableManageList;
    protected int TagID = 0;
    protected int ExhibitionID = 0;
    protected int Tmy = 0;
    protected int Counts = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        View_News condition = new View_News();
        View_News value = new View_News();
        string title = GetstringKey("name");
        TagID = GetIntKey("tagid");
        ExhibitionID = GetIntKey("ExhibitionID");
        Tmy = GetIntKey("t");
        if (title != "")
        {
            condition.Title = "%" + title + "%";
            condition.AddAttach("Title", "like");
        }
        if (TagID != 0)
        {
            condition.TagID = TagID;
        }
        if (ExhibitionID != 0)
        {
            condition.ExhibitionID = ExhibitionID;
        }
        if (Tmy != 0)
        {
            condition.AddID = AdminMethod.AdminID;
        }
        condition.TypeID = 1;
        m_tableManageList = TableOperate<View_News>.SelectByPage(value,condition, "order by  OrderID asc", PageSize, PageIndex, ref Count);
        Counts = Counts = TableOperate<View_News>.GetCountValue(condition); ;
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