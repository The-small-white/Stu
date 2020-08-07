using System;
using System.Drawing;
using System.IO;
using System.Web;

/// <summary>
/// Draw 的摘要说明
/// </summary>
public class Draw
{
    protected static readonly string PATH = HttpRuntime.AppDomainAppPath.ToString() + @"/Plusbe2019_Admin/AdminHeadPic";

	public Draw()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public static string Drawing(string name,string fileName)
    {
        if (!Directory.Exists(PATH))//如果不存在该文件夹就先创建
        {
            Directory.CreateDirectory(PATH);
        }

        if (!File.Exists(PATH + @"\" + fileName))//如果不存在该头像
        {

            Bitmap bmp = new Bitmap(149, 149);
            Graphics g = Graphics.FromImage(bmp);

            Color[] colors = { ColorTranslator.FromHtml("#F2725D"), ColorTranslator.FromHtml("#4DA8EA"), ColorTranslator.FromHtml("#B28978"), ColorTranslator.FromHtml("#16C295"), ColorTranslator.FromHtml("#F6B45D"), ColorTranslator.FromHtml("#5F6FA6"), ColorTranslator.FromHtml("#558AAC") };
            SolidBrush brush=new SolidBrush(colors[new Random().Next(colors.Length)]);
            g.FillRectangle(brush, 0, 0, 149, 149);

            if (name.Length >= 3)
            {
                name = name.Substring(name.Length - 2, 2);
            }

            g.DrawString(name, new Font("楷体", 47), new SolidBrush(Color.White),2, 46);
            bmp.Save(PATH + @"\" + fileName);
        }

        return fileName;
    }

}