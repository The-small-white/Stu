/************************************************************

  Copyright (c) 2008，
  Author:               Date: 2018/11/22 下午3:32:47
  Description:    数据表TableManage对应的业务逻辑层
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
    /// 与TableManage数据表对应对象
    /// </summary>
    public class TableManage : IDateBuildTable
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
        
        private string m_englishName;
        private bool englishName_initialized = false;
        
        private string m_ziDuan;
        private bool ziDuan_initialized = false;
        
        private string m_ziDuanType;
        private bool ziDuanType_initialized = false;
        
        private string m_addType;
        private bool addType_initialized = false;
        
        private string m_chengYuan;
        private bool chengYuan_initialized = false;
        
        private string m_zhi;
        private bool zhi_initialized = false;
        
        private string m_biXu;
        private bool biXu_initialized = false;
        
        private string m_souSuo;
        private bool souSuo_initialized = false;
        
        private string m_lieBiao;
        private bool lieBiao_initialized = false;
        
        private string m_addShow;
        private bool addShow_initialized = false;
        
        private string m_editShow;
        private bool editShow_initialized = false;
        
        private int m_shenPiID;
        private bool shenPiID_initialized = false;
        
        private string m_dingDing;
        private bool dingDing_initialized = false;
        
        private string m_breif;
        private bool breif_initialized = false;
        
        private DateTime m_addTime;
        private bool addTime_initialized = false;
        
        private int m_addID;
        private bool addID_initialized = false;
        
        private string m_addName;
        private bool addName_initialized = false;
        
        private string m_zhongWenZiDuan;
        private bool zhongWenZiDuan_initialized = false;
        
        private string m_canEdit;
        private bool canEdit_initialized = false;
        
        private string m_viewShow;
        private bool viewShow_initialized = false;
        
        private string m_mangeBumen;
        private bool mangeBumen_initialized = false;
        
        private string m_manageUser;
        private bool manageUser_initialized = false;
        
        private string m_kuaiJiBumen;
        private bool kuaiJiBumen_initialized = false;
        
        private string m_kuaiJiUser;
        private bool kuaiJiUser_initialized = false;
        
        private string m_shengPiDingDing;
        private bool shengPiDingDing_initialized = false;
        
        private string m_dingDingZiDuan;
        private bool dingDingZiDuan_initialized = false;
        
        private string m_dingDingZiDuanName;
        private bool dingDingZiDuanName_initialized = false;
        

        public TableManage()
        {
        }

        public TableManage(int iD, string name, string englishName, string ziDuan, string ziDuanType, string addType, string chengYuan, string zhi, string biXu, string souSuo, string lieBiao, string addShow, string editShow, int shenPiID, string dingDing, string breif, DateTime addTime, int addID, string addName, string zhongWenZiDuan, string canEdit, string viewShow, string mangeBumen, string manageUser, string kuaiJiBumen, string kuaiJiUser, string shengPiDingDing, string dingDingZiDuan, string dingDingZiDuanName)
        {
            
            this.ID = iD;
            
            this.Name = name;
            
            this.EnglishName = englishName;
            
            this.ZiDuan = ziDuan;
            
            this.ZiDuanType = ziDuanType;
            
            this.AddType = addType;
            
            this.ChengYuan = chengYuan;
            
            this.Zhi = zhi;
            
            this.BiXu = biXu;
            
            this.SouSuo = souSuo;
            
            this.LieBiao = lieBiao;
            
            this.AddShow = addShow;
            
            this.EditShow = editShow;
            
            this.ShenPiID = shenPiID;
            
            this.DingDing = dingDing;
            
            this.Breif = breif;
            
            this.AddTime = addTime;
            
            this.AddID = addID;
            
            this.AddName = addName;
            
            this.ZhongWenZiDuan = zhongWenZiDuan;
            
            this.CanEdit = canEdit;
            
            this.ViewShow = viewShow;
            
            this.MangeBumen = mangeBumen;
            
            this.ManageUser = manageUser;
            
            this.KuaiJiBumen = kuaiJiBumen;
            
            this.KuaiJiUser = kuaiJiUser;
            
            this.ShengPiDingDing = shengPiDingDing;
            
            this.DingDingZiDuan = dingDingZiDuan;
            
            this.DingDingZiDuanName = dingDingZiDuanName;
            
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

            
            if(CheckColumn(dr, "EnglishName"))
            {
                if (dr["EnglishName"] != null && dr["EnglishName"] != DBNull.Value)
                {
                    this.EnglishName = Convert.ToString(dr["EnglishName"]);
                }
            }

            
            if(CheckColumn(dr, "ZiDuan"))
            {
                if (dr["ZiDuan"] != null && dr["ZiDuan"] != DBNull.Value)
                {
                    this.ZiDuan = Convert.ToString(dr["ZiDuan"]);
                }
            }

            
            if(CheckColumn(dr, "ZiDuanType"))
            {
                if (dr["ZiDuanType"] != null && dr["ZiDuanType"] != DBNull.Value)
                {
                    this.ZiDuanType = Convert.ToString(dr["ZiDuanType"]);
                }
            }

            
            if(CheckColumn(dr, "AddType"))
            {
                if (dr["AddType"] != null && dr["AddType"] != DBNull.Value)
                {
                    this.AddType = Convert.ToString(dr["AddType"]);
                }
            }

            
            if(CheckColumn(dr, "ChengYuan"))
            {
                if (dr["ChengYuan"] != null && dr["ChengYuan"] != DBNull.Value)
                {
                    this.ChengYuan = Convert.ToString(dr["ChengYuan"]);
                }
            }

            
            if(CheckColumn(dr, "Zhi"))
            {
                if (dr["Zhi"] != null && dr["Zhi"] != DBNull.Value)
                {
                    this.Zhi = Convert.ToString(dr["Zhi"]);
                }
            }

            
            if(CheckColumn(dr, "BiXu"))
            {
                if (dr["BiXu"] != null && dr["BiXu"] != DBNull.Value)
                {
                    this.BiXu = Convert.ToString(dr["BiXu"]);
                }
            }

            
            if(CheckColumn(dr, "SouSuo"))
            {
                if (dr["SouSuo"] != null && dr["SouSuo"] != DBNull.Value)
                {
                    this.SouSuo = Convert.ToString(dr["SouSuo"]);
                }
            }

            
            if(CheckColumn(dr, "LieBiao"))
            {
                if (dr["LieBiao"] != null && dr["LieBiao"] != DBNull.Value)
                {
                    this.LieBiao = Convert.ToString(dr["LieBiao"]);
                }
            }

            
            if(CheckColumn(dr, "AddShow"))
            {
                if (dr["AddShow"] != null && dr["AddShow"] != DBNull.Value)
                {
                    this.AddShow = Convert.ToString(dr["AddShow"]);
                }
            }

            
            if(CheckColumn(dr, "EditShow"))
            {
                if (dr["EditShow"] != null && dr["EditShow"] != DBNull.Value)
                {
                    this.EditShow = Convert.ToString(dr["EditShow"]);
                }
            }

            
            if(CheckColumn(dr, "ShenPiID"))
            {
                if (dr["ShenPiID"] != null && dr["ShenPiID"] != DBNull.Value)
                {
                    this.ShenPiID = Convert.ToInt32(dr["ShenPiID"]);
                }
            }

            
            if(CheckColumn(dr, "DingDing"))
            {
                if (dr["DingDing"] != null && dr["DingDing"] != DBNull.Value)
                {
                    this.DingDing = Convert.ToString(dr["DingDing"]);
                }
            }

            
            if(CheckColumn(dr, "Breif"))
            {
                if (dr["Breif"] != null && dr["Breif"] != DBNull.Value)
                {
                    this.Breif = Convert.ToString(dr["Breif"]);
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

            
            if(CheckColumn(dr, "AddName"))
            {
                if (dr["AddName"] != null && dr["AddName"] != DBNull.Value)
                {
                    this.AddName = Convert.ToString(dr["AddName"]);
                }
            }

            
            if(CheckColumn(dr, "ZhongWenZiDuan"))
            {
                if (dr["ZhongWenZiDuan"] != null && dr["ZhongWenZiDuan"] != DBNull.Value)
                {
                    this.ZhongWenZiDuan = Convert.ToString(dr["ZhongWenZiDuan"]);
                }
            }

            
            if(CheckColumn(dr, "CanEdit"))
            {
                if (dr["CanEdit"] != null && dr["CanEdit"] != DBNull.Value)
                {
                    this.CanEdit = Convert.ToString(dr["CanEdit"]);
                }
            }

            
            if(CheckColumn(dr, "ViewShow"))
            {
                if (dr["ViewShow"] != null && dr["ViewShow"] != DBNull.Value)
                {
                    this.ViewShow = Convert.ToString(dr["ViewShow"]);
                }
            }

            
            if(CheckColumn(dr, "MangeBumen"))
            {
                if (dr["MangeBumen"] != null && dr["MangeBumen"] != DBNull.Value)
                {
                    this.MangeBumen = Convert.ToString(dr["MangeBumen"]);
                }
            }

            
            if(CheckColumn(dr, "ManageUser"))
            {
                if (dr["ManageUser"] != null && dr["ManageUser"] != DBNull.Value)
                {
                    this.ManageUser = Convert.ToString(dr["ManageUser"]);
                }
            }

            
            if(CheckColumn(dr, "KuaiJiBumen"))
            {
                if (dr["KuaiJiBumen"] != null && dr["KuaiJiBumen"] != DBNull.Value)
                {
                    this.KuaiJiBumen = Convert.ToString(dr["KuaiJiBumen"]);
                }
            }

            
            if(CheckColumn(dr, "KuaiJiUser"))
            {
                if (dr["KuaiJiUser"] != null && dr["KuaiJiUser"] != DBNull.Value)
                {
                    this.KuaiJiUser = Convert.ToString(dr["KuaiJiUser"]);
                }
            }

            
            if(CheckColumn(dr, "ShengPiDingDing"))
            {
                if (dr["ShengPiDingDing"] != null && dr["ShengPiDingDing"] != DBNull.Value)
                {
                    this.ShengPiDingDing = Convert.ToString(dr["ShengPiDingDing"]);
                }
            }

            
            if(CheckColumn(dr, "DingDingZiDuan"))
            {
                if (dr["DingDingZiDuan"] != null && dr["DingDingZiDuan"] != DBNull.Value)
                {
                    this.DingDingZiDuan = Convert.ToString(dr["DingDingZiDuan"]);
                }
            }

            
            if(CheckColumn(dr, "DingDingZiDuanName"))
            {
                if (dr["DingDingZiDuanName"] != null && dr["DingDingZiDuanName"] != DBNull.Value)
                {
                    this.DingDingZiDuanName = Convert.ToString(dr["DingDingZiDuanName"]);
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
        
        public string EnglishName
        {
            get
            {
                return this.m_englishName;
            }
            set
            {
                englishName_initialized = true;
                this.m_englishName = value;
            }
        }
        
        public string ZiDuan
        {
            get
            {
                return this.m_ziDuan;
            }
            set
            {
                ziDuan_initialized = true;
                this.m_ziDuan = value;
            }
        }
        
        public string ZiDuanType
        {
            get
            {
                return this.m_ziDuanType;
            }
            set
            {
                ziDuanType_initialized = true;
                this.m_ziDuanType = value;
            }
        }
        
        public string AddType
        {
            get
            {
                return this.m_addType;
            }
            set
            {
                addType_initialized = true;
                this.m_addType = value;
            }
        }
        
        public string ChengYuan
        {
            get
            {
                return this.m_chengYuan;
            }
            set
            {
                chengYuan_initialized = true;
                this.m_chengYuan = value;
            }
        }
        
        public string Zhi
        {
            get
            {
                return this.m_zhi;
            }
            set
            {
                zhi_initialized = true;
                this.m_zhi = value;
            }
        }
        
        public string BiXu
        {
            get
            {
                return this.m_biXu;
            }
            set
            {
                biXu_initialized = true;
                this.m_biXu = value;
            }
        }
        
        public string SouSuo
        {
            get
            {
                return this.m_souSuo;
            }
            set
            {
                souSuo_initialized = true;
                this.m_souSuo = value;
            }
        }
        
        public string LieBiao
        {
            get
            {
                return this.m_lieBiao;
            }
            set
            {
                lieBiao_initialized = true;
                this.m_lieBiao = value;
            }
        }
        
        public string AddShow
        {
            get
            {
                return this.m_addShow;
            }
            set
            {
                addShow_initialized = true;
                this.m_addShow = value;
            }
        }
        
        public string EditShow
        {
            get
            {
                return this.m_editShow;
            }
            set
            {
                editShow_initialized = true;
                this.m_editShow = value;
            }
        }
        
        public int ShenPiID
        {
            get
            {
                return this.m_shenPiID;
            }
            set
            {
                shenPiID_initialized = true;
                this.m_shenPiID = value;
            }
        }
        
        public string DingDing
        {
            get
            {
                return this.m_dingDing;
            }
            set
            {
                dingDing_initialized = true;
                this.m_dingDing = value;
            }
        }
        
        public string Breif
        {
            get
            {
                return this.m_breif;
            }
            set
            {
                breif_initialized = true;
                this.m_breif = value;
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
        
        public string ZhongWenZiDuan
        {
            get
            {
                return this.m_zhongWenZiDuan;
            }
            set
            {
                zhongWenZiDuan_initialized = true;
                this.m_zhongWenZiDuan = value;
            }
        }
        
        public string CanEdit
        {
            get
            {
                return this.m_canEdit;
            }
            set
            {
                canEdit_initialized = true;
                this.m_canEdit = value;
            }
        }
        
        public string ViewShow
        {
            get
            {
                return this.m_viewShow;
            }
            set
            {
                viewShow_initialized = true;
                this.m_viewShow = value;
            }
        }
        
        public string MangeBumen
        {
            get
            {
                return this.m_mangeBumen;
            }
            set
            {
                mangeBumen_initialized = true;
                this.m_mangeBumen = value;
            }
        }
        
        public string ManageUser
        {
            get
            {
                return this.m_manageUser;
            }
            set
            {
                manageUser_initialized = true;
                this.m_manageUser = value;
            }
        }
        
        public string KuaiJiBumen
        {
            get
            {
                return this.m_kuaiJiBumen;
            }
            set
            {
                kuaiJiBumen_initialized = true;
                this.m_kuaiJiBumen = value;
            }
        }
        
        public string KuaiJiUser
        {
            get
            {
                return this.m_kuaiJiUser;
            }
            set
            {
                kuaiJiUser_initialized = true;
                this.m_kuaiJiUser = value;
            }
        }
        
        public string ShengPiDingDing
        {
            get
            {
                return this.m_shengPiDingDing;
            }
            set
            {
                shengPiDingDing_initialized = true;
                this.m_shengPiDingDing = value;
            }
        }
        
        public string DingDingZiDuan
        {
            get
            {
                return this.m_dingDingZiDuan;
            }
            set
            {
                dingDingZiDuan_initialized = true;
                this.m_dingDingZiDuan = value;
            }
        }
        
        public string DingDingZiDuanName
        {
            get
            {
                return this.m_dingDingZiDuanName;
            }
            set
            {
                dingDingZiDuanName_initialized = true;
                this.m_dingDingZiDuanName = value;
            }
        }
        


        /// <summary>
        /// 判断对象属性是否赋值。没有赋值返回true
        /// </summary>
        public bool IsNull
        {
            get
            {
                if (iD_initialized || name_initialized || englishName_initialized || ziDuan_initialized || ziDuanType_initialized || addType_initialized || chengYuan_initialized || zhi_initialized || biXu_initialized || souSuo_initialized || lieBiao_initialized || addShow_initialized || editShow_initialized || shenPiID_initialized || dingDing_initialized || breif_initialized || addTime_initialized || addID_initialized || addName_initialized || zhongWenZiDuan_initialized || canEdit_initialized || viewShow_initialized || mangeBumen_initialized || manageUser_initialized || kuaiJiBumen_initialized || kuaiJiUser_initialized || shengPiDingDing_initialized || dingDingZiDuan_initialized || dingDingZiDuanName_initialized)
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
            
            if (englishName_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "EnglishName", SqlDbType.NVarChar);
                n_Parameter.Value = this.EnglishName;
                n_Parameter.SourceColumn = "EnglishName";
                parametersList.Add(n_Parameter);
            }
            
            if (ziDuan_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ZiDuan", SqlDbType.NVarChar);
                n_Parameter.Value = this.ZiDuan;
                n_Parameter.SourceColumn = "ZiDuan";
                parametersList.Add(n_Parameter);
            }
            
            if (ziDuanType_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ZiDuanType", SqlDbType.NVarChar);
                n_Parameter.Value = this.ZiDuanType;
                n_Parameter.SourceColumn = "ZiDuanType";
                parametersList.Add(n_Parameter);
            }
            
            if (addType_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "AddType", SqlDbType.NVarChar);
                n_Parameter.Value = this.AddType;
                n_Parameter.SourceColumn = "AddType";
                parametersList.Add(n_Parameter);
            }
            
            if (chengYuan_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ChengYuan", SqlDbType.NVarChar);
                n_Parameter.Value = this.ChengYuan;
                n_Parameter.SourceColumn = "ChengYuan";
                parametersList.Add(n_Parameter);
            }
            
            if (zhi_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Zhi", SqlDbType.NVarChar);
                n_Parameter.Value = this.Zhi;
                n_Parameter.SourceColumn = "Zhi";
                parametersList.Add(n_Parameter);
            }
            
            if (biXu_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "BiXu", SqlDbType.NVarChar);
                n_Parameter.Value = this.BiXu;
                n_Parameter.SourceColumn = "BiXu";
                parametersList.Add(n_Parameter);
            }
            
            if (souSuo_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "SouSuo", SqlDbType.NVarChar);
                n_Parameter.Value = this.SouSuo;
                n_Parameter.SourceColumn = "SouSuo";
                parametersList.Add(n_Parameter);
            }
            
            if (lieBiao_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "LieBiao", SqlDbType.NVarChar);
                n_Parameter.Value = this.LieBiao;
                n_Parameter.SourceColumn = "LieBiao";
                parametersList.Add(n_Parameter);
            }
            
            if (addShow_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "AddShow", SqlDbType.NVarChar);
                n_Parameter.Value = this.AddShow;
                n_Parameter.SourceColumn = "AddShow";
                parametersList.Add(n_Parameter);
            }
            
            if (editShow_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "EditShow", SqlDbType.NVarChar);
                n_Parameter.Value = this.EditShow;
                n_Parameter.SourceColumn = "EditShow";
                parametersList.Add(n_Parameter);
            }
            
            if (shenPiID_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ShenPiID", SqlDbType.Int);
                n_Parameter.Value = this.ShenPiID;
                n_Parameter.SourceColumn = "ShenPiID";
                parametersList.Add(n_Parameter);
            }
            
            if (dingDing_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "DingDing", SqlDbType.NVarChar);
                n_Parameter.Value = this.DingDing;
                n_Parameter.SourceColumn = "DingDing";
                parametersList.Add(n_Parameter);
            }
            
            if (breif_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "Breif", SqlDbType.NVarChar);
                n_Parameter.Value = this.Breif;
                n_Parameter.SourceColumn = "Breif";
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
            
            if (addName_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "AddName", SqlDbType.NVarChar);
                n_Parameter.Value = this.AddName;
                n_Parameter.SourceColumn = "AddName";
                parametersList.Add(n_Parameter);
            }
            
            if (zhongWenZiDuan_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ZhongWenZiDuan", SqlDbType.NVarChar);
                n_Parameter.Value = this.ZhongWenZiDuan;
                n_Parameter.SourceColumn = "ZhongWenZiDuan";
                parametersList.Add(n_Parameter);
            }
            
            if (canEdit_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "CanEdit", SqlDbType.NVarChar);
                n_Parameter.Value = this.CanEdit;
                n_Parameter.SourceColumn = "CanEdit";
                parametersList.Add(n_Parameter);
            }
            
            if (viewShow_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ViewShow", SqlDbType.NVarChar);
                n_Parameter.Value = this.ViewShow;
                n_Parameter.SourceColumn = "ViewShow";
                parametersList.Add(n_Parameter);
            }
            
            if (mangeBumen_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "MangeBumen", SqlDbType.NVarChar);
                n_Parameter.Value = this.MangeBumen;
                n_Parameter.SourceColumn = "MangeBumen";
                parametersList.Add(n_Parameter);
            }
            
            if (manageUser_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ManageUser", SqlDbType.NVarChar);
                n_Parameter.Value = this.ManageUser;
                n_Parameter.SourceColumn = "ManageUser";
                parametersList.Add(n_Parameter);
            }
            
            if (kuaiJiBumen_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "KuaiJiBumen", SqlDbType.NVarChar);
                n_Parameter.Value = this.KuaiJiBumen;
                n_Parameter.SourceColumn = "KuaiJiBumen";
                parametersList.Add(n_Parameter);
            }
            
            if (kuaiJiUser_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "KuaiJiUser", SqlDbType.NVarChar);
                n_Parameter.Value = this.KuaiJiUser;
                n_Parameter.SourceColumn = "KuaiJiUser";
                parametersList.Add(n_Parameter);
            }
            
            if (shengPiDingDing_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "ShengPiDingDing", SqlDbType.NVarChar);
                n_Parameter.Value = this.ShengPiDingDing;
                n_Parameter.SourceColumn = "ShengPiDingDing";
                parametersList.Add(n_Parameter);
            }
            
            if (dingDingZiDuan_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "DingDingZiDuan", SqlDbType.NVarChar);
                n_Parameter.Value = this.DingDingZiDuan;
                n_Parameter.SourceColumn = "DingDingZiDuan";
                parametersList.Add(n_Parameter);
            }
            
            if (dingDingZiDuanName_initialized)
            {
                SqlParameter n_Parameter = new SqlParameter("@" + headStr + "DingDingZiDuanName", SqlDbType.NVarChar);
                n_Parameter.Value = this.DingDingZiDuanName;
                n_Parameter.SourceColumn = "DingDingZiDuanName";
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
                
                if (this.englishName_initialized)
                {
                    contentText += ", [EnglishName]=@" + headStr + "EnglishName ";
                }
                
                if (this.ziDuan_initialized)
                {
                    contentText += ", [ZiDuan]=@" + headStr + "ZiDuan ";
                }
                
                if (this.ziDuanType_initialized)
                {
                    contentText += ", [ZiDuanType]=@" + headStr + "ZiDuanType ";
                }
                
                if (this.addType_initialized)
                {
                    contentText += ", [AddType]=@" + headStr + "AddType ";
                }
                
                if (this.chengYuan_initialized)
                {
                    contentText += ", [ChengYuan]=@" + headStr + "ChengYuan ";
                }
                
                if (this.zhi_initialized)
                {
                    contentText += ", [Zhi]=@" + headStr + "Zhi ";
                }
                
                if (this.biXu_initialized)
                {
                    contentText += ", [BiXu]=@" + headStr + "BiXu ";
                }
                
                if (this.souSuo_initialized)
                {
                    contentText += ", [SouSuo]=@" + headStr + "SouSuo ";
                }
                
                if (this.lieBiao_initialized)
                {
                    contentText += ", [LieBiao]=@" + headStr + "LieBiao ";
                }
                
                if (this.addShow_initialized)
                {
                    contentText += ", [AddShow]=@" + headStr + "AddShow ";
                }
                
                if (this.editShow_initialized)
                {
                    contentText += ", [EditShow]=@" + headStr + "EditShow ";
                }
                
                if (this.shenPiID_initialized)
                {
                    contentText += ", [ShenPiID]=@" + headStr + "ShenPiID ";
                }
                
                if (this.dingDing_initialized)
                {
                    contentText += ", [DingDing]=@" + headStr + "DingDing ";
                }
                
                if (this.breif_initialized)
                {
                    contentText += ", [Breif]=@" + headStr + "Breif ";
                }
                
                if (this.addTime_initialized)
                {
                    contentText += ", [AddTime]=@" + headStr + "AddTime ";
                }
                
                if (this.addID_initialized)
                {
                    contentText += ", [AddID]=@" + headStr + "AddID ";
                }
                
                if (this.addName_initialized)
                {
                    contentText += ", [AddName]=@" + headStr + "AddName ";
                }
                
                if (this.zhongWenZiDuan_initialized)
                {
                    contentText += ", [ZhongWenZiDuan]=@" + headStr + "ZhongWenZiDuan ";
                }
                
                if (this.canEdit_initialized)
                {
                    contentText += ", [CanEdit]=@" + headStr + "CanEdit ";
                }
                
                if (this.viewShow_initialized)
                {
                    contentText += ", [ViewShow]=@" + headStr + "ViewShow ";
                }
                
                if (this.mangeBumen_initialized)
                {
                    contentText += ", [MangeBumen]=@" + headStr + "MangeBumen ";
                }
                
                if (this.manageUser_initialized)
                {
                    contentText += ", [ManageUser]=@" + headStr + "ManageUser ";
                }
                
                if (this.kuaiJiBumen_initialized)
                {
                    contentText += ", [KuaiJiBumen]=@" + headStr + "KuaiJiBumen ";
                }
                
                if (this.kuaiJiUser_initialized)
                {
                    contentText += ", [KuaiJiUser]=@" + headStr + "KuaiJiUser ";
                }
                
                if (this.shengPiDingDing_initialized)
                {
                    contentText += ", [ShengPiDingDing]=@" + headStr + "ShengPiDingDing ";
                }
                
                if (this.dingDingZiDuan_initialized)
                {
                    contentText += ", [DingDingZiDuan]=@" + headStr + "DingDingZiDuan ";
                }
                
                if (this.dingDingZiDuanName_initialized)
                {
                    contentText += ", [DingDingZiDuanName]=@" + headStr + "DingDingZiDuanName ";
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
                
                if (this.englishName_initialized)
                {
                    conditionStr += " AND [EnglishName]=@" + headStr + "EnglishName ";
                }
                
                if (this.ziDuan_initialized)
                {
                    conditionStr += " AND [ZiDuan]=@" + headStr + "ZiDuan ";
                }
                
                if (this.ziDuanType_initialized)
                {
                    conditionStr += " AND [ZiDuanType]=@" + headStr + "ZiDuanType ";
                }
                
                if (this.addType_initialized)
                {
                    conditionStr += " AND [AddType]=@" + headStr + "AddType ";
                }
                
                if (this.chengYuan_initialized)
                {
                    conditionStr += " AND [ChengYuan]=@" + headStr + "ChengYuan ";
                }
                
                if (this.zhi_initialized)
                {
                    conditionStr += " AND [Zhi]=@" + headStr + "Zhi ";
                }
                
                if (this.biXu_initialized)
                {
                    conditionStr += " AND [BiXu]=@" + headStr + "BiXu ";
                }
                
                if (this.souSuo_initialized)
                {
                    conditionStr += " AND [SouSuo]=@" + headStr + "SouSuo ";
                }
                
                if (this.lieBiao_initialized)
                {
                    conditionStr += " AND [LieBiao]=@" + headStr + "LieBiao ";
                }
                
                if (this.addShow_initialized)
                {
                    conditionStr += " AND [AddShow]=@" + headStr + "AddShow ";
                }
                
                if (this.editShow_initialized)
                {
                    conditionStr += " AND [EditShow]=@" + headStr + "EditShow ";
                }
                
                if (this.shenPiID_initialized)
                {
                    conditionStr += " AND [ShenPiID]=@" + headStr + "ShenPiID ";
                }
                
                if (this.dingDing_initialized)
                {
                    conditionStr += " AND [DingDing]=@" + headStr + "DingDing ";
                }
                
                if (this.breif_initialized)
                {
                    conditionStr += " AND [Breif]=@" + headStr + "Breif ";
                }
                
                if (this.addTime_initialized)
                {
                    conditionStr += " AND [AddTime]=@" + headStr + "AddTime ";
                }
                
                if (this.addID_initialized)
                {
                    conditionStr += " AND [AddID]=@" + headStr + "AddID ";
                }
                
                if (this.addName_initialized)
                {
                    conditionStr += " AND [AddName]=@" + headStr + "AddName ";
                }
                
                if (this.zhongWenZiDuan_initialized)
                {
                    conditionStr += " AND [ZhongWenZiDuan]=@" + headStr + "ZhongWenZiDuan ";
                }
                
                if (this.canEdit_initialized)
                {
                    conditionStr += " AND [CanEdit]=@" + headStr + "CanEdit ";
                }
                
                if (this.viewShow_initialized)
                {
                    conditionStr += " AND [ViewShow]=@" + headStr + "ViewShow ";
                }
                
                if (this.mangeBumen_initialized)
                {
                    conditionStr += " AND [MangeBumen]=@" + headStr + "MangeBumen ";
                }
                
                if (this.manageUser_initialized)
                {
                    conditionStr += " AND [ManageUser]=@" + headStr + "ManageUser ";
                }
                
                if (this.kuaiJiBumen_initialized)
                {
                    conditionStr += " AND [KuaiJiBumen]=@" + headStr + "KuaiJiBumen ";
                }
                
                if (this.kuaiJiUser_initialized)
                {
                    conditionStr += " AND [KuaiJiUser]=@" + headStr + "KuaiJiUser ";
                }
                
                if (this.shengPiDingDing_initialized)
                {
                    conditionStr += " AND [ShengPiDingDing]=@" + headStr + "ShengPiDingDing ";
                }
                
                if (this.dingDingZiDuan_initialized)
                {
                    conditionStr += " AND [DingDingZiDuan]=@" + headStr + "DingDingZiDuan ";
                }
                
                if (this.dingDingZiDuanName_initialized)
                {
                    conditionStr += " AND [DingDingZiDuanName]=@" + headStr + "DingDingZiDuanName ";
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
                
                if (this.englishName_initialized)
                {
                    contentText += ", [EnglishName] ";
                }
                
                if (this.ziDuan_initialized)
                {
                    contentText += ", [ZiDuan] ";
                }
                
                if (this.ziDuanType_initialized)
                {
                    contentText += ", [ZiDuanType] ";
                }
                
                if (this.addType_initialized)
                {
                    contentText += ", [AddType] ";
                }
                
                if (this.chengYuan_initialized)
                {
                    contentText += ", [ChengYuan] ";
                }
                
                if (this.zhi_initialized)
                {
                    contentText += ", [Zhi] ";
                }
                
                if (this.biXu_initialized)
                {
                    contentText += ", [BiXu] ";
                }
                
                if (this.souSuo_initialized)
                {
                    contentText += ", [SouSuo] ";
                }
                
                if (this.lieBiao_initialized)
                {
                    contentText += ", [LieBiao] ";
                }
                
                if (this.addShow_initialized)
                {
                    contentText += ", [AddShow] ";
                }
                
                if (this.editShow_initialized)
                {
                    contentText += ", [EditShow] ";
                }
                
                if (this.shenPiID_initialized)
                {
                    contentText += ", [ShenPiID] ";
                }
                
                if (this.dingDing_initialized)
                {
                    contentText += ", [DingDing] ";
                }
                
                if (this.breif_initialized)
                {
                    contentText += ", [Breif] ";
                }
                
                if (this.addTime_initialized)
                {
                    contentText += ", [AddTime] ";
                }
                
                if (this.addID_initialized)
                {
                    contentText += ", [AddID] ";
                }
                
                if (this.addName_initialized)
                {
                    contentText += ", [AddName] ";
                }
                
                if (this.zhongWenZiDuan_initialized)
                {
                    contentText += ", [ZhongWenZiDuan] ";
                }
                
                if (this.canEdit_initialized)
                {
                    contentText += ", [CanEdit] ";
                }
                
                if (this.viewShow_initialized)
                {
                    contentText += ", [ViewShow] ";
                }
                
                if (this.mangeBumen_initialized)
                {
                    contentText += ", [MangeBumen] ";
                }
                
                if (this.manageUser_initialized)
                {
                    contentText += ", [ManageUser] ";
                }
                
                if (this.kuaiJiBumen_initialized)
                {
                    contentText += ", [KuaiJiBumen] ";
                }
                
                if (this.kuaiJiUser_initialized)
                {
                    contentText += ", [KuaiJiUser] ";
                }
                
                if (this.shengPiDingDing_initialized)
                {
                    contentText += ", [ShengPiDingDing] ";
                }
                
                if (this.dingDingZiDuan_initialized)
                {
                    contentText += ", [DingDingZiDuan] ";
                }
                
                if (this.dingDingZiDuanName_initialized)
                {
                    contentText += ", [DingDingZiDuanName] ";
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
                
                if (this.englishName_initialized)
                {
                    contentText += ", @" + headStr + "EnglishName ";
                }
                
                if (this.ziDuan_initialized)
                {
                    contentText += ", @" + headStr + "ZiDuan ";
                }
                
                if (this.ziDuanType_initialized)
                {
                    contentText += ", @" + headStr + "ZiDuanType ";
                }
                
                if (this.addType_initialized)
                {
                    contentText += ", @" + headStr + "AddType ";
                }
                
                if (this.chengYuan_initialized)
                {
                    contentText += ", @" + headStr + "ChengYuan ";
                }
                
                if (this.zhi_initialized)
                {
                    contentText += ", @" + headStr + "Zhi ";
                }
                
                if (this.biXu_initialized)
                {
                    contentText += ", @" + headStr + "BiXu ";
                }
                
                if (this.souSuo_initialized)
                {
                    contentText += ", @" + headStr + "SouSuo ";
                }
                
                if (this.lieBiao_initialized)
                {
                    contentText += ", @" + headStr + "LieBiao ";
                }
                
                if (this.addShow_initialized)
                {
                    contentText += ", @" + headStr + "AddShow ";
                }
                
                if (this.editShow_initialized)
                {
                    contentText += ", @" + headStr + "EditShow ";
                }
                
                if (this.shenPiID_initialized)
                {
                    contentText += ", @" + headStr + "ShenPiID ";
                }
                
                if (this.dingDing_initialized)
                {
                    contentText += ", @" + headStr + "DingDing ";
                }
                
                if (this.breif_initialized)
                {
                    contentText += ", @" + headStr + "Breif ";
                }
                
                if (this.addTime_initialized)
                {
                    contentText += ", @" + headStr + "AddTime ";
                }
                
                if (this.addID_initialized)
                {
                    contentText += ", @" + headStr + "AddID ";
                }
                
                if (this.addName_initialized)
                {
                    contentText += ", @" + headStr + "AddName ";
                }
                
                if (this.zhongWenZiDuan_initialized)
                {
                    contentText += ", @" + headStr + "ZhongWenZiDuan ";
                }
                
                if (this.canEdit_initialized)
                {
                    contentText += ", @" + headStr + "CanEdit ";
                }
                
                if (this.viewShow_initialized)
                {
                    contentText += ", @" + headStr + "ViewShow ";
                }
                
                if (this.mangeBumen_initialized)
                {
                    contentText += ", @" + headStr + "MangeBumen ";
                }
                
                if (this.manageUser_initialized)
                {
                    contentText += ", @" + headStr + "ManageUser ";
                }
                
                if (this.kuaiJiBumen_initialized)
                {
                    contentText += ", @" + headStr + "KuaiJiBumen ";
                }
                
                if (this.kuaiJiUser_initialized)
                {
                    contentText += ", @" + headStr + "KuaiJiUser ";
                }
                
                if (this.shengPiDingDing_initialized)
                {
                    contentText += ", @" + headStr + "ShengPiDingDing ";
                }
                
                if (this.dingDingZiDuan_initialized)
                {
                    contentText += ", @" + headStr + "DingDingZiDuan ";
                }
                
                if (this.dingDingZiDuanName_initialized)
                {
                    contentText += ", @" + headStr + "DingDingZiDuanName ";
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
            string tableName = "TableManage";
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
            
            this.englishName_initialized = true;
            
            this.ziDuan_initialized = true;
            
            this.ziDuanType_initialized = true;
            
            this.addType_initialized = true;
            
            this.chengYuan_initialized = true;
            
            this.zhi_initialized = true;
            
            this.biXu_initialized = true;
            
            this.souSuo_initialized = true;
            
            this.lieBiao_initialized = true;
            
            this.addShow_initialized = true;
            
            this.editShow_initialized = true;
            
            this.shenPiID_initialized = true;
            
            this.dingDing_initialized = true;
            
            this.breif_initialized = true;
            
            this.addTime_initialized = true;
            
            this.addID_initialized = true;
            
            this.addName_initialized = true;
            
            this.zhongWenZiDuan_initialized = true;
            
            this.canEdit_initialized = true;
            
            this.viewShow_initialized = true;
            
            this.mangeBumen_initialized = true;
            
            this.manageUser_initialized = true;
            
            this.kuaiJiBumen_initialized = true;
            
            this.kuaiJiUser_initialized = true;
            
            this.shengPiDingDing_initialized = true;
            
            this.dingDingZiDuan_initialized = true;
            
            this.dingDingZiDuanName_initialized = true;
            
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

            
            if(page.Request["englishName"] != null)
            {
                if (this.englishName_initialized)
                {
                    if(page.Request["englishName"] != "")
                    {
                        this.EnglishName = Convert.ToString(page.Request["englishName"]);
                    }
                    else
                    {
                        this.englishName_initialized = false;
                    }
                }
                else
                {
                    this.EnglishName = Convert.ToString(page.Request["englishName"]);
                }
            }

            
            if(page.Request["ziDuan"] != null)
            {
                if (this.ziDuan_initialized)
                {
                    if(page.Request["ziDuan"] != "")
                    {
                        this.ZiDuan = Convert.ToString(page.Request["ziDuan"]);
                    }
                    else
                    {
                        this.ziDuan_initialized = false;
                    }
                }
                else
                {
                    this.ZiDuan = Convert.ToString(page.Request["ziDuan"]);
                }
            }

            
            if(page.Request["ziDuanType"] != null)
            {
                if (this.ziDuanType_initialized)
                {
                    if(page.Request["ziDuanType"] != "")
                    {
                        this.ZiDuanType = Convert.ToString(page.Request["ziDuanType"]);
                    }
                    else
                    {
                        this.ziDuanType_initialized = false;
                    }
                }
                else
                {
                    this.ZiDuanType = Convert.ToString(page.Request["ziDuanType"]);
                }
            }

            
            if(page.Request["addType"] != null)
            {
                if (this.addType_initialized)
                {
                    if(page.Request["addType"] != "")
                    {
                        this.AddType = Convert.ToString(page.Request["addType"]);
                    }
                    else
                    {
                        this.addType_initialized = false;
                    }
                }
                else
                {
                    this.AddType = Convert.ToString(page.Request["addType"]);
                }
            }

            
            if(page.Request["chengYuan"] != null)
            {
                if (this.chengYuan_initialized)
                {
                    if(page.Request["chengYuan"] != "")
                    {
                        this.ChengYuan = Convert.ToString(page.Request["chengYuan"]);
                    }
                    else
                    {
                        this.chengYuan_initialized = false;
                    }
                }
                else
                {
                    this.ChengYuan = Convert.ToString(page.Request["chengYuan"]);
                }
            }

            
            if(page.Request["zhi"] != null)
            {
                if (this.zhi_initialized)
                {
                    if(page.Request["zhi"] != "")
                    {
                        this.Zhi = Convert.ToString(page.Request["zhi"]);
                    }
                    else
                    {
                        this.zhi_initialized = false;
                    }
                }
                else
                {
                    this.Zhi = Convert.ToString(page.Request["zhi"]);
                }
            }

            
            if(page.Request["biXu"] != null)
            {
                if (this.biXu_initialized)
                {
                    if(page.Request["biXu"] != "")
                    {
                        this.BiXu = Convert.ToString(page.Request["biXu"]);
                    }
                    else
                    {
                        this.biXu_initialized = false;
                    }
                }
                else
                {
                    this.BiXu = Convert.ToString(page.Request["biXu"]);
                }
            }

            
            if(page.Request["souSuo"] != null)
            {
                if (this.souSuo_initialized)
                {
                    if(page.Request["souSuo"] != "")
                    {
                        this.SouSuo = Convert.ToString(page.Request["souSuo"]);
                    }
                    else
                    {
                        this.souSuo_initialized = false;
                    }
                }
                else
                {
                    this.SouSuo = Convert.ToString(page.Request["souSuo"]);
                }
            }

            
            if(page.Request["lieBiao"] != null)
            {
                if (this.lieBiao_initialized)
                {
                    if(page.Request["lieBiao"] != "")
                    {
                        this.LieBiao = Convert.ToString(page.Request["lieBiao"]);
                    }
                    else
                    {
                        this.lieBiao_initialized = false;
                    }
                }
                else
                {
                    this.LieBiao = Convert.ToString(page.Request["lieBiao"]);
                }
            }

            
            if(page.Request["addShow"] != null)
            {
                if (this.addShow_initialized)
                {
                    if(page.Request["addShow"] != "")
                    {
                        this.AddShow = Convert.ToString(page.Request["addShow"]);
                    }
                    else
                    {
                        this.addShow_initialized = false;
                    }
                }
                else
                {
                    this.AddShow = Convert.ToString(page.Request["addShow"]);
                }
            }

            
            if(page.Request["editShow"] != null)
            {
                if (this.editShow_initialized)
                {
                    if(page.Request["editShow"] != "")
                    {
                        this.EditShow = Convert.ToString(page.Request["editShow"]);
                    }
                    else
                    {
                        this.editShow_initialized = false;
                    }
                }
                else
                {
                    this.EditShow = Convert.ToString(page.Request["editShow"]);
                }
            }

            
            if(page.Request["shenPiID"] != null)
            {
                if (this.shenPiID_initialized)
                {
                    if(page.Request["shenPiID"] != "")
                    {
                        this.ShenPiID = Convert.ToInt32(page.Request["shenPiID"]);
                    }
                    else
                    {
                        this.shenPiID_initialized = false;
                    }
                }
                else
                {
                    this.ShenPiID = Convert.ToInt32(page.Request["shenPiID"]);
                }
            }

            
            if(page.Request["dingDing"] != null)
            {
                if (this.dingDing_initialized)
                {
                    if(page.Request["dingDing"] != "")
                    {
                        this.DingDing = Convert.ToString(page.Request["dingDing"]);
                    }
                    else
                    {
                        this.dingDing_initialized = false;
                    }
                }
                else
                {
                    this.DingDing = Convert.ToString(page.Request["dingDing"]);
                }
            }

            
            if(page.Request["breif"] != null)
            {
                if (this.breif_initialized)
                {
                    if(page.Request["breif"] != "")
                    {
                        this.Breif = Convert.ToString(page.Request["breif"]);
                    }
                    else
                    {
                        this.breif_initialized = false;
                    }
                }
                else
                {
                    this.Breif = Convert.ToString(page.Request["breif"]);
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

            
            if(page.Request["zhongWenZiDuan"] != null)
            {
                if (this.zhongWenZiDuan_initialized)
                {
                    if(page.Request["zhongWenZiDuan"] != "")
                    {
                        this.ZhongWenZiDuan = Convert.ToString(page.Request["zhongWenZiDuan"]);
                    }
                    else
                    {
                        this.zhongWenZiDuan_initialized = false;
                    }
                }
                else
                {
                    this.ZhongWenZiDuan = Convert.ToString(page.Request["zhongWenZiDuan"]);
                }
            }

            
            if(page.Request["canEdit"] != null)
            {
                if (this.canEdit_initialized)
                {
                    if(page.Request["canEdit"] != "")
                    {
                        this.CanEdit = Convert.ToString(page.Request["canEdit"]);
                    }
                    else
                    {
                        this.canEdit_initialized = false;
                    }
                }
                else
                {
                    this.CanEdit = Convert.ToString(page.Request["canEdit"]);
                }
            }

            
            if(page.Request["viewShow"] != null)
            {
                if (this.viewShow_initialized)
                {
                    if(page.Request["viewShow"] != "")
                    {
                        this.ViewShow = Convert.ToString(page.Request["viewShow"]);
                    }
                    else
                    {
                        this.viewShow_initialized = false;
                    }
                }
                else
                {
                    this.ViewShow = Convert.ToString(page.Request["viewShow"]);
                }
            }

            
            if(page.Request["mangeBumen"] != null)
            {
                if (this.mangeBumen_initialized)
                {
                    if(page.Request["mangeBumen"] != "")
                    {
                        this.MangeBumen = Convert.ToString(page.Request["mangeBumen"]);
                    }
                    else
                    {
                        this.mangeBumen_initialized = false;
                    }
                }
                else
                {
                    this.MangeBumen = Convert.ToString(page.Request["mangeBumen"]);
                }
            }

            
            if(page.Request["manageUser"] != null)
            {
                if (this.manageUser_initialized)
                {
                    if(page.Request["manageUser"] != "")
                    {
                        this.ManageUser = Convert.ToString(page.Request["manageUser"]);
                    }
                    else
                    {
                        this.manageUser_initialized = false;
                    }
                }
                else
                {
                    this.ManageUser = Convert.ToString(page.Request["manageUser"]);
                }
            }

            
            if(page.Request["kuaiJiBumen"] != null)
            {
                if (this.kuaiJiBumen_initialized)
                {
                    if(page.Request["kuaiJiBumen"] != "")
                    {
                        this.KuaiJiBumen = Convert.ToString(page.Request["kuaiJiBumen"]);
                    }
                    else
                    {
                        this.kuaiJiBumen_initialized = false;
                    }
                }
                else
                {
                    this.KuaiJiBumen = Convert.ToString(page.Request["kuaiJiBumen"]);
                }
            }

            
            if(page.Request["kuaiJiUser"] != null)
            {
                if (this.kuaiJiUser_initialized)
                {
                    if(page.Request["kuaiJiUser"] != "")
                    {
                        this.KuaiJiUser = Convert.ToString(page.Request["kuaiJiUser"]);
                    }
                    else
                    {
                        this.kuaiJiUser_initialized = false;
                    }
                }
                else
                {
                    this.KuaiJiUser = Convert.ToString(page.Request["kuaiJiUser"]);
                }
            }

            
            if(page.Request["shengPiDingDing"] != null)
            {
                if (this.shengPiDingDing_initialized)
                {
                    if(page.Request["shengPiDingDing"] != "")
                    {
                        this.ShengPiDingDing = Convert.ToString(page.Request["shengPiDingDing"]);
                    }
                    else
                    {
                        this.shengPiDingDing_initialized = false;
                    }
                }
                else
                {
                    this.ShengPiDingDing = Convert.ToString(page.Request["shengPiDingDing"]);
                }
            }

            
            if(page.Request["dingDingZiDuan"] != null)
            {
                if (this.dingDingZiDuan_initialized)
                {
                    if(page.Request["dingDingZiDuan"] != "")
                    {
                        this.DingDingZiDuan = Convert.ToString(page.Request["dingDingZiDuan"]);
                    }
                    else
                    {
                        this.dingDingZiDuan_initialized = false;
                    }
                }
                else
                {
                    this.DingDingZiDuan = Convert.ToString(page.Request["dingDingZiDuan"]);
                }
            }

            
            if(page.Request["dingDingZiDuanName"] != null)
            {
                if (this.dingDingZiDuanName_initialized)
                {
                    if(page.Request["dingDingZiDuanName"] != "")
                    {
                        this.DingDingZiDuanName = Convert.ToString(page.Request["dingDingZiDuanName"]);
                    }
                    else
                    {
                        this.dingDingZiDuanName_initialized = false;
                    }
                }
                else
                {
                    this.DingDingZiDuanName = Convert.ToString(page.Request["dingDingZiDuanName"]);
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