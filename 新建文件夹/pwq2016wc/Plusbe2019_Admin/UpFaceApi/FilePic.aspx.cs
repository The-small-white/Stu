using FaceBai;
using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Plusbe2019_Admin_UpFaceApi_FacePic : AdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Result result;
        HttpPostedFile file = Request.Files["file_data"];
        string filename = Request["file_name"];
        int _iD = GetIntKey("iD");
        int t = GetIntKey("t");
        
        string path = Request.MapPath("/UploadFiles");
        if (file != null && file.ContentLength != -1)
        {
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(filename);
            string filePath = Path.Combine(path, fileName);
             file.SaveAs(filePath);
            
             result = new Result(true, null, new { status = 2, file_Name = fileName});

        
            
        }
        else
        {
            result = new Result("请选择图片");
        }

        Response.ContentType = "text/json";
        Response.Write(new JavaScriptSerializer().Serialize(result));
        Response.End();
    }
    static string PostWebRequest(string postUrl, string paramData)
    {
        string ret = string.Empty;
        try
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(paramData); //转化
            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
            webReq.Method = "POST";
            webReq.ContentType = "application/x-www-form-urlencoded";

            webReq.ContentLength = byteArray.Length;
            Stream newStream = webReq.GetRequestStream();
            newStream.Write(byteArray, 0, byteArray.Length);//写入参数
            newStream.Close();
            HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default);
            ret = sr.ReadToEnd();
            sr.Close();
            response.Close();
            newStream.Close();
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
        return ret;
    }
    private string GetImgBase64(string file)
    {
        string base64str = "";
        System.Drawing.Bitmap bmp1 = new System.Drawing.Bitmap(file);
        using (MemoryStream ms1 = new MemoryStream())
        {
            bmp1.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] arr1 = new byte[ms1.Length];
            ms1.Position = 0;
            ms1.Read(arr1, 0, (int)ms1.Length);
            ms1.Close();
            base64str = Convert.ToBase64String(arr1);
        }
        return base64str;
    }
    public static Byte[] byteFromPath(string path)
    {
        using (FileStream file = new FileStream(path, FileMode.Open))
        {
            byte[] b = new byte[file.Length];
            file.Read(b, 0, b.Length);

            return b;
        }
    }
}