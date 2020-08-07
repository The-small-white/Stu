using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class Plusbe2019_Admin_AreaManageDevice_Manage : AdminAndPage
{
    protected Device news = new Device();
    protected int AreaID = 0;
    protected List<View_Device> m_tableManageList;
    protected int TypeID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        View_Device condition = new View_Device();
        View_Device value = new View_Device();
        TypeID = GetIntKey("tid");
        AreaID = GetIntKey("AreaID");
        if (AreaID != 0)
        {
            condition.AreaID = AreaID;
        }
        string title = GetstringKey("name");

        if (title != "")
        {
            condition.Name = "%" + title + "%";
            condition.AddAttach("Name", "like");
        }
        condition.ExhibitionID = AdminMethod.ExhibitionID;
        condition.TypeID = TypeID;
        m_tableManageList = TableOperate<View_Device>.SelectByPage(value, condition, "order by  OrderID asc", PageSize, PageIndex, ref Count);
        tid.Value = TypeID + "";
        name.Value = title;
        DataBind();
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