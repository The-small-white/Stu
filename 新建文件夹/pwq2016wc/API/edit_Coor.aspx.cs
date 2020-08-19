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

public partial class API_edit_Coor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string act = "";
        if (!string.IsNullOrEmpty(Request["act"]))
        {
            act = Convert.ToString(Request["act"]);
        }
        // var id = int.Parse(Request.QueryString["ID"]);
        //var x = HttpUtility.UrlDecode(Request.Params["X"]);
        //var y = HttpUtility.UrlDecode(Request.Params["Y"]);
        switch (act)
        {
            //case "editlight"://编辑灯
            //    editlight(id, x, y);
            //    break;
            //case "editDevice"://编辑设备
            //    editDevice(id, x, y);
            //    break;


            case "GetParam"://编辑灯
                GetParam(Context);
                break;
        }
    }

    private void GetParam(HttpContext context)
    {
        HttpRequest requset = context.Request;
        var  ID =int.Parse( requset["ID"]);
        var  X = double.Parse(requset["X"]);
        var  Y = double.Parse(requset["Y"]);

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


    private void editlight(int ID, string X, string Y)
    {
        try
        {
            View_Light view_Light = new View_Light();
            view_Light.ID = ID;
            View_Light hot = TableOperate<View_Light>.GetRowData(view_Light);//查询是否存在
            if (hot.ID > 0)
            {
                if (Request.Params["X"] == null)
                {
                    X = null;
                }
                else
                {
                    X = HttpUtility.UrlDecode(Request.Params["X"]);
                    view_Light.X = double.Parse(X);
                }
                if (Request.Params["Y"] == null)
                {
                    Y = null;
                }
                else
                {
                    Y = HttpUtility.UrlDecode(Request.Params["Y"]);

                    view_Light.Y = double.Parse(Y);
                }
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
            else
            {
                Response.Write("\"errcode\":\"1\",\"msg\":\"无效参数\"");
            }
        }
        catch (Exception)
        {
            throw;
        }
        Response.End();
    }
    private void editDevice(int ID, string X, string Y)
    {
        try
        {
            View_Device condition = new View_Device();
            condition.ID = ID;
            View_Device hot = TableOperate<View_Device>.GetRowData(condition);//查询是否存在
            if (hot.ID > 0)
            {
                if (Request.Params["X"] == null)
                {
                    X = null;
                }
                else
                {
                    X = HttpUtility.UrlDecode(Request.Params["X"]);

                    condition.X = double.Parse(X);
                }
                if (Request.Params["Y"] == null)
                {
                    Y = null;
                }
                else
                {
                    Y = HttpUtility.UrlDecode(Request.Params["Y"]);

                    condition.Y = double.Parse(Y);
                }
                int mes = TableOperate<View_Device>.Update(condition);
                if (mes > 0)
                {
                    Response.Write("\"errcode\":\"0\",\"msg\":\"ok\"");
                }
                else
                {
                    Response.Write("\"errcode\":\"1\",\"msg\":\"false\"");
                }
            }
            else
            {
                Response.Write("\"errcode\":\"1\",\"msg\":\"无效参数\"");
            }
        }
        catch (Exception)
        {

            throw;
        }
        Response.End();


    }
}