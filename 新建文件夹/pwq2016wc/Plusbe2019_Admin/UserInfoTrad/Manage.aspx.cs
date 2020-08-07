using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class Plusbe2019_Admin_TableManage_Manage : AdminAndPage
{
    protected List<TrdType> m_tableManageList;
    protected void Page_Load(object sender, EventArgs e)
    {
        TrdType condition = new TrdType();
        TrdType value = new TrdType();
        string title = GetstringKey("name");
        if (title != "")
        {
            condition.TradeType = "%" + title + "%";
            condition.AddAttach("TradeType", "like");
        }
        condition.ExhibitionID = AdminMethod.ExhibitionID;
        m_tableManageList = TableOperate<TrdType>.SelectByPage(value, condition, "order by  OrderID asc", PageSize, PageIndex, ref Count);
       
        DataBind();
        name.Value = title;
        

    }
}