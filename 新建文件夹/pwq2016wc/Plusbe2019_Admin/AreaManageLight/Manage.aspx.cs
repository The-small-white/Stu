using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class Plusbe2019_Admin_AreaManageLight_Manage : AdminAndPage
{
    protected Light news = new Light();
    protected List<View_Light> m_tableManageList;
    protected int AreaID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        string title = GetstringKey("name");
        View_Light condition = new View_Light();
        View_Light value = new View_Light();
        AreaID = GetIntKey("AreaID");
        if (AreaID != 0)
        {
            condition.AreaID = AreaID;
        }

        if (title != "")
        {
            condition.Title = "%" + title + "%";
            condition.AddAttach("Title", "like");
        }
        condition.ExhibitionID = AdminMethod.ExhibitionID;

        m_tableManageList = TableOperate<View_Light>.SelectByPage(value, condition, "order by  OrderID asc", PageSize, PageIndex, ref Count);
       
        DataBind();
        name.Value = title;
        

    }
    
    protected string GetStates(int States)
    {
        if (States == 1)
        {
            return "<span class=\"label label-primary\">启用</span>";
        }
        else
        {
            return "<span class=\"label label-danger\">停用</span>";

        }
    }


}