using System;
using System.Collections.Generic;
using Dejun.DataProvider.Table;
using Dejun.DataProvider.Sql2005;

public partial class API_ExhibitionDate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.Request["seviceID"]))
        {
            return;
        }
        int SeviceID = Convert.ToInt32(this.Request["seviceID"]);
        string sn = RequestString.NoHTML(Convert.ToString(this.Request["sn"]));
        if (!SysConfig.IsTrueSn(SeviceID, sn))
        {
            string error = "加密不正确"; Response.Write(error); return;

        }
        ExhibitionOpen condition = new ExhibitionOpen();
        condition.ExhibitionID = SeviceID;
        condition.AddTime = DateTime.Now;
        int Sid= TableOperate<ExhibitionOpen>.InsertReturnID(condition);
        if (Sid > 0)
        {
            Response.Write("true");return;
        }
    }
}