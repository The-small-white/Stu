using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;



public partial class Admin_ManageTableManage_Delete : AdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Result result = new Result();
        JavaScriptSerializer js = new JavaScriptSerializer();
        int States = GetIntKey("states");
        int iD = GetIntKey("iD");
        string checkshop = GetstringKey("checkshop");
        int Sid = 0;
        if (checkshop != "" && States != 0)
        {
            if (States == -1)
            {
                Sid = TableOperate<Mailbox>.MultiDelete(checkshop);
            }
            else
            {
                string sql = "update Mailbox set States="+States+" where id in("+checkshop+")";
                Sid= TableOperate<Mailbox>.Execute(sql);
            }
        }
        if (Sid > 0)
        {

            result.isOk = true;

        }
        else
        {
            result.msg = "删除失败";
        }

        Response.ContentType = "text/json";
        Response.Write(js.Serialize(result));
        Response.End();
    }
   
}
