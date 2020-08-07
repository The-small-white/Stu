using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Dejun.DataProvider.Table;
using System.Collections.Generic;
using Dejun.DataProvider.Sql2005;

public partial class deviceList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Device v = new Device();
        Device condition = new Device();
        if (string.IsNullOrEmpty(this.Request["seviceID"]))
        {
            return;
        }
        int SeviceID = Convert.ToInt32(this.Request["seviceID"]);
        string sn = RequestString.NoHTML(Convert.ToString(this.Request["sn"]));
        if (!SysConfig.IsTrueSn(SeviceID, sn))
        {
            string error = "加密不正确"; Response.Write(error); return;

        }
        condition.ExhibitionID = SeviceID;
        condition.TypeID = 0;
        condition.State = 1;

        List<Projector> projectorList = TableOperate<Projector>.Select();
        List<Device> m_deviceList = TableOperate<Device>.Select(v, condition, 0, " order by OrderID asc ");
        string json = "{\"list\":[";
        for (int i = 0; i < m_deviceList.Count; i++)
        {
            if (m_deviceList[i].DeviceType == 4)
            {
                //投影机
               Projector projector = GetProjectorInfo(m_deviceList[i].ProjectorType, projectorList);
               m_deviceList[i].OpenProtocol = projector.OpenProtocol;
               m_deviceList[i].QueryClose = projector.QueryClose;
               m_deviceList[i].QueryOpen = projector.QueryOpen;
               m_deviceList[i].QueryProtocol = projector.QueryProtocol;
               m_deviceList[i].ReCharType = projector.ReCharType;
               m_deviceList[i].CharType = projector.CharType;
               m_deviceList[i].CloseProtocol = projector.CloseProtocol; 
            }

            if (m_deviceList[i].CharType != 1)
            {
                m_deviceList[i].CloseProtocol = m_deviceList[i].CloseProtocol.Replace(" ", "");
                m_deviceList[i].OpenProtocol = m_deviceList[i].OpenProtocol.Replace(" ", "");
                m_deviceList[i].QueryProtocol = m_deviceList[i].QueryProtocol.Replace(" ", "");
            }

            if (m_deviceList[i].ReCharType != 1)
            {
                m_deviceList[i].QueryClose = m_deviceList[i].QueryClose.Replace(" ", "");
                m_deviceList[i].QueryOpen = m_deviceList[i].QueryOpen.Replace(" ", "");
            }

            json += "{\"id\":" + m_deviceList[i].ID + ", \"name\":\"" + m_deviceList[i].Name + "\", \"AreaID\":" + m_deviceList[i].AreaID + ",\"AreaName\":\"" + m_deviceList[i].Name +
                "\", \"DeviceType\":" + m_deviceList[i].DeviceType + ", \"pic\":\"" + m_deviceList[i].Pic +
                "\", \"ip\":\"" + m_deviceList[i].Ip +
                "\", \"openCount\":\"" + m_deviceList[i].OpenCount +
                "\", \"mac\":\"" + m_deviceList[i].Mac + "\", \"port\":" + m_deviceList[i].Port +
                ", \"BHome\":" + 1 + ", \"BShow\":" + 1 + ", \"BAllDone\":" + 1 + ", \"SwitchIP\":\"" + m_deviceList[i].SwitchIP +
                "\", \"SwitchPort\":" + m_deviceList[i].SwitchPort + ", \"SwitchIndex\":" + m_deviceList[i].SwitchIndex +
                ", \"SwitchGroup\":" + m_deviceList[i].SwitchGroup + ", \"ProjectorType\":" + m_deviceList[i].ProjectorType +
                ", \"protocol\":" + m_deviceList[i].Protocol + ", \"charType\":" + m_deviceList[i].CharType + ", \"reCharType\":" + m_deviceList[i].ReCharType +
                ", \"openProtocol\":\"" + m_deviceList[i].OpenProtocol + "\", \"closeProtocol\":\"" + m_deviceList[i].CloseProtocol + "\", \"queryProtocol\":\"" + m_deviceList[i].QueryProtocol +
                "\", \"queryOpen\":\"" + m_deviceList[i].QueryOpen + "\", \"queryClose\":\"" + m_deviceList[i].QueryClose + "\"},";
        }
 

   

        

        json = json.Trim(',');
        json += "]}";

        Response.Write(json);

    }
    private bool IsUUid(int UserID,string uuid)
    {
        IpadUuid conditon = new IpadUuid();
        IpadUuid value = new IpadUuid();
        conditon.UUID = uuid;
        conditon.AddID = UserID;
        value = TableOperate<IpadUuid>.GetRowData(conditon);
        if (value.ID > 0 && value.State == 1)
        {
            return true;
        }
        else
        {
            if (value.ID == 0)
            {
                conditon.State = 0;
                conditon.AddTime = DateTime.Now;
                TableOperate<IpadUuid>.InsertReturnID(conditon);
            }
            return false;
        }
    }
    private Projector GetProjectorInfo(int projectorType, List<Projector> projectorList)
    {
        for (int i = 0; i < projectorList.Count; i++)
        {
            if (projectorList[i].ID == projectorType)
            {
                return projectorList[i];
            }
        }
        return null;
    }


}
