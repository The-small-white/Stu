using LitJson;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;

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
               // msg = "{\"state\":\"false\", \"msg\":\"人脸删除失败\", \"code\":\"1\"}";
            }
            else if (act == "select" || act == "insert")
            {
                string headimg = Convert.ToString(Request["pic"]);//传入base64图片编码格式
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
                        JsonData DataList = JsonMapper.ToObject(str);
                        string state = DataList["state"].ToString();
                        if (state == "true")
                        {
                            DeleteFace(filePath);//删除保存的图片
                            int FaceID = (int)DataList["returnid"];
                            if (FaceID > 0)
                            {
                                if (act == "select")
                                {
                                    Face condition = new Face();
                                    condition.ID = FaceID;
                                    //condition.States = 2;
                                    Face user = TableOperate<Face>.GetRowData(condition);
                                    if (user.ID > 0)
                                    {
                                        msg = "{\"state\":\"true\", \"userid\":\"" + user.UserinfoID + "\", \"msg\":\"人脸查询成功\", \"code\":\"0\"}";
                                    }
                                }
                                else
                                {
                                    AddHead(FaceID, headpic);
                                    msg = "{\"state\":\"true\", \"faceid\":\"" + FaceID + "\", \"msg\":\"人脸插入成功\", \"code\":\"0\"}";
                                }


                            }

                        }
                        else
                        {
                            msg = "{\"state\":\"false\", \"msg\":\"人脸库操作失败，或未查询到该人脸\", \"code\":\"2\"}";
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
           msg= "{\"state\":\"false\", \"msg\":\"人脸服务未开启\", \"code\":\"-1\"}"; 
        }
       
    
      
        Response.Write(msg);
        

    }
    public void AddHead(int FaceID,string headpic)
    {
        Face face = new Face();
        face.ID = FaceID;
       
        face.HeadImage = headpic;
        TableOperate<Face>.Update(face);
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
        catch
        {

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