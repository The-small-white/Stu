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
        
        bool isUp= false;

     
        string ID = Request["ID"];

        View_News condition = new View_News();
        View_News v = new View_News();
        if (string.IsNullOrEmpty(ID))
        {
            Response.Write("");
            return;
        }

       condition.ID = Convert.ToInt32(ID);
       View_News myView = TableOperate<View_News>.GetRowData(v, condition);

        if (myView.ID == 0)
        {
            Response.Write("");
            return;
        }

        View_News condition2 = new View_News();
        View_News V2 = new View_News();
       condition2.AddConditon(" and ID<>'" + condition.ID + "'");
       condition2.PcID= myView.PcID;
       string strOrder = string.Empty;
       condition2.OrderID = myView.OrderID;
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


       List<View_News> desOrderMdl = TableOperate<View_News>.Select(V2, condition2, 1, strOrder);
       if (desOrderMdl.Count != 1)
       {
           Response.Write("");
           return;
       }


       News conditionU = new News();
       conditionU.ID = myView.ID;
       conditionU.OrderID = desOrderMdl[0].OrderID;
       TableOperate<News>.Update(conditionU);

       News conditionU2 = new News();
       conditionU2.ID = desOrderMdl[0].ID;
       conditionU2.OrderID = myView.OrderID;
       TableOperate<News>.Update(conditionU2);
        CloudSQL.UpdataVesion(myView.PcID);
       Response.StatusCode = 200;
       Response.Write(conditionU2.ID);
       
    }
}