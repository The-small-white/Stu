using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// 表单处理的一些公用函数
/// </summary>
public class FormDeal
{
	public FormDeal()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 设置radio和CheckBox的勾选
    /// </summary>
    /// <param name="strID">id</param>
    /// <param name="strValue">值</param>
    public static void SetRadioValue(string strID, string strValue, Page page)
    {
        for (int i = 0; i < page.Controls.Count; i++)
        {
            foreach (Control o in page.Controls[i].Controls)
            {
                if (o is HtmlInputRadioButton || o is HtmlInputCheckBox)
                {

                    if (o.ID.IndexOf("_" + strID + "__") > -1)
                    {

                        if (o is HtmlInputRadioButton)
                        {
                            HtmlInputRadioButton tb = (HtmlInputRadioButton)o;
                            if (tb.Value == strValue)
                            {
                                tb.Checked = true;
                                return;
                            }
                        }
                        else if (o is HtmlInputCheckBox)
                        {
                            HtmlInputCheckBox cb = (HtmlInputCheckBox)o;
                            if (cb.Value == strValue)
                            {
                                cb.Checked = true;
                                return;
                            }
                        }


                    }
                }
                
            }
        }
    }
    }
