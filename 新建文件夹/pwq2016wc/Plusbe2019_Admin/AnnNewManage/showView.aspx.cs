using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;

public partial class Plusbe2019_Admin_AnnNewManage_showView : AdminPage
{
    protected AnnNews news = new AnnNews();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.Request["iD"]))
        {

            int _iD = Convert.ToInt32(this.Request["iD"]);
            AnnNews condition = new AnnNews();
            condition.ID = _iD;
            news = TableOperate<AnnNews>.GetRowData(condition);
           
        }
        DataBind();
    }
}