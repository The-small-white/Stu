using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class Plusbe2019_Admin_Main : AdminPage
{

    protected List<View_News> MyList;
    protected List<ExhibitionOpen> OpenList;
    int days = 0;
    protected int Count = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime dtNow = DateTime.Now;
        days = DateTime.DaysInMonth(dtNow.Year, dtNow.Month);
        View_News condition = new View_News();
        View_News value = new View_News();
        condition.ExhibitionID = AdminMethod.ExhibitionID;
        condition.TypeID = 0;
        MyList = TableOperate<View_News>.Select(value, condition);
        ExhibitionOpen exhibition = new ExhibitionOpen();
        ExhibitionOpen exhibitionvalue = new ExhibitionOpen();
        exhibition.ExhibitionID = AdminMethod.ExhibitionID;
        OpenList = TableOperate<ExhibitionOpen>.Select(exhibitionvalue,exhibition);
        Count = OpenList.Count;
        DataBind();
    }
    /// <summary>
    /// 获取资料分类 1 是视频 2是网页 3是ppt 4是图片
    /// </summary>
    /// <param name="FileType"></param>
    /// <returns></returns>
    protected int GetFileCount(int FileType)
    {
        int Count = 0;
        for (int i = 0; i < MyList.Count; i++)
        {
            if (MyList[i].FileType == FileType)
            {
                Count += 1;
            }
        }
        return Count;
    }
    protected string GetUp()
    {
        string valueStr = "";
        for (int i = 0; i < 12; i++)
        {
            int Count = 0;
            for (int j = 0; j < MyList.Count; j++)
            {
                int Year = MyList[j].AddTime.Year;
                int Month = MyList[j].AddTime.Month;
               
                DateTime dt = DateTime.Now;
                if (dt.Year == Year && Month==(i+1))
                {

                    Count += 1;
                }
            }
            valueStr += Count + ",";
        }
        valueStr = valueStr.TrimEnd(',');
        return valueStr;
    }
   
    
    protected string GetNowYue()
    {
        string dayarry = "";
        for (int i = 0; i < days; i++)
        {
            dayarry += "'"+(i+1)+"日',";
        }
        dayarry = dayarry.Trim(',');
        return dayarry;
    }
    protected string GetCount()
    {
        string valueStr = "";
        for (int i = 0; i < days; i++)
        {
            int Count = 0;
            for (int j = 0; j < OpenList.Count; j++)
            {
                int Year = OpenList[j].AddTime.Year;
                int Month = OpenList[j].AddTime.Month;
                int Day = OpenList[j].AddTime.Day;
                DateTime dt = DateTime.Now;
                if (dt.Year==Year&&dt.Month==Month&&Day==(i+1))
                {
                   
                    Count += 1;
                }
            }
            valueStr += Count + ",";
        }
        valueStr = valueStr.TrimEnd(',');
        return valueStr;
       
    }
}