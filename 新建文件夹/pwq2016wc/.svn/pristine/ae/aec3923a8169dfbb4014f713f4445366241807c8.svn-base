using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System;

public partial class UserJson : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string act = "";
        string msg = "";
        if (!string.IsNullOrEmpty(Request["act"]))
        {
            act = Convert.ToString(Request["act"]);
           
            if (act == "insert")

            {
                string height = Convert.ToString(RequestString.NoHTML(Request["height"]));
                string weight = Convert.ToString(RequestString.NoHTML(Request["weight"]));
                string cardNum = Convert.ToString(RequestString.NoHTML(Request["num"]));
                
                int faceid = Convert.ToInt32(Request["faceid"]);
                if (!string.IsNullOrEmpty(Request["userid"]))
                {
                    int userid = Convert.ToInt32(Request["userid"]);
                    IBeaconDev condition = new IBeaconDev();
                    condition.IcMac = cardNum;
                    IBeaconDev dev = TableOperate<IBeaconDev>.GetRowData(condition);
                    if (dev.ID > 0)
                    {
                        condition.UserID = userid;
                        condition.ID = dev.ID;
                        TableOperate<IBeaconDev>.Update(condition);

                        Userinfo userinfo = new Userinfo();
                        userinfo.ID = userid;
                        Userinfo user = TableOperate<Userinfo>.GetRowData(userinfo);
                        if (user.ID > 0)
                        {
                            userinfo.TradeID = user.TradeID + 1;
                            userinfo.AddTime = DateTime.Now;
                            TableOperate<Userinfo>.Update(userinfo);
                            msg = "{\"state\":\"true\", \"msg\":\"IC卡绑定成功\"}";
                            AddCount();
                        }
                      
                    }
                }
                else
                {


                    IBeaconDev condition = new IBeaconDev();
                    condition.IcMac = cardNum;
                    IBeaconDev dev = TableOperate<IBeaconDev>.GetRowData(condition);
                    if (dev.ID > 0)
                    {
                        Userinfo conditions = new Userinfo();
                        conditions.Name = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                        conditions.NickName = weight;
                        conditions.Phone = height;
                        conditions.AddTime = DateTime.Now;
                        conditions.TradeID = 1;
                        int userid = TableOperate<Userinfo>.InsertReturnID(conditions);
                        if (userid > 0)
                        {
                            Face face = new Face();
                            face.ID = faceid;
                            face.UserinfoID = userid;
                            TableOperate<Face>.Update(face);
                            condition.UserID = userid;
                            condition.ID = dev.ID;
                            TableOperate<IBeaconDev>.Update(condition);
                            msg = "{\"state\":\"true\", \"msg\":\"注册成功\"}";
                            AddCount();

                        }
                        else
                        {
                            msg = "{\"state\":\"false\", \"msg\":\"注册失败\"}";
                        }
                    }
                    else
                    {
                        msg = "{\"state\":\"false\", \"msg\":\"IC卡不存在\"}";
                    }
                }

            }
            else if (act == "check")
            {
                string cardNum = Convert.ToString(RequestString.NoHTML(Request["num"]));
                IBeaconDev condition = new IBeaconDev();
                condition.IcMac = cardNum;
                IBeaconDev dev = TableOperate<IBeaconDev>.GetRowData(condition);
                if (dev.ID > 0)
                {
                    if (dev.UserID > 0)
                    {
                        msg = "{\"state\":\"true\", \"msg\":\"该卡已绑定\", \"code\":\"1\"}";
                    }
                    else
                    {
                        msg = "{\"state\":\"true\", \"msg\":\"该卡未绑定\", \"code\":\"0\"}";
                    }
                    
                }
                else
                {
                    msg = "{\"state\":\"false\", \"msg\":\"该卡不存在\", \"code\":\"2\"}";
                }


                //int faceid = Convert.ToInt32(Request["faceid"]);
                //Face face = new Face();
                //face.ID = faceid;
                //Face faces = TableOperate<Face>.GetRowData(face);
                //if (faces.ID > 0 && face.UserinfoID > 0)
                //{
                //    Userinfo conditions = new Userinfo();
                //    conditions.ID = face.UserinfoID;
                //    Userinfo userinfo = TableOperate<Userinfo>.GetRowData(conditions);
                //    if (userinfo.ID > 0)
                //    {
                //        msg = "{\"state\":\"true\", \"ID\":\"" + userinfo.ID + "\", \"height\":\"" + userinfo.Name + "\", \"weight\":\"" + userinfo.NickName + "\", \"msg\":\"查询成功\"}";
                //    }
                //    else
                //    {
                //        msg = "{\"state\":\"false\", \"msg\":\"用户不存在\"}";
                //    }

                //}
                //else
                //{
                //    msg = "{\"state\":\"false\", \"msg\":\"未查询到该用户\"}";
                //}

            }
        }
        Response.Write(msg);
    }
   
    /// <summary>
    /// 人数统计
    /// </summary>
    private void AddCount()
    {
        UserVistCount condition = new UserVistCount();
        condition.ID = 1;
        UserVistCount user = TableOperate<UserVistCount>.GetRowData(condition);
        if (user.ID > 0)
        {
            if (user.AddTime.Date == DateTime.Now.Date)
            {
                condition.NowDayCount = user.NowDayCount + 1;

            }
            else
            {
                condition.NowDayCount = 1;
            }
            condition.AddTime = DateTime.Now;
            condition.Count = user.Count + 1;
            condition.ID = user.ID;
            TableOperate<UserVistCount>.Update(condition);
        }
        else
        {
            condition.AddTime = DateTime.Now;
            condition.NowDayCount = 1;
            condition.Count = 1;
            TableOperate<UserVistCount>.Insert(condition);
        }
    }
    private bool IsHave(string num)
    {
        IBeaconDev condition = new IBeaconDev();
        condition.IcMac = num;
        int id = TableOperate<IBeaconDev>.GetCountValue(condition);
        if (id > 0)
        {
            return true;
        }
        return false;

    }
}