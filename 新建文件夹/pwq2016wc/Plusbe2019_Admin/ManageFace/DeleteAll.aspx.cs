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


            if (!string.IsNullOrEmpty(this.Request["all"]))
            {
                Del();
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
    private void Del()
    {
        string sql1 = " Delete  UserFaceTime where ID>0 ";
        TableOperate<UserFaceTime>.Execute(sql1);
        string sql2 = " Delete  Userinfo where ID>0 ";
         TableOperate<Userinfo>.Execute(sql2);
        string sql3 = " Delete  Face where ID>0 ";
        TableOperate<Face>.Execute(sql3);
        string url = "http://127.0.0.1:5478/?act=restart";
        string str = HttpHelp.Get(url);
    }
}
