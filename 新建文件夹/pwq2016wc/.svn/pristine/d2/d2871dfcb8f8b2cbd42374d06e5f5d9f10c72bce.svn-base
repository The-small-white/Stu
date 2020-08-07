using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class Plusbe2019_Admin_TableManage_Manage : AdminAndPage
{
    protected List<SpeechTitle> m_tableManageList;
    protected int AreaID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        SpeechTitle condition = new SpeechTitle();
        string title = GetstringKey("name");
       
        condition.ExhibitionID = AdminMethod.ExhibitionID;
        if (title != "")
        {
            condition.Key_Word = "%" + title + "%";
            condition.AddAttach("Key_Word", "like");
        }
        m_tableManageList = TableOperate<SpeechTitle>.SelectByPage(condition, PageSize, PageIndex, ref Count);
       
        DataBind();
        name.Value = title;
        

    }

   
}