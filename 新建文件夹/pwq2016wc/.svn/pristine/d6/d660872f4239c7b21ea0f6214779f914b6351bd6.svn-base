using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class Plusbe2019_Admin_TableManage_Manage : AdminAndPage
{
    protected List<IBeaconGateWay> m_tableManageList;
    protected void Page_Load(object sender, EventArgs e)
    {
        IBeaconGateWay condition = new IBeaconGateWay();
        IBeaconGateWay value = new IBeaconGateWay();
        string title = GetstringKey("name");
        if (title != "")
        {
            condition.MAC = "%" + title + "%";
            condition.AddAttach("MAC", "like");
        }
        condition.ExhibitionID = AdminMethod.ExhibitionID;
        m_tableManageList = TableOperate<IBeaconGateWay>.SelectByPage(value, condition, "order by  id desc", PageSize, PageIndex, ref Count);
       
        DataBind();
        name.Value = title;
        

    }
}