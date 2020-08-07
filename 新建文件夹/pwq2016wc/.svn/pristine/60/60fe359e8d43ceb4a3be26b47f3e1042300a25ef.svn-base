using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dejun.DataProvider.Table;
using Dejun.DataProvider.Sql2005;

/// <summary>
/// Lognet 的摘要说明
/// </summary>
public class Lognet
{
    public Lognet()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 操作日志
    /// </summary>
    /// <param name="brief"></param>
    public static void AddLogin(string brief)
    {
        CloudLog log = new CloudLog();
        log.AddTime = DateTime.Now;
        log.Brief = brief;
        log.AddID = AdminMethod.AdminID;
        log.ExhibitionID = AdminMethod.ExhibitionID;
        TableOperate<CloudLog>.Insert(log);
    }
    public static void AddMailBox(string log)
    {
        List<Admin_User> list = TableOperate<Admin_User>.Select();
        for (int i = 0; i < list.Count; i++)
        {
            Mailbox condition = new Mailbox();
            condition.Msg = log;
            condition.SendID = AdminMethod.AdminID;
            condition.ReceiveID = list[i].ID;
            condition.AddTime = DateTime.Now;
            condition.States = 0;
            condition.SendName = AdminMethod.AdminFullName;
            TableOperate<Mailbox>.Insert(condition);
        }
    }
}