using System;
using System.Text;
using Dejun.DataProvider.Table;
using Dejun.DataProvider.Sql2005;
using System.IO;
using MsgPack;
using LitJson;
using System.Collections.Generic;

public partial class ibeacon : System.Web.UI.Page
{
    protected string jsoner = "";
    protected List<IBeaconDev> devlist;
    protected List<IBeaconGateWay> gatewaylist;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            devlist = TableOperate<IBeaconDev>.Select();
            gatewaylist = TableOperate<IBeaconGateWay>.Select();

            Stream postData = Request.InputStream;//创建流  获取传入的 HTTP 实体主体的内容。
            var rawObject = Unpacking.UnpackObject(postData);//拆包解压缩

            jsoner = rawObject.ToString();
            
            if (jsoner != "")
            {
                //数据库操作
                //  2018/11/20 11:32:38;{ "v" : "1.1.0.26", "mid" : 851, "time" : 1748, "ip" : "192.168.60.19", "mac" : "B4E62DBE9A01", "devices" : [ "0x001918FC0532D2BF0201061AFF4C000215FDA50693A4E24FB1AFCFC6EB0764782527121458C5", "0x03123B6A1B8AF5BF0201061AFF4C000215B5B182C7EAB14988AA99B5C1517008D900010002C5" ] }
                AddJson(jsoner);

                //////
               // Response.Write(jsoner);
            }
            else
            {
                Response.Write(-2);
            }
        }
        catch (Exception ex)
        {
            SaveExLog(ex.ToString());
        }
    }
    public class Keys
    {
        public string v;
     
    }

    public byte[] StreamToBytes(Stream stream)
{
    byte[] bytes = new byte[stream.Length];
        stream.Read(bytes,0, bytes.Length);
   
 
    stream.Seek(0,SeekOrigin.Begin);
    return bytes;
}
    public static void SaveExLog(string strErrMessage)
    {

        string strCurrentPath = @"C:\Log\";

        if (Directory.Exists(strCurrentPath) == false)
        {
            DirectoryInfo dirPathInfo = Directory.CreateDirectory(strCurrentPath);
        }

        string strFilePath = strCurrentPath + DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.DateTimeFormatInfo.InvariantInfo) + ".log";



        try
        {
            File.AppendAllText(strFilePath, DateTime.Now.ToString() + ";" + strErrMessage + "\r\n");
        }

        catch (Exception ex)
        {
            //SaveExLog(ex + ";strErrMessage: " + strErrMessage);
        }

        finally
        {
            //TODO
        }

    }
    private void AddJson(string jsonStr)
    {
      
        //  jsonStr="{ \"v\" : \"1.1.0.26\", \"mid\" : 851, \"time\" : 1748, \"ip\" : \"192.168.60.19\", \"mac\" : \"B4E62DBE9A01\", \"devices\" : [ \"0x001918FC0532D2BF0201061AFF4C000215FDA50693A4E24FB1AFCFC6EB0764782527121458C5\", \"0x03123B6A1B8AF5BF0201061AFF4C000215B5B182C7EAB14988AA99B5C1517008D900010002C5\" ] }";
        //SaveExLog(jsonStr);
        string mac = "";

        if (jsonStr.IndexOf("devices") > -1)
        {
            JsonData json = JsonMapper.ToObject(jsonStr);
            mac = Convert.ToString(json["mac"]);
            //0x03
            //12 3B 6A 1B 8A F5
            //CA 02 01 06 1A FF 4C 00 
            //02 15 B5 B1 82 C7 EA B1 49 88 AA 99 B5 C1 51 70 08 D9 00 01 00 02 C5
            JsonData list = json["devices"];
            IBeaconGateWay beacon = gateWay(mac);
            if (beacon!=null)
            {
                list = RemoveJson(list);
                
                double maxdistance = beacon.MaxDistance;//设置的最大距离
                for (int i = 0; i < list.Count; i++)
                {
                    string blueMac = list[i].ToString().Substring(4, 12);
                    IBeaconDev blue = Isdev(blueMac);
                    if (blue!=null)
                    {
                        
                        if (blue.ID > 0&&blue.UserID>0)//&&blue.UserID!=0非绑定不做操作
                        {
                            string rssi = list[i].ToString().Substring(16, 2);
                            int NowRssi = toRssi(rssi) - 256;
                            double distance = getDistance(-59, Convert.ToDouble(NowRssi));
                            
                            if (distance <= maxdistance)//在设置的最大距离范围内
                            {
                                SaveExLog(beacon.ID+"---"+mac+"-----"+blueMac + "信号-" + NowRssi + "预估距离-" + distance);
                                StopTime(blue.ID, beacon.ID,blue.UserID);
                                
                            }
                        }
                    } 
                }
            }
        }


        // SaveExLog(jsonStr);


    }
       /// <summary>
    /// 更新当前位置
    /// </summary>
    /// <param name="devID"></param>
    /// <param name="GateWayID"></param>
    /// <param name="distance"></param>
    private void Into(int devID,int GateWayID,double distance ,int UserID)
    {
        IBeaconDevNow condition = new IBeaconDevNow();
        condition.DevID = devID;
        IBeaconDevNow devNow = TableOperate<IBeaconDevNow>.GetRowData(condition);
        condition.LastTime = DateTime.Now;
        condition.GateWayID = GateWayID;
        condition.Distance = distance;
        if (devNow.ID > 0)
        {
            

                condition.ID = devNow.ID;
                TableOperate<IBeaconDevNow>.Update(condition);
                StopTime(devID, GateWayID,UserID);

            
          

        }
        else
        {
            TableOperate<IBeaconDevNow>.Insert(condition);
        }
    }
    private void StopTime(int devID, int GateWayID,int Uid)
    {
        IBeaconData condition = new IBeaconData();
        condition.DevID = devID;
        condition.GateWayID = GateWayID;
        condition.UserID = Uid;
        condition.AddConditon(" and DateDiff(dd,LastTime,getdate())=0");//今天
        IBeaconData data = TableOperate<IBeaconData>.GetRowData(condition);
        if (data.ID > 0)//获取今天的数据
        {
            TimeSpan t3 = DateTime.Now - data.LastTime;
            double time = t3.TotalSeconds;
            if (time > 58 && time <= 70)//更新间隔50秒和60s之间算持续站在范围内
            {
                condition.StopTime = data.StopTime + 1;
                condition.ID = data.ID;
                condition.LastTime = DateTime.Now;
                TableOperate<IBeaconData>.Update(condition);
                AddStopTime(1, GateWayID);
            }
            else if (time > 120)//离开再回来120秒后计算
            {
                condition.ID = data.ID;
                condition.LastTime = DateTime.Now;
                TableOperate<IBeaconData>.Update(condition);
            }

        }
        else
        {
           
            condition.StopTime = 1;
            condition.LastTime = DateTime.Now;
            TableOperate<IBeaconData>.Insert(condition);
            AddStopTime(1, GateWayID);
            IntoGetWay(GateWayID);
        }
    }
    private void IntoGetWay(int DevID)//增加展区参观人数
    {
        IBeaconGateWay condition = new IBeaconGateWay();
        condition.ID = DevID;
        IBeaconGateWay ibecont = TableOperate<IBeaconGateWay>.GetRowData(condition);
        if (ibecont.ID > 0)
        {
            condition = new IBeaconGateWay();
            condition.X = ibecont.X + 1;
            condition.ID = ibecont.ID;
            TableOperate<IBeaconGateWay>.Update(condition);
        }

    }
    private void AddStopTime(int time,int GateWayID)
    {
        UserVistCount condition = new UserVistCount();
        condition.ID = 1;
        UserVistCount user = TableOperate<UserVistCount>.GetRowData(condition);
        if (user.ID > 0)
        {
            condition.StopTime = user.StopTime +time;
            condition.ID = 1;
            TableOperate<UserVistCount>.Update(condition);
        }
        IBeaconGateWay condition1 = new IBeaconGateWay();//增加展区停留时间
        condition1.ID = GateWayID;
        IBeaconGateWay ibecont = TableOperate<IBeaconGateWay>.GetRowData(condition1);
        if (ibecont.ID > 0)
        {
            condition1 = new IBeaconGateWay();
            condition1.Y = ibecont.Y + 1;
            condition1.ID = ibecont.ID;
            TableOperate<IBeaconGateWay>.Update(condition1);
        }

    }
    /// <summary>
    /// 过滤重复数据
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    private JsonData RemoveJson(JsonData list)
    {
        JsonData json = new JsonData();
        for (int i = 0; i < list.Count; i++)
        {
            string blueMac = list[i].ToString().Substring(4, 12);
            if (json.ToJson().IndexOf(list[i].ToJson()) ==-1)
            {
                json.Add(list[i]);
            }
        }
        return RemoveJsonMac(json);
    }
    private JsonData RemoveJsonMac(JsonData list)
    {
        JsonData json = new JsonData();
        for (int i = 0; i < list.Count; i++)
        {
            string blueMac = list[i].ToString().Substring(4, 12);
            if (json.ToJson().IndexOf(blueMac) == -1)
            {
                json.Add(list[i]);
            }
        }
        return json;
    }
    /// <summary>
    /// 查询mac是否存在
    /// </summary>
    /// <param name="mac"></param>
    /// <returns></returns>
    protected IBeaconGateWay gateWay(string mac)
    {
        for (int i = 0; i < gatewaylist.Count; i++)
        {
            if (gatewaylist[i].MAC.ToLower() == mac.ToLower())
            {
                return gatewaylist[i];
            }
        }
        return null;

    }
    /// <summary>
    /// 查询蓝牙手环是否存在
    /// </summary>
    /// <param name="Mac"></param>
    /// <returns></returns>
    protected IBeaconDev Isdev(string Mac)
    {
        for (int i = 0; i < devlist.Count; i++)
        {
            if (devlist[i].BeaconMac.ToLower() == Mac.ToLower())
            {
                return devlist[i];
            }
        }
        return null;


    }
    /// <summary>
    /// 信号转换距离
    /// </summary>
    /// <param name="measuredPower"></param>
    /// <param name="rssi"></param>
    /// <returns></returns>
    public double getDistance(int measuredPower, double rssi)
    {
        if (rssi >= 0)
        {
            return -1.0;
        }
        if (measuredPower == 0)
        {
            return -1.0;
        }
        double ratio = rssi * 1.0 / measuredPower;
        if (ratio < 1.0)
        {
            return Math.Pow(ratio, 10);
        }
        else
        {
            double distance = (0.42093) * Math.Pow(ratio, 6.9476) + 0.54992;
            return distance;
        }
    }
    protected int toRssi(string rssi)
    {
        Byte b = Byte.Parse(rssi.Substring(0, 2),System.Globalization.NumberStyles.HexNumber);
        return b;
    }
 

    /// <summary>
    /// 程序执行时间测试
    /// </summary>
    /// <param name="dateBegin">开始时间</param>
    /// <param name="dateEnd">结束时间</param>
    /// <returns>返回(秒)单位，比如: 0.00239秒</returns>
    public static int ExecDateDiff(DateTime dateBegin, DateTime dateEnd)
    {
        TimeSpan ts1 = new TimeSpan(dateBegin.Ticks);
        TimeSpan ts2 = new TimeSpan(dateEnd.Ticks);
        TimeSpan ts3 = ts1.Subtract(ts2).Duration();
        //你想转的格式
        return Convert.ToInt32(ts3.TotalMinutes);
    }
 
   
    public static string SubString(string sourceStr, string beginStr, string endStr)
    {
        int begin = sourceStr.IndexOf(beginStr);
        if (begin == -1) return "";
        int end = sourceStr.IndexOf(endStr, begin + beginStr.Length);
        if (end == -1 && end == begin + beginStr.Length) return "";

        return sourceStr.Substring(begin + beginStr.Length, end - begin - beginStr.Length);

    }

    private string PostInput()
    {
       

        try
        {
            System.IO.Stream s = Request.InputStream;
            int count = 0;
            byte[] buffer = new byte[1024];
            StringBuilder builder = new StringBuilder();
            while ((count = s.Read(buffer, 0, 1024)) > 0)
            {
                builder.Append(Encoding.UTF8.GetString(buffer, 0, count));

            }
            s.Flush();
            s.Close();
            s.Dispose();

            return builder.ToString();
        }
        catch (Exception ex)
        { throw ex; }
    }
}