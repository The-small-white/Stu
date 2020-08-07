using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class Plusbe2019_Admin_TableManage_Manage : AdminAndPage
{
    protected List<CloudLog> m_tableManageList;
    protected void Page_Load(object sender, EventArgs e)
    {
        CloudLog condition = new CloudLog();
        string title = GetstringKey("name");
        if (title != "")
        {
            condition.Brief = "%" + title + "%";
            condition.AddAttach("Brief", "like");
        }
        condition.ExhibitionID = AdminMethod.ExhibitionID;
        m_tableManageList = TableOperate<CloudLog>.SelectByPage(condition, PageSize, PageIndex, ref Count);
       
        DataBind();
        name.Value = title;
        

    }
}