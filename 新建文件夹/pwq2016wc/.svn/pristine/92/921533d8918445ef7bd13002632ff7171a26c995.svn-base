/************************************************************

  Copyright (c) 2008，
  Author:               Date: 2019/7/30 13:35:50
  Description:    数据表Mailbox对应的业务逻辑层
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
    /// 与Mailbox数据表对应对象
    /// </summary>
    public class Mailbox : IDateBuildTable
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
        
        private int m_sendID;
        private bool sendID_initialized = false;
        
        private string m_msg;
        private bool msg_initialized = false;
        
        private int m_states;
        private bool states_initialized = false;
        
        private int m_receiveID;
        private bool receiveID_initialized = false;
        
        private string m_sendName;
        private bool sendName_initialized = false;
        
        private DateTime m_addTime;
        private bool addTime_initialized = false;
        

        public Mailbox()
        {
        }

        public Mailbox(int iD, int sendID, string msg, int states, int receiveID, string sendName, DateTime addTime)
        {
            
            this.ID = iD;
            
            this.SendID = sendID;
            
            this.Msg = msg;
            
            this.States = states;
            
            this.ReceiveID = receiveID;
            
            this.SendName = sendName;
            
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

            
            if(CheckColumn(dr, "SendID"))
            {
                if (dr["SendID"] != null && dr["SendID"] != DBNull.Value)
                {
                    this.SendID = Convert.ToInt32(dr["SendID"]);
                }
            }

            
            if(CheckColumn(dr, "Msg"))
            {
                if (dr["Msg"] != null && dr["Msg"] != DBNull.Value)
                {
                    this.Msg = Convert.ToString(dr["Msg"]);
                }
            }

            
            if(CheckColumn(dr, "States"))
            {
                if (dr["States"] != null && dr["States"] != DBNull.Value)
                {
                    this.States = Convert.ToInt32(dr["States"]);
                }
            }

            
            if(CheckColumn(dr, "ReceiveID"))
            {
                if (dr["ReceiveID"] != null && dr["ReceiveID"] != DBNull.Value)
                {
                    this.ReceiveID = Convert.ToInt32(dr["ReceiveID"]);
                }
            }

            
            if(CheckColumn(dr, "SendName"))
            {
                if (dr["SendName"] != null && dr["SendName"] != DBNull.Value)
                {
                    this.SendName = Convert.ToString(dr["SendName"]);
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
        
        public int SendID
        {
            get
            {
                return this.m_sendID;
            }
            set
            {
                sendID_initialized = true;
                this.m_sendID = value;
            }
        }
        
        public string Msg
        {
            get
            {
                return this.m_msg;
            }
            set
            {
                msg_initialized = true;
                this.m_msg = value;
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
        
        public int ReceiveID
        {
            get
            {
                return this.m_receiveID;
            }
            set
            {
                receiveID_initialized = true;
                this.m_receiveID = value;
            }
        }
        
        public string SendName
        {
            get
            {
                return this.m_sendName;
            }
            set
            {
                sendName_initialized = true;
                this.m_sendName = value;
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
                if (iD_initialized || sendID_initialized || msg_initialized || states_initialized || receiveID_initialized || sendName_initialized || addTime_initialized)
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
            
            if (sendID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "SendID", SqlDbType.Int);
                n_Parameter.Value = this.SendID;
                n_Parameter.SourceColumn = "SendID";
                parametersList.Add(n_Parameter);
            }
            
            if (msg_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Msg", SqlDbType.NVarChar);
                n_Parameter.Value = this.Msg;
                n_Parameter.SourceColumn = "Msg";
                parametersList.Add(n_Parameter);
            }
            
            if (states_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "States", SqlDbType.Int);
                n_Parameter.Value = this.States;
                n_Parameter.SourceColumn = "States";
                parametersList.Add(n_Parameter);
            }
            
            if (receiveID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ReceiveID", SqlDbType.Int);
                n_Parameter.Value = this.ReceiveID;
                n_Parameter.SourceColumn = "ReceiveID";
                parametersList.Add(n_Parameter);
            }
            
            if (sendName_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "SendName", SqlDbType.NVarChar);
                n_Parameter.Value = this.SendName;
                n_Parameter.SourceColumn = "SendName";
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
                
                if (this.sendID_initialized)
                {
                    contentText += ", [SendID]=@" + headStr + "SendID ";
                }
                
                if (this.msg_initialized)
                {
                    contentText += ", [Msg]=@" + headStr + "Msg ";
                }
                
                if (this.states_initialized)
                {
                    contentText += ", [States]=@" + headStr + "States ";
                }
                
                if (this.receiveID_initialized)
                {
                    contentText += ", [ReceiveID]=@" + headStr + "ReceiveID ";
                }
                
                if (this.sendName_initialized)
                {
                    contentText += ", [SendName]=@" + headStr + "SendName ";
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
                
                if (this.sendID_initialized)
                {
                    conditionStr += " AND [SendID]=@" + headStr + "SendID ";
                }
                
                if (this.msg_initialized)
                {
                    conditionStr += " AND [Msg]=@" + headStr + "Msg ";
                }
                
                if (this.states_initialized)
                {
                    conditionStr += " AND [States]=@" + headStr + "States ";
                }
                
                if (this.receiveID_initialized)
                {
                    conditionStr += " AND [ReceiveID]=@" + headStr + "ReceiveID ";
                }
                
                if (this.sendName_initialized)
                {
                    conditionStr += " AND [SendName]=@" + headStr + "SendName ";
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
                
                if (this.sendID_initialized)
                {
                    contentText += ", [SendID] ";
                }
                
                if (this.msg_initialized)
                {
                    contentText += ", [Msg] ";
                }
                
                if (this.states_initialized)
                {
                    contentText += ", [States] ";
                }
                
                if (this.receiveID_initialized)
                {
                    contentText += ", [ReceiveID] ";
                }
                
                if (this.sendName_initialized)
                {
                    contentText += ", [SendName] ";
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
                
                if (this.sendID_initialized)
                {
                    contentText += ", @" + headStr + "SendID ";
                }
                
                if (this.msg_initialized)
                {
                    contentText += ", @" + headStr + "Msg ";
                }
                
                if (this.states_initialized)
                {
                    contentText += ", @" + headStr + "States ";
                }
                
                if (this.receiveID_initialized)
                {
                    contentText += ", @" + headStr + "ReceiveID ";
                }
                
                if (this.sendName_initialized)
                {
                    contentText += ", @" + headStr + "SendName ";
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
            string tableName = "Mailbox";
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
            
            this.sendID_initialized = true;
            
            this.msg_initialized = true;
            
            this.states_initialized = true;
            
            this.receiveID_initialized = true;
            
            this.sendName_initialized = true;
            
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

            
            if(page.Request["sendID"] != null)
            {
                if (this.sendID_initialized)
                {
                    if(page.Request["sendID"] != "")
                    {
                        this.SendID = Convert.ToInt32(page.Request["sendID"]);
                    }
                    else
                    {
                        this.sendID_initialized = false;
                    }
                }
                else
                {
                    this.SendID = Convert.ToInt32(page.Request["sendID"]);
                }
            }

            
            if(page.Request["msg"] != null)
            {
                if (this.msg_initialized)
                {
                    if(page.Request["msg"] != "")
                    {
                        this.Msg = Convert.ToString(page.Request["msg"]);
                    }
                    else
                    {
                        this.msg_initialized = false;
                    }
                }
                else
                {
                    this.Msg = Convert.ToString(page.Request["msg"]);
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

            
            if(page.Request["receiveID"] != null)
            {
                if (this.receiveID_initialized)
                {
                    if(page.Request["receiveID"] != "")
                    {
                        this.ReceiveID = Convert.ToInt32(page.Request["receiveID"]);
                    }
                    else
                    {
                        this.receiveID_initialized = false;
                    }
                }
                else
                {
                    this.ReceiveID = Convert.ToInt32(page.Request["receiveID"]);
                }
            }

            
            if(page.Request["sendName"] != null)
            {
                if (this.sendName_initialized)
                {
                    if(page.Request["sendName"] != "")
                    {
                        this.SendName = Convert.ToString(page.Request["sendName"]);
                    }
                    else
                    {
                        this.sendName_initialized = false;
                    }
                }
                else
                {
                    this.SendName = Convert.ToString(page.Request["sendName"]);
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