using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class Plusbe2019_Admin_TableManage_Manage : AdminAndPage
{
    protected List<News> m_tableManageList;
    protected void Page_Load(object sender, EventArgs e)
    {
        News condition = new News();
        string title = GetstringKey("name");
        if (title != "")
        {
            condition.Title = "%" + title + "%";
            condition.AddAttach("Title", "like");
        }
        m_tableManageList = TableOperate<News>.SelectByPage(condition, PageSize, PageIndex, ref Count);
       
        DataBind();
        
        

    }
}