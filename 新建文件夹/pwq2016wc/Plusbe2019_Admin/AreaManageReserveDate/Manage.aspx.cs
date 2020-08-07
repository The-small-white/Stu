using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class Plusbe2019_Admin_TableManageReserveDate_Manage : AdminAndPage
{
    protected List<ReserveDate> m_tableManageList;
    protected void Page_Load(object sender, EventArgs e)
    {
        ReserveDate condition = new ReserveDate();
        ReserveDate value = new ReserveDate();
        string title = GetstringKey("name");
        if (title != "")
        {
            condition.Date = "%" + title + "%";
            condition.AddAttach("Date", "like");
        }
        condition.ExhibitionID = AdminMethod.ExhibitionID;
        m_tableManageList = TableOperate<ReserveDate>.SelectByPage(value, condition, "order by  OrderID asc", PageSize, PageIndex, ref Count);
       
        DataBind();
        name.Value = title;
        

    }
}