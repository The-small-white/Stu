using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_API_APIClear : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sql = "truncate table peoplecount";
        SQL.ExecuteNonQuery(SQL.ConnectionStringProfile, System.Data.CommandType.Text, sql);

        Response.Write("true");
        Response.End();
    }
}