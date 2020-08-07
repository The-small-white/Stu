using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;

public partial class Admin_ManageNews_ChangeSortOrder : AdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string action = GetstringKey("action");
        int ID = GetIntKey("ID") ;
        int Tid = GetIntKey("tid");
        int areaid = GetIntKey("areaid");
        View_Device condition = new View_Device();
        View_Device v = new View_Device();
        if (ID==0)
        {
            Response.Write("");
            return;
        }

        condition.ID = ID;
        View_Device myView = TableOperate<View_Device>.GetRowData(v, condition);

        if (myView.ID == 0)
        {
            Response.Write("");
            return;
        }

        View_Device condition2 = new View_Device();
        View_Device V2 = new View_Device();
       condition2.AddConditon(" and ID<>'" + condition.ID + "'");
       condition2.ExhibitionID= AdminMethod.ExhibitionID;
       condition2.TypeID = Tid;
        if (areaid != 0)
        {
            condition2.AreaID = areaid;
        }
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


       List<View_Device> desOrderMdl = TableOperate<View_Device>.Select(V2, condition2, 1, strOrder);
       if (desOrderMdl.Count != 1)
       {
           Response.Write("");
           return;
       }


       Device conditionU = new Device();
       conditionU.ID = myView.ID;
       conditionU.OrderID = desOrderMdl[0].OrderID;
       TableOperate<Device>.Update(conditionU);

        Device conditionU2 = new Device();
       conditionU2.ID = desOrderMdl[0].ID;
       conditionU2.OrderID = myView.OrderID;
       TableOperate<Device>.Update(conditionU2);
      
       Response.StatusCode = 200;
       Response.Write(conditionU2.ID);
       
    }
}