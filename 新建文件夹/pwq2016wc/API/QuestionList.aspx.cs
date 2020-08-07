using System;
using System.Collections.Generic;
using Dejun.DataProvider.Table;
using Dejun.DataProvider.Sql2005;

public partial class API_QuestionList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.Request["seviceID"]))
        {
            return;
        }
        if (string.IsNullOrEmpty(this.Request["sn"]))
        {
            return;
        }
        int SeviceID = Convert.ToInt32(this.Request["seviceID"]);
        string sn = RequestString.NoHTML(Convert.ToString(this.Request["sn"]));
        if (!SysConfig.IsTrueSn(SeviceID, sn))
        {
            string error = "{\"state\":\"false\", \"msg\":\"加密错误\"}";
            Response.Write(error); return;

        }
        else
        {
            string act = Convert.ToString(Request["act"]);

            int rootID = 0;
            if (!string.IsNullOrEmpty(this.Request["rootID"]))
            {
                rootID = Convert.ToInt32(Request["rootID"]);
            }
            int typeid = 0;
            if (!string.IsNullOrEmpty(this.Request["typeid"]))
            {
                typeid = Convert.ToInt32(Request["typeid"]);
            }
            List<QuestionType> Typelist = QusetionProvider.SelectByRootID(rootID);
            string json = "{\"Typelist\":[";
            for (int i = 0; i < Typelist.Count; i++)
            {
                json += "{\"ID\":" + Typelist[i].ID + ", \"Name\":\"" + Typelist[i].Name + "\", \"ParentID\":\"" + Typelist[i].ParentID + "\", \"Depth\":\"" + Typelist[i].Depth + "\", \"RootID\":\"" + Typelist[i].RootID + "\"},";
            }
            json = json.Trim(',');
            json += "],";
            View_Question condition = new View_Question();
            condition.ExhibitionID = SeviceID;
            if (typeid != 0)
            {
                condition.TypeID = typeid;
            }
            View_Question value = new View_Question();
            List<View_Question> list = TableOperate<View_Question>.Select(value, condition, 0, "order by OrderID asc");
            json += "\"list\":[";
            for (int i = 0; i < list.Count; i++)
            {
                json += "{\"ID\":" + list[i].ID + ", \"Title\":\"" + list[i].Title + "\", \"Files\":\"UploadFiles/" + list[i].Files+ "\", \"Brief\":\"" + list[i].Brief + "\", \"TypeID\":\"" + list[i].TypeID + "\",\"OptionList\":" + GetOption(list[i]) + "},";
            }
            json = json.Trim(',');
            json += "]}";
            Response.Write(json);

        }


    }
    protected string GetOption(View_Question answer)
    {
        string jsonstr = "[";
        string[] answeArry = answer.Answer.Split(',');
        string[] trueArry = answer.TrueList.Split(',');
        for (int i = 0; i < answeArry.Length; i++)
        {
            jsonstr += "{\"answer\":\"" + answeArry[i] + "\", \"istrue\":\"" + trueArry[i] + "\"},";
        }
        jsonstr = jsonstr.Trim(',');
        jsonstr += "]";
        return jsonstr;
    }
}