/************************************************************

  Copyright (c) 2008，
  Author:               Date: 2019/7/22 15:02:03
  Description:    数据表AnnNews对应的业务逻辑层
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
    /// 与AnnNews数据表对应对象
    /// </summary>
    public class AnnNews : IDateBuildTable
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
        
        private string m_author;
        private bool author_initialized = false;
        
        private string m_contents;
        private bool contents_initialized = false;
        
        private string m_brief;
        private bool brief_initialized = false;
        
        private int m_states;
        private bool states_initialized = false;
        
        private Boolean m_isHot;
        private bool isHot_initialized = false;
        
        private int m_exhibitionID;
        private bool exhibitionID_initialized = false;
        
        private Boolean m_isZD;
        private bool isZD_initialized = false;
        
        private int m_addID;
        private bool addID_initialized = false;
        
        private DateTime m_addTime;
        private bool addTime_initialized = false;
        
        private string m_addName;
        private bool addName_initialized = false;
        

        public AnnNews()
        {
        }

        public AnnNews(int iD, string title, string author, string contents, string brief, int states, Boolean isHot, int exhibitionID, Boolean isZD, int addID, DateTime addTime, string addName)
        {
            
            this.ID = iD;
            
            this.Title = title;
            
            this.Author = author;
            
            this.Contents = contents;
            
            this.Brief = brief;
            
            this.States = states;
            
            this.IsHot = isHot;
            
            this.ExhibitionID = exhibitionID;
            
            this.IsZD = isZD;
            
            this.AddID = addID;
            
            this.AddTime = addTime;
            
            this.AddName = addName;
            
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

            
            if(CheckColumn(dr, "Author"))
            {
                if (dr["Author"] != null && dr["Author"] != DBNull.Value)
                {
                    this.Author = Convert.ToString(dr["Author"]);
                }
            }

            
            if(CheckColumn(dr, "Contents"))
            {
                if (dr["Contents"] != null && dr["Contents"] != DBNull.Value)
                {
                    this.Contents = Convert.ToString(dr["Contents"]);
                }
            }

            
            if(CheckColumn(dr, "Brief"))
            {
                if (dr["Brief"] != null && dr["Brief"] != DBNull.Value)
                {
                    this.Brief = Convert.ToString(dr["Brief"]);
                }
            }

            
            if(CheckColumn(dr, "States"))
            {
                if (dr["States"] != null && dr["States"] != DBNull.Value)
                {
                    this.States = Convert.ToInt32(dr["States"]);
                }
            }

            
            if(CheckColumn(dr, "IsHot"))
            {
                if (dr["IsHot"] != null && dr["IsHot"] != DBNull.Value)
                {
                    this.IsHot = Convert.ToBoolean(dr["IsHot"]);
                }
            }

            
            if(CheckColumn(dr, "ExhibitionID"))
            {
                if (dr["ExhibitionID"] != null && dr["ExhibitionID"] != DBNull.Value)
                {
                    this.ExhibitionID = Convert.ToInt32(dr["ExhibitionID"]);
                }
            }

            
            if(CheckColumn(dr, "IsZD"))
            {
                if (dr["IsZD"] != null && dr["IsZD"] != DBNull.Value)
                {
                    this.IsZD = Convert.ToBoolean(dr["IsZD"]);
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

            
            if(CheckColumn(dr, "AddName"))
            {
                if (dr["AddName"] != null && dr["AddName"] != DBNull.Value)
                {
                    this.AddName = Convert.ToString(dr["AddName"]);
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
        
        public string Author
        {
            get
            {
                return this.m_author;
            }
            set
            {
                author_initialized = true;
                this.m_author = value;
            }
        }
        
        public string Contents
        {
            get
            {
                return this.m_contents;
            }
            set
            {
                contents_initialized = true;
                this.m_contents = value;
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
        
        public Boolean IsHot
        {
            get
            {
                return this.m_isHot;
            }
            set
            {
                isHot_initialized = true;
                this.m_isHot = value;
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
        
        public Boolean IsZD
        {
            get
            {
                return this.m_isZD;
            }
            set
            {
                isZD_initialized = true;
                this.m_isZD = value;
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
        
        public string AddName
        {
            get
            {
                return this.m_addName;
            }
            set
            {
                addName_initialized = true;
                this.m_addName = value;
            }
        }
        


        /// <summary>
        /// 判断对象属性是否赋值。没有赋值返回true
        /// </summary>
        public bool IsNull
        {
            get
            {
                if (iD_initialized || title_initialized || author_initialized || contents_initialized || brief_initialized || states_initialized || isHot_initialized || exhibitionID_initialized || isZD_initialized || addID_initialized || addTime_initialized || addName_initialized)
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
            
            if (author_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Author", SqlDbType.NVarChar);
                n_Parameter.Value = this.Author;
                n_Parameter.SourceColumn = "Author";
                parametersList.Add(n_Parameter);
            }
            
            if (contents_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Contents", SqlDbType.NVarChar);
                n_Parameter.Value = this.Contents;
                n_Parameter.SourceColumn = "Contents";
                parametersList.Add(n_Parameter);
            }
            
            if (brief_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Brief", SqlDbType.NVarChar);
                n_Parameter.Value = this.Brief;
                n_Parameter.SourceColumn = "Brief";
                parametersList.Add(n_Parameter);
            }
            
            if (states_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "States", SqlDbType.Int);
                n_Parameter.Value = this.States;
                n_Parameter.SourceColumn = "States";
                parametersList.Add(n_Parameter);
            }
            
            if (isHot_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "IsHot", SqlDbType.Bit);
                n_Parameter.Value = this.IsHot;
                n_Parameter.SourceColumn = "IsHot";
                parametersList.Add(n_Parameter);
            }
            
            if (exhibitionID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ExhibitionID", SqlDbType.Int);
                n_Parameter.Value = this.ExhibitionID;
                n_Parameter.SourceColumn = "ExhibitionID";
                parametersList.Add(n_Parameter);
            }
            
            if (isZD_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "IsZD", SqlDbType.Bit);
                n_Parameter.Value = this.IsZD;
                n_Parameter.SourceColumn = "IsZD";
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
            
            if (addName_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "AddName", SqlDbType.NVarChar);
                n_Parameter.Value = this.AddName;
                n_Parameter.SourceColumn = "AddName";
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
                
                if (this.author_initialized)
                {
                    contentText += ", [Author]=@" + headStr + "Author ";
                }
                
                if (this.contents_initialized)
                {
                    contentText += ", [Contents]=@" + headStr + "Contents ";
                }
                
                if (this.brief_initialized)
                {
                    contentText += ", [Brief]=@" + headStr + "Brief ";
                }
                
                if (this.states_initialized)
                {
                    contentText += ", [States]=@" + headStr + "States ";
                }
                
                if (this.isHot_initialized)
                {
                    contentText += ", [IsHot]=@" + headStr + "IsHot ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    contentText += ", [ExhibitionID]=@" + headStr + "ExhibitionID ";
                }
                
                if (this.isZD_initialized)
                {
                    contentText += ", [IsZD]=@" + headStr + "IsZD ";
                }
                
                if (this.addID_initialized)
                {
                    contentText += ", [AddID]=@" + headStr + "AddID ";
                }
                
                if (this.addTime_initialized)
                {
                    contentText += ", [AddTime]=@" + headStr + "AddTime ";
                }
                
                if (this.addName_initialized)
                {
                    contentText += ", [AddName]=@" + headStr + "AddName ";
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
                
                if (this.author_initialized)
                {
                    conditionStr += " AND [Author]=@" + headStr + "Author ";
                }
                
                if (this.contents_initialized)
                {
                    conditionStr += " AND [Contents]=@" + headStr + "Contents ";
                }
                
                if (this.brief_initialized)
                {
                    conditionStr += " AND [Brief]=@" + headStr + "Brief ";
                }
                
                if (this.states_initialized)
                {
                    conditionStr += " AND [States]=@" + headStr + "States ";
                }
                
                if (this.isHot_initialized)
                {
                    conditionStr += " AND [IsHot]=@" + headStr + "IsHot ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    conditionStr += " AND [ExhibitionID]=@" + headStr + "ExhibitionID ";
                }
                
                if (this.isZD_initialized)
                {
                    conditionStr += " AND [IsZD]=@" + headStr + "IsZD ";
                }
                
                if (this.addID_initialized)
                {
                    conditionStr += " AND [AddID]=@" + headStr + "AddID ";
                }
                
                if (this.addTime_initialized)
                {
                    conditionStr += " AND [AddTime]=@" + headStr + "AddTime ";
                }
                
                if (this.addName_initialized)
                {
                    conditionStr += " AND [AddName]=@" + headStr + "AddName ";
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
                
                if (this.author_initialized)
                {
                    contentText += ", [Author] ";
                }
                
                if (this.contents_initialized)
                {
                    contentText += ", [Contents] ";
                }
                
                if (this.brief_initialized)
                {
                    contentText += ", [Brief] ";
                }
                
                if (this.states_initialized)
                {
                    contentText += ", [States] ";
                }
                
                if (this.isHot_initialized)
                {
                    contentText += ", [IsHot] ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    contentText += ", [ExhibitionID] ";
                }
                
                if (this.isZD_initialized)
                {
                    contentText += ", [IsZD] ";
                }
                
                if (this.addID_initialized)
                {
                    contentText += ", [AddID] ";
                }
                
                if (this.addTime_initialized)
                {
                    contentText += ", [AddTime] ";
                }
                
                if (this.addName_initialized)
                {
                    contentText += ", [AddName] ";
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
                
                if (this.author_initialized)
                {
                    contentText += ", @" + headStr + "Author ";
                }
                
                if (this.contents_initialized)
                {
                    contentText += ", @" + headStr + "Contents ";
                }
                
                if (this.brief_initialized)
                {
                    contentText += ", @" + headStr + "Brief ";
                }
                
                if (this.states_initialized)
                {
                    contentText += ", @" + headStr + "States ";
                }
                
                if (this.isHot_initialized)
                {
                    contentText += ", @" + headStr + "IsHot ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    contentText += ", @" + headStr + "ExhibitionID ";
                }
                
                if (this.isZD_initialized)
                {
                    contentText += ", @" + headStr + "IsZD ";
                }
                
                if (this.addID_initialized)
                {
                    contentText += ", @" + headStr + "AddID ";
                }
                
                if (this.addTime_initialized)
                {
                    contentText += ", @" + headStr + "AddTime ";
                }
                
                if (this.addName_initialized)
                {
                    contentText += ", @" + headStr + "AddName ";
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
            string tableName = "AnnNews";
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
            
            this.author_initialized = true;
            
            this.contents_initialized = true;
            
            this.brief_initialized = true;
            
            this.states_initialized = true;
            
            this.isHot_initialized = true;
            
            this.exhibitionID_initialized = true;
            
            this.isZD_initialized = true;
            
            this.addID_initialized = true;
            
            this.addTime_initialized = true;
            
            this.addName_initialized = true;
            
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

            
            if(page.Request["author"] != null)
            {
                if (this.author_initialized)
                {
                    if(page.Request["author"] != "")
                    {
                        this.Author = Convert.ToString(page.Request["author"]);
                    }
                    else
                    {
                        this.author_initialized = false;
                    }
                }
                else
                {
                    this.Author = Convert.ToString(page.Request["author"]);
                }
            }

            
            if(page.Request["contents"] != null)
            {
                if (this.contents_initialized)
                {
                    if(page.Request["contents"] != "")
                    {
                        this.Contents = Convert.ToString(page.Request["contents"]);
                    }
                    else
                    {
                        this.contents_initialized = false;
                    }
                }
                else
                {
                    this.Contents = Convert.ToString(page.Request["contents"]);
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

            
            if(page.Request["isHot"] != null)
            {
                if (this.isHot_initialized)
                {
                    if(page.Request["isHot"] != "")
                    {
                        this.IsHot = Convert.ToBoolean(page.Request["isHot"]);
                    }
                    else
                    {
                        this.isHot_initialized = false;
                    }
                }
                else
                {
                    this.IsHot = Convert.ToBoolean(page.Request["isHot"]);
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

            
            if(page.Request["isZD"] != null)
            {
                if (this.isZD_initialized)
                {
                    if(page.Request["isZD"] != "")
                    {
                        this.IsZD = Convert.ToBoolean(page.Request["isZD"]);
                    }
                    else
                    {
                        this.isZD_initialized = false;
                    }
                }
                else
                {
                    this.IsZD = Convert.ToBoolean(page.Request["isZD"]);
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

            
            if(page.Request["addName"] != null)
            {
                if (this.addName_initialized)
                {
                    if(page.Request["addName"] != "")
                    {
                        this.AddName = Convert.ToString(page.Request["addName"]);
                    }
                    else
                    {
                        this.addName_initialized = false;
                    }
                }
                else
                {
                    this.AddName = Convert.ToString(page.Request["addName"]);
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