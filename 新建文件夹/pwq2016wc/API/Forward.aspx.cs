using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class API_Forward : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.Request["tag"]))
        {
            string tag = Convert.ToString(Request["tag"]);
            SendHttp("192.168.10.33", tag); SendHttp("192.168.10.34", tag); SendHttp("192.168.10.35", tag);
        }
    }
    protected void SendHttp(string ip, string Tag)
    {
        string url = "http://" + ip + ":8020/?act=movie&object=" + Tag + "&states=18&dev=pc";
        Thread t = new Thread(delegate () { HttpHelp.Get(url); });
        t.Start();
    }
}