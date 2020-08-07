﻿/************************************************************

  Copyright (c) 2008，
  Author:               Date: 2019/12/9 11:22:32
  Description:    数据表Userinfo_View对应的业务逻辑层
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
    /// 与Userinfo_View数据表对应对象
    /// </summary>
    public class Userinfo_View : IDateBuildTable
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
        
        private string m_nickName;
        private bool nickName_initialized = false;
        
        private int m_gender;
        private bool gender_initialized = false;
        
        private string m_wxID;
        private bool wxID_initialized = false;
        
        private string m_phone;
        private bool phone_initialized = false;
        
        private DateTime m_addTime;
        private bool addTime_initialized = false;
        
        private int m_ageType;
        private bool ageType_initialized = false;
        
        private int m_tradeID;
        private bool tradeID_initialized = false;
        
        private string m_headImage;
        private bool headImage_initialized = false;
        
        private DateTime m_lastModifyTime;
        private bool lastModifyTime_initialized = false;
        
        private string m_erCode;
        private bool erCode_initialized = false;
        
        private int m_addID;
        private bool addID_initialized = false;
        
        private int m_exhibitionID;
        private bool exhibitionID_initialized = false;
        
        private long m_orderID;
        private bool orderID_initialized = false;
        
        private string m_fileSize;
        private bool fileSize_initialized = false;
        
        private string m_ageName;
        private bool ageName_initialized = false;
        
        private string m_tradeType;
        private bool tradeType_initialized = false;
        
        private int m_state;
        private bool state_initialized = false;
        

        public Userinfo_View()
        {
        }

        public Userinfo_View(int iD, string name, string nickName, int gender, string wxID, string phone, DateTime addTime, int ageType, int tradeID, string headImage, DateTime lastModifyTime, string erCode, int addID, int exhibitionID, long orderID, string fileSize, string ageName, string tradeType, int state)
        {
            
            this.ID = iD;
            
            this.Name = name;
            
            this.NickName = nickName;
            
            this.Gender = gender;
            
            this.WxID = wxID;
            
            this.Phone = phone;
            
            this.AddTime = addTime;
            
            this.AgeType = ageType;
            
            this.TradeID = tradeID;
            
            this.HeadImage = headImage;
            
            this.LastModifyTime = lastModifyTime;
            
            this.ErCode = erCode;
            
            this.AddID = addID;
            
            this.ExhibitionID = exhibitionID;
            
            this.OrderID = orderID;
            
            this.FileSize = fileSize;
            
            this.AgeName = ageName;
            
            this.TradeType = tradeType;
            
            this.State = state;
            
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

            
            if(CheckColumn(dr, "NickName"))
            {
                if (dr["NickName"] != null && dr["NickName"] != DBNull.Value)
                {
                    this.NickName = Convert.ToString(dr["NickName"]);
                }
            }

            
            if(CheckColumn(dr, "Gender"))
            {
                if (dr["Gender"] != null && dr["Gender"] != DBNull.Value)
                {
                    this.Gender = Convert.ToInt32(dr["Gender"]);
                }
            }

            
            if(CheckColumn(dr, "WxID"))
            {
                if (dr["WxID"] != null && dr["WxID"] != DBNull.Value)
                {
                    this.WxID = Convert.ToString(dr["WxID"]);
                }
            }

            
            if(CheckColumn(dr, "Phone"))
            {
                if (dr["Phone"] != null && dr["Phone"] != DBNull.Value)
                {
                    this.Phone = Convert.ToString(dr["Phone"]);
                }
            }

            
            if(CheckColumn(dr, "AddTime"))
            {
                if (dr["AddTime"] != null && dr["AddTime"] != DBNull.Value)
                {
                    this.AddTime = Convert.ToDateTime(dr["AddTime"]);
                }
            }

            
            if(CheckColumn(dr, "AgeType"))
            {
                if (dr["AgeType"] != null && dr["AgeType"] != DBNull.Value)
                {
                    this.AgeType = Convert.ToInt32(dr["AgeType"]);
                }
            }

            
            if(CheckColumn(dr, "TradeID"))
            {
                if (dr["TradeID"] != null && dr["TradeID"] != DBNull.Value)
                {
                    this.TradeID = Convert.ToInt32(dr["TradeID"]);
                }
            }

            
            if(CheckColumn(dr, "HeadImage"))
            {
                if (dr["HeadImage"] != null && dr["HeadImage"] != DBNull.Value)
                {
                    this.HeadImage = Convert.ToString(dr["HeadImage"]);
                }
            }

            
            if(CheckColumn(dr, "LastModifyTime"))
            {
                if (dr["LastModifyTime"] != null && dr["LastModifyTime"] != DBNull.Value)
                {
                    this.LastModifyTime = Convert.ToDateTime(dr["LastModifyTime"]);
                }
            }

            
            if(CheckColumn(dr, "ErCode"))
            {
                if (dr["ErCode"] != null && dr["ErCode"] != DBNull.Value)
                {
                    this.ErCode = Convert.ToString(dr["ErCode"]);
                }
            }

            
            if(CheckColumn(dr, "AddID"))
            {
                if (dr["AddID"] != null && dr["AddID"] != DBNull.Value)
                {
                    this.AddID = Convert.ToInt32(dr["AddID"]);
                }
            }

            
            if(CheckColumn(dr, "ExhibitionID"))
            {
                if (dr["ExhibitionID"] != null && dr["ExhibitionID"] != DBNull.Value)
                {
                    this.ExhibitionID = Convert.ToInt32(dr["ExhibitionID"]);
                }
            }

            
            if(CheckColumn(dr, "OrderID"))
            {
                if (dr["OrderID"] != null && dr["OrderID"] != DBNull.Value)
                {
                    this.OrderID = Convert.ToInt64(dr["OrderID"]);
                }
            }

            
            if(CheckColumn(dr, "FileSize"))
            {
                if (dr["FileSize"] != null && dr["FileSize"] != DBNull.Value)
                {
                    this.FileSize = Convert.ToString(dr["FileSize"]);
                }
            }

            
            if(CheckColumn(dr, "AgeName"))
            {
                if (dr["AgeName"] != null && dr["AgeName"] != DBNull.Value)
                {
                    this.AgeName = Convert.ToString(dr["AgeName"]);
                }
            }

            
            if(CheckColumn(dr, "TradeType"))
            {
                if (dr["TradeType"] != null && dr["TradeType"] != DBNull.Value)
                {
                    this.TradeType = Convert.ToString(dr["TradeType"]);
                }
            }

            
            if(CheckColumn(dr, "State"))
            {
                if (dr["State"] != null && dr["State"] != DBNull.Value)
                {
                    this.State = Convert.ToInt32(dr["State"]);
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
        
        public string NickName
        {
            get
            {
                return this.m_nickName;
            }
            set
            {
                nickName_initialized = true;
                this.m_nickName = value;
            }
        }
        
        public int Gender
        {
            get
            {
                return this.m_gender;
            }
            set
            {
                gender_initialized = true;
                this.m_gender = value;
            }
        }
        
        public string WxID
        {
            get
            {
                return this.m_wxID;
            }
            set
            {
                wxID_initialized = true;
                this.m_wxID = value;
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
        
        public int AgeType
        {
            get
            {
                return this.m_ageType;
            }
            set
            {
                ageType_initialized = true;
                this.m_ageType = value;
            }
        }
        
        public int TradeID
        {
            get
            {
                return this.m_tradeID;
            }
            set
            {
                tradeID_initialized = true;
                this.m_tradeID = value;
            }
        }
        
        public string HeadImage
        {
            get
            {
                return this.m_headImage;
            }
            set
            {
                headImage_initialized = true;
                this.m_headImage = value;
            }
        }
        
        public DateTime LastModifyTime
        {
            get
            {
                return this.m_lastModifyTime;
            }
            set
            {
                lastModifyTime_initialized = true;
                this.m_lastModifyTime = value;
            }
        }
        
        public string ErCode
        {
            get
            {
                return this.m_erCode;
            }
            set
            {
                erCode_initialized = true;
                this.m_erCode = value;
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
        
        public long OrderID
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
        
        public string FileSize
        {
            get
            {
                return this.m_fileSize;
            }
            set
            {
                fileSize_initialized = true;
                this.m_fileSize = value;
            }
        }
        
        public string AgeName
        {
            get
            {
                return this.m_ageName;
            }
            set
            {
                ageName_initialized = true;
                this.m_ageName = value;
            }
        }
        
        public string TradeType
        {
            get
            {
                return this.m_tradeType;
            }
            set
            {
                tradeType_initialized = true;
                this.m_tradeType = value;
            }
        }
        
        public int State
        {
            get
            {
                return this.m_state;
            }
            set
            {
                state_initialized = true;
                this.m_state = value;
            }
        }
        


        /// <summary>
        /// 判断对象属性是否赋值。没有赋值返回true
        /// </summary>
        public bool IsNull
        {
            get
            {
                if (iD_initialized || name_initialized || nickName_initialized || gender_initialized || wxID_initialized || phone_initialized || addTime_initialized || ageType_initialized || tradeID_initialized || headImage_initialized || lastModifyTime_initialized || erCode_initialized || addID_initialized || exhibitionID_initialized || orderID_initialized || fileSize_initialized || ageName_initialized || tradeType_initialized || state_initialized)
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
            
            if (nickName_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "NickName", SqlDbType.NVarChar);
                n_Parameter.Value = this.NickName;
                n_Parameter.SourceColumn = "NickName";
                parametersList.Add(n_Parameter);
            }
            
            if (gender_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Gender", SqlDbType.Int);
                n_Parameter.Value = this.Gender;
                n_Parameter.SourceColumn = "Gender";
                parametersList.Add(n_Parameter);
            }
            
            if (wxID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "WxID", SqlDbType.NVarChar);
                n_Parameter.Value = this.WxID;
                n_Parameter.SourceColumn = "WxID";
                parametersList.Add(n_Parameter);
            }
            
            if (phone_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Phone", SqlDbType.NVarChar);
                n_Parameter.Value = this.Phone;
                n_Parameter.SourceColumn = "Phone";
                parametersList.Add(n_Parameter);
            }
            
            if (addTime_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "AddTime", SqlDbType.DateTime);
                n_Parameter.Value = this.AddTime;
                n_Parameter.SourceColumn = "AddTime";
                parametersList.Add(n_Parameter);
            }
            
            if (ageType_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "AgeType", SqlDbType.Int);
                n_Parameter.Value = this.AgeType;
                n_Parameter.SourceColumn = "AgeType";
                parametersList.Add(n_Parameter);
            }
            
            if (tradeID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "TradeID", SqlDbType.Int);
                n_Parameter.Value = this.TradeID;
                n_Parameter.SourceColumn = "TradeID";
                parametersList.Add(n_Parameter);
            }
            
            if (headImage_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "HeadImage", SqlDbType.NVarChar);
                n_Parameter.Value = this.HeadImage;
                n_Parameter.SourceColumn = "HeadImage";
                parametersList.Add(n_Parameter);
            }
            
            if (lastModifyTime_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "LastModifyTime", SqlDbType.DateTime);
                n_Parameter.Value = this.LastModifyTime;
                n_Parameter.SourceColumn = "LastModifyTime";
                parametersList.Add(n_Parameter);
            }
            
            if (erCode_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ErCode", SqlDbType.NVarChar);
                n_Parameter.Value = this.ErCode;
                n_Parameter.SourceColumn = "ErCode";
                parametersList.Add(n_Parameter);
            }
            
            if (addID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "AddID", SqlDbType.Int);
                n_Parameter.Value = this.AddID;
                n_Parameter.SourceColumn = "AddID";
                parametersList.Add(n_Parameter);
            }
            
            if (exhibitionID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ExhibitionID", SqlDbType.Int);
                n_Parameter.Value = this.ExhibitionID;
                n_Parameter.SourceColumn = "ExhibitionID";
                parametersList.Add(n_Parameter);
            }
            
            if (orderID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "OrderID", SqlDbType.BigInt);
                n_Parameter.Value = this.OrderID;
                n_Parameter.SourceColumn = "OrderID";
                parametersList.Add(n_Parameter);
            }
            
            if (fileSize_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "FileSize", SqlDbType.NVarChar);
                n_Parameter.Value = this.FileSize;
                n_Parameter.SourceColumn = "FileSize";
                parametersList.Add(n_Parameter);
            }
            
            if (ageName_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "AgeName", SqlDbType.NVarChar);
                n_Parameter.Value = this.AgeName;
                n_Parameter.SourceColumn = "AgeName";
                parametersList.Add(n_Parameter);
            }
            
            if (tradeType_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "TradeType", SqlDbType.NVarChar);
                n_Parameter.Value = this.TradeType;
                n_Parameter.SourceColumn = "TradeType";
                parametersList.Add(n_Parameter);
            }
            
            if (state_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "State", SqlDbType.Int);
                n_Parameter.Value = this.State;
                n_Parameter.SourceColumn = "State";
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
                
                if (this.nickName_initialized)
                {
                    contentText += ", [NickName]=@" + headStr + "NickName ";
                }
                
                if (this.gender_initialized)
                {
                    contentText += ", [Gender]=@" + headStr + "Gender ";
                }
                
                if (this.wxID_initialized)
                {
                    contentText += ", [WxID]=@" + headStr + "WxID ";
                }
                
                if (this.phone_initialized)
                {
                    contentText += ", [Phone]=@" + headStr + "Phone ";
                }
                
                if (this.addTime_initialized)
                {
                    contentText += ", [AddTime]=@" + headStr + "AddTime ";
                }
                
                if (this.ageType_initialized)
                {
                    contentText += ", [AgeType]=@" + headStr + "AgeType ";
                }
                
                if (this.tradeID_initialized)
                {
                    contentText += ", [TradeID]=@" + headStr + "TradeID ";
                }
                
                if (this.headImage_initialized)
                {
                    contentText += ", [HeadImage]=@" + headStr + "HeadImage ";
                }
                
                if (this.lastModifyTime_initialized)
                {
                    contentText += ", [LastModifyTime]=@" + headStr + "LastModifyTime ";
                }
                
                if (this.erCode_initialized)
                {
                    contentText += ", [ErCode]=@" + headStr + "ErCode ";
                }
                
                if (this.addID_initialized)
                {
                    contentText += ", [AddID]=@" + headStr + "AddID ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    contentText += ", [ExhibitionID]=@" + headStr + "ExhibitionID ";
                }
                
                if (this.orderID_initialized)
                {
                    contentText += ", [OrderID]=@" + headStr + "OrderID ";
                }
                
                if (this.fileSize_initialized)
                {
                    contentText += ", [FileSize]=@" + headStr + "FileSize ";
                }
                
                if (this.ageName_initialized)
                {
                    contentText += ", [AgeName]=@" + headStr + "AgeName ";
                }
                
                if (this.tradeType_initialized)
                {
                    contentText += ", [TradeType]=@" + headStr + "TradeType ";
                }
                
                if (this.state_initialized)
                {
                    contentText += ", [State]=@" + headStr + "State ";
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
                
                if (this.nickName_initialized)
                {
                    conditionStr += " AND [NickName]=@" + headStr + "NickName ";
                }
                
                if (this.gender_initialized)
                {
                    conditionStr += " AND [Gender]=@" + headStr + "Gender ";
                }
                
                if (this.wxID_initialized)
                {
                    conditionStr += " AND [WxID]=@" + headStr + "WxID ";
                }
                
                if (this.phone_initialized)
                {
                    conditionStr += " AND [Phone]=@" + headStr + "Phone ";
                }
                
                if (this.addTime_initialized)
                {
                    conditionStr += " AND [AddTime]=@" + headStr + "AddTime ";
                }
                
                if (this.ageType_initialized)
                {
                    conditionStr += " AND [AgeType]=@" + headStr + "AgeType ";
                }
                
                if (this.tradeID_initialized)
                {
                    conditionStr += " AND [TradeID]=@" + headStr + "TradeID ";
                }
                
                if (this.headImage_initialized)
                {
                    conditionStr += " AND [HeadImage]=@" + headStr + "HeadImage ";
                }
                
                if (this.lastModifyTime_initialized)
                {
                    conditionStr += " AND [LastModifyTime]=@" + headStr + "LastModifyTime ";
                }
                
                if (this.erCode_initialized)
                {
                    conditionStr += " AND [ErCode]=@" + headStr + "ErCode ";
                }
                
                if (this.addID_initialized)
                {
                    conditionStr += " AND [AddID]=@" + headStr + "AddID ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    conditionStr += " AND [ExhibitionID]=@" + headStr + "ExhibitionID ";
                }
                
                if (this.orderID_initialized)
                {
                    conditionStr += " AND [OrderID]=@" + headStr + "OrderID ";
                }
                
                if (this.fileSize_initialized)
                {
                    conditionStr += " AND [FileSize]=@" + headStr + "FileSize ";
                }
                
                if (this.ageName_initialized)
                {
                    conditionStr += " AND [AgeName]=@" + headStr + "AgeName ";
                }
                
                if (this.tradeType_initialized)
                {
                    conditionStr += " AND [TradeType]=@" + headStr + "TradeType ";
                }
                
                if (this.state_initialized)
                {
                    conditionStr += " AND [State]=@" + headStr + "State ";
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
                
                if (this.nickName_initialized)
                {
                    contentText += ", [NickName] ";
                }
                
                if (this.gender_initialized)
                {
                    contentText += ", [Gender] ";
                }
                
                if (this.wxID_initialized)
                {
                    contentText += ", [WxID] ";
                }
                
                if (this.phone_initialized)
                {
                    contentText += ", [Phone] ";
                }
                
                if (this.addTime_initialized)
                {
                    contentText += ", [AddTime] ";
                }
                
                if (this.ageType_initialized)
                {
                    contentText += ", [AgeType] ";
                }
                
                if (this.tradeID_initialized)
                {
                    contentText += ", [TradeID] ";
                }
                
                if (this.headImage_initialized)
                {
                    contentText += ", [HeadImage] ";
                }
                
                if (this.lastModifyTime_initialized)
                {
                    contentText += ", [LastModifyTime] ";
                }
                
                if (this.erCode_initialized)
                {
                    contentText += ", [ErCode] ";
                }
                
                if (this.addID_initialized)
                {
                    contentText += ", [AddID] ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    contentText += ", [ExhibitionID] ";
                }
                
                if (this.orderID_initialized)
                {
                    contentText += ", [OrderID] ";
                }
                
                if (this.fileSize_initialized)
                {
                    contentText += ", [FileSize] ";
                }
                
                if (this.ageName_initialized)
                {
                    contentText += ", [AgeName] ";
                }
                
                if (this.tradeType_initialized)
                {
                    contentText += ", [TradeType] ";
                }
                
                if (this.state_initialized)
                {
                    contentText += ", [State] ";
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
                
                if (this.nickName_initialized)
                {
                    contentText += ", @" + headStr + "NickName ";
                }
                
                if (this.gender_initialized)
                {
                    contentText += ", @" + headStr + "Gender ";
                }
                
                if (this.wxID_initialized)
                {
                    contentText += ", @" + headStr + "WxID ";
                }
                
                if (this.phone_initialized)
                {
                    contentText += ", @" + headStr + "Phone ";
                }
                
                if (this.addTime_initialized)
                {
                    contentText += ", @" + headStr + "AddTime ";
                }
                
                if (this.ageType_initialized)
                {
                    contentText += ", @" + headStr + "AgeType ";
                }
                
                if (this.tradeID_initialized)
                {
                    contentText += ", @" + headStr + "TradeID ";
                }
                
                if (this.headImage_initialized)
                {
                    contentText += ", @" + headStr + "HeadImage ";
                }
                
                if (this.lastModifyTime_initialized)
                {
                    contentText += ", @" + headStr + "LastModifyTime ";
                }
                
                if (this.erCode_initialized)
                {
                    contentText += ", @" + headStr + "ErCode ";
                }
                
                if (this.addID_initialized)
                {
                    contentText += ", @" + headStr + "AddID ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    contentText += ", @" + headStr + "ExhibitionID ";
                }
                
                if (this.orderID_initialized)
                {
                    contentText += ", @" + headStr + "OrderID ";
                }
                
                if (this.fileSize_initialized)
                {
                    contentText += ", @" + headStr + "FileSize ";
                }
                
                if (this.ageName_initialized)
                {
                    contentText += ", @" + headStr + "AgeName ";
                }
                
                if (this.tradeType_initialized)
                {
                    contentText += ", @" + headStr + "TradeType ";
                }
                
                if (this.state_initialized)
                {
                    contentText += ", @" + headStr + "State ";
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
            string tableName = "Userinfo_View";
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
            
            this.nickName_initialized = true;
            
            this.gender_initialized = true;
            
            this.wxID_initialized = true;
            
            this.phone_initialized = true;
            
            this.addTime_initialized = true;
            
            this.ageType_initialized = true;
            
            this.tradeID_initialized = true;
            
            this.headImage_initialized = true;
            
            this.lastModifyTime_initialized = true;
            
            this.erCode_initialized = true;
            
            this.addID_initialized = true;
            
            this.exhibitionID_initialized = true;
            
            this.orderID_initialized = true;
            
            this.fileSize_initialized = true;
            
            this.ageName_initialized = true;
            
            this.tradeType_initialized = true;
            
            this.state_initialized = true;
            
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

            
            if(page.Request["nickName"] != null)
            {
                if (this.nickName_initialized)
                {
                    if(page.Request["nickName"] != "")
                    {
                        this.NickName = Convert.ToString(page.Request["nickName"]);
                    }
                    else
                    {
                        this.nickName_initialized = false;
                    }
                }
                else
                {
                    this.NickName = Convert.ToString(page.Request["nickName"]);
                }
            }

            
            if(page.Request["gender"] != null)
            {
                if (this.gender_initialized)
                {
                    if(page.Request["gender"] != "")
                    {
                        this.Gender = Convert.ToInt32(page.Request["gender"]);
                    }
                    else
                    {
                        this.gender_initialized = false;
                    }
                }
                else
                {
                    this.Gender = Convert.ToInt32(page.Request["gender"]);
                }
            }

            
            if(page.Request["wxID"] != null)
            {
                if (this.wxID_initialized)
                {
                    if(page.Request["wxID"] != "")
                    {
                        this.WxID = Convert.ToString(page.Request["wxID"]);
                    }
                    else
                    {
                        this.wxID_initialized = false;
                    }
                }
                else
                {
                    this.WxID = Convert.ToString(page.Request["wxID"]);
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

            
            if(page.Request["ageType"] != null)
            {
                if (this.ageType_initialized)
                {
                    if(page.Request["ageType"] != "")
                    {
                        this.AgeType = Convert.ToInt32(page.Request["ageType"]);
                    }
                    else
                    {
                        this.ageType_initialized = false;
                    }
                }
                else
                {
                    this.AgeType = Convert.ToInt32(page.Request["ageType"]);
                }
            }

            
            if(page.Request["tradeID"] != null)
            {
                if (this.tradeID_initialized)
                {
                    if(page.Request["tradeID"] != "")
                    {
                        this.TradeID = Convert.ToInt32(page.Request["tradeID"]);
                    }
                    else
                    {
                        this.tradeID_initialized = false;
                    }
                }
                else
                {
                    this.TradeID = Convert.ToInt32(page.Request["tradeID"]);
                }
            }

            
            if(page.Request["headImage"] != null)
            {
                if (this.headImage_initialized)
                {
                    if(page.Request["headImage"] != "")
                    {
                        this.HeadImage = Convert.ToString(page.Request["headImage"]);
                    }
                    else
                    {
                        this.headImage_initialized = false;
                    }
                }
                else
                {
                    this.HeadImage = Convert.ToString(page.Request["headImage"]);
                }
            }

            
            if(page.Request["lastModifyTime"] != null)
            {
                if (this.lastModifyTime_initialized)
                {
                    if(page.Request["lastModifyTime"] != "")
                    {
                        this.LastModifyTime = Convert.ToDateTime(page.Request["lastModifyTime"]);
                    }
                    else
                    {
                        this.lastModifyTime_initialized = false;
                    }
                }
                else
                {
                    this.LastModifyTime = Convert.ToDateTime(page.Request["lastModifyTime"]);
                }
            }

            
            if(page.Request["erCode"] != null)
            {
                if (this.erCode_initialized)
                {
                    if(page.Request["erCode"] != "")
                    {
                        this.ErCode = Convert.ToString(page.Request["erCode"]);
                    }
                    else
                    {
                        this.erCode_initialized = false;
                    }
                }
                else
                {
                    this.ErCode = Convert.ToString(page.Request["erCode"]);
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

            
            if(page.Request["orderID"] != null)
            {
                if (this.orderID_initialized)
                {
                    if(page.Request["orderID"] != "")
                    {
                        this.OrderID = Convert.ToInt64(page.Request["orderID"]);
                    }
                    else
                    {
                        this.orderID_initialized = false;
                    }
                }
                else
                {
                    this.OrderID = Convert.ToInt64(page.Request["orderID"]);
                }
            }

            
            if(page.Request["fileSize"] != null)
            {
                if (this.fileSize_initialized)
                {
                    if(page.Request["fileSize"] != "")
                    {
                        this.FileSize = Convert.ToString(page.Request["fileSize"]);
                    }
                    else
                    {
                        this.fileSize_initialized = false;
                    }
                }
                else
                {
                    this.FileSize = Convert.ToString(page.Request["fileSize"]);
                }
            }

            
            if(page.Request["ageName"] != null)
            {
                if (this.ageName_initialized)
                {
                    if(page.Request["ageName"] != "")
                    {
                        this.AgeName = Convert.ToString(page.Request["ageName"]);
                    }
                    else
                    {
                        this.ageName_initialized = false;
                    }
                }
                else
                {
                    this.AgeName = Convert.ToString(page.Request["ageName"]);
                }
            }

            
            if(page.Request["tradeType"] != null)
            {
                if (this.tradeType_initialized)
                {
                    if(page.Request["tradeType"] != "")
                    {
                        this.TradeType = Convert.ToString(page.Request["tradeType"]);
                    }
                    else
                    {
                        this.tradeType_initialized = false;
                    }
                }
                else
                {
                    this.TradeType = Convert.ToString(page.Request["tradeType"]);
                }
            }

            
            if(page.Request["state"] != null)
            {
                if (this.state_initialized)
                {
                    if(page.Request["state"] != "")
                    {
                        this.State = Convert.ToInt32(page.Request["state"]);
                    }
                    else
                    {
                        this.state_initialized = false;
                    }
                }
                else
                {
                    this.State = Convert.ToInt32(page.Request["state"]);
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