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
using System.Collections.Generic;
using Dejun.DataProvider;
using Dejun.DataProvider.Table;
using Dejun.DataProvider.Sql2005;

public partial class Admin_ManageNews_ChangeSortOrder : AdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string action = GetstringKey("action");
        int ID = GetIntKey("ID");
        int areaid = GetIntKey("areaid");
        View_Light condition = new View_Light();
        View_Light v = new View_Light();
        if (ID==0)
        {
            Response.Write("");
            return;
        }
       condition.ID = ID;
        View_Light myView = TableOperate<View_Light>.GetRowData(v, condition);

        if (myView.ID == 0)
        {
            Response.Write("");
            return;
        }
        View_Light condition2 = new View_Light();
        View_Light V2 = new View_Light();
       condition2.AddConditon(" and ID<>'" + condition.ID + "'");
       string strOrder = string.Empty;
       condition2.OrderID = myView.OrderID;
        if (areaid != 0)
        {
            condition2.AreaID = areaid;
        }
        condition2.ExhibitionID = AdminMethod.ExhibitionID;
       if (action == "up")
       {
           //向上，现在是时间越早越在上面
           condition2.AddAttach("OrderID", "<");
           strOrder = " order by OrderID  DESC";  //时间从大到小
       }
       else
       {
           condition2.AddAttach("OrderID", ">");
           strOrder = " order by OrderID ASC";
       }
       List<View_Light> desOrderMdl = TableOperate<View_Light>.Select(V2, condition2, 1, strOrder);
       if (desOrderMdl.Count != 1)
       {
           Response.Write("");
           return;
       }
       Light conditionU = new Light();
       conditionU.ID = myView.ID;
       conditionU.OrderID = desOrderMdl[0].OrderID;
       TableOperate<Light>.Update(conditionU);

        Light conditionU2 = new Light();
       conditionU2.ID = desOrderMdl[0].ID;
       conditionU2.OrderID = myView.OrderID;
       TableOperate<Light>.Update(conditionU2);
       Response.StatusCode = 200;
       Response.Write(conditionU2.ID);
       
    }
}