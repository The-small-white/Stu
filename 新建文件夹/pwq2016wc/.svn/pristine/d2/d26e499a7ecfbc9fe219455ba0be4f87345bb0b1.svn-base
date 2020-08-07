using System;
using System.Web;
using System.Collections.Generic;
using Dejun.DataProvider.Table;
using Dejun.DataProvider.Sql2005;

/// <summary>
/// 管理员的一些方法
/// </summary>
public class AdminMethod
{
    public AdminMethod()
    {

    }

    /// <summary>
    /// 获取具有某权限的人员列表
    /// </summary>
    /// <param name="manage"></param>
    /// <returns></returns>
    public static List<Admin_User> GetHasManageAdmin(string manage)
    {
        List<Admin_User> returnList=new List<Admin_User>();
        Admin_User condition = new Admin_User();
        Admin_User value = new Admin_User();
        condition.AddConditon(" and manage like @Manage");
        condition.AddParameter("Manage", "%" + manage + "%");

        List<Admin_User> list = TableOperate<Admin_User>.Select(value, condition);
        foreach (Admin_User item in list)
        {
            if (string.IsNullOrEmpty(item.Manage)) continue;
            string[] arr = item.Manage.Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == manage)
                {
                    returnList.Add(item);
                    break;
                }
            }
        }
        return returnList;
    }
    public static void UpdataManage(string Manage)
    {
        if (Manage != null && Manage != "")
        {
            string[] arrManage = Manage.Split(',');
            HttpContext.Current.Session["adminManage"] = arrManage;
        }
    }
    /// <summary>
    /// 账号是否存在
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static bool IsName(string name)
    {
        Admin_User condition = new Admin_User();
        condition.Name = name;
        int ID= TableOperate<Admin_User>.GetCountValue(condition);
        if (ID > 0)
        {
            return true;
        }
        return false;
    }


    #region 验证用户名，密码
    /// <summary>
    /// 验证用户名，密码
    /// </summary>
    /// <param name="username">用户名</param>
    /// <param name="password">密码</param>
    /// <returns></returns>
    public static Boolean VerifyPwd(string username, string password)
    {

        if (string.IsNullOrEmpty(username)) return false;
        if (string.IsNullOrEmpty(password)) return false;

        string jiaMiPass = Md5JiaMi.JiaMi(password); //加密密码

        Admin_User valueTable = new Admin_User();


        Admin_User conditionTable = new Admin_User();
        conditionTable.Name = username;
        conditionTable.Pass = jiaMiPass;
        conditionTable.AddConditon(" and States > 0");
        Admin_User admin = TableOperate<Admin_User>.GetRowData(valueTable, conditionTable);

        if (!admin.IsNull)
        {
            GetConfig();
            HttpContext.Current.Session["adminName"] = username;
            if (admin.HeadPic != null && admin.HeadPic != "")
            {
                HttpContext.Current.Session["headpic"] = SysConfig.headpicfile + admin.HeadPic;
            }
            HttpContext.Current.Session["adminFullName"] = admin.FullName;
            HttpContext.Current.Session["adminLevel"] = admin.UserLevel;
            HttpContext.Current.Session["adminID"] = admin.ID;
            HttpContext.Current.Session["ExhibitionID"] = admin.ExhibitionID;
            if (admin.Manage != null && admin.Manage != "")
            {
                string[] arrManage = admin.Manage.Split(',');
                HttpContext.Current.Session["adminManage"] = arrManage;
            }
           
            UpdateLoginDate(admin.ID); //更新最后登录时间
            string check = admin.ID + "|" + AdminJiaMi(admin.ID, admin.Pass, HttpContext.Current.Request.UserHostName, HttpContext.Current.Request.UserHostAddress);
           // CookieUserCheck = check;


            return true;
        }
        return false;
    }
    /// <summary>
    /// 获取全局的是否启用白名单
    /// </summary>
    public static void GetConfig()
    {
        GlobalConfig condition = new GlobalConfig();
        condition.ID = 1;
        GlobalConfig global = TableOperate<GlobalConfig>.GetRowData(condition);
        if (global.ID > 0)
        {
            HttpContext.Current.Session["UserIP"] = global.UserIP;
        }
    }
    public static bool VerifyPwd(Admin_User admin)
    {
        HttpContext.Current.Session["adminName"] = admin.Name;
        if (admin.HeadPic != null && admin.HeadPic != "")
        {
            HttpContext.Current.Session["headpic"] = SysConfig.headpicfile + admin.HeadPic;
        }
        HttpContext.Current.Session["adminFullName"] = admin.FullName;
        HttpContext.Current.Session["adminLevel"] = admin.UserLevel;
        HttpContext.Current.Session["adminID"] = admin.ID;
        HttpContext.Current.Session["ExhibitionID"] = admin.ExhibitionID;
        string[] arrManage = admin.Manage.Split(',');
        HttpContext.Current.Session["adminManage"] = arrManage;
        UpdateLoginDate(admin.ID); //更新最后登录时间

        //CookieUserID = admin.ID;
        string check = admin.ID + "|" + AdminJiaMi(admin.ID, admin.Pass, HttpContext.Current.Request.UserHostName, HttpContext.Current.Request.UserHostAddress);
        CookieUserCheck = check;

        return true;
    }

    public static Boolean VerifyPwd(int id)
    {
        Admin_User valueTable = new Admin_User();

        Admin_User conditionTable = new Admin_User();
        conditionTable.ID = id;
        conditionTable.States = 1;
        Admin_User admin = TableOperate<Admin_User>.GetRowData(valueTable, conditionTable);

        if (!admin.IsNull)
        {
            //page.s
            HttpContext.Current.Session["adminName"] = admin.Name;
            if (admin.HeadPic != null && admin.HeadPic != "")
            {
                HttpContext.Current.Session["headpic"] = SysConfig.headpicfile + admin.HeadPic;
            }
            HttpContext.Current.Session["adminFullName"] = admin.FullName;
            HttpContext.Current.Session["adminLevel"] = admin.UserLevel;
            HttpContext.Current.Session["ExhibitionID"] = admin.ExhibitionID;
            HttpContext.Current.Session["adminID"] = admin.ID;
           

            string[] arrManage = admin.Manage.Split(',');
            HttpContext.Current.Session["adminManage"] = arrManage;
            HttpContext.Current.Session.Timeout = 60;
            UpdateLoginDate(admin.ID); //更新最后登录时间
            //CookieUserID = admin.ID;
            string check = admin.ID + "|" + AdminJiaMi(admin.ID, admin.Pass, HttpContext.Current.Request.UserHostName, HttpContext.Current.Request.UserHostAddress);
            CookieUserCheck = check;
            return true;
        }
        return false;
    }


   


    public static Boolean VerifyUser(string mix)
    {
        string[] infoArr = mix.Split('|');
        if (infoArr.Length != 2)
        {
            return false;
        }

        int userid = -1;
        if (!int.TryParse(infoArr[0], out userid))
        {
            return false;
        }
        Admin_User valueTable = new Admin_User();

        Admin_User conditionTable = new Admin_User();
        conditionTable.ID = userid;

        Admin_User admin = TableOperate<Admin_User>.GetRowData(valueTable, conditionTable);
        string check = AdminJiaMi(admin.ID, admin.Pass, HttpContext.Current.Request.UserHostName, HttpContext.Current.Request.UserHostAddress);

        //TimeSpan t = DateTime.Now - admin.LastLoginTime;
 
       
            HttpContext.Current.Session["adminName"] = admin.Name;
            HttpContext.Current.Session["adminFullName"] = admin.FullName;
            HttpContext.Current.Session["adminLevel"] = admin.UserLevel;
        if (admin.HeadPic != null && admin.HeadPic != "")
        {
            HttpContext.Current.Session["headpic"] = SysConfig.headpicfile + admin.HeadPic;
        }
            
            HttpContext.Current.Session["ExhibitionID"] = admin.ExhibitionID;
            HttpContext.Current.Session["adminID"] = admin.ID;
            string[] arrManage = admin.Manage.Split(',');
            HttpContext.Current.Session["adminManage"] = arrManage;
            UpdateLoginDate(admin.ID); //更新最后登录时间
            //CookieUserID = admin.ID;
            CookieUserCheck = admin.ID + "|" + check;
            return true;
        
       
    }



    #endregion

    #region 判断是否通过验证
    /// <summary>
    /// 判断是否通过验证
    /// </summary>
    public static Boolean IsAuthenticated
    {
        get
        {
            if (UserIP == 1 && !IsWhite())
            {
                return false;
            }
            string userLevel = Convert.ToString(HttpContext.Current.Session["adminLevel"]);


            if (!string.IsNullOrEmpty(userLevel))
            {
                int adminLevel = Convert.ToInt32(userLevel);
                if (adminLevel >= -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                //Cookie判断

               // return VerifyUser(CookieUserCheck);

            }
            return false;
        }
    }
    /// <summary>
    ///是否白名单 是返回true
    /// </summary>
    /// <returns></returns>
    public static bool IsWhite()
    {
        IPWhite condition = new IPWhite();
        condition.States = 1;
        IPWhite value = new IPWhite();
        List<IPWhite> list = TableOperate<IPWhite>.Select(value,condition);
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].IP == GetIP())
            {
                return true;
            }
        }
        return false;
    }
    public static string GetIP()
    {
        string userIP = "";
        HttpRequest Request = System.Web.HttpContext.Current.Request; // 如果使用代理，获取真实IP  
        if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")
        {
            userIP = Request.ServerVariables["REMOTE_ADDR"];
        }
        else
        {
            userIP = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        }
           
        if (userIP == null || userIP == "")
            userIP = Request.UserHostAddress;
        return userIP;
    }
    #endregion 判断是否通过验证

    /// <summary>
    /// 管理员等级
    /// </summary>
    public static int AdminLevel
    {
        get
        {
            string userLevel = Convert.ToString(HttpContext.Current.Session["adminLevel"]);
            if (string.IsNullOrEmpty(userLevel))
            {
                return -1;
            }
            else
            {
                int adminLevel = (Convert.ToInt32(userLevel));
                return adminLevel;
            }

        }
    }
    /// <summary>
    /// 是否启用白名单 1是启用 0是不启用
    /// </summary>
    public static int UserIP
    {
        get
        {
            string _UserIP = Convert.ToString(HttpContext.Current.Session["UserIP"]);
            if (string.IsNullOrEmpty(_UserIP))
            {
                return -1;
            }
            else
            {
                int adminLevel = (Convert.ToInt32(_UserIP));
                return adminLevel;
            }

        }
    }

    public static string AdminJiaMi(int id, string pass, string host, string ip)
    {
        string str = Md5JiaMi.JiaMi(id + pass + host + ip + "UO*&^*&^(*B(*NIKGFYTFTrfTR");
        return str;
    }
    /// <summary>
    /// 管理员ID
    /// </summary>
    public static int AdminID
    {
        get
        {
            string adminIDStr = Convert.ToString(HttpContext.Current.Session["adminID"]);
            if (string.IsNullOrEmpty(adminIDStr))
            {
                return 0;
            }
            else
            {
                int adminID = (Convert.ToInt32(adminIDStr));
                return adminID;
            }

        }
    }
    public static string HeadPic
    {
        get
        {
            string _adminManage = Convert.ToString(HttpContext.Current.Session["headpic"]);
            if (string.IsNullOrEmpty(_adminManage))
            {
                return SysConfig.Hui+ "img/profile_small.jpg";
            }
            else
            {

                return _adminManage;
            }

        }
    }
    public static string AdminManages
    {
        get
        {
            string _adminManage = Convert.ToString(HttpContext.Current.Session["adminManage"]);
            if (string.IsNullOrEmpty(_adminManage))
            {
                return "";
            }
            else
            {
                
                return _adminManage;
            }

        }
    }
    public static string CookieUserCheck
    {
        get
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["check"];
            if (cookie == null)
            {
                return "";
            }
            else
            {
                return cookie.Value;
            }
        }
        set
        {
            HttpCookie cookie = new HttpCookie("check");
 
            //设定此cookies值
            //设定cookie的生命周期，在这里定义为一个小时
            DateTime expiresTime = DateTime.Now.AddHours(2);
            cookie.Expires = expiresTime;
            cookie.Value = value;

            //加入此cookie
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
     

    /// <summary>
    /// 展厅ID
    /// </summary>
    public static int ExhibitionID
    {
        get
        {
            string adminIDStr = Convert.ToString(HttpContext.Current.Session["ExhibitionID"]);
            if (string.IsNullOrEmpty(adminIDStr))
            {
                return 0;
            }
            else
            {
                int adminID = (Convert.ToInt32(adminIDStr));
                return adminID;
            }

        }
    }


    #region 更新最后登录时间
    /// <summary>
    /// 更新最后登录时间
    /// </summary>
    /// <param name="username">用户名</param>
    public static void UpdateLoginDate(int AdminID)
    {

        Admin_User condition = new Admin_User();
        condition.ID = AdminID;
        condition.LastLoginTime = DateTime.Now;
        TableOperate<Admin_User>.Update(condition);
        string log = "管理员:【" + AdminFullName + "】在" + DateTime.Now.GetDateTimeFormats('f')[0].ToString() + "进行登陆" ;
        Lognet.AddLogin(log);
    }
    #endregion 更新最后登录时间



    /// <summary>
    /// 获取管理员管理权限
    /// </summary>
    public static string[] AdminManage
    {
        get
        {
            return (string[])HttpContext.Current.Session["adminManage"];
        }
    }
   
    /// <summary>
    /// 获取是否有特定权限
    /// </summary>
    /// <param name="manage">权限名称</param>
    public static bool HasManage(string manage)
    {
        string[] manageArr = (string[])HttpContext.Current.Session["adminManage"];
        if (manageArr.Length <= 0) return false;
        for (int i = 0; i < manageArr.Length; i++)
        {
            if (manage.ToLower() == manageArr[i].ToLower())
                return true;
        }
        return false;
    }

    public static bool CheckManage(string strManage)
    {
        if (AdminManage == null) return false;

        for (int i = 0; i < AdminManage.Length; i++)
        {
            if (AdminManage[i] == strManage)
            {
                return true;
            }
        }
        return false;
    }


    public static string AdminName
    {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["adminName"]);
        }
    }

    /// <summary>
    /// 获取管理员名字
    /// </summary>
    public static string AdminFullName
    {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["adminFullName"]);
        }
    }
    public static DateTime LastTime
    {
        get
        {
            return Convert.ToDateTime(HttpContext.Current.Session["adminlasttime"]);
        }
    }


    public static void LoginOut()
    {
        HttpContext.Current.Session.Remove("adminlasttime");
        HttpContext.Current.Session.Remove("adminFullName");
        HttpContext.Current.Session.Remove("adminName");
        HttpContext.Current.Session.Remove("adminLevel");
        HttpContext.Current.Session.Remove("adminID");
        HttpContext.Current.Session.Remove("adminManage");

        HttpCookie cookie = new HttpCookie("check");
        //设定此cookies值
        //设定cookie的生命周期，在这里定义为一个小时
        DateTime expiresTime = new DateTime(1900, 1, 1, 0, 0, 0, 0);
        cookie.Expires = expiresTime;
       
        cookie.Value = "";
        //加入此cookie
        HttpContext.Current.Response.Cookies.Add(cookie);


    }
    public enum EnumAdminStates
    {
        锁定 = 0,
        正常 = 1,
        //管理员=3
        //代理商=2
    }
    public enum EnumAdminLevel
    {
        普通 = 0,
        管理员 = 1,
        开发人员=2,
        内容管理员=-1
    }


}

