/************************************************************

  Copyright (c) 2008，
  Author:               Date: 2020/8/12 14:22:14
  Description:    数据表Light对应的业务逻辑层
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
    /// 与Light数据表对应对象
    /// </summary>
    public class Light : IDateBuildTable
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
        
        private string m_title;
        private bool title_initialized = false;
        
        private int m_typeID;
        private bool typeID_initialized = false;
        
        private int m_areaID;
        private bool areaID_initialized = false;
        
        private string m_switchIP;
        private bool switchIP_initialized = false;
        
        private int m_switchPort;
        private bool switchPort_initialized = false;
        
        private int m_switchIndex;
        private bool switchIndex_initialized = false;
        
        private int m_switchGroup;
        private bool switchGroup_initialized = false;
        
        private long m_orderID;
        private bool orderID_initialized = false;
        
        private int m_state;
        private bool state_initialized = false;
        
        private string m_brief;
        private bool brief_initialized = false;
        
        private int m_isdele;
        private bool isdele_initialized = false;
        
        private int m_exhibitionID;
        private bool exhibitionID_initialized = false;
        
        private double m_x;
        private bool x_initialized = false;
        
        private double m_y;
        private bool y_initialized = false;
        

        public Light()
        {
        }

        public Light(int iD, int addID, DateTime addTime, string title, int typeID, int areaID, string switchIP, int switchPort, int switchIndex, int switchGroup, long orderID, int state, string brief, int isdele, int exhibitionID, double x, double y)
        {
            
            this.ID = iD;
            
            this.AddID = addID;
            
            this.AddTime = addTime;
            
            this.Title = title;
            
            this.TypeID = typeID;
            
            this.AreaID = areaID;
            
            this.SwitchIP = switchIP;
            
            this.SwitchPort = switchPort;
            
            this.SwitchIndex = switchIndex;
            
            this.SwitchGroup = switchGroup;
            
            this.OrderID = orderID;
            
            this.State = state;
            
            this.Brief = brief;
            
            this.Isdele = isdele;
            
            this.ExhibitionID = exhibitionID;
            
            this.X = x;
            
            this.Y = y;
            
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

            
            if(CheckColumn(dr, "Title"))
            {
                if (dr["Title"] != null && dr["Title"] != DBNull.Value)
                {
                    this.Title = Convert.ToString(dr["Title"]);
                }
            }

            
            if(CheckColumn(dr, "TypeID"))
            {
                if (dr["TypeID"] != null && dr["TypeID"] != DBNull.Value)
                {
                    this.TypeID = Convert.ToInt32(dr["TypeID"]);
                }
            }

            
            if(CheckColumn(dr, "AreaID"))
            {
                if (dr["AreaID"] != null && dr["AreaID"] != DBNull.Value)
                {
                    this.AreaID = Convert.ToInt32(dr["AreaID"]);
                }
            }

            
            if(CheckColumn(dr, "SwitchIP"))
            {
                if (dr["SwitchIP"] != null && dr["SwitchIP"] != DBNull.Value)
                {
                    this.SwitchIP = Convert.ToString(dr["SwitchIP"]);
                }
            }

            
            if(CheckColumn(dr, "SwitchPort"))
            {
                if (dr["SwitchPort"] != null && dr["SwitchPort"] != DBNull.Value)
                {
                    this.SwitchPort = Convert.ToInt32(dr["SwitchPort"]);
                }
            }

            
            if(CheckColumn(dr, "SwitchIndex"))
            {
                if (dr["SwitchIndex"] != null && dr["SwitchIndex"] != DBNull.Value)
                {
                    this.SwitchIndex = Convert.ToInt32(dr["SwitchIndex"]);
                }
            }

            
            if(CheckColumn(dr, "SwitchGroup"))
            {
                if (dr["SwitchGroup"] != null && dr["SwitchGroup"] != DBNull.Value)
                {
                    this.SwitchGroup = Convert.ToInt32(dr["SwitchGroup"]);
                }
            }

            
            if(CheckColumn(dr, "OrderID"))
            {
                if (dr["OrderID"] != null && dr["OrderID"] != DBNull.Value)
                {
                    this.OrderID = Convert.ToInt64(dr["OrderID"]);
                }
            }

            
            if(CheckColumn(dr, "State"))
            {
                if (dr["State"] != null && dr["State"] != DBNull.Value)
                {
                    this.State = Convert.ToInt32(dr["State"]);
                }
            }

            
            if(CheckColumn(dr, "Brief"))
            {
                if (dr["Brief"] != null && dr["Brief"] != DBNull.Value)
                {
                    this.Brief = Convert.ToString(dr["Brief"]);
                }
            }

            
            if(CheckColumn(dr, "Isdele"))
            {
                if (dr["Isdele"] != null && dr["Isdele"] != DBNull.Value)
                {
                    this.Isdele = Convert.ToInt32(dr["Isdele"]);
                }
            }

            
            if(CheckColumn(dr, "ExhibitionID"))
            {
                if (dr["ExhibitionID"] != null && dr["ExhibitionID"] != DBNull.Value)
                {
                    this.ExhibitionID = Convert.ToInt32(dr["ExhibitionID"]);
                }
            }

            
            if(CheckColumn(dr, "X"))
            {
                if (dr["X"] != null && dr["X"] != DBNull.Value)
                {
                    this.X = Convert.ToDouble(dr["X"]);
                }
            }

            
            if(CheckColumn(dr, "Y"))
            {
                if (dr["Y"] != null && dr["Y"] != DBNull.Value)
                {
                    this.Y = Convert.ToDouble(dr["Y"]);
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
        
        public int AreaID
        {
            get
            {
                return this.m_areaID;
            }
            set
            {
                areaID_initialized = true;
                this.m_areaID = value;
            }
        }
        
        public string SwitchIP
        {
            get
            {
                return this.m_switchIP;
            }
            set
            {
                switchIP_initialized = true;
                this.m_switchIP = value;
            }
        }
        
        public int SwitchPort
        {
            get
            {
                return this.m_switchPort;
            }
            set
            {
                switchPort_initialized = true;
                this.m_switchPort = value;
            }
        }
        
        public int SwitchIndex
        {
            get
            {
                return this.m_switchIndex;
            }
            set
            {
                switchIndex_initialized = true;
                this.m_switchIndex = value;
            }
        }
        
        public int SwitchGroup
        {
            get
            {
                return this.m_switchGroup;
            }
            set
            {
                switchGroup_initialized = true;
                this.m_switchGroup = value;
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
        
        public int Isdele
        {
            get
            {
                return this.m_isdele;
            }
            set
            {
                isdele_initialized = true;
                this.m_isdele = value;
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
        
        public double X
        {
            get
            {
                return this.m_x;
            }
            set
            {
                x_initialized = true;
                this.m_x = value;
            }
        }
        
        public double Y
        {
            get
            {
                return this.m_y;
            }
            set
            {
                y_initialized = true;
                this.m_y = value;
            }
        }
        


        /// <summary>
        /// 判断对象属性是否赋值。没有赋值返回true
        /// </summary>
        public bool IsNull
        {
            get
            {
                if (iD_initialized || addID_initialized || addTime_initialized || title_initialized || typeID_initialized || areaID_initialized || switchIP_initialized || switchPort_initialized || switchIndex_initialized || switchGroup_initialized || orderID_initialized || state_initialized || brief_initialized || isdele_initialized || exhibitionID_initialized || x_initialized || y_initialized)
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
            
            if (title_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Title", SqlDbType.NVarChar);
                n_Parameter.Value = this.Title;
                n_Parameter.SourceColumn = "Title";
                parametersList.Add(n_Parameter);
            }
            
            if (typeID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "TypeID", SqlDbType.Int);
                n_Parameter.Value = this.TypeID;
                n_Parameter.SourceColumn = "TypeID";
                parametersList.Add(n_Parameter);
            }
            
            if (areaID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "AreaID", SqlDbType.Int);
                n_Parameter.Value = this.AreaID;
                n_Parameter.SourceColumn = "AreaID";
                parametersList.Add(n_Parameter);
            }
            
            if (switchIP_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "SwitchIP", SqlDbType.NVarChar);
                n_Parameter.Value = this.SwitchIP;
                n_Parameter.SourceColumn = "SwitchIP";
                parametersList.Add(n_Parameter);
            }
            
            if (switchPort_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "SwitchPort", SqlDbType.Int);
                n_Parameter.Value = this.SwitchPort;
                n_Parameter.SourceColumn = "SwitchPort";
                parametersList.Add(n_Parameter);
            }
            
            if (switchIndex_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "SwitchIndex", SqlDbType.Int);
                n_Parameter.Value = this.SwitchIndex;
                n_Parameter.SourceColumn = "SwitchIndex";
                parametersList.Add(n_Parameter);
            }
            
            if (switchGroup_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "SwitchGroup", SqlDbType.Int);
                n_Parameter.Value = this.SwitchGroup;
                n_Parameter.SourceColumn = "SwitchGroup";
                parametersList.Add(n_Parameter);
            }
            
            if (orderID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "OrderID", SqlDbType.BigInt);
                n_Parameter.Value = this.OrderID;
                n_Parameter.SourceColumn = "OrderID";
                parametersList.Add(n_Parameter);
            }
            
            if (state_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "State", SqlDbType.Int);
                n_Parameter.Value = this.State;
                n_Parameter.SourceColumn = "State";
                parametersList.Add(n_Parameter);
            }
            
            if (brief_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Brief", SqlDbType.NVarChar);
                n_Parameter.Value = this.Brief;
                n_Parameter.SourceColumn = "Brief";
                parametersList.Add(n_Parameter);
            }
            
            if (isdele_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Isdele", SqlDbType.Int);
                n_Parameter.Value = this.Isdele;
                n_Parameter.SourceColumn = "Isdele";
                parametersList.Add(n_Parameter);
            }
            
            if (exhibitionID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ExhibitionID", SqlDbType.Int);
                n_Parameter.Value = this.ExhibitionID;
                n_Parameter.SourceColumn = "ExhibitionID";
                parametersList.Add(n_Parameter);
            }
            
            if (x_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "X", SqlDbType.Float);
                n_Parameter.Value = this.X;
                n_Parameter.SourceColumn = "X";
                parametersList.Add(n_Parameter);
            }
            
            if (y_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Y", SqlDbType.Float);
                n_Parameter.Value = this.Y;
                n_Parameter.SourceColumn = "Y";
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
                
                if (this.title_initialized)
                {
                    contentText += ", [Title]=@" + headStr + "Title ";
                }
                
                if (this.typeID_initialized)
                {
                    contentText += ", [TypeID]=@" + headStr + "TypeID ";
                }
                
                if (this.areaID_initialized)
                {
                    contentText += ", [AreaID]=@" + headStr + "AreaID ";
                }
                
                if (this.switchIP_initialized)
                {
                    contentText += ", [SwitchIP]=@" + headStr + "SwitchIP ";
                }
                
                if (this.switchPort_initialized)
                {
                    contentText += ", [SwitchPort]=@" + headStr + "SwitchPort ";
                }
                
                if (this.switchIndex_initialized)
                {
                    contentText += ", [SwitchIndex]=@" + headStr + "SwitchIndex ";
                }
                
                if (this.switchGroup_initialized)
                {
                    contentText += ", [SwitchGroup]=@" + headStr + "SwitchGroup ";
                }
                
                if (this.orderID_initialized)
                {
                    contentText += ", [OrderID]=@" + headStr + "OrderID ";
                }
                
                if (this.state_initialized)
                {
                    contentText += ", [State]=@" + headStr + "State ";
                }
                
                if (this.brief_initialized)
                {
                    contentText += ", [Brief]=@" + headStr + "Brief ";
                }
                
                if (this.isdele_initialized)
                {
                    contentText += ", [Isdele]=@" + headStr + "Isdele ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    contentText += ", [ExhibitionID]=@" + headStr + "ExhibitionID ";
                }
                
                if (this.x_initialized)
                {
                    contentText += ", [X]=@" + headStr + "X ";
                }
                
                if (this.y_initialized)
                {
                    contentText += ", [Y]=@" + headStr + "Y ";
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
                
                if (this.title_initialized)
                {
                    conditionStr += " AND [Title]=@" + headStr + "Title ";
                }
                
                if (this.typeID_initialized)
                {
                    conditionStr += " AND [TypeID]=@" + headStr + "TypeID ";
                }
                
                if (this.areaID_initialized)
                {
                    conditionStr += " AND [AreaID]=@" + headStr + "AreaID ";
                }
                
                if (this.switchIP_initialized)
                {
                    conditionStr += " AND [SwitchIP]=@" + headStr + "SwitchIP ";
                }
                
                if (this.switchPort_initialized)
                {
                    conditionStr += " AND [SwitchPort]=@" + headStr + "SwitchPort ";
                }
                
                if (this.switchIndex_initialized)
                {
                    conditionStr += " AND [SwitchIndex]=@" + headStr + "SwitchIndex ";
                }
                
                if (this.switchGroup_initialized)
                {
                    conditionStr += " AND [SwitchGroup]=@" + headStr + "SwitchGroup ";
                }
                
                if (this.orderID_initialized)
                {
                    conditionStr += " AND [OrderID]=@" + headStr + "OrderID ";
                }
                
                if (this.state_initialized)
                {
                    conditionStr += " AND [State]=@" + headStr + "State ";
                }
                
                if (this.brief_initialized)
                {
                    conditionStr += " AND [Brief]=@" + headStr + "Brief ";
                }
                
                if (this.isdele_initialized)
                {
                    conditionStr += " AND [Isdele]=@" + headStr + "Isdele ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    conditionStr += " AND [ExhibitionID]=@" + headStr + "ExhibitionID ";
                }
                
                if (this.x_initialized)
                {
                    conditionStr += " AND [X]=@" + headStr + "X ";
                }
                
                if (this.y_initialized)
                {
                    conditionStr += " AND [Y]=@" + headStr + "Y ";
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
                
                if (this.title_initialized)
                {
                    contentText += ", [Title] ";
                }
                
                if (this.typeID_initialized)
                {
                    contentText += ", [TypeID] ";
                }
                
                if (this.areaID_initialized)
                {
                    contentText += ", [AreaID] ";
                }
                
                if (this.switchIP_initialized)
                {
                    contentText += ", [SwitchIP] ";
                }
                
                if (this.switchPort_initialized)
                {
                    contentText += ", [SwitchPort] ";
                }
                
                if (this.switchIndex_initialized)
                {
                    contentText += ", [SwitchIndex] ";
                }
                
                if (this.switchGroup_initialized)
                {
                    contentText += ", [SwitchGroup] ";
                }
                
                if (this.orderID_initialized)
                {
                    contentText += ", [OrderID] ";
                }
                
                if (this.state_initialized)
                {
                    contentText += ", [State] ";
                }
                
                if (this.brief_initialized)
                {
                    contentText += ", [Brief] ";
                }
                
                if (this.isdele_initialized)
                {
                    contentText += ", [Isdele] ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    contentText += ", [ExhibitionID] ";
                }
                
                if (this.x_initialized)
                {
                    contentText += ", [X] ";
                }
                
                if (this.y_initialized)
                {
                    contentText += ", [Y] ";
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
                
                if (this.title_initialized)
                {
                    contentText += ", @" + headStr + "Title ";
                }
                
                if (this.typeID_initialized)
                {
                    contentText += ", @" + headStr + "TypeID ";
                }
                
                if (this.areaID_initialized)
                {
                    contentText += ", @" + headStr + "AreaID ";
                }
                
                if (this.switchIP_initialized)
                {
                    contentText += ", @" + headStr + "SwitchIP ";
                }
                
                if (this.switchPort_initialized)
                {
                    contentText += ", @" + headStr + "SwitchPort ";
                }
                
                if (this.switchIndex_initialized)
                {
                    contentText += ", @" + headStr + "SwitchIndex ";
                }
                
                if (this.switchGroup_initialized)
                {
                    contentText += ", @" + headStr + "SwitchGroup ";
                }
                
                if (this.orderID_initialized)
                {
                    contentText += ", @" + headStr + "OrderID ";
                }
                
                if (this.state_initialized)
                {
                    contentText += ", @" + headStr + "State ";
                }
                
                if (this.brief_initialized)
                {
                    contentText += ", @" + headStr + "Brief ";
                }
                
                if (this.isdele_initialized)
                {
                    contentText += ", @" + headStr + "Isdele ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    contentText += ", @" + headStr + "ExhibitionID ";
                }
                
                if (this.x_initialized)
                {
                    contentText += ", @" + headStr + "X ";
                }
                
                if (this.y_initialized)
                {
                    contentText += ", @" + headStr + "Y ";
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
            string tableName = "Light";
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
            
            this.title_initialized = true;
            
            this.typeID_initialized = true;
            
            this.areaID_initialized = true;
            
            this.switchIP_initialized = true;
            
            this.switchPort_initialized = true;
            
            this.switchIndex_initialized = true;
            
            this.switchGroup_initialized = true;
            
            this.orderID_initialized = true;
            
            this.state_initialized = true;
            
            this.brief_initialized = true;
            
            this.isdele_initialized = true;
            
            this.exhibitionID_initialized = true;
            
            this.x_initialized = true;
            
            this.y_initialized = true;
            
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

            
            if(page.Request["areaID"] != null)
            {
                if (this.areaID_initialized)
                {
                    if(page.Request["areaID"] != "")
                    {
                        this.AreaID = Convert.ToInt32(page.Request["areaID"]);
                    }
                    else
                    {
                        this.areaID_initialized = false;
                    }
                }
                else
                {
                    this.AreaID = Convert.ToInt32(page.Request["areaID"]);
                }
            }

            
            if(page.Request["switchIP"] != null)
            {
                if (this.switchIP_initialized)
                {
                    if(page.Request["switchIP"] != "")
                    {
                        this.SwitchIP = Convert.ToString(page.Request["switchIP"]);
                    }
                    else
                    {
                        this.switchIP_initialized = false;
                    }
                }
                else
                {
                    this.SwitchIP = Convert.ToString(page.Request["switchIP"]);
                }
            }

            
            if(page.Request["switchPort"] != null)
            {
                if (this.switchPort_initialized)
                {
                    if(page.Request["switchPort"] != "")
                    {
                        this.SwitchPort = Convert.ToInt32(page.Request["switchPort"]);
                    }
                    else
                    {
                        this.switchPort_initialized = false;
                    }
                }
                else
                {
                    this.SwitchPort = Convert.ToInt32(page.Request["switchPort"]);
                }
            }

            
            if(page.Request["switchIndex"] != null)
            {
                if (this.switchIndex_initialized)
                {
                    if(page.Request["switchIndex"] != "")
                    {
                        this.SwitchIndex = Convert.ToInt32(page.Request["switchIndex"]);
                    }
                    else
                    {
                        this.switchIndex_initialized = false;
                    }
                }
                else
                {
                    this.SwitchIndex = Convert.ToInt32(page.Request["switchIndex"]);
                }
            }

            
            if(page.Request["switchGroup"] != null)
            {
                if (this.switchGroup_initialized)
                {
                    if(page.Request["switchGroup"] != "")
                    {
                        this.SwitchGroup = Convert.ToInt32(page.Request["switchGroup"]);
                    }
                    else
                    {
                        this.switchGroup_initialized = false;
                    }
                }
                else
                {
                    this.SwitchGroup = Convert.ToInt32(page.Request["switchGroup"]);
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

            
            if(page.Request["isdele"] != null)
            {
                if (this.isdele_initialized)
                {
                    if(page.Request["isdele"] != "")
                    {
                        this.Isdele = Convert.ToInt32(page.Request["isdele"]);
                    }
                    else
                    {
                        this.isdele_initialized = false;
                    }
                }
                else
                {
                    this.Isdele = Convert.ToInt32(page.Request["isdele"]);
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

            
            if(page.Request["x"] != null)
            {
                if (this.x_initialized)
                {
                    if(page.Request["x"] != "")
                    {
                        this.X = Convert.ToDouble(page.Request["x"]);
                    }
                    else
                    {
                        this.x_initialized = false;
                    }
                }
                else
                {
                    this.X = Convert.ToDouble(page.Request["x"]);
                }
            }

            
            if(page.Request["y"] != null)
            {
                if (this.y_initialized)
                {
                    if(page.Request["y"] != "")
                    {
                        this.Y = Convert.ToDouble(page.Request["y"]);
                    }
                    else
                    {
                        this.y_initialized = false;
                    }
                }
                else
                {
                    this.Y = Convert.ToDouble(page.Request["y"]);
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