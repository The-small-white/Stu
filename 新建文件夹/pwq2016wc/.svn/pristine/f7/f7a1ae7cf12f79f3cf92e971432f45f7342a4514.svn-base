/************************************************************

  Copyright (c) 2008，
  Author:               Date: 2017/12/27 10:38:35
  Description:    数据表Camera对应的业务逻辑层
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
    /// 与Camera数据表对应对象
    /// </summary>
    public class Camera : IDateBuildTable
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
        
        private string m_iPAddress;
        private bool iPAddress_initialized = false;
        
        private string m_macAddress;
        private bool macAddress_initialized = false;
        
        private int m_channelID;
        private bool channelID_initialized = false;
        

        public Camera()
        {
        }

        public Camera(int iD, string name, string iPAddress, string macAddress, int channelID)
        {
            
            this.ID = iD;
            
            this.Name = name;
            
            this.IPAddress = iPAddress;
            
            this.MacAddress = macAddress;
            
            this.ChannelID = channelID;
            
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

            
            if(CheckColumn(dr, "IPAddress"))
            {
                if (dr["IPAddress"] != null && dr["IPAddress"] != DBNull.Value)
                {
                    this.IPAddress = Convert.ToString(dr["IPAddress"]);
                }
            }

            
            if(CheckColumn(dr, "MacAddress"))
            {
                if (dr["MacAddress"] != null && dr["MacAddress"] != DBNull.Value)
                {
                    this.MacAddress = Convert.ToString(dr["MacAddress"]);
                }
            }

            
            if(CheckColumn(dr, "ChannelID"))
            {
                if (dr["ChannelID"] != null && dr["ChannelID"] != DBNull.Value)
                {
                    this.ChannelID = Convert.ToInt32(dr["ChannelID"]);
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
        
        public string IPAddress
        {
            get
            {
                return this.m_iPAddress;
            }
            set
            {
                iPAddress_initialized = true;
                this.m_iPAddress = value;
            }
        }
        
        public string MacAddress
        {
            get
            {
                return this.m_macAddress;
            }
            set
            {
                macAddress_initialized = true;
                this.m_macAddress = value;
            }
        }
        
        public int ChannelID
        {
            get
            {
                return this.m_channelID;
            }
            set
            {
                channelID_initialized = true;
                this.m_channelID = value;
            }
        }
        


        /// <summary>
        /// 判断对象属性是否赋值。没有赋值返回true
        /// </summary>
        public bool IsNull
        {
            get
            {
                if (iD_initialized || name_initialized || iPAddress_initialized || macAddress_initialized || channelID_initialized)
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
            
            if (iPAddress_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "IPAddress", SqlDbType.NVarChar);
                n_Parameter.Value = this.IPAddress;
                n_Parameter.SourceColumn = "IPAddress";
                parametersList.Add(n_Parameter);
            }
            
            if (macAddress_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "MacAddress", SqlDbType.NVarChar);
                n_Parameter.Value = this.MacAddress;
                n_Parameter.SourceColumn = "MacAddress";
                parametersList.Add(n_Parameter);
            }
            
            if (channelID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ChannelID", SqlDbType.Int);
                n_Parameter.Value = this.ChannelID;
                n_Parameter.SourceColumn = "ChannelID";
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
                
                if (this.iPAddress_initialized)
                {
                    contentText += ", [IPAddress]=@" + headStr + "IPAddress ";
                }
                
                if (this.macAddress_initialized)
                {
                    contentText += ", [MacAddress]=@" + headStr + "MacAddress ";
                }
                
                if (this.channelID_initialized)
                {
                    contentText += ", [ChannelID]=@" + headStr + "ChannelID ";
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
                
                if (this.iPAddress_initialized)
                {
                    conditionStr += " AND [IPAddress]=@" + headStr + "IPAddress ";
                }
                
                if (this.macAddress_initialized)
                {
                    conditionStr += " AND [MacAddress]=@" + headStr + "MacAddress ";
                }
                
                if (this.channelID_initialized)
                {
                    conditionStr += " AND [ChannelID]=@" + headStr + "ChannelID ";
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
                
                if (this.iPAddress_initialized)
                {
                    contentText += ", [IPAddress] ";
                }
                
                if (this.macAddress_initialized)
                {
                    contentText += ", [MacAddress] ";
                }
                
                if (this.channelID_initialized)
                {
                    contentText += ", [ChannelID] ";
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
                
                if (this.iPAddress_initialized)
                {
                    contentText += ", @" + headStr + "IPAddress ";
                }
                
                if (this.macAddress_initialized)
                {
                    contentText += ", @" + headStr + "MacAddress ";
                }
                
                if (this.channelID_initialized)
                {
                    contentText += ", @" + headStr + "ChannelID ";
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
            string tableName = "Camera";
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
            
            this.iPAddress_initialized = true;
            
            this.macAddress_initialized = true;
            
            this.channelID_initialized = true;
            
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

            
            if(page.Request["iPAddress"] != null)
            {
                if (this.iPAddress_initialized)
                {
                    if(page.Request["iPAddress"] != "")
                    {
                        this.IPAddress = Convert.ToString(page.Request["iPAddress"]);
                    }
                    else
                    {
                        this.iPAddress_initialized = false;
                    }
                }
                else
                {
                    this.IPAddress = Convert.ToString(page.Request["iPAddress"]);
                }
            }

            
            if(page.Request["macAddress"] != null)
            {
                if (this.macAddress_initialized)
                {
                    if(page.Request["macAddress"] != "")
                    {
                        this.MacAddress = Convert.ToString(page.Request["macAddress"]);
                    }
                    else
                    {
                        this.macAddress_initialized = false;
                    }
                }
                else
                {
                    this.MacAddress = Convert.ToString(page.Request["macAddress"]);
                }
            }

            
            if(page.Request["channelID"] != null)
            {
                if (this.channelID_initialized)
                {
                    if(page.Request["channelID"] != "")
                    {
                        this.ChannelID = Convert.ToInt32(page.Request["channelID"]);
                    }
                    else
                    {
                        this.channelID_initialized = false;
                    }
                }
                else
                {
                    this.ChannelID = Convert.ToInt32(page.Request["channelID"]);
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