using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dejun.DataProvider.Table;
using CodeBuild.Model;
using TemplateEngine;
using Dejun.DataProvider.Sql2005;

/// <summary>
///BuildSqlTable 的摘要说明
/// </summary>
public class BuildSqlTable
{
    public BuildSqlTable()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
 
 
    /// <summary>
    /// 读取数据建立文件
    /// </summary>
    /// <param name="_fileList"></param>
    public static void BuildSql(TableManage tableManage)
    {

    }

    public static string AddTable(TableManage tableManage)
    {
        //SELECT  OBJECT_ID(N'[PK_BaoXiaoGuanLi1]')
        string[] ziduanZWArr = tableManage.ZhongWenZiDuan.Split(',');
        string[] ziduanArr = tableManage.ZiDuan.Split(',');
        string[] ziduanTypeArr = tableManage.ZiDuanType.Split(',');
        string pk_name = "PK_" + tableManage.EnglishName;
        while (GetZuJIanCount(pk_name) > 0)
        {
            pk_name += "1";
        }

        string sql = "create table " + tableManage.EnglishName + "(";

//        string sql = @"create table " + tableManage.EnglishName + @"(
//                [ID] [int] IDENTITY(1,1) NOT NULL,  
//                [XTAddTime] [datetime] NULL,
//                [XTAddID] [int] NULL,
//                [XTAddName] [nvarchar](50) NULL,
//                [XTShenPi] [nvarchar](max) NULL,
//                [XTShenPiResult] [nvarchar](max) NULL,
//                [XTDingDing] [nvarchar](max) NULL,
//                [XTDingDingResult] [nvarchar](max) NULL,
//";
        for (int i = 0; i < ziduanZWArr.Length; i++)
        {
            if (ziduanArr[i] == "ID")
            {
                sql += "[ID] [int] IDENTITY(1,1) NOT NULL,  ";
            }
            else
            {
                sql += "[" + ziduanArr[i] + "] " + ConvertType(ziduanTypeArr[i]) + " NULL,";
            }
        }
        sql += @" CONSTRAINT [" + pk_name + @"] PRIMARY KEY CLUSTERED 
                (
                    [ID] ASC
                )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
                ) ON [PRIMARY]
";
        SQL.Exesql(sql);
        //return sql;
        //Projector p = new Projector();
        //TableOperate<Projector>.Execute(sql, p);
        return sql;

    }


    //Projector condition = new Projector();
    //condition
    //string sqlStr = "SELECT count(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'TableManage1') AND type in (N'U')";

    //m_num = Convert.ToInt32(TableOperate<Projector>.GetOneValue(sqlStr, condition));

    //if (m_num == 1)
    //{
    //    //查询列
    //    //Select name from syscolumns Where ID=OBJECT_ID(N'TableManage')
    //    //获取列
    //    //插入新列
    //    //ALTER TABLE distributors ADD COLUMN address varchar(30); 
    //    //
    //}
    public static string EditTable(TableManage newTable, TableManage oldTable)
    {
        string sqlAll = "";

        try
        {
            //
            string[] ziduanArr = newTable.ZiDuan.Split(',');
            string[] ziduanTypeArr = newTable.ZiDuanType.Split(',');


            string[] oldZiduanArr = oldTable.ZiDuan.Split(',');
            string[] oldZiduanTypeArr = oldTable.ZiDuanType.Split(',');

            if (newTable.EnglishName != oldTable.EnglishName)
            {
                //string sql = " ALTER TABLE " + oldTable.EnglishName + " RENAME TO " + newTable.EnglishName;
                string sql = " EXEC sp_rename '" + oldTable.EnglishName + "', '" + newTable.EnglishName + "'";
                sqlAll += sql;
                SQL.Exesql(sql);
            }

            if (ziduanArr.Length == oldZiduanArr.Length)
            {
                //修改
                for (int i = 0; i < ziduanArr.Length; i++)
                {
                    if (ziduanArr[i] != oldZiduanArr[i])
                    {
                        //string sql = "ALTER TABLE " + newTable.EnglishName + "  RENAME COLUMN " + oldZiduanArr[i] + " TO " + ziduanArr[i] + " ";
                        //string sql = "ALTER TABLE " + newTable.EnglishName + "  RENAME COLUMN " + oldZiduanArr[i] + " TO " + ziduanArr[i] + " ";
                        string sql = "EXEC sp_rename '" + newTable.EnglishName + ".[" + oldZiduanArr[i] + "]', '" + ziduanArr[i] + "', 'column'";
                        sqlAll += sql;
                        SQL.Exesql(sql);
                    }

                    if (ziduanTypeArr[i] != oldZiduanTypeArr[i])
                    {
                        string sql = "ALTER TABLE " + newTable.EnglishName + "  ALTER COLUMN " + ziduanArr[i] + " " + ConvertType(ziduanTypeArr[i]) + " ";
                        sqlAll += sql;
                        SQL.Exesql(sql);
                    }
                }
            }
            else
            {
                for (int i = 0; i < ziduanArr.Length; i++)
                {
                    int index = GetIndex(ziduanArr[i], oldZiduanArr);
                    if (index > -1)
                    {
                        if (ziduanTypeArr[i] != oldZiduanTypeArr[index])
                        {
                            string sql = "ALTER TABLE " + newTable.EnglishName + "  ALTER column " + ziduanArr[i] + " " + ConvertType(ziduanTypeArr[i]) + " ";
                            sqlAll += sql;
                            SQL.Exesql(sql);
                        }
                    }
                    else
                    {
                        string sql = "ALTER TABLE " + newTable.EnglishName + "  ADD   " + ziduanArr[i] + " " + ConvertType(ziduanTypeArr[i]) + " ";
                        sqlAll += sql;
                        SQL.Exesql(sql);
                    }
                }

                //删除表格
                for (int i = 0; i < oldZiduanArr.Length; i++)
                {
                    int index = GetIndex(oldZiduanArr[i], ziduanArr);
                    if (index == -1)
                    {
                        //ALTER TABLE distributors DROP COLUMN address RESTRICT; 
                        string sql = "ALTER TABLE " + newTable.EnglishName + "  DROP COLUMN " + oldZiduanArr[i] + "  ";
                        sqlAll += sql;
                        SQL.Exesql(sql);
                    }
                }


            }
        }
        catch (Exception ex)
        { 
        }
        return sqlAll;
        //return true;

    }


    public static void DelTable(string name)
    {
        //try
        //{
        //    string sql = " ALTER TABLE " + name + "DROP CONSTRAINT PK_" + name;
        //    SQL.Exesql(sql);
        //}
        //catch (Exception ex)
        //{
        //}


        string sql1 = @" IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'" + name + @"') AND type in (N'U'))  
        DROP TABLE " + name + @" 
 ";
        //string sql = " ALTER TABLE " + name + "DROP CONSTRAINT zipchk";
        SQL.Exesql(sql1);
    }

    public static int GetTableCount(string name)
    {
        Projector condition = new Projector();
        string sqlStr = "SELECT count(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'" + name + "') AND type in (N'U')";
        return Convert.ToInt32(TableOperate<Projector>.GetOneValue(sqlStr, condition));
    }


    public static int GetZuJIanCount(string name)
    {

        Projector condition = new Projector();
        string sqlStr = "SELECT  Count(OBJECT_ID(N'[" + name + "]'))";
        return Convert.ToInt32(TableOperate<Projector>.GetOneValue(sqlStr, condition));
    }


    //SELECT  Count(OBJECT_ID(N'[PK_BaoXiaoGuanLi11]'))


    private static string ConvertType(string typeWord)
    {
        string sqlType = "[nvarchar](50)";
        switch (typeWord)
        {
            #region case
            case "0":
                sqlType = "[nvarchar](50)";
                break;

            case "1":
                sqlType = "[nvarchar](max)";
                break;

            case "2":
                sqlType = "[int]";
                break;

            case "3":
                sqlType = "[datetime]";
                break;

            case "4":
                sqlType = "[bit]";
                break;

            case "5":
                sqlType = "[float]";
                break;

            case "6":
                sqlType = "[float]";
                break;
            case "7":
                sqlType = "[bigint]";
                break;
            default:
                sqlType = "[nvarchar](50)";
                break;
           
                #endregion
        }
        return sqlType;
    }

    private static int GetIndex(string ziduan, string[] ziduanArr)
    {
        for (int i = 0; i < ziduanArr.Length; i++)
        {
            if (ziduan == ziduanArr[i])
            {
                return i;
            }
        }

        return -1;
    }
}
 
public struct Columns
{
    public string Name;
    public int Index;
    public string Type;
}

//USE [caiwu]
//GO

///****** Object:  Table [dbo].[TableManage]    Script Date: 11/06/2018 17:47:18 ******/
//IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TableManage]') AND type in (N'U'))
//DROP TABLE [dbo].[TableManage]
//GO

//USE [caiwu]
//GO

///****** Object:  Table [dbo].[TableManage]    Script Date: 11/06/2018 17:47:20 ******/
//SET ANSI_NULLS ON
//GO

//SET QUOTED_IDENTIFIER ON
//GO

//CREATE TABLE [dbo].[TableManage](
//    [ID] [int] IDENTITY(1,1) NOT NULL,
//    [Name] [nvarchar](200) NULL,
//    [EnglishName] [nvarchar](200) NULL,
//    [ZiDuan] [nvarchar](max) NULL,
//    [ZiDuanType] [nvarchar](max) NULL,
//    [AddType] [nvarchar](max) NULL,
//    [ChengYuan] [nvarchar](max) NULL,
//    [Zhi] [nvarchar](max) NULL,
//    [BiXu] [nvarchar](max) NULL,
//    [SouSuo] [nvarchar](max) NULL,
//    [LieBiao] [nvarchar](max) NULL,
//    [AddShow] [nvarchar](max) NULL,
//    [EditShow] [nvarchar](max) NULL,
//    [ShenPi] [nvarchar](max) NULL,
//    [DingDing] [nvarchar](max) NULL,
//    [Breif] [nvarchar](max) NULL,
//    [AddTime] [datetime] NULL,
//    [AddID] [int] NULL,
//    [AddName] [nvarchar](50) NULL,
//    [ZhongWenZiDuan] [nvarchar](max) NULL,
// CONSTRAINT [PK_TableManage] PRIMARY KEY CLUSTERED 
//(
//    [ID] ASC
//)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
//) ON [PRIMARY]

//GO





//USE [caiwu]
//GO

///****** Object:  Table [dbo].[TableManage]    Script Date: 11/06/2018 17:48:43 ******/
//SET ANSI_NULLS ON
//GO

//SET QUOTED_IDENTIFIER ON
//GO

//CREATE TABLE [dbo].[TableManage](
//    [ID] [int] IDENTITY(1,1) NOT NULL,
//    [Name] [nvarchar](200) NULL,
//    [EnglishName] [nvarchar](200) NULL,
//    [ZiDuan] [nvarchar](max) NULL,
//    [ZiDuanType] [nvarchar](max) NULL,
//    [AddType] [nvarchar](max) NULL,
//    [ChengYuan] [nvarchar](max) NULL,
//    [Zhi] [nvarchar](max) NULL,
//    [BiXu] [nvarchar](max) NULL,
//    [SouSuo] [nvarchar](max) NULL,
//    [LieBiao] [nvarchar](max) NULL,
//    [AddShow] [nvarchar](max) NULL,
//    [EditShow] [nvarchar](max) NULL,
//    [ShenPi] [nvarchar](max) NULL,
//    [DingDing] [nvarchar](max) NULL,
//    [Breif] [nvarchar](max) NULL,
//    [AddTime] [datetime] NULL,
//    [AddID] [int] NULL,
//    [AddName] [nvarchar](50) NULL,
//    [ZhongWenZiDuan] [nvarchar](max) NULL,
// CONSTRAINT [PK_TableManage] PRIMARY KEY CLUSTERED 
//(
//    [ID] ASC
//)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
//) ON [PRIMARY]

//GO





//向sql server表中增加一个varchar列： 
//ALTER TABLE distributors ADD COLUMN address varchar(30); 
//从sql server表中删除一个字段： 
//ALTER TABLE distributors DROP COLUMN address RESTRICT; 
//在一个操作中修改两个现有字段的类型： 
//ALTER TABLE distributors 
//ALTER COLUMN address TYPE varchar(80), 
//ALTER COLUMN name TYPE varchar(100); 
//对现存字段改名： 
//ALTER TABLE distributors RENAME COLUMN address TO city; 
//更改现存sql server表的名字： 
//ALTER TABLE distributors RENAME TO suppliers; 


//create table inf(

//id int,

//name varchar(10),

//grade int

//)

//查看所有表名： 
//select name from sysobjects where type=’U’

//查询表的所有字段名： 
//Select name from syscolumns Where ID=OBJECT_ID(‘表名’)

//select * from information_schema.tables 
//select * from information_schema.views 
//select * from information_schema.columns