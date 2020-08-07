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
                result.isOk=AddLog(iD + "");
              
                result.msg = "删除失败";
                
                   

            }
            else if (!string.IsNullOrEmpty(this.Request["checkshop"]))
            {
                string checkshop = Convert.ToString(this.Request["checkshop"]);
                checkshop = RequestString.NoHTML(checkshop);
                result.isOk=AddLog(checkshop);
            
                result.msg = "删除失败";
                

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
    protected bool AddLog(string ids)
    {
        bool IsDelete = true;
        Face condition = new Face();
        Face value = new Face();
        condition.AddConditon(" and id in(" + ids + ")");
        List<Face> list = TableOperate<Face>.Select(value, condition);
        if (list.Count > 0)
        {
            string deltitle = "";
            for (int i = 0; i < list.Count; i++)
            {
               
                deltitle += list[i].UserinfoID + ",";
                CloudSQL.DeleteFace(list[i].HeadImage);
                IsDelete = IsDelete&&Delete(list[i].ID);
            }
            deltitle = deltitle.TrimEnd(',');
            if (deltitle != "")
            {
                string logbrief = "管理员:【" + AdminMethod.AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "删除了【" + deltitle + "】的用户头像";
                Lognet.AddLogin(logbrief);
            }
            
        }
        return IsDelete;



    }
    private bool Delete(int _iD)
    {
        string json = "{\"type\":\"delete\", \"file\":\"\",\"id\":" + _iD + "}";
        json = json.Replace("\\", "/");
        string url = string.Format("http://127.0.0.1:5478/?json={0}", HttpUtility.UrlEncode(json));
        string str = HttpHelp.Get(url);
        JsonData DataList = JsonMapper.ToObject(str);
        string state = DataList["state"].ToString();
        if (state == "true")
        {
            return true;
        }
        return false;
    }
}
