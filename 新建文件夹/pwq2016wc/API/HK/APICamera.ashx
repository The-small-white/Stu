<%@ WebHandler Language="C#" Class="APICamera" %>

using System;
using System.Web;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System.Configuration;
using System.Data;
using System.Collections.Generic;

public class APICamera : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        string result = "";
        try
        {
            context.Response.ContentType = "text/plain";
            //context.Response.AddHeader("Access-Control-Allow-Origin", "*");

            result += "进入接口了;\r\n";

            string xmlStr = GetRequestMsg(context.Request);
            //xmlStr = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><EventNotificationAlert ><ipAddress>192.168.60.221</ipAddress><protocolType>HTTP</protocolType><macAddress>4c:bd:8f:c4:00:87</macAddress><channelID>1</channelID><dateTime>2017-09-01T11:57:40+08:00</dateTime><activePostCount>74</activePostCount><eventType>PeopleCounting</eventType><eventState>active</eventState><eventDescription>peopleCounting alarm</eventDescription><channelName>Camera 01</channelName><peopleCounting><statisticalMethods>realTime</statisticalMethods><RealTime><time>2017-09-03T13:57:35+08:00</time></RealTime><enter>167</enter><exit>454</exit><pass>9729</pass></peopleCounting></EventNotificationAlert>";

            result += "\r\n接收到的数据:\r\n" + xmlStr + "\r\n";
            CloudLog cloud = new CloudLog();
            cloud.Brief = result;
            TableOperate<CloudLog>.Insert(cloud);
            if (string.IsNullOrEmpty(xmlStr))
            {
                ResponseEnd("null");
            }

            //根据字符串加载xml文档
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlStr);

            //判断"statisticalMethods"节点的内容,是realTime则进行操作,不是则不操作
            if (doc.GetElementsByTagName("statisticalMethods")[0].InnerText != "realTime")
            {
                ResponseEnd("no-realTime");
            }

            //获取值
            string cameraName = doc.GetElementsByTagName("channelName")[0].InnerText;//只输出文本
            string macAddress = doc.GetElementsByTagName("macAddress")[0].InnerText;
            string ipAddress = doc.GetElementsByTagName("ipAddress")[0].InnerText;
            DateTime time = Convert.ToDateTime(doc.GetElementsByTagName("RealTime")[0].FirstChild.InnerText);
            int enter = Convert.ToInt32(doc.GetElementsByTagName("enter")[0].InnerText);
            int exit = Convert.ToInt32(doc.GetElementsByTagName("exit")[0].InnerText);

            //新增camera
            int cameraID = 0;
            Camera camera = new Camera();
            camera.Name = cameraName;
            camera.MacAddress = macAddress;
            camera.IPAddress = ipAddress;
            AddCamera(camera, out cameraID);

            //新增或修改 PeopleCount
            PeopleCount pc = new PeopleCount();
            pc.ExitNum = exit;
            pc.EnterNum = enter;
            pc.CountTime = time;
            pc.CameraID = cameraID;
            UpdatePeopleCount(pc);
        }
        catch (Exception ex)
        {

        }
        finally
        {

        }
    }

    /// <summary>
    /// 修改人流统计数据
    /// </summary>
    private void UpdatePeopleCount(PeopleCount pc)
    {
        DateTime beginTime = new DateTime(pc.CountTime.Year, pc.CountTime.Month, pc.CountTime.Day, pc.CountTime.Hour, 0, 0);
        DateTime endTime = beginTime.AddHours(1);//在开始时间上加一小时
        PeopleCount condition = new PeopleCount();
        condition.AddConditon(" and CountTime>= '" + beginTime + "' and CountTime< '" + endTime + "' and CameraID=" + pc.CameraID);
        PeopleCount newPc = TableOperate<PeopleCount>.GetRowData(condition);

        //本段小时内的出入人口数
        int enterNum = 0;
        int exitNum = 0;

        GetCountNum(out enterNum, out exitNum, pc);
        if (newPc.ID > 0)//存在
        {
            //把查出来的数据进行增加
            newPc.ExitNum += (pc.ExitNum - exitNum);
            newPc.EnterNum += (pc.EnterNum - enterNum);
            TableOperate<PeopleCount>.Update(newPc);//更新下查出来的数据
        }
        else //不存在,直接插入新数据
        {
            pc.ExitNum -= exitNum;
            pc.EnterNum -= enterNum;
            TableOperate<PeopleCount>.InsertReturnID(pc);//插入并返回插入信息的ID
        }
    }
    private void GetCountNum(out int enterNum, out int exitNum, PeopleCount pc)
    {
        enterNum = exitNum = 0;
        //计算今天的所有人数
        DateTime begin = new DateTime(pc.CountTime.Year, pc.CountTime.Month, pc.CountTime.Day, 0, 0, 0);
        PeopleCount p1 = new PeopleCount();
        PeopleCount p2 = new PeopleCount();
        p1.AddConditon(" and CountTime>='" + begin + "' and CountTime<='" + pc.CountTime + "' and CameraID=" + pc.CameraID);

        List<PeopleCount> list = TableOperate<PeopleCount>.Select(p2, p1);

        //得出今天的所有出入人数
        if (list.Count > 0)
        {
            foreach (PeopleCount item in list)
            {
                enterNum += item.EnterNum;
                exitNum += item.ExitNum;
            }
        }
    }

    /// <summary>
    /// 根据传入的摄像头查询是否已存在该摄像头,不存在则创建
    /// </summary>
    private void AddCamera(Camera camera,out int cameraID)
    {
        Camera newCamera = TableOperate<Camera>.GetRowData(camera);
        cameraID = newCamera.ID;
        if (newCamera.ID == 0)
        {
            cameraID = TableOperate<Camera>.InsertReturnID(camera);
        }
    }

    /// <summary>
    /// 获取流文本
    /// </summary>
    private string GetRequestMsg(HttpRequest Request)
    {
        if (Request.RequestType.ToUpper() == "POST")
        {
            Stream stream = Request.InputStream;//获取传入的 HTTP 实体主体的内容。
            using (StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8))//将传过来的值转换成UTF8格式
            {
                return reader.ReadToEnd();
            }
        }
        return "";
    }

    /// <summary>
    /// 返回响应内容并结束响应
    /// </summary>
    private void ResponseEnd(string msg)
    {
        HttpContext.Current.Response.Write(msg);
        HttpContext.Current.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}