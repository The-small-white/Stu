using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using LitJson;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;

public partial class API_NewFace : System.Web.UI.Page
{
    string msg = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!string.IsNullOrEmpty(this.Request["act"]))
        {
            string act = Convert.ToString(Request["act"]);
            if (act == "select" || act == "insert" || act == "auto")
            {
                string headimg = Convert.ToString(Request["pic"]);//传入base64图片编码格式
                int Aid = Convert.ToInt32(Request["aid"]);
                if (headimg != "" && headimg != null)
                {
                    headimg = headimg.Replace("data:image/png;base64,", "").Replace("data:image/jgp;base64,", "").Replace("data:image/jpg;base64,", "").Replace("data:image/jpeg;base64,", "");//将base64头部信息替换
                    string strbaser64 = headimg.Replace(" ", "+");//https://www.cnblogs.com/jueye/archive/2012/07/02/Url.html
                    string path = Request.MapPath("/UserFacePic");
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
                    string filePath = Path.Combine(path, fileName);
                    string headpic = "UserFacePic/" + fileName;
                    bool IsSave = ToImg(strbaser64, filePath);
                    if (IsSave)
                    {
                        string json = "{\"type\":\"" + act + "\", \"file\":\"" + filePath + "\",\"id\":0}";
                        json = json.Replace("\\", "/");
                        string url = string.Format("http://127.0.0.1:5478/?json={0}", HttpUtility.UrlEncode(json));
                        string str = HttpHelp.Get(url);
                        if (str != null)
                        {
                            JsonData DataList = JsonMapper.ToObject(str);
                            string state = DataList["state"].ToString();
                            if (act == "select"||act=="auto")
                            {
                                if (state == "true")
                                {
                                    string qualityStr =Convert.ToString(DataList["quality"]);
                                    double quality = Convert.ToDouble(qualityStr);
                                    int returnid = (int)DataList["returnid"];
                                    if (returnid > 0)
                                    {
                                        Face condition = new Face();
                                        condition.ID = returnid;
                                        Face user = TableOperate<Face>.GetRowData(condition);
                                        if (user.ID > 0)
                                        {
                                            msg = "{\"state\":\"true\", \"msg\":\"人脸查询成功\", \"userid\":" + user.UserinfoID + ", \"quality\":\"" + quality + "\",\"code\":\"1\"}";
                                            Up(user.UserinfoID);
                                            UpTime(user.UserinfoID, Aid, quality, headpic, filePath);//更新数据

                                        }
                                        else
                                        {
                                            msg = "{\"state\":\"false\", \"msg\":\"未查询到用户\", \"userid\":0, \"quality\":\"0\",\"code\":\"1\"}";
                                        }
                                    }
                                }
                                else
                                {
                                    msg = str;
                                }
                            }
                            else if (act == "insert")
                            {
                                msg = str;
                            }
                        }
                        else
                        {
                            msg = "{\"state\":\"false\", \"msg\":\"人脸服务未开启\", \"code\":\"-5\"}";
                        }

                    }
                    else
                    {
                        msg = "{\"state\":\"false\", \"msg\":\"base64格式错误或无法生成图片\", \"code\":\"-4\"}";
                    }
                }

            }
            Response.Write(msg);
        }
        else
        {
            msg = "{\"state\":\"false\", \"msg\":\"无效的参数请求\", \"code\":\"-6\"}";
            Response.Write(msg);
        }
    }
    protected void UpTime(int ID, int Aid, double quality, string headpic, string file)
    {
        try
        {
            UserFaceTime condition = new UserFaceTime();
            UserFaceTime value = new UserFaceTime();
            condition.UserID = ID;
            condition.ZQID = Aid;
            List<UserFaceTime> list = TableOperate<UserFaceTime>.Select(value, condition, 0, "order by LastTime desc");
            condition.LastTime = DateTime.Now;
            if (list.Count > 0)
            {
                TimeSpan t3 = DateTime.Now - list[0].LastTime;
                double time = t3.TotalMinutes;
                if (time > 2)
                {
                    condition.Quality = quality;
                    condition.HeadPic = headpic;
                    condition.AddTime = DateTime.Now;
                    TableOperate<UserFaceTime>.InsertReturnID(condition);

                }
                else
                {
                    string oldfile = Request.MapPath("/" + list[0].HeadPic);
                    if (quality < list[0].Quality)
                    {
                        condition.Quality = quality;
                        condition.HeadPic = headpic;
                        //  DeleteFace(oldfile);
                    }
                    condition.ID = list[0].ID;
                    TableOperate<UserFaceTime>.Update(condition);


                    AddTime(Aid, time);

                }
            }
            else
            {
                condition.Quality = quality;
                condition.HeadPic = headpic;
                condition.AddTime = DateTime.Now;
                TableOperate<UserFaceTime>.InsertReturnID(condition);

            }
        }
        catch (Exception ex)
        {
            //Log("错误！" + ex.ToString());
        }


    }
    private void Up(int id)
    {
        Userinfo condition = new Userinfo();
        condition.ID = id;
        condition.LastModifyTime = DateTime.Now;
        TableOperate<Userinfo>.Update(condition);
    }
    private void AddTime(int ZQID, double time)
    {
        FaceHotArea condition = new FaceHotArea();
        condition.ID = ZQID;
        FaceHotArea hot = TableOperate<FaceHotArea>.GetRowData(condition);
        if (hot.ID > 0)
        {
            condition.Time = (hot.Time + time);
            condition.ID = hot.ID;
            TableOperate<FaceHotArea>.Update(condition);
        }
    }
    /// <summary>
    /// API接收Base64转图片
    /// </summary>
    /// <param name="Img">图片字节</param>
    /// <param name="Path">储存地址</param>
    /// <returns></returns>
    public static bool ToImg(string Img, string Path)
    {
        try
        {
            //转图片
            byte[] bit = Convert.FromBase64String(Img);
            MemoryStream ms = new MemoryStream(bit);
            Bitmap bmp = new Bitmap(ms);
            bmp.Save(Path);
            return true;
        }
        catch
        {
            return false;
        }


    }
}