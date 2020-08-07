using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class Plusbe2019_Admin_TableManage_Manage : AdminAndPage
{
    protected List<TableManage> m_tableManageList;
    protected void Page_Load(object sender, EventArgs e)
    {
        TableManage condition = new TableManage();
        m_tableManageList = TableOperate<TableManage>.SelectByPage(condition, PageSize, PageIndex, ref Count);
        DataBind();
        
    }
}