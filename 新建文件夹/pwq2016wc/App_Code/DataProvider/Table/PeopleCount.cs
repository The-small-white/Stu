/************************************************************

  Copyright (c) 2008，
  Author:               Date: 2018/1/2 16:10:28
  Description:    数据表PeopleCount对应的业务逻辑层
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
    /// 与PeopleCount数据表对应对象
    /// </summary>
    public class PeopleCount : IDateBuildTable
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
        
        private int m_enterNum;
        private bool enterNum_initialized = false;
        
        private int m_exitNum;
        private bool exitNum_initialized = false;
        
        private DateTime m_countTime;
        private bool countTime_initialized = false;
        
        private int m_cameraID;
        private bool cameraID_initialized = false;
        

        public PeopleCount()
        {
        }

        public PeopleCount(int iD, int enterNum, int exitNum, DateTime countTime, int cameraID)
        {
            
            this.ID = iD;
            
            this.EnterNum = enterNum;
            
            this.ExitNum = exitNum;
            
            this.CountTime = countTime;
            
            this.CameraID = cameraID;
            
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

            
            if(CheckColumn(dr, "EnterNum"))
            {
                if (dr["EnterNum"] != null && dr["EnterNum"] != DBNull.Value)
                {
                    this.EnterNum = Convert.ToInt32(dr["EnterNum"]);
                }
            }

            
            if(CheckColumn(dr, "ExitNum"))
            {
                if (dr["ExitNum"] != null && dr["ExitNum"] != DBNull.Value)
                {
                    this.ExitNum = Convert.ToInt32(dr["ExitNum"]);
                }
            }

            
            if(CheckColumn(dr, "CountTime"))
            {
                if (dr["CountTime"] != null && dr["CountTime"] != DBNull.Value)
                {
                    this.CountTime = Convert.ToDateTime(dr["CountTime"]);
                }
            }

            
            if(CheckColumn(dr, "CameraID"))
            {
                if (dr["CameraID"] != null && dr["CameraID"] != DBNull.Value)
                {
                    this.CameraID = Convert.ToInt32(dr["CameraID"]);
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
        
        public int EnterNum
        {
            get
            {
                return this.m_enterNum;
            }
            set
            {
                enterNum_initialized = true;
                this.m_enterNum = value;
            }
        }
        
        public int ExitNum
        {
            get
            {
                return this.m_exitNum;
            }
            set
            {
                exitNum_initialized = true;
                this.m_exitNum = value;
            }
        }
        
        public DateTime CountTime
        {
            get
            {
                return this.m_countTime;
            }
            set
            {
                countTime_initialized = true;
                this.m_countTime = value;
            }
        }
        
        public int CameraID
        {
            get
            {
                return this.m_cameraID;
            }
            set
            {
                cameraID_initialized = true;
                this.m_cameraID = value;
            }
        }
        


        /// <summary>
        /// 判断对象属性是否赋值。没有赋值返回true
        /// </summary>
        public bool IsNull
        {
            get
            {
                if (iD_initialized || enterNum_initialized || exitNum_initialized || countTime_initialized || cameraID_initialized)
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
            
            if (enterNum_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "EnterNum", SqlDbType.Int);
                n_Parameter.Value = this.EnterNum;
                n_Parameter.SourceColumn = "EnterNum";
                parametersList.Add(n_Parameter);
            }
            
            if (exitNum_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ExitNum", SqlDbType.Int);
                n_Parameter.Value = this.ExitNum;
                n_Parameter.SourceColumn = "ExitNum";
                parametersList.Add(n_Parameter);
            }
            
            if (countTime_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "CountTime", SqlDbType.DateTime);
                n_Parameter.Value = this.CountTime;
                n_Parameter.SourceColumn = "CountTime";
                parametersList.Add(n_Parameter);
            }
            
            if (cameraID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "CameraID", SqlDbType.Int);
                n_Parameter.Value = this.CameraID;
                n_Parameter.SourceColumn = "CameraID";
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
                
                if (this.enterNum_initialized)
                {
                    contentText += ", [EnterNum]=@" + headStr + "EnterNum ";
                }
                
                if (this.exitNum_initialized)
                {
                    contentText += ", [ExitNum]=@" + headStr + "ExitNum ";
                }
                
                if (this.countTime_initialized)
                {
                    contentText += ", [CountTime]=@" + headStr + "CountTime ";
                }
                
                if (this.cameraID_initialized)
                {
                    contentText += ", [CameraID]=@" + headStr + "CameraID ";
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
                
                if (this.enterNum_initialized)
                {
                    conditionStr += " AND [EnterNum]=@" + headStr + "EnterNum ";
                }
                
                if (this.exitNum_initialized)
                {
                    conditionStr += " AND [ExitNum]=@" + headStr + "ExitNum ";
                }
                
                if (this.countTime_initialized)
                {
                    conditionStr += " AND [CountTime]=@" + headStr + "CountTime ";
                }
                
                if (this.cameraID_initialized)
                {
                    conditionStr += " AND [CameraID]=@" + headStr + "CameraID ";
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
                
                if (this.enterNum_initialized)
                {
                    contentText += ", [EnterNum] ";
                }
                
                if (this.exitNum_initialized)
                {
                    contentText += ", [ExitNum] ";
                }
                
                if (this.countTime_initialized)
                {
                    contentText += ", [CountTime] ";
                }
                
                if (this.cameraID_initialized)
                {
                    contentText += ", [CameraID] ";
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
                
                if (this.enterNum_initialized)
                {
                    contentText += ", @" + headStr + "EnterNum ";
                }
                
                if (this.exitNum_initialized)
                {
                    contentText += ", @" + headStr + "ExitNum ";
                }
                
                if (this.countTime_initialized)
                {
                    contentText += ", @" + headStr + "CountTime ";
                }
                
                if (this.cameraID_initialized)
                {
                    contentText += ", @" + headStr + "CameraID ";
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
            string tableName = "PeopleCount";
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
            
            this.enterNum_initialized = true;
            
            this.exitNum_initialized = true;
            
            this.countTime_initialized = true;
            
            this.cameraID_initialized = true;
            
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

            
            if(page.Request["enterNum"] != null)
            {
                if (this.enterNum_initialized)
                {
                    if(page.Request["enterNum"] != "")
                    {
                        this.EnterNum = Convert.ToInt32(page.Request["enterNum"]);
                    }
                    else
                    {
                        this.enterNum_initialized = false;
                    }
                }
                else
                {
                    this.EnterNum = Convert.ToInt32(page.Request["enterNum"]);
                }
            }

            
            if(page.Request["exitNum"] != null)
            {
                if (this.exitNum_initialized)
                {
                    if(page.Request["exitNum"] != "")
                    {
                        this.ExitNum = Convert.ToInt32(page.Request["exitNum"]);
                    }
                    else
                    {
                        this.exitNum_initialized = false;
                    }
                }
                else
                {
                    this.ExitNum = Convert.ToInt32(page.Request["exitNum"]);
                }
            }

            
            if(page.Request["countTime"] != null)
            {
                if (this.countTime_initialized)
                {
                    if(page.Request["countTime"] != "")
                    {
                        this.CountTime = Convert.ToDateTime(page.Request["countTime"]);
                    }
                    else
                    {
                        this.countTime_initialized = false;
                    }
                }
                else
                {
                    this.CountTime = Convert.ToDateTime(page.Request["countTime"]);
                }
            }

            
            if(page.Request["cameraID"] != null)
            {
                if (this.cameraID_initialized)
                {
                    if(page.Request["cameraID"] != "")
                    {
                        this.CameraID = Convert.ToInt32(page.Request["cameraID"]);
                    }
                    else
                    {
                        this.cameraID_initialized = false;
                    }
                }
                else
                {
                    this.CameraID = Convert.ToInt32(page.Request["cameraID"]);
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