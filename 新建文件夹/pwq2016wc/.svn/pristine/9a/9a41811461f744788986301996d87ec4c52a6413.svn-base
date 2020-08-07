using Dejun.DataProvider.Sql2005;
using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;

/// <summary>
/// 栏目表 相关操作方法 
/// </summary>
public class QusetionProvider
{
    public QusetionProvider()
    {
        //Channel s = new Channel();
        // s.SetAutoInsert("")
    }


    #region 添加栏目
    /// <summary>
    /// 添加栏目
    /// </summary>
    public static int Insert(QuestionType channel)
    {
        if (channel.ParentID == 0)
        {
            channel.Depth = 0;
            channel.ParentID = 0;
            channel.Path = "0~";
            channel.NamePath = "所有栏目~";
            channel.AddInsert("RootID", "IDENT_CURRENT('QuestionType')");
        }
        else
        {
            QuestionType condition = new QuestionType();
            condition.ID = channel.ParentID;
            QuestionType parentChannel = TableOperate<QuestionType>.GetRowData(condition);
            string path = Convert.ToString(parentChannel.Path) + channel.ParentID + "~";
            string namePath = Convert.ToString(parentChannel.NamePath) + Convert.ToString(parentChannel.Name) + "~";
            channel.Depth = parentChannel.Depth + 1;
            channel.Path = path;
            channel.RootID = parentChannel.RootID;
            channel.NamePath = namePath;
        }
        return TableOperate<QuestionType>.InsertReturnID(channel);
    }
    #endregion

    #region 修改栏目
    /// <summary>
    /// 修改栏目
    /// </summary>
    public static int Update(QuestionType channel)
    {
        //修改信息

        QuestionType condition = new QuestionType();
        condition.ID = channel.ID;
        QuestionType oldChannel = TableOperate<QuestionType>.GetRowData(condition);


        if (channel.ParentID != oldChannel.ParentID)
        {
            if (channel.ParentID == 0)
            {
                channel.Depth = 0;
                channel.ParentID = 0;
                channel.Path = "0~";
                channel.NamePath = "所有栏目~";
                channel.AddInsert("RootID", "IDENT_CURRENT('QuestionType')");
            }
            else
            {
                condition = new QuestionType();
                condition.ID = channel.ParentID;
                QuestionType parentChannel = TableOperate<QuestionType>.GetRowData(condition);

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

        return TableOperate<QuestionType>.Update(channel);
    }
    #endregion

    private static int UpdateChild(QuestionType channel, QuestionType oldChannel)
    {
        //int depthSpan = channel.Depth - oldChannel.Depth;
        QuestionType value = new QuestionType();
        QuestionType condition = new QuestionType();
        condition.Path = "%~" + channel.ID + "~%";
        condition.AddAttach("Path", "like");

        value.RootID = channel.RootID;
        value.Depth = channel.Depth - oldChannel.Depth;
        value.AddParameter("OldPath", oldChannel.Path + "" + channel.ID + "~");
        value.AddParameter("OldNamePath", oldChannel.NamePath + "" + oldChannel.Name + "~");
        value.Path = channel.Path + "" + channel.ID + "~";
        value.NamePath = channel.NamePath + "" + channel.Name + "~";

        value.SetUpdate(" RootID=@RootID, Depth = Depth + @Depth, [Path]=REPLACE([Path], @OldPath, @Path) , [NamePath]=REPLACE([NamePath], @OldNamePath, @NamePath)");
        return TableOperate<QuestionType>.Update(value, condition);
    }


    #region 读取所有栏目数据
    /// <summary>
    /// 读取所有栏目数据
    /// </summary>
    /// <returns></returns>
    public static List<QuestionType> SelectAll()
    {
        return SelectByRootID(0);
       
    }
    #endregion

    public static List<QuestionType> SelectByRootID(int rootID)
    {
        List<QuestionType> channelData = new List<QuestionType>();
        List<int> idList = new List<int>();

        //查询数据
        QuestionType value = new QuestionType();
        QuestionType conditon = new QuestionType();

       

        if (rootID > 0)
        {
            conditon.RootID = rootID;
        }

        List<QuestionType> oldTypeData = TableOperate<QuestionType>.Select(value, conditon, 0, " order by Depth, ParentID, ID DESC ");

        for (int i = 0; i < oldTypeData.Count; i++)
        {
            QuestionType typeObj = oldTypeData[i];
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


    public static List<QuestionType> SelectByParentID(int parentID)
    {
        List<QuestionType> channelData = new List<QuestionType>();
        List<int> idList = new List<int>();

        //查询数据
        QuestionType value = new QuestionType();
        QuestionType conditon = new QuestionType();

        if (parentID > 0)
        {
            conditon.Path = "%~" + parentID + "~%";
            conditon.AddAttach("Path", "like");
        }
        List<QuestionType> oldTypeData = TableOperate<QuestionType>.Select(value, conditon, 0, " order by ParentID, Depth, ID DESC ");

        for (int i = 0; i < oldTypeData.Count; i++)
        {
            QuestionType typeObj = oldTypeData[i];
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
        QuestionType value = new QuestionType();
        value.ID = 0;
        QuestionType conditon = new QuestionType();
        conditon.Path = "%~" + id + "~%";
        conditon.AddAttach("Path", "like");

        List<QuestionType> childChannelList = TableOperate<QuestionType>.Select(value, conditon);

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

    public static QuestionType GetChannelByID(int id)
    {
        QuestionType conditon = new QuestionType();
        conditon.ID = id;
        return TableOperate<QuestionType>.GetRowData(conditon);
    }
}
