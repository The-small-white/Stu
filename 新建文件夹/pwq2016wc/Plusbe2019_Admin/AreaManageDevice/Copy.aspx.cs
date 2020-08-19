using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;


public partial class Admin_AreaManageLight_Copy : AdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Result result = new Result();
        JavaScriptSerializer js = new JavaScriptSerializer();
        try
        {

            int ID = GetIntKey("id");
            Device condition = new Device();
            condition.ID = ID;
            Device light = TableOperate<Device>.GetRowData(condition);
            if (light.ID > 0)
            {
                Device newlight = new Device();

                newlight = light;
                // newlight.NoID();2020/08/17
                newlight.Name = light.Name + "-复制";
                newlight.AddTime = DateTime.Now;
                newlight.AddID = AdminMethod.AdminID;
                newlight.ExhibitionID = AdminMethod.ExhibitionID;
                newlight.OrderID = CloudSQL.GetNowTime();
                int Sid = TableOperate<Device>.InsertReturnID(newlight);
                if (Sid > 0)
                {
                    result.isOk = true;
                }

            }





        }
        catch (Exception ex)
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

        Light condition = new Light();
        Light value = new Light();
        condition.AddConditon(" and id in(" + ids + ")");
        List<Light> list = TableOperate<Light>.Select(value, condition);
        if (list.Count > 0)
        {
            string deltitle = "";
            for (int i = 0; i < list.Count; i++)
            {
                deltitle += list[i].Title + ",";
            }
            deltitle = deltitle.TrimEnd(',');
            if (deltitle != "")
            {
                string logbrief = "管理员:【" + AdminMethod.AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "删除了【" + deltitle + "】的灯光";
                Lognet.AddLogin(logbrief);
            }
        }




    }
}
