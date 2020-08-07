using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;

public partial class Plusbe2019_Admin_CloudNews_view : AdminPage
{
    protected News news = new News();
    protected void Page_Load(object sender, EventArgs e)
    {
        int _ID = GetIntKey("iD");
        if (_ID != 0)
        {
            News condition = new News();
            condition.ID = _ID;
            news = TableOperate<News>.GetRowData(condition);
            if (news.ID > 0)
            {
                if (news.FileType == 4)
                {
                    Bing(news.Files);

                }
            }
        }
        DataBind();
    }
    protected void Bing(string picString)
    {
        string[] picArry = picString.Split('|');
        pic.DataSource = picArry;
        pic.DataBind();

    }
}