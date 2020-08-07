using Dejun.DataProvider.Table;
using System;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;
using System.Collections;

public partial class Plusbe2019_Admin_AdminExTree_TreeApi : AdminPage
{
    protected List<TagTree> channelList;
    protected void Page_Load(object sender, EventArgs e)
    {
//        [{
//	"text": "父节点 1",
//	"nodes": [{
//		"text": "子节点 1",
//		"nodes": [{
//			"text": "孙子节点 1"

//        }, {
//			"text": "孙子节点 2"
//		}]
//	}, {
//		"text": "子节点 2"
//	}]
//}, {
//	"text": "父节点 2"
//}, {
//	"text": "父节点 3"
//}, {
//	"text": "父节点 4"
//}, {
//	"text": "父节点 5"
//}]
        channelList = TagProvider.SelectAll();
        string arrstr = "";
        for (int i = 0; i < channelList.Count; i++)
        {
            arrstr += channelList[i].ID + ",";

        }
       string[] arry = arrstr.TrimEnd(',').Split(',');
        string TreeJson = "[";
        string JsonData = "";
        for (int i = 0; i < channelList.Count; i++)
        {
            if (channelList[i].Depth == 0)
            {
                JsonData += "{";
                JsonData += "\"text\":\"" + channelList[i].Name + "\"";
                JsonData += ",\"id\":\"" + channelList[i].ID + "\"";
                JsonData += ",\"itemid\":\"" + i + "\"";
                if (channelList[i].Child)
                {
                    JsonData += GetChild(channelList[i].ID);
                }
                JsonData += "},";
            }
            else
            {
                if (!((IList)arry).Contains(channelList[i].ParentID + ""))
                {
                    JsonData += "{";
                    JsonData += "\"text\":\"" + channelList[i].Name + "\"";
                    JsonData += ",\"id\":\"" + channelList[i].ID + "\"";
                    JsonData += "},";
                }
            }
        }
        JsonData = JsonData.TrimEnd(',');
        TreeJson += JsonData+"]";
        Response.Write(TreeJson);

    }
    protected string GetChild(int ID)
    {
        string JsonData = ",\"nodes\":[";
        for (int i = 0; i < channelList.Count; i++)
        {
            if (channelList[i].ParentID == ID)
            {
               
                JsonData += "{";
                JsonData += "\"text\":\"" + channelList[i].Name + "\"";
                JsonData += ",\"id\":\"" + channelList[i].ID + "\"";
                JsonData += ",\"itemid\":\"" + i + "\"";
                if (channelList[i].Child)
                {
                    JsonData+=GetChild(channelList[i].ID);
                }
                JsonData += "},";

            }
        }
        JsonData = JsonData.TrimEnd(',');
        JsonData += "]";
        return JsonData;
    }
}