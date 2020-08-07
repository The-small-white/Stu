/************************************************************

  Copyright (c) 2008，
  Author:               Date: 2019/7/16 10:17:48
  Description:    数据表Exhibition对应的业务逻辑层
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
    /// 与Exhibition数据表对应对象
    /// </summary>
    public class Exhibition : IDateBuildTable
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
        
        private int m_depth;
        private bool depth_initialized = false;
        
        private int m_parentID;
        private bool parentID_initialized = false;
        
        private Boolean m_child;
        private bool child_initialized = false;
        
        private string m_path;
        private bool path_initialized = false;
        
        private int m_rootID;
        private bool rootID_initialized = false;
        
        private string m_namePath;
        private bool namePath_initialized = false;
        
        private string m_brief;
        private bool brief_initialized = false;
        
        private int m_addID;
        private bool addID_initialized = false;
        
        private DateTime m_addTime;
        private bool addTime_initialized = false;
        

        public Exhibition()
        {
        }

        public Exhibition(int iD, string name, int depth, int parentID, Boolean child, string path, int rootID, string namePath, string brief, int addID, DateTime addTime)
        {
            
            this.ID = iD;
            
            this.Name = name;
            
            this.Depth = depth;
            
            this.ParentID = parentID;
            
            this.Child = child;
            
            this.Path = path;
            
            this.RootID = rootID;
            
            this.NamePath = namePath;
            
            this.Brief = brief;
            
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

            
            if(CheckColumn(dr, "Name"))
            {
                if (dr["Name"] != null && dr["Name"] != DBNull.Value)
                {
                    this.Name = Convert.ToString(dr["Name"]);
                }
            }

            
            if(CheckColumn(dr, "Depth"))
            {
                if (dr["Depth"] != null && dr["Depth"] != DBNull.Value)
                {
                    this.Depth = Convert.ToInt32(dr["Depth"]);
                }
            }

            
            if(CheckColumn(dr, "ParentID"))
            {
                if (dr["ParentID"] != null && dr["ParentID"] != DBNull.Value)
                {
                    this.ParentID = Convert.ToInt32(dr["ParentID"]);
                }
            }

            
            if(CheckColumn(dr, "Child"))
            {
                if (dr["Child"] != null && dr["Child"] != DBNull.Value)
                {
                    this.Child = Convert.ToBoolean(dr["Child"]);
                }
            }

            
            if(CheckColumn(dr, "Path"))
            {
                if (dr["Path"] != null && dr["Path"] != DBNull.Value)
                {
                    this.Path = Convert.ToString(dr["Path"]);
                }
            }

            
            if(CheckColumn(dr, "RootID"))
            {
                if (dr["RootID"] != null && dr["RootID"] != DBNull.Value)
                {
                    this.RootID = Convert.ToInt32(dr["RootID"]);
                }
            }

            
            if(CheckColumn(dr, "NamePath"))
            {
                if (dr["NamePath"] != null && dr["NamePath"] != DBNull.Value)
                {
                    this.NamePath = Convert.ToString(dr["NamePath"]);
                }
            }

            
            if(CheckColumn(dr, "Brief"))
            {
                if (dr["Brief"] != null && dr["Brief"] != DBNull.Value)
                {
                    this.Brief = Convert.ToString(dr["Brief"]);
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
        
        public int Depth
        {
            get
            {
                return this.m_depth;
            }
            set
            {
                depth_initialized = true;
                this.m_depth = value;
            }
        }
        
        public int ParentID
        {
            get
            {
                return this.m_parentID;
            }
            set
            {
                parentID_initialized = true;
                this.m_parentID = value;
            }
        }
        
        public Boolean Child
        {
            get
            {
                return this.m_child;
            }
            set
            {
                child_initialized = true;
                this.m_child = value;
            }
        }
        
        public string Path
        {
            get
            {
                return this.m_path;
            }
            set
            {
                path_initialized = true;
                this.m_path = value;
            }
        }
        
        public int RootID
        {
            get
            {
                return this.m_rootID;
            }
            set
            {
                rootID_initialized = true;
                this.m_rootID = value;
            }
        }
        
        public string NamePath
        {
            get
            {
                return this.m_namePath;
            }
            set
            {
                namePath_initialized = true;
                this.m_namePath = value;
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
                if (iD_initialized || name_initialized || depth_initialized || parentID_initialized || child_initialized || path_initialized || rootID_initialized || namePath_initialized || brief_initialized || addID_initialized || addTime_initialized)
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
            
            if (depth_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Depth", SqlDbType.Int);
                n_Parameter.Value = this.Depth;
                n_Parameter.SourceColumn = "Depth";
                parametersList.Add(n_Parameter);
            }
            
            if (parentID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ParentID", SqlDbType.Int);
                n_Parameter.Value = this.ParentID;
                n_Parameter.SourceColumn = "ParentID";
                parametersList.Add(n_Parameter);
            }
            
            if (child_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Child", SqlDbType.Bit);
                n_Parameter.Value = this.Child;
                n_Parameter.SourceColumn = "Child";
                parametersList.Add(n_Parameter);
            }
            
            if (path_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Path", SqlDbType.NVarChar);
                n_Parameter.Value = this.Path;
                n_Parameter.SourceColumn = "Path";
                parametersList.Add(n_Parameter);
            }
            
            if (rootID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "RootID", SqlDbType.Int);
                n_Parameter.Value = this.RootID;
                n_Parameter.SourceColumn = "RootID";
                parametersList.Add(n_Parameter);
            }
            
            if (namePath_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "NamePath", SqlDbType.NVarChar);
                n_Parameter.Value = this.NamePath;
                n_Parameter.SourceColumn = "NamePath";
                parametersList.Add(n_Parameter);
            }
            
            if (brief_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Brief", SqlDbType.NVarChar);
                n_Parameter.Value = this.Brief;
                n_Parameter.SourceColumn = "Brief";
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
                
                if (this.name_initialized)
                {
                    contentText += ", [Name]=@" + headStr + "Name ";
                }
                
                if (this.depth_initialized)
                {
                    contentText += ", [Depth]=@" + headStr + "Depth ";
                }
                
                if (this.parentID_initialized)
                {
                    contentText += ", [ParentID]=@" + headStr + "ParentID ";
                }
                
                if (this.child_initialized)
                {
                    contentText += ", [Child]=@" + headStr + "Child ";
                }
                
                if (this.path_initialized)
                {
                    contentText += ", [Path]=@" + headStr + "Path ";
                }
                
                if (this.rootID_initialized)
                {
                    contentText += ", [RootID]=@" + headStr + "RootID ";
                }
                
                if (this.namePath_initialized)
                {
                    contentText += ", [NamePath]=@" + headStr + "NamePath ";
                }
                
                if (this.brief_initialized)
                {
                    contentText += ", [Brief]=@" + headStr + "Brief ";
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
                
                if (this.name_initialized)
                {
                    conditionStr += " AND [Name]=@" + headStr + "Name ";
                }
                
                if (this.depth_initialized)
                {
                    conditionStr += " AND [Depth]=@" + headStr + "Depth ";
                }
                
                if (this.parentID_initialized)
                {
                    conditionStr += " AND [ParentID]=@" + headStr + "ParentID ";
                }
                
                if (this.child_initialized)
                {
                    conditionStr += " AND [Child]=@" + headStr + "Child ";
                }
                
                if (this.path_initialized)
                {
                    conditionStr += " AND [Path]=@" + headStr + "Path ";
                }
                
                if (this.rootID_initialized)
                {
                    conditionStr += " AND [RootID]=@" + headStr + "RootID ";
                }
                
                if (this.namePath_initialized)
                {
                    conditionStr += " AND [NamePath]=@" + headStr + "NamePath ";
                }
                
                if (this.brief_initialized)
                {
                    conditionStr += " AND [Brief]=@" + headStr + "Brief ";
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
                
                if (this.name_initialized)
                {
                    contentText += ", [Name] ";
                }
                
                if (this.depth_initialized)
                {
                    contentText += ", [Depth] ";
                }
                
                if (this.parentID_initialized)
                {
                    contentText += ", [ParentID] ";
                }
                
                if (this.child_initialized)
                {
                    contentText += ", [Child] ";
                }
                
                if (this.path_initialized)
                {
                    contentText += ", [Path] ";
                }
                
                if (this.rootID_initialized)
                {
                    contentText += ", [RootID] ";
                }
                
                if (this.namePath_initialized)
                {
                    contentText += ", [NamePath] ";
                }
                
                if (this.brief_initialized)
                {
                    contentText += ", [Brief] ";
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
                
                if (this.name_initialized)
                {
                    contentText += ", @" + headStr + "Name ";
                }
                
                if (this.depth_initialized)
                {
                    contentText += ", @" + headStr + "Depth ";
                }
                
                if (this.parentID_initialized)
                {
                    contentText += ", @" + headStr + "ParentID ";
                }
                
                if (this.child_initialized)
                {
                    contentText += ", @" + headStr + "Child ";
                }
                
                if (this.path_initialized)
                {
                    contentText += ", @" + headStr + "Path ";
                }
                
                if (this.rootID_initialized)
                {
                    contentText += ", @" + headStr + "RootID ";
                }
                
                if (this.namePath_initialized)
                {
                    contentText += ", @" + headStr + "NamePath ";
                }
                
                if (this.brief_initialized)
                {
                    contentText += ", @" + headStr + "Brief ";
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
            string tableName = "Exhibition";
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
            
            this.depth_initialized = true;
            
            this.parentID_initialized = true;
            
            this.child_initialized = true;
            
            this.path_initialized = true;
            
            this.rootID_initialized = true;
            
            this.namePath_initialized = true;
            
            this.brief_initialized = true;
            
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

            
            if(page.Request["depth"] != null)
            {
                if (this.depth_initialized)
                {
                    if(page.Request["depth"] != "")
                    {
                        this.Depth = Convert.ToInt32(page.Request["depth"]);
                    }
                    else
                    {
                        this.depth_initialized = false;
                    }
                }
                else
                {
                    this.Depth = Convert.ToInt32(page.Request["depth"]);
                }
            }

            
            if(page.Request["parentID"] != null)
            {
                if (this.parentID_initialized)
                {
                    if(page.Request["parentID"] != "")
                    {
                        this.ParentID = Convert.ToInt32(page.Request["parentID"]);
                    }
                    else
                    {
                        this.parentID_initialized = false;
                    }
                }
                else
                {
                    this.ParentID = Convert.ToInt32(page.Request["parentID"]);
                }
            }

            
            if(page.Request["child"] != null)
            {
                if (this.child_initialized)
                {
                    if(page.Request["child"] != "")
                    {
                        this.Child = Convert.ToBoolean(page.Request["child"]);
                    }
                    else
                    {
                        this.child_initialized = false;
                    }
                }
                else
                {
                    this.Child = Convert.ToBoolean(page.Request["child"]);
                }
            }

            
            if(page.Request["path"] != null)
            {
                if (this.path_initialized)
                {
                    if(page.Request["path"] != "")
                    {
                        this.Path = Convert.ToString(page.Request["path"]);
                    }
                    else
                    {
                        this.path_initialized = false;
                    }
                }
                else
                {
                    this.Path = Convert.ToString(page.Request["path"]);
                }
            }

            
            if(page.Request["rootID"] != null)
            {
                if (this.rootID_initialized)
                {
                    if(page.Request["rootID"] != "")
                    {
                        this.RootID = Convert.ToInt32(page.Request["rootID"]);
                    }
                    else
                    {
                        this.rootID_initialized = false;
                    }
                }
                else
                {
                    this.RootID = Convert.ToInt32(page.Request["rootID"]);
                }
            }

            
            if(page.Request["namePath"] != null)
            {
                if (this.namePath_initialized)
                {
                    if(page.Request["namePath"] != "")
                    {
                        this.NamePath = Convert.ToString(page.Request["namePath"]);
                    }
                    else
                    {
                        this.namePath_initialized = false;
                    }
                }
                else
                {
                    this.NamePath = Convert.ToString(page.Request["namePath"]);
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