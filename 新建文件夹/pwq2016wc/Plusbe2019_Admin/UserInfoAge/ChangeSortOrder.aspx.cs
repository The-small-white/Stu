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

        AgeType condition = new AgeType();
        AgeType v = new AgeType();
        if (ID==0)
        {
            Response.Write("");
            return;
        }

       condition.ID = ID;
        AgeType myView = TableOperate<AgeType>.GetRowData(v, condition);

        if (myView.ID == 0)
        {
            Response.Write("");
            return;
        }

        AgeType condition2 = new AgeType();
        AgeType V2 = new AgeType();
       condition2.AddConditon(" and ID<>'" + condition.ID + "'");
        condition2.ExhibitionID = AdminMethod.ExhibitionID;
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


       List<AgeType> desOrderMdl = TableOperate<AgeType>.Select(V2, condition2, 1, strOrder);
       if (desOrderMdl.Count != 1)
       {
           Response.Write("");
           return;
       }


        AgeType conditionU = new AgeType();
       conditionU.ID = myView.ID;
       conditionU.OrderID = desOrderMdl[0].OrderID;
       TableOperate<AgeType>.Update(conditionU);

        AgeType conditionU2 = new AgeType();
       conditionU2.ID = desOrderMdl[0].ID;
       conditionU2.OrderID = myView.OrderID;
       TableOperate<AgeType>.Update(conditionU2);
       Response.StatusCode = 200;
       Response.Write(conditionU2.ID);
       
    }
}