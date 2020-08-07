using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class Plusbe2019_Admin_TableManageReserveMsg_Manage : AdminAndPage
{
    protected List<View_Reserve> m_tableManageList;
    protected void Page_Load(object sender, EventArgs e)
    {
        View_Reserve condition = new View_Reserve();
        View_Reserve value = new View_Reserve();
        string title = GetstringKey("name");
        string phones = GetstringKey("phone");
        if (title != "")
        {
            condition.ReserveName = "%" + title + "%";
            condition.AddAttach("ReserveName", "like");
        }
        if (phones != "")
        {
            condition.ReservePhone = "%" + phones + "%";
            condition.AddAttach("ReservePhone", "like");
        }
        condition.ExhibitionID = AdminMethod.ExhibitionID;
        m_tableManageList = TableOperate<View_Reserve>.SelectByPage(value, condition, "order by  ReserveTime desc", PageSize, PageIndex, ref Count);
        
       
        DataBind();
        name.Value = title;
        phone.Value = phones;
        

    }
    protected string GetStates(int States)
    {
        if (States == 1)
        {
            return "<span class=\"label label-primary\">已审核</span>";
        }
        else if (States == -1)
        {
            return "<span class=\"label label-danger\">已拒绝</span>";

        }
        else
        {
            return "<span class=\"label label-warning\">未审核</span>";
        }
    }
}