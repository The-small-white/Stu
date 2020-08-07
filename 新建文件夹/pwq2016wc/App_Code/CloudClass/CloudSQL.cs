using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;
using System.Linq;
using System.Web;
using System.IO;
using Ionic.Zip;

/// <summary>
/// layerMsg 的摘要说明
/// </summary>
public class CloudSQL
{
    public CloudSQL()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public static string  GetTopNews()
    {
        AnnNews condition = new AnnNews();
        AnnNews value = new AnnNews();
        List<AnnNews> list = TableOperate<AnnNews>.Select(value, condition, 1, "order by iszd,ishot asc,id desc");
        if (list.Count > 0)
        {
            return SysConfig.GetStr1(list[0].Title,20);
        }
        return "暂无公告";
        
    }
    /// <summary>
    /// 获取用户列表
    /// </summary>
    /// <returns></returns>
    public static List<Userinfo> GetMyUserInfo()
    {
        Userinfo condition = new Userinfo();
        condition.ExhibitionID = AdminMethod.ExhibitionID;
        Userinfo value = new Userinfo();
        List<Userinfo> list = TableOperate<Userinfo>.Select(value,condition);
        return list;
    }
    /// <summary>
    /// 获取我的信息
    /// </summary>
    /// <returns></returns>
    public static List<Mailbox> GetMsg()
    {
        Mailbox condition = new Mailbox();
        Mailbox value = new Mailbox();
        condition.ReceiveID = AdminMethod.AdminID;
        condition.States = 0;
       return TableOperate<Mailbox>.Select(value,condition);
        
    }
    /// <summary>
    /// 删除人脸图片
    /// </summary>
    /// <param name="file"></param>
    public static void DeleteFace(string file)
    {
        try
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "/UserFacePic/"; //获取网站根目录
            string deleteFiles = path + file;
            if (File.Exists(deleteFiles))
            {
                File.Delete(deleteFiles);
            }
        }
        catch
        {

        }
     
    }
    /// <summary>
    /// 判断删除是否需要删除文件
    /// </summary>
    /// <param name="news"></param>
    public static void DeleteOldFile(News news)
    {
        try
        {
            News condition = new News();
            condition.Files = news.Files;
            int Count = TableOperate<News>.GetCountValue(condition);
            if (Count == 1)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "UploadFiles\\"; //获取网站根目录
                string piczip = path + news.Files1;
                if (news.FileType == 1 || news.FileType == 3)//删除视频 ppt
                {

                    string deleteFiles = path + news.Files;
                    if (File.Exists(deleteFiles))
                    {
                        File.Delete(deleteFiles);
                    }
                }
                else if (news.FileType == 4)//删除图片以及压缩包
                {
                    string[] arry = news.Files.Split('|');
                    for (int j = 0; j < arry.Length; j++)
                    {
                        string nowpic = path + arry[j];
                        if (File.Exists(nowpic))
                        {
                            File.Delete(nowpic);
                        }
                    }
                    if (File.Exists(piczip))
                    {
                        File.Delete(piczip);
                    }
                }

            }
        }
        catch
        {

        }


    }
    /// <summary>
    /// 图片打包
    /// </summary>
    /// <param name="file"></param>
    /// <param name="oldzipfile"></param>
    /// <returns></returns>
    public static string GetPicZip(string file, string oldzipfile)
    {
        string addTime = "";
        try
        {
            string path = AppDomain.CurrentDomain.BaseDirectory; //获取网站根目录
            if (oldzipfile != "" && oldzipfile != null)
            {
                string delzip = path + "UploadFiles\\" + oldzipfile;
                if (File.Exists(delzip))
                {
                    System.IO.File.Delete(delzip);
                }
            }
            
            addTime = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".zip";

            using (ZipFile zip = new ZipFile(System.Text.Encoding.Default))
            {
                string[] arry = file.Split('|');
                for (int j = 0; j < arry.Length; j++)
                {
                    string nowpic = path + "UploadFiles\\" + arry[j];

                    if (File.Exists(nowpic))
                    {
                        try
                        {
                            zip.AddFile(nowpic, "");
                        }
                        catch
                        {

                        }

                    }
                }
                zip.Save(path + "UploadFiles\\" + addTime);
            }
        }
        catch
        {

        }
      
        return addTime;
    }
    /// <summary>
    /// 获取关键词库
    /// </summary>
    /// <returns></returns>
    public static List<SpeechKeyWord> GetKey()
    {
        SpeechKeyWord condition = new SpeechKeyWord();
        SpeechKeyWord value = new SpeechKeyWord();
        condition.ExhibitionID = AdminMethod.ExhibitionID;
        List<SpeechKeyWord> list = TableOperate<SpeechKeyWord>.Select(value, condition);
        return list;
    }
    /// <summary>
    /// 获取我的展区
    /// </summary>
    /// <returns></returns>
    public static List<Area> GetMyArea()
    {
        Area condition = new Area();
        Area value = new Area();
        condition.ExhibitionID = AdminMethod.ExhibitionID;
        List<Area> list = TableOperate<Area>.Select(value,condition);
        return list;
    }
    public static List<AgeType> GetMyAge()
    {
        AgeType condition = new AgeType();
        AgeType value = new AgeType();
        condition.ExhibitionID = AdminMethod.ExhibitionID;
        List<AgeType> list = TableOperate<AgeType>.Select(value, condition);
        return list;
    }
    public static List<TrdType> GetMyTrdType()
    {
        TrdType condition = new TrdType();
        TrdType value = new TrdType();
        condition.ExhibitionID = AdminMethod.ExhibitionID;
        List<TrdType> list = TableOperate<TrdType>.Select(value, condition);
        return list;
    }
    /// <summary>
    /// 我的展厅的文件总数量
    /// </summary>
    /// <returns></returns>
    public static int GetMyWJ()
    {
        News condition = new News();
        condition.TypeID = 0;
        condition.ExhibitionID = AdminMethod.ExhibitionID;
        int Count = TableOperate<News>.GetCountValue(condition);
        return Count;
    }
    /// <summary>
    /// 获取我的展厅的内容主机数量
    /// </summary>
    /// <returns></returns>
    public static int GetMyPC()
    {
        Pclist condition = new Pclist();
        condition.ExhibitionID = AdminMethod.ExhibitionID;
        int Count = TableOperate<Pclist>.GetCountValue(condition);
        return Count;
    }
    /// <summary>
    /// 获取我的主机列表
    /// </summary>
    /// <returns></returns>
    public static List<Pclist> GetMyPCList()
    {
        Pclist condition = new Pclist();
        Pclist value = new Pclist();
        condition.ExhibitionID = AdminMethod.ExhibitionID;
         List<Pclist>list= TableOperate<Pclist>.Select(value,condition);
        return list;
    }
    /// <summary>
    /// 获取所有展厅
    /// </summary>
    /// <returns></returns>
    public static List<Exhibition> GetTExhibitionList()
    {

        List<Exhibition> list = ExhibitionProvider.SelectAll();
        return list;
    }
    /// <summary>
    /// 获取资源标签
    /// </summary>
    /// <returns></returns>
    public static List<TagTree> GetTagList()
    {
        
        List<TagTree> list = TagProvider.SelectAll();
        return list;
    }
    /// <summary>
    /// 排序时间戳
    /// </summary>
    /// <returns></returns>
    public static long GetNowTime()
    {
        string time = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        return Convert.ToInt64(time);
    }
    /// <summary>
    /// 更新主机版本
    /// </summary>
    /// <param name="PCID"></param>
    public static void UpdataVesion(int PCID)
    {
        Pclist newChannel = new Pclist();
        newChannel.ID = PCID;
        Pclist ddd = TableOperate<Pclist>.GetRowData(newChannel);
        newChannel.Version = ddd.Version + 1;
        TableOperate<Pclist>.Update(newChannel);
    }
    /// <summary>
    /// 获取管理员最后登录
    /// </summary>
    /// <returns></returns>
    public static List<Admin_User> GetMyUser()
    {
        Admin_User condition = new Admin_User();
        Admin_User value = new Admin_User();
        condition.ExhibitionID = AdminMethod.ExhibitionID;
        return TableOperate<Admin_User>.Select(value,condition,5, "order by LastLoginTime desc");
        
    }
    public static List<ReserveDate> GetRevDate()
    {
        ReserveDate condition = new ReserveDate();
        ReserveDate value = new ReserveDate();
        condition.ExhibitionID = AdminMethod.ExhibitionID;
        return TableOperate<ReserveDate>.Select(value, condition, 0, "order by OrderID asc");

    }
    /// <summary>
    /// 新闻公告
    /// </summary>
    /// <returns></returns>
    public static List<AnnNews> ListNews()
    {
        AnnNews condition = new AnnNews();
        AnnNews value = new AnnNews();
        return TableOperate<AnnNews>.Select(value,condition,5, "order by iszd,ishot asc,id desc");
    }
    /// <summary>
    /// 获取展厅最新更新的5条资源
    /// </summary>
    /// <returns></returns>
    public static List<View_News> NewsList()
    {
        View_News condition = new View_News();
        View_News value = new View_News();
        condition.ExhibitionID = AdminMethod.ExhibitionID;
        condition.TypeID = 0;
        List<View_News> list = TableOperate<View_News>.Select(value,condition,5,"order by id desc");
        return list;

    }

}