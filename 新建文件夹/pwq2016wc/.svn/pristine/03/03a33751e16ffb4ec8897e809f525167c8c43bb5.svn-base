using System;
using Dejun.DataProvider.Table;
using Dejun.DataProvider.Sql2005;

public partial class ExeVersion : System.Web.UI.Page
{
    string json = "false";
    protected void Page_Load(object sender, EventArgs e)
    {
        int v = 0;
        if (!string.IsNullOrEmpty(Request["v"]))
        {
            v = Convert.ToInt32(Request["v"]);
        }
        GlobalConfig condition = new GlobalConfig();
        condition.ID = 1;
        GlobalConfig config = TableOperate<GlobalConfig>.GetRowData(condition);
        if (config.ID > 0)
        {
            if (config.Version != v)
            {
                json = config.Version+"";
            }
        }
        Response.Write(json);
        
    }
}