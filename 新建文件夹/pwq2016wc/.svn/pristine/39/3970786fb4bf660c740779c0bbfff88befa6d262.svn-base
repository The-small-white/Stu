using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class Plusbe2019_Admin_TableManage_Manage : AdminAndPage
{
    protected List<IPWhite> m_tableManageList;
    protected void Page_Load(object sender, EventArgs e)
    {
        IPWhite condition = new IPWhite();
        string title = GetstringKey("name");
        if (title != "")
        {
            condition.IP = "%" + title + "%";
            condition.AddAttach("IP", "like");
        }
        m_tableManageList = TableOperate<IPWhite>.SelectByPage(condition, PageSize, PageIndex, ref Count);
       
        DataBind();
        name.Value = title;
        

    }
    protected string GetStates(int States)
    {
        if (States == 1)
        {
            return "<span class=\"label label-primary\">启用</span>";
        }
        else
        {
            return "<span class=\"label label-danger\">停用</span>";

        }
    }
}