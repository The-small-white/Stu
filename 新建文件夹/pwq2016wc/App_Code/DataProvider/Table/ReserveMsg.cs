/************************************************************

  Copyright (c) 2008，
  Author:               Date: 2019/8/21 11:22:05
  Description:    数据表ReserveMsg对应的业务逻辑层
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
    /// 与ReserveMsg数据表对应对象
    /// </summary>
    public class ReserveMsg : IDateBuildTable
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
        
        private int m_addID;
        private bool addID_initialized = false;
        
        private DateTime m_addTime;
        private bool addTime_initialized = false;
        
        private int m_exhibitionID;
        private bool exhibitionID_initialized = false;
        
        private DateTime m_reserveTime;
        private bool reserveTime_initialized = false;
        
        private int m_dateType;
        private bool dateType_initialized = false;
        
        private string m_reserveName;
        private bool reserveName_initialized = false;
        
        private string m_reservePhone;
        private bool reservePhone_initialized = false;
        
        private int m_reserveCount;
        private bool reserveCount_initialized = false;
        
        private int m_userInfoID;
        private bool userInfoID_initialized = false;
        
        private string m_openID;
        private bool openID_initialized = false;
        
        private int m_states;
        private bool states_initialized = false;
        
        private string m_brief;
        private bool brief_initialized = false;
        

        public ReserveMsg()
        {
        }

        public ReserveMsg(int iD, int addID, DateTime addTime, int exhibitionID, DateTime reserveTime, int dateType, string reserveName, string reservePhone, int reserveCount, int userInfoID, string openID, int states, string brief)
        {
            
            this.ID = iD;
            
            this.AddID = addID;
            
            this.AddTime = addTime;
            
            this.ExhibitionID = exhibitionID;
            
            this.ReserveTime = reserveTime;
            
            this.DateType = dateType;
            
            this.ReserveName = reserveName;
            
            this.ReservePhone = reservePhone;
            
            this.ReserveCount = reserveCount;
            
            this.UserInfoID = userInfoID;
            
            this.OpenID = openID;
            
            this.States = states;
            
            this.Brief = brief;
            
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

            
            if(CheckColumn(dr, "AddID"))
            {
                if (dr["AddID"] != null && dr["AddID"] != DBNull.Value)
                {
                    this.AddID = Convert.ToInt32(dr["AddID"]);
                }
            }

            
            if(CheckColumn(dr, "AddTime"))
            {
                if (dr["AddTime"] != null && dr["AddTime"] != DBNull.Value)
                {
                    this.AddTime = Convert.ToDateTime(dr["AddTime"]);
                }
            }

            
            if(CheckColumn(dr, "ExhibitionID"))
            {
                if (dr["ExhibitionID"] != null && dr["ExhibitionID"] != DBNull.Value)
                {
                    this.ExhibitionID = Convert.ToInt32(dr["ExhibitionID"]);
                }
            }

            
            if(CheckColumn(dr, "ReserveTime"))
            {
                if (dr["ReserveTime"] != null && dr["ReserveTime"] != DBNull.Value)
                {
                    this.ReserveTime = Convert.ToDateTime(dr["ReserveTime"]);
                }
            }

            
            if(CheckColumn(dr, "DateType"))
            {
                if (dr["DateType"] != null && dr["DateType"] != DBNull.Value)
                {
                    this.DateType = Convert.ToInt32(dr["DateType"]);
                }
            }

            
            if(CheckColumn(dr, "ReserveName"))
            {
                if (dr["ReserveName"] != null && dr["ReserveName"] != DBNull.Value)
                {
                    this.ReserveName = Convert.ToString(dr["ReserveName"]);
                }
            }

            
            if(CheckColumn(dr, "ReservePhone"))
            {
                if (dr["ReservePhone"] != null && dr["ReservePhone"] != DBNull.Value)
                {
                    this.ReservePhone = Convert.ToString(dr["ReservePhone"]);
                }
            }

            
            if(CheckColumn(dr, "ReserveCount"))
            {
                if (dr["ReserveCount"] != null && dr["ReserveCount"] != DBNull.Value)
                {
                    this.ReserveCount = Convert.ToInt32(dr["ReserveCount"]);
                }
            }

            
            if(CheckColumn(dr, "UserInfoID"))
            {
                if (dr["UserInfoID"] != null && dr["UserInfoID"] != DBNull.Value)
                {
                    this.UserInfoID = Convert.ToInt32(dr["UserInfoID"]);
                }
            }

            
            if(CheckColumn(dr, "OpenID"))
            {
                if (dr["OpenID"] != null && dr["OpenID"] != DBNull.Value)
                {
                    this.OpenID = Convert.ToString(dr["OpenID"]);
                }
            }

            
            if(CheckColumn(dr, "States"))
            {
                if (dr["States"] != null && dr["States"] != DBNull.Value)
                {
                    this.States = Convert.ToInt32(dr["States"]);
                }
            }

            
            if(CheckColumn(dr, "Brief"))
            {
                if (dr["Brief"] != null && dr["Brief"] != DBNull.Value)
                {
                    this.Brief = Convert.ToString(dr["Brief"]);
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
        
        public int AddID
        {
            get
            {
                return this.m_addID;
            }
            set
            {
                addID_initialized = true;
                this.m_addID = value;
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
        
        public int ExhibitionID
        {
            get
            {
                return this.m_exhibitionID;
            }
            set
            {
                exhibitionID_initialized = true;
                this.m_exhibitionID = value;
            }
        }
        
        public DateTime ReserveTime
        {
            get
            {
                return this.m_reserveTime;
            }
            set
            {
                reserveTime_initialized = true;
                this.m_reserveTime = value;
            }
        }
        
        public int DateType
        {
            get
            {
                return this.m_dateType;
            }
            set
            {
                dateType_initialized = true;
                this.m_dateType = value;
            }
        }
        
        public string ReserveName
        {
            get
            {
                return this.m_reserveName;
            }
            set
            {
                reserveName_initialized = true;
                this.m_reserveName = value;
            }
        }
        
        public string ReservePhone
        {
            get
            {
                return this.m_reservePhone;
            }
            set
            {
                reservePhone_initialized = true;
                this.m_reservePhone = value;
            }
        }
        
        public int ReserveCount
        {
            get
            {
                return this.m_reserveCount;
            }
            set
            {
                reserveCount_initialized = true;
                this.m_reserveCount = value;
            }
        }
        
        public int UserInfoID
        {
            get
            {
                return this.m_userInfoID;
            }
            set
            {
                userInfoID_initialized = true;
                this.m_userInfoID = value;
            }
        }
        
        public string OpenID
        {
            get
            {
                return this.m_openID;
            }
            set
            {
                openID_initialized = true;
                this.m_openID = value;
            }
        }
        
        public int States
        {
            get
            {
                return this.m_states;
            }
            set
            {
                states_initialized = true;
                this.m_states = value;
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
        


        /// <summary>
        /// 判断对象属性是否赋值。没有赋值返回true
        /// </summary>
        public bool IsNull
        {
            get
            {
                if (iD_initialized || addID_initialized || addTime_initialized || exhibitionID_initialized || reserveTime_initialized || dateType_initialized || reserveName_initialized || reservePhone_initialized || reserveCount_initialized || userInfoID_initialized || openID_initialized || states_initialized || brief_initialized)
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
            
            if (addID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "AddID", SqlDbType.Int);
                n_Parameter.Value = this.AddID;
                n_Parameter.SourceColumn = "AddID";
                parametersList.Add(n_Parameter);
            }
            
            if (addTime_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "AddTime", SqlDbType.DateTime);
                n_Parameter.Value = this.AddTime;
                n_Parameter.SourceColumn = "AddTime";
                parametersList.Add(n_Parameter);
            }
            
            if (exhibitionID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ExhibitionID", SqlDbType.Int);
                n_Parameter.Value = this.ExhibitionID;
                n_Parameter.SourceColumn = "ExhibitionID";
                parametersList.Add(n_Parameter);
            }
            
            if (reserveTime_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ReserveTime", SqlDbType.DateTime);
                n_Parameter.Value = this.ReserveTime;
                n_Parameter.SourceColumn = "ReserveTime";
                parametersList.Add(n_Parameter);
            }
            
            if (dateType_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "DateType", SqlDbType.Int);
                n_Parameter.Value = this.DateType;
                n_Parameter.SourceColumn = "DateType";
                parametersList.Add(n_Parameter);
            }
            
            if (reserveName_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ReserveName", SqlDbType.NVarChar);
                n_Parameter.Value = this.ReserveName;
                n_Parameter.SourceColumn = "ReserveName";
                parametersList.Add(n_Parameter);
            }
            
            if (reservePhone_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ReservePhone", SqlDbType.NVarChar);
                n_Parameter.Value = this.ReservePhone;
                n_Parameter.SourceColumn = "ReservePhone";
                parametersList.Add(n_Parameter);
            }
            
            if (reserveCount_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ReserveCount", SqlDbType.Int);
                n_Parameter.Value = this.ReserveCount;
                n_Parameter.SourceColumn = "ReserveCount";
                parametersList.Add(n_Parameter);
            }
            
            if (userInfoID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "UserInfoID", SqlDbType.Int);
                n_Parameter.Value = this.UserInfoID;
                n_Parameter.SourceColumn = "UserInfoID";
                parametersList.Add(n_Parameter);
            }
            
            if (openID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "OpenID", SqlDbType.NVarChar);
                n_Parameter.Value = this.OpenID;
                n_Parameter.SourceColumn = "OpenID";
                parametersList.Add(n_Parameter);
            }
            
            if (states_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "States", SqlDbType.Int);
                n_Parameter.Value = this.States;
                n_Parameter.SourceColumn = "States";
                parametersList.Add(n_Parameter);
            }
            
            if (brief_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Brief", SqlDbType.NVarChar);
                n_Parameter.Value = this.Brief;
                n_Parameter.SourceColumn = "Brief";
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
                
                if (this.addID_initialized)
                {
                    contentText += ", [AddID]=@" + headStr + "AddID ";
                }
                
                if (this.addTime_initialized)
                {
                    contentText += ", [AddTime]=@" + headStr + "AddTime ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    contentText += ", [ExhibitionID]=@" + headStr + "ExhibitionID ";
                }
                
                if (this.reserveTime_initialized)
                {
                    contentText += ", [ReserveTime]=@" + headStr + "ReserveTime ";
                }
                
                if (this.dateType_initialized)
                {
                    contentText += ", [DateType]=@" + headStr + "DateType ";
                }
                
                if (this.reserveName_initialized)
                {
                    contentText += ", [ReserveName]=@" + headStr + "ReserveName ";
                }
                
                if (this.reservePhone_initialized)
                {
                    contentText += ", [ReservePhone]=@" + headStr + "ReservePhone ";
                }
                
                if (this.reserveCount_initialized)
                {
                    contentText += ", [ReserveCount]=@" + headStr + "ReserveCount ";
                }
                
                if (this.userInfoID_initialized)
                {
                    contentText += ", [UserInfoID]=@" + headStr + "UserInfoID ";
                }
                
                if (this.openID_initialized)
                {
                    contentText += ", [OpenID]=@" + headStr + "OpenID ";
                }
                
                if (this.states_initialized)
                {
                    contentText += ", [States]=@" + headStr + "States ";
                }
                
                if (this.brief_initialized)
                {
                    contentText += ", [Brief]=@" + headStr + "Brief ";
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
                
                if (this.addID_initialized)
                {
                    conditionStr += " AND [AddID]=@" + headStr + "AddID ";
                }
                
                if (this.addTime_initialized)
                {
                    conditionStr += " AND [AddTime]=@" + headStr + "AddTime ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    conditionStr += " AND [ExhibitionID]=@" + headStr + "ExhibitionID ";
                }
                
                if (this.reserveTime_initialized)
                {
                    conditionStr += " AND [ReserveTime]=@" + headStr + "ReserveTime ";
                }
                
                if (this.dateType_initialized)
                {
                    conditionStr += " AND [DateType]=@" + headStr + "DateType ";
                }
                
                if (this.reserveName_initialized)
                {
                    conditionStr += " AND [ReserveName]=@" + headStr + "ReserveName ";
                }
                
                if (this.reservePhone_initialized)
                {
                    conditionStr += " AND [ReservePhone]=@" + headStr + "ReservePhone ";
                }
                
                if (this.reserveCount_initialized)
                {
                    conditionStr += " AND [ReserveCount]=@" + headStr + "ReserveCount ";
                }
                
                if (this.userInfoID_initialized)
                {
                    conditionStr += " AND [UserInfoID]=@" + headStr + "UserInfoID ";
                }
                
                if (this.openID_initialized)
                {
                    conditionStr += " AND [OpenID]=@" + headStr + "OpenID ";
                }
                
                if (this.states_initialized)
                {
                    conditionStr += " AND [States]=@" + headStr + "States ";
                }
                
                if (this.brief_initialized)
                {
                    conditionStr += " AND [Brief]=@" + headStr + "Brief ";
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
                
                if (this.addID_initialized)
                {
                    contentText += ", [AddID] ";
                }
                
                if (this.addTime_initialized)
                {
                    contentText += ", [AddTime] ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    contentText += ", [ExhibitionID] ";
                }
                
                if (this.reserveTime_initialized)
                {
                    contentText += ", [ReserveTime] ";
                }
                
                if (this.dateType_initialized)
                {
                    contentText += ", [DateType] ";
                }
                
                if (this.reserveName_initialized)
                {
                    contentText += ", [ReserveName] ";
                }
                
                if (this.reservePhone_initialized)
                {
                    contentText += ", [ReservePhone] ";
                }
                
                if (this.reserveCount_initialized)
                {
                    contentText += ", [ReserveCount] ";
                }
                
                if (this.userInfoID_initialized)
                {
                    contentText += ", [UserInfoID] ";
                }
                
                if (this.openID_initialized)
                {
                    contentText += ", [OpenID] ";
                }
                
                if (this.states_initialized)
                {
                    contentText += ", [States] ";
                }
                
                if (this.brief_initialized)
                {
                    contentText += ", [Brief] ";
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
                
                if (this.addID_initialized)
                {
                    contentText += ", @" + headStr + "AddID ";
                }
                
                if (this.addTime_initialized)
                {
                    contentText += ", @" + headStr + "AddTime ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    contentText += ", @" + headStr + "ExhibitionID ";
                }
                
                if (this.reserveTime_initialized)
                {
                    contentText += ", @" + headStr + "ReserveTime ";
                }
                
                if (this.dateType_initialized)
                {
                    contentText += ", @" + headStr + "DateType ";
                }
                
                if (this.reserveName_initialized)
                {
                    contentText += ", @" + headStr + "ReserveName ";
                }
                
                if (this.reservePhone_initialized)
                {
                    contentText += ", @" + headStr + "ReservePhone ";
                }
                
                if (this.reserveCount_initialized)
                {
                    contentText += ", @" + headStr + "ReserveCount ";
                }
                
                if (this.userInfoID_initialized)
                {
                    contentText += ", @" + headStr + "UserInfoID ";
                }
                
                if (this.openID_initialized)
                {
                    contentText += ", @" + headStr + "OpenID ";
                }
                
                if (this.states_initialized)
                {
                    contentText += ", @" + headStr + "States ";
                }
                
                if (this.brief_initialized)
                {
                    contentText += ", @" + headStr + "Brief ";
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
            string tableName = "ReserveMsg";
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
            
            this.addID_initialized = true;
            
            this.addTime_initialized = true;
            
            this.exhibitionID_initialized = true;
            
            this.reserveTime_initialized = true;
            
            this.dateType_initialized = true;
            
            this.reserveName_initialized = true;
            
            this.reservePhone_initialized = true;
            
            this.reserveCount_initialized = true;
            
            this.userInfoID_initialized = true;
            
            this.openID_initialized = true;
            
            this.states_initialized = true;
            
            this.brief_initialized = true;
            
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

            
            if(page.Request["addID"] != null)
            {
                if (this.addID_initialized)
                {
                    if(page.Request["addID"] != "")
                    {
                        this.AddID = Convert.ToInt32(page.Request["addID"]);
                    }
                    else
                    {
                        this.addID_initialized = false;
                    }
                }
                else
                {
                    this.AddID = Convert.ToInt32(page.Request["addID"]);
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

            
            if(page.Request["exhibitionID"] != null)
            {
                if (this.exhibitionID_initialized)
                {
                    if(page.Request["exhibitionID"] != "")
                    {
                        this.ExhibitionID = Convert.ToInt32(page.Request["exhibitionID"]);
                    }
                    else
                    {
                        this.exhibitionID_initialized = false;
                    }
                }
                else
                {
                    this.ExhibitionID = Convert.ToInt32(page.Request["exhibitionID"]);
                }
            }

            
            if(page.Request["reserveTime"] != null)
            {
                if (this.reserveTime_initialized)
                {
                    if(page.Request["reserveTime"] != "")
                    {
                        this.ReserveTime = Convert.ToDateTime(page.Request["reserveTime"]);
                    }
                    else
                    {
                        this.reserveTime_initialized = false;
                    }
                }
                else
                {
                    this.ReserveTime = Convert.ToDateTime(page.Request["reserveTime"]);
                }
            }

            
            if(page.Request["dateType"] != null)
            {
                if (this.dateType_initialized)
                {
                    if(page.Request["dateType"] != "")
                    {
                        this.DateType = Convert.ToInt32(page.Request["dateType"]);
                    }
                    else
                    {
                        this.dateType_initialized = false;
                    }
                }
                else
                {
                    this.DateType = Convert.ToInt32(page.Request["dateType"]);
                }
            }

            
            if(page.Request["reserveName"] != null)
            {
                if (this.reserveName_initialized)
                {
                    if(page.Request["reserveName"] != "")
                    {
                        this.ReserveName = Convert.ToString(page.Request["reserveName"]);
                    }
                    else
                    {
                        this.reserveName_initialized = false;
                    }
                }
                else
                {
                    this.ReserveName = Convert.ToString(page.Request["reserveName"]);
                }
            }

            
            if(page.Request["reservePhone"] != null)
            {
                if (this.reservePhone_initialized)
                {
                    if(page.Request["reservePhone"] != "")
                    {
                        this.ReservePhone = Convert.ToString(page.Request["reservePhone"]);
                    }
                    else
                    {
                        this.reservePhone_initialized = false;
                    }
                }
                else
                {
                    this.ReservePhone = Convert.ToString(page.Request["reservePhone"]);
                }
            }

            
            if(page.Request["reserveCount"] != null)
            {
                if (this.reserveCount_initialized)
                {
                    if(page.Request["reserveCount"] != "")
                    {
                        this.ReserveCount = Convert.ToInt32(page.Request["reserveCount"]);
                    }
                    else
                    {
                        this.reserveCount_initialized = false;
                    }
                }
                else
                {
                    this.ReserveCount = Convert.ToInt32(page.Request["reserveCount"]);
                }
            }

            
            if(page.Request["userInfoID"] != null)
            {
                if (this.userInfoID_initialized)
                {
                    if(page.Request["userInfoID"] != "")
                    {
                        this.UserInfoID = Convert.ToInt32(page.Request["userInfoID"]);
                    }
                    else
                    {
                        this.userInfoID_initialized = false;
                    }
                }
                else
                {
                    this.UserInfoID = Convert.ToInt32(page.Request["userInfoID"]);
                }
            }

            
            if(page.Request["openID"] != null)
            {
                if (this.openID_initialized)
                {
                    if(page.Request["openID"] != "")
                    {
                        this.OpenID = Convert.ToString(page.Request["openID"]);
                    }
                    else
                    {
                        this.openID_initialized = false;
                    }
                }
                else
                {
                    this.OpenID = Convert.ToString(page.Request["openID"]);
                }
            }

            
            if(page.Request["states"] != null)
            {
                if (this.states_initialized)
                {
                    if(page.Request["states"] != "")
                    {
                        this.States = Convert.ToInt32(page.Request["states"]);
                    }
                    else
                    {
                        this.states_initialized = false;
                    }
                }
                else
                {
                    this.States = Convert.ToInt32(page.Request["states"]);
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