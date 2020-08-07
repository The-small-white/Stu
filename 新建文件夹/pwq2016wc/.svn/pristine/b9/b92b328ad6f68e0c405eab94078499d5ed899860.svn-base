using Dejun.DataProvider.Sql2000;
using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class API_Tips : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(Request["act"]))
            {
                string act = Convert.ToString(Request["act"]);
                if (act == "get")
                {
                    Area v = new Area();
                    Area condition = new Area();
                    List<Area> m_lightList = TableOperate<Area>.Select(v, condition, 0, " order by OrderID asc ");
                    string json = "{\"list\":[";
                    for (int i = 0; i < m_lightList.Count; i++)
                    {
                        json += "{\"id\":" + m_lightList[i].ID + ", \"name\":\"" + m_lightList[i].AreaName + "\", \"Tips\":\"" + m_lightList[i].Brief + "\"},";
                    }
                    json = json.Trim(',');
                    json += "]}";
                    Response.Write(json);
                }
                else if (act == "edit")
                {
                    int _ID = Convert.ToInt32(Request["id"]);
                    string Brief = Convert.ToString(Request["brief"]);
                    Area v = new Area();
                    Area condition = new Area();
                    condition.ID = _ID;
                    v = TableOperate<Area>.GetRowData(condition);
                    if (v.ID > 0)
                    {
                        condition.Brief = Brief;
                        condition.ID = v.ID;
                        TableOperate<Area>.Update(condition);
                        string msg = "{\"state\":\"true\", \"msg\":\"修改成功\"}";
                        Response.Write(msg);
                    }
                    else
                    {
                        string msg = "{\"state\":\"false\", \"msg\":\"ID不存在\"}";
                        Response.Write(msg);
                    }

                }
            }
        }
        catch
        {
            string msg = "{\"state\":\"false\", \"msg\":\"请求异常！\"}";
            Response.Write(msg);
        }
     
    }
}