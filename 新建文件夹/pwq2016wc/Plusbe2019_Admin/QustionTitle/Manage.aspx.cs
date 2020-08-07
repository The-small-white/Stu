using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class Plusbe2019_Admin_TableManage_Manage : AdminAndPage
{
    protected List<QuestionType> m_ExhibitionList;
    protected List<View_Question> m_tableManageList;
    protected int PCID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        m_ExhibitionList = QusetionProvider.SelectAll();
        View_Question condition = new View_Question();
        View_Question value = new View_Question();
        string title = GetstringKey("name");
        PCID = GetIntKey("pcid");
        if (title != "")
        {
            condition.Title = "%" + title + "%";
            condition.AddAttach("Title", "like");
        }
        if (PCID != 0)
        {
            condition.TypeID = PCID;
        }
        condition.ExhibitionID = AdminMethod.ExhibitionID;
        m_tableManageList = TableOperate<View_Question>.SelectByPage(value,condition, "order by  OrderID asc", PageSize, PageIndex, ref Count);
       
        DataBind();
        name.Value = title;
        

    }
}