

<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using LitJson;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public class Handler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/json";


        string json = context.Request["list"];
        List<View_Light> list = null;
        try
        {
            list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<View_Light>>(json);
            View_Light view_Light = new View_Light();
            View_Light V = new View_Light();

            int ID = int.Parse(list.Count.ToString("ID"));
            V.ID = ID;


            View_Light hot = TableOperate<View_Light>.GetRowData(V);//查询是否存在
            if (hot.ID > 0)
            {
                int mes = TableOperate<View_Light>.Update(view_Light);
            }
        }
        catch (Exception ex)
        {

        }

        var result = new
        {
            count = list == null ? 0 : list.Count(),
        };
        context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(result));
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}










    