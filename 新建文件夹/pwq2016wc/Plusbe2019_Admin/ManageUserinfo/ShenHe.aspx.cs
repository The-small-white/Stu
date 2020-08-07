using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System;
using System.Web.Script.Serialization;
using System.Collections.Generic;


public partial class Admin_ManageUserinfo_Delete : AdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Result result = new Result();
        JavaScriptSerializer js = new JavaScriptSerializer();
        try
        {

             if (!string.IsNullOrEmpty(this.Request["checkshop"]))
            {
                string checkshop = Convert.ToString(this.Request["checkshop"]);
                checkshop = RequestString.NoHTML(checkshop);
                string sql = " update Userinfo set State=1 WHERE id in (" + checkshop + ") ";
                int id = TableOperate<Userinfo>.Execute(sql);
                if (id > 0)
                {
                    result.isOk = true;
                  
                }
                else
                {
                    result.msg = "设置失败";
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
    protected void AddLog(string ids)
    {

        Userinfo condition = new Userinfo();
        Userinfo value = new Userinfo();
        condition.AddConditon(" and id in(" + ids + ")");
        List<Userinfo> list = TableOperate<Userinfo>.Select(value, condition);
        if (list.Count > 0)
        {
            string deltitle = "";
            for (int i = 0; i < list.Count; i++)
            {
                CloudSQL.DeleteFace(list[i].HeadImage);
                deltitle += list[i].Name + ",";
            }
            deltitle = deltitle.TrimEnd(',');
            if (deltitle != "")
            {
                string logbrief = "管理员:【" + AdminMethod.AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "删除了【" + deltitle + "】的用户";
                Lognet.AddLogin(logbrief);
            }
        }




    }
}
