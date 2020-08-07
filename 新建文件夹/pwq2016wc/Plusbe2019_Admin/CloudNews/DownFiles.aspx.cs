using System;
using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Script.Serialization;

public partial class Plusbe2019_Admin_CloudNews_DownFiles : AdminPage
{
    bool IsDown = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        int id = GetIntKey("iD");
        if (id > 0)
        {
            News condition = new News();
            condition.ID = id;
            News news = TableOperate<News>.GetRowData(condition);
            if (news.ID > 0 && news.FileType != 2)
            {
                Result result = new Result();
                string file = news.Files;
                if (news.FileType == 4)//图片下载
                {
                    file = news.Files1;
                }
                Down(news.Title, "/UploadFiles/" + file);

            }
            else
            {
                Result result = new Result();
                result.isOk = true;
                result.msg = "网页不支持下载请点击浏览！";
                Response.ContentType = "text/json";
                Response.Write(new JavaScriptSerializer().Serialize(result));
                Response.End();
            }
        }
    }
    protected void Down(string title,string files)
    {
        try
        {
            string fileName = "云平台下载--" + title + Path.GetExtension(files);//客户端保存的文件名 
            string filePath = Server.MapPath(files);//路径 
            if (!File.Exists(filePath))
            {
                IsDown = false;
                Result result = new Result();
                result.isOk = true;
                result.msg = "文件不存在！";
                Response.ContentType = "text/json";
                Response.Write(new JavaScriptSerializer().Serialize(result));
                Response.End();return;
            }
            //以字符流的形式下载文件 
            FileStream fs = new FileStream(filePath, FileMode.Open);
            byte[] bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close(); IsDown = true;
            Response.ContentType = "application/octet-stream";
            //通知浏览器下载文件而不是打开 
            Response.AddHeader("Content-Disposition", "attachment;  filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
            
        }
        catch (Exception ex)
        {
            Result result = new Result();
            result.isOk = true;
            result.msg = ex.ToString();
            Response.ContentType = "text/json";
            Response.Write(new JavaScriptSerializer().Serialize(result));
            Response.End(); return;
        }


    }
}