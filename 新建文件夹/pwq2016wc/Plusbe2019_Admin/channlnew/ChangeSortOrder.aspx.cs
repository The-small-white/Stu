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
        string ID = Request["ID"];

        ChannelNews condition = new ChannelNews();
        ChannelNews v = new ChannelNews();
        if (string.IsNullOrEmpty(ID))
        {
            Response.Write("");
            return;
        }

       condition.ID = Convert.ToInt32(ID);
        ChannelNews myView = TableOperate<ChannelNews>.GetRowData(v, condition);

        if (myView.ID == 0)
        {
            Response.Write("");
            return;
        }

        ChannelNews condition2 = new ChannelNews();
        ChannelNews V2 = new ChannelNews();
       condition2.AddConditon(" and ID<>'" + condition.ID + "'");
       condition2.ChannelID= myView.ChannelID;
     
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


       List<ChannelNews> desOrderMdl = TableOperate<ChannelNews>.Select(V2, condition2, 1, strOrder);
       if (desOrderMdl.Count != 1)
       {
           Response.Write("");
           return;
       }


        ChannelNews conditionU = new ChannelNews();
       conditionU.ID = myView.ID;
       conditionU.OrderID = desOrderMdl[0].OrderID;
       TableOperate<ChannelNews>.Update(conditionU);

        ChannelNews conditionU2 = new ChannelNews();
       conditionU2.ID = desOrderMdl[0].ID;
       conditionU2.OrderID = myView.OrderID;
       TableOperate<ChannelNews>.Update(conditionU2);
      
       Response.StatusCode = 200;
       Response.Write(conditionU2.ID);
       
    }
}