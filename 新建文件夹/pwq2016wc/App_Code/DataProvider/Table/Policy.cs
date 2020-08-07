/************************************************************

  Copyright (c) 2008，
  Author:               Date: 2018/10/23 上午11:14:05
  Description:    数据表Policy对应的业务逻辑层
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
    /// 与Policy数据表对应对象
    /// </summary>
    public class Policy : IDateBuildTable
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
        
        private string m_title;
        private bool title_initialized = false;
        
        private int m_type;
        private bool type_initialized = false;
        
        private string m_file;
        private bool file_initialized = false;
        
        private DateTime m_addSystemDate;
        private bool addSystemDate_initialized = false;
        
        private int m_orderID;
        private bool orderID_initialized = false;
        

        public Policy()
        {
        }

        public Policy(int iD, string title, int type, string file, DateTime addSystemDate, int orderID)
        {
            
            this.ID = iD;
            
            this.Title = title;
            
            this.Type = type;
            
            this.File = file;
            
            this.AddSystemDate = addSystemDate;
            
            this.OrderID = orderID;
            
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

            
            if(CheckColumn(dr, "Title"))
            {
                if (dr["Title"] != null && dr["Title"] != DBNull.Value)
                {
                    this.Title = Convert.ToString(dr["Title"]);
                }
            }

            
            if(CheckColumn(dr, "Type"))
            {
                if (dr["Type"] != null && dr["Type"] != DBNull.Value)
                {
                    this.Type = Convert.ToInt32(dr["Type"]);
                }
            }

            
            if(CheckColumn(dr, "File"))
            {
                if (dr["File"] != null && dr["File"] != DBNull.Value)
                {
                    this.File = Convert.ToString(dr["File"]);
                }
            }

            
            if(CheckColumn(dr, "AddSystemDate"))
            {
                if (dr["AddSystemDate"] != null && dr["AddSystemDate"] != DBNull.Value)
                {
                    this.AddSystemDate = Convert.ToDateTime(dr["AddSystemDate"]);
                }
            }

            
            if(CheckColumn(dr, "OrderID"))
            {
                if (dr["OrderID"] != null && dr["OrderID"] != DBNull.Value)
                {
                    this.OrderID = Convert.ToInt32(dr["OrderID"]);
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
        
        public int Type
        {
            get
            {
                return this.m_type;
            }
            set
            {
                type_initialized = true;
                this.m_type = value;
            }
        }
        
        public string File
        {
            get
            {
                return this.m_file;
            }
            set
            {
                file_initialized = true;
                this.m_file = value;
            }
        }
        
        public DateTime AddSystemDate
        {
            get
            {
                return this.m_addSystemDate;
            }
            set
            {
                addSystemDate_initialized = true;
                this.m_addSystemDate = value;
            }
        }
        
        public int OrderID
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
        


        /// <summary>
        /// 判断对象属性是否赋值。没有赋值返回true
        /// </summary>
        public bool IsNull
        {
            get
            {
                if (iD_initialized || title_initialized || type_initialized || file_initialized || addSystemDate_initialized || orderID_initialized)
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
            
            if (title_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Title", SqlDbType.NVarChar);
                n_Parameter.Value = this.Title;
                n_Parameter.SourceColumn = "Title";
                parametersList.Add(n_Parameter);
            }
            
            if (type_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Type", SqlDbType.Int);
                n_Parameter.Value = this.Type;
                n_Parameter.SourceColumn = "Type";
                parametersList.Add(n_Parameter);
            }
            
            if (file_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "File", SqlDbType.NVarChar);
                n_Parameter.Value = this.File;
                n_Parameter.SourceColumn = "File";
                parametersList.Add(n_Parameter);
            }
            
            if (addSystemDate_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "AddSystemDate", SqlDbType.DateTime);
                n_Parameter.Value = this.AddSystemDate;
                n_Parameter.SourceColumn = "AddSystemDate";
                parametersList.Add(n_Parameter);
            }
            
            if (orderID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "OrderID", SqlDbType.Int);
                n_Parameter.Value = this.OrderID;
                n_Parameter.SourceColumn = "OrderID";
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
                
                if (this.title_initialized)
                {
                    contentText += ", [Title]=@" + headStr + "Title ";
                }
                
                if (this.type_initialized)
                {
                    contentText += ", [Type]=@" + headStr + "Type ";
                }
                
                if (this.file_initialized)
                {
                    contentText += ", [File]=@" + headStr + "File ";
                }
                
                if (this.addSystemDate_initialized)
                {
                    contentText += ", [AddSystemDate]=@" + headStr + "AddSystemDate ";
                }
                
                if (this.orderID_initialized)
                {
                    contentText += ", [OrderID]=@" + headStr + "OrderID ";
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
                
                if (this.title_initialized)
                {
                    conditionStr += " AND [Title]=@" + headStr + "Title ";
                }
                
                if (this.type_initialized)
                {
                    conditionStr += " AND [Type]=@" + headStr + "Type ";
                }
                
                if (this.file_initialized)
                {
                    conditionStr += " AND [File]=@" + headStr + "File ";
                }
                
                if (this.addSystemDate_initialized)
                {
                    conditionStr += " AND [AddSystemDate]=@" + headStr + "AddSystemDate ";
                }
                
                if (this.orderID_initialized)
                {
                    conditionStr += " AND [OrderID]=@" + headStr + "OrderID ";
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
                
                if (this.title_initialized)
                {
                    contentText += ", [Title] ";
                }
                
                if (this.type_initialized)
                {
                    contentText += ", [Type] ";
                }
                
                if (this.file_initialized)
                {
                    contentText += ", [File] ";
                }
                
                if (this.addSystemDate_initialized)
                {
                    contentText += ", [AddSystemDate] ";
                }
                
                if (this.orderID_initialized)
                {
                    contentText += ", [OrderID] ";
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
                
                if (this.title_initialized)
                {
                    contentText += ", @" + headStr + "Title ";
                }
                
                if (this.type_initialized)
                {
                    contentText += ", @" + headStr + "Type ";
                }
                
                if (this.file_initialized)
                {
                    contentText += ", @" + headStr + "File ";
                }
                
                if (this.addSystemDate_initialized)
                {
                    contentText += ", @" + headStr + "AddSystemDate ";
                }
                
                if (this.orderID_initialized)
                {
                    contentText += ", @" + headStr + "OrderID ";
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
            string tableName = "Policy";
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
            
            this.title_initialized = true;
            
            this.type_initialized = true;
            
            this.file_initialized = true;
            
            this.addSystemDate_initialized = true;
            
            this.orderID_initialized = true;
            
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

            
            if(page.Request["type"] != null)
            {
                if (this.type_initialized)
                {
                    if(page.Request["type"] != "")
                    {
                        this.Type = Convert.ToInt32(page.Request["type"]);
                    }
                    else
                    {
                        this.type_initialized = false;
                    }
                }
                else
                {
                    this.Type = Convert.ToInt32(page.Request["type"]);
                }
            }

            
            if(page.Request["file"] != null)
            {
                if (this.file_initialized)
                {
                    if(page.Request["file"] != "")
                    {
                        this.File = Convert.ToString(page.Request["file"]);
                    }
                    else
                    {
                        this.file_initialized = false;
                    }
                }
                else
                {
                    this.File = Convert.ToString(page.Request["file"]);
                }
            }

            
            if(page.Request["addSystemDate"] != null)
            {
                if (this.addSystemDate_initialized)
                {
                    if(page.Request["addSystemDate"] != "")
                    {
                        this.AddSystemDate = Convert.ToDateTime(page.Request["addSystemDate"]);
                    }
                    else
                    {
                        this.addSystemDate_initialized = false;
                    }
                }
                else
                {
                    this.AddSystemDate = Convert.ToDateTime(page.Request["addSystemDate"]);
                }
            }

            
            if(page.Request["orderID"] != null)
            {
                if (this.orderID_initialized)
                {
                    if(page.Request["orderID"] != "")
                    {
                        this.OrderID = Convert.ToInt32(page.Request["orderID"]);
                    }
                    else
                    {
                        this.orderID_initialized = false;
                    }
                }
                else
                {
                    this.OrderID = Convert.ToInt32(page.Request["orderID"]);
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