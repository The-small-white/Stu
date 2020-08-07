using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

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
                string sql = " Delete  FaceLog where ID >0 ";
                TableOperate<FaceLog>.Execute(sql);
                
                 result.isOk = true;

               
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
        string str = "";
        Userinfo condition = new Userinfo();
        condition.State = 0;
        Userinfo value = new Userinfo();
        List<Userinfo> list = TableOperate<Userinfo>.Select(value,condition);
        if (list.Count > 0)
        {
            for (int i = 0; i < list.Count; i++)
            {
                str += list[i].ID + ",";
            }
            if (str != "")
            {
                str = str.Trim(',');
           
                string sql1 = " Delete  UserFaceTime where UserID  in (" + str + ") ";
                TableOperate<UserFaceTime>.Execute(sql1);
                string sql2 = " Delete  Userinfo where State=0 ";
                TableOperate<Userinfo>.Execute(sql2);
                string sql3 = " Delete  Face where UserinfoID in (“+str+”) ";
                TableOperate<Face>.Execute(sql3);
                string url = "http://127.0.0.1:5477/?json=restart";
                HttpHelp.Get(url);
            }
        }
      
        
        
    }
}
