using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class Plusbe2019_Admin_Contacts : AdminPage
{
    protected List<View_AdminUser> list;
    protected void Page_Load(object sender, EventArgs e)
    {

        list = TableOperate<View_AdminUser>.Select();
        DataBind();
    }
}