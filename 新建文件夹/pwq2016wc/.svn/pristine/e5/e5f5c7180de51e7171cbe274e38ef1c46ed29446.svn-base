using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class Plusbe2019_ManageUserinfo_Manage : AdminAndPage
{
    protected List<Face> m_tableManageList;
    protected int Gender = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        Face condition = new Face();
        Face value = new Face();
        string phone = GetstringKey("phone");
  
        if (!string.IsNullOrEmpty(Request["Name"]))
        {
            condition.AddConditon(" and ( Name like @Name or NickName like @Name)");
            condition.AddParameter("Name", "%" + Request["Name"] + "%");
        }
       
        m_tableManageList = TableOperate<Face>.SelectByPage(value, condition, "order by  OrderID asc", PageSize, PageIndex, ref Count);     
        DataBind();   
       
    }
    public void DeleteNoFace()
    {
        Face condition = new Face();
        condition.States = 0;
        Face value = new Face();
        TableOperate<Face>.Delete(condition);
    }
    protected string Image(string path)
    {
        if (string.IsNullOrEmpty(path)) return "无";
        return string.Format("<img data-target=\"../../{0}\" style=\"width:80px;height:80px\" class=\"img-circle target\" src=\"../../{0}\"/>", path);
    }
    protected string GetAgeType(int age)
    {
        switch (age)
        {
            case 0:
                return "选择年龄段";
            case 1:
                return "20岁及以下";
            case 2:
                return "21-30岁";
            case 3:
                return "31-40岁";
            case 4:
                return "41-50岁";
            case 5:
                return "51-60岁";
            case 6:
                return "60岁以上";
            default:
                return "";
        }
    }
    protected string GetTradeType(int reade)
    {
        switch (reade)
        {
            case 0:
                return "未选择";
            case 1:
                return "金融";
            case 2:
                return "电商";
            case 3:
                return "IT";
            case 4:
                return "法律";
            case 5:
                return "政府";
            case 6:
                return "汽车业";
            case 7:
                return "林业";
            case 8:
                return "制造业";
            default:
                return "";
        }
    }
    protected string GetGenderType(int gender)
    {
        switch (gender)
        {
            case 0:
                return "未选择";
            case 1:
                return "男";
            case 2:
                return "女";
            default:
                return "";
        }
    }
}