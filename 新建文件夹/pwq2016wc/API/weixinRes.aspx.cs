using System;
using System.Collections.Generic;
using Dejun.DataProvider.Table;
using Dejun.DataProvider.Sql2005;

public partial class Reserve_weixinRes : System.Web.UI.Page
{
    string json = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.Request["seviceID"]))
        {
            return;
        }
        if (string.IsNullOrEmpty(this.Request["sn"]))
        {
            return;
        }
        int SeviceID = Convert.ToInt32(this.Request["seviceID"]);
        string sn = RequestString.NoHTML(Convert.ToString(this.Request["sn"]));
        if (!SysConfig.IsTrueSn(SeviceID, sn))//对比加密后是否对照
        {
            json = "{\"state\":\"false\", \"msg\":\"加密错误\"}";

        }
        else
        {
            string act = "";
            act = RequestString.NoHTML(Convert.ToString(Request["act"]));
            string openid = Convert.ToString(RequestString.NoHTML(this.Request["openid"]));
            if (act == "insert")
            {
                string name = RequestString.NoHTML(Convert.ToString(this.Request["name"]));
                string phone = RequestString.NoHTML(Convert.ToString(this.Request["phone"]));
                int count = Convert.ToInt32(RequestString.NoHTML(this.Request["count"]));
                int exid = Convert.ToInt32(RequestString.NoHTML(this.Request["exid"]));
                int DateType = Convert.ToInt32(Request["datetype"]);
                
                DateTime restime = Convert.ToDateTime(Request["restime"]);
                int DateAllCount = GetAllCount(DateType);//根据ID查询是否已经有过记录
                if (count > DateAllCount)
                {
                    json = "{\"state\":\"false\", \"msg\":\"人数超过最大参观人数\"}";

                }
                else
                {
                    ReserveMsg msg = new ReserveMsg();
                    msg.ReserveCount = count;
                    msg.DateType = DateType;
                    msg.ExhibitionID = exid;
                    msg.OpenID = openid;
                    msg.ReservePhone = phone;
                    msg.ReserveTime = restime;
                    msg.ReserveName = name;
                    msg.States = 0;
                    int id = TableOperate<ReserveMsg>.InsertReturnID(msg);//将预约数据插入并返回
                    if (id > 0)
                    {
                        json = "{\"state\":\"true\", \"msg\":\"预约成功！\"}";
                    }
                    else
                    {
                        json = "{\"false\":\"true\", \"msg\":\"预约失败！\"}";
                    }
                }
            }
            else if (act == "selectdate")
            {
                int DateType = Convert.ToInt32(Request["datetype"]);
                DateTime restime = Convert.ToDateTime(Request["restime"]);
                ReserveMsg condition = new ReserveMsg();
                condition.AddConditon("DateDiff(dd,ReserveTime,'"+ restime + "')=0");//添加时间条件
                condition.DateType = DateType;
                condition.States = 1;
                int count = TableOperate<ReserveMsg>.GetCountValue(condition);//查询获取总数
                if (count > 0)
                {
                    json = "{\"false\":\"true\", \"msg\":\"今日预约已满！\"}";
                }

            }
            else if (act == "my")
            {
                View_Reserve condition = new View_Reserve();
                View_Reserve value = new View_Reserve();
                condition.OpenID = openid;
                List<View_Reserve> list = TableOperate<View_Reserve>.Select(value,condition,0,"order by addtime desc");

            }
        }
      
        Response.Write(json); return;


    }
    protected int GetAllCount(int ID)
    {
        ReserveDate condition = new ReserveDate();
        condition.ID = ID;
        return TableOperate<ReserveDate>.GetRowData(condition).Count;
    }
   
}