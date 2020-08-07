using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;

public partial class Admin_ManageNews_ChangeSortOrder : AdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string action = GetstringKey("action");



        int ID = GetIntKey("ID");

        ReserveDate condition = new ReserveDate();
        ReserveDate v = new ReserveDate();
        if (ID==0)
        {
            Response.Write("");
            return;
        }

       condition.ID = ID;
        ReserveDate myView = TableOperate<ReserveDate>.GetRowData(v, condition);

        if (myView.ID == 0)
        {
            Response.Write("");
            return;
        }

        ReserveDate condition2 = new ReserveDate();
        ReserveDate V2 = new ReserveDate();
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


       List<ReserveDate> desOrderMdl = TableOperate<ReserveDate>.Select(V2, condition2, 1, strOrder);
       if (desOrderMdl.Count != 1)
       {
           Response.Write("");
           return;
       }


        ReserveDate conditionU = new ReserveDate();
       conditionU.ID = myView.ID;
       conditionU.OrderID = desOrderMdl[0].OrderID;
       TableOperate<ReserveDate>.Update(conditionU);

        ReserveDate conditionU2 = new ReserveDate();
       conditionU2.ID = desOrderMdl[0].ID;
       conditionU2.OrderID = myView.OrderID;
       TableOperate<ReserveDate>.Update(conditionU2);
       Response.StatusCode = 200;
       Response.Write(conditionU2.ID);
       
    }
}