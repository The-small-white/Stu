using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class Plusbe2019_Admin_TableManage_Manage : AdminAndPage
{
    protected List<AgeType> m_tableManageList;
    protected void Page_Load(object sender, EventArgs e)
    {
        AgeType condition = new AgeType();
        AgeType value = new AgeType();
        string title = GetstringKey("name");
        if (title != "")
        {
            condition.AgeName = "%" + title + "%";
            condition.AddAttach("AgeName", "like");
        }
        condition.ExhibitionID = AdminMethod.ExhibitionID;
        m_tableManageList = TableOperate<AgeType>.SelectByPage(value, condition, "order by  OrderID asc", PageSize, PageIndex, ref Count);
       
        DataBind();
        name.Value = title;
        

    }
}