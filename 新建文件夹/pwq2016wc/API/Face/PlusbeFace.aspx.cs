using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class API_Face_FaceData : System.Web.UI.Page
{
    string msg = "{\"state\":\"false\", \"msg\":\"获取异常\"}";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string act = Convert.ToString(Request["act"]);
            int uid = Convert.ToInt32(Request["uid"]);

            if (act == "get")
            {
                UserFaceTime condition = new UserFaceTime();
                UserFaceTime vlaue = new UserFaceTime();
                condition.AddConditon("and DateDiff(dd,AddTime,getdate())=0");
                condition.UserID = uid;
                List<int> ZQlist = new List<int>();
                List<UserFaceTime> list = TableOperate<UserFaceTime>.Select(vlaue, condition, 0, "order by LastTime desc");
                #region 排序处理
                List<UserFaceTime> listtemp = new List<UserFaceTime>();
                for (int i = 0; i < list.Count; i++)
                {
                    bool find = false;
                    for (int j = 0; j < listtemp.Count; j++)
                    {
                        if (list[i].ZQID == listtemp[j].ZQID)
                        {
                            if (listtemp[j].Time < 10)
                            {
                                listtemp[j] = list[i];

                            }

                            find = true;
                        }
                    }
                    if (!find)
                        listtemp.Add(list[i]);
                }

                list = listtemp;
                list = list.OrderByDescending(s => s.LastTime).ToList<UserFaceTime>();

                #endregion
                msg = "{\"list\":[";
                for (int i = 0; i < list.Count; i++)
                {
                    TimeSpan t3 = list[i].LastTime - list[i].AddTime;
                    double time = t3.TotalMinutes;
                    msg += "{\"ID\":" + list[i].ID + ", \"UserID\":\"" + list[i].UserID + "\", \"AddTime\":\"" + list[i].AddTime + "\", \"LastTime\":\"" + list[i].LastTime + "\", \"Time\":\"" + time + "\", \"Zqid\":\"" + list[i].ZQID + "\", \"HeadImg\":\"" + list[i].HeadPic + "\"},";
                }
                msg = msg.Trim(',');
                msg += "]}";
            }
            else if (act == "user")
            {
                Userinfo condition = new Userinfo();
                Userinfo value = new Userinfo();
                //condition.AddConditon("and DateDiff(dd,LastModifyTime,getdate())=0");
                List<Userinfo> list = TableOperate<Userinfo>.Select(value, condition, 0, "order by LastModifyTime desc");
                msg = "{\"list\":[";
                for (int i = 0; i < list.Count; i++)
                {
                    msg += "{\"ID\":" + list[i].ID + ", \"HeadImg\":\"" + list[i].HeadImage + "\"},";
                }
                msg = msg.Trim(',');
                msg += "]}";
            }
            else if (act == "uptime")
            {
                UserFaceTime value = new UserFaceTime();
                UserFaceTime conditon = new UserFaceTime();
                conditon.ZQID = Convert.ToInt32(Request["zqid"]);
                conditon.UserID = uid;
                List<UserFaceTime>list=  TableOperate<UserFaceTime>.Select(value, conditon, 1, "order by LastTime desc");
                if (list.Count > 0)
                {
                    msg = "{\"state\":\"true\", \"LastTime\":\"" + list[0].LastTime + "\", \"msg\":\"请求成功\"}";
                }
                
                else
                {
                    msg = "{\"state\":\"false\",\"msg\":\"暂无数据\"}";
                }
            }
            else if (act == "zq")
            {

                msg = "{\"state\":\"true\", \"Area\":" + GetZQ() + ", \"msg\":\"请求成功\"}";

            }
            else
            {
                msg = "{\"state\":\"false\", \"msg\":\"查询失败\"}";
            }


        }
        catch (Exception ex)
        {
            msg = "{\"state\":\"false\", \"msg\":\"查询失败\"}";
        }



        Response.Write(msg);
    }
    /// <summary>
    /// 获取各展区的总时长
    /// </summary>
    /// <returns></returns>
    protected string GetZQ()
    {
        string str = "[";
        List<FaceHotArea> list = TableOperate<FaceHotArea>.Select();
        for (int i = 0; i < list.Count; i++)
        {
            str += "{\"ID\":\"" + list[i].ID + "\", \"Name\":\"" + list[i].Name + "\", \"Time\":\"" + list[i].Time + "\"},";

        }

        str = str.TrimEnd(',');
        str = str + "]";
        return str;
    }
}