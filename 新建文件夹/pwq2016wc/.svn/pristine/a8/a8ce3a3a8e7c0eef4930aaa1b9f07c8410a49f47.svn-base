using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;

/// <summary>
/// 栏目表 相关操作方法 
/// </summary>
public class ModeChannelProvider
{
    public ModeChannelProvider()
    {
        //Channel s = new Channel();
       // s.SetAutoInsert("")
    }


    #region 添加栏目
    /// <summary>
    /// 添加栏目
    /// </summary>
    public static int Insert(ModeChannel channel)
    {
        if (channel.ParentID == 0)
        {
            channel.Depth = 0;
            channel.ParentID = 0;
            channel.Path = "0~";
            channel.NamePath = "所有栏目~";
            channel.AddInsert("RootID", "IDENT_CURRENT('ModeChannel')");
        }
        else
        {
            ModeChannel condition = new ModeChannel();
            condition.ID = channel.ParentID;
            ModeChannel pArentChannel = TableOperate<ModeChannel>.GetRowData(condition);
            string path = Convert.ToString(pArentChannel.Path) + channel.ParentID + "~";
            string namePath = Convert.ToString(pArentChannel.NamePath) + Convert.ToString(pArentChannel.Name) + "~";
            channel.Depth = pArentChannel.Depth + 1;
            channel.Path = path;
            channel.RootID = pArentChannel.RootID;
            channel.NamePath = namePath;
        }
        return TableOperate<ModeChannel>.InsertReturnID(channel);
    }
    #endregion

    #region 修改栏目
    /// <summary>
    /// 修改栏目
    /// </summary>
    public static int Update(ModeChannel channel)
    {
        //修改信息

        ModeChannel condition = new ModeChannel();
        condition.ID = channel.ID;
        ModeChannel oldChannel = TableOperate<ModeChannel>.GetRowData(condition);


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
                condition = new ModeChannel();
                condition.ID = channel.ParentID;
                ModeChannel pArentChannel = TableOperate<ModeChannel>.GetRowData(condition);

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

        return TableOperate<ModeChannel>.Update(channel);
    }
    #endregion

    private static int UpdateChild(ModeChannel channel, ModeChannel oldChannel)
    {
        //int depthSpan = channel.Depth - oldChannel.Depth;
        ModeChannel value = new ModeChannel();
        ModeChannel condition = new ModeChannel();
        condition.Path = "%~" + channel.ID + "~%";
        condition.AddAttach("Path", "like");

        value.RootID = channel.RootID;
        value.Depth = channel.Depth - oldChannel.Depth;
        value.AddParameter("OldPath", oldChannel.Path + "" + channel.ID + "~");
        value.AddParameter("OldNamePath", oldChannel.NamePath + "" + oldChannel.Name + "~");
        value.Path = channel.Path + "" + channel.ID + "~";
        value.NamePath = channel.NamePath + "" + channel.Name + "~";
     
        value.SetUpdate(" RootID=@RootID, Depth = Depth + @Depth, [Path]=REPLACE([Path], @OldPath, @Path) , [NamePath]=REPLACE([NamePath], @OldNamePath, @NamePath)");
        return TableOperate<ModeChannel>.Update(value, condition);
    }


    #region 读取所有栏目数据
    /// <summary>
    /// 读取所有栏目数据
    /// </summary>
    /// <returns></returns>
    public static List<ModeChannel> SelectAll()
    {
        return SelectByRootID(0);
    }
    #endregion

    public static List<ModeChannel> SelectByRootID(int rootID)
    {
        List<ModeChannel> channelData = new List<ModeChannel>();
        List<int> idList = new List<int>();

        //查询数据
        ModeChannel value = new ModeChannel();
        ModeChannel conditon = new ModeChannel();
        if (AdminMethod.ExhibitionID != 0)
        {
            conditon.ExhibitionID = AdminMethod.ExhibitionID;
        }

        if (rootID > 0)
        {
            conditon.RootID = rootID;
        }

        List<ModeChannel> oldTypeData = TableOperate<ModeChannel>.Select(value, conditon, 0, " order by Depth, ParentID, OrderID DESC, ID DESC ");

        for (int i = 0; i < oldTypeData.Count; i++)
        {
            ModeChannel typeObj = oldTypeData[i];
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

    public static List<ModeChannel> MySelectByParentID(int ParentID)
    {
        List<ModeChannel> channelData = new List<ModeChannel>();
        List<int> idList = new List<int>();

        //查询数据
        ModeChannel value = new ModeChannel();
        ModeChannel conditon = new ModeChannel();
        if (ParentID > 0)
        {
            conditon.Path = "%~" + ParentID + "~%";
            conditon.AddAttach("Path", "like");
        }

        List<ModeChannel> oldTypeData = TableOperate<ModeChannel>.Select(value, conditon, 0, " order by ParentID, Depth, OrderID DESC, ID DESC ");

        for (int i = 0; i < oldTypeData.Count; i++)
        {
            ModeChannel typeObj = oldTypeData[i];
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
    public static List<ModeChannel> SelectByParentID(int ParentID)
    {
        List<ModeChannel> channelData = new List<ModeChannel>();
        List<int> idList = new List<int>();

        //查询数据
        ModeChannel value = new ModeChannel();
        ModeChannel conditon = new ModeChannel();
        if (AdminMethod.ExhibitionID != 0)
        {
            conditon.ExhibitionID = AdminMethod.ExhibitionID;
        }
        if (ParentID > 0)
        {
            conditon.Path = "%~" + ParentID + "~%";
            conditon.AddAttach("Path", "like");
        }

        List<ModeChannel> oldTypeData = TableOperate<ModeChannel>.Select(value, conditon, 0, " order by ParentID, Depth, OrderID DESC, ID DESC ");
        
        for (int i = 0; i < oldTypeData.Count; i++)
        {
            ModeChannel typeObj = oldTypeData[i];
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
        ModeChannel value = new ModeChannel();
        value.ID = 0;
        ModeChannel conditon = new ModeChannel();
        conditon.Path = "%~" + id + "~%";
        conditon.AddAttach("Path", "like");
        if (AdminMethod.ExhibitionID != 0)
        {
            conditon.ExhibitionID = AdminMethod.ExhibitionID;
        }
        List<ModeChannel> childChannelList = TableOperate<ModeChannel>.Select(value, conditon);

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

    public static ModeChannel GetChannelByID(int id)
    {
        ModeChannel conditon = new ModeChannel();
        conditon.ID = id;
        if (AdminMethod.ExhibitionID != 0)
        {
            conditon.ExhibitionID = AdminMethod.ExhibitionID;
        }
        return TableOperate<ModeChannel>.GetRowData(conditon);
    }
    public static List<ModeChannel> GetMyID(int id)
    {
        ModeChannel value = new ModeChannel();
        ModeChannel conditon = new ModeChannel();
        conditon.ID = id;

        List<ModeChannel> oldTypeData = TableOperate<ModeChannel>.Select(value, conditon, 0, " order by ParentID, Depth, OrderID ASC, ID DESC ");
        return oldTypeData;
    }

    public static string GetHtmlUrl(int id)
    {
        ModeChannel condition = new ModeChannel();
        condition.ID = id;
        if (AdminMethod.ExhibitionID != 0)
        {
            condition.ExhibitionID = AdminMethod.ExhibitionID;
        }
        ModeChannel newChannel = TableOperate<ModeChannel>.GetRowData(condition);

        //string tFile = StaticPage.GetUrlRule(newChannel.TemplateFile, id);
        //string relustFile = StaticPage.GetUrlRule(newChannel.LanMuRule, newChannel.RootID, id, 0);
        return "";
    }
}
