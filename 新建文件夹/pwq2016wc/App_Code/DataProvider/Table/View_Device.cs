/************************************************************

  Copyright (c) 2008，
  Author:               Date: 2020/8/13 10:58:10
  Description:    数据表View_Device对应的业务逻辑层
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
    /// 与View_Device数据表对应对象
    /// </summary>
    public class View_Device : IDateBuildTable
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


        private string m_areaName;
        private bool areaName_initialized = false;

        private int m_iD;
        private bool iD_initialized = false;

        private string m_name;
        private bool name_initialized = false;

        private string m_pic;
        private bool pic_initialized = false;

        private string m_brief;
        private bool brief_initialized = false;

        private int m_areaID;
        private bool areaID_initialized = false;

        private int m_protocol;
        private bool protocol_initialized = false;

        private int m_charType;
        private bool charType_initialized = false;

        private int m_reCharType;
        private bool reCharType_initialized = false;

        private string m_openProtocol;
        private bool openProtocol_initialized = false;

        private string m_closeProtocol;
        private bool closeProtocol_initialized = false;

        private string m_queryProtocol;
        private bool queryProtocol_initialized = false;

        private string m_queryOpen;
        private bool queryOpen_initialized = false;

        private string m_queryClose;
        private bool queryClose_initialized = false;

        private DateTime m_addTime;
        private bool addTime_initialized = false;

        private int m_onlineTIme;
        private bool onlineTIme_initialized = false;

        private string m_addName;
        private bool addName_initialized = false;

        private string m_ip;
        private bool ip_initialized = false;

        private int m_port;
        private bool port_initialized = false;

        private string m_mac;
        private bool mac_initialized = false;

        private int m_state;
        private bool state_initialized = false;

        private int m_deviceType;
        private bool deviceType_initialized = false;

        private int m_seviceID;
        private bool seviceID_initialized = false;

        private string m_switchIP;
        private bool switchIP_initialized = false;

        private int m_switchPort;
        private bool switchPort_initialized = false;

        private int m_switchIndex;
        private bool switchIndex_initialized = false;

        private int m_switchGroup;
        private bool switchGroup_initialized = false;

        private int m_switchTime;
        private bool switchTime_initialized = false;

        private int m_projectorType;
        private bool projectorType_initialized = false;

        private long m_orderID;
        private bool orderID_initialized = false;

        private string m_broadcastIP;
        private bool broadcastIP_initialized = false;

        private int m_openCount;
        private bool openCount_initialized = false;

        private string m_manage;
        private bool manage_initialized = false;

        private int m_typeID;
        private bool typeID_initialized = false;

        private int m_isDele;
        private bool isDele_initialized = false;

        private int m_addID;
        private bool addID_initialized = false;

        private int m_exhibitionID;
        private bool exhibitionID_initialized = false;

        private string m_title;
        private bool title_initialized = false;

        private double m_x;
        private bool x_initialized = false;

        private double m_y;
        private bool y_initialized = false;


        public View_Device()
        {
        }

        public View_Device(string areaName, int iD, string name, string pic, string brief, int areaID, int protocol, int charType, int reCharType, string openProtocol, string closeProtocol, string queryProtocol, string queryOpen, string queryClose, DateTime addTime, int onlineTIme, string addName, string ip, int port, string mac, int state, int deviceType, int seviceID, string switchIP, int switchPort, int switchIndex, int switchGroup, int switchTime, int projectorType, long orderID, string broadcastIP, int openCount, string manage, int typeID, int isDele, int addID, int exhibitionID, string title, double x, double y)
        {

            this.AreaName = areaName;

            this.ID = iD;

            this.Name = name;

            this.Pic = pic;

            this.Brief = brief;

            this.AreaID = areaID;

            this.Protocol = protocol;

            this.CharType = charType;

            this.ReCharType = reCharType;

            this.OpenProtocol = openProtocol;

            this.CloseProtocol = closeProtocol;

            this.QueryProtocol = queryProtocol;

            this.QueryOpen = queryOpen;

            this.QueryClose = queryClose;

            this.AddTime = addTime;

            this.OnlineTIme = onlineTIme;

            this.AddName = addName;

            this.Ip = ip;

            this.Port = port;

            this.Mac = mac;

            this.State = state;

            this.DeviceType = deviceType;

            this.SeviceID = seviceID;

            this.SwitchIP = switchIP;

            this.SwitchPort = switchPort;

            this.SwitchIndex = switchIndex;

            this.SwitchGroup = switchGroup;

            this.SwitchTime = switchTime;

            this.ProjectorType = projectorType;

            this.OrderID = orderID;

            this.BroadcastIP = broadcastIP;

            this.OpenCount = openCount;

            this.Manage = manage;

            this.TypeID = typeID;

            this.IsDele = isDele;

            this.AddID = addID;

            this.ExhibitionID = exhibitionID;

            this.Title = title;

            this.X = x;

            this.Y = y;

        }


        /// <summary>
        /// 从SqlDataProvider中读取数据
        /// </summary>
        /// <param name="dr"></param>
        public void FromIDataReader(IDataReader dr)
        {

            if (CheckColumn(dr, "AreaName"))
            {
                if (dr["AreaName"] != null && dr["AreaName"] != DBNull.Value)
                {
                    this.AreaName = Convert.ToString(dr["AreaName"]);
                }
            }


            if (CheckColumn(dr, "ID"))
            {
                if (dr["ID"] != null && dr["ID"] != DBNull.Value)
                {
                    this.ID = Convert.ToInt32(dr["ID"]);
                }
            }


            if (CheckColumn(dr, "Name"))
            {
                if (dr["Name"] != null && dr["Name"] != DBNull.Value)
                {
                    this.Name = Convert.ToString(dr["Name"]);
                }
            }


            if (CheckColumn(dr, "Pic"))
            {
                if (dr["Pic"] != null && dr["Pic"] != DBNull.Value)
                {
                    this.Pic = Convert.ToString(dr["Pic"]);
                }
            }


            if (CheckColumn(dr, "Brief"))
            {
                if (dr["Brief"] != null && dr["Brief"] != DBNull.Value)
                {
                    this.Brief = Convert.ToString(dr["Brief"]);
                }
            }


            if (CheckColumn(dr, "AreaID"))
            {
                if (dr["AreaID"] != null && dr["AreaID"] != DBNull.Value)
                {
                    this.AreaID = Convert.ToInt32(dr["AreaID"]);
                }
            }


            if (CheckColumn(dr, "Protocol"))
            {
                if (dr["Protocol"] != null && dr["Protocol"] != DBNull.Value)
                {
                    this.Protocol = Convert.ToInt32(dr["Protocol"]);
                }
            }


            if (CheckColumn(dr, "CharType"))
            {
                if (dr["CharType"] != null && dr["CharType"] != DBNull.Value)
                {
                    this.CharType = Convert.ToInt32(dr["CharType"]);
                }
            }


            if (CheckColumn(dr, "ReCharType"))
            {
                if (dr["ReCharType"] != null && dr["ReCharType"] != DBNull.Value)
                {
                    this.ReCharType = Convert.ToInt32(dr["ReCharType"]);
                }
            }


            if (CheckColumn(dr, "OpenProtocol"))
            {
                if (dr["OpenProtocol"] != null && dr["OpenProtocol"] != DBNull.Value)
                {
                    this.OpenProtocol = Convert.ToString(dr["OpenProtocol"]);
                }
            }


            if (CheckColumn(dr, "CloseProtocol"))
            {
                if (dr["CloseProtocol"] != null && dr["CloseProtocol"] != DBNull.Value)
                {
                    this.CloseProtocol = Convert.ToString(dr["CloseProtocol"]);
                }
            }


            if (CheckColumn(dr, "QueryProtocol"))
            {
                if (dr["QueryProtocol"] != null && dr["QueryProtocol"] != DBNull.Value)
                {
                    this.QueryProtocol = Convert.ToString(dr["QueryProtocol"]);
                }
            }


            if (CheckColumn(dr, "QueryOpen"))
            {
                if (dr["QueryOpen"] != null && dr["QueryOpen"] != DBNull.Value)
                {
                    this.QueryOpen = Convert.ToString(dr["QueryOpen"]);
                }
            }


            if (CheckColumn(dr, "QueryClose"))
            {
                if (dr["QueryClose"] != null && dr["QueryClose"] != DBNull.Value)
                {
                    this.QueryClose = Convert.ToString(dr["QueryClose"]);
                }
            }


            if (CheckColumn(dr, "AddTime"))
            {
                if (dr["AddTime"] != null && dr["AddTime"] != DBNull.Value)
                {
                    this.AddTime = Convert.ToDateTime(dr["AddTime"]);
                }
            }


            if (CheckColumn(dr, "OnlineTIme"))
            {
                if (dr["OnlineTIme"] != null && dr["OnlineTIme"] != DBNull.Value)
                {
                    this.OnlineTIme = Convert.ToInt32(dr["OnlineTIme"]);
                }
            }


            if (CheckColumn(dr, "AddName"))
            {
                if (dr["AddName"] != null && dr["AddName"] != DBNull.Value)
                {
                    this.AddName = Convert.ToString(dr["AddName"]);
                }
            }


            if (CheckColumn(dr, "Ip"))
            {
                if (dr["Ip"] != null && dr["Ip"] != DBNull.Value)
                {
                    this.Ip = Convert.ToString(dr["Ip"]);
                }
            }


            if (CheckColumn(dr, "Port"))
            {
                if (dr["Port"] != null && dr["Port"] != DBNull.Value)
                {
                    this.Port = Convert.ToInt32(dr["Port"]);
                }
            }


            if (CheckColumn(dr, "Mac"))
            {
                if (dr["Mac"] != null && dr["Mac"] != DBNull.Value)
                {
                    this.Mac = Convert.ToString(dr["Mac"]);
                }
            }


            if (CheckColumn(dr, "State"))
            {
                if (dr["State"] != null && dr["State"] != DBNull.Value)
                {
                    this.State = Convert.ToInt32(dr["State"]);
                }
            }


            if (CheckColumn(dr, "DeviceType"))
            {
                if (dr["DeviceType"] != null && dr["DeviceType"] != DBNull.Value)
                {
                    this.DeviceType = Convert.ToInt32(dr["DeviceType"]);
                }
            }


            if (CheckColumn(dr, "SeviceID"))
            {
                if (dr["SeviceID"] != null && dr["SeviceID"] != DBNull.Value)
                {
                    this.SeviceID = Convert.ToInt32(dr["SeviceID"]);
                }
            }


            if (CheckColumn(dr, "SwitchIP"))
            {
                if (dr["SwitchIP"] != null && dr["SwitchIP"] != DBNull.Value)
                {
                    this.SwitchIP = Convert.ToString(dr["SwitchIP"]);
                }
            }


            if (CheckColumn(dr, "SwitchPort"))
            {
                if (dr["SwitchPort"] != null && dr["SwitchPort"] != DBNull.Value)
                {
                    this.SwitchPort = Convert.ToInt32(dr["SwitchPort"]);
                }
            }


            if (CheckColumn(dr, "SwitchIndex"))
            {
                if (dr["SwitchIndex"] != null && dr["SwitchIndex"] != DBNull.Value)
                {
                    this.SwitchIndex = Convert.ToInt32(dr["SwitchIndex"]);
                }
            }


            if (CheckColumn(dr, "SwitchGroup"))
            {
                if (dr["SwitchGroup"] != null && dr["SwitchGroup"] != DBNull.Value)
                {
                    this.SwitchGroup = Convert.ToInt32(dr["SwitchGroup"]);
                }
            }


            if (CheckColumn(dr, "SwitchTime"))
            {
                if (dr["SwitchTime"] != null && dr["SwitchTime"] != DBNull.Value)
                {
                    this.SwitchTime = Convert.ToInt32(dr["SwitchTime"]);
                }
            }


            if (CheckColumn(dr, "ProjectorType"))
            {
                if (dr["ProjectorType"] != null && dr["ProjectorType"] != DBNull.Value)
                {
                    this.ProjectorType = Convert.ToInt32(dr["ProjectorType"]);
                }
            }


            if (CheckColumn(dr, "OrderID"))
            {
                if (dr["OrderID"] != null && dr["OrderID"] != DBNull.Value)
                {
                    this.OrderID = Convert.ToInt64(dr["OrderID"]);
                }
            }


            if (CheckColumn(dr, "BroadcastIP"))
            {
                if (dr["BroadcastIP"] != null && dr["BroadcastIP"] != DBNull.Value)
                {
                    this.BroadcastIP = Convert.ToString(dr["BroadcastIP"]);
                }
            }


            if (CheckColumn(dr, "OpenCount"))
            {
                if (dr["OpenCount"] != null && dr["OpenCount"] != DBNull.Value)
                {
                    this.OpenCount = Convert.ToInt32(dr["OpenCount"]);
                }
            }


            if (CheckColumn(dr, "Manage"))
            {
                if (dr["Manage"] != null && dr["Manage"] != DBNull.Value)
                {
                    this.Manage = Convert.ToString(dr["Manage"]);
                }
            }


            if (CheckColumn(dr, "TypeID"))
            {
                if (dr["TypeID"] != null && dr["TypeID"] != DBNull.Value)
                {
                    this.TypeID = Convert.ToInt32(dr["TypeID"]);
                }
            }


            if (CheckColumn(dr, "IsDele"))
            {
                if (dr["IsDele"] != null && dr["IsDele"] != DBNull.Value)
                {
                    this.IsDele = Convert.ToInt32(dr["IsDele"]);
                }
            }


            if (CheckColumn(dr, "AddID"))
            {
                if (dr["AddID"] != null && dr["AddID"] != DBNull.Value)
                {
                    this.AddID = Convert.ToInt32(dr["AddID"]);
                }
            }


            if (CheckColumn(dr, "ExhibitionID"))
            {
                if (dr["ExhibitionID"] != null && dr["ExhibitionID"] != DBNull.Value)
                {
                    this.ExhibitionID = Convert.ToInt32(dr["ExhibitionID"]);
                }
            }


            if (CheckColumn(dr, "Title"))
            {
                if (dr["Title"] != null && dr["Title"] != DBNull.Value)
                {
                    this.Title = Convert.ToString(dr["Title"]);
                }
            }


            if (CheckColumn(dr, "X"))
            {
                if (dr["X"] != null && dr["X"] != DBNull.Value)
                {
                    this.X = Convert.ToDouble(dr["X"]);
                }
            }


            if (CheckColumn(dr, "Y"))
            {
                if (dr["Y"] != null && dr["Y"] != DBNull.Value)
                {
                    this.Y = Convert.ToDouble(dr["Y"]);
                }
            }



        }


        public string AreaName
        {
            get
            {
                return this.m_areaName;
            }
            set
            {
                areaName_initialized = true;
                this.m_areaName = value;
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

        public int ReCharType
        {
            get
            {
                return this.m_reCharType;
            }
            set
            {
                reCharType_initialized = true;
                this.m_reCharType = value;
            }
        }

        public string OpenProtocol
        {
            get
            {
                return this.m_openProtocol;
            }
            set
            {
                openProtocol_initialized = true;
                this.m_openProtocol = value;
            }
        }

        public string CloseProtocol
        {
            get
            {
                return this.m_closeProtocol;
            }
            set
            {
                closeProtocol_initialized = true;
                this.m_closeProtocol = value;
            }
        }

        public string QueryProtocol
        {
            get
            {
                return this.m_queryProtocol;
            }
            set
            {
                queryProtocol_initialized = true;
                this.m_queryProtocol = value;
            }
        }

        public string QueryOpen
        {
            get
            {
                return this.m_queryOpen;
            }
            set
            {
                queryOpen_initialized = true;
                this.m_queryOpen = value;
            }
        }

        public string QueryClose
        {
            get
            {
                return this.m_queryClose;
            }
            set
            {
                queryClose_initialized = true;
                this.m_queryClose = value;
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

        public int OnlineTIme
        {
            get
            {
                return this.m_onlineTIme;
            }
            set
            {
                onlineTIme_initialized = true;
                this.m_onlineTIme = value;
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

        public string Ip
        {
            get
            {
                return this.m_ip;
            }
            set
            {
                ip_initialized = true;
                this.m_ip = value;
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

        public string Mac
        {
            get
            {
                return this.m_mac;
            }
            set
            {
                mac_initialized = true;
                this.m_mac = value;
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

        public int DeviceType
        {
            get
            {
                return this.m_deviceType;
            }
            set
            {
                deviceType_initialized = true;
                this.m_deviceType = value;
            }
        }

        public int SeviceID
        {
            get
            {
                return this.m_seviceID;
            }
            set
            {
                seviceID_initialized = true;
                this.m_seviceID = value;
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

        public int SwitchTime
        {
            get
            {
                return this.m_switchTime;
            }
            set
            {
                switchTime_initialized = true;
                this.m_switchTime = value;
            }
        }

        public int ProjectorType
        {
            get
            {
                return this.m_projectorType;
            }
            set
            {
                projectorType_initialized = true;
                this.m_projectorType = value;
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

        public string BroadcastIP
        {
            get
            {
                return this.m_broadcastIP;
            }
            set
            {
                broadcastIP_initialized = true;
                this.m_broadcastIP = value;
            }
        }

        public int OpenCount
        {
            get
            {
                return this.m_openCount;
            }
            set
            {
                openCount_initialized = true;
                this.m_openCount = value;
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

        public int IsDele
        {
            get
            {
                return this.m_isDele;
            }
            set
            {
                isDele_initialized = true;
                this.m_isDele = value;
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
                if (areaName_initialized || iD_initialized || name_initialized || pic_initialized || brief_initialized || areaID_initialized || protocol_initialized || charType_initialized || reCharType_initialized || openProtocol_initialized || closeProtocol_initialized || queryProtocol_initialized || queryOpen_initialized || queryClose_initialized || addTime_initialized || onlineTIme_initialized || addName_initialized || ip_initialized || port_initialized || mac_initialized || state_initialized || deviceType_initialized || seviceID_initialized || switchIP_initialized || switchPort_initialized || switchIndex_initialized || switchGroup_initialized || switchTime_initialized || projectorType_initialized || orderID_initialized || broadcastIP_initialized || openCount_initialized || manage_initialized || typeID_initialized || isDele_initialized || addID_initialized || exhibitionID_initialized || title_initialized || x_initialized || y_initialized)
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

            if (areaName_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "AreaName", SqlDbType.NVarChar);
                n_Parameter.Value = this.AreaName;
                n_Parameter.SourceColumn = "AreaName";
                parametersList.Add(n_Parameter);
            }

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

            if (pic_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Pic", SqlDbType.NVarChar);
                n_Parameter.Value = this.Pic;
                n_Parameter.SourceColumn = "Pic";
                parametersList.Add(n_Parameter);
            }

            if (brief_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Brief", SqlDbType.NVarChar);
                n_Parameter.Value = this.Brief;
                n_Parameter.SourceColumn = "Brief";
                parametersList.Add(n_Parameter);
            }

            if (areaID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "AreaID", SqlDbType.Int);
                n_Parameter.Value = this.AreaID;
                n_Parameter.SourceColumn = "AreaID";
                parametersList.Add(n_Parameter);
            }

            if (protocol_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Protocol", SqlDbType.Int);
                n_Parameter.Value = this.Protocol;
                n_Parameter.SourceColumn = "Protocol";
                parametersList.Add(n_Parameter);
            }

            if (charType_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "CharType", SqlDbType.Int);
                n_Parameter.Value = this.CharType;
                n_Parameter.SourceColumn = "CharType";
                parametersList.Add(n_Parameter);
            }

            if (reCharType_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ReCharType", SqlDbType.Int);
                n_Parameter.Value = this.ReCharType;
                n_Parameter.SourceColumn = "ReCharType";
                parametersList.Add(n_Parameter);
            }

            if (openProtocol_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "OpenProtocol", SqlDbType.NVarChar);
                n_Parameter.Value = this.OpenProtocol;
                n_Parameter.SourceColumn = "OpenProtocol";
                parametersList.Add(n_Parameter);
            }

            if (closeProtocol_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "CloseProtocol", SqlDbType.NVarChar);
                n_Parameter.Value = this.CloseProtocol;
                n_Parameter.SourceColumn = "CloseProtocol";
                parametersList.Add(n_Parameter);
            }

            if (queryProtocol_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "QueryProtocol", SqlDbType.NVarChar);
                n_Parameter.Value = this.QueryProtocol;
                n_Parameter.SourceColumn = "QueryProtocol";
                parametersList.Add(n_Parameter);
            }

            if (queryOpen_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "QueryOpen", SqlDbType.NVarChar);
                n_Parameter.Value = this.QueryOpen;
                n_Parameter.SourceColumn = "QueryOpen";
                parametersList.Add(n_Parameter);
            }

            if (queryClose_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "QueryClose", SqlDbType.NVarChar);
                n_Parameter.Value = this.QueryClose;
                n_Parameter.SourceColumn = "QueryClose";
                parametersList.Add(n_Parameter);
            }

            if (addTime_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "AddTime", SqlDbType.DateTime);
                n_Parameter.Value = this.AddTime;
                n_Parameter.SourceColumn = "AddTime";
                parametersList.Add(n_Parameter);
            }

            if (onlineTIme_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "OnlineTIme", SqlDbType.Int);
                n_Parameter.Value = this.OnlineTIme;
                n_Parameter.SourceColumn = "OnlineTIme";
                parametersList.Add(n_Parameter);
            }

            if (addName_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "AddName", SqlDbType.NVarChar);
                n_Parameter.Value = this.AddName;
                n_Parameter.SourceColumn = "AddName";
                parametersList.Add(n_Parameter);
            }

            if (ip_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Ip", SqlDbType.NVarChar);
                n_Parameter.Value = this.Ip;
                n_Parameter.SourceColumn = "Ip";
                parametersList.Add(n_Parameter);
            }

            if (port_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Port", SqlDbType.Int);
                n_Parameter.Value = this.Port;
                n_Parameter.SourceColumn = "Port";
                parametersList.Add(n_Parameter);
            }

            if (mac_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Mac", SqlDbType.NVarChar);
                n_Parameter.Value = this.Mac;
                n_Parameter.SourceColumn = "Mac";
                parametersList.Add(n_Parameter);
            }

            if (state_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "State", SqlDbType.Int);
                n_Parameter.Value = this.State;
                n_Parameter.SourceColumn = "State";
                parametersList.Add(n_Parameter);
            }

            if (deviceType_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "DeviceType", SqlDbType.Int);
                n_Parameter.Value = this.DeviceType;
                n_Parameter.SourceColumn = "DeviceType";
                parametersList.Add(n_Parameter);
            }

            if (seviceID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "SeviceID", SqlDbType.Int);
                n_Parameter.Value = this.SeviceID;
                n_Parameter.SourceColumn = "SeviceID";
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

            if (switchTime_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "SwitchTime", SqlDbType.Int);
                n_Parameter.Value = this.SwitchTime;
                n_Parameter.SourceColumn = "SwitchTime";
                parametersList.Add(n_Parameter);
            }

            if (projectorType_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ProjectorType", SqlDbType.Int);
                n_Parameter.Value = this.ProjectorType;
                n_Parameter.SourceColumn = "ProjectorType";
                parametersList.Add(n_Parameter);
            }

            if (orderID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "OrderID", SqlDbType.BigInt);
                n_Parameter.Value = this.OrderID;
                n_Parameter.SourceColumn = "OrderID";
                parametersList.Add(n_Parameter);
            }

            if (broadcastIP_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "BroadcastIP", SqlDbType.NVarChar);
                n_Parameter.Value = this.BroadcastIP;
                n_Parameter.SourceColumn = "BroadcastIP";
                parametersList.Add(n_Parameter);
            }

            if (openCount_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "OpenCount", SqlDbType.Int);
                n_Parameter.Value = this.OpenCount;
                n_Parameter.SourceColumn = "OpenCount";
                parametersList.Add(n_Parameter);
            }

            if (manage_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Manage", SqlDbType.NVarChar);
                n_Parameter.Value = this.Manage;
                n_Parameter.SourceColumn = "Manage";
                parametersList.Add(n_Parameter);
            }

            if (typeID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "TypeID", SqlDbType.Int);
                n_Parameter.Value = this.TypeID;
                n_Parameter.SourceColumn = "TypeID";
                parametersList.Add(n_Parameter);
            }

            if (isDele_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "IsDele", SqlDbType.Int);
                n_Parameter.Value = this.IsDele;
                n_Parameter.SourceColumn = "IsDele";
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

            if (title_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Title", SqlDbType.NVarChar);
                n_Parameter.Value = this.Title;
                n_Parameter.SourceColumn = "Title";
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

            if (this.m_isAutoUpdate)
            {

                if (this.areaName_initialized)
                {
                    contentText += ", [AreaName]=@" + headStr + "AreaName ";
                }

                if (this.iD_initialized)
                {
                    contentText += ", [ID]=@" + headStr + "ID ";
                }

                if (this.name_initialized)
                {
                    contentText += ", [Name]=@" + headStr + "Name ";
                }

                if (this.pic_initialized)
                {
                    contentText += ", [Pic]=@" + headStr + "Pic ";
                }

                if (this.brief_initialized)
                {
                    contentText += ", [Brief]=@" + headStr + "Brief ";
                }

                if (this.areaID_initialized)
                {
                    contentText += ", [AreaID]=@" + headStr + "AreaID ";
                }

                if (this.protocol_initialized)
                {
                    contentText += ", [Protocol]=@" + headStr + "Protocol ";
                }

                if (this.charType_initialized)
                {
                    contentText += ", [CharType]=@" + headStr + "CharType ";
                }

                if (this.reCharType_initialized)
                {
                    contentText += ", [ReCharType]=@" + headStr + "ReCharType ";
                }

                if (this.openProtocol_initialized)
                {
                    contentText += ", [OpenProtocol]=@" + headStr + "OpenProtocol ";
                }

                if (this.closeProtocol_initialized)
                {
                    contentText += ", [CloseProtocol]=@" + headStr + "CloseProtocol ";
                }

                if (this.queryProtocol_initialized)
                {
                    contentText += ", [QueryProtocol]=@" + headStr + "QueryProtocol ";
                }

                if (this.queryOpen_initialized)
                {
                    contentText += ", [QueryOpen]=@" + headStr + "QueryOpen ";
                }

                if (this.queryClose_initialized)
                {
                    contentText += ", [QueryClose]=@" + headStr + "QueryClose ";
                }

                if (this.addTime_initialized)
                {
                    contentText += ", [AddTime]=@" + headStr + "AddTime ";
                }

                if (this.onlineTIme_initialized)
                {
                    contentText += ", [OnlineTIme]=@" + headStr + "OnlineTIme ";
                }

                if (this.addName_initialized)
                {
                    contentText += ", [AddName]=@" + headStr + "AddName ";
                }

                if (this.ip_initialized)
                {
                    contentText += ", [Ip]=@" + headStr + "Ip ";
                }

                if (this.port_initialized)
                {
                    contentText += ", [Port]=@" + headStr + "Port ";
                }

                if (this.mac_initialized)
                {
                    contentText += ", [Mac]=@" + headStr + "Mac ";
                }

                if (this.state_initialized)
                {
                    contentText += ", [State]=@" + headStr + "State ";
                }

                if (this.deviceType_initialized)
                {
                    contentText += ", [DeviceType]=@" + headStr + "DeviceType ";
                }

                if (this.seviceID_initialized)
                {
                    contentText += ", [SeviceID]=@" + headStr + "SeviceID ";
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

                if (this.switchTime_initialized)
                {
                    contentText += ", [SwitchTime]=@" + headStr + "SwitchTime ";
                }

                if (this.projectorType_initialized)
                {
                    contentText += ", [ProjectorType]=@" + headStr + "ProjectorType ";
                }

                if (this.orderID_initialized)
                {
                    contentText += ", [OrderID]=@" + headStr + "OrderID ";
                }

                if (this.broadcastIP_initialized)
                {
                    contentText += ", [BroadcastIP]=@" + headStr + "BroadcastIP ";
                }

                if (this.openCount_initialized)
                {
                    contentText += ", [OpenCount]=@" + headStr + "OpenCount ";
                }

                if (this.manage_initialized)
                {
                    contentText += ", [Manage]=@" + headStr + "Manage ";
                }

                if (this.typeID_initialized)
                {
                    contentText += ", [TypeID]=@" + headStr + "TypeID ";
                }

                if (this.isDele_initialized)
                {
                    contentText += ", [IsDele]=@" + headStr + "IsDele ";
                }

                if (this.addID_initialized)
                {
                    contentText += ", [AddID]=@" + headStr + "AddID ";
                }

                if (this.exhibitionID_initialized)
                {
                    contentText += ", [ExhibitionID]=@" + headStr + "ExhibitionID ";
                }

                if (this.title_initialized)
                {
                    contentText += ", [Title]=@" + headStr + "Title ";
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
            if (this.m_isAutoConditon)
            {

                if (this.areaName_initialized)
                {
                    conditionStr += " AND [AreaName]=@" + headStr + "AreaName ";
                }

                if (this.iD_initialized)
                {
                    conditionStr += " AND [ID]=@" + headStr + "ID ";
                }

                if (this.name_initialized)
                {
                    conditionStr += " AND [Name]=@" + headStr + "Name ";
                }

                if (this.pic_initialized)
                {
                    conditionStr += " AND [Pic]=@" + headStr + "Pic ";
                }

                if (this.brief_initialized)
                {
                    conditionStr += " AND [Brief]=@" + headStr + "Brief ";
                }

                if (this.areaID_initialized)
                {
                    conditionStr += " AND [AreaID]=@" + headStr + "AreaID ";
                }

                if (this.protocol_initialized)
                {
                    conditionStr += " AND [Protocol]=@" + headStr + "Protocol ";
                }

                if (this.charType_initialized)
                {
                    conditionStr += " AND [CharType]=@" + headStr + "CharType ";
                }

                if (this.reCharType_initialized)
                {
                    conditionStr += " AND [ReCharType]=@" + headStr + "ReCharType ";
                }

                if (this.openProtocol_initialized)
                {
                    conditionStr += " AND [OpenProtocol]=@" + headStr + "OpenProtocol ";
                }

                if (this.closeProtocol_initialized)
                {
                    conditionStr += " AND [CloseProtocol]=@" + headStr + "CloseProtocol ";
                }

                if (this.queryProtocol_initialized)
                {
                    conditionStr += " AND [QueryProtocol]=@" + headStr + "QueryProtocol ";
                }

                if (this.queryOpen_initialized)
                {
                    conditionStr += " AND [QueryOpen]=@" + headStr + "QueryOpen ";
                }

                if (this.queryClose_initialized)
                {
                    conditionStr += " AND [QueryClose]=@" + headStr + "QueryClose ";
                }

                if (this.addTime_initialized)
                {
                    conditionStr += " AND [AddTime]=@" + headStr + "AddTime ";
                }

                if (this.onlineTIme_initialized)
                {
                    conditionStr += " AND [OnlineTIme]=@" + headStr + "OnlineTIme ";
                }

                if (this.addName_initialized)
                {
                    conditionStr += " AND [AddName]=@" + headStr + "AddName ";
                }

                if (this.ip_initialized)
                {
                    conditionStr += " AND [Ip]=@" + headStr + "Ip ";
                }

                if (this.port_initialized)
                {
                    conditionStr += " AND [Port]=@" + headStr + "Port ";
                }

                if (this.mac_initialized)
                {
                    conditionStr += " AND [Mac]=@" + headStr + "Mac ";
                }

                if (this.state_initialized)
                {
                    conditionStr += " AND [State]=@" + headStr + "State ";
                }

                if (this.deviceType_initialized)
                {
                    conditionStr += " AND [DeviceType]=@" + headStr + "DeviceType ";
                }

                if (this.seviceID_initialized)
                {
                    conditionStr += " AND [SeviceID]=@" + headStr + "SeviceID ";
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

                if (this.switchTime_initialized)
                {
                    conditionStr += " AND [SwitchTime]=@" + headStr + "SwitchTime ";
                }

                if (this.projectorType_initialized)
                {
                    conditionStr += " AND [ProjectorType]=@" + headStr + "ProjectorType ";
                }

                if (this.orderID_initialized)
                {
                    conditionStr += " AND [OrderID]=@" + headStr + "OrderID ";
                }

                if (this.broadcastIP_initialized)
                {
                    conditionStr += " AND [BroadcastIP]=@" + headStr + "BroadcastIP ";
                }

                if (this.openCount_initialized)
                {
                    conditionStr += " AND [OpenCount]=@" + headStr + "OpenCount ";
                }

                if (this.manage_initialized)
                {
                    conditionStr += " AND [Manage]=@" + headStr + "Manage ";
                }

                if (this.typeID_initialized)
                {
                    conditionStr += " AND [TypeID]=@" + headStr + "TypeID ";
                }

                if (this.isDele_initialized)
                {
                    conditionStr += " AND [IsDele]=@" + headStr + "IsDele ";
                }

                if (this.addID_initialized)
                {
                    conditionStr += " AND [AddID]=@" + headStr + "AddID ";
                }

                if (this.exhibitionID_initialized)
                {
                    conditionStr += " AND [ExhibitionID]=@" + headStr + "ExhibitionID ";
                }

                if (this.title_initialized)
                {
                    conditionStr += " AND [Title]=@" + headStr + "Title ";
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

                if (m_addConditonStr != "")
                {
                    conditionStr = "" + conditionStr + " " + m_addConditonStr;
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
            if (this.m_isAutoContent)
            {

                if (this.areaName_initialized)
                {
                    contentText += ", [AreaName] ";
                }

                if (this.iD_initialized)
                {
                    contentText += ", [ID] ";
                }

                if (this.name_initialized)
                {
                    contentText += ", [Name] ";
                }

                if (this.pic_initialized)
                {
                    contentText += ", [Pic] ";
                }

                if (this.brief_initialized)
                {
                    contentText += ", [Brief] ";
                }

                if (this.areaID_initialized)
                {
                    contentText += ", [AreaID] ";
                }

                if (this.protocol_initialized)
                {
                    contentText += ", [Protocol] ";
                }

                if (this.charType_initialized)
                {
                    contentText += ", [CharType] ";
                }

                if (this.reCharType_initialized)
                {
                    contentText += ", [ReCharType] ";
                }

                if (this.openProtocol_initialized)
                {
                    contentText += ", [OpenProtocol] ";
                }

                if (this.closeProtocol_initialized)
                {
                    contentText += ", [CloseProtocol] ";
                }

                if (this.queryProtocol_initialized)
                {
                    contentText += ", [QueryProtocol] ";
                }

                if (this.queryOpen_initialized)
                {
                    contentText += ", [QueryOpen] ";
                }

                if (this.queryClose_initialized)
                {
                    contentText += ", [QueryClose] ";
                }

                if (this.addTime_initialized)
                {
                    contentText += ", [AddTime] ";
                }

                if (this.onlineTIme_initialized)
                {
                    contentText += ", [OnlineTIme] ";
                }

                if (this.addName_initialized)
                {
                    contentText += ", [AddName] ";
                }

                if (this.ip_initialized)
                {
                    contentText += ", [Ip] ";
                }

                if (this.port_initialized)
                {
                    contentText += ", [Port] ";
                }

                if (this.mac_initialized)
                {
                    contentText += ", [Mac] ";
                }

                if (this.state_initialized)
                {
                    contentText += ", [State] ";
                }

                if (this.deviceType_initialized)
                {
                    contentText += ", [DeviceType] ";
                }

                if (this.seviceID_initialized)
                {
                    contentText += ", [SeviceID] ";
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

                if (this.switchTime_initialized)
                {
                    contentText += ", [SwitchTime] ";
                }

                if (this.projectorType_initialized)
                {
                    contentText += ", [ProjectorType] ";
                }

                if (this.orderID_initialized)
                {
                    contentText += ", [OrderID] ";
                }

                if (this.broadcastIP_initialized)
                {
                    contentText += ", [BroadcastIP] ";
                }

                if (this.openCount_initialized)
                {
                    contentText += ", [OpenCount] ";
                }

                if (this.manage_initialized)
                {
                    contentText += ", [Manage] ";
                }

                if (this.typeID_initialized)
                {
                    contentText += ", [TypeID] ";
                }

                if (this.isDele_initialized)
                {
                    contentText += ", [IsDele] ";
                }

                if (this.addID_initialized)
                {
                    contentText += ", [AddID] ";
                }

                if (this.exhibitionID_initialized)
                {
                    contentText += ", [ExhibitionID] ";
                }

                if (this.title_initialized)
                {
                    contentText += ", [Title] ";
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

                if (contentText == "")
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
            if (this.m_isAutoInsert)
            {

                if (this.areaName_initialized)
                {
                    contentText += ", @" + headStr + "AreaName ";
                }

                if (this.iD_initialized)
                {
                    contentText += ", @" + headStr + "ID ";
                }

                if (this.name_initialized)
                {
                    contentText += ", @" + headStr + "Name ";
                }

                if (this.pic_initialized)
                {
                    contentText += ", @" + headStr + "Pic ";
                }

                if (this.brief_initialized)
                {
                    contentText += ", @" + headStr + "Brief ";
                }

                if (this.areaID_initialized)
                {
                    contentText += ", @" + headStr + "AreaID ";
                }

                if (this.protocol_initialized)
                {
                    contentText += ", @" + headStr + "Protocol ";
                }

                if (this.charType_initialized)
                {
                    contentText += ", @" + headStr + "CharType ";
                }

                if (this.reCharType_initialized)
                {
                    contentText += ", @" + headStr + "ReCharType ";
                }

                if (this.openProtocol_initialized)
                {
                    contentText += ", @" + headStr + "OpenProtocol ";
                }

                if (this.closeProtocol_initialized)
                {
                    contentText += ", @" + headStr + "CloseProtocol ";
                }

                if (this.queryProtocol_initialized)
                {
                    contentText += ", @" + headStr + "QueryProtocol ";
                }

                if (this.queryOpen_initialized)
                {
                    contentText += ", @" + headStr + "QueryOpen ";
                }

                if (this.queryClose_initialized)
                {
                    contentText += ", @" + headStr + "QueryClose ";
                }

                if (this.addTime_initialized)
                {
                    contentText += ", @" + headStr + "AddTime ";
                }

                if (this.onlineTIme_initialized)
                {
                    contentText += ", @" + headStr + "OnlineTIme ";
                }

                if (this.addName_initialized)
                {
                    contentText += ", @" + headStr + "AddName ";
                }

                if (this.ip_initialized)
                {
                    contentText += ", @" + headStr + "Ip ";
                }

                if (this.port_initialized)
                {
                    contentText += ", @" + headStr + "Port ";
                }

                if (this.mac_initialized)
                {
                    contentText += ", @" + headStr + "Mac ";
                }

                if (this.state_initialized)
                {
                    contentText += ", @" + headStr + "State ";
                }

                if (this.deviceType_initialized)
                {
                    contentText += ", @" + headStr + "DeviceType ";
                }

                if (this.seviceID_initialized)
                {
                    contentText += ", @" + headStr + "SeviceID ";
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

                if (this.switchTime_initialized)
                {
                    contentText += ", @" + headStr + "SwitchTime ";
                }

                if (this.projectorType_initialized)
                {
                    contentText += ", @" + headStr + "ProjectorType ";
                }

                if (this.orderID_initialized)
                {
                    contentText += ", @" + headStr + "OrderID ";
                }

                if (this.broadcastIP_initialized)
                {
                    contentText += ", @" + headStr + "BroadcastIP ";
                }

                if (this.openCount_initialized)
                {
                    contentText += ", @" + headStr + "OpenCount ";
                }

                if (this.manage_initialized)
                {
                    contentText += ", @" + headStr + "Manage ";
                }

                if (this.typeID_initialized)
                {
                    contentText += ", @" + headStr + "TypeID ";
                }

                if (this.isDele_initialized)
                {
                    contentText += ", @" + headStr + "IsDele ";
                }

                if (this.addID_initialized)
                {
                    contentText += ", @" + headStr + "AddID ";
                }

                if (this.exhibitionID_initialized)
                {
                    contentText += ", @" + headStr + "ExhibitionID ";
                }

                if (this.title_initialized)
                {
                    contentText += ", @" + headStr + "Title ";
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
            string tableName = "View_Device";
            return tableName;
        }

        /// <summary>
        /// 获取第一列名称
        /// </summary>
        /// <returns></returns>
        public string FirstColumn()
        {
            string firstColumn = "AreaName";
            return firstColumn;
        }

        /// <summary>
        /// 设置所有列为已赋值
        /// </summary>
        /// <returns></returns>
        public void AllInitialized()
        {

            this.areaName_initialized = true;

            this.iD_initialized = true;

            this.name_initialized = true;

            this.pic_initialized = true;

            this.brief_initialized = true;

            this.areaID_initialized = true;

            this.protocol_initialized = true;

            this.charType_initialized = true;

            this.reCharType_initialized = true;

            this.openProtocol_initialized = true;

            this.closeProtocol_initialized = true;

            this.queryProtocol_initialized = true;

            this.queryOpen_initialized = true;

            this.queryClose_initialized = true;

            this.addTime_initialized = true;

            this.onlineTIme_initialized = true;

            this.addName_initialized = true;

            this.ip_initialized = true;

            this.port_initialized = true;

            this.mac_initialized = true;

            this.state_initialized = true;

            this.deviceType_initialized = true;

            this.seviceID_initialized = true;

            this.switchIP_initialized = true;

            this.switchPort_initialized = true;

            this.switchIndex_initialized = true;

            this.switchGroup_initialized = true;

            this.switchTime_initialized = true;

            this.projectorType_initialized = true;

            this.orderID_initialized = true;

            this.broadcastIP_initialized = true;

            this.openCount_initialized = true;

            this.manage_initialized = true;

            this.typeID_initialized = true;

            this.isDele_initialized = true;

            this.addID_initialized = true;

            this.exhibitionID_initialized = true;

            this.title_initialized = true;

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

            if (page.Request["areaName"] != null)
            {
                if (this.areaName_initialized)
                {
                    if (page.Request["areaName"] != "")
                    {
                        this.AreaName = Convert.ToString(page.Request["areaName"]);
                    }
                    else
                    {
                        this.areaName_initialized = false;
                    }
                }
                else
                {
                    this.AreaName = Convert.ToString(page.Request["areaName"]);
                }
            }


            if (page.Request["iD"] != null)
            {
                if (this.iD_initialized)
                {
                    if (page.Request["iD"] != "")
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


            if (page.Request["name"] != null)
            {
                if (this.name_initialized)
                {
                    if (page.Request["name"] != "")
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


            if (page.Request["pic"] != null)
            {
                if (this.pic_initialized)
                {
                    if (page.Request["pic"] != "")
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


            if (page.Request["brief"] != null)
            {
                if (this.brief_initialized)
                {
                    if (page.Request["brief"] != "")
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


            if (page.Request["areaID"] != null)
            {
                if (this.areaID_initialized)
                {
                    if (page.Request["areaID"] != "")
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


            if (page.Request["protocol"] != null)
            {
                if (this.protocol_initialized)
                {
                    if (page.Request["protocol"] != "")
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


            if (page.Request["charType"] != null)
            {
                if (this.charType_initialized)
                {
                    if (page.Request["charType"] != "")
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


            if (page.Request["reCharType"] != null)
            {
                if (this.reCharType_initialized)
                {
                    if (page.Request["reCharType"] != "")
                    {
                        this.ReCharType = Convert.ToInt32(page.Request["reCharType"]);
                    }
                    else
                    {
                        this.reCharType_initialized = false;
                    }
                }
                else
                {
                    this.ReCharType = Convert.ToInt32(page.Request["reCharType"]);
                }
            }


            if (page.Request["openProtocol"] != null)
            {
                if (this.openProtocol_initialized)
                {
                    if (page.Request["openProtocol"] != "")
                    {
                        this.OpenProtocol = Convert.ToString(page.Request["openProtocol"]);
                    }
                    else
                    {
                        this.openProtocol_initialized = false;
                    }
                }
                else
                {
                    this.OpenProtocol = Convert.ToString(page.Request["openProtocol"]);
                }
            }


            if (page.Request["closeProtocol"] != null)
            {
                if (this.closeProtocol_initialized)
                {
                    if (page.Request["closeProtocol"] != "")
                    {
                        this.CloseProtocol = Convert.ToString(page.Request["closeProtocol"]);
                    }
                    else
                    {
                        this.closeProtocol_initialized = false;
                    }
                }
                else
                {
                    this.CloseProtocol = Convert.ToString(page.Request["closeProtocol"]);
                }
            }


            if (page.Request["queryProtocol"] != null)
            {
                if (this.queryProtocol_initialized)
                {
                    if (page.Request["queryProtocol"] != "")
                    {
                        this.QueryProtocol = Convert.ToString(page.Request["queryProtocol"]);
                    }
                    else
                    {
                        this.queryProtocol_initialized = false;
                    }
                }
                else
                {
                    this.QueryProtocol = Convert.ToString(page.Request["queryProtocol"]);
                }
            }


            if (page.Request["queryOpen"] != null)
            {
                if (this.queryOpen_initialized)
                {
                    if (page.Request["queryOpen"] != "")
                    {
                        this.QueryOpen = Convert.ToString(page.Request["queryOpen"]);
                    }
                    else
                    {
                        this.queryOpen_initialized = false;
                    }
                }
                else
                {
                    this.QueryOpen = Convert.ToString(page.Request["queryOpen"]);
                }
            }


            if (page.Request["queryClose"] != null)
            {
                if (this.queryClose_initialized)
                {
                    if (page.Request["queryClose"] != "")
                    {
                        this.QueryClose = Convert.ToString(page.Request["queryClose"]);
                    }
                    else
                    {
                        this.queryClose_initialized = false;
                    }
                }
                else
                {
                    this.QueryClose = Convert.ToString(page.Request["queryClose"]);
                }
            }


            if (page.Request["addTime"] != null)
            {
                if (this.addTime_initialized)
                {
                    if (page.Request["addTime"] != "")
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


            if (page.Request["onlineTIme"] != null)
            {
                if (this.onlineTIme_initialized)
                {
                    if (page.Request["onlineTIme"] != "")
                    {
                        this.OnlineTIme = Convert.ToInt32(page.Request["onlineTIme"]);
                    }
                    else
                    {
                        this.onlineTIme_initialized = false;
                    }
                }
                else
                {
                    this.OnlineTIme = Convert.ToInt32(page.Request["onlineTIme"]);
                }
            }


            if (page.Request["addName"] != null)
            {
                if (this.addName_initialized)
                {
                    if (page.Request["addName"] != "")
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


            if (page.Request["ip"] != null)
            {
                if (this.ip_initialized)
                {
                    if (page.Request["ip"] != "")
                    {
                        this.Ip = Convert.ToString(page.Request["ip"]);
                    }
                    else
                    {
                        this.ip_initialized = false;
                    }
                }
                else
                {
                    this.Ip = Convert.ToString(page.Request["ip"]);
                }
            }


            if (page.Request["port"] != null)
            {
                if (this.port_initialized)
                {
                    if (page.Request["port"] != "")
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


            if (page.Request["mac"] != null)
            {
                if (this.mac_initialized)
                {
                    if (page.Request["mac"] != "")
                    {
                        this.Mac = Convert.ToString(page.Request["mac"]);
                    }
                    else
                    {
                        this.mac_initialized = false;
                    }
                }
                else
                {
                    this.Mac = Convert.ToString(page.Request["mac"]);
                }
            }


            if (page.Request["state"] != null)
            {
                if (this.state_initialized)
                {
                    if (page.Request["state"] != "")
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


            if (page.Request["deviceType"] != null)
            {
                if (this.deviceType_initialized)
                {
                    if (page.Request["deviceType"] != "")
                    {
                        this.DeviceType = Convert.ToInt32(page.Request["deviceType"]);
                    }
                    else
                    {
                        this.deviceType_initialized = false;
                    }
                }
                else
                {
                    this.DeviceType = Convert.ToInt32(page.Request["deviceType"]);
                }
            }


            if (page.Request["seviceID"] != null)
            {
                if (this.seviceID_initialized)
                {
                    if (page.Request["seviceID"] != "")
                    {
                        this.SeviceID = Convert.ToInt32(page.Request["seviceID"]);
                    }
                    else
                    {
                        this.seviceID_initialized = false;
                    }
                }
                else
                {
                    this.SeviceID = Convert.ToInt32(page.Request["seviceID"]);
                }
            }


            if (page.Request["switchIP"] != null)
            {
                if (this.switchIP_initialized)
                {
                    if (page.Request["switchIP"] != "")
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


            if (page.Request["switchPort"] != null)
            {
                if (this.switchPort_initialized)
                {
                    if (page.Request["switchPort"] != "")
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


            if (page.Request["switchIndex"] != null)
            {
                if (this.switchIndex_initialized)
                {
                    if (page.Request["switchIndex"] != "")
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


            if (page.Request["switchGroup"] != null)
            {
                if (this.switchGroup_initialized)
                {
                    if (page.Request["switchGroup"] != "")
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


            if (page.Request["switchTime"] != null)
            {
                if (this.switchTime_initialized)
                {
                    if (page.Request["switchTime"] != "")
                    {
                        this.SwitchTime = Convert.ToInt32(page.Request["switchTime"]);
                    }
                    else
                    {
                        this.switchTime_initialized = false;
                    }
                }
                else
                {
                    this.SwitchTime = Convert.ToInt32(page.Request["switchTime"]);
                }
            }


            if (page.Request["projectorType"] != null)
            {
                if (this.projectorType_initialized)
                {
                    if (page.Request["projectorType"] != "")
                    {
                        this.ProjectorType = Convert.ToInt32(page.Request["projectorType"]);
                    }
                    else
                    {
                        this.projectorType_initialized = false;
                    }
                }
                else
                {
                    this.ProjectorType = Convert.ToInt32(page.Request["projectorType"]);
                }
            }


            if (page.Request["orderID"] != null)
            {
                if (this.orderID_initialized)
                {
                    if (page.Request["orderID"] != "")
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


            if (page.Request["broadcastIP"] != null)
            {
                if (this.broadcastIP_initialized)
                {
                    if (page.Request["broadcastIP"] != "")
                    {
                        this.BroadcastIP = Convert.ToString(page.Request["broadcastIP"]);
                    }
                    else
                    {
                        this.broadcastIP_initialized = false;
                    }
                }
                else
                {
                    this.BroadcastIP = Convert.ToString(page.Request["broadcastIP"]);
                }
            }


            if (page.Request["openCount"] != null)
            {
                if (this.openCount_initialized)
                {
                    if (page.Request["openCount"] != "")
                    {
                        this.OpenCount = Convert.ToInt32(page.Request["openCount"]);
                    }
                    else
                    {
                        this.openCount_initialized = false;
                    }
                }
                else
                {
                    this.OpenCount = Convert.ToInt32(page.Request["openCount"]);
                }
            }


            if (page.Request["manage"] != null)
            {
                if (this.manage_initialized)
                {
                    if (page.Request["manage"] != "")
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


            if (page.Request["typeID"] != null)
            {
                if (this.typeID_initialized)
                {
                    if (page.Request["typeID"] != "")
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


            if (page.Request["isDele"] != null)
            {
                if (this.isDele_initialized)
                {
                    if (page.Request["isDele"] != "")
                    {
                        this.IsDele = Convert.ToInt32(page.Request["isDele"]);
                    }
                    else
                    {
                        this.isDele_initialized = false;
                    }
                }
                else
                {
                    this.IsDele = Convert.ToInt32(page.Request["isDele"]);
                }
            }


            if (page.Request["addID"] != null)
            {
                if (this.addID_initialized)
                {
                    if (page.Request["addID"] != "")
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


            if (page.Request["exhibitionID"] != null)
            {
                if (this.exhibitionID_initialized)
                {
                    if (page.Request["exhibitionID"] != "")
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


            if (page.Request["title"] != null)
            {
                if (this.title_initialized)
                {
                    if (page.Request["title"] != "")
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


            if (page.Request["x"] != null)
            {
                if (this.x_initialized)
                {
                    if (page.Request["x"] != "")
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


            if (page.Request["y"] != null)
            {
                if (this.y_initialized)
                {
                    if (page.Request["y"] != "")
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