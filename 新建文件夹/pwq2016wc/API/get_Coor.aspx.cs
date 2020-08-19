using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class API_get_Coor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string act = "";
        int AreaID = 0;
        if (!string.IsNullOrEmpty(Request["act"]))
        {
            act = Convert.ToString(Request["act"]);
        }
        switch (act)
        {
            case "getlight"://获取灯
                getlight(AreaID);
                break;
            case "getDevice"://获取设备
                getDevice(AreaID);
                break;
        }

    }
    private void getlight(int AreaID)
    {
        View_Light value = new View_Light();
        View_Light condition = new View_Light();

        if (!string.IsNullOrEmpty(this.Request["AreaID"]))
        {
            AreaID = Convert.ToInt32(Request["AreaID"]);
            condition.ID = AreaID;
        }
        List<View_Light> list = TableOperate<View_Light>.SelectByIdDesc(value, condition);
        string json = "{\"list\":[";
        for (int i = 0; i < list.Count; i++)
        {
            json += "{\"ID\":" + list[i].ID + ",  \"X\":\"" + list[i].X + "\", \"Y\":\"" + list[i].Y + "\", \"AreaID\":" + list[i].AreaID + "},";
        }
        json = json.Trim(',');
        json += "]}";
        Response.Write(json);
    }
    private void getDevice(int AreaID)
    {
        View_Device value = new View_Device();
        View_Device condition = new View_Device();
        if (!string.IsNullOrEmpty(this.Request["AreaID"]))
        {
            AreaID = Convert.ToInt32(Request["AreaID"]);
            condition.ID = AreaID;
        }
        List<View_Device> list = TableOperate<View_Device>.SelectByIdDesc(value, condition);
        string json = "{\"list\":[";
        for (int i = 0; i < list.Count; i++)
        {
            json += "{\"ID\":" + list[i].AreaID + ",  \"X\":\"" + list[i].X + "\", \"Y\":\"" + list[i].Y + "\", \"AreaID\":" + list[i].AreaID + "},";
        }
        json = json.Trim(',');
        json += "]}";
        Response.Write(json);
    }



}