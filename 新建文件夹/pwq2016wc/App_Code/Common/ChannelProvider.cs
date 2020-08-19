using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Dejun.DataProvider.Table;
using Dejun.DataProvider.Sql2005;
using System.Collections.Generic;

/// <summary>
/// 栏目表 相关操作方法 
/// </summary>
public class ChannelProvider
{
    public ChannelProvider()
    {
        //Channel s = new Channel();
       // s.SetAutoInsert("")
    }


    #region 添加栏目
    /// <summary>
    /// 添加栏目
    /// </summary>
    public static int Insert(Channel channel)
    {
        if (channel.ParentID == 0)
        {
            channel.Depth = 0;
            channel.ParentID = 0;
            channel.Path = "0~";
            channel.NamePath = "所有栏目~";
            channel.AddInsert("RootID", "IDENT_CURRENT('Channel')");
        }
        else
        {
            Channel condition = new Channel();
            condition.ID = channel.ParentID;
            Channel pArentChannel = TableOperate<Channel>.GetRowData(condition);
            string path = Convert.ToString(pArentChannel.Path) + channel.ParentID + "~";
            string namePath = Convert.ToString(pArentChannel.NamePath) + Convert.ToString(pArentChannel.Name) + "~";
            channel.Depth = pArentChannel.Depth + 1;
            channel.Path = path;
            channel.RootID = pArentChannel.RootID;
            channel.NamePath = namePath;
        }
        return TableOperate<Channel>.InsertReturnID(channel);
    }
    #endregion

    #region 修改栏目
    /// <summary>
    /// 修改栏目
    /// </summary>
    public static int Update(Channel channel)
    {
        //修改信息
 
        Channel condition = new Channel();
        condition.ID = channel.ID;
        Channel oldChannel = TableOperate<Channel>.GetRowData(condition);


        if (channel.ParentID != oldChannel.ParentID)
        {
            if (channel.ParentID == 0)
            {
                channel.Depth = 0;
                channel.ParentID = 0;
                channel.Path = "0~";
                channel.NamePath = "所有栏目~";
                channel.AddInsert("RootID", "IDENT_CURRENT('Channel')");
            }
            else
            {
                condition = new Channel();
                condition.ID = channel.ParentID;
                Channel pArentChannel = TableOperate<Channel>.GetRowData(condition);

                string path = Convert.ToString(pArentChannel.Path) + channel.ParentID + "~";
                string namePath = Convert.ToString(pArentChannel.NamePath) + Convert.ToString(pArentChannel.Name) + "~";
                channel.Depth = pArentChannel.Depth + 1;
                channel.Path = path;
                channel.RootID = pArentChannel.RootID;
                channel.NamePath = namePath;

            }

        }
        else
        {
            channel.Depth = oldChannel.Depth;
            channel.Path = oldChannel.Path;
            channel.NamePath = oldChannel.NamePath;
            channel.RootID = oldChannel.RootID;
        }
        //修改下面是有的子项的Depth， Path， RootID， NamePath
        UpdateChild(channel, oldChannel);

        return TableOperate<Channel>.Update(channel);
    }
    #endregion

    private static int UpdateChild(Channel channel, Channel oldChannel)
    {
        //int depthSpan = channel.Depth - oldChannel.Depth;
        Channel value = new Channel();
        Channel condition = new Channel();
        condition.Path = "%~" + channel.ID + "~%";
        condition.AddAttach("Path", "like");

        value.RootID = channel.RootID;
        value.Depth = channel.Depth - oldChannel.Depth;
        value.AddParameter("OldPath", oldChannel.Path + "" + channel.ID + "~");
        value.AddParameter("OldNamePath", oldChannel.NamePath + "" + oldChannel.Name + "~");
        value.Path = channel.Path + "" + channel.ID + "~";
        value.NamePath = channel.NamePath + "" + channel.Name + "~";
     
        value.SetUpdate(" RootID=@RootID, Depth = Depth + @Depth, [Path]=REPLACE([Path], @OldPath, @Path) , [NamePath]=REPLACE([NamePath], @OldNamePath, @NamePath)");
        return TableOperate<Channel>.Update(value, condition);
    }


    #region 读取所有栏目数据
    /// <summary>
    /// 读取所有栏目数据
    /// </summary>
    /// <returns></returns>
    public static List<Channel> SelectAll()
    {
        return SelectByRootID(0);
    }
    #endregion

    public static List<Channel> SelectByRootID(int rootID)
    {
        List<Channel> channelData = new List<Channel>();
        List<int> idList = new List<int>();

        //查询数据
        Channel value = new Channel();
        Channel conditon = new Channel();
        if (AdminMethod.ExhibitionID != 0)
        {
            conditon.ExhibitionID = AdminMethod.ExhibitionID;
        }
        if (rootID > 0)
        {
            conditon.RootID = rootID;
        }
        List<Channel> oldTypeData = TableOperate<Channel>.Select(value, conditon, 0, " order by Depth, ParentID, OrderID DESC, ID DESC");
       
        for (int i = 0; i < oldTypeData.Count; i++)
        {
            Channel typeObj = oldTypeData[i];
            if (typeObj.Depth == 0) //深度为0，直接添加
            {
                channelData.Insert(0, typeObj);
                idList.Insert(0, typeObj.ID);
            }
            else
            {
                //对list集合进行操作
                int pArentIndex = idList.IndexOf(typeObj.ParentID);//查找上及目录所在位置！
                channelData.Insert(pArentIndex + 1, typeObj);
                idList.Insert(pArentIndex + 1, typeObj.ID);    //将数据插入上级目录之后
            }
        }
        return channelData;
    }

    public static List<Channel> MySelectByParentID(int ParentID)
    {
        List<Channel> channelData = new List<Channel>();
        List<int> idList = new List<int>();

        //查询数据
        Channel value = new Channel();
        Channel conditon = new Channel();
        if (ParentID > 0)
        {
            conditon.Path = "%~" + ParentID + "~%";
            conditon.AddAttach("Path", "like");
        }

        List<Channel> oldTypeData = TableOperate<Channel>.Select(value, conditon, 0, " order by ParentID, Depth, OrderID DESC, ID DESC ");

        for (int i = 0; i < oldTypeData.Count; i++)
        {
            Channel typeObj = oldTypeData[i];
            if (typeObj.Depth == 0) //深度为0，直接添加
            {
                channelData.Insert(0, typeObj);
                idList.Insert(0, typeObj.ID);
            }
            else
            {
                int pArentIndex = idList.IndexOf(typeObj.ParentID);//查找上及目录所在位置！
                channelData.Insert(pArentIndex + 1, typeObj);
                idList.Insert(pArentIndex + 1, typeObj.ID);    //将数据插入上级目录之后
            }
        }
        return channelData;
    }
    public static List<Channel> SelectByParentID(int ParentID)
    {
        List<Channel> channelData = new List<Channel>();
        List<int> idList = new List<int>();

        //查询数据
        Channel value = new Channel();
        Channel conditon = new Channel();
        if (AdminMethod.ExhibitionID != 0)
        {
            conditon.ExhibitionID = AdminMethod.ExhibitionID;
        }
        if (ParentID > 0)
        {
            conditon.Path = "%~" + ParentID + "~%";
            conditon.AddAttach("Path", "like");
        }

        List<Channel> oldTypeData = TableOperate<Channel>.Select(value, conditon, 0, " order by ParentID, Depth, OrderID DESC, ID DESC ");
        
        for (int i = 0; i < oldTypeData.Count; i++)
        {
            Channel typeObj = oldTypeData[i];
            if (typeObj.Depth == 0) //深度为0，直接添加
            {
                channelData.Insert(0, typeObj);
                idList.Insert(0, typeObj.ID);
            }
            else
            {
                int pArentIndex = idList.IndexOf(typeObj.ParentID);//查找上及目录所在位置！
                channelData.Insert(pArentIndex + 1, typeObj);
                idList.Insert(pArentIndex + 1, typeObj.ID);    //将数据插入上级目录之后
            }
        }
        return channelData;
    }

    
    public static string GetDepth(int depth)
    {
        string depthstr = "";
        for (int i = 0; i < depth; i++)
        {
            depthstr += "&nbsp;&nbsp;&nbsp;&nbsp;";
        }
        return depthstr;
    }


    /// <summary>
    /// 获取所有子类id序列，例如 1,3,4,5,6
    /// </summary>
    /// <param name="id">要查询频道的id</param>
    /// <returns></returns>
    public static string GetChildID(int id)
    {
        Channel value = new Channel();
        value.ID = 0;
        Channel conditon = new Channel();
        conditon.Path = "%~" + id + "~%";
        conditon.AddAttach("Path", "like");
        if (AdminMethod.ExhibitionID != 0)
        {
            conditon.ExhibitionID = AdminMethod.ExhibitionID;
        }
        List<Channel> childChannelList = TableOperate<Channel>.Select(value, conditon);

        string idStr = "";
        for (int i = 0; i < childChannelList.Count; i++)
        {
            idStr += childChannelList[i].ID + ",";
        }

        idStr = idStr.Trim(',');
        return idStr;
    }

    /// <summary>
    /// 获取子id和当前id组成的字符串 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static string GetMyChildID(int id)
    {
        string idStr = GetChildID(id);
        idStr = id + "," + idStr;
        idStr = idStr.Trim(',');
        return idStr;
    }

    public static Channel GetChannelByID(int id)
    {
        Channel conditon = new Channel();
        conditon.ID = id;
        if (AdminMethod.ExhibitionID != 0)
        {
            conditon.ExhibitionID = AdminMethod.ExhibitionID;
        }
        return TableOperate<Channel>.GetRowData(conditon);
    }
    public static List<Channel> GetMyID(int id)
    {
        Channel value = new Channel();
        Channel conditon = new Channel();
        conditon.ID = id;

        List<Channel> oldTypeData = TableOperate<Channel>.Select(value, conditon, 0, " order by ParentID, Depth, OrderID DESC, ID DESC ");
        return oldTypeData;
    }

    public static string GetHtmlUrl(int id)
    {
        Channel condition = new Channel();
        condition.ID = id;
        if (AdminMethod.ExhibitionID != 0)
        {
            condition.ExhibitionID = AdminMethod.ExhibitionID;
        }
        Channel newChannel = TableOperate<Channel>.GetRowData(condition);

        //string tFile = StaticPage.GetUrlRule(newChannel.TemplateFile, id);
        //string relustFile = StaticPage.GetUrlRule(newChannel.LanMuRule, newChannel.RootID, id, 0);
        return "";
    }
}
