using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class API_SpeechJson : System.Web.UI.Page
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
            string error = "加密不正确"; Response.Write(error); return;

        }
        string json = "";
        SpeechTitle condition = new SpeechTitle();
        SpeechTitle value = new SpeechTitle();
        condition.ExhibitionID = SeviceID;
        List<SpeechTitle> list = TableOperate<SpeechTitle>.Select(value,condition);
        if (list.Count > 0)
        {
            json = "{\"list\":[";
            for (int i = 0; i < list.Count; i++)
            {
                json += "{\"ID\":" + list[i].ID + ", \"Title\":\"" + list[i].Title + "\", \"KeyWord\":\"" + list[i].Key_Word + "\",\"CmdList\":" + GetList(list[i].ID) + "},";
            }
            json = json.Trim(',');
            json += "]}";
            Response.Write(json);
        }
    }
    protected string GetList(int KeyID)
    {
        string jsonstr = "[";
        SpeechSend value = new SpeechSend();
        SpeechSend condition = new SpeechSend();
        condition.SpeechID = KeyID;
        List<SpeechSend> list = TableOperate<SpeechSend>.Select(value, condition, 0, "order by id desc");
        for (int i = 0; i < list.Count; i++)
        {
            jsonstr += "{\"ID\":" + list[i].ID + ", \"IP\":\"" + list[i].IP + "\", \"Port\":\"" + list[i].Port + "\", \"Cmd\":\"" + list[i].SendCode + "\", \"CharType\":\"" + list[i].CharType + "\", \"Protocol\":\"" + list[i].Protocol + "\"},";
        }
        jsonstr = jsonstr.Trim(',');
        jsonstr += "]";
        return jsonstr;
    }
}