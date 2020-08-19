using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;

/// <summary>
/// 栏目表 相关操作方法 
/// </summary>
public class ExhibitionProvider
{
    public ExhibitionProvider()
    {
        //Channel s = new Channel();
        // s.SetAutoInsert("")
    }


    #region 添加栏目
    /// <summary>
    /// 添加栏目
    /// </summary>
    public static int Insert(Exhibition channel)
    {
        if (channel.ParentID == 0)
        {
            channel.Depth = 0;
            channel.ParentID = 0;
            channel.Path = "0~";
            channel.NamePath = "所有栏目~";
            channel.AddInsert("RootID", "IDENT_CURRENT('Exhibition')");
        }
        else
        {
            Exhibition condition = new Exhibition();
            condition.ID = channel.ParentID;
            Exhibition parentChannel = TableOperate<Exhibition>.GetRowData(condition);
            string path = Convert.ToString(parentChannel.Path) + channel.ParentID + "~";
            string namePath = Convert.ToString(parentChannel.NamePath) + Convert.ToString(parentChannel.Name) + "~";
            channel.Depth = parentChannel.Depth + 1;
            channel.Path = path;
            channel.RootID = parentChannel.RootID;
            channel.NamePath = namePath;
        }
        return TableOperate<Exhibition>.InsertReturnID(channel);
    }
    #endregion

    #region 修改栏目
    /// <summary>
    /// 修改栏目
    /// </summary>
    public static int Update(Exhibition channel)
    {
        //修改信息

        Exhibition condition = new Exhibition();
        condition.ID = channel.ID;
        Exhibition oldChannel = TableOperate<Exhibition>.GetRowData(condition);


        if (channel.ParentID != oldChannel.ParentID)
        {
            if (channel.ParentID == 0)
            {
                channel.Depth = 0;
                channel.ParentID = 0;
                channel.Path = "0~";
                channel.NamePath = "所有栏目~";
                channel.AddInsert("RootID", "IDENT_CURRENT('Exhibition')");
            }
            else
            {
                condition = new Exhibition();
                condition.ID = channel.ParentID;
                Exhibition parentChannel = TableOperate<Exhibition>.GetRowData(condition);

                string path = Convert.ToString(parentChannel.Path) + channel.ParentID + "~";
                string namePath = Convert.ToString(parentChannel.NamePath) + Convert.ToString(parentChannel.Name) + "~";
                channel.Depth = parentChannel.Depth + 1;
                channel.Path = path;
                channel.RootID = parentChannel.RootID;
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

        return TableOperate<Exhibition>.Update(channel);
    }
    #endregion

    private static int UpdateChild(Exhibition channel, Exhibition oldChannel)
    {
        //int depthSpan = channel.Depth - oldChannel.Depth;
        Exhibition value = new Exhibition();
        Exhibition condition = new Exhibition();
        condition.Path = "%~" + channel.ID + "~%";
        condition.AddAttach("Path", "like");

        value.RootID = channel.RootID;
        value.Depth = channel.Depth - oldChannel.Depth;
        value.AddParameter("OldPath", oldChannel.Path + "" + channel.ID + "~");
        value.AddParameter("OldNamePath", oldChannel.NamePath + "" + oldChannel.Name + "~");
        value.Path = channel.Path + "" + channel.ID + "~";
        value.NamePath = channel.NamePath + "" + channel.Name + "~";

        value.SetUpdate(" RootID=@RootID, Depth = Depth + @Depth, [Path]=REPLACE([Path], @OldPath, @Path) , [NamePath]=REPLACE([NamePath], @OldNamePath, @NamePath)");
        return TableOperate<Exhibition>.Update(value, condition);
    }


    #region 读取所有栏目数据
    /// <summary>
    /// 读取所有栏目数据
    /// </summary>
    /// <returns></returns>
    public static List<Exhibition> SelectAll()
    {
        return SelectByRootID(0);
       
    }
    #endregion

    public static List<Exhibition> SelectByRootID(int rootID)
    {
        List<Exhibition> channelData = new List<Exhibition>();
        List<int> idList = new List<int>();
        //查询数据
        Exhibition value = new Exhibition();
        Exhibition conditon = new Exhibition();
        if (rootID > 0)
        {
            conditon.RootID = rootID;
        }
        List<Exhibition> oldTypeData = TableOperate<Exhibition>.Select(value, conditon, 0, " order by Depth, ParentID, ID DESC ");

        for (int i = 0; i < oldTypeData.Count; i++)
        {
            Exhibition typeObj = oldTypeData[i];
            if (typeObj.Depth == 0) //深度为0，直接添加
            {
                channelData.Insert(0, typeObj);
                idList.Insert(0, typeObj.ID);
            }
            else
            {
                int parentIndex = idList.IndexOf(typeObj.ParentID);//查找上及目录所在位置！
                channelData.Insert(parentIndex + 1, typeObj);
                idList.Insert(parentIndex + 1, typeObj.ID);    //将数据插入上级目录之后
            }
        }
        return channelData;
    }


    public static List<Exhibition> SelectByParentID(int parentID)
    {
        List<Exhibition> channelData = new List<Exhibition>();
        List<int> idList = new List<int>();

        //查询数据
        Exhibition value = new Exhibition();
        Exhibition conditon = new Exhibition();

        if (parentID > 0)
        {
            conditon.Path = "%~" + parentID + "~%";
            conditon.AddAttach("Path", "like");
        }
        List<Exhibition> oldTypeData = TableOperate<Exhibition>.Select(value, conditon, 0, " order by ParentID, Depth, ID DESC ");

        for (int i = 0; i < oldTypeData.Count; i++)
        {
            Exhibition typeObj = oldTypeData[i];
            if (typeObj.Depth == 0) //深度为0，直接添加
            {
                channelData.Insert(0, typeObj);
                idList.Insert(0, typeObj.ID);
            }
            else
            {
                int parentIndex = idList.IndexOf(typeObj.ParentID);//查找上及目录所在位置！
                channelData.Insert(parentIndex + 1, typeObj);
                idList.Insert(parentIndex + 1, typeObj.ID);    //将数据插入上级目录之后
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
        Exhibition value = new Exhibition();
        value.ID = 0;
        Exhibition conditon = new Exhibition();
        conditon.Path = "%~" + id + "~%";
        conditon.AddAttach("Path", "like");

        List<Exhibition> childChannelList = TableOperate<Exhibition>.Select(value, conditon);

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

    public static Exhibition GetChannelByID(int id)
    {
        Exhibition conditon = new Exhibition();
        conditon.ID = id;
        return TableOperate<Exhibition>.GetRowData(conditon);
    }
}
