using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class Plusbe2019_Admin_TableManage_Manage : AdminAndPage
{
    protected List<View_AdminUser> m_tableManageList;
    protected void Page_Load(object sender, EventArgs e)
    {
        View_AdminUser condition = new View_AdminUser();
        string title = GetstringKey("name");
        if (AdminMethod.AdminLevel != 2)
        {
            
            condition.ExhibitionID = AdminMethod.ExhibitionID;
            condition.AddConditon("and UserLevel< 2");
        }
       
       
        
        if (title != "")
        {
            condition.FullName = "%" + title + "%";
            condition.AddAttach("FullName", "like");
        }
        m_tableManageList = TableOperate<View_AdminUser>.SelectByPage(condition, PageSize, PageIndex, ref Count);
       
        DataBind();
        name.Value = title;
        

    }
    protected string GetStates(int States)
    {
        if (States == 1)
        {
            return "<span class=\"label label-primary\">正常</span>";
        }
        else
        {
            return "<span class=\"label label-danger\">锁定</span>";
            
        }
    }
}