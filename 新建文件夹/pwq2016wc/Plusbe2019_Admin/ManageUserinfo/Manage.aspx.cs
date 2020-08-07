using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class Plusbe2019_ManageUserinfo_Manage : AdminAndPage
{
    protected List<Userinfo_View> m_tableManageList;
    protected int Gender = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Userinfo_View condition = new Userinfo_View();
        Userinfo_View value = new Userinfo_View();
        string phone = GetstringKey("phone");
  
        if (!string.IsNullOrEmpty(Request["Name"]))
        {
            condition.AddConditon(" and ( Name like @Name or NickName like @Name)");
            condition.AddParameter("Name", "%" + Request["Name"] + "%");
        }
        if (phone != "")
        {
            condition.Phone = "%" + phone + "%";
            condition.AddAttach("Phone", "like");
        }

        condition.ExhibitionID = AdminMethod.ExhibitionID;
        m_tableManageList = TableOperate<Userinfo_View>.SelectByPage(value, condition, "order by  OrderID asc", PageSize, PageIndex, ref Count);     
        DataBind();   
       
    }
    protected string Image(string path)
    {
        if (string.IsNullOrEmpty(path)) return "无";
        return string.Format("<img data-target=\"../../{0}\" style=\"width:80px;height:80px\" class=\"img-circle target\" src=\"../../UserFacePic/{0}\"/>", path);
    }
    protected string GetGenderType(int gender)
    {
        switch (gender)
        {
           
            case 0:
                return "男";
            case 1:
                return "女";
            default:
                return "";
        }
    }
}