using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class Plusbe2019_Admin_TableManage_Manage : AdminAndPage
{
    protected List<IBeaconDev> m_tableManageList;
    protected void Page_Load(object sender, EventArgs e)
    {
        IBeaconDev condition = new IBeaconDev();
        IBeaconDev value = new IBeaconDev();
        string title = GetstringKey("name");
        if (title != "")
        {
            condition.BeaconMac = "%" + title + "%";
            condition.AddAttach("BeaconMac", "like");
        }
        condition.ExhibitionID = AdminMethod.ExhibitionID;
        m_tableManageList = TableOperate<IBeaconDev>.SelectByPage(value, condition, "order by  id asc", PageSize, PageIndex, ref Count);
       
        DataBind();
        name.Value = title;
        

    }
}