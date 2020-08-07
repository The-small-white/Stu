using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Plusbe2019_Admin_index : AdminPage
{
    protected List<View_PCList> m_tableManageList;
    protected string MsgCount ="";
    protected void Page_Load(object sender, EventArgs e)
    {
        int count = CloudSQL.GetMsg().Count;
        if (count > 0)
        {
            MsgCount = count+"";
        }
        View_PCList condition = new View_PCList();
        View_PCList value = new View_PCList();
        condition.ExhibitionID = AdminMethod.ExhibitionID;
        m_tableManageList = TableOperate<View_PCList>.Select(value,condition);
        DataBind();

    }
}