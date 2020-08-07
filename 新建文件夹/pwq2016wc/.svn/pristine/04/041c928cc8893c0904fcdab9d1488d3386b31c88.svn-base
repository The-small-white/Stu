using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;
using System.Web.Script.Serialization;

public partial class Plusbe2019_Admin_DeployDel : AdminPage
{
  
    protected void Page_Load(object sender, EventArgs e)
    {
        Result result = new Result();
        JavaScriptSerializer js = new JavaScriptSerializer();
        try
        {
            if (!string.IsNullOrEmpty(this.Request["id"]))
            {
                int id = Convert.ToInt32(Request["id"]);
                if (id == -1&&AdminMethod.AdminID==1)
                {
                    string sql = "Delete  ModeChannel where ID>0";
                    TableOperate<ModeChannel>.Execute(sql);
                    string sql1 = "Delete  Channel where ID>0";
                    TableOperate<Channel>.Execute(sql1);
                    string sql2 = "Delete  ChannelNews where ID>0";
                    TableOperate<ChannelNews>.Execute(sql2);
                    string sql3 = "Delete  CloudLog where ID>0";
                    TableOperate<CloudLog>.Execute(sql3);
                    string sql4 = "Delete  Pclist where ID>0";
                    TableOperate<Pclist>.Execute(sql4);
                    Response.Write("1");
                    return;
                }
            }
        }
        catch
        {
            Response.Write("0");
        }
     
    }
}