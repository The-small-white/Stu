using LitJson;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System.Collections.Generic;

public partial class API_FaceCheck : System.Web.UI.Page
{
    string msg = "{\"state\":\"false\", \"msg\":\"操作异常\"}";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string act = Convert.ToString(Request["act"]);
            if (act == "delete")
            {
                int id = Convert.ToInt32(Request["id"]);
                string json = "{\"type\":\"delete\", \"file\":\"\",\"id\":" + id + "}";
                json = json.Replace("\\", "/");
                string url = string.Format("http://127.0.0.1:5478/?json={0}", HttpUtility.UrlEncode(json));
                string str = HttpHelp.Get(url);
                JsonData DataList = JsonMapper.ToObject(str);
                string state = DataList["state"].ToString();
                if (state == "true")
                {
                    msg = "{\"state\":\"true\", \"msg\":\"人脸删除成功\"}";
                }
                msg = "{\"state\":\"false\", \"msg\":\"人脸删除失败\"}";
            }
            else if (act == "select" || act == "tryinsert")
            {
                string headimg = Convert.ToString(Request["pic"]);//传入base64图片编码格式
                int Aid = Convert.ToInt32(Request["aid"]);
                if (headimg != "" && headimg != null)
                {
                    headimg= headimg.Replace("data:image/png;base64,", "").Replace("data:image/jgp;base64,", "").Replace("data:image/jpg;base64,", "").Replace("data:image/jpeg;base64,", "");//将base64头部信息替换
                    string strbaser64 = headimg.Replace(" ", "+");//https://www.cnblogs.com/jueye/archive/2012/07/02/Url.html
                    string path = Request.MapPath("/UserFacePic");
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff")+".jpg";
                    string filePath = Path.Combine(path, fileName);
                    string headpic = "UserFacePic/" + fileName;
                    bool IsSave = ToImg(strbaser64, filePath);
                    if (IsSave)
                    {

                        string json = "{\"type\":\"" + act + "\", \"file\":\"" + filePath + "\",\"id\":0}";
                        json = json.Replace("\\", "/");
                        string url = string.Format("http://127.0.0.1:5478/?json={0}", HttpUtility.UrlEncode(json));
                        string str = HttpHelp.Get(url);
                        Log("aj返回:"+str);
                        JsonData DataList = JsonMapper.ToObject(str);
                        string state = DataList["state"].ToString();
                        if (state == "true")
                        {
                            //DeleteFace(filePath);//删除保存的图片
                            int FaceID = (int)DataList["returnid"];
                            if (FaceID > 0)
                            {
                                if (act == "select")
                                {
                                    double quality =0;
                                    Face condition = new Face();
                                    condition.ID = FaceID;
                                    Face user = TableOperate<Face>.GetRowData(condition);
                                    if (user.ID > 0)
                                    {
                                        msg = "{\"state\":\"true\", \"userid\":\"" + user.UserinfoID + "\", \"msg\":\"人脸查询成功图片质量\", \"code\":\"0\"}";
                                        Log("查询成功！"+msg);
                                        Up(user.UserinfoID);
                                        UpTime(user.UserinfoID,Aid, quality,headpic, filePath);//更新数据
                                       
                                    }
                                }



                            }

                        }
                        else
                        {
                            //DeleteFace(filePath);
                            msg = "{\"state\":\"false\", \"msg\":\"人脸库操作失败，或未查询到该人脸\", \"code\":\"2\"}";
                        }
                       if (act == "tryinsert")
                        {
                            int _id = IsIns(filePath);
                            if (_id == 0)
                            {
                                tryinsert(filePath, headpic,_id);//注册
                            }
                            else
                            {
                                tryinsert(filePath, headpic, _id);//插入人脸
                            }

                        }

                    }
                    else
                    {
                        msg = "{\"state\":\"false\", \"msg\":\"base64格式错误或无法生成图片\", \"code\":\"1\"}";
                    }
                }
            }
        }
        catch(Exception ex)
        {
           msg= "{\"state\":\"false\", \"msg\":\"人脸服务未开启"+ex.ToString()+ "\", \"code\":\"-1\"}";
        }
       
    
      
        Response.Write(msg);
        

    }
    protected void Log(string msg)
    {
       
        FaceLog condition = new FaceLog();
        int count = TableOperate<FaceLog>.GetCountValue(condition);
        if (count > 10000)
        {
            string sql = " Delete  FaceLog where ID>0 ";
            int id = TableOperate<FaceLog>.Execute(sql);
        }
        condition.Msg = msg;
        condition.AddTime = DateTime.Now;
        TableOperate<FaceLog>.InsertReturnID(condition);
    }
    protected void tryinsert(string filePath,string headpic,int Uid)
    {
        int Count = GetCount(Uid);
        if (Count > 10)
        {
            return;
        }
        string json = "{\"type\":\"insert\", \"file\":\"" + filePath + "\",\"id\":0}";
        json = json.Replace("\\", "/");
        string url = string.Format("http://127.0.0.1:5478/?json={0}", HttpUtility.UrlEncode(json));
        string str = HttpHelp.Get(url);
        JsonData DataList = JsonMapper.ToObject(str);
        string state = DataList["state"].ToString();
        if (state == "true")
        {

            int FaceID = (int)DataList["returnid"];
            if (FaceID > 0)
            {
                if (Uid == 0)
                {
                    Userinfo condition = new Userinfo();
                    condition.HeadImage = headpic;
                    condition.AddTime = DateTime.Now;
                    int _id = TableOperate<Userinfo>.InsertReturnID(condition);
                    msg = "{\"state\":\"true\", \"faceid\":\"" + FaceID + "\", \"msg\":\"人脸插入成功\", \"code\":\"0\"}";
                    Log("插入成功成功！" + msg);
                    Face face = new Face();
                    face.ID = FaceID;
                    face.UserinfoID = _id;
                    face.HeadImage = headpic;
                    TableOperate<Face>.Update(face);
                }
                else
                {
                    Face face = new Face();
                    face.ID = FaceID;
                    face.UserinfoID = Uid;
                    face.HeadImage = headpic;
                    TableOperate<Face>.Update(face);
                }
               
            }

        }
    }
    protected int IsIns(string filePath)
    {
        string json = "{\"type\":\"select\", \"file\":\"" + filePath + "\",\"id\":0}";
        json = json.Replace("\\", "/");
        string url = string.Format("http://127.0.0.1:5478/?json={0}", HttpUtility.UrlEncode(json));
        string str = HttpHelp.Get(url);
        JsonData DataList = JsonMapper.ToObject(str);
        string state = DataList["state"].ToString();
        if (state == "true")
        {
           
            int FaceID = (int)DataList["returnid"];
            if (FaceID > 0)
            {

                Face condition = new Face();
                condition.ID = FaceID;
                Face user = TableOperate<Face>.GetRowData(condition);
                
                if (user.UserinfoID > 0)
                {
                    return user.UserinfoID;
                }
            }
           
        }
        return 0;
    }
    protected int GetCount(int UserID)
    {
        Face condition = new Face();
        condition.UserinfoID = UserID;
        int count = TableOperate<Face>.GetCountValue(condition);
        return count;
    }
    protected void UpTime(int ID,int Aid,double quality,string headpic,string file)
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
        catch(Exception ex)
        {
            Log("错误！" + ex.ToString());
        }
      
       
    }
    private void Up(int id)
    {
        Userinfo condition = new Userinfo();
        condition.ID = id;
        condition.LastModifyTime = DateTime.Now;
        TableOperate<Userinfo>.Update(condition);
    }
    private void AddTime(int ZQID,double time)
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
    
    private void DeleteFace(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        catch(Exception ex)
        {
            Log("删除错误"+ filePath+ex.ToString());
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