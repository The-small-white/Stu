using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class Plusbe2019_Admin_TableManage_Manage : AdminAndPage
{
    protected List<SpeechKeyWord> m_tableManageList;
    protected void Page_Load(object sender, EventArgs e)
    {
        SpeechKeyWord condition = new SpeechKeyWord();
        SpeechKeyWord value = new SpeechKeyWord();
        string title = GetstringKey("name");
        if (title != "")
        {
            condition.KeyWords = "%" + title + "%";
            condition.AddAttach("KeyWords", "like");
        }
        condition.ExhibitionID = AdminMethod.ExhibitionID;
        m_tableManageList = TableOperate<SpeechKeyWord>.SelectByPage(value, condition, "order by  id desc", PageSize, PageIndex, ref Count);
       
        DataBind();
        name.Value = title;
        

    }
}