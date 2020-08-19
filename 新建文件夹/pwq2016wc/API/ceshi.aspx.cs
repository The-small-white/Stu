using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class API_ceshi : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        GetParam(Context);
     
    }
    
    private void GetParam(HttpContext context)
    {
        HttpRequest requset = context.Request;
       
        var ID = int.Parse(requset["ID"]);
        var X = double.Parse(requset["X"]);
        var Y = double.Parse(requset["Y"]);

        View_Light view_Light = new View_Light();
        View_Light V = new View_Light();
        V.ID = ID;
        view_Light.ID = ID;
        view_Light.X = X;
        view_Light.Y = Y;
        View_Light hot = TableOperate<View_Light>.GetRowData(V);//查询是否存在
        if (hot.ID > 0)
        {

            int mes = TableOperate<View_Light>.Update(view_Light);
            if (mes > 0)
            {
                Response.Write("\"errcode\":\"0\",\"msg\":\"ok\"");
            }
            else
            {
                Response.Write("\"errcode\":\"1\",\"msg\":\"false\"");
            }
        }


    }
    public List<View_Light> JsonToList(string str)
    {
        //str = "{\"User\":[{\"Name\":\"Sony\",\"Age\":7},{\"Name\":\"Samsumg\",\"Age\":14},{\"Name\":\"LG\",\"Age\":21},{\"Name\":\"Vizio\",\"Age\":34},{\"Name\":\"Insignia\",\"Age\":24}]}";
        JavaScriptSerializer json = new JavaScriptSerializer();
        var list = json.DeserializeObject(str) as IDictionary<string, object>;
        var groups = (from s in (IEnumerable<object>)list["View_Light"]
                      let i = s as IDictionary<string, object>
                      where i != null
                      select new View_Light()
                      {
                          ID = (int)i["ID"],
                          X = (int)i["X"],
                          Y = (int)i["Y"]

                      }).ToList();
        return groups;
    }
}