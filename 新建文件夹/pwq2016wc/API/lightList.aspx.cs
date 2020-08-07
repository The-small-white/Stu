using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Dejun.DataProvider.Table;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class lightList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Light v = new Light();
        Light condition = new Light();

        if (string.IsNullOrEmpty(this.Request["seviceID"]))
        {
            return;
        }
        int SeviceID = Convert.ToInt32(this.Request["seviceID"]);
        string sn = RequestString.NoHTML(Convert.ToString(this.Request["sn"]));
        if (!SysConfig.IsTrueSn(SeviceID, sn))
        {
            string error = "加密不正确"; Response.Write(error); return;

        }
        condition.ExhibitionID = SeviceID;
        condition.State = 1;
        List<Light> m_lightList = TableOperate<Light>.Select(v, condition, 0, " order by OrderID asc ");
        string json = "{\"list\":[";
        for (int i = 0; i < m_lightList.Count; i++)
        {
            json += "{\"id\":" + m_lightList[i].ID + ", \"name\":\"" + m_lightList[i].Title +
                "\", \"AreaID\":" + m_lightList[i].AreaID + ", \"state\":"+m_lightList[i].State+", \"SwitchIP\":\"" +
                m_lightList[i].SwitchIP + "\", \"SwitchPort\":" + m_lightList[i].SwitchPort + ", \"SwitchIndex\":" + m_lightList[i].SwitchIndex + ", \"SwitchGroup\":" + m_lightList[i].SwitchGroup + "},";
        }
        json = json.Trim(',');
        json += "]}";

        Response.Write(json);
    }
}
