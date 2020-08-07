using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System;
using System.IO;
using System.Web.Script.Serialization;
using TemplateEngine;



public partial class Admin_ManageTableManage_Delete : AdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Result result = new Result();
        JavaScriptSerializer js = new JavaScriptSerializer();
        if (string.IsNullOrEmpty(this.Request["iD"]))
        {
            result.msg = "请选择要删除的对象";

        }
        else
        {
            int iD = Convert.ToInt32(this.Request["iD"]);
            TableManage condition = new TableManage();
            condition.ID = iD;
            TableManage tableManage = TableOperate<TableManage>.GetRowData(condition);
            BuildSqlTable.DelTable(tableManage.EnglishName);
            string buildModePath = Request.PhysicalApplicationPath + "\\App_Code\\DataProvider\\Table";

            string newFileName = buildModePath + "\\" + StringDeal.HeadUpper(tableManage.EnglishName) + ".cs";

            if (File.Exists(newFileName))
            {
                File.Delete(newFileName);
            }

            string buildPath = Request.PhysicalApplicationPath + "\\Admin\\Manage" + StringDeal.HeadUpper(tableManage.EnglishName);
            if (Directory.Exists(buildPath))
            {
                Directory.Delete(buildPath, true);
            }

            if (TableOperate<TableManage>.Delete(iD) > 0)
                result.isOk = true;
            else
                result.msg = "删除失败";
        }
        Response.ContentType = "text/json";
        Response.Write(js.Serialize(result));
        Response.End();
    }
}
