/************************************************************

  Copyright (c) 2008，
  Author:               Date: 2019/9/16 9:50:36
  Description:    数据表View_News对应的业务逻辑层
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
    /// 与View_News数据表对应对象
    /// </summary>
    public class View_News : IDateBuildTable
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

        
        private string m_exhibitionName;
        private bool exhibitionName_initialized = false;
        
        private string m_tagName;
        private bool tagName_initialized = false;
        
        private string m_modeName;
        private bool modeName_initialized = false;
        
        private int m_iD;
        private bool iD_initialized = false;
        
        private int m_addID;
        private bool addID_initialized = false;
        
        private DateTime m_addTime;
        private bool addTime_initialized = false;
        
        private string m_title;
        private bool title_initialized = false;
        
        private string m_files;
        private bool files_initialized = false;
        
        private string m_files1;
        private bool files1_initialized = false;
        
        private int m_pcID;
        private bool pcID_initialized = false;
        
        private string m_jsonStr;
        private bool jsonStr_initialized = false;
        
        private int m_isjz;
        private bool isjz_initialized = false;
        
        private int m_state;
        private bool state_initialized = false;
        
        private long m_orderID;
        private bool orderID_initialized = false;
        
        private string m_picWord;
        private bool picWord_initialized = false;
        
        private string m_brief;
        private bool brief_initialized = false;
        
        private int m_fileType;
        private bool fileType_initialized = false;
        
        private int m_isPingBao;
        private bool isPingBao_initialized = false;
        
        private int m_exhibitionID;
        private bool exhibitionID_initialized = false;
        
        private int m_modeID;
        private bool modeID_initialized = false;
        
        private string m_fileSize;
        private bool fileSize_initialized = false;
        
        private int m_isShare;
        private bool isShare_initialized = false;
        
        private int m_isDown;
        private bool isDown_initialized = false;
        
        private int m_tagID;
        private bool tagID_initialized = false;
        
        private int m_typeID;
        private bool typeID_initialized = false;
        
        private DateTime m_shareTime;
        private bool shareTime_initialized = false;
        
        private int m_oldID;
        private bool oldID_initialized = false;
        
        private int m_channelID;
        private bool channelID_initialized = false;
        
        private string m_pcName;
        private bool pcName_initialized = false;
        
        private string m_channelName;
        private bool channelName_initialized = false;
        
        private string m_pic;
        private bool pic_initialized = false;
        
        private string m_brief1;
        private bool brief1_initialized = false;
        
        private string m_brief2;
        private bool brief2_initialized = false;
        

        public View_News()
        {
        }

        public View_News(string exhibitionName, string tagName, string modeName, int iD, int addID, DateTime addTime, string title, string files, string files1, int pcID, string jsonStr, int isjz, int state, long orderID, string picWord, string brief, int fileType, int isPingBao, int exhibitionID, int modeID, string fileSize, int isShare, int isDown, int tagID, int typeID, DateTime shareTime, int oldID, int channelID, string pcName, string channelName, string pic, string brief1, string brief2)
        {
            
            this.ExhibitionName = exhibitionName;
            
            this.TagName = tagName;
            
            this.ModeName = modeName;
            
            this.ID = iD;
            
            this.AddID = addID;
            
            this.AddTime = addTime;
            
            this.Title = title;
            
            this.Files = files;
            
            this.Files1 = files1;
            
            this.PcID = pcID;
            
            this.JsonStr = jsonStr;
            
            this.Isjz = isjz;
            
            this.State = state;
            
            this.OrderID = orderID;
            
            this.PicWord = picWord;
            
            this.Brief = brief;
            
            this.FileType = fileType;
            
            this.IsPingBao = isPingBao;
            
            this.ExhibitionID = exhibitionID;
            
            this.ModeID = modeID;
            
            this.FileSize = fileSize;
            
            this.IsShare = isShare;
            
            this.IsDown = isDown;
            
            this.TagID = tagID;
            
            this.TypeID = typeID;
            
            this.ShareTime = shareTime;
            
            this.OldID = oldID;
            
            this.ChannelID = channelID;
            
            this.PcName = pcName;
            
            this.ChannelName = channelName;
            
            this.Pic = pic;
            
            this.Brief1 = brief1;
            
            this.Brief2 = brief2;
            
        }


        /// <summary>
        /// 从SqlDataProvider中读取数据
        /// </summary>
        /// <param name="dr"></param>
        public void FromIDataReader(IDataReader dr)
        {
            
            if(CheckColumn(dr, "ExhibitionName"))
            {
                if (dr["ExhibitionName"] != null && dr["ExhibitionName"] != DBNull.Value)
                {
                    this.ExhibitionName = Convert.ToString(dr["ExhibitionName"]);
                }
            }

            
            if(CheckColumn(dr, "TagName"))
            {
                if (dr["TagName"] != null && dr["TagName"] != DBNull.Value)
                {
                    this.TagName = Convert.ToString(dr["TagName"]);
                }
            }

            
            if(CheckColumn(dr, "ModeName"))
            {
                if (dr["ModeName"] != null && dr["ModeName"] != DBNull.Value)
                {
                    this.ModeName = Convert.ToString(dr["ModeName"]);
                }
            }

            
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

            
            if(CheckColumn(dr, "Title"))
            {
                if (dr["Title"] != null && dr["Title"] != DBNull.Value)
                {
                    this.Title = Convert.ToString(dr["Title"]);
                }
            }

            
            if(CheckColumn(dr, "Files"))
            {
                if (dr["Files"] != null && dr["Files"] != DBNull.Value)
                {
                    this.Files = Convert.ToString(dr["Files"]);
                }
            }

            
            if(CheckColumn(dr, "Files1"))
            {
                if (dr["Files1"] != null && dr["Files1"] != DBNull.Value)
                {
                    this.Files1 = Convert.ToString(dr["Files1"]);
                }
            }

            
            if(CheckColumn(dr, "PcID"))
            {
                if (dr["PcID"] != null && dr["PcID"] != DBNull.Value)
                {
                    this.PcID = Convert.ToInt32(dr["PcID"]);
                }
            }

            
            if(CheckColumn(dr, "JsonStr"))
            {
                if (dr["JsonStr"] != null && dr["JsonStr"] != DBNull.Value)
                {
                    this.JsonStr = Convert.ToString(dr["JsonStr"]);
                }
            }

            
            if(CheckColumn(dr, "Isjz"))
            {
                if (dr["Isjz"] != null && dr["Isjz"] != DBNull.Value)
                {
                    this.Isjz = Convert.ToInt32(dr["Isjz"]);
                }
            }

            
            if(CheckColumn(dr, "State"))
            {
                if (dr["State"] != null && dr["State"] != DBNull.Value)
                {
                    this.State = Convert.ToInt32(dr["State"]);
                }
            }

            
            if(CheckColumn(dr, "OrderID"))
            {
                if (dr["OrderID"] != null && dr["OrderID"] != DBNull.Value)
                {
                    this.OrderID = Convert.ToInt64(dr["OrderID"]);
                }
            }

            
            if(CheckColumn(dr, "PicWord"))
            {
                if (dr["PicWord"] != null && dr["PicWord"] != DBNull.Value)
                {
                    this.PicWord = Convert.ToString(dr["PicWord"]);
                }
            }

            
            if(CheckColumn(dr, "Brief"))
            {
                if (dr["Brief"] != null && dr["Brief"] != DBNull.Value)
                {
                    this.Brief = Convert.ToString(dr["Brief"]);
                }
            }

            
            if(CheckColumn(dr, "FileType"))
            {
                if (dr["FileType"] != null && dr["FileType"] != DBNull.Value)
                {
                    this.FileType = Convert.ToInt32(dr["FileType"]);
                }
            }

            
            if(CheckColumn(dr, "IsPingBao"))
            {
                if (dr["IsPingBao"] != null && dr["IsPingBao"] != DBNull.Value)
                {
                    this.IsPingBao = Convert.ToInt32(dr["IsPingBao"]);
                }
            }

            
            if(CheckColumn(dr, "ExhibitionID"))
            {
                if (dr["ExhibitionID"] != null && dr["ExhibitionID"] != DBNull.Value)
                {
                    this.ExhibitionID = Convert.ToInt32(dr["ExhibitionID"]);
                }
            }

            
            if(CheckColumn(dr, "ModeID"))
            {
                if (dr["ModeID"] != null && dr["ModeID"] != DBNull.Value)
                {
                    this.ModeID = Convert.ToInt32(dr["ModeID"]);
                }
            }

            
            if(CheckColumn(dr, "FileSize"))
            {
                if (dr["FileSize"] != null && dr["FileSize"] != DBNull.Value)
                {
                    this.FileSize = Convert.ToString(dr["FileSize"]);
                }
            }

            
            if(CheckColumn(dr, "IsShare"))
            {
                if (dr["IsShare"] != null && dr["IsShare"] != DBNull.Value)
                {
                    this.IsShare = Convert.ToInt32(dr["IsShare"]);
                }
            }

            
            if(CheckColumn(dr, "IsDown"))
            {
                if (dr["IsDown"] != null && dr["IsDown"] != DBNull.Value)
                {
                    this.IsDown = Convert.ToInt32(dr["IsDown"]);
                }
            }

            
            if(CheckColumn(dr, "TagID"))
            {
                if (dr["TagID"] != null && dr["TagID"] != DBNull.Value)
                {
                    this.TagID = Convert.ToInt32(dr["TagID"]);
                }
            }

            
            if(CheckColumn(dr, "TypeID"))
            {
                if (dr["TypeID"] != null && dr["TypeID"] != DBNull.Value)
                {
                    this.TypeID = Convert.ToInt32(dr["TypeID"]);
                }
            }

            
            if(CheckColumn(dr, "ShareTime"))
            {
                if (dr["ShareTime"] != null && dr["ShareTime"] != DBNull.Value)
                {
                    this.ShareTime = Convert.ToDateTime(dr["ShareTime"]);
                }
            }

            
            if(CheckColumn(dr, "oldID"))
            {
                if (dr["oldID"] != null && dr["oldID"] != DBNull.Value)
                {
                    this.OldID = Convert.ToInt32(dr["oldID"]);
                }
            }

            
            if(CheckColumn(dr, "ChannelID"))
            {
                if (dr["ChannelID"] != null && dr["ChannelID"] != DBNull.Value)
                {
                    this.ChannelID = Convert.ToInt32(dr["ChannelID"]);
                }
            }

            
            if(CheckColumn(dr, "PcName"))
            {
                if (dr["PcName"] != null && dr["PcName"] != DBNull.Value)
                {
                    this.PcName = Convert.ToString(dr["PcName"]);
                }
            }

            
            if(CheckColumn(dr, "ChannelName"))
            {
                if (dr["ChannelName"] != null && dr["ChannelName"] != DBNull.Value)
                {
                    this.ChannelName = Convert.ToString(dr["ChannelName"]);
                }
            }

            
            if(CheckColumn(dr, "Pic"))
            {
                if (dr["Pic"] != null && dr["Pic"] != DBNull.Value)
                {
                    this.Pic = Convert.ToString(dr["Pic"]);
                }
            }

            
            if(CheckColumn(dr, "Brief1"))
            {
                if (dr["Brief1"] != null && dr["Brief1"] != DBNull.Value)
                {
                    this.Brief1 = Convert.ToString(dr["Brief1"]);
                }
            }

            
            if(CheckColumn(dr, "Brief2"))
            {
                if (dr["Brief2"] != null && dr["Brief2"] != DBNull.Value)
                {
                    this.Brief2 = Convert.ToString(dr["Brief2"]);
                }
            }

            

        }

        
        public string ExhibitionName
        {
            get
            {
                return this.m_exhibitionName;
            }
            set
            {
                exhibitionName_initialized = true;
                this.m_exhibitionName = value;
            }
        }
        
        public string TagName
        {
            get
            {
                return this.m_tagName;
            }
            set
            {
                tagName_initialized = true;
                this.m_tagName = value;
            }
        }
        
        public string ModeName
        {
            get
            {
                return this.m_modeName;
            }
            set
            {
                modeName_initialized = true;
                this.m_modeName = value;
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
        
        public string Files
        {
            get
            {
                return this.m_files;
            }
            set
            {
                files_initialized = true;
                this.m_files = value;
            }
        }
        
        public string Files1
        {
            get
            {
                return this.m_files1;
            }
            set
            {
                files1_initialized = true;
                this.m_files1 = value;
            }
        }
        
        public int PcID
        {
            get
            {
                return this.m_pcID;
            }
            set
            {
                pcID_initialized = true;
                this.m_pcID = value;
            }
        }
        
        public string JsonStr
        {
            get
            {
                return this.m_jsonStr;
            }
            set
            {
                jsonStr_initialized = true;
                this.m_jsonStr = value;
            }
        }
        
        public int Isjz
        {
            get
            {
                return this.m_isjz;
            }
            set
            {
                isjz_initialized = true;
                this.m_isjz = value;
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
        
        public string PicWord
        {
            get
            {
                return this.m_picWord;
            }
            set
            {
                picWord_initialized = true;
                this.m_picWord = value;
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
        
        public int FileType
        {
            get
            {
                return this.m_fileType;
            }
            set
            {
                fileType_initialized = true;
                this.m_fileType = value;
            }
        }
        
        public int IsPingBao
        {
            get
            {
                return this.m_isPingBao;
            }
            set
            {
                isPingBao_initialized = true;
                this.m_isPingBao = value;
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
        
        public int ModeID
        {
            get
            {
                return this.m_modeID;
            }
            set
            {
                modeID_initialized = true;
                this.m_modeID = value;
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
        
        public int IsShare
        {
            get
            {
                return this.m_isShare;
            }
            set
            {
                isShare_initialized = true;
                this.m_isShare = value;
            }
        }
        
        public int IsDown
        {
            get
            {
                return this.m_isDown;
            }
            set
            {
                isDown_initialized = true;
                this.m_isDown = value;
            }
        }
        
        public int TagID
        {
            get
            {
                return this.m_tagID;
            }
            set
            {
                tagID_initialized = true;
                this.m_tagID = value;
            }
        }
        
        public int TypeID
        {
            get
            {
                return this.m_typeID;
            }
            set
            {
                typeID_initialized = true;
                this.m_typeID = value;
            }
        }
        
        public DateTime ShareTime
        {
            get
            {
                return this.m_shareTime;
            }
            set
            {
                shareTime_initialized = true;
                this.m_shareTime = value;
            }
        }
        
        public int OldID
        {
            get
            {
                return this.m_oldID;
            }
            set
            {
                oldID_initialized = true;
                this.m_oldID = value;
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
        
        public string PcName
        {
            get
            {
                return this.m_pcName;
            }
            set
            {
                pcName_initialized = true;
                this.m_pcName = value;
            }
        }
        
        public string ChannelName
        {
            get
            {
                return this.m_channelName;
            }
            set
            {
                channelName_initialized = true;
                this.m_channelName = value;
            }
        }
        
        public string Pic
        {
            get
            {
                return this.m_pic;
            }
            set
            {
                pic_initialized = true;
                this.m_pic = value;
            }
        }
        
        public string Brief1
        {
            get
            {
                return this.m_brief1;
            }
            set
            {
                brief1_initialized = true;
                this.m_brief1 = value;
            }
        }
        
        public string Brief2
        {
            get
            {
                return this.m_brief2;
            }
            set
            {
                brief2_initialized = true;
                this.m_brief2 = value;
            }
        }
        


        /// <summary>
        /// 判断对象属性是否赋值。没有赋值返回true
        /// </summary>
        public bool IsNull
        {
            get
            {
                if (exhibitionName_initialized || tagName_initialized || modeName_initialized || iD_initialized || addID_initialized || addTime_initialized || title_initialized || files_initialized || files1_initialized || pcID_initialized || jsonStr_initialized || isjz_initialized || state_initialized || orderID_initialized || picWord_initialized || brief_initialized || fileType_initialized || isPingBao_initialized || exhibitionID_initialized || modeID_initialized || fileSize_initialized || isShare_initialized || isDown_initialized || tagID_initialized || typeID_initialized || shareTime_initialized || oldID_initialized || channelID_initialized || pcName_initialized || channelName_initialized || pic_initialized || brief1_initialized || brief2_initialized)
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
            
            if (exhibitionName_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ExhibitionName", SqlDbType.NVarChar);
                n_Parameter.Value = this.ExhibitionName;
                n_Parameter.SourceColumn = "ExhibitionName";
                parametersList.Add(n_Parameter);
            }
            
            if (tagName_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "TagName", SqlDbType.NVarChar);
                n_Parameter.Value = this.TagName;
                n_Parameter.SourceColumn = "TagName";
                parametersList.Add(n_Parameter);
            }
            
            if (modeName_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ModeName", SqlDbType.NVarChar);
                n_Parameter.Value = this.ModeName;
                n_Parameter.SourceColumn = "ModeName";
                parametersList.Add(n_Parameter);
            }
            
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
            
            if (title_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Title", SqlDbType.NVarChar);
                n_Parameter.Value = this.Title;
                n_Parameter.SourceColumn = "Title";
                parametersList.Add(n_Parameter);
            }
            
            if (files_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Files", SqlDbType.NVarChar);
                n_Parameter.Value = this.Files;
                n_Parameter.SourceColumn = "Files";
                parametersList.Add(n_Parameter);
            }
            
            if (files1_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Files1", SqlDbType.NVarChar);
                n_Parameter.Value = this.Files1;
                n_Parameter.SourceColumn = "Files1";
                parametersList.Add(n_Parameter);
            }
            
            if (pcID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "PcID", SqlDbType.Int);
                n_Parameter.Value = this.PcID;
                n_Parameter.SourceColumn = "PcID";
                parametersList.Add(n_Parameter);
            }
            
            if (jsonStr_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "JsonStr", SqlDbType.NVarChar);
                n_Parameter.Value = this.JsonStr;
                n_Parameter.SourceColumn = "JsonStr";
                parametersList.Add(n_Parameter);
            }
            
            if (isjz_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Isjz", SqlDbType.Int);
                n_Parameter.Value = this.Isjz;
                n_Parameter.SourceColumn = "Isjz";
                parametersList.Add(n_Parameter);
            }
            
            if (state_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "State", SqlDbType.Int);
                n_Parameter.Value = this.State;
                n_Parameter.SourceColumn = "State";
                parametersList.Add(n_Parameter);
            }
            
            if (orderID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "OrderID", SqlDbType.BigInt);
                n_Parameter.Value = this.OrderID;
                n_Parameter.SourceColumn = "OrderID";
                parametersList.Add(n_Parameter);
            }
            
            if (picWord_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "PicWord", SqlDbType.NVarChar);
                n_Parameter.Value = this.PicWord;
                n_Parameter.SourceColumn = "PicWord";
                parametersList.Add(n_Parameter);
            }
            
            if (brief_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Brief", SqlDbType.NVarChar);
                n_Parameter.Value = this.Brief;
                n_Parameter.SourceColumn = "Brief";
                parametersList.Add(n_Parameter);
            }
            
            if (fileType_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "FileType", SqlDbType.Int);
                n_Parameter.Value = this.FileType;
                n_Parameter.SourceColumn = "FileType";
                parametersList.Add(n_Parameter);
            }
            
            if (isPingBao_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "IsPingBao", SqlDbType.Int);
                n_Parameter.Value = this.IsPingBao;
                n_Parameter.SourceColumn = "IsPingBao";
                parametersList.Add(n_Parameter);
            }
            
            if (exhibitionID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ExhibitionID", SqlDbType.Int);
                n_Parameter.Value = this.ExhibitionID;
                n_Parameter.SourceColumn = "ExhibitionID";
                parametersList.Add(n_Parameter);
            }
            
            if (modeID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ModeID", SqlDbType.Int);
                n_Parameter.Value = this.ModeID;
                n_Parameter.SourceColumn = "ModeID";
                parametersList.Add(n_Parameter);
            }
            
            if (fileSize_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "FileSize", SqlDbType.NVarChar);
                n_Parameter.Value = this.FileSize;
                n_Parameter.SourceColumn = "FileSize";
                parametersList.Add(n_Parameter);
            }
            
            if (isShare_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "IsShare", SqlDbType.Int);
                n_Parameter.Value = this.IsShare;
                n_Parameter.SourceColumn = "IsShare";
                parametersList.Add(n_Parameter);
            }
            
            if (isDown_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "IsDown", SqlDbType.Int);
                n_Parameter.Value = this.IsDown;
                n_Parameter.SourceColumn = "IsDown";
                parametersList.Add(n_Parameter);
            }
            
            if (tagID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "TagID", SqlDbType.Int);
                n_Parameter.Value = this.TagID;
                n_Parameter.SourceColumn = "TagID";
                parametersList.Add(n_Parameter);
            }
            
            if (typeID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "TypeID", SqlDbType.Int);
                n_Parameter.Value = this.TypeID;
                n_Parameter.SourceColumn = "TypeID";
                parametersList.Add(n_Parameter);
            }
            
            if (shareTime_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ShareTime", SqlDbType.DateTime);
                n_Parameter.Value = this.ShareTime;
                n_Parameter.SourceColumn = "ShareTime";
                parametersList.Add(n_Parameter);
            }
            
            if (oldID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "oldID", SqlDbType.Int);
                n_Parameter.Value = this.OldID;
                n_Parameter.SourceColumn = "oldID";
                parametersList.Add(n_Parameter);
            }
            
            if (channelID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ChannelID", SqlDbType.Int);
                n_Parameter.Value = this.ChannelID;
                n_Parameter.SourceColumn = "ChannelID";
                parametersList.Add(n_Parameter);
            }
            
            if (pcName_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "PcName", SqlDbType.NVarChar);
                n_Parameter.Value = this.PcName;
                n_Parameter.SourceColumn = "PcName";
                parametersList.Add(n_Parameter);
            }
            
            if (channelName_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ChannelName", SqlDbType.NVarChar);
                n_Parameter.Value = this.ChannelName;
                n_Parameter.SourceColumn = "ChannelName";
                parametersList.Add(n_Parameter);
            }
            
            if (pic_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Pic", SqlDbType.NVarChar);
                n_Parameter.Value = this.Pic;
                n_Parameter.SourceColumn = "Pic";
                parametersList.Add(n_Parameter);
            }
            
            if (brief1_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Brief1", SqlDbType.NVarChar);
                n_Parameter.Value = this.Brief1;
                n_Parameter.SourceColumn = "Brief1";
                parametersList.Add(n_Parameter);
            }
            
            if (brief2_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Brief2", SqlDbType.NVarChar);
                n_Parameter.Value = this.Brief2;
                n_Parameter.SourceColumn = "Brief2";
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
                
                if (this.exhibitionName_initialized)
                {
                    contentText += ", [ExhibitionName]=@" + headStr + "ExhibitionName ";
                }
                
                if (this.tagName_initialized)
                {
                    contentText += ", [TagName]=@" + headStr + "TagName ";
                }
                
                if (this.modeName_initialized)
                {
                    contentText += ", [ModeName]=@" + headStr + "ModeName ";
                }
                
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
                
                if (this.title_initialized)
                {
                    contentText += ", [Title]=@" + headStr + "Title ";
                }
                
                if (this.files_initialized)
                {
                    contentText += ", [Files]=@" + headStr + "Files ";
                }
                
                if (this.files1_initialized)
                {
                    contentText += ", [Files1]=@" + headStr + "Files1 ";
                }
                
                if (this.pcID_initialized)
                {
                    contentText += ", [PcID]=@" + headStr + "PcID ";
                }
                
                if (this.jsonStr_initialized)
                {
                    contentText += ", [JsonStr]=@" + headStr + "JsonStr ";
                }
                
                if (this.isjz_initialized)
                {
                    contentText += ", [Isjz]=@" + headStr + "Isjz ";
                }
                
                if (this.state_initialized)
                {
                    contentText += ", [State]=@" + headStr + "State ";
                }
                
                if (this.orderID_initialized)
                {
                    contentText += ", [OrderID]=@" + headStr + "OrderID ";
                }
                
                if (this.picWord_initialized)
                {
                    contentText += ", [PicWord]=@" + headStr + "PicWord ";
                }
                
                if (this.brief_initialized)
                {
                    contentText += ", [Brief]=@" + headStr + "Brief ";
                }
                
                if (this.fileType_initialized)
                {
                    contentText += ", [FileType]=@" + headStr + "FileType ";
                }
                
                if (this.isPingBao_initialized)
                {
                    contentText += ", [IsPingBao]=@" + headStr + "IsPingBao ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    contentText += ", [ExhibitionID]=@" + headStr + "ExhibitionID ";
                }
                
                if (this.modeID_initialized)
                {
                    contentText += ", [ModeID]=@" + headStr + "ModeID ";
                }
                
                if (this.fileSize_initialized)
                {
                    contentText += ", [FileSize]=@" + headStr + "FileSize ";
                }
                
                if (this.isShare_initialized)
                {
                    contentText += ", [IsShare]=@" + headStr + "IsShare ";
                }
                
                if (this.isDown_initialized)
                {
                    contentText += ", [IsDown]=@" + headStr + "IsDown ";
                }
                
                if (this.tagID_initialized)
                {
                    contentText += ", [TagID]=@" + headStr + "TagID ";
                }
                
                if (this.typeID_initialized)
                {
                    contentText += ", [TypeID]=@" + headStr + "TypeID ";
                }
                
                if (this.shareTime_initialized)
                {
                    contentText += ", [ShareTime]=@" + headStr + "ShareTime ";
                }
                
                if (this.oldID_initialized)
                {
                    contentText += ", [oldID]=@" + headStr + "oldID ";
                }
                
                if (this.channelID_initialized)
                {
                    contentText += ", [ChannelID]=@" + headStr + "ChannelID ";
                }
                
                if (this.pcName_initialized)
                {
                    contentText += ", [PcName]=@" + headStr + "PcName ";
                }
                
                if (this.channelName_initialized)
                {
                    contentText += ", [ChannelName]=@" + headStr + "ChannelName ";
                }
                
                if (this.pic_initialized)
                {
                    contentText += ", [Pic]=@" + headStr + "Pic ";
                }
                
                if (this.brief1_initialized)
                {
                    contentText += ", [Brief1]=@" + headStr + "Brief1 ";
                }
                
                if (this.brief2_initialized)
                {
                    contentText += ", [Brief2]=@" + headStr + "Brief2 ";
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
                
                if (this.exhibitionName_initialized)
                {
                    conditionStr += " AND [ExhibitionName]=@" + headStr + "ExhibitionName ";
                }
                
                if (this.tagName_initialized)
                {
                    conditionStr += " AND [TagName]=@" + headStr + "TagName ";
                }
                
                if (this.modeName_initialized)
                {
                    conditionStr += " AND [ModeName]=@" + headStr + "ModeName ";
                }
                
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
                
                if (this.title_initialized)
                {
                    conditionStr += " AND [Title]=@" + headStr + "Title ";
                }
                
                if (this.files_initialized)
                {
                    conditionStr += " AND [Files]=@" + headStr + "Files ";
                }
                
                if (this.files1_initialized)
                {
                    conditionStr += " AND [Files1]=@" + headStr + "Files1 ";
                }
                
                if (this.pcID_initialized)
                {
                    conditionStr += " AND [PcID]=@" + headStr + "PcID ";
                }
                
                if (this.jsonStr_initialized)
                {
                    conditionStr += " AND [JsonStr]=@" + headStr + "JsonStr ";
                }
                
                if (this.isjz_initialized)
                {
                    conditionStr += " AND [Isjz]=@" + headStr + "Isjz ";
                }
                
                if (this.state_initialized)
                {
                    conditionStr += " AND [State]=@" + headStr + "State ";
                }
                
                if (this.orderID_initialized)
                {
                    conditionStr += " AND [OrderID]=@" + headStr + "OrderID ";
                }
                
                if (this.picWord_initialized)
                {
                    conditionStr += " AND [PicWord]=@" + headStr + "PicWord ";
                }
                
                if (this.brief_initialized)
                {
                    conditionStr += " AND [Brief]=@" + headStr + "Brief ";
                }
                
                if (this.fileType_initialized)
                {
                    conditionStr += " AND [FileType]=@" + headStr + "FileType ";
                }
                
                if (this.isPingBao_initialized)
                {
                    conditionStr += " AND [IsPingBao]=@" + headStr + "IsPingBao ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    conditionStr += " AND [ExhibitionID]=@" + headStr + "ExhibitionID ";
                }
                
                if (this.modeID_initialized)
                {
                    conditionStr += " AND [ModeID]=@" + headStr + "ModeID ";
                }
                
                if (this.fileSize_initialized)
                {
                    conditionStr += " AND [FileSize]=@" + headStr + "FileSize ";
                }
                
                if (this.isShare_initialized)
                {
                    conditionStr += " AND [IsShare]=@" + headStr + "IsShare ";
                }
                
                if (this.isDown_initialized)
                {
                    conditionStr += " AND [IsDown]=@" + headStr + "IsDown ";
                }
                
                if (this.tagID_initialized)
                {
                    conditionStr += " AND [TagID]=@" + headStr + "TagID ";
                }
                
                if (this.typeID_initialized)
                {
                    conditionStr += " AND [TypeID]=@" + headStr + "TypeID ";
                }
                
                if (this.shareTime_initialized)
                {
                    conditionStr += " AND [ShareTime]=@" + headStr + "ShareTime ";
                }
                
                if (this.oldID_initialized)
                {
                    conditionStr += " AND [oldID]=@" + headStr + "oldID ";
                }
                
                if (this.channelID_initialized)
                {
                    conditionStr += " AND [ChannelID]=@" + headStr + "ChannelID ";
                }
                
                if (this.pcName_initialized)
                {
                    conditionStr += " AND [PcName]=@" + headStr + "PcName ";
                }
                
                if (this.channelName_initialized)
                {
                    conditionStr += " AND [ChannelName]=@" + headStr + "ChannelName ";
                }
                
                if (this.pic_initialized)
                {
                    conditionStr += " AND [Pic]=@" + headStr + "Pic ";
                }
                
                if (this.brief1_initialized)
                {
                    conditionStr += " AND [Brief1]=@" + headStr + "Brief1 ";
                }
                
                if (this.brief2_initialized)
                {
                    conditionStr += " AND [Brief2]=@" + headStr + "Brief2 ";
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
                
                if (this.exhibitionName_initialized)
                {
                    contentText += ", [ExhibitionName] ";
                }
                
                if (this.tagName_initialized)
                {
                    contentText += ", [TagName] ";
                }
                
                if (this.modeName_initialized)
                {
                    contentText += ", [ModeName] ";
                }
                
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
                
                if (this.title_initialized)
                {
                    contentText += ", [Title] ";
                }
                
                if (this.files_initialized)
                {
                    contentText += ", [Files] ";
                }
                
                if (this.files1_initialized)
                {
                    contentText += ", [Files1] ";
                }
                
                if (this.pcID_initialized)
                {
                    contentText += ", [PcID] ";
                }
                
                if (this.jsonStr_initialized)
                {
                    contentText += ", [JsonStr] ";
                }
                
                if (this.isjz_initialized)
                {
                    contentText += ", [Isjz] ";
                }
                
                if (this.state_initialized)
                {
                    contentText += ", [State] ";
                }
                
                if (this.orderID_initialized)
                {
                    contentText += ", [OrderID] ";
                }
                
                if (this.picWord_initialized)
                {
                    contentText += ", [PicWord] ";
                }
                
                if (this.brief_initialized)
                {
                    contentText += ", [Brief] ";
                }
                
                if (this.fileType_initialized)
                {
                    contentText += ", [FileType] ";
                }
                
                if (this.isPingBao_initialized)
                {
                    contentText += ", [IsPingBao] ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    contentText += ", [ExhibitionID] ";
                }
                
                if (this.modeID_initialized)
                {
                    contentText += ", [ModeID] ";
                }
                
                if (this.fileSize_initialized)
                {
                    contentText += ", [FileSize] ";
                }
                
                if (this.isShare_initialized)
                {
                    contentText += ", [IsShare] ";
                }
                
                if (this.isDown_initialized)
                {
                    contentText += ", [IsDown] ";
                }
                
                if (this.tagID_initialized)
                {
                    contentText += ", [TagID] ";
                }
                
                if (this.typeID_initialized)
                {
                    contentText += ", [TypeID] ";
                }
                
                if (this.shareTime_initialized)
                {
                    contentText += ", [ShareTime] ";
                }
                
                if (this.oldID_initialized)
                {
                    contentText += ", [oldID] ";
                }
                
                if (this.channelID_initialized)
                {
                    contentText += ", [ChannelID] ";
                }
                
                if (this.pcName_initialized)
                {
                    contentText += ", [PcName] ";
                }
                
                if (this.channelName_initialized)
                {
                    contentText += ", [ChannelName] ";
                }
                
                if (this.pic_initialized)
                {
                    contentText += ", [Pic] ";
                }
                
                if (this.brief1_initialized)
                {
                    contentText += ", [Brief1] ";
                }
                
                if (this.brief2_initialized)
                {
                    contentText += ", [Brief2] ";
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
                
                if (this.exhibitionName_initialized)
                {
                    contentText += ", @" + headStr + "ExhibitionName ";
                }
                
                if (this.tagName_initialized)
                {
                    contentText += ", @" + headStr + "TagName ";
                }
                
                if (this.modeName_initialized)
                {
                    contentText += ", @" + headStr + "ModeName ";
                }
                
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
                
                if (this.title_initialized)
                {
                    contentText += ", @" + headStr + "Title ";
                }
                
                if (this.files_initialized)
                {
                    contentText += ", @" + headStr + "Files ";
                }
                
                if (this.files1_initialized)
                {
                    contentText += ", @" + headStr + "Files1 ";
                }
                
                if (this.pcID_initialized)
                {
                    contentText += ", @" + headStr + "PcID ";
                }
                
                if (this.jsonStr_initialized)
                {
                    contentText += ", @" + headStr + "JsonStr ";
                }
                
                if (this.isjz_initialized)
                {
                    contentText += ", @" + headStr + "Isjz ";
                }
                
                if (this.state_initialized)
                {
                    contentText += ", @" + headStr + "State ";
                }
                
                if (this.orderID_initialized)
                {
                    contentText += ", @" + headStr + "OrderID ";
                }
                
                if (this.picWord_initialized)
                {
                    contentText += ", @" + headStr + "PicWord ";
                }
                
                if (this.brief_initialized)
                {
                    contentText += ", @" + headStr + "Brief ";
                }
                
                if (this.fileType_initialized)
                {
                    contentText += ", @" + headStr + "FileType ";
                }
                
                if (this.isPingBao_initialized)
                {
                    contentText += ", @" + headStr + "IsPingBao ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    contentText += ", @" + headStr + "ExhibitionID ";
                }
                
                if (this.modeID_initialized)
                {
                    contentText += ", @" + headStr + "ModeID ";
                }
                
                if (this.fileSize_initialized)
                {
                    contentText += ", @" + headStr + "FileSize ";
                }
                
                if (this.isShare_initialized)
                {
                    contentText += ", @" + headStr + "IsShare ";
                }
                
                if (this.isDown_initialized)
                {
                    contentText += ", @" + headStr + "IsDown ";
                }
                
                if (this.tagID_initialized)
                {
                    contentText += ", @" + headStr + "TagID ";
                }
                
                if (this.typeID_initialized)
                {
                    contentText += ", @" + headStr + "TypeID ";
                }
                
                if (this.shareTime_initialized)
                {
                    contentText += ", @" + headStr + "ShareTime ";
                }
                
                if (this.oldID_initialized)
                {
                    contentText += ", @" + headStr + "oldID ";
                }
                
                if (this.channelID_initialized)
                {
                    contentText += ", @" + headStr + "ChannelID ";
                }
                
                if (this.pcName_initialized)
                {
                    contentText += ", @" + headStr + "PcName ";
                }
                
                if (this.channelName_initialized)
                {
                    contentText += ", @" + headStr + "ChannelName ";
                }
                
                if (this.pic_initialized)
                {
                    contentText += ", @" + headStr + "Pic ";
                }
                
                if (this.brief1_initialized)
                {
                    contentText += ", @" + headStr + "Brief1 ";
                }
                
                if (this.brief2_initialized)
                {
                    contentText += ", @" + headStr + "Brief2 ";
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
            string tableName = "View_News";
            return tableName;
        }

        /// <summary>
        /// 获取第一列名称
        /// </summary>
        /// <returns></returns>
        public string FirstColumn()
        {
            string firstColumn = "ExhibitionName";
            return firstColumn;
        }

        /// <summary>
        /// 设置所有列为已赋值
        /// </summary>
        /// <returns></returns>
        public void AllInitialized()
        {
            
            this.exhibitionName_initialized = true;
            
            this.tagName_initialized = true;
            
            this.modeName_initialized = true;
            
            this.iD_initialized = true;
            
            this.addID_initialized = true;
            
            this.addTime_initialized = true;
            
            this.title_initialized = true;
            
            this.files_initialized = true;
            
            this.files1_initialized = true;
            
            this.pcID_initialized = true;
            
            this.jsonStr_initialized = true;
            
            this.isjz_initialized = true;
            
            this.state_initialized = true;
            
            this.orderID_initialized = true;
            
            this.picWord_initialized = true;
            
            this.brief_initialized = true;
            
            this.fileType_initialized = true;
            
            this.isPingBao_initialized = true;
            
            this.exhibitionID_initialized = true;
            
            this.modeID_initialized = true;
            
            this.fileSize_initialized = true;
            
            this.isShare_initialized = true;
            
            this.isDown_initialized = true;
            
            this.tagID_initialized = true;
            
            this.typeID_initialized = true;
            
            this.shareTime_initialized = true;
            
            this.oldID_initialized = true;
            
            this.channelID_initialized = true;
            
            this.pcName_initialized = true;
            
            this.channelName_initialized = true;
            
            this.pic_initialized = true;
            
            this.brief1_initialized = true;
            
            this.brief2_initialized = true;
            
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
            
            if(page.Request["exhibitionName"] != null)
            {
                if (this.exhibitionName_initialized)
                {
                    if(page.Request["exhibitionName"] != "")
                    {
                        this.ExhibitionName = Convert.ToString(page.Request["exhibitionName"]);
                    }
                    else
                    {
                        this.exhibitionName_initialized = false;
                    }
                }
                else
                {
                    this.ExhibitionName = Convert.ToString(page.Request["exhibitionName"]);
                }
            }

            
            if(page.Request["tagName"] != null)
            {
                if (this.tagName_initialized)
                {
                    if(page.Request["tagName"] != "")
                    {
                        this.TagName = Convert.ToString(page.Request["tagName"]);
                    }
                    else
                    {
                        this.tagName_initialized = false;
                    }
                }
                else
                {
                    this.TagName = Convert.ToString(page.Request["tagName"]);
                }
            }

            
            if(page.Request["modeName"] != null)
            {
                if (this.modeName_initialized)
                {
                    if(page.Request["modeName"] != "")
                    {
                        this.ModeName = Convert.ToString(page.Request["modeName"]);
                    }
                    else
                    {
                        this.modeName_initialized = false;
                    }
                }
                else
                {
                    this.ModeName = Convert.ToString(page.Request["modeName"]);
                }
            }

            
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

            
            if(page.Request["files"] != null)
            {
                if (this.files_initialized)
                {
                    if(page.Request["files"] != "")
                    {
                        this.Files = Convert.ToString(page.Request["files"]);
                    }
                    else
                    {
                        this.files_initialized = false;
                    }
                }
                else
                {
                    this.Files = Convert.ToString(page.Request["files"]);
                }
            }

            
            if(page.Request["files1"] != null)
            {
                if (this.files1_initialized)
                {
                    if(page.Request["files1"] != "")
                    {
                        this.Files1 = Convert.ToString(page.Request["files1"]);
                    }
                    else
                    {
                        this.files1_initialized = false;
                    }
                }
                else
                {
                    this.Files1 = Convert.ToString(page.Request["files1"]);
                }
            }

            
            if(page.Request["pcID"] != null)
            {
                if (this.pcID_initialized)
                {
                    if(page.Request["pcID"] != "")
                    {
                        this.PcID = Convert.ToInt32(page.Request["pcID"]);
                    }
                    else
                    {
                        this.pcID_initialized = false;
                    }
                }
                else
                {
                    this.PcID = Convert.ToInt32(page.Request["pcID"]);
                }
            }

            
            if(page.Request["jsonStr"] != null)
            {
                if (this.jsonStr_initialized)
                {
                    if(page.Request["jsonStr"] != "")
                    {
                        this.JsonStr = Convert.ToString(page.Request["jsonStr"]);
                    }
                    else
                    {
                        this.jsonStr_initialized = false;
                    }
                }
                else
                {
                    this.JsonStr = Convert.ToString(page.Request["jsonStr"]);
                }
            }

            
            if(page.Request["isjz"] != null)
            {
                if (this.isjz_initialized)
                {
                    if(page.Request["isjz"] != "")
                    {
                        this.Isjz = Convert.ToInt32(page.Request["isjz"]);
                    }
                    else
                    {
                        this.isjz_initialized = false;
                    }
                }
                else
                {
                    this.Isjz = Convert.ToInt32(page.Request["isjz"]);
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

            
            if(page.Request["picWord"] != null)
            {
                if (this.picWord_initialized)
                {
                    if(page.Request["picWord"] != "")
                    {
                        this.PicWord = Convert.ToString(page.Request["picWord"]);
                    }
                    else
                    {
                        this.picWord_initialized = false;
                    }
                }
                else
                {
                    this.PicWord = Convert.ToString(page.Request["picWord"]);
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

            
            if(page.Request["fileType"] != null)
            {
                if (this.fileType_initialized)
                {
                    if(page.Request["fileType"] != "")
                    {
                        this.FileType = Convert.ToInt32(page.Request["fileType"]);
                    }
                    else
                    {
                        this.fileType_initialized = false;
                    }
                }
                else
                {
                    this.FileType = Convert.ToInt32(page.Request["fileType"]);
                }
            }

            
            if(page.Request["isPingBao"] != null)
            {
                if (this.isPingBao_initialized)
                {
                    if(page.Request["isPingBao"] != "")
                    {
                        this.IsPingBao = Convert.ToInt32(page.Request["isPingBao"]);
                    }
                    else
                    {
                        this.isPingBao_initialized = false;
                    }
                }
                else
                {
                    this.IsPingBao = Convert.ToInt32(page.Request["isPingBao"]);
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

            
            if(page.Request["modeID"] != null)
            {
                if (this.modeID_initialized)
                {
                    if(page.Request["modeID"] != "")
                    {
                        this.ModeID = Convert.ToInt32(page.Request["modeID"]);
                    }
                    else
                    {
                        this.modeID_initialized = false;
                    }
                }
                else
                {
                    this.ModeID = Convert.ToInt32(page.Request["modeID"]);
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

            
            if(page.Request["isShare"] != null)
            {
                if (this.isShare_initialized)
                {
                    if(page.Request["isShare"] != "")
                    {
                        this.IsShare = Convert.ToInt32(page.Request["isShare"]);
                    }
                    else
                    {
                        this.isShare_initialized = false;
                    }
                }
                else
                {
                    this.IsShare = Convert.ToInt32(page.Request["isShare"]);
                }
            }

            
            if(page.Request["isDown"] != null)
            {
                if (this.isDown_initialized)
                {
                    if(page.Request["isDown"] != "")
                    {
                        this.IsDown = Convert.ToInt32(page.Request["isDown"]);
                    }
                    else
                    {
                        this.isDown_initialized = false;
                    }
                }
                else
                {
                    this.IsDown = Convert.ToInt32(page.Request["isDown"]);
                }
            }

            
            if(page.Request["tagID"] != null)
            {
                if (this.tagID_initialized)
                {
                    if(page.Request["tagID"] != "")
                    {
                        this.TagID = Convert.ToInt32(page.Request["tagID"]);
                    }
                    else
                    {
                        this.tagID_initialized = false;
                    }
                }
                else
                {
                    this.TagID = Convert.ToInt32(page.Request["tagID"]);
                }
            }

            
            if(page.Request["typeID"] != null)
            {
                if (this.typeID_initialized)
                {
                    if(page.Request["typeID"] != "")
                    {
                        this.TypeID = Convert.ToInt32(page.Request["typeID"]);
                    }
                    else
                    {
                        this.typeID_initialized = false;
                    }
                }
                else
                {
                    this.TypeID = Convert.ToInt32(page.Request["typeID"]);
                }
            }

            
            if(page.Request["shareTime"] != null)
            {
                if (this.shareTime_initialized)
                {
                    if(page.Request["shareTime"] != "")
                    {
                        this.ShareTime = Convert.ToDateTime(page.Request["shareTime"]);
                    }
                    else
                    {
                        this.shareTime_initialized = false;
                    }
                }
                else
                {
                    this.ShareTime = Convert.ToDateTime(page.Request["shareTime"]);
                }
            }

            
            if(page.Request["oldID"] != null)
            {
                if (this.oldID_initialized)
                {
                    if(page.Request["oldID"] != "")
                    {
                        this.OldID = Convert.ToInt32(page.Request["oldID"]);
                    }
                    else
                    {
                        this.oldID_initialized = false;
                    }
                }
                else
                {
                    this.OldID = Convert.ToInt32(page.Request["oldID"]);
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

            
            if(page.Request["pcName"] != null)
            {
                if (this.pcName_initialized)
                {
                    if(page.Request["pcName"] != "")
                    {
                        this.PcName = Convert.ToString(page.Request["pcName"]);
                    }
                    else
                    {
                        this.pcName_initialized = false;
                    }
                }
                else
                {
                    this.PcName = Convert.ToString(page.Request["pcName"]);
                }
            }

            
            if(page.Request["channelName"] != null)
            {
                if (this.channelName_initialized)
                {
                    if(page.Request["channelName"] != "")
                    {
                        this.ChannelName = Convert.ToString(page.Request["channelName"]);
                    }
                    else
                    {
                        this.channelName_initialized = false;
                    }
                }
                else
                {
                    this.ChannelName = Convert.ToString(page.Request["channelName"]);
                }
            }

            
            if(page.Request["pic"] != null)
            {
                if (this.pic_initialized)
                {
                    if(page.Request["pic"] != "")
                    {
                        this.Pic = Convert.ToString(page.Request["pic"]);
                    }
                    else
                    {
                        this.pic_initialized = false;
                    }
                }
                else
                {
                    this.Pic = Convert.ToString(page.Request["pic"]);
                }
            }

            
            if(page.Request["brief1"] != null)
            {
                if (this.brief1_initialized)
                {
                    if(page.Request["brief1"] != "")
                    {
                        this.Brief1 = Convert.ToString(page.Request["brief1"]);
                    }
                    else
                    {
                        this.brief1_initialized = false;
                    }
                }
                else
                {
                    this.Brief1 = Convert.ToString(page.Request["brief1"]);
                }
            }

            
            if(page.Request["brief2"] != null)
            {
                if (this.brief2_initialized)
                {
                    if(page.Request["brief2"] != "")
                    {
                        this.Brief2 = Convert.ToString(page.Request["brief2"]);
                    }
                    else
                    {
                        this.brief2_initialized = false;
                    }
                }
                else
                {
                    this.Brief2 = Convert.ToString(page.Request["brief2"]);
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