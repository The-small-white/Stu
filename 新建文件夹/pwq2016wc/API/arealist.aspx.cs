using System;
using System.Collections.Generic;
using Dejun.DataProvider.Table;
using Dejun.DataProvider.Sql2005;


public partial class Arealist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (string.IsNullOrEmpty(this.Request["seviceID"]))
        {
            return;
        }
        if (string.IsNullOrEmpty(this.Request["sn"]))
        {
            return;
        }
        int SeviceID = Convert.ToInt32(this.Request["seviceID"]);
        string sn = RequestString.NoHTML(Convert.ToString(this.Request["sn"]));
        if (!SysConfig.IsTrueSn(SeviceID, sn))
        {
            string error = "加密不正确"; Response.Write(error);return;
            
        }
        Area v = new Area();
        Area condition = new Area();
        condition.ExhibitionID = SeviceID;
        List<Area> m_lightList = TableOperate<Area>.Select(v, condition, 0, " order by OrderID asc ");
        string json = "{\"list\":[";
        for (int i = 0; i < m_lightList.Count; i++)
        {
            json += "{\"id\":" + m_lightList[i].ID + ", \"name\":\"" + m_lightList[i].AreaName + "\"},";
        }
        json = json.Trim(',');
        json += "]}";

        Response.Write(json);
    }
}