using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using FaceBai;
using LitJson;
using System.Web;

public partial class Admin_ManageUserinfo_Delete : AdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Result result = new Result();
        JavaScriptSerializer js = new JavaScriptSerializer();
        try
        {

            if (!string.IsNullOrEmpty(this.Request["iD"]))
            {

                int iD = Convert.ToInt32(this.Request["iD"]);
                if (TableOperate<FaceLog>.Delete(iD) > 0)
                {
                    result.isOk = true;

                }
                else
                {
                    result.msg = "删除失败";
                }



            }
            else if (!string.IsNullOrEmpty(this.Request["checkshop"]))
            {
                string checkshop = Convert.ToString(this.Request["checkshop"]);
                checkshop = RequestString.NoHTML(checkshop);
                int id = TableOperate<FaceLog>.MultiDelete(checkshop);
                if (id > 0)
                {
                    result.isOk = true;

                }
                else
                {
                    result.msg = "删除失败";
                }


            }
            else if (!string.IsNullOrEmpty(this.Request["all"]))
            {
                string sql = " Delete  FaceLog where ID>0 ";
                int id = TableOperate<FaceLog>.Execute(sql);
                if (id > 0)
                {
                    result.isOk = true;

                }
                else
                {
                    result.msg = "删除失败";
                }
            }

        }
        catch(Exception ex)
        {
            result.isOk = false;
            result.msg = ex.ToString();
        }
     
        Response.ContentType = "text/json";
        Response.Write(js.Serialize(result));
        Response.End();
    }
}
