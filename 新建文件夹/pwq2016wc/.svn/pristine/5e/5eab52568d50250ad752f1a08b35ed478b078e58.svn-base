using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System;
using System.Web.Script.Serialization;
using System.Collections.Generic;


public partial class Admin_ManageTableManage_Delete : AdminPage
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
                AddLog(iD + "");
                if (TableOperate<Admin_User>.Delete(iD) > 0)
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
                AddLog(checkshop);
                int id = TableOperate<Admin_User>.MultiDelete(checkshop);
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
    protected void AddLog(string ids)
    {

        Admin_User condition = new Admin_User();
        Admin_User value = new Admin_User();
        condition.AddConditon(" and id in(" + ids + ")");
        List<Admin_User> list = TableOperate<Admin_User>.Select(value, condition);
        if (list.Count > 0)
        {
            string deltitle = "";
            for (int i = 0; i < list.Count; i++)
            {
                deltitle += list[i].Name + ",";
            }
            deltitle = deltitle.TrimEnd(',');
            if (deltitle != "")
            {
                string logbrief = "管理员:【" + AdminMethod.AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "删除了【" + deltitle + "】的管理员";
                Lognet.AddLogin(logbrief);
            }
        }




    }
}
