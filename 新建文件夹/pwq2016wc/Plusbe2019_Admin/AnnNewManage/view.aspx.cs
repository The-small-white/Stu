using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class Plusbe2019_Admin_AnnNewManage_view : AdminPage
{
    protected List<AnnNews> m_tableManageList;
    protected void Page_Load(object sender, EventArgs e)
    {
        AnnNews condition = new AnnNews();
        AnnNews value = new AnnNews();
        m_tableManageList = TableOperate<AnnNews>.Select(value, condition,0, "ORDER BY IsZD DESC, IsHot DESC, ID DESC");
        DataBind();
    }
}