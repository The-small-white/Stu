/************************************************************

  Copyright (c) 2008，
  Author:               Date: 2019/7/27 9:51:26
  Description:    数据表SpeechSend对应的业务逻辑层
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
    /// 与SpeechSend数据表对应对象
    /// </summary>
    public class SpeechSend : IDateBuildTable
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
        
        private int m_charType;
        private bool charType_initialized = false;
        
        private string m_iP;
        private bool iP_initialized = false;
        
        private int m_port;
        private bool port_initialized = false;
        
        private string m_sendCode;
        private bool sendCode_initialized = false;
        
        private int m_protocol;
        private bool protocol_initialized = false;
        
        private int m_deviceID;
        private bool deviceID_initialized = false;
        
        private int m_speechID;
        private bool speechID_initialized = false;
        
        private string m_title;
        private bool title_initialized = false;
        
        private int m_addID;
        private bool addID_initialized = false;
        
        private DateTime m_addTime;
        private bool addTime_initialized = false;
        

        public SpeechSend()
        {
        }

        public SpeechSend(int iD, int charType, string iP, int port, string sendCode, int protocol, int deviceID, int speechID, string title, int addID, DateTime addTime)
        {
            
            this.ID = iD;
            
            this.CharType = charType;
            
            this.IP = iP;
            
            this.Port = port;
            
            this.SendCode = sendCode;
            
            this.Protocol = protocol;
            
            this.DeviceID = deviceID;
            
            this.SpeechID = speechID;
            
            this.Title = title;
            
            this.AddID = addID;
            
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

            
            if(CheckColumn(dr, "CharType"))
            {
                if (dr["CharType"] != null && dr["CharType"] != DBNull.Value)
                {
                    this.CharType = Convert.ToInt32(dr["CharType"]);
                }
            }

            
            if(CheckColumn(dr, "IP"))
            {
                if (dr["IP"] != null && dr["IP"] != DBNull.Value)
                {
                    this.IP = Convert.ToString(dr["IP"]);
                }
            }

            
            if(CheckColumn(dr, "Port"))
            {
                if (dr["Port"] != null && dr["Port"] != DBNull.Value)
                {
                    this.Port = Convert.ToInt32(dr["Port"]);
                }
            }

            
            if(CheckColumn(dr, "SendCode"))
            {
                if (dr["SendCode"] != null && dr["SendCode"] != DBNull.Value)
                {
                    this.SendCode = Convert.ToString(dr["SendCode"]);
                }
            }

            
            if(CheckColumn(dr, "Protocol"))
            {
                if (dr["Protocol"] != null && dr["Protocol"] != DBNull.Value)
                {
                    this.Protocol = Convert.ToInt32(dr["Protocol"]);
                }
            }

            
            if(CheckColumn(dr, "DeviceID"))
            {
                if (dr["DeviceID"] != null && dr["DeviceID"] != DBNull.Value)
                {
                    this.DeviceID = Convert.ToInt32(dr["DeviceID"]);
                }
            }

            
            if(CheckColumn(dr, "SpeechID"))
            {
                if (dr["SpeechID"] != null && dr["SpeechID"] != DBNull.Value)
                {
                    this.SpeechID = Convert.ToInt32(dr["SpeechID"]);
                }
            }

            
            if(CheckColumn(dr, "Title"))
            {
                if (dr["Title"] != null && dr["Title"] != DBNull.Value)
                {
                    this.Title = Convert.ToString(dr["Title"]);
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
        
        public int Port
        {
            get
            {
                return this.m_port;
            }
            set
            {
                port_initialized = true;
                this.m_port = value;
            }
        }
        
        public string SendCode
        {
            get
            {
                return this.m_sendCode;
            }
            set
            {
                sendCode_initialized = true;
                this.m_sendCode = value;
            }
        }
        
        public int Protocol
        {
            get
            {
                return this.m_protocol;
            }
            set
            {
                protocol_initialized = true;
                this.m_protocol = value;
            }
        }
        
        public int DeviceID
        {
            get
            {
                return this.m_deviceID;
            }
            set
            {
                deviceID_initialized = true;
                this.m_deviceID = value;
            }
        }
        
        public int SpeechID
        {
            get
            {
                return this.m_speechID;
            }
            set
            {
                speechID_initialized = true;
                this.m_speechID = value;
            }
        }
        
        public string Title
        {
            get
            {
                return this.m_title;
            }
            set
            {
                title_initialized = true;
                this.m_title = value;
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
        


        /// <summary>
        /// 判断对象属性是否赋值。没有赋值返回true
        /// </summary>
        public bool IsNull
        {
            get
            {
                if (iD_initialized || charType_initialized || iP_initialized || port_initialized || sendCode_initialized || protocol_initialized || deviceID_initialized || speechID_initialized || title_initialized || addID_initialized || addTime_initialized)
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
            
            if (charType_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "CharType", SqlDbType.Int);
                n_Parameter.Value = this.CharType;
                n_Parameter.SourceColumn = "CharType";
                parametersList.Add(n_Parameter);
            }
            
            if (iP_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "IP", SqlDbType.NVarChar);
                n_Parameter.Value = this.IP;
                n_Parameter.SourceColumn = "IP";
                parametersList.Add(n_Parameter);
            }
            
            if (port_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Port", SqlDbType.Int);
                n_Parameter.Value = this.Port;
                n_Parameter.SourceColumn = "Port";
                parametersList.Add(n_Parameter);
            }
            
            if (sendCode_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "SendCode", SqlDbType.NVarChar);
                n_Parameter.Value = this.SendCode;
                n_Parameter.SourceColumn = "SendCode";
                parametersList.Add(n_Parameter);
            }
            
            if (protocol_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Protocol", SqlDbType.Int);
                n_Parameter.Value = this.Protocol;
                n_Parameter.SourceColumn = "Protocol";
                parametersList.Add(n_Parameter);
            }
            
            if (deviceID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "DeviceID", SqlDbType.Int);
                n_Parameter.Value = this.DeviceID;
                n_Parameter.SourceColumn = "DeviceID";
                parametersList.Add(n_Parameter);
            }
            
            if (speechID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "SpeechID", SqlDbType.Int);
                n_Parameter.Value = this.SpeechID;
                n_Parameter.SourceColumn = "SpeechID";
                parametersList.Add(n_Parameter);
            }
            
            if (title_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Title", SqlDbType.NVarChar);
                n_Parameter.Value = this.Title;
                n_Parameter.SourceColumn = "Title";
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
                
                if (this.charType_initialized)
                {
                    contentText += ", [CharType]=@" + headStr + "CharType ";
                }
                
                if (this.iP_initialized)
                {
                    contentText += ", [IP]=@" + headStr + "IP ";
                }
                
                if (this.port_initialized)
                {
                    contentText += ", [Port]=@" + headStr + "Port ";
                }
                
                if (this.sendCode_initialized)
                {
                    contentText += ", [SendCode]=@" + headStr + "SendCode ";
                }
                
                if (this.protocol_initialized)
                {
                    contentText += ", [Protocol]=@" + headStr + "Protocol ";
                }
                
                if (this.deviceID_initialized)
                {
                    contentText += ", [DeviceID]=@" + headStr + "DeviceID ";
                }
                
                if (this.speechID_initialized)
                {
                    contentText += ", [SpeechID]=@" + headStr + "SpeechID ";
                }
                
                if (this.title_initialized)
                {
                    contentText += ", [Title]=@" + headStr + "Title ";
                }
                
                if (this.addID_initialized)
                {
                    contentText += ", [AddID]=@" + headStr + "AddID ";
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
                
                if (this.charType_initialized)
                {
                    conditionStr += " AND [CharType]=@" + headStr + "CharType ";
                }
                
                if (this.iP_initialized)
                {
                    conditionStr += " AND [IP]=@" + headStr + "IP ";
                }
                
                if (this.port_initialized)
                {
                    conditionStr += " AND [Port]=@" + headStr + "Port ";
                }
                
                if (this.sendCode_initialized)
                {
                    conditionStr += " AND [SendCode]=@" + headStr + "SendCode ";
                }
                
                if (this.protocol_initialized)
                {
                    conditionStr += " AND [Protocol]=@" + headStr + "Protocol ";
                }
                
                if (this.deviceID_initialized)
                {
                    conditionStr += " AND [DeviceID]=@" + headStr + "DeviceID ";
                }
                
                if (this.speechID_initialized)
                {
                    conditionStr += " AND [SpeechID]=@" + headStr + "SpeechID ";
                }
                
                if (this.title_initialized)
                {
                    conditionStr += " AND [Title]=@" + headStr + "Title ";
                }
                
                if (this.addID_initialized)
                {
                    conditionStr += " AND [AddID]=@" + headStr + "AddID ";
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
                
                if (this.charType_initialized)
                {
                    contentText += ", [CharType] ";
                }
                
                if (this.iP_initialized)
                {
                    contentText += ", [IP] ";
                }
                
                if (this.port_initialized)
                {
                    contentText += ", [Port] ";
                }
                
                if (this.sendCode_initialized)
                {
                    contentText += ", [SendCode] ";
                }
                
                if (this.protocol_initialized)
                {
                    contentText += ", [Protocol] ";
                }
                
                if (this.deviceID_initialized)
                {
                    contentText += ", [DeviceID] ";
                }
                
                if (this.speechID_initialized)
                {
                    contentText += ", [SpeechID] ";
                }
                
                if (this.title_initialized)
                {
                    contentText += ", [Title] ";
                }
                
                if (this.addID_initialized)
                {
                    contentText += ", [AddID] ";
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
                
                if (this.charType_initialized)
                {
                    contentText += ", @" + headStr + "CharType ";
                }
                
                if (this.iP_initialized)
                {
                    contentText += ", @" + headStr + "IP ";
                }
                
                if (this.port_initialized)
                {
                    contentText += ", @" + headStr + "Port ";
                }
                
                if (this.sendCode_initialized)
                {
                    contentText += ", @" + headStr + "SendCode ";
                }
                
                if (this.protocol_initialized)
                {
                    contentText += ", @" + headStr + "Protocol ";
                }
                
                if (this.deviceID_initialized)
                {
                    contentText += ", @" + headStr + "DeviceID ";
                }
                
                if (this.speechID_initialized)
                {
                    contentText += ", @" + headStr + "SpeechID ";
                }
                
                if (this.title_initialized)
                {
                    contentText += ", @" + headStr + "Title ";
                }
                
                if (this.addID_initialized)
                {
                    contentText += ", @" + headStr + "AddID ";
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
            string tableName = "SpeechSend";
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
            
            this.charType_initialized = true;
            
            this.iP_initialized = true;
            
            this.port_initialized = true;
            
            this.sendCode_initialized = true;
            
            this.protocol_initialized = true;
            
            this.deviceID_initialized = true;
            
            this.speechID_initialized = true;
            
            this.title_initialized = true;
            
            this.addID_initialized = true;
            
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

            
            if(page.Request["port"] != null)
            {
                if (this.port_initialized)
                {
                    if(page.Request["port"] != "")
                    {
                        this.Port = Convert.ToInt32(page.Request["port"]);
                    }
                    else
                    {
                        this.port_initialized = false;
                    }
                }
                else
                {
                    this.Port = Convert.ToInt32(page.Request["port"]);
                }
            }

            
            if(page.Request["sendCode"] != null)
            {
                if (this.sendCode_initialized)
                {
                    if(page.Request["sendCode"] != "")
                    {
                        this.SendCode = Convert.ToString(page.Request["sendCode"]);
                    }
                    else
                    {
                        this.sendCode_initialized = false;
                    }
                }
                else
                {
                    this.SendCode = Convert.ToString(page.Request["sendCode"]);
                }
            }

            
            if(page.Request["protocol"] != null)
            {
                if (this.protocol_initialized)
                {
                    if(page.Request["protocol"] != "")
                    {
                        this.Protocol = Convert.ToInt32(page.Request["protocol"]);
                    }
                    else
                    {
                        this.protocol_initialized = false;
                    }
                }
                else
                {
                    this.Protocol = Convert.ToInt32(page.Request["protocol"]);
                }
            }

            
            if(page.Request["deviceID"] != null)
            {
                if (this.deviceID_initialized)
                {
                    if(page.Request["deviceID"] != "")
                    {
                        this.DeviceID = Convert.ToInt32(page.Request["deviceID"]);
                    }
                    else
                    {
                        this.deviceID_initialized = false;
                    }
                }
                else
                {
                    this.DeviceID = Convert.ToInt32(page.Request["deviceID"]);
                }
            }

            
            if(page.Request["speechID"] != null)
            {
                if (this.speechID_initialized)
                {
                    if(page.Request["speechID"] != "")
                    {
                        this.SpeechID = Convert.ToInt32(page.Request["speechID"]);
                    }
                    else
                    {
                        this.speechID_initialized = false;
                    }
                }
                else
                {
                    this.SpeechID = Convert.ToInt32(page.Request["speechID"]);
                }
            }

            
            if(page.Request["title"] != null)
            {
                if (this.title_initialized)
                {
                    if(page.Request["title"] != "")
                    {
                        this.Title = Convert.ToString(page.Request["title"]);
                    }
                    else
                    {
                        this.title_initialized = false;
                    }
                }
                else
                {
                    this.Title = Convert.ToString(page.Request["title"]);
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