﻿/************************************************************

  Copyright (c) 2008，
  Author:               Date: 2019/7/23 10:39:09
  Description:    数据表CloudUsing对应的业务逻辑层
  Version:         1.1.0.0

************************************************************/

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;

namespace Dejun.DataProvider.Table
{

    /// <summary>
    /// 与CloudUsing数据表对应对象
    /// </summary>
    public class CloudUsing : IDateBuildTable
    {

        private bool m_isAutoConditon = true;
        private string m_conditonStr;
        private bool m_isAutoContent = true;
        private string m_ContentStr;
        private bool m_isAutoInsert = true;
        private string m_InsertStr;
        private bool m_isAutoUpdate = true;
        private string m_UpdateStr;

        //在自动的前提增加条件
        private string m_addConditonStr = "";

        
        private int m_iD;
        private bool iD_initialized = false;
        
        private int m_newsID;
        private bool newsID_initialized = false;
        
        private int m_count;
        private bool count_initialized = false;
        
        private DateTime m_addTime;
        private bool addTime_initialized = false;
        

        public CloudUsing()
        {
        }

        public CloudUsing(int iD, int newsID, int count, DateTime addTime)
        {
            
            this.ID = iD;
            
            this.NewsID = newsID;
            
            this.Count = count;
            
            this.AddTime = addTime;
            
        }


        /// <summary>
        /// 从SqlDataProvider中读取数据
        /// </summary>
        /// <param name="dr"></param>
        public void FromIDataReader(IDataReader dr)
        {
            
            if(CheckColumn(dr, "ID"))
            {
                if (dr["ID"] != null && dr["ID"] != DBNull.Value)
                {
                    this.ID = Convert.ToInt32(dr["ID"]);
                }
            }

            
            if(CheckColumn(dr, "NewsID"))
            {
                if (dr["NewsID"] != null && dr["NewsID"] != DBNull.Value)
                {
                    this.NewsID = Convert.ToInt32(dr["NewsID"]);
                }
            }

            
            if(CheckColumn(dr, "Count"))
            {
                if (dr["Count"] != null && dr["Count"] != DBNull.Value)
                {
                    this.Count = Convert.ToInt32(dr["Count"]);
                }
            }

            
            if(CheckColumn(dr, "AddTime"))
            {
                if (dr["AddTime"] != null && dr["AddTime"] != DBNull.Value)
                {
                    this.AddTime = Convert.ToDateTime(dr["AddTime"]);
                }
            }

            

        }

        
        public int ID
        {
            get
            {
                return this.m_iD;
            }
            set
            {
                iD_initialized = true;
                this.m_iD = value;
            }
        }
        
        public int NewsID
        {
            get
            {
                return this.m_newsID;
            }
            set
            {
                newsID_initialized = true;
                this.m_newsID = value;
            }
        }
        
        public int Count
        {
            get
            {
                return this.m_count;
            }
            set
            {
                count_initialized = true;
                this.m_count = value;
            }
        }
        
        public DateTime AddTime
        {
            get
            {
                return this.m_addTime;
            }
            set
            {
                addTime_initialized = true;
                this.m_addTime = value;
            }
        }
        


        /// <summary>
        /// 判断对象属性是否赋值。没有赋值返回true
        /// </summary>
        public bool IsNull
        {
            get
            {
                if (iD_initialized || newsID_initialized || count_initialized || addTime_initialized)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }


        /// <summary>
        /// 获取SqlParameter
        /// </summary>
        /// <returns></returns>
        public SqlParameter[] GetSqlParameter()
        {
            return GetSqlParameter("");
        }

        /// <summary>
        /// 获取SqlParameter
        /// </summary>
        /// <returns></returns>
        public SqlParameter[] GetSqlParameter(string headStr)
        {
            ArrayList parametersList = new ArrayList();
            
            if (iD_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ID", SqlDbType.Int);
                n_Parameter.Value = this.ID;
                n_Parameter.SourceColumn = "ID";
                parametersList.Add(n_Parameter);
            }
            
            if (newsID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "NewsID", SqlDbType.Int);
                n_Parameter.Value = this.NewsID;
                n_Parameter.SourceColumn = "NewsID";
                parametersList.Add(n_Parameter);
            }
            
            if (count_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Count", SqlDbType.Int);
                n_Parameter.Value = this.Count;
                n_Parameter.SourceColumn = "Count";
                parametersList.Add(n_Parameter);
            }
            
            if (addTime_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "AddTime", SqlDbType.DateTime);
                n_Parameter.Value = this.AddTime;
                n_Parameter.SourceColumn = "AddTime";
                parametersList.Add(n_Parameter);
            }
            
            parametersList.AddRange(m_addParametersList);  
            SqlParameter[] parameters = (SqlParameter[])parametersList.ToArray(typeof(SqlParameter));
            return parameters;

        }

        /// <summary>
        /// 格式：, [列名]=@列名
        /// </summary>
        /// <returns></returns>
        public string UpdateText()
        {
            return UpdateText("");
        }

        /// <summary>
        /// 格式：, [列名]=@列名
        /// </summary>
        /// <returns></returns>
        public string UpdateText(string headStr)
        {
            string contentText = "";

            if(this.m_isAutoUpdate)
            {
                
                if (this.iD_initialized)
                {
                    contentText += ", [ID]=@" + headStr + "ID ";
                }
                
                if (this.newsID_initialized)
                {
                    contentText += ", [NewsID]=@" + headStr + "NewsID ";
                }
                
                if (this.count_initialized)
                {
                    contentText += ", [Count]=@" + headStr + "Count ";
                }
                
                if (this.addTime_initialized)
                {
                    contentText += ", [AddTime]=@" + headStr + "AddTime ";
                }
                

                contentText = contentText.TrimStart(',');

            }
            else
            {
                contentText = this.m_UpdateStr;
            }

            return contentText;

        }

        /// <summary>
        /// 格式： AND [列名]=@列名
        /// </summary>
        /// <returns></returns>
        public string ConditionText()
        {
            return ConditionText("");
        }


        /// <summary>
        /// 格式： AND [列名]=@列名
        /// </summary>
        /// <returns></returns>
        public string ConditionText(string headStr)
        {
            string conditionStr = " WHERE 1=1 ";
            if(this.m_isAutoConditon)
            {
                
                if (this.iD_initialized)
                {
                    conditionStr += " AND [ID]=@" + headStr + "ID ";
                }
                
                if (this.newsID_initialized)
                {
                    conditionStr += " AND [NewsID]=@" + headStr + "NewsID ";
                }
                
                if (this.count_initialized)
                {
                    conditionStr += " AND [Count]=@" + headStr + "Count ";
                }
                
                if (this.addTime_initialized)
                {
                    conditionStr += " AND [AddTime]=@" + headStr + "AddTime ";
                }
                

                //add by dejun--2011-6-21
                for (int i = 0; i < m_columnName.Count; i++)
                {
                   conditionStr = conditionStr.Replace(" AND [" + m_columnName[i] + "]=@" + headStr + "" + m_columnName[i] + " ", " AND [" + m_columnName[i] + "] " + m_attachList[i] + " @" + headStr + "" + m_columnName[i] + " ");

                }
                //end -add by dejun--2011-6-21

                if(m_addConditonStr !="")
                {
                    conditionStr= "" + conditionStr + " " + m_addConditonStr;
                }

             }
            else
            {
                conditionStr = this.m_conditonStr;
            }
            return conditionStr;

        }

        /// <summary>
        /// 格式：,[列名]
        /// </summary>
        /// <returns></returns>
        public string ContentText()
        {
            string contentText = "";
            if(this.m_isAutoContent)
            {
                
                if (this.iD_initialized)
                {
                    contentText += ", [ID] ";
                }
                
                if (this.newsID_initialized)
                {
                    contentText += ", [NewsID] ";
                }
                
                if (this.count_initialized)
                {
                    contentText += ", [Count] ";
                }
                
                if (this.addTime_initialized)
                {
                    contentText += ", [AddTime] ";
                }
                

                for (int i = 0; i < m_InsertColumn.Count; i++)
			    {
    			     contentText += ", [" + m_InsertColumn[i] + "] ";
			    }

                contentText = contentText.TrimStart(',');

                if(contentText == "")
                {     
                    contentText = " * ";
                }
            }
            else
            {
                contentText = this.m_ContentStr;
            }
            return contentText;

        }

        /// <summary>
        /// 格式：,@列名
        /// </summary>
        /// <returns></returns>
        public string InsertText(string headStr)
        {
            string contentText = "";
            if(this.m_isAutoInsert)
            {
                
                if (this.iD_initialized)
                {
                    contentText += ", @" + headStr + "ID ";
                }
                
                if (this.newsID_initialized)
                {
                    contentText += ", @" + headStr + "NewsID ";
                }
                
                if (this.count_initialized)
                {
                    contentText += ", @" + headStr + "Count ";
                }
                
                if (this.addTime_initialized)
                {
                    contentText += ", @" + headStr + "AddTime ";
                }
                

                for (int i = 0; i < m_InsertValue.Count; i++)
			    {
    			     contentText += ", " + m_InsertValue[i] + " ";
			    }
                contentText = contentText.TrimStart(',');
            }
            else
            {
                contentText = this.m_InsertStr;
            }
            return contentText;

        }

        /// <summary>
        /// 格式：,@列名
        /// </summary>
        /// <returns></returns>
        public string InsertText()
        {

            return InsertText("");

        }

        /// <summary>
        /// 表名
        /// </summary>
        /// <returns></returns>
        public string TableName()
        {
            string tableName = "CloudUsing";
            return tableName;
        }

        /// <summary>
        /// 获取第一列名称
        /// </summary>
        /// <returns></returns>
        public string FirstColumn()
        {
            string firstColumn = "ID";
            return firstColumn;
        }

        /// <summary>
        /// 设置所有列为已赋值
        /// </summary>
        /// <returns></returns>
        public void AllInitialized()
        {
            
            this.iD_initialized = true;
            
            this.newsID_initialized = true;
            
            this.count_initialized = true;
            
            this.addTime_initialized = true;
            
        }
    
        private bool CheckColumn(IDataReader dr, string columnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (columnName == dr.GetName(i))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 设置条件语句，设置改语句之后，将替代自动生成条件语句
        /// </summary>
        /// <param name="conditionStr">条件对象，例如where id=@id and Name=@name</param>
        public void SetConditon(string conditionStr)
        {
            this.m_isAutoConditon = false;
            this.m_conditonStr = conditionStr;
        }

        /// <summary>
        /// 设置内容语句，设置改语句之后，将替代自动生成内容语句
        /// </summary>
        /// <param name="conditionStr">内容对象，例如 count(*) </param>
        public void SetContent(string contentStr)
        {
            this.m_isAutoContent = false;
            this.m_ContentStr = contentStr;
        }

        /// <summary>
        /// 设置内容语句，设置改语句之后，将替代自动生成插入语句
        /// </summary>
        /// <param name="conditionStr">内容对象，例如 ", @列名 </param>
        public void SetInsert(string insertStr)
        {
            this.m_isAutoInsert = false;
            this.m_InsertStr = insertStr;
        }

        /// <summary>
        /// 设置内容语句，设置改语句之后，将替代自动更新插入语句
        /// </summary>
        /// <param name="conditionStr">内容对象，[列名]=@列名 </param>
        public void SetUpdate(string updateStr)
        {
            this.m_isAutoUpdate = false;
            this.m_UpdateStr = updateStr;
        }



        /// <summary>
        /// 在原有的条件里增加条件
        /// </summary>
        /// <param name="conditionStr">条件对象，例如where id=@id and Name=@name</param>
        public void AddConditon(string conditionStr)
        {
            this.m_addConditonStr += conditionStr;
        }


        /// <summary>
        /// 自动获取表单信息
        /// </summary>
        /// <param name="page">页面对象 </param>
        public void AutoForm(System.Web.UI.Page page)
        {
            
            if(page.Request["iD"] != null)
            {
                if (this.iD_initialized)
                {
                    if(page.Request["iD"] != "")
                    {
                        this.ID = Convert.ToInt32(page.Request["iD"]);
                    }
                    else
                    {
                        this.iD_initialized = false;
                    }
                }
                else
                {
                    this.ID = Convert.ToInt32(page.Request["iD"]);
                }
            }

            
            if(page.Request["newsID"] != null)
            {
                if (this.newsID_initialized)
                {
                    if(page.Request["newsID"] != "")
                    {
                        this.NewsID = Convert.ToInt32(page.Request["newsID"]);
                    }
                    else
                    {
                        this.newsID_initialized = false;
                    }
                }
                else
                {
                    this.NewsID = Convert.ToInt32(page.Request["newsID"]);
                }
            }

            
            if(page.Request["count"] != null)
            {
                if (this.count_initialized)
                {
                    if(page.Request["count"] != "")
                    {
                        this.Count = Convert.ToInt32(page.Request["count"]);
                    }
                    else
                    {
                        this.count_initialized = false;
                    }
                }
                else
                {
                    this.Count = Convert.ToInt32(page.Request["count"]);
                }
            }

            
            if(page.Request["addTime"] != null)
            {
                if (this.addTime_initialized)
                {
                    if(page.Request["addTime"] != "")
                    {
                        this.AddTime = Convert.ToDateTime(page.Request["addTime"]);
                    }
                    else
                    {
                        this.addTime_initialized = false;
                    }
                }
                else
                {
                    this.AddTime = Convert.ToDateTime(page.Request["addTime"]);
                }
            }

            
        }

        //add by dejun--2011-6-21
        List<string> m_columnName = new List<string>();
        List<string> m_attachList = new List<string>();

        /// <summary>
        /// 添加附加条件，比如like，＞，＜等，注意，如果使用like，赋值时需要加入%%.比如value.Info="%值%"
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="attach"></param>
        public void AddAttach(string columnName, string attach)
        {
            m_columnName.Add(columnName);
            m_attachList.Add(attach);
        }
        //end -add by dejun--2011-6-21

        //add by dejun--2011-08-25
        List<string> m_InsertColumn = new List<string>();
        List<string> m_InsertValue = new List<string>();

        /// <summary>
        /// 加入添加内容，用来处理特别的插入
        /// </summary>
        /// <param name="columnName"></param>
        public void AddInsert(string columnName, string columnValue)
        {
            m_InsertColumn.Add(columnName);
            m_InsertValue.Add(columnValue);
        }
        //end -add by dejun--2011-08-25

        //add by dejun--2011-08-27
        ArrayList m_addParametersList = new ArrayList();
        public void AddParameter(string columnName, object columnValue)
        {
            System.Type type = columnValue.GetType();
            SqlDbType dbType;

            if (type.Name == "Int32")
            {
                dbType = SqlDbType.Int;
            }
            else if (type.Name == "String")
            {
                dbType = SqlDbType.NVarChar;
            }
            else if (type.Name == "Double")
            {
                dbType = SqlDbType.Float;
            }
            else if (type.Name == "Single")
            {
                dbType = SqlDbType.Float;
            }
            else if (type.Name == "Boolean")
            {
                dbType = SqlDbType.Bit;
            }
            else if (type.Name == "Decimal")
            {
                dbType = SqlDbType.Decimal;
            }
            else if (type.Name == "DateTime")
            {
                dbType = SqlDbType.DateTime;
            }
            else
            {
                dbType = SqlDbType.NVarChar;
            }

            SqlParameter n_Parameter = new SqlParameter("@" + columnName, dbType);
            n_Parameter.Value = columnValue;
            n_Parameter.SourceColumn = columnName;
            m_addParametersList.Add(n_Parameter);
        }
        //end -add by dejun--2011-08-27
    }

}