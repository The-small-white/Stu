/************************************************************

  Copyright (c) 2008，
  Author:               Date: 2017-05-23 14:18:14
  Description:    数据表PC_Channel对应的业务逻辑层
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
    /// 与PC_Channel数据表对应对象
    /// </summary>
    public class PC_Channel : IDateBuildTable
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
        
        private int m_typeID;
        private bool typeID_initialized = false;
        
        private string m_brief;
        private bool brief_initialized = false;
        
        private string m_iP;
        private bool iP_initialized = false;
        
        private long m_orderID;
        private bool orderID_initialized = false;
        
        private int m_version;
        private bool version_initialized = false;
        
        private int m_seviceID;
        private bool seviceID_initialized = false;
        
        private int m_groupID;
        private bool groupID_initialized = false;
        
        private int m_areaID;
        private bool areaID_initialized = false;
        
        private int m_state;
        private bool state_initialized = false;
        
        private DateTime m_lastTime;
        private bool lastTime_initialized = false;
        

        public PC_Channel()
        {
        }

        public PC_Channel(int iD, string name, int typeID, string brief, string iP, long orderID, int version, int seviceID, int groupID, int areaID, int state, DateTime lastTime)
        {
            
            this.ID = iD;
            
            this.Name = name;
            
            this.TypeID = typeID;
            
            this.Brief = brief;
            
            this.IP = iP;
            
            this.OrderID = orderID;
            
            this.Version = version;
            
            this.SeviceID = seviceID;
            
            this.GroupID = groupID;
            
            this.AreaID = areaID;
            
            this.State = state;
            
            this.LastTime = lastTime;
            
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

            
            if(CheckColumn(dr, "TypeID"))
            {
                if (dr["TypeID"] != null && dr["TypeID"] != DBNull.Value)
                {
                    this.TypeID = Convert.ToInt32(dr["TypeID"]);
                }
            }

            
            if(CheckColumn(dr, "Brief"))
            {
                if (dr["Brief"] != null && dr["Brief"] != DBNull.Value)
                {
                    this.Brief = Convert.ToString(dr["Brief"]);
                }
            }

            
            if(CheckColumn(dr, "IP"))
            {
                if (dr["IP"] != null && dr["IP"] != DBNull.Value)
                {
                    this.IP = Convert.ToString(dr["IP"]);
                }
            }

            
            if(CheckColumn(dr, "OrderID"))
            {
                if (dr["OrderID"] != null && dr["OrderID"] != DBNull.Value)
                {
                    this.OrderID = Convert.ToInt64(dr["OrderID"]);
                }
            }

            
            if(CheckColumn(dr, "Version"))
            {
                if (dr["Version"] != null && dr["Version"] != DBNull.Value)
                {
                    this.Version = Convert.ToInt32(dr["Version"]);
                }
            }

            
            if(CheckColumn(dr, "SeviceID"))
            {
                if (dr["SeviceID"] != null && dr["SeviceID"] != DBNull.Value)
                {
                    this.SeviceID = Convert.ToInt32(dr["SeviceID"]);
                }
            }

            
            if(CheckColumn(dr, "GroupID"))
            {
                if (dr["GroupID"] != null && dr["GroupID"] != DBNull.Value)
                {
                    this.GroupID = Convert.ToInt32(dr["GroupID"]);
                }
            }

            
            if(CheckColumn(dr, "AreaID"))
            {
                if (dr["AreaID"] != null && dr["AreaID"] != DBNull.Value)
                {
                    this.AreaID = Convert.ToInt32(dr["AreaID"]);
                }
            }

            
            if(CheckColumn(dr, "State"))
            {
                if (dr["State"] != null && dr["State"] != DBNull.Value)
                {
                    this.State = Convert.ToInt32(dr["State"]);
                }
            }

            
            if(CheckColumn(dr, "LastTime"))
            {
                if (dr["LastTime"] != null && dr["LastTime"] != DBNull.Value)
                {
                    this.LastTime = Convert.ToDateTime(dr["LastTime"]);
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
        
        public int TypeID
        {
            get
            {
                return this.m_typeID;
            }
            set
            {
                typeID_initialized = true;
                this.m_typeID = value;
            }
        }
        
        public string Brief
        {
            get
            {
                return this.m_brief;
            }
            set
            {
                brief_initialized = true;
                this.m_brief = value;
            }
        }
        
        public string IP
        {
            get
            {
                return this.m_iP;
            }
            set
            {
                iP_initialized = true;
                this.m_iP = value;
            }
        }
        
        public long OrderID
        {
            get
            {
                return this.m_orderID;
            }
            set
            {
                orderID_initialized = true;
                this.m_orderID = value;
            }
        }
        
        public int Version
        {
            get
            {
                return this.m_version;
            }
            set
            {
                version_initialized = true;
                this.m_version = value;
            }
        }
        
        public int SeviceID
        {
            get
            {
                return this.m_seviceID;
            }
            set
            {
                seviceID_initialized = true;
                this.m_seviceID = value;
            }
        }
        
        public int GroupID
        {
            get
            {
                return this.m_groupID;
            }
            set
            {
                groupID_initialized = true;
                this.m_groupID = value;
            }
        }
        
        public int AreaID
        {
            get
            {
                return this.m_areaID;
            }
            set
            {
                areaID_initialized = true;
                this.m_areaID = value;
            }
        }
        
        public int State
        {
            get
            {
                return this.m_state;
            }
            set
            {
                state_initialized = true;
                this.m_state = value;
            }
        }
        
        public DateTime LastTime
        {
            get
            {
                return this.m_lastTime;
            }
            set
            {
                lastTime_initialized = true;
                this.m_lastTime = value;
            }
        }
        


        /// <summary>
        /// 判断对象属性是否赋值。没有赋值返回true
        /// </summary>
        public bool IsNull
        {
            get
            {
                if (iD_initialized || name_initialized || typeID_initialized || brief_initialized || iP_initialized || orderID_initialized || version_initialized || seviceID_initialized || groupID_initialized || areaID_initialized || state_initialized || lastTime_initialized)
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
            
            if (typeID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "TypeID", SqlDbType.Int);
                n_Parameter.Value = this.TypeID;
                n_Parameter.SourceColumn = "TypeID";
                parametersList.Add(n_Parameter);
            }
            
            if (brief_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Brief", SqlDbType.Text);
                n_Parameter.Value = this.Brief;
                n_Parameter.SourceColumn = "Brief";
                parametersList.Add(n_Parameter);
            }
            
            if (iP_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "IP", SqlDbType.NVarChar);
                n_Parameter.Value = this.IP;
                n_Parameter.SourceColumn = "IP";
                parametersList.Add(n_Parameter);
            }
            
            if (orderID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "OrderID", SqlDbType.BigInt);
                n_Parameter.Value = this.OrderID;
                n_Parameter.SourceColumn = "OrderID";
                parametersList.Add(n_Parameter);
            }
            
            if (version_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Version", SqlDbType.Int);
                n_Parameter.Value = this.Version;
                n_Parameter.SourceColumn = "Version";
                parametersList.Add(n_Parameter);
            }
            
            if (seviceID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "SeviceID", SqlDbType.Int);
                n_Parameter.Value = this.SeviceID;
                n_Parameter.SourceColumn = "SeviceID";
                parametersList.Add(n_Parameter);
            }
            
            if (groupID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "GroupID", SqlDbType.Int);
                n_Parameter.Value = this.GroupID;
                n_Parameter.SourceColumn = "GroupID";
                parametersList.Add(n_Parameter);
            }
            
            if (areaID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "AreaID", SqlDbType.Int);
                n_Parameter.Value = this.AreaID;
                n_Parameter.SourceColumn = "AreaID";
                parametersList.Add(n_Parameter);
            }
            
            if (state_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "State", SqlDbType.Int);
                n_Parameter.Value = this.State;
                n_Parameter.SourceColumn = "State";
                parametersList.Add(n_Parameter);
            }
            
            if (lastTime_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "LastTime", SqlDbType.DateTime);
                n_Parameter.Value = this.LastTime;
                n_Parameter.SourceColumn = "LastTime";
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
                
                if (this.typeID_initialized)
                {
                    contentText += ", [TypeID]=@" + headStr + "TypeID ";
                }
                
                if (this.brief_initialized)
                {
                    contentText += ", [Brief]=@" + headStr + "Brief ";
                }
                
                if (this.iP_initialized)
                {
                    contentText += ", [IP]=@" + headStr + "IP ";
                }
                
                if (this.orderID_initialized)
                {
                    contentText += ", [OrderID]=@" + headStr + "OrderID ";
                }
                
                if (this.version_initialized)
                {
                    contentText += ", [Version]=@" + headStr + "Version ";
                }
                
                if (this.seviceID_initialized)
                {
                    contentText += ", [SeviceID]=@" + headStr + "SeviceID ";
                }
                
                if (this.groupID_initialized)
                {
                    contentText += ", [GroupID]=@" + headStr + "GroupID ";
                }
                
                if (this.areaID_initialized)
                {
                    contentText += ", [AreaID]=@" + headStr + "AreaID ";
                }
                
                if (this.state_initialized)
                {
                    contentText += ", [State]=@" + headStr + "State ";
                }
                
                if (this.lastTime_initialized)
                {
                    contentText += ", [LastTime]=@" + headStr + "LastTime ";
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
                
                if (this.typeID_initialized)
                {
                    conditionStr += " AND [TypeID]=@" + headStr + "TypeID ";
                }
                
                if (this.brief_initialized)
                {
                    conditionStr += " AND [Brief]=@" + headStr + "Brief ";
                }
                
                if (this.iP_initialized)
                {
                    conditionStr += " AND [IP]=@" + headStr + "IP ";
                }
                
                if (this.orderID_initialized)
                {
                    conditionStr += " AND [OrderID]=@" + headStr + "OrderID ";
                }
                
                if (this.version_initialized)
                {
                    conditionStr += " AND [Version]=@" + headStr + "Version ";
                }
                
                if (this.seviceID_initialized)
                {
                    conditionStr += " AND [SeviceID]=@" + headStr + "SeviceID ";
                }
                
                if (this.groupID_initialized)
                {
                    conditionStr += " AND [GroupID]=@" + headStr + "GroupID ";
                }
                
                if (this.areaID_initialized)
                {
                    conditionStr += " AND [AreaID]=@" + headStr + "AreaID ";
                }
                
                if (this.state_initialized)
                {
                    conditionStr += " AND [State]=@" + headStr + "State ";
                }
                
                if (this.lastTime_initialized)
                {
                    conditionStr += " AND [LastTime]=@" + headStr + "LastTime ";
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
                
                if (this.typeID_initialized)
                {
                    contentText += ", [TypeID] ";
                }
                
                if (this.brief_initialized)
                {
                    contentText += ", [Brief] ";
                }
                
                if (this.iP_initialized)
                {
                    contentText += ", [IP] ";
                }
                
                if (this.orderID_initialized)
                {
                    contentText += ", [OrderID] ";
                }
                
                if (this.version_initialized)
                {
                    contentText += ", [Version] ";
                }
                
                if (this.seviceID_initialized)
                {
                    contentText += ", [SeviceID] ";
                }
                
                if (this.groupID_initialized)
                {
                    contentText += ", [GroupID] ";
                }
                
                if (this.areaID_initialized)
                {
                    contentText += ", [AreaID] ";
                }
                
                if (this.state_initialized)
                {
                    contentText += ", [State] ";
                }
                
                if (this.lastTime_initialized)
                {
                    contentText += ", [LastTime] ";
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
                
                if (this.typeID_initialized)
                {
                    contentText += ", @" + headStr + "TypeID ";
                }
                
                if (this.brief_initialized)
                {
                    contentText += ", @" + headStr + "Brief ";
                }
                
                if (this.iP_initialized)
                {
                    contentText += ", @" + headStr + "IP ";
                }
                
                if (this.orderID_initialized)
                {
                    contentText += ", @" + headStr + "OrderID ";
                }
                
                if (this.version_initialized)
                {
                    contentText += ", @" + headStr + "Version ";
                }
                
                if (this.seviceID_initialized)
                {
                    contentText += ", @" + headStr + "SeviceID ";
                }
                
                if (this.groupID_initialized)
                {
                    contentText += ", @" + headStr + "GroupID ";
                }
                
                if (this.areaID_initialized)
                {
                    contentText += ", @" + headStr + "AreaID ";
                }
                
                if (this.state_initialized)
                {
                    contentText += ", @" + headStr + "State ";
                }
                
                if (this.lastTime_initialized)
                {
                    contentText += ", @" + headStr + "LastTime ";
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
            string tableName = "PC_Channel";
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
            
            this.typeID_initialized = true;
            
            this.brief_initialized = true;
            
            this.iP_initialized = true;
            
            this.orderID_initialized = true;
            
            this.version_initialized = true;
            
            this.seviceID_initialized = true;
            
            this.groupID_initialized = true;
            
            this.areaID_initialized = true;
            
            this.state_initialized = true;
            
            this.lastTime_initialized = true;
            
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

            
            if(page.Request["typeID"] != null)
            {
                if (this.typeID_initialized)
                {
                    if(page.Request["typeID"] != "")
                    {
                        this.TypeID = Convert.ToInt32(page.Request["typeID"]);
                    }
                    else
                    {
                        this.typeID_initialized = false;
                    }
                }
                else
                {
                    this.TypeID = Convert.ToInt32(page.Request["typeID"]);
                }
            }

            
            if(page.Request["brief"] != null)
            {
                if (this.brief_initialized)
                {
                    if(page.Request["brief"] != "")
                    {
                        this.Brief = Convert.ToString(page.Request["brief"]);
                    }
                    else
                    {
                        this.brief_initialized = false;
                    }
                }
                else
                {
                    this.Brief = Convert.ToString(page.Request["brief"]);
                }
            }

            
            if(page.Request["iP"] != null)
            {
                if (this.iP_initialized)
                {
                    if(page.Request["iP"] != "")
                    {
                        this.IP = Convert.ToString(page.Request["iP"]);
                    }
                    else
                    {
                        this.iP_initialized = false;
                    }
                }
                else
                {
                    this.IP = Convert.ToString(page.Request["iP"]);
                }
            }

            
            if(page.Request["orderID"] != null)
            {
                if (this.orderID_initialized)
                {
                    if(page.Request["orderID"] != "")
                    {
                        this.OrderID = Convert.ToInt64(page.Request["orderID"]);
                    }
                    else
                    {
                        this.orderID_initialized = false;
                    }
                }
                else
                {
                    this.OrderID = Convert.ToInt64(page.Request["orderID"]);
                }
            }

            
            if(page.Request["version"] != null)
            {
                if (this.version_initialized)
                {
                    if(page.Request["version"] != "")
                    {
                        this.Version = Convert.ToInt32(page.Request["version"]);
                    }
                    else
                    {
                        this.version_initialized = false;
                    }
                }
                else
                {
                    this.Version = Convert.ToInt32(page.Request["version"]);
                }
            }

            
            if(page.Request["seviceID"] != null)
            {
                if (this.seviceID_initialized)
                {
                    if(page.Request["seviceID"] != "")
                    {
                        this.SeviceID = Convert.ToInt32(page.Request["seviceID"]);
                    }
                    else
                    {
                        this.seviceID_initialized = false;
                    }
                }
                else
                {
                    this.SeviceID = Convert.ToInt32(page.Request["seviceID"]);
                }
            }

            
            if(page.Request["groupID"] != null)
            {
                if (this.groupID_initialized)
                {
                    if(page.Request["groupID"] != "")
                    {
                        this.GroupID = Convert.ToInt32(page.Request["groupID"]);
                    }
                    else
                    {
                        this.groupID_initialized = false;
                    }
                }
                else
                {
                    this.GroupID = Convert.ToInt32(page.Request["groupID"]);
                }
            }

            
            if(page.Request["areaID"] != null)
            {
                if (this.areaID_initialized)
                {
                    if(page.Request["areaID"] != "")
                    {
                        this.AreaID = Convert.ToInt32(page.Request["areaID"]);
                    }
                    else
                    {
                        this.areaID_initialized = false;
                    }
                }
                else
                {
                    this.AreaID = Convert.ToInt32(page.Request["areaID"]);
                }
            }

            
            if(page.Request["state"] != null)
            {
                if (this.state_initialized)
                {
                    if(page.Request["state"] != "")
                    {
                        this.State = Convert.ToInt32(page.Request["state"]);
                    }
                    else
                    {
                        this.state_initialized = false;
                    }
                }
                else
                {
                    this.State = Convert.ToInt32(page.Request["state"]);
                }
            }

            
            if(page.Request["lastTime"] != null)
            {
                if (this.lastTime_initialized)
                {
                    if(page.Request["lastTime"] != "")
                    {
                        this.LastTime = Convert.ToDateTime(page.Request["lastTime"]);
                    }
                    else
                    {
                        this.lastTime_initialized = false;
                    }
                }
                else
                {
                    this.LastTime = Convert.ToDateTime(page.Request["lastTime"]);
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