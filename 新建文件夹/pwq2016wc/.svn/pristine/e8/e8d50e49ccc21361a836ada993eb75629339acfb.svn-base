using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class Plusbe2019_Admin_TableManage_Manage : AdminAndPage
{
    protected List<AnnNews> m_tableManageList;
    protected string t = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        AnnNews  condition = new AnnNews();
        AnnNews value = new AnnNews();
        string title = GetstringKey("name");
        t = GetstringKey("t");
        if (t != "")
        {
            condition.AddID = AdminMethod.AdminID;
        }
        if (title != "")
        {
            condition.Title = "%" + title + "%";
            condition.AddAttach("Title", "like");
        }
        m_tableManageList = TableOperate<AnnNews>.SelectByPage(value,condition, "ORDER BY IsZD DESC, IsHot DESC, ID DESC", PageSize, PageIndex, ref Count);
       
        DataBind();
        name.Value = title;
        

    }
    protected string Sub(string brief, int leng)
    {
        if (brief.Length > leng)
        {
            brief = brief.Substring(0, leng) + "...";
        }
        return brief;
    }
}