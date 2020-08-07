/************************************************************

  Copyright (c) 2008，
  Author:               Date: 2019/7/15 9:32:21
  Description:    数据表Admin_User对应的业务逻辑层
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
    /// 与Admin_User数据表对应对象
    /// </summary>
    public class Admin_User : IDateBuildTable
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
        
        private string m_name;
        private bool name_initialized = false;
        
        private string m_fullName;
        private bool fullName_initialized = false;
        
        private string m_pass;
        private bool pass_initialized = false;
        
        private int m_userLevel;
        private bool userLevel_initialized = false;
        
        private int m_states;
        private bool states_initialized = false;
        
        private string m_manage;
        private bool manage_initialized = false;
        
        private string m_email;
        private bool email_initialized = false;
        
        private string m_phone;
        private bool phone_initialized = false;
        
        private string m_jobTitle;
        private bool jobTitle_initialized = false;
        
        private int m_exhibitionID;
        private bool exhibitionID_initialized = false;
        
        private string m_address;
        private bool address_initialized = false;
        
        private string m_sn;
        private bool sn_initialized = false;
        
        private string m_headPic;
        private bool headPic_initialized = false;
        
        private string m_brief;
        private bool brief_initialized = false;
        
        private DateTime m_lastLoginTime;
        private bool lastLoginTime_initialized = false;
        

        public Admin_User()
        {
        }

        public Admin_User(int iD, int addID, DateTime addTime, string name, string fullName, string pass, int userLevel, int states, string manage, string email, string phone, string jobTitle, int exhibitionID, string address, string sn, string headPic, string brief, DateTime lastLoginTime)
        {
            
            this.ID = iD;
            
            this.AddID = addID;
            
            this.AddTime = addTime;
            
            this.Name = name;
            
            this.FullName = fullName;
            
            this.Pass = pass;
            
            this.UserLevel = userLevel;
            
            this.States = states;
            
            this.Manage = manage;
            
            this.Email = email;
            
            this.Phone = phone;
            
            this.JobTitle = jobTitle;
            
            this.ExhibitionID = exhibitionID;
            
            this.Address = address;
            
            this.Sn = sn;
            
            this.HeadPic = headPic;
            
            this.Brief = brief;
            
            this.LastLoginTime = lastLoginTime;
            
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

            
            if(CheckColumn(dr, "Name"))
            {
                if (dr["Name"] != null && dr["Name"] != DBNull.Value)
                {
                    this.Name = Convert.ToString(dr["Name"]);
                }
            }

            
            if(CheckColumn(dr, "FullName"))
            {
                if (dr["FullName"] != null && dr["FullName"] != DBNull.Value)
                {
                    this.FullName = Convert.ToString(dr["FullName"]);
                }
            }

            
            if(CheckColumn(dr, "Pass"))
            {
                if (dr["Pass"] != null && dr["Pass"] != DBNull.Value)
                {
                    this.Pass = Convert.ToString(dr["Pass"]);
                }
            }

            
            if(CheckColumn(dr, "UserLevel"))
            {
                if (dr["UserLevel"] != null && dr["UserLevel"] != DBNull.Value)
                {
                    this.UserLevel = Convert.ToInt32(dr["UserLevel"]);
                }
            }

            
            if(CheckColumn(dr, "States"))
            {
                if (dr["States"] != null && dr["States"] != DBNull.Value)
                {
                    this.States = Convert.ToInt32(dr["States"]);
                }
            }

            
            if(CheckColumn(dr, "Manage"))
            {
                if (dr["Manage"] != null && dr["Manage"] != DBNull.Value)
                {
                    this.Manage = Convert.ToString(dr["Manage"]);
                }
            }

            
            if(CheckColumn(dr, "Email"))
            {
                if (dr["Email"] != null && dr["Email"] != DBNull.Value)
                {
                    this.Email = Convert.ToString(dr["Email"]);
                }
            }

            
            if(CheckColumn(dr, "Phone"))
            {
                if (dr["Phone"] != null && dr["Phone"] != DBNull.Value)
                {
                    this.Phone = Convert.ToString(dr["Phone"]);
                }
            }

            
            if(CheckColumn(dr, "JobTitle"))
            {
                if (dr["JobTitle"] != null && dr["JobTitle"] != DBNull.Value)
                {
                    this.JobTitle = Convert.ToString(dr["JobTitle"]);
                }
            }

            
            if(CheckColumn(dr, "ExhibitionID"))
            {
                if (dr["ExhibitionID"] != null && dr["ExhibitionID"] != DBNull.Value)
                {
                    this.ExhibitionID = Convert.ToInt32(dr["ExhibitionID"]);
                }
            }

            
            if(CheckColumn(dr, "Address"))
            {
                if (dr["Address"] != null && dr["Address"] != DBNull.Value)
                {
                    this.Address = Convert.ToString(dr["Address"]);
                }
            }

            
            if(CheckColumn(dr, "Sn"))
            {
                if (dr["Sn"] != null && dr["Sn"] != DBNull.Value)
                {
                    this.Sn = Convert.ToString(dr["Sn"]);
                }
            }

            
            if(CheckColumn(dr, "headPic"))
            {
                if (dr["headPic"] != null && dr["headPic"] != DBNull.Value)
                {
                    this.HeadPic = Convert.ToString(dr["headPic"]);
                }
            }

            
            if(CheckColumn(dr, "Brief"))
            {
                if (dr["Brief"] != null && dr["Brief"] != DBNull.Value)
                {
                    this.Brief = Convert.ToString(dr["Brief"]);
                }
            }

            
            if(CheckColumn(dr, "LastLoginTime"))
            {
                if (dr["LastLoginTime"] != null && dr["LastLoginTime"] != DBNull.Value)
                {
                    this.LastLoginTime = Convert.ToDateTime(dr["LastLoginTime"]);
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
        
        public string FullName
        {
            get
            {
                return this.m_fullName;
            }
            set
            {
                fullName_initialized = true;
                this.m_fullName = value;
            }
        }
        
        public string Pass
        {
            get
            {
                return this.m_pass;
            }
            set
            {
                pass_initialized = true;
                this.m_pass = value;
            }
        }
        
        public int UserLevel
        {
            get
            {
                return this.m_userLevel;
            }
            set
            {
                userLevel_initialized = true;
                this.m_userLevel = value;
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
        
        public string Manage
        {
            get
            {
                return this.m_manage;
            }
            set
            {
                manage_initialized = true;
                this.m_manage = value;
            }
        }
        
        public string Email
        {
            get
            {
                return this.m_email;
            }
            set
            {
                email_initialized = true;
                this.m_email = value;
            }
        }
        
        public string Phone
        {
            get
            {
                return this.m_phone;
            }
            set
            {
                phone_initialized = true;
                this.m_phone = value;
            }
        }
        
        public string JobTitle
        {
            get
            {
                return this.m_jobTitle;
            }
            set
            {
                jobTitle_initialized = true;
                this.m_jobTitle = value;
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
        
        public string Address
        {
            get
            {
                return this.m_address;
            }
            set
            {
                address_initialized = true;
                this.m_address = value;
            }
        }
        
        public string Sn
        {
            get
            {
                return this.m_sn;
            }
            set
            {
                sn_initialized = true;
                this.m_sn = value;
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
        
        public DateTime LastLoginTime
        {
            get
            {
                return this.m_lastLoginTime;
            }
            set
            {
                lastLoginTime_initialized = true;
                this.m_lastLoginTime = value;
            }
        }
        


        /// <summary>
        /// 判断对象属性是否赋值。没有赋值返回true
        /// </summary>
        public bool IsNull
        {
            get
            {
                if (iD_initialized || addID_initialized || addTime_initialized || name_initialized || fullName_initialized || pass_initialized || userLevel_initialized || states_initialized || manage_initialized || email_initialized || phone_initialized || jobTitle_initialized || exhibitionID_initialized || address_initialized || sn_initialized || headPic_initialized || brief_initialized || lastLoginTime_initialized)
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
            
            if (name_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Name", SqlDbType.NVarChar);
                n_Parameter.Value = this.Name;
                n_Parameter.SourceColumn = "Name";
                parametersList.Add(n_Parameter);
            }
            
            if (fullName_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "FullName", SqlDbType.NVarChar);
                n_Parameter.Value = this.FullName;
                n_Parameter.SourceColumn = "FullName";
                parametersList.Add(n_Parameter);
            }
            
            if (pass_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Pass", SqlDbType.NVarChar);
                n_Parameter.Value = this.Pass;
                n_Parameter.SourceColumn = "Pass";
                parametersList.Add(n_Parameter);
            }
            
            if (userLevel_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "UserLevel", SqlDbType.Int);
                n_Parameter.Value = this.UserLevel;
                n_Parameter.SourceColumn = "UserLevel";
                parametersList.Add(n_Parameter);
            }
            
            if (states_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "States", SqlDbType.Int);
                n_Parameter.Value = this.States;
                n_Parameter.SourceColumn = "States";
                parametersList.Add(n_Parameter);
            }
            
            if (manage_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Manage", SqlDbType.NVarChar);
                n_Parameter.Value = this.Manage;
                n_Parameter.SourceColumn = "Manage";
                parametersList.Add(n_Parameter);
            }
            
            if (email_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Email", SqlDbType.NVarChar);
                n_Parameter.Value = this.Email;
                n_Parameter.SourceColumn = "Email";
                parametersList.Add(n_Parameter);
            }
            
            if (phone_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Phone", SqlDbType.NVarChar);
                n_Parameter.Value = this.Phone;
                n_Parameter.SourceColumn = "Phone";
                parametersList.Add(n_Parameter);
            }
            
            if (jobTitle_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "JobTitle", SqlDbType.NVarChar);
                n_Parameter.Value = this.JobTitle;
                n_Parameter.SourceColumn = "JobTitle";
                parametersList.Add(n_Parameter);
            }
            
            if (exhibitionID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ExhibitionID", SqlDbType.Int);
                n_Parameter.Value = this.ExhibitionID;
                n_Parameter.SourceColumn = "ExhibitionID";
                parametersList.Add(n_Parameter);
            }
            
            if (address_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Address", SqlDbType.NVarChar);
                n_Parameter.Value = this.Address;
                n_Parameter.SourceColumn = "Address";
                parametersList.Add(n_Parameter);
            }
            
            if (sn_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Sn", SqlDbType.NVarChar);
                n_Parameter.Value = this.Sn;
                n_Parameter.SourceColumn = "Sn";
                parametersList.Add(n_Parameter);
            }
            
            if (headPic_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "headPic", SqlDbType.NVarChar);
                n_Parameter.Value = this.HeadPic;
                n_Parameter.SourceColumn = "headPic";
                parametersList.Add(n_Parameter);
            }
            
            if (brief_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Brief", SqlDbType.NVarChar);
                n_Parameter.Value = this.Brief;
                n_Parameter.SourceColumn = "Brief";
                parametersList.Add(n_Parameter);
            }
            
            if (lastLoginTime_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "LastLoginTime", SqlDbType.DateTime);
                n_Parameter.Value = this.LastLoginTime;
                n_Parameter.SourceColumn = "LastLoginTime";
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
                
                if (this.name_initialized)
                {
                    contentText += ", [Name]=@" + headStr + "Name ";
                }
                
                if (this.fullName_initialized)
                {
                    contentText += ", [FullName]=@" + headStr + "FullName ";
                }
                
                if (this.pass_initialized)
                {
                    contentText += ", [Pass]=@" + headStr + "Pass ";
                }
                
                if (this.userLevel_initialized)
                {
                    contentText += ", [UserLevel]=@" + headStr + "UserLevel ";
                }
                
                if (this.states_initialized)
                {
                    contentText += ", [States]=@" + headStr + "States ";
                }
                
                if (this.manage_initialized)
                {
                    contentText += ", [Manage]=@" + headStr + "Manage ";
                }
                
                if (this.email_initialized)
                {
                    contentText += ", [Email]=@" + headStr + "Email ";
                }
                
                if (this.phone_initialized)
                {
                    contentText += ", [Phone]=@" + headStr + "Phone ";
                }
                
                if (this.jobTitle_initialized)
                {
                    contentText += ", [JobTitle]=@" + headStr + "JobTitle ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    contentText += ", [ExhibitionID]=@" + headStr + "ExhibitionID ";
                }
                
                if (this.address_initialized)
                {
                    contentText += ", [Address]=@" + headStr + "Address ";
                }
                
                if (this.sn_initialized)
                {
                    contentText += ", [Sn]=@" + headStr + "Sn ";
                }
                
                if (this.headPic_initialized)
                {
                    contentText += ", [headPic]=@" + headStr + "headPic ";
                }
                
                if (this.brief_initialized)
                {
                    contentText += ", [Brief]=@" + headStr + "Brief ";
                }
                
                if (this.lastLoginTime_initialized)
                {
                    contentText += ", [LastLoginTime]=@" + headStr + "LastLoginTime ";
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
                
                if (this.name_initialized)
                {
                    conditionStr += " AND [Name]=@" + headStr + "Name ";
                }
                
                if (this.fullName_initialized)
                {
                    conditionStr += " AND [FullName]=@" + headStr + "FullName ";
                }
                
                if (this.pass_initialized)
                {
                    conditionStr += " AND [Pass]=@" + headStr + "Pass ";
                }
                
                if (this.userLevel_initialized)
                {
                    conditionStr += " AND [UserLevel]=@" + headStr + "UserLevel ";
                }
                
                if (this.states_initialized)
                {
                    conditionStr += " AND [States]=@" + headStr + "States ";
                }
                
                if (this.manage_initialized)
                {
                    conditionStr += " AND [Manage]=@" + headStr + "Manage ";
                }
                
                if (this.email_initialized)
                {
                    conditionStr += " AND [Email]=@" + headStr + "Email ";
                }
                
                if (this.phone_initialized)
                {
                    conditionStr += " AND [Phone]=@" + headStr + "Phone ";
                }
                
                if (this.jobTitle_initialized)
                {
                    conditionStr += " AND [JobTitle]=@" + headStr + "JobTitle ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    conditionStr += " AND [ExhibitionID]=@" + headStr + "ExhibitionID ";
                }
                
                if (this.address_initialized)
                {
                    conditionStr += " AND [Address]=@" + headStr + "Address ";
                }
                
                if (this.sn_initialized)
                {
                    conditionStr += " AND [Sn]=@" + headStr + "Sn ";
                }
                
                if (this.headPic_initialized)
                {
                    conditionStr += " AND [headPic]=@" + headStr + "headPic ";
                }
                
                if (this.brief_initialized)
                {
                    conditionStr += " AND [Brief]=@" + headStr + "Brief ";
                }
                
                if (this.lastLoginTime_initialized)
                {
                    conditionStr += " AND [LastLoginTime]=@" + headStr + "LastLoginTime ";
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
                
                if (this.name_initialized)
                {
                    contentText += ", [Name] ";
                }
                
                if (this.fullName_initialized)
                {
                    contentText += ", [FullName] ";
                }
                
                if (this.pass_initialized)
                {
                    contentText += ", [Pass] ";
                }
                
                if (this.userLevel_initialized)
                {
                    contentText += ", [UserLevel] ";
                }
                
                if (this.states_initialized)
                {
                    contentText += ", [States] ";
                }
                
                if (this.manage_initialized)
                {
                    contentText += ", [Manage] ";
                }
                
                if (this.email_initialized)
                {
                    contentText += ", [Email] ";
                }
                
                if (this.phone_initialized)
                {
                    contentText += ", [Phone] ";
                }
                
                if (this.jobTitle_initialized)
                {
                    contentText += ", [JobTitle] ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    contentText += ", [ExhibitionID] ";
                }
                
                if (this.address_initialized)
                {
                    contentText += ", [Address] ";
                }
                
                if (this.sn_initialized)
                {
                    contentText += ", [Sn] ";
                }
                
                if (this.headPic_initialized)
                {
                    contentText += ", [headPic] ";
                }
                
                if (this.brief_initialized)
                {
                    contentText += ", [Brief] ";
                }
                
                if (this.lastLoginTime_initialized)
                {
                    contentText += ", [LastLoginTime] ";
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
                
                if (this.name_initialized)
                {
                    contentText += ", @" + headStr + "Name ";
                }
                
                if (this.fullName_initialized)
                {
                    contentText += ", @" + headStr + "FullName ";
                }
                
                if (this.pass_initialized)
                {
                    contentText += ", @" + headStr + "Pass ";
                }
                
                if (this.userLevel_initialized)
                {
                    contentText += ", @" + headStr + "UserLevel ";
                }
                
                if (this.states_initialized)
                {
                    contentText += ", @" + headStr + "States ";
                }
                
                if (this.manage_initialized)
                {
                    contentText += ", @" + headStr + "Manage ";
                }
                
                if (this.email_initialized)
                {
                    contentText += ", @" + headStr + "Email ";
                }
                
                if (this.phone_initialized)
                {
                    contentText += ", @" + headStr + "Phone ";
                }
                
                if (this.jobTitle_initialized)
                {
                    contentText += ", @" + headStr + "JobTitle ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    contentText += ", @" + headStr + "ExhibitionID ";
                }
                
                if (this.address_initialized)
                {
                    contentText += ", @" + headStr + "Address ";
                }
                
                if (this.sn_initialized)
                {
                    contentText += ", @" + headStr + "Sn ";
                }
                
                if (this.headPic_initialized)
                {
                    contentText += ", @" + headStr + "headPic ";
                }
                
                if (this.brief_initialized)
                {
                    contentText += ", @" + headStr + "Brief ";
                }
                
                if (this.lastLoginTime_initialized)
                {
                    contentText += ", @" + headStr + "LastLoginTime ";
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
            string tableName = "Admin_User";
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
            
            this.name_initialized = true;
            
            this.fullName_initialized = true;
            
            this.pass_initialized = true;
            
            this.userLevel_initialized = true;
            
            this.states_initialized = true;
            
            this.manage_initialized = true;
            
            this.email_initialized = true;
            
            this.phone_initialized = true;
            
            this.jobTitle_initialized = true;
            
            this.exhibitionID_initialized = true;
            
            this.address_initialized = true;
            
            this.sn_initialized = true;
            
            this.headPic_initialized = true;
            
            this.brief_initialized = true;
            
            this.lastLoginTime_initialized = true;
            
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

            
            if(page.Request["fullName"] != null)
            {
                if (this.fullName_initialized)
                {
                    if(page.Request["fullName"] != "")
                    {
                        this.FullName = Convert.ToString(page.Request["fullName"]);
                    }
                    else
                    {
                        this.fullName_initialized = false;
                    }
                }
                else
                {
                    this.FullName = Convert.ToString(page.Request["fullName"]);
                }
            }

            
            if(page.Request["pass"] != null)
            {
                if (this.pass_initialized)
                {
                    if(page.Request["pass"] != "")
                    {
                        this.Pass = Convert.ToString(page.Request["pass"]);
                    }
                    else
                    {
                        this.pass_initialized = false;
                    }
                }
                else
                {
                    this.Pass = Convert.ToString(page.Request["pass"]);
                }
            }

            
            if(page.Request["userLevel"] != null)
            {
                if (this.userLevel_initialized)
                {
                    if(page.Request["userLevel"] != "")
                    {
                        this.UserLevel = Convert.ToInt32(page.Request["userLevel"]);
                    }
                    else
                    {
                        this.userLevel_initialized = false;
                    }
                }
                else
                {
                    this.UserLevel = Convert.ToInt32(page.Request["userLevel"]);
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

            
            if(page.Request["manage"] != null)
            {
                if (this.manage_initialized)
                {
                    if(page.Request["manage"] != "")
                    {
                        this.Manage = Convert.ToString(page.Request["manage"]);
                    }
                    else
                    {
                        this.manage_initialized = false;
                    }
                }
                else
                {
                    this.Manage = Convert.ToString(page.Request["manage"]);
                }
            }

            
            if(page.Request["email"] != null)
            {
                if (this.email_initialized)
                {
                    if(page.Request["email"] != "")
                    {
                        this.Email = Convert.ToString(page.Request["email"]);
                    }
                    else
                    {
                        this.email_initialized = false;
                    }
                }
                else
                {
                    this.Email = Convert.ToString(page.Request["email"]);
                }
            }

            
            if(page.Request["phone"] != null)
            {
                if (this.phone_initialized)
                {
                    if(page.Request["phone"] != "")
                    {
                        this.Phone = Convert.ToString(page.Request["phone"]);
                    }
                    else
                    {
                        this.phone_initialized = false;
                    }
                }
                else
                {
                    this.Phone = Convert.ToString(page.Request["phone"]);
                }
            }

            
            if(page.Request["jobTitle"] != null)
            {
                if (this.jobTitle_initialized)
                {
                    if(page.Request["jobTitle"] != "")
                    {
                        this.JobTitle = Convert.ToString(page.Request["jobTitle"]);
                    }
                    else
                    {
                        this.jobTitle_initialized = false;
                    }
                }
                else
                {
                    this.JobTitle = Convert.ToString(page.Request["jobTitle"]);
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

            
            if(page.Request["address"] != null)
            {
                if (this.address_initialized)
                {
                    if(page.Request["address"] != "")
                    {
                        this.Address = Convert.ToString(page.Request["address"]);
                    }
                    else
                    {
                        this.address_initialized = false;
                    }
                }
                else
                {
                    this.Address = Convert.ToString(page.Request["address"]);
                }
            }

            
            if(page.Request["sn"] != null)
            {
                if (this.sn_initialized)
                {
                    if(page.Request["sn"] != "")
                    {
                        this.Sn = Convert.ToString(page.Request["sn"]);
                    }
                    else
                    {
                        this.sn_initialized = false;
                    }
                }
                else
                {
                    this.Sn = Convert.ToString(page.Request["sn"]);
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

            
            if(page.Request["lastLoginTime"] != null)
            {
                if (this.lastLoginTime_initialized)
                {
                    if(page.Request["lastLoginTime"] != "")
                    {
                        this.LastLoginTime = Convert.ToDateTime(page.Request["lastLoginTime"]);
                    }
                    else
                    {
                        this.lastLoginTime_initialized = false;
                    }
                }
                else
                {
                    this.LastLoginTime = Convert.ToDateTime(page.Request["lastLoginTime"]);
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