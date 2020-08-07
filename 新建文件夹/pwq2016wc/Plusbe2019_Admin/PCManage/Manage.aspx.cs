using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class Plusbe2019_Admin_TableManage_Manage : AdminAndPage
{
    protected List<View_PCList> m_tableManageList;
    protected int AreaID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        View_PCList condition = new View_PCList();
        string title = GetstringKey("name");
        AreaID = GetIntKey("AreaID");
        if (AreaID != 0)
        {
            condition.AreaID = AreaID;
        }
        condition.ExhibitionID = AdminMethod.ExhibitionID;
        if (title != "")
        {
            condition.Title = "%" + title + "%";
            condition.AddAttach("Title", "like");
        }
        m_tableManageList = TableOperate<View_PCList>.SelectByPage(condition, PageSize, PageIndex, ref Count);
       
        DataBind();
        name.Value = title;
        

    }
    protected string GetStates(int ID)
    {
        for (int i = 0; i < m_tableManageList.Count; i++)
        {
            if (m_tableManageList[i].ID == ID)
            {
                if (m_tableManageList[i].LastTime.ToString() == "0001/1/1 0:00:00")
                {
                    return "<span class=\"label label-danger\">离线</span>";
                }
                TimeSpan span = DateTime.Now - m_tableManageList[i].LastTime;
                if (span.Minutes < 5)
                {
                    return "<span class=\"label label-primary\">在线</span>";
                }

            }
        }
        return "<span class=\"label label-danger\">离线</span>";

    }
   
}