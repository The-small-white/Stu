/************************************************************

  Copyright (c) 2008，
  Author:               Date: 2019/10/29 15:04:19
  Description:    数据表UserFaceTime对应的业务逻辑层
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
    /// 与UserFaceTime数据表对应对象
    /// </summary>
    public class UserFaceTime : IDateBuildTable
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
        
        private int m_userID;
        private bool userID_initialized = false;
        
        private DateTime m_lastTime;
        private bool lastTime_initialized = false;
        
        private DateTime m_addTime;
        private bool addTime_initialized = false;
        
        private double m_time;
        private bool time_initialized = false;
        
        private int m_zQID;
        private bool zQID_initialized = false;
        
        private string m_headPic;
        private bool headPic_initialized = false;
        
        private double m_quality;
        private bool quality_initialized = false;
        

        public UserFaceTime()
        {
        }

        public UserFaceTime(int iD, int userID, DateTime lastTime, DateTime addTime, double time, int zQID, string headPic, double quality)
        {
            
            this.ID = iD;
            
            this.UserID = userID;
            
            this.LastTime = lastTime;
            
            this.AddTime = addTime;
            
            this.Time = time;
            
            this.ZQID = zQID;
            
            this.HeadPic = headPic;
            
            this.Quality = quality;
            
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

            
            if(CheckColumn(dr, "UserID"))
            {
                if (dr["UserID"] != null && dr["UserID"] != DBNull.Value)
                {
                    this.UserID = Convert.ToInt32(dr["UserID"]);
                }
            }

            
            if(CheckColumn(dr, "LastTime"))
            {
                if (dr["LastTime"] != null && dr["LastTime"] != DBNull.Value)
                {
                    this.LastTime = Convert.ToDateTime(dr["LastTime"]);
                }
            }

            
            if(CheckColumn(dr, "AddTime"))
            {
                if (dr["AddTime"] != null && dr["AddTime"] != DBNull.Value)
                {
                    this.AddTime = Convert.ToDateTime(dr["AddTime"]);
                }
            }

            
            if(CheckColumn(dr, "Time"))
            {
                if (dr["Time"] != null && dr["Time"] != DBNull.Value)
                {
                    this.Time = Convert.ToDouble(dr["Time"]);
                }
            }

            
            if(CheckColumn(dr, "ZQID"))
            {
                if (dr["ZQID"] != null && dr["ZQID"] != DBNull.Value)
                {
                    this.ZQID = Convert.ToInt32(dr["ZQID"]);
                }
            }

            
            if(CheckColumn(dr, "HeadPic"))
            {
                if (dr["HeadPic"] != null && dr["HeadPic"] != DBNull.Value)
                {
                    this.HeadPic = Convert.ToString(dr["HeadPic"]);
                }
            }

            
            if(CheckColumn(dr, "Quality"))
            {
                if (dr["Quality"] != null && dr["Quality"] != DBNull.Value)
                {
                    this.Quality = Convert.ToDouble(dr["Quality"]);
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
        
        public int UserID
        {
            get
            {
                return this.m_userID;
            }
            set
            {
                userID_initialized = true;
                this.m_userID = value;
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
        
        public double Time
        {
            get
            {
                return this.m_time;
            }
            set
            {
                time_initialized = true;
                this.m_time = value;
            }
        }
        
        public int ZQID
        {
            get
            {
                return this.m_zQID;
            }
            set
            {
                zQID_initialized = true;
                this.m_zQID = value;
            }
        }
        
        public string HeadPic
        {
            get
            {
                return this.m_headPic;
            }
            set
            {
                headPic_initialized = true;
                this.m_headPic = value;
            }
        }
        
        public double Quality
        {
            get
            {
                return this.m_quality;
            }
            set
            {
                quality_initialized = true;
                this.m_quality = value;
            }
        }
        


        /// <summary>
        /// 判断对象属性是否赋值。没有赋值返回true
        /// </summary>
        public bool IsNull
        {
            get
            {
                if (iD_initialized || userID_initialized || lastTime_initialized || addTime_initialized || time_initialized || zQID_initialized || headPic_initialized || quality_initialized)
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
            
            if (userID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "UserID", SqlDbType.Int);
                n_Parameter.Value = this.UserID;
                n_Parameter.SourceColumn = "UserID";
                parametersList.Add(n_Parameter);
            }
            
            if (lastTime_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "LastTime", SqlDbType.DateTime);
                n_Parameter.Value = this.LastTime;
                n_Parameter.SourceColumn = "LastTime";
                parametersList.Add(n_Parameter);
            }
            
            if (addTime_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "AddTime", SqlDbType.DateTime);
                n_Parameter.Value = this.AddTime;
                n_Parameter.SourceColumn = "AddTime";
                parametersList.Add(n_Parameter);
            }
            
            if (time_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Time", SqlDbType.Float);
                n_Parameter.Value = this.Time;
                n_Parameter.SourceColumn = "Time";
                parametersList.Add(n_Parameter);
            }
            
            if (zQID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ZQID", SqlDbType.Int);
                n_Parameter.Value = this.ZQID;
                n_Parameter.SourceColumn = "ZQID";
                parametersList.Add(n_Parameter);
            }
            
            if (headPic_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "HeadPic", SqlDbType.NVarChar);
                n_Parameter.Value = this.HeadPic;
                n_Parameter.SourceColumn = "HeadPic";
                parametersList.Add(n_Parameter);
            }
            
            if (quality_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Quality", SqlDbType.Float);
                n_Parameter.Value = this.Quality;
                n_Parameter.SourceColumn = "Quality";
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
                
                if (this.userID_initialized)
                {
                    contentText += ", [UserID]=@" + headStr + "UserID ";
                }
                
                if (this.lastTime_initialized)
                {
                    contentText += ", [LastTime]=@" + headStr + "LastTime ";
                }
                
                if (this.addTime_initialized)
                {
                    contentText += ", [AddTime]=@" + headStr + "AddTime ";
                }
                
                if (this.time_initialized)
                {
                    contentText += ", [Time]=@" + headStr + "Time ";
                }
                
                if (this.zQID_initialized)
                {
                    contentText += ", [ZQID]=@" + headStr + "ZQID ";
                }
                
                if (this.headPic_initialized)
                {
                    contentText += ", [HeadPic]=@" + headStr + "HeadPic ";
                }
                
                if (this.quality_initialized)
                {
                    contentText += ", [Quality]=@" + headStr + "Quality ";
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
                
                if (this.userID_initialized)
                {
                    conditionStr += " AND [UserID]=@" + headStr + "UserID ";
                }
                
                if (this.lastTime_initialized)
                {
                    conditionStr += " AND [LastTime]=@" + headStr + "LastTime ";
                }
                
                if (this.addTime_initialized)
                {
                    conditionStr += " AND [AddTime]=@" + headStr + "AddTime ";
                }
                
                if (this.time_initialized)
                {
                    conditionStr += " AND [Time]=@" + headStr + "Time ";
                }
                
                if (this.zQID_initialized)
                {
                    conditionStr += " AND [ZQID]=@" + headStr + "ZQID ";
                }
                
                if (this.headPic_initialized)
                {
                    conditionStr += " AND [HeadPic]=@" + headStr + "HeadPic ";
                }
                
                if (this.quality_initialized)
                {
                    conditionStr += " AND [Quality]=@" + headStr + "Quality ";
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
                
                if (this.userID_initialized)
                {
                    contentText += ", [UserID] ";
                }
                
                if (this.lastTime_initialized)
                {
                    contentText += ", [LastTime] ";
                }
                
                if (this.addTime_initialized)
                {
                    contentText += ", [AddTime] ";
                }
                
                if (this.time_initialized)
                {
                    contentText += ", [Time] ";
                }
                
                if (this.zQID_initialized)
                {
                    contentText += ", [ZQID] ";
                }
                
                if (this.headPic_initialized)
                {
                    contentText += ", [HeadPic] ";
                }
                
                if (this.quality_initialized)
                {
                    contentText += ", [Quality] ";
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
                
                if (this.userID_initialized)
                {
                    contentText += ", @" + headStr + "UserID ";
                }
                
                if (this.lastTime_initialized)
                {
                    contentText += ", @" + headStr + "LastTime ";
                }
                
                if (this.addTime_initialized)
                {
                    contentText += ", @" + headStr + "AddTime ";
                }
                
                if (this.time_initialized)
                {
                    contentText += ", @" + headStr + "Time ";
                }
                
                if (this.zQID_initialized)
                {
                    contentText += ", @" + headStr + "ZQID ";
                }
                
                if (this.headPic_initialized)
                {
                    contentText += ", @" + headStr + "HeadPic ";
                }
                
                if (this.quality_initialized)
                {
                    contentText += ", @" + headStr + "Quality ";
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
            string tableName = "UserFaceTime";
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
            
            this.userID_initialized = true;
            
            this.lastTime_initialized = true;
            
            this.addTime_initialized = true;
            
            this.time_initialized = true;
            
            this.zQID_initialized = true;
            
            this.headPic_initialized = true;
            
            this.quality_initialized = true;
            
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

            
            if(page.Request["userID"] != null)
            {
                if (this.userID_initialized)
                {
                    if(page.Request["userID"] != "")
                    {
                        this.UserID = Convert.ToInt32(page.Request["userID"]);
                    }
                    else
                    {
                        this.userID_initialized = false;
                    }
                }
                else
                {
                    this.UserID = Convert.ToInt32(page.Request["userID"]);
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

            
            if(page.Request["time"] != null)
            {
                if (this.time_initialized)
                {
                    if(page.Request["time"] != "")
                    {
                        this.Time = Convert.ToDouble(page.Request["time"]);
                    }
                    else
                    {
                        this.time_initialized = false;
                    }
                }
                else
                {
                    this.Time = Convert.ToDouble(page.Request["time"]);
                }
            }

            
            if(page.Request["zQID"] != null)
            {
                if (this.zQID_initialized)
                {
                    if(page.Request["zQID"] != "")
                    {
                        this.ZQID = Convert.ToInt32(page.Request["zQID"]);
                    }
                    else
                    {
                        this.zQID_initialized = false;
                    }
                }
                else
                {
                    this.ZQID = Convert.ToInt32(page.Request["zQID"]);
                }
            }

            
            if(page.Request["headPic"] != null)
            {
                if (this.headPic_initialized)
                {
                    if(page.Request["headPic"] != "")
                    {
                        this.HeadPic = Convert.ToString(page.Request["headPic"]);
                    }
                    else
                    {
                        this.headPic_initialized = false;
                    }
                }
                else
                {
                    this.HeadPic = Convert.ToString(page.Request["headPic"]);
                }
            }

            
            if(page.Request["quality"] != null)
            {
                if (this.quality_initialized)
                {
                    if(page.Request["quality"] != "")
                    {
                        this.Quality = Convert.ToDouble(page.Request["quality"]);
                    }
                    else
                    {
                        this.quality_initialized = false;
                    }
                }
                else
                {
                    this.Quality = Convert.ToDouble(page.Request["quality"]);
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