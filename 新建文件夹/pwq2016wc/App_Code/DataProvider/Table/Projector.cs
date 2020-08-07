/************************************************************

  Copyright (c) 2008，
  Author:               Date: 2017/5/11 11:28:20
  Description:    数据表Projector对应的业务逻辑层
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
    /// 与Projector数据表对应对象
    /// </summary>
    public class Projector : IDateBuildTable
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
        
        private string m_name;
        private bool name_initialized = false;
        
        private int m_baudRate;
        private bool baudRate_initialized = false;
        
        private string m_queryTimeReturn;
        private bool queryTimeReturn_initialized = false;
        
        private string m_queryTime;
        private bool queryTime_initialized = false;
        
        private string m_openProtocol;
        private bool openProtocol_initialized = false;
        
        private string m_closeProtocol;
        private bool closeProtocol_initialized = false;
        
        private string m_queryProtocol;
        private bool queryProtocol_initialized = false;
        
        private string m_queryOpen;
        private bool queryOpen_initialized = false;
        
        private string m_queryClose;
        private bool queryClose_initialized = false;
        
        private int m_charType;
        private bool charType_initialized = false;
        
        private int m_reCharType;
        private bool reCharType_initialized = false;
        

        public Projector()
        {
        }

        public Projector(int iD, string name, int baudRate, string queryTimeReturn, string queryTime, string openProtocol, string closeProtocol, string queryProtocol, string queryOpen, string queryClose, int charType, int reCharType)
        {
            
            this.ID = iD;
            
            this.Name = name;
            
            this.BaudRate = baudRate;
            
            this.QueryTimeReturn = queryTimeReturn;
            
            this.QueryTime = queryTime;
            
            this.OpenProtocol = openProtocol;
            
            this.CloseProtocol = closeProtocol;
            
            this.QueryProtocol = queryProtocol;
            
            this.QueryOpen = queryOpen;
            
            this.QueryClose = queryClose;
            
            this.CharType = charType;
            
            this.ReCharType = reCharType;
            
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

            
            if(CheckColumn(dr, "Name"))
            {
                if (dr["Name"] != null && dr["Name"] != DBNull.Value)
                {
                    this.Name = Convert.ToString(dr["Name"]);
                }
            }

            
            if(CheckColumn(dr, "BaudRate"))
            {
                if (dr["BaudRate"] != null && dr["BaudRate"] != DBNull.Value)
                {
                    this.BaudRate = Convert.ToInt32(dr["BaudRate"]);
                }
            }

            
            if(CheckColumn(dr, "QueryTimeReturn"))
            {
                if (dr["QueryTimeReturn"] != null && dr["QueryTimeReturn"] != DBNull.Value)
                {
                    this.QueryTimeReturn = Convert.ToString(dr["QueryTimeReturn"]);
                }
            }

            
            if(CheckColumn(dr, "QueryTime"))
            {
                if (dr["QueryTime"] != null && dr["QueryTime"] != DBNull.Value)
                {
                    this.QueryTime = Convert.ToString(dr["QueryTime"]);
                }
            }

            
            if(CheckColumn(dr, "OpenProtocol"))
            {
                if (dr["OpenProtocol"] != null && dr["OpenProtocol"] != DBNull.Value)
                {
                    this.OpenProtocol = Convert.ToString(dr["OpenProtocol"]);
                }
            }

            
            if(CheckColumn(dr, "CloseProtocol"))
            {
                if (dr["CloseProtocol"] != null && dr["CloseProtocol"] != DBNull.Value)
                {
                    this.CloseProtocol = Convert.ToString(dr["CloseProtocol"]);
                }
            }

            
            if(CheckColumn(dr, "QueryProtocol"))
            {
                if (dr["QueryProtocol"] != null && dr["QueryProtocol"] != DBNull.Value)
                {
                    this.QueryProtocol = Convert.ToString(dr["QueryProtocol"]);
                }
            }

            
            if(CheckColumn(dr, "QueryOpen"))
            {
                if (dr["QueryOpen"] != null && dr["QueryOpen"] != DBNull.Value)
                {
                    this.QueryOpen = Convert.ToString(dr["QueryOpen"]);
                }
            }

            
            if(CheckColumn(dr, "QueryClose"))
            {
                if (dr["QueryClose"] != null && dr["QueryClose"] != DBNull.Value)
                {
                    this.QueryClose = Convert.ToString(dr["QueryClose"]);
                }
            }

            
            if(CheckColumn(dr, "CharType"))
            {
                if (dr["CharType"] != null && dr["CharType"] != DBNull.Value)
                {
                    this.CharType = Convert.ToInt32(dr["CharType"]);
                }
            }

            
            if(CheckColumn(dr, "ReCharType"))
            {
                if (dr["ReCharType"] != null && dr["ReCharType"] != DBNull.Value)
                {
                    this.ReCharType = Convert.ToInt32(dr["ReCharType"]);
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
        
        public string Name
        {
            get
            {
                return this.m_name;
            }
            set
            {
                name_initialized = true;
                this.m_name = value;
            }
        }
        
        public int BaudRate
        {
            get
            {
                return this.m_baudRate;
            }
            set
            {
                baudRate_initialized = true;
                this.m_baudRate = value;
            }
        }
        
        public string QueryTimeReturn
        {
            get
            {
                return this.m_queryTimeReturn;
            }
            set
            {
                queryTimeReturn_initialized = true;
                this.m_queryTimeReturn = value;
            }
        }
        
        public string QueryTime
        {
            get
            {
                return this.m_queryTime;
            }
            set
            {
                queryTime_initialized = true;
                this.m_queryTime = value;
            }
        }
        
        public string OpenProtocol
        {
            get
            {
                return this.m_openProtocol;
            }
            set
            {
                openProtocol_initialized = true;
                this.m_openProtocol = value;
            }
        }
        
        public string CloseProtocol
        {
            get
            {
                return this.m_closeProtocol;
            }
            set
            {
                closeProtocol_initialized = true;
                this.m_closeProtocol = value;
            }
        }
        
        public string QueryProtocol
        {
            get
            {
                return this.m_queryProtocol;
            }
            set
            {
                queryProtocol_initialized = true;
                this.m_queryProtocol = value;
            }
        }
        
        public string QueryOpen
        {
            get
            {
                return this.m_queryOpen;
            }
            set
            {
                queryOpen_initialized = true;
                this.m_queryOpen = value;
            }
        }
        
        public string QueryClose
        {
            get
            {
                return this.m_queryClose;
            }
            set
            {
                queryClose_initialized = true;
                this.m_queryClose = value;
            }
        }
        
        public int CharType
        {
            get
            {
                return this.m_charType;
            }
            set
            {
                charType_initialized = true;
                this.m_charType = value;
            }
        }
        
        public int ReCharType
        {
            get
            {
                return this.m_reCharType;
            }
            set
            {
                reCharType_initialized = true;
                this.m_reCharType = value;
            }
        }
        


        /// <summary>
        /// 判断对象属性是否赋值。没有赋值返回true
        /// </summary>
        public bool IsNull
        {
            get
            {
                if (iD_initialized || name_initialized || baudRate_initialized || queryTimeReturn_initialized || queryTime_initialized || openProtocol_initialized || closeProtocol_initialized || queryProtocol_initialized || queryOpen_initialized || queryClose_initialized || charType_initialized || reCharType_initialized)
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
            
            if (name_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Name", SqlDbType.NVarChar);
                n_Parameter.Value = this.Name;
                n_Parameter.SourceColumn = "Name";
                parametersList.Add(n_Parameter);
            }
            
            if (baudRate_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "BaudRate", SqlDbType.Int);
                n_Parameter.Value = this.BaudRate;
                n_Parameter.SourceColumn = "BaudRate";
                parametersList.Add(n_Parameter);
            }
            
            if (queryTimeReturn_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "QueryTimeReturn", SqlDbType.NVarChar);
                n_Parameter.Value = this.QueryTimeReturn;
                n_Parameter.SourceColumn = "QueryTimeReturn";
                parametersList.Add(n_Parameter);
            }
            
            if (queryTime_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "QueryTime", SqlDbType.NVarChar);
                n_Parameter.Value = this.QueryTime;
                n_Parameter.SourceColumn = "QueryTime";
                parametersList.Add(n_Parameter);
            }
            
            if (openProtocol_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "OpenProtocol", SqlDbType.NVarChar);
                n_Parameter.Value = this.OpenProtocol;
                n_Parameter.SourceColumn = "OpenProtocol";
                parametersList.Add(n_Parameter);
            }
            
            if (closeProtocol_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "CloseProtocol", SqlDbType.NVarChar);
                n_Parameter.Value = this.CloseProtocol;
                n_Parameter.SourceColumn = "CloseProtocol";
                parametersList.Add(n_Parameter);
            }
            
            if (queryProtocol_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "QueryProtocol", SqlDbType.NVarChar);
                n_Parameter.Value = this.QueryProtocol;
                n_Parameter.SourceColumn = "QueryProtocol";
                parametersList.Add(n_Parameter);
            }
            
            if (queryOpen_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "QueryOpen", SqlDbType.NVarChar);
                n_Parameter.Value = this.QueryOpen;
                n_Parameter.SourceColumn = "QueryOpen";
                parametersList.Add(n_Parameter);
            }
            
            if (queryClose_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "QueryClose", SqlDbType.NVarChar);
                n_Parameter.Value = this.QueryClose;
                n_Parameter.SourceColumn = "QueryClose";
                parametersList.Add(n_Parameter);
            }
            
            if (charType_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "CharType", SqlDbType.Int);
                n_Parameter.Value = this.CharType;
                n_Parameter.SourceColumn = "CharType";
                parametersList.Add(n_Parameter);
            }
            
            if (reCharType_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ReCharType", SqlDbType.Int);
                n_Parameter.Value = this.ReCharType;
                n_Parameter.SourceColumn = "ReCharType";
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
                
                if (this.name_initialized)
                {
                    contentText += ", [Name]=@" + headStr + "Name ";
                }
                
                if (this.baudRate_initialized)
                {
                    contentText += ", [BaudRate]=@" + headStr + "BaudRate ";
                }
                
                if (this.queryTimeReturn_initialized)
                {
                    contentText += ", [QueryTimeReturn]=@" + headStr + "QueryTimeReturn ";
                }
                
                if (this.queryTime_initialized)
                {
                    contentText += ", [QueryTime]=@" + headStr + "QueryTime ";
                }
                
                if (this.openProtocol_initialized)
                {
                    contentText += ", [OpenProtocol]=@" + headStr + "OpenProtocol ";
                }
                
                if (this.closeProtocol_initialized)
                {
                    contentText += ", [CloseProtocol]=@" + headStr + "CloseProtocol ";
                }
                
                if (this.queryProtocol_initialized)
                {
                    contentText += ", [QueryProtocol]=@" + headStr + "QueryProtocol ";
                }
                
                if (this.queryOpen_initialized)
                {
                    contentText += ", [QueryOpen]=@" + headStr + "QueryOpen ";
                }
                
                if (this.queryClose_initialized)
                {
                    contentText += ", [QueryClose]=@" + headStr + "QueryClose ";
                }
                
                if (this.charType_initialized)
                {
                    contentText += ", [CharType]=@" + headStr + "CharType ";
                }
                
                if (this.reCharType_initialized)
                {
                    contentText += ", [ReCharType]=@" + headStr + "ReCharType ";
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
                
                if (this.name_initialized)
                {
                    conditionStr += " AND [Name]=@" + headStr + "Name ";
                }
                
                if (this.baudRate_initialized)
                {
                    conditionStr += " AND [BaudRate]=@" + headStr + "BaudRate ";
                }
                
                if (this.queryTimeReturn_initialized)
                {
                    conditionStr += " AND [QueryTimeReturn]=@" + headStr + "QueryTimeReturn ";
                }
                
                if (this.queryTime_initialized)
                {
                    conditionStr += " AND [QueryTime]=@" + headStr + "QueryTime ";
                }
                
                if (this.openProtocol_initialized)
                {
                    conditionStr += " AND [OpenProtocol]=@" + headStr + "OpenProtocol ";
                }
                
                if (this.closeProtocol_initialized)
                {
                    conditionStr += " AND [CloseProtocol]=@" + headStr + "CloseProtocol ";
                }
                
                if (this.queryProtocol_initialized)
                {
                    conditionStr += " AND [QueryProtocol]=@" + headStr + "QueryProtocol ";
                }
                
                if (this.queryOpen_initialized)
                {
                    conditionStr += " AND [QueryOpen]=@" + headStr + "QueryOpen ";
                }
                
                if (this.queryClose_initialized)
                {
                    conditionStr += " AND [QueryClose]=@" + headStr + "QueryClose ";
                }
                
                if (this.charType_initialized)
                {
                    conditionStr += " AND [CharType]=@" + headStr + "CharType ";
                }
                
                if (this.reCharType_initialized)
                {
                    conditionStr += " AND [ReCharType]=@" + headStr + "ReCharType ";
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
                
                if (this.name_initialized)
                {
                    contentText += ", [Name] ";
                }
                
                if (this.baudRate_initialized)
                {
                    contentText += ", [BaudRate] ";
                }
                
                if (this.queryTimeReturn_initialized)
                {
                    contentText += ", [QueryTimeReturn] ";
                }
                
                if (this.queryTime_initialized)
                {
                    contentText += ", [QueryTime] ";
                }
                
                if (this.openProtocol_initialized)
                {
                    contentText += ", [OpenProtocol] ";
                }
                
                if (this.closeProtocol_initialized)
                {
                    contentText += ", [CloseProtocol] ";
                }
                
                if (this.queryProtocol_initialized)
                {
                    contentText += ", [QueryProtocol] ";
                }
                
                if (this.queryOpen_initialized)
                {
                    contentText += ", [QueryOpen] ";
                }
                
                if (this.queryClose_initialized)
                {
                    contentText += ", [QueryClose] ";
                }
                
                if (this.charType_initialized)
                {
                    contentText += ", [CharType] ";
                }
                
                if (this.reCharType_initialized)
                {
                    contentText += ", [ReCharType] ";
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
                
                if (this.name_initialized)
                {
                    contentText += ", @" + headStr + "Name ";
                }
                
                if (this.baudRate_initialized)
                {
                    contentText += ", @" + headStr + "BaudRate ";
                }
                
                if (this.queryTimeReturn_initialized)
                {
                    contentText += ", @" + headStr + "QueryTimeReturn ";
                }
                
                if (this.queryTime_initialized)
                {
                    contentText += ", @" + headStr + "QueryTime ";
                }
                
                if (this.openProtocol_initialized)
                {
                    contentText += ", @" + headStr + "OpenProtocol ";
                }
                
                if (this.closeProtocol_initialized)
                {
                    contentText += ", @" + headStr + "CloseProtocol ";
                }
                
                if (this.queryProtocol_initialized)
                {
                    contentText += ", @" + headStr + "QueryProtocol ";
                }
                
                if (this.queryOpen_initialized)
                {
                    contentText += ", @" + headStr + "QueryOpen ";
                }
                
                if (this.queryClose_initialized)
                {
                    contentText += ", @" + headStr + "QueryClose ";
                }
                
                if (this.charType_initialized)
                {
                    contentText += ", @" + headStr + "CharType ";
                }
                
                if (this.reCharType_initialized)
                {
                    contentText += ", @" + headStr + "ReCharType ";
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
            string tableName = "Projector";
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
            
            this.name_initialized = true;
            
            this.baudRate_initialized = true;
            
            this.queryTimeReturn_initialized = true;
            
            this.queryTime_initialized = true;
            
            this.openProtocol_initialized = true;
            
            this.closeProtocol_initialized = true;
            
            this.queryProtocol_initialized = true;
            
            this.queryOpen_initialized = true;
            
            this.queryClose_initialized = true;
            
            this.charType_initialized = true;
            
            this.reCharType_initialized = true;
            
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

            
            if(page.Request["name"] != null)
            {
                if (this.name_initialized)
                {
                    if(page.Request["name"] != "")
                    {
                        this.Name = Convert.ToString(page.Request["name"]);
                    }
                    else
                    {
                        this.name_initialized = false;
                    }
                }
                else
                {
                    this.Name = Convert.ToString(page.Request["name"]);
                }
            }

            
            if(page.Request["baudRate"] != null)
            {
                if (this.baudRate_initialized)
                {
                    if(page.Request["baudRate"] != "")
                    {
                        this.BaudRate = Convert.ToInt32(page.Request["baudRate"]);
                    }
                    else
                    {
                        this.baudRate_initialized = false;
                    }
                }
                else
                {
                    this.BaudRate = Convert.ToInt32(page.Request["baudRate"]);
                }
            }

            
            if(page.Request["queryTimeReturn"] != null)
            {
                if (this.queryTimeReturn_initialized)
                {
                    if(page.Request["queryTimeReturn"] != "")
                    {
                        this.QueryTimeReturn = Convert.ToString(page.Request["queryTimeReturn"]);
                    }
                    else
                    {
                        this.queryTimeReturn_initialized = false;
                    }
                }
                else
                {
                    this.QueryTimeReturn = Convert.ToString(page.Request["queryTimeReturn"]);
                }
            }

            
            if(page.Request["queryTime"] != null)
            {
                if (this.queryTime_initialized)
                {
                    if(page.Request["queryTime"] != "")
                    {
                        this.QueryTime = Convert.ToString(page.Request["queryTime"]);
                    }
                    else
                    {
                        this.queryTime_initialized = false;
                    }
                }
                else
                {
                    this.QueryTime = Convert.ToString(page.Request["queryTime"]);
                }
            }

            
            if(page.Request["openProtocol"] != null)
            {
                if (this.openProtocol_initialized)
                {
                    if(page.Request["openProtocol"] != "")
                    {
                        this.OpenProtocol = Convert.ToString(page.Request["openProtocol"]);
                    }
                    else
                    {
                        this.openProtocol_initialized = false;
                    }
                }
                else
                {
                    this.OpenProtocol = Convert.ToString(page.Request["openProtocol"]);
                }
            }

            
            if(page.Request["closeProtocol"] != null)
            {
                if (this.closeProtocol_initialized)
                {
                    if(page.Request["closeProtocol"] != "")
                    {
                        this.CloseProtocol = Convert.ToString(page.Request["closeProtocol"]);
                    }
                    else
                    {
                        this.closeProtocol_initialized = false;
                    }
                }
                else
                {
                    this.CloseProtocol = Convert.ToString(page.Request["closeProtocol"]);
                }
            }

            
            if(page.Request["queryProtocol"] != null)
            {
                if (this.queryProtocol_initialized)
                {
                    if(page.Request["queryProtocol"] != "")
                    {
                        this.QueryProtocol = Convert.ToString(page.Request["queryProtocol"]);
                    }
                    else
                    {
                        this.queryProtocol_initialized = false;
                    }
                }
                else
                {
                    this.QueryProtocol = Convert.ToString(page.Request["queryProtocol"]);
                }
            }

            
            if(page.Request["queryOpen"] != null)
            {
                if (this.queryOpen_initialized)
                {
                    if(page.Request["queryOpen"] != "")
                    {
                        this.QueryOpen = Convert.ToString(page.Request["queryOpen"]);
                    }
                    else
                    {
                        this.queryOpen_initialized = false;
                    }
                }
                else
                {
                    this.QueryOpen = Convert.ToString(page.Request["queryOpen"]);
                }
            }

            
            if(page.Request["queryClose"] != null)
            {
                if (this.queryClose_initialized)
                {
                    if(page.Request["queryClose"] != "")
                    {
                        this.QueryClose = Convert.ToString(page.Request["queryClose"]);
                    }
                    else
                    {
                        this.queryClose_initialized = false;
                    }
                }
                else
                {
                    this.QueryClose = Convert.ToString(page.Request["queryClose"]);
                }
            }

            
            if(page.Request["charType"] != null)
            {
                if (this.charType_initialized)
                {
                    if(page.Request["charType"] != "")
                    {
                        this.CharType = Convert.ToInt32(page.Request["charType"]);
                    }
                    else
                    {
                        this.charType_initialized = false;
                    }
                }
                else
                {
                    this.CharType = Convert.ToInt32(page.Request["charType"]);
                }
            }

            
            if(page.Request["reCharType"] != null)
            {
                if (this.reCharType_initialized)
                {
                    if(page.Request["reCharType"] != "")
                    {
                        this.ReCharType = Convert.ToInt32(page.Request["reCharType"]);
                    }
                    else
                    {
                        this.reCharType_initialized = false;
                    }
                }
                else
                {
                    this.ReCharType = Convert.ToInt32(page.Request["reCharType"]);
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