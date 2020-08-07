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
            act = RequestString.NoHTML(act);
            if (act == "insert")

            {
                string name = Convert.ToString(RequestString.NoHTML(Request["name"]));
                string nickname = Convert.ToString(RequestString.NoHTML(Request["nickname"]));
                string phone = Convert.ToString(RequestString.NoHTML(Request["phone"]));
                int sex = Convert.ToInt32(Request["sex"]);
                int hy = Convert.ToInt32(Request["hy"]);
                int faceid = Convert.ToInt32(Request["faceid"]);
                if (IsHave(phone))
                {
                    msg = "{\"state\":\"false\", \"msg\":\"手机号已被注册\"}";
                }
                else
                {
                    Userinfo condition = new Userinfo();
                    condition.Name = name;
                    condition.NickName = nickname;
                    condition.Gender = sex;
                    condition.TradeID = hy;
                    condition.Phone = phone;
                    int id = TableOperate<Userinfo>.InsertReturnID(condition);
                    if (id > 0)
                    {
                        Face face = new Face();
                        face.ID = faceid;
                        face.UserinfoID = id;
                        TableOperate<Face>.Update(face);
                        msg = "{\"state\":\"true\", \"msg\":\"注册成功\"}";
                    }
                    else
                    {
                        msg = "{\"state\":\"false\", \"msg\":\"注册失败\"}";
                    }

                }


            }
            else if (act == "add")
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
                        condition.NowDayCount = 0;
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
        }
        Response.Write(msg);
    }
    private bool IsHave(string phone)
    {
        Userinfo condition = new Userinfo();
        condition.Phone = phone;
        int id = TableOperate<Userinfo>.GetCountValue(condition);
        if (id > 0)
        {
            return true;
        }
        return false;

    }
}