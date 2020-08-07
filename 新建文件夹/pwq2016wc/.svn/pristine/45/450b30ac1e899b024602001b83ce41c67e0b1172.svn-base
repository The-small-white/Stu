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
        try
        {
            if (!string.IsNullOrEmpty(this.Request["iD"]))
            {

                int iD = Convert.ToInt32(this.Request["iD"]);
            
                if (TableOperate<QuestionBank>.Delete(iD) > 0)
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
               
                int id = TableOperate<QuestionBank>.MultiDelete(checkshop);
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
       
        News condition = new News();
        News value = new News();
        condition.AddConditon(" and id in("+ ids + ")");
        List<News> list = TableOperate<News>.Select(value,condition);
        if (list.Count > 0)
        {
            CloudSQL.UpdataVesion(list[0].PcID);
            string deltitle = "";
            for (int i = 0; i < list.Count; i++)
            {
                CloudSQL.DeleteOldFile(list[i]);
                deltitle += list[i].Title+",";
            }
            deltitle = deltitle.TrimEnd(',');
            if (deltitle != "")
            {
                string logbrief = "管理员:【" + AdminMethod.AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "删除了资源【" + deltitle + "】";
                Lognet.AddLogin(logbrief);
            }
        }
      

       

    }
}
