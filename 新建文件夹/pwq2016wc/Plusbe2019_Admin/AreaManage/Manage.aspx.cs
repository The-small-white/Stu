using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class Plusbe2019_Admin_TableManage_Manage : AdminAndPage
{
    protected List<Area> m_tableManageList;
    protected void Page_Load(object sender, EventArgs e)
    {
        Area condition = new Area();
        Area value = new Area();
        string title = GetstringKey("name");
        if (title != "")
        {
            condition.AreaName = "%" + title + "%";
            condition.AddAttach("AreaName", "like");
        }
        condition.ExhibitionID = AdminMethod.ExhibitionID;
        m_tableManageList = TableOperate<Area>.SelectByPage(value, condition, "order by  OrderID asc", PageSize, PageIndex, ref Count);
       
        DataBind();
        name.Value = title;
        

    }
}