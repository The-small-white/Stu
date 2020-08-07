/************************************************************

  Copyright (c) 2008，
  Author:               Date: 2019/9/3 10:54:44
  Description:    数据表View_iBeaconNow对应的业务逻辑层
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
    /// 与View_iBeaconNow数据表对应对象
    /// </summary>
    public class View_iBeaconNow : IDateBuildTable
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
        
        private int m_devID;
        private bool devID_initialized = false;
        
        private int m_gateWayID;
        private bool gateWayID_initialized = false;
        
        private DateTime m_lastTime;
        private bool lastTime_initialized = false;
        
        private double m_distance;
        private bool distance_initialized = false;
        
        private string m_beaconMac;
        private bool beaconMac_initialized = false;
        
        private int m_userID;
        private bool userID_initialized = false;
        
        private int m_exhibitionID;
        private bool exhibitionID_initialized = false;
        
        private string m_devName;
        private bool devName_initialized = false;
        

        public View_iBeaconNow()
        {
        }

        public View_iBeaconNow(int iD, int devID, int gateWayID, DateTime lastTime, double distance, string beaconMac, int userID, int exhibitionID, string devName)
        {
            
            this.ID = iD;
            
            this.DevID = devID;
            
            this.GateWayID = gateWayID;
            
            this.LastTime = lastTime;
            
            this.Distance = distance;
            
            this.BeaconMac = beaconMac;
            
            this.UserID = userID;
            
            this.ExhibitionID = exhibitionID;
            
            this.DevName = devName;
            
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

            
            if(CheckColumn(dr, "DevID"))
            {
                if (dr["DevID"] != null && dr["DevID"] != DBNull.Value)
                {
                    this.DevID = Convert.ToInt32(dr["DevID"]);
                }
            }

            
            if(CheckColumn(dr, "GateWayID"))
            {
                if (dr["GateWayID"] != null && dr["GateWayID"] != DBNull.Value)
                {
                    this.GateWayID = Convert.ToInt32(dr["GateWayID"]);
                }
            }

            
            if(CheckColumn(dr, "LastTime"))
            {
                if (dr["LastTime"] != null && dr["LastTime"] != DBNull.Value)
                {
                    this.LastTime = Convert.ToDateTime(dr["LastTime"]);
                }
            }

            
            if(CheckColumn(dr, "Distance"))
            {
                if (dr["Distance"] != null && dr["Distance"] != DBNull.Value)
                {
                    this.Distance = Convert.ToDouble(dr["Distance"]);
                }
            }

            
            if(CheckColumn(dr, "BeaconMac"))
            {
                if (dr["BeaconMac"] != null && dr["BeaconMac"] != DBNull.Value)
                {
                    this.BeaconMac = Convert.ToString(dr["BeaconMac"]);
                }
            }

            
            if(CheckColumn(dr, "UserID"))
            {
                if (dr["UserID"] != null && dr["UserID"] != DBNull.Value)
                {
                    this.UserID = Convert.ToInt32(dr["UserID"]);
                }
            }

            
            if(CheckColumn(dr, "ExhibitionID"))
            {
                if (dr["ExhibitionID"] != null && dr["ExhibitionID"] != DBNull.Value)
                {
                    this.ExhibitionID = Convert.ToInt32(dr["ExhibitionID"]);
                }
            }

            
            if(CheckColumn(dr, "DevName"))
            {
                if (dr["DevName"] != null && dr["DevName"] != DBNull.Value)
                {
                    this.DevName = Convert.ToString(dr["DevName"]);
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
        
        public int DevID
        {
            get
            {
                return this.m_devID;
            }
            set
            {
                devID_initialized = true;
                this.m_devID = value;
            }
        }
        
        public int GateWayID
        {
            get
            {
                return this.m_gateWayID;
            }
            set
            {
                gateWayID_initialized = true;
                this.m_gateWayID = value;
            }
        }
        
        public DateTime LastTime
        {
            get
            {
                return this.m_lastTime;
            }
            set
            {
                lastTime_initialized = true;
                this.m_lastTime = value;
            }
        }
        
        public double Distance
        {
            get
            {
                return this.m_distance;
            }
            set
            {
                distance_initialized = true;
                this.m_distance = value;
            }
        }
        
        public string BeaconMac
        {
            get
            {
                return this.m_beaconMac;
            }
            set
            {
                beaconMac_initialized = true;
                this.m_beaconMac = value;
            }
        }
        
        public int UserID
        {
            get
            {
                return this.m_userID;
            }
            set
            {
                userID_initialized = true;
                this.m_userID = value;
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
        
        public string DevName
        {
            get
            {
                return this.m_devName;
            }
            set
            {
                devName_initialized = true;
                this.m_devName = value;
            }
        }
        


        /// <summary>
        /// 判断对象属性是否赋值。没有赋值返回true
        /// </summary>
        public bool IsNull
        {
            get
            {
                if (iD_initialized || devID_initialized || gateWayID_initialized || lastTime_initialized || distance_initialized || beaconMac_initialized || userID_initialized || exhibitionID_initialized || devName_initialized)
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
            
            if (devID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "DevID", SqlDbType.Int);
                n_Parameter.Value = this.DevID;
                n_Parameter.SourceColumn = "DevID";
                parametersList.Add(n_Parameter);
            }
            
            if (gateWayID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "GateWayID", SqlDbType.Int);
                n_Parameter.Value = this.GateWayID;
                n_Parameter.SourceColumn = "GateWayID";
                parametersList.Add(n_Parameter);
            }
            
            if (lastTime_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "LastTime", SqlDbType.DateTime);
                n_Parameter.Value = this.LastTime;
                n_Parameter.SourceColumn = "LastTime";
                parametersList.Add(n_Parameter);
            }
            
            if (distance_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Distance", SqlDbType.Float);
                n_Parameter.Value = this.Distance;
                n_Parameter.SourceColumn = "Distance";
                parametersList.Add(n_Parameter);
            }
            
            if (beaconMac_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "BeaconMac", SqlDbType.NVarChar);
                n_Parameter.Value = this.BeaconMac;
                n_Parameter.SourceColumn = "BeaconMac";
                parametersList.Add(n_Parameter);
            }
            
            if (userID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "UserID", SqlDbType.Int);
                n_Parameter.Value = this.UserID;
                n_Parameter.SourceColumn = "UserID";
                parametersList.Add(n_Parameter);
            }
            
            if (exhibitionID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ExhibitionID", SqlDbType.Int);
                n_Parameter.Value = this.ExhibitionID;
                n_Parameter.SourceColumn = "ExhibitionID";
                parametersList.Add(n_Parameter);
            }
            
            if (devName_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "DevName", SqlDbType.NVarChar);
                n_Parameter.Value = this.DevName;
                n_Parameter.SourceColumn = "DevName";
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
                
                if (this.devID_initialized)
                {
                    contentText += ", [DevID]=@" + headStr + "DevID ";
                }
                
                if (this.gateWayID_initialized)
                {
                    contentText += ", [GateWayID]=@" + headStr + "GateWayID ";
                }
                
                if (this.lastTime_initialized)
                {
                    contentText += ", [LastTime]=@" + headStr + "LastTime ";
                }
                
                if (this.distance_initialized)
                {
                    contentText += ", [Distance]=@" + headStr + "Distance ";
                }
                
                if (this.beaconMac_initialized)
                {
                    contentText += ", [BeaconMac]=@" + headStr + "BeaconMac ";
                }
                
                if (this.userID_initialized)
                {
                    contentText += ", [UserID]=@" + headStr + "UserID ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    contentText += ", [ExhibitionID]=@" + headStr + "ExhibitionID ";
                }
                
                if (this.devName_initialized)
                {
                    contentText += ", [DevName]=@" + headStr + "DevName ";
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
                
                if (this.devID_initialized)
                {
                    conditionStr += " AND [DevID]=@" + headStr + "DevID ";
                }
                
                if (this.gateWayID_initialized)
                {
                    conditionStr += " AND [GateWayID]=@" + headStr + "GateWayID ";
                }
                
                if (this.lastTime_initialized)
                {
                    conditionStr += " AND [LastTime]=@" + headStr + "LastTime ";
                }
                
                if (this.distance_initialized)
                {
                    conditionStr += " AND [Distance]=@" + headStr + "Distance ";
                }
                
                if (this.beaconMac_initialized)
                {
                    conditionStr += " AND [BeaconMac]=@" + headStr + "BeaconMac ";
                }
                
                if (this.userID_initialized)
                {
                    conditionStr += " AND [UserID]=@" + headStr + "UserID ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    conditionStr += " AND [ExhibitionID]=@" + headStr + "ExhibitionID ";
                }
                
                if (this.devName_initialized)
                {
                    conditionStr += " AND [DevName]=@" + headStr + "DevName ";
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
                
                if (this.devID_initialized)
                {
                    contentText += ", [DevID] ";
                }
                
                if (this.gateWayID_initialized)
                {
                    contentText += ", [GateWayID] ";
                }
                
                if (this.lastTime_initialized)
                {
                    contentText += ", [LastTime] ";
                }
                
                if (this.distance_initialized)
                {
                    contentText += ", [Distance] ";
                }
                
                if (this.beaconMac_initialized)
                {
                    contentText += ", [BeaconMac] ";
                }
                
                if (this.userID_initialized)
                {
                    contentText += ", [UserID] ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    contentText += ", [ExhibitionID] ";
                }
                
                if (this.devName_initialized)
                {
                    contentText += ", [DevName] ";
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
                
                if (this.devID_initialized)
                {
                    contentText += ", @" + headStr + "DevID ";
                }
                
                if (this.gateWayID_initialized)
                {
                    contentText += ", @" + headStr + "GateWayID ";
                }
                
                if (this.lastTime_initialized)
                {
                    contentText += ", @" + headStr + "LastTime ";
                }
                
                if (this.distance_initialized)
                {
                    contentText += ", @" + headStr + "Distance ";
                }
                
                if (this.beaconMac_initialized)
                {
                    contentText += ", @" + headStr + "BeaconMac ";
                }
                
                if (this.userID_initialized)
                {
                    contentText += ", @" + headStr + "UserID ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    contentText += ", @" + headStr + "ExhibitionID ";
                }
                
                if (this.devName_initialized)
                {
                    contentText += ", @" + headStr + "DevName ";
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
            string tableName = "View_iBeaconNow";
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
            
            this.devID_initialized = true;
            
            this.gateWayID_initialized = true;
            
            this.lastTime_initialized = true;
            
            this.distance_initialized = true;
            
            this.beaconMac_initialized = true;
            
            this.userID_initialized = true;
            
            this.exhibitionID_initialized = true;
            
            this.devName_initialized = true;
            
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

            
            if(page.Request["devID"] != null)
            {
                if (this.devID_initialized)
                {
                    if(page.Request["devID"] != "")
                    {
                        this.DevID = Convert.ToInt32(page.Request["devID"]);
                    }
                    else
                    {
                        this.devID_initialized = false;
                    }
                }
                else
                {
                    this.DevID = Convert.ToInt32(page.Request["devID"]);
                }
            }

            
            if(page.Request["gateWayID"] != null)
            {
                if (this.gateWayID_initialized)
                {
                    if(page.Request["gateWayID"] != "")
                    {
                        this.GateWayID = Convert.ToInt32(page.Request["gateWayID"]);
                    }
                    else
                    {
                        this.gateWayID_initialized = false;
                    }
                }
                else
                {
                    this.GateWayID = Convert.ToInt32(page.Request["gateWayID"]);
                }
            }

            
            if(page.Request["lastTime"] != null)
            {
                if (this.lastTime_initialized)
                {
                    if(page.Request["lastTime"] != "")
                    {
                        this.LastTime = Convert.ToDateTime(page.Request["lastTime"]);
                    }
                    else
                    {
                        this.lastTime_initialized = false;
                    }
                }
                else
                {
                    this.LastTime = Convert.ToDateTime(page.Request["lastTime"]);
                }
            }

            
            if(page.Request["distance"] != null)
            {
                if (this.distance_initialized)
                {
                    if(page.Request["distance"] != "")
                    {
                        this.Distance = Convert.ToDouble(page.Request["distance"]);
                    }
                    else
                    {
                        this.distance_initialized = false;
                    }
                }
                else
                {
                    this.Distance = Convert.ToDouble(page.Request["distance"]);
                }
            }

            
            if(page.Request["beaconMac"] != null)
            {
                if (this.beaconMac_initialized)
                {
                    if(page.Request["beaconMac"] != "")
                    {
                        this.BeaconMac = Convert.ToString(page.Request["beaconMac"]);
                    }
                    else
                    {
                        this.beaconMac_initialized = false;
                    }
                }
                else
                {
                    this.BeaconMac = Convert.ToString(page.Request["beaconMac"]);
                }
            }

            
            if(page.Request["userID"] != null)
            {
                if (this.userID_initialized)
                {
                    if(page.Request["userID"] != "")
                    {
                        this.UserID = Convert.ToInt32(page.Request["userID"]);
                    }
                    else
                    {
                        this.userID_initialized = false;
                    }
                }
                else
                {
                    this.UserID = Convert.ToInt32(page.Request["userID"]);
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

            
            if(page.Request["devName"] != null)
            {
                if (this.devName_initialized)
                {
                    if(page.Request["devName"] != "")
                    {
                        this.DevName = Convert.ToString(page.Request["devName"]);
                    }
                    else
                    {
                        this.devName_initialized = false;
                    }
                }
                else
                {
                    this.DevName = Convert.ToString(page.Request["devName"]);
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