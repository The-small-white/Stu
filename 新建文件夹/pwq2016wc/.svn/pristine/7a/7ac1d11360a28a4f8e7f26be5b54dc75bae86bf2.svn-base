/************************************************************

  Copyright (c) 2008，
  Author:               Date: 2019/8/30 14:10:20
  Description:    数据表IBeaconGateWay对应的业务逻辑层
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
    /// 与IBeaconGateWay数据表对应对象
    /// </summary>
    public class IBeaconGateWay : IDateBuildTable
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
        
        private string m_mAC;
        private bool mAC_initialized = false;
        
        private string m_devName;
        private bool devName_initialized = false;
        
        private double m_maxDistance;
        private bool maxDistance_initialized = false;
        
        private int m_x;
        private bool x_initialized = false;
        
        private int m_y;
        private bool y_initialized = false;
        
        private int m_h;
        private bool h_initialized = false;
        
        private int m_exhibitionID;
        private bool exhibitionID_initialized = false;
        
        private string m_brief;
        private bool brief_initialized = false;
        
        private DateTime m_addTime;
        private bool addTime_initialized = false;
        
        private int m_addID;
        private bool addID_initialized = false;
        

        public IBeaconGateWay()
        {
        }

        public IBeaconGateWay(int iD, string mAC, string devName, double maxDistance, int x, int y, int h, int exhibitionID, string brief, DateTime addTime, int addID)
        {
            
            this.ID = iD;
            
            this.MAC = mAC;
            
            this.DevName = devName;
            
            this.MaxDistance = maxDistance;
            
            this.X = x;
            
            this.Y = y;
            
            this.H = h;
            
            this.ExhibitionID = exhibitionID;
            
            this.Brief = brief;
            
            this.AddTime = addTime;
            
            this.AddID = addID;
            
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

            
            if(CheckColumn(dr, "MAC"))
            {
                if (dr["MAC"] != null && dr["MAC"] != DBNull.Value)
                {
                    this.MAC = Convert.ToString(dr["MAC"]);
                }
            }

            
            if(CheckColumn(dr, "DevName"))
            {
                if (dr["DevName"] != null && dr["DevName"] != DBNull.Value)
                {
                    this.DevName = Convert.ToString(dr["DevName"]);
                }
            }

            
            if(CheckColumn(dr, "MaxDistance"))
            {
                if (dr["MaxDistance"] != null && dr["MaxDistance"] != DBNull.Value)
                {
                    this.MaxDistance = Convert.ToDouble(dr["MaxDistance"]);
                }
            }

            
            if(CheckColumn(dr, "x"))
            {
                if (dr["x"] != null && dr["x"] != DBNull.Value)
                {
                    this.X = Convert.ToInt32(dr["x"]);
                }
            }

            
            if(CheckColumn(dr, "y"))
            {
                if (dr["y"] != null && dr["y"] != DBNull.Value)
                {
                    this.Y = Convert.ToInt32(dr["y"]);
                }
            }

            
            if(CheckColumn(dr, "h"))
            {
                if (dr["h"] != null && dr["h"] != DBNull.Value)
                {
                    this.H = Convert.ToInt32(dr["h"]);
                }
            }

            
            if(CheckColumn(dr, "ExhibitionID"))
            {
                if (dr["ExhibitionID"] != null && dr["ExhibitionID"] != DBNull.Value)
                {
                    this.ExhibitionID = Convert.ToInt32(dr["ExhibitionID"]);
                }
            }

            
            if(CheckColumn(dr, "Brief"))
            {
                if (dr["Brief"] != null && dr["Brief"] != DBNull.Value)
                {
                    this.Brief = Convert.ToString(dr["Brief"]);
                }
            }

            
            if(CheckColumn(dr, "AddTime"))
            {
                if (dr["AddTime"] != null && dr["AddTime"] != DBNull.Value)
                {
                    this.AddTime = Convert.ToDateTime(dr["AddTime"]);
                }
            }

            
            if(CheckColumn(dr, "AddID"))
            {
                if (dr["AddID"] != null && dr["AddID"] != DBNull.Value)
                {
                    this.AddID = Convert.ToInt32(dr["AddID"]);
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
        
        public string MAC
        {
            get
            {
                return this.m_mAC;
            }
            set
            {
                mAC_initialized = true;
                this.m_mAC = value;
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
        
        public double MaxDistance
        {
            get
            {
                return this.m_maxDistance;
            }
            set
            {
                maxDistance_initialized = true;
                this.m_maxDistance = value;
            }
        }
        
        public int X
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
        
        public int Y
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
        
        public int H
        {
            get
            {
                return this.m_h;
            }
            set
            {
                h_initialized = true;
                this.m_h = value;
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
        


        /// <summary>
        /// 判断对象属性是否赋值。没有赋值返回true
        /// </summary>
        public bool IsNull
        {
            get
            {
                if (iD_initialized || mAC_initialized || devName_initialized || maxDistance_initialized || x_initialized || y_initialized || h_initialized || exhibitionID_initialized || brief_initialized || addTime_initialized || addID_initialized)
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
            
            if (mAC_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "MAC", SqlDbType.NVarChar);
                n_Parameter.Value = this.MAC;
                n_Parameter.SourceColumn = "MAC";
                parametersList.Add(n_Parameter);
            }
            
            if (devName_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "DevName", SqlDbType.NVarChar);
                n_Parameter.Value = this.DevName;
                n_Parameter.SourceColumn = "DevName";
                parametersList.Add(n_Parameter);
            }
            
            if (maxDistance_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "MaxDistance", SqlDbType.Float);
                n_Parameter.Value = this.MaxDistance;
                n_Parameter.SourceColumn = "MaxDistance";
                parametersList.Add(n_Parameter);
            }
            
            if (x_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "x", SqlDbType.Int);
                n_Parameter.Value = this.X;
                n_Parameter.SourceColumn = "x";
                parametersList.Add(n_Parameter);
            }
            
            if (y_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "y", SqlDbType.Int);
                n_Parameter.Value = this.Y;
                n_Parameter.SourceColumn = "y";
                parametersList.Add(n_Parameter);
            }
            
            if (h_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "h", SqlDbType.Int);
                n_Parameter.Value = this.H;
                n_Parameter.SourceColumn = "h";
                parametersList.Add(n_Parameter);
            }
            
            if (exhibitionID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ExhibitionID", SqlDbType.Int);
                n_Parameter.Value = this.ExhibitionID;
                n_Parameter.SourceColumn = "ExhibitionID";
                parametersList.Add(n_Parameter);
            }
            
            if (brief_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Brief", SqlDbType.NVarChar);
                n_Parameter.Value = this.Brief;
                n_Parameter.SourceColumn = "Brief";
                parametersList.Add(n_Parameter);
            }
            
            if (addTime_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "AddTime", SqlDbType.DateTime);
                n_Parameter.Value = this.AddTime;
                n_Parameter.SourceColumn = "AddTime";
                parametersList.Add(n_Parameter);
            }
            
            if (addID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "AddID", SqlDbType.Int);
                n_Parameter.Value = this.AddID;
                n_Parameter.SourceColumn = "AddID";
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
                
                if (this.mAC_initialized)
                {
                    contentText += ", [MAC]=@" + headStr + "MAC ";
                }
                
                if (this.devName_initialized)
                {
                    contentText += ", [DevName]=@" + headStr + "DevName ";
                }
                
                if (this.maxDistance_initialized)
                {
                    contentText += ", [MaxDistance]=@" + headStr + "MaxDistance ";
                }
                
                if (this.x_initialized)
                {
                    contentText += ", [x]=@" + headStr + "x ";
                }
                
                if (this.y_initialized)
                {
                    contentText += ", [y]=@" + headStr + "y ";
                }
                
                if (this.h_initialized)
                {
                    contentText += ", [h]=@" + headStr + "h ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    contentText += ", [ExhibitionID]=@" + headStr + "ExhibitionID ";
                }
                
                if (this.brief_initialized)
                {
                    contentText += ", [Brief]=@" + headStr + "Brief ";
                }
                
                if (this.addTime_initialized)
                {
                    contentText += ", [AddTime]=@" + headStr + "AddTime ";
                }
                
                if (this.addID_initialized)
                {
                    contentText += ", [AddID]=@" + headStr + "AddID ";
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
                
                if (this.mAC_initialized)
                {
                    conditionStr += " AND [MAC]=@" + headStr + "MAC ";
                }
                
                if (this.devName_initialized)
                {
                    conditionStr += " AND [DevName]=@" + headStr + "DevName ";
                }
                
                if (this.maxDistance_initialized)
                {
                    conditionStr += " AND [MaxDistance]=@" + headStr + "MaxDistance ";
                }
                
                if (this.x_initialized)
                {
                    conditionStr += " AND [x]=@" + headStr + "x ";
                }
                
                if (this.y_initialized)
                {
                    conditionStr += " AND [y]=@" + headStr + "y ";
                }
                
                if (this.h_initialized)
                {
                    conditionStr += " AND [h]=@" + headStr + "h ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    conditionStr += " AND [ExhibitionID]=@" + headStr + "ExhibitionID ";
                }
                
                if (this.brief_initialized)
                {
                    conditionStr += " AND [Brief]=@" + headStr + "Brief ";
                }
                
                if (this.addTime_initialized)
                {
                    conditionStr += " AND [AddTime]=@" + headStr + "AddTime ";
                }
                
                if (this.addID_initialized)
                {
                    conditionStr += " AND [AddID]=@" + headStr + "AddID ";
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
                
                if (this.mAC_initialized)
                {
                    contentText += ", [MAC] ";
                }
                
                if (this.devName_initialized)
                {
                    contentText += ", [DevName] ";
                }
                
                if (this.maxDistance_initialized)
                {
                    contentText += ", [MaxDistance] ";
                }
                
                if (this.x_initialized)
                {
                    contentText += ", [x] ";
                }
                
                if (this.y_initialized)
                {
                    contentText += ", [y] ";
                }
                
                if (this.h_initialized)
                {
                    contentText += ", [h] ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    contentText += ", [ExhibitionID] ";
                }
                
                if (this.brief_initialized)
                {
                    contentText += ", [Brief] ";
                }
                
                if (this.addTime_initialized)
                {
                    contentText += ", [AddTime] ";
                }
                
                if (this.addID_initialized)
                {
                    contentText += ", [AddID] ";
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
                
                if (this.mAC_initialized)
                {
                    contentText += ", @" + headStr + "MAC ";
                }
                
                if (this.devName_initialized)
                {
                    contentText += ", @" + headStr + "DevName ";
                }
                
                if (this.maxDistance_initialized)
                {
                    contentText += ", @" + headStr + "MaxDistance ";
                }
                
                if (this.x_initialized)
                {
                    contentText += ", @" + headStr + "x ";
                }
                
                if (this.y_initialized)
                {
                    contentText += ", @" + headStr + "y ";
                }
                
                if (this.h_initialized)
                {
                    contentText += ", @" + headStr + "h ";
                }
                
                if (this.exhibitionID_initialized)
                {
                    contentText += ", @" + headStr + "ExhibitionID ";
                }
                
                if (this.brief_initialized)
                {
                    contentText += ", @" + headStr + "Brief ";
                }
                
                if (this.addTime_initialized)
                {
                    contentText += ", @" + headStr + "AddTime ";
                }
                
                if (this.addID_initialized)
                {
                    contentText += ", @" + headStr + "AddID ";
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
            string tableName = "iBeaconGateWay";
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
            
            this.mAC_initialized = true;
            
            this.devName_initialized = true;
            
            this.maxDistance_initialized = true;
            
            this.x_initialized = true;
            
            this.y_initialized = true;
            
            this.h_initialized = true;
            
            this.exhibitionID_initialized = true;
            
            this.brief_initialized = true;
            
            this.addTime_initialized = true;
            
            this.addID_initialized = true;
            
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

            
            if(page.Request["mAC"] != null)
            {
                if (this.mAC_initialized)
                {
                    if(page.Request["mAC"] != "")
                    {
                        this.MAC = Convert.ToString(page.Request["mAC"]);
                    }
                    else
                    {
                        this.mAC_initialized = false;
                    }
                }
                else
                {
                    this.MAC = Convert.ToString(page.Request["mAC"]);
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

            
            if(page.Request["maxDistance"] != null)
            {
                if (this.maxDistance_initialized)
                {
                    if(page.Request["maxDistance"] != "")
                    {
                        this.MaxDistance = Convert.ToDouble(page.Request["maxDistance"]);
                    }
                    else
                    {
                        this.maxDistance_initialized = false;
                    }
                }
                else
                {
                    this.MaxDistance = Convert.ToDouble(page.Request["maxDistance"]);
                }
            }

            
            if(page.Request["x"] != null)
            {
                if (this.x_initialized)
                {
                    if(page.Request["x"] != "")
                    {
                        this.X = Convert.ToInt32(page.Request["x"]);
                    }
                    else
                    {
                        this.x_initialized = false;
                    }
                }
                else
                {
                    this.X = Convert.ToInt32(page.Request["x"]);
                }
            }

            
            if(page.Request["y"] != null)
            {
                if (this.y_initialized)
                {
                    if(page.Request["y"] != "")
                    {
                        this.Y = Convert.ToInt32(page.Request["y"]);
                    }
                    else
                    {
                        this.y_initialized = false;
                    }
                }
                else
                {
                    this.Y = Convert.ToInt32(page.Request["y"]);
                }
            }

            
            if(page.Request["h"] != null)
            {
                if (this.h_initialized)
                {
                    if(page.Request["h"] != "")
                    {
                        this.H = Convert.ToInt32(page.Request["h"]);
                    }
                    else
                    {
                        this.h_initialized = false;
                    }
                }
                else
                {
                    this.H = Convert.ToInt32(page.Request["h"]);
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