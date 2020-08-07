using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;

public partial class server_webup : AdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            #region 头部生成，关闭缓存
            //Response.Write("{\"status\" : 0,\"chunked\" : false, \"hasError\" : true, \"f_ext\" : \"出错位置\"}");
            //return;

            Response.Buffer = true;
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
            Response.Expires = 0;
            Response.CacheControl = "no-cache";
            Response.Cache.SetNoStore();
            Response.ContentType = "text/plain";
            #endregion
            #region 初始参数变量
            //初始参数
            _MaxFileSize = 400;
            _FileDir = "/UploadFiles/";
            //jpg,jpeg,png,ppt,pptx,pps,ppsx,mp3,mp4,mpe,mpeg,mpg,mkv,mov,avi,flv,rmvb,wmv,wma,rm,swf
            _FileType = ".mp4;.mp3;.avi;.flv;.f4v;.rmvb;.mkv;.mpe;.ppt;.pptx;.pot;.pps;.pptm;.ppsx;.jpg;.png;.swf;.wmv;.wma;.mpeg;.rm;.mov;.jpeg;.pdf;.txt;.txt";
            string dm = DateTime.Now.Month.ToString();
            string dd = DateTime.Now.Day.ToString();
            if (dm.Length == 1) dm = "0" + dm;
            if (dd.Length == 1) dd = "0" + dd;
            string datepath = _FileDir;//存储路径
            //string filenameok = DateTime.Now.ToFileTime().ToString();//根据时间确定文件名
            #endregion

            #region md5查询,文件秒传判断，分片秒传判断,合并文件操作
            if (Request["status"] != null)
            {
                string status = Request["status"];
                #region 文件上传前的服务器秒传判断
                if (Request["status"] == "fileMerge")
                {
                    //md5验证
                    _fileMd5 = Request["md5"];
                    string ext = Request["ext"];
                    if (File.Exists(Server.MapPath("~/" + datepath + _fileMd5 + "." + ext)))
                    {
                        FileInfo fileInfo = new FileInfo(Server.MapPath("~/" + datepath + _fileMd5 + "." + ext));
                        if (fileInfo.Length ==Convert.ToInt32( Request["size"]))
                        {
                            if ((DateTime.Now.Day * 24 * 60 + DateTime.Now.Hour * 60 + DateTime.Now.Minute) - (fileInfo.CreationTime.Day * 24 * 60 + fileInfo.CreationTime.Hour * 60 + fileInfo.CreationTime.Minute) <2)
                            {
                                Response.Write("{\"hasError\":false, \"path\": \"" + (datepath + _fileMd5 + "." + ext).Replace("\\", "/") + "\", \"f_ext\" : \"" + "成功上传" + "\"}");
                            }
                            else
                            {
                                Response.Write("{\"hasError\":false, \"path\": \"" + (datepath + _fileMd5 + "." + ext).Replace("\\", "/") + "\", \"f_ext\" : \"" + "文件秒传" + "\"}");
                            }
                            return;
                        }
                        else
                        {
                            Response.Write("{\"hasError\":true, \"path\": \"" + (datepath + _fileMd5 + "." + ext).Replace("\\", "/") + "\", \"f_ext\" : \"" + "文件大小不一致" + "\"}");
                            return;
                        }
                    }
                    else
                    {
                        Response.Write("{\"hasError\":true, \"f_ext\" : \"" + "该文件不存在！" + "\"}");
                        return;

                    }
                    return;
                }
                if (Request["status"] == "md5Check")
                {
                    //md5验证
                    _fileMd5 = Request["md5"];
                    string ext = Request["ext"];
                    _FileSize = Convert.ToInt32(Request["size"]);
                    //数据库中查询验证，默认没上传

                    //文件级大小判断
                    if (File.Exists(Server.MapPath("~/" + datepath + _fileMd5 + "." + ext)))
                    {
                        FileInfo fileInfo = new FileInfo(Server.MapPath("~/" + datepath + _fileMd5 + "." + ext));
                        if (fileInfo.Length == _FileSize)
                        {
                            Response.Write("{\"ifExist\":1, \"path\": \"" + (datepath + _fileMd5 + "." + ext).Replace("\\", "/") + "\", \"f_ext\" : \"" + "该文件已经存在，无需上传！" + "\"}");
                            return;
                        }
                        else
                        {
                            try
                            {
                                System.IO.File.Delete(Server.MapPath("~/" + datepath + _fileMd5 + "." + ext));
                            }
                            catch { }
                            Response.Write("{\"ifExist\":0, \"path\": \"" + (datepath + _fileMd5 + "." + ext).Replace("\\", "/") + "\", \"f_ext\" : \"" + "该文件已经存在，但大小不一致，重新上传！" + "\"}");
                            return;
                        }
                    }

                    Response.Write("{\"ifExist\":0}");//如果没有状态，返回空数据！
                    return;
                }
                #endregion
                #region 分片上传时的秒传判断，是否已经存在该分片
                if (Request["status"] == "chunkCheck")
                {

                    try
                    {
                        //首先判断文件是否已经通过其它方式上传完成（防止多标签上传）
                        string okfile = datepath + Request["name"] + "." + Request["ext"];
                        int okfilesize = Convert.ToInt32(Request["filesize"]);
                        if (File.Exists(Server.MapPath("~/" + okfile)))
                        {
                            FileInfo fileInfo = new FileInfo(Server.MapPath("~/" + okfile));
                            if (fileInfo.Length == okfilesize)
                            {

                                Response.Write("{\"ifExist\":1, \"f_ext\" : \"" + Request["chunkIndex"] + "该文件已上传完成并合并！" + "\"}");
                                return;
                            }
                            else
                            {
                                //删除此文件
                                //System.IO.File.Delete(Server.MapPath("~/" + okfile));
                                Response.Write("{\"ifExist\":1, \"f_ext\" : \"" + Request["chunkIndex"] + "该块的文件已存在，但大小不一致！" + "\"}");//如果没有状态，返回空数据！
                                return;
                            }
                        }

                        //文件分块是否已经存在
                        _FileSize = Convert.ToInt32(Request["size"]);
                        string _filename = Request["name"];
                        string fkfile = datepath + _filename + "/" + Request["chunkIndex"];
                        if (File.Exists(Server.MapPath("~/" + fkfile)))
                        {
                            FileInfo fileInfo = new FileInfo(Server.MapPath("~/" + fkfile));
                            if (fileInfo.Length == _FileSize)
                            {
                                Response.Write("{\"ifExist\":1, \"f_ext\" : \"" + Request["chunkIndex"] + "该块已正常上传！" + "\"}");
                                return;
                            }
                            else
                            {
                                //删除此文件
                                System.IO.File.Delete(Server.MapPath("~/" + fkfile));
                                Response.Write("{\"ifExist\":0, \"f_ext\" : \"" + Request["chunkIndex"] + "该块存在，但大小不一致！" + "\"}");//如果没有状态，返回空数据！
                                return;
                            }
                            //如果存在，返回1



                        }
                        else
                        {
                            Response.Write("{\"ifExist\":0,\"path\":\"" + Request["chunkIndex"] + "该块不存在，即将上传：" + fkfile + "\"}");//如果没有状态，返回空数据！
                        }
                    }
                    catch (Exception e5)
                    {
                        Response.Write("{\"ifExist\":0,\"path\":\"" + Request["chunkIndex"] + "该块有问题，即将重新上传!"+e5.Message+"\"}");//如果没有状态，返回空数据！
                        
                    }
                    return;
                }
                #endregion
                #region 文件合并判断及操作
                if (Request["status"] == "chunksMerge")
                {
                    try
                    {

                        string guid = Request["md5"];
                        string fileExt = Request["ext"];

                        string root = Server.MapPath("~/" + datepath);
                        string sourcePath = Path.Combine(root, guid + "/");//源数据文件夹
                        string targetPath = Path.Combine(root, guid + "." + fileExt);//合并后的文件
                        string fangfa="1";

                        #region 方法一
                        if (fangfa == "1")
                        {
                            DirectoryInfo dicInfo = new DirectoryInfo(sourcePath);
                            if (Directory.Exists(Path.GetDirectoryName(sourcePath)))
                            {

                                //判断分片数量，是否和文件是否一致
                                int fsum = Convert.ToInt32(Request["chunks"]);//分片总数
                                //文件总数判断
                                if (fsum != dicInfo.GetFiles().Length)
                                {

                                    Response.Write("{\"ifExist\":0,\"hasError\" : true,\"chunked\" : true, \"f_ext\" : \"" + "合并文件失败，客户端分片数与上传数不一致，请重新上传！" + "\"}");//如果没有状态，返回空数据！
                                    return;

                                }

                                FileInfo[] files = dicInfo.GetFiles();

                                long fsize = 0;
                                //通过GetFiles方法,获取di目录中的所有文件的大小

                                foreach (FileInfo fi in dicInfo.GetFiles())
                                {
                                    fsize += fi.Length;
                                }
                                int fsizeok = Convert.ToInt32(fsize);

                                if (fsizeok != Convert.ToInt32(Request["size"]))
                                {
                                    Response.Write("{\"ifExist\":0,\"hasError\" : true,\"chunked\" : true, \"f_ext\" : \"" + "合并文件失败，上传分片数大小【" + Convert.ToInt64(fsize) + "】与文件【" + Request["size"] + "】不一致，请重新上传！" + "\"}");//如果没有状态，返回空数据！
                                    return;
                                }


                                //检查合并后的文件是否已经存在

                                if (File.Exists(targetPath))
                                {

                                    _FileSize = Convert.ToInt32(Request["size"]);
                                    FileInfo fileInfo = new FileInfo(targetPath);
                                    if (fileInfo.Length == _FileSize || fileInfo.Length == fsizeok)
                                    {

                                        DeleteFolder(sourcePath);
                                        Response.Write("{\"ifExist\":1,\"hasError\" : false,\"chunked\" : true, \"path\": \"" + datepath + guid + "." + fileExt + "\", \"f_ext\" : \"" + "该文件已经存在！" + "\"}");

                                        return;
                                    }
                                    else
                                    {
                                        //删除此文件,重新生成
                                        try
                                        {
                                            System.IO.File.Delete(targetPath);
                                        }
                                        catch { }
                                        //Response.Write("{\"ifExist\":0, \"f_ext\" : \"" + "该文件存在，但大小不一致！" + "\"}");//如果没有状态，返回空数据！
                                        //return;
                                    }
                                }

                                foreach (FileInfo file in files.OrderBy(f => int.Parse(f.Name)))
                                {
                                    FileStream addFile = new FileStream(targetPath, FileMode.Append, FileAccess.Write);
                                    BinaryWriter AddWriter = new BinaryWriter(addFile);

                                    //获得上传的分片数据流
                                    Stream stream = file.Open(FileMode.Open);
                                    BinaryReader TempReader = new BinaryReader(stream);
                                    //将上传的分片追加到临时文件末尾
                                    AddWriter.Write(TempReader.ReadBytes((int)stream.Length));
                                    //关闭BinaryReader文件阅读器
                                    TempReader.Close();
                                    stream.Close();
                                    AddWriter.Close();
                                    addFile.Close();

                                    TempReader.Dispose();
                                    stream.Dispose();
                                    AddWriter.Dispose();
                                    addFile.Dispose();
                                    //删除这个分片数据
                                    //System.IO.File.Delete(file.DirectoryName+"\\"+file.Name);
                                }
                                DeleteFolder(sourcePath);
                                //System.Web.HttpUtility.UrlEncode(targetPath) 
                                Response.Write("{\"status\":1, \"path\": \"" + datepath + guid + "." + fileExt + "\",\"chunked\" : true, \"hasError\" : false, \"savePath\" :\"" + System.Web.HttpUtility.UrlEncode(targetPath) + "\"}");
                                return;

                                //Response.Write("{\"hasError\" : false}");
                            }
                            else
                            {   //检查合并后的文件是否已经存在

                                if (File.Exists(targetPath))
                                {

                                    _FileSize = Convert.ToInt32(Request["size"]);
                                     FileInfo fileInfo = new FileInfo(targetPath);
                                    
                                    if (fileInfo.Length == _FileSize)
                                    {

                                        DeleteFolder(sourcePath);
                                        Response.Write("{\"ifExist\":1,\"hasError\" : false,\"chunked\" : true, \"path\": \"" + datepath + guid + "." + fileExt + "\", \"f_ext\" : \"" + "该文件已经存在,无需操作！" + "\"}");

                                        return;
                                    }
                                }
                                Response.Write("{\"status\":0,\"hasError\" : true, \"f_ext\" : \"" + "源数据文件夹未找到！" + "\"}");
                                return;
                            }
                        }
                        #endregion
                        #region 方法2
                        if (fangfa == "2")
                        {
                            string tempFilePath = Path.Combine(root, guid + "/");//源数据文件夹
                            string saveFilePath = Path.Combine(root, guid + "." + fileExt);//合并后的文件
                            string[] fileArr = Directory.GetFiles(tempFilePath);
                            try
                            {

                                lock (tempFilePath)
                                {
                                    int chunkNum = Convert.ToInt32(Request["chunks"]);//分片总数
                                    if (Convert.ToInt32(chunkNum) == fileArr.Length)
                                    {
                                        if (System.IO.File.Exists(saveFilePath))
                                        {
                                            System.IO.File.Delete(saveFilePath);
                                        }
                                        FileStream addStream = new FileStream(saveFilePath, FileMode.Append, FileAccess.Write);
                                        BinaryWriter AddWriter = new BinaryWriter(addStream);
                                        for (int i = 0; i < fileArr.Length; i++)
                                        {
                                            //以小文件所对应的文件名称和打开模式来初始化FileStream文件流，起读取分割作用
                                            FileStream TempStream = new FileStream(tempFilePath + i, FileMode.Open);
                                            //用FileStream文件流来初始化BinaryReader文件阅读器，也起读取分割文件作用
                                            BinaryReader TempReader = new BinaryReader(TempStream);
                                            //读取分割文件中的数据，并生成合并后文件
                                            AddWriter.Write(TempReader.ReadBytes((int)TempStream.Length));
                                            //关闭BinaryReader文件阅读器
                                            TempReader.Close();
                                            TempStream.Close();
                                        }
                                        AddWriter.Close();
                                        addStream.Close();
                                        AddWriter.Dispose();
                                        addStream.Dispose();
                                        Directory.Delete(tempFilePath, true);
                                    }
                                    //验证文件的MD5，确定文件的完整性 前端文件MD5值与后端合并的文件MD5值不相等
                                    //if (UploaderHelper.GetMD5HashFromFile(saveFilePath) == md5)
                                    //{
                                    //    int i = 1;
                                    //}
                                    Response.Write("{\"status\":1, \"path\": \"" + datepath + guid + "." + fileExt + "\",\"chunked\" : true, \"hasError\" : false, \"savePath\" :\"" + System.Web.HttpUtility.UrlEncode(targetPath) + "\"}");
                                    return;
                                    //return Json("{hasError:\"false\"}");
                                }
                            }
                            catch (Exception ex)
                            {
                                Response.Write("{\"status\":0,\"hasError\" : true,\"chunked\" : true,  \"f_ext\" : \"" + ex.Message + "\"}");
                                return;
                            }
                        }
                        #endregion
                    }
                    catch (Exception e1)
                    {
                        if (e1.Message.Contains("正由另一进程使用"))
                        {
                            Response.Write("{\"status\":0,\"hasError\" : true,\"chunked\" : true, \"f_ext\" : \"已经有其它进程在合并文件！\"}");
                        }
                        else
                        {
                            Response.Write("{\"status\":0,\"hasError\" : true,\"chunked\" : true, \"f_ext\" : \"" + e1.Message + "\"}");
                        }
                        return;
                    }
                    Response.Write("{\"status\":0,\"hasError\" : true,\"chunked\" : true, \"f_ext\" : \"" + "合并文件未完成！" + "\"}");
                    return;    
                }
                #endregion
                Response.Write("{\"status\":0,\"ifExist\":0, \"f_ext\" : \"" + "状态码正确，但未操作成功！" + "\"}");//如果没有状态，返回空数据！
                return;
            }

            #endregion



            #region 前期 文件类型大小判断

            try
            {
                _FileSize = Request.Files[0].ContentLength;//文件大小 byte
            }
            catch { }

            if (_FileSize == 0)  // 判断是否有文件需要上传或所选文件是否为0字节。
            {
                _UploadInfo = "没有选择要上传的文件或所选文件大小为0字节";
                //{"status":1, "path": "'.$path.'"}
                Response.Write("{\"status\" : 0,\"status\" : false, \"hasError\" : true, \"f_ext\" : \"" + _UploadInfo + "\"}");
                return;  // 返回文件上传状态和信息。
            }
            //_MaxFileSize = 200;
            if (_FileSize > (_MaxFileSize * 1024 * 1024))  // 限制要上传的文件大小(byte)。
            {
                _UploadInfo = "上传的文件【" + (_FileSize).ToString("0.00") + "】超过限制大小(" + (_MaxFileSize * 1024 * 1024).ToString() + "Byte)";
                Response.Write("{\"status\" : 0,\"chunked\" : false, \"hasError\" : true, \"f_ext\" : \"" + _UploadInfo + "\"}");
                return;  // 返回文件上传状态和信息。
            }
            int intFileExtPoint = Request.Files[0].FileName.LastIndexOf("."); //存储最后一个 . 号的位置
            string strFileExtName = Request.Files[0].FileName.Substring(intFileExtPoint + 1).ToLower();  // 获取要上传的文件的后缀名。
            if (_FileType != "*")
            {
                if (_FileType.ToLower().IndexOf(strFileExtName.ToLower().Trim()) == -1)  // 判断要上传的文件类型的是否在允许的范围内。
                {
                    _UploadInfo = "不允许上传的文件类型(允许的类型：" + _FileType + ")";
                    Response.Write("{\"status\" : 0,\"chunked\" : false, \"hasError\" : true, \"f_ext\" : \"" + _UploadInfo + "\"}");
                    return;  // 返回文件上传状态和信息
                }
            }

            #endregion

            //如果进行了分片


            #region 文件上传存储
            //建立文件夹

            #region 写文件时，再判断
            if (Request["chunk"] != null && Request["chunks"] != null)
            {
                try
                {
                    //首先判断文件是否已经通过其它方式上传完成（防止多标签上传）
                    string okfile = datepath + Request["md5"] + "." + Request["ext"];
                    int okfilesize = Convert.ToInt32(Request["size"]);
                    if (File.Exists(Server.MapPath("~/" + okfile)))
                    {
                        FileInfo fileInfo = new FileInfo(Server.MapPath("~/" + okfile));
                        if (fileInfo.Length == okfilesize)
                        {

                            Response.Write("{{\"status\":1,\"ifExist\":1,\"chunked\" : true,\"hasError\" : false,  \"f_ext\" : \"" + Request["chunk"] + "该文件已上传完成并合并！" + "\"}");
                            return;
                        }
                    }

                    //文件分块是否已经存在
                    int chunkSize = Convert.ToInt32(Request["chunkSize"]);
                    string _filename = Request["md5"];
                    string fkfile = datepath + _filename + "/" + Request["chunk"];
                    if (File.Exists(Server.MapPath("~/" + fkfile)))
                    {
                        //如果该块大小与设置上传分块一致，说明已经上传，并且不是最后一个分块
                        FileInfo fileInfo = new FileInfo(Server.MapPath("~/" + fkfile));
                        if (fileInfo.Length == chunkSize && Convert.ToInt32(Request["chunk"]) + 1 != Convert.ToInt32(Request["chunks"]))
                        {
                            Response.Write("{\"status\":1, \"ifExist\":1,\"chunked\" : true,\"hasError\" : false, \"f_ext\" : \"" + fkfile + "该块已正常上传！" + "\"}");
                            return;
                        }
                        else
                        {
                            //删除此文件
                            System.IO.File.Delete(Server.MapPath("~/" + fkfile));
                        }
                        //如果存在，返回1



                    }

                }
                catch (Exception e5)
                {

                }
            }
            #endregion





            if (!Directory.Exists(Server.MapPath("~/" + datepath)))
            {
                Directory.CreateDirectory(Server.MapPath("~/" + datepath));
            }
            if (Request.Form.AllKeys.Any(m => m == "chunk"))
            {
                //取得chunk和chunks
                int chunk = Convert.ToInt32(Request["chunk"]);//当前分片在上传分片中的顺序（从0开始）
                int chunks = Convert.ToInt32(Request["chunks"]);//总分片数
                //根据GUID创建用该GUID命名的临时文件夹,如果要做秒传GUID可用固定的值
                string folder = Server.MapPath("~/" + datepath + Request["md5"] + "/");
                string path = folder + chunk;

                //建立临时传输文件夹
                if (!Directory.Exists(Path.GetDirectoryName(folder)))
                {
                    Directory.CreateDirectory(folder);
                }

                FileStream addFile = new FileStream(path, FileMode.Append, FileAccess.Write);
                BinaryWriter AddWriter = new BinaryWriter(addFile);
                //获得上传的分片数据流
                HttpPostedFile file = Request.Files[0];
                Stream stream = file.InputStream;

                BinaryReader TempReader = new BinaryReader(stream);
                //将上传的分片追加到临时文件末尾
                AddWriter.Write(TempReader.ReadBytes((int)stream.Length));
                //关闭BinaryReader文件阅读器
                TempReader.Close();
                stream.Close();
                AddWriter.Close();
                addFile.Close();

                TempReader.Dispose();
                stream.Dispose();
                AddWriter.Dispose();
                addFile.Dispose();

                Response.Write("{\"status\":1, \"path\": \"" + datepath + Request["md5"] + "/" + chunk + "\",\"chunked\" : true, \"hasError\" : false, \"f_ext\" : \"" + chunk.ToString() + ".chunk" + "\"}");
                return;
            }
            else//没有分片直接保存
            {

                Request.Files[0].SaveAs(Server.MapPath("~/" + datepath + Request["md5"] + "." + Request["ext"]));
                Response.Write("{\"status\":1, \"path\": \"" + "/" + datepath + Request["md5"] + Request["ext"] + "\",\"chunked\" : false, \"hasError\" : false, \"f_ext\" : \"" + datepath + Request["md5"] + Request["ext"] + "\"}");
                return;
            }
            #endregion
        }
        catch (Exception e1)
        {

            Response.Write("{\"status\":0, \"chunked\" : false, \"hasError\" : true, \"f_ext\" : \"整体出错：" +HttpUtility.HtmlEncode( e1.Message )+e1.StackTrace+ "\"}");
        }
    }
    #region 文件分片2
    //字段
    //还需测试一下这个链接的功能
    //https://blog.csdn.net/sinat_38843093/article/details/78874606
    //待验证
    //该版本目前的问题：（1）不能多个文件同时上传（2）如果两人同时上传一个文件，会出现合并错误的情况
    private string _UploadInfo;  // 文件上传的返回信息。
    private string _FileType;  // 允许上传文件的类型。
    private string _FileDir;  // 文件存储位置。
    private int _FileSize;  // 上传文件的大小。
    private int _MaxFileSize;  // 上传文件大小的最大长度。
    private string _NewFileName;  // 上传后的文件名。
    private string _fileMd5;  // 文件的MD5验证。
    private static readonly object SequenceLock = new object();//锁定某段程序代码
    private static System.Threading.ReaderWriterLockSlim LogWriteLock = new System.Threading.ReaderWriterLockSlim(); //写文件时，暂停其它线程写入

    #endregion
    /// <summary>
    /// 删除文件夹及其内容
    /// </summary>
    /// <param name="dir"></param>
    private static void DeleteFolder(string strPath)
    {
        try
        {
            //删除这个目录下的所有子目录
            if (Directory.GetDirectories(strPath).Length > 0)
            {
                foreach (string fl in Directory.GetDirectories(strPath))
                {
                    Directory.Delete(fl, true);
                }
            }
            //删除这个目录下的所有文件
            if (Directory.GetFiles(strPath).Length > 0)
            {
                foreach (string f in Directory.GetFiles(strPath))
                {
                    System.IO.File.Delete(f);
                }
            }
            Directory.Delete(strPath, true);
        }
        catch { }
    }
}