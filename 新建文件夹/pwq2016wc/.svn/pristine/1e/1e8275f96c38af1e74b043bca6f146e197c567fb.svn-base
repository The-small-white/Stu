using System;
using System.Collections.Generic;
using System.Text;
using CodeBuild.Model;

namespace TemplateEngine
{

    class FormItem
    {
        Table m_table;
        public FormItem(Table table)
        {
            m_table = table;
            m_table.Brief = string.IsNullOrEmpty(table.Brief) ? table.Name : table.Brief;
        }
        public string GetInsertNecessary()
        {
            string str = "";
            if (m_table.Necessary)
            {
                str = "if (string.IsNullOrEmpty(this.Request[\"" + StringDeal.HeadLower(m_table.Name) + "\"])) { Response.Redirect(\"Insert.aspx?error=添加失败，" + m_table.Brief + "不能为空！\"); }";
            }
            return str;
        }

        public string GetUpdateNecessary()
        {
            string str = "";
            if (m_table.Necessary)
            {
                str = " if (string.IsNullOrEmpty(this.Request[\"" + StringDeal.HeadLower(m_table.Name) + "\"])) { Response.Redirect(\"Update.aspx?{第一列小写列名}=\" + {第一列小写列名} + \"&error=修改失败！" + m_table.Brief + "不能为空！\"); }";
                //str = "if (string.IsNullOrEmpty(this.Request[\"{第一列小写列名}\"])) { Response.Redirect(\"Update.aspx?error=修改失败，" + m_table.Brief + "不能为空！\"); }";
                //str = "if (string.IsNullOrEmpty(this.Request[\"" + StringDeal.HeadLower(m_table.Name) + "\"])) { Response.Redirect(\"Insert.aspx?error=添加失败，" + m_table.Brief + "不能为空！\"); }";
            }
            return str;
        }

        //赋值必要条件
        public string GetUpdateConditon()
        {
            string str = "";
            string members = m_table.SelectMember;
            string[] values = m_table.SelectValue.Split('|');
            if (m_table.EditType == "下拉框表关联")
            {
                str = @"
                List<" + StringDeal.HeadUpper(members) + @"> " + StringDeal.HeadLower(members) + @"List = TableOperate<" + StringDeal.HeadUpper(members) + @">.Select();
                " + StringDeal.HeadLower(m_table.Name) + @".DataSource = " + StringDeal.HeadLower(members) + @"List;
                " + StringDeal.HeadLower(m_table.Name) + @".DataTextField = """ + StringDeal.HeadUpper(values[1]) + @""";
                " + StringDeal.HeadLower(m_table.Name) + @".DataValueField = """ + StringDeal.HeadUpper(values[0]) + @""";
                ";
               str += StringDeal.HeadLower(m_table.Name) + ".DataBind();\r\n";
            }

            return str;
        }

        //赋值
        public string GetUpdateSetValue()
        {
            string str = "";
            string members = m_table.SelectMember;
            string[] values = m_table.SelectValue.Split('|');
            if (m_table.EditType == "复选选择框(checkBox)" || m_table.EditType == "单选选择框(radio)")
            {
                str = "FormDeal.SetRadioValue(\"" + StringDeal.HeadLower(m_table.Name) + "\",  Convert.ToString({首字母小写表名}." + StringDeal.HeadUpper(m_table.Name) + "), this.Page); \r\n";
            }           
            else 
            {
                str = StringDeal.HeadLower(m_table.Name) + ".Value=  Convert.ToString({首字母小写表名}." + StringDeal.HeadUpper(m_table.Name) + "); \r\n";
            }
            if (m_table.EditType == "下拉框表关联" || m_table.EditType == "弹出框表关联")
            {
                str += "" + StringDeal.HeadUpper(m_table.SelectMember) + " v" + StringDeal.HeadUpper(m_table.Name) + " = new " + StringDeal.HeadUpper(m_table.SelectMember) + "();\r\n";
                str += "v" + StringDeal.HeadUpper(m_table.Name) + "." + values[1] + " = \"\";\r\n";
                str += "" + StringDeal.HeadUpper(m_table.SelectMember) + " c" + StringDeal.HeadUpper(m_table.Name) + " = new " + StringDeal.HeadUpper(m_table.SelectMember) + "();\r\n";
                str += "c" + StringDeal.HeadUpper(m_table.Name) + "." + values[0] + " = " + StringDeal.HeadLower(m_table.TableName) + "." + StringDeal.HeadUpper(m_table.Name) + ";\r\n";
                str += "" + StringDeal.HeadLower(m_table.Name) + "_name.Value = TableOperate<" + StringDeal.HeadUpper(m_table.SelectMember) + ">.GetOneValue(v" + StringDeal.HeadUpper(m_table.Name) + ", c" + StringDeal.HeadUpper(m_table.Name) + ");\r\n";
                //str += " " + StringDeal.HeadUpper(m_table.SelectMember) + " v" + StringDeal.HeadUpper(m_table.Name) + " = new " + StringDeal.HeadUpper(m_table.SelectMember) + "();\r\n";
                //str += " v" + StringDeal.HeadUpper(m_table.Name) + "." + StringDeal.HeadUpper(values[0]) + " = 0;\r\n";
                //str += " v" + StringDeal.HeadUpper(m_table.Name) + "." + StringDeal.HeadUpper(values[1]) + " = \"\";\r\n";
                //str += " " + StringDeal.HeadUpper(m_table.SelectMember) + " c" + StringDeal.HeadUpper(m_table.Name) + " = new " + StringDeal.HeadUpper(m_table.SelectMember) + "();\r\n";
                //str += " string " + StringDeal.HeadLower(m_table.Name) + "Str = \"where id in(0\";\r\n";
                //str += " for (int i = 0; i < m_" + StringDeal.HeadLower(m_table.TableName) + "LiList.Count; i++)\r\n";
                //str += " {\r\n";
                //str += "     " + StringDeal.HeadLower(m_table.Name) + "Str += \",\" + m_" + StringDeal.HeadLower(m_table.TableName) + "LiList[i]." + StringDeal.HeadUpper(m_table.Name) + ";\r\n";
                //str += " }\r\n";
                //str += " " + StringDeal.HeadLower(m_table.Name) + "Str = " + StringDeal.HeadLower(m_table.Name) + "Str + \")\";\r\n";
                //str += " c" + StringDeal.HeadUpper(m_table.Name) + ".SetConditon(" + StringDeal.HeadLower(m_table.Name) + "Str);\r\n";
                //str += " m_" + StringDeal.HeadLower(m_table.Name) + "List = TableOperate<" + StringDeal.HeadUpper(m_table.SelectMember) + ">.Select(v" + StringDeal.HeadUpper(m_table.Name) + ", c" + StringDeal.HeadUpper(m_table.Name) + ");\r\n";
            
            }

            return str;
        }

        public string GetShouYeTanList()
        {
            string str = "";
            string members = m_table.SelectMember;
            string[] values = m_table.SelectValue.Split('|');
            if (m_table.EditType == "下拉框表关联" || m_table.EditType == "弹出框表关联")
            {
                str += " " + StringDeal.HeadUpper(m_table.SelectMember) + " v" + StringDeal.HeadUpper(m_table.Name) + " = new " + StringDeal.HeadUpper(m_table.SelectMember) + "();\r\n";
                str += " v" + StringDeal.HeadUpper(m_table.Name) + "." + StringDeal.HeadUpper(values[0]) + " = 0;\r\n";
                str += " v" + StringDeal.HeadUpper(m_table.Name) + "." + StringDeal.HeadUpper(values[1]) + " = \"\";\r\n";
                str += " " + StringDeal.HeadUpper(m_table.SelectMember) + " c" + StringDeal.HeadUpper(m_table.Name) + " = new " + StringDeal.HeadUpper(m_table.SelectMember) + "();\r\n";
                str += " string " + StringDeal.HeadLower(m_table.Name) + "Str = \"where id in(0\";\r\n";
                str += " for (int i = 0; i < m_" + StringDeal.HeadLower(m_table.TableName) + "List.Count; i++)\r\n";
                str += " {\r\n";
                str += "     " + StringDeal.HeadLower(m_table.Name) + "Str += \",\" + m_" + StringDeal.HeadLower(m_table.TableName) + "List[i]." + StringDeal.HeadUpper(m_table.Name) + ";\r\n";
                str += " }\r\n";
                str += " " + StringDeal.HeadLower(m_table.Name) + "Str = " + StringDeal.HeadLower(m_table.Name) + "Str + \")\";\r\n";
                str += " c" + StringDeal.HeadUpper(m_table.Name) + ".SetConditon(" + StringDeal.HeadLower(m_table.Name) + "Str);\r\n";
                str += " m_" + StringDeal.HeadLower(m_table.Name) + "List = TableOperate<" + StringDeal.HeadUpper(m_table.SelectMember) + ">.Select(v" + StringDeal.HeadUpper(m_table.Name) + ", c" + StringDeal.HeadUpper(m_table.Name) + ");\r\n";
            }
            return str;
        }


        //没在用
        public string GetJs()
        {
            string str = "";

 
            //switch (m_table.NetType)
            //{
            //    case "long":
            //        str += "if(document.theform." + StringDeal.HeadLower(m_table.Name) + ".value != \"\" && !isInteger( document.theform." + StringDeal.HeadLower(m_table.Name) + ".value )) { alert(\"" + m_table.Brief + "必须为整数！\");  return false;}";
            //        //isInteger( str )
            //        break;
            //    case "decimal":
            //        str += "if(document.theform." + StringDeal.HeadLower(m_table.Name) + ".value != \"\" && !isDecimal( document.theform." + StringDeal.HeadLower(m_table.Name) + ".value )) { alert(\"" + m_table.Brief + "必须为数字！\");  return false;}";
                    
            //        break;
            //    case "double":
            //        str += "if(document.theform." + StringDeal.HeadLower(m_table.Name) + ".value != \"\" && !isDecimal( document.theform." + StringDeal.HeadLower(m_table.Name) + ".value )) { alert(\"" + m_table.Brief + "必须为数字！\");  return false;}";
 
            //        break;
            //    case "int":
            //        str += "if(document.theform." + StringDeal.HeadLower(m_table.Name) + ".value != \"\" && !isInteger( document.theform." + StringDeal.HeadLower(m_table.Name) + ".value )) { alert(\"" + m_table.Brief + "必须为整数！\");  return false;}";
            //        break;
                    
            //    case "Single":
            //        str += "if(document.theform." + StringDeal.HeadLower(m_table.Name) + ".value != \"\" && !isDecimal( document.theform." + StringDeal.HeadLower(m_table.Name) + ".value )) { alert(\"" + m_table.Brief + "必须为数字！\");  return false;}";
            //        break;
 
            //    case "UInt32":
            //        str += "if(document.theform." + StringDeal.HeadLower(m_table.Name) + ".value != \"\" && !isInteger( document.theform." + StringDeal.HeadLower(m_table.Name) + ".value )) { alert(\"" + m_table.Brief + "必须为整数！\");  return false;}";
                    
            //        break;
            //    default:
            //        break;
            //}
             //           if (m_table.NetType == )
           // {

            return str;
        }

        //没在用
        public string GetForm()
        {
            string str = "";

            string[] members = m_table.SelectMember.Split('|');
            string[] value = m_table.SelectValue.Split('|');
            string strNecessary = "";
            if (m_table.Necessary)
            {
                strNecessary = "required";
            }
            switch (m_table.EditType)
            {

                case "文本框(text)":
                    str = "<input type=\"text\" class=\"form-control\" " + strNecessary + "  name=\"" + StringDeal.HeadLower(m_table.Name) + "\" /> ";
                    break;
                case "密码框(password)":
                    str = "<input class=\"form-control\" " + strNecessary + " name=\"" + StringDeal.HeadLower(m_table.Name) + "\" type=\"password\"  /> ";
                    break;
                case "复选选择框(checkBox)":
              
                    for (int i = 0; i < members.Length; i++)
                    {
                        str += "<label class=\"checkbox-inline i-checks\"><input type=\"checkbox\" name=\"" + StringDeal.HeadLower(m_table.Name) + "\" value=\"" + value[i] + "\"  />" + members[i] + "</label> ";
                    }
                    if (string.IsNullOrEmpty(m_table.SelectMember))
                    {
                        str = "<label class=\"checkbox-inline i-checks\"><input type=\"checkbox\" name=\"" + StringDeal.HeadLower(m_table.Name) + "\" value=\"" + StringDeal.HeadLower(m_table.Name) + "\" />" + StringDeal.HeadLower(m_table.Name) + "</label> ";
                    }
                    break;
                case "选择框(select)":


                    str = "<select class=\"form-control\" " + strNecessary + " name=\"" + StringDeal.HeadLower(m_table.Name) + "\" >";
                    for (int i = 0; i < members.Length; i++)
                    {
                        str += "<option value=\"" + value[i] + "\">" + members[i] + "</option>";
                    }
                    str += "</select>";
                    break;
                case "单选选择框(radio)":

                    for (int i = 0; i < members.Length; i++)
                    {
                        str += "<input class=\"form-control\"  name=\"" + StringDeal.HeadLower(m_table.Name) + "\" type=\"radio\" value=\"" + value[i] + "\"  />" + members[i] + "";
                    }
                    break;
                case "时间选择框(datetime)":
                    str = "<div class=\"input-group date\"><span class=\"input-group-addon\"><i class=\"fa fa-calendar\"></i></span><input class=\"form-control form-datetime\"" + strNecessary + " name=\"" + StringDeal.HeadLower(m_table.Name) + "\"  readonly=\"readonly\"  /></div>";
 
                    break;
                case "上传选择框(upload)":
                    str = @"<INPUT class=""form-control"" " + strNecessary + @"  name=""" + StringDeal.HeadLower(m_table.Name) + @""" >  <input type=""button"" id=""btn_" + StringDeal.HeadLower(m_table.Name) + @""" value=""上传"" onClick=""openwin(this);"" />
        &nbsp;</td>
    </tr>
	
     <TR id=""upPic_" + StringDeal.HeadLower(m_table.Name) + @""" style="" display:none"">
    <TD class=row height=30 style=""width: 83px"">上传图片：</TD>
    <TD class=row ><iframe  id=""Iframe1_" + StringDeal.HeadLower(m_table.Name) + @"""  name=""upimg_" + StringDeal.HeadLower(m_table.Name) + @""" src=""../UpFile.aspx?name=" + StringDeal.HeadLower(m_table.Name) + @""" width=""450"" height=""55""  frameborder=0></IFRAME>";

                    break;
                case "文本框(textarea)":
                    str = "<textarea class=\"form-control\" " + strNecessary + " name=\"" + StringDeal.HeadLower(m_table.Name) + "\" cols=\"50\" rows=\"10\" ></textarea>";
                    break;

                case "可视化编辑器":
                    str = "<textarea class=\"form-control\" name=\"" + StringDeal.HeadLower(m_table.Name) + "\" cols=\"50\" rows=\"10\" ></textarea>";
                    break;

                case "进度条上传":
                    str = @"<INPUT class=""form-control""  name=""" + StringDeal.HeadLower(m_table.Name) + @""" >    <span id=""sBPlace_" + StringDeal.HeadLower(m_table.Name) + @""" ></span>
  
 
      <span id=""sBPlace1" + StringDeal.HeadLower(m_table.Name) + @""" ></span> ";
                    break;

                case "下拉框表关联":
                    str = @"<select class=""form-control"" " + strNecessary + @" name=""" + StringDeal.HeadLower(m_table.Name) + @""" id=""" + StringDeal.HeadLower(m_table.Name) + @"""  > 
                           <asp:repeater id=""Repeater1"" runat=""server"" DataSource=""<%# m_" + StringDeal.HeadLower(m_table.Name) + @"List %>"">
		<ItemTemplate>
		 <option value=""<%# ((" + StringDeal.HeadUpper(m_table.Name) + @")Container.DataItem).ID%>""><%# ((" + StringDeal.HeadUpper(m_table.Name) + @")Container.DataItem).Name%></option>
		</ItemTemplate>
	</asp:repeater>
                </select>    ";
                    break;
                case "弹出框表关联":
                    str = "<input type=\"hidden\" " + strNecessary + " name=\"" + StringDeal.HeadLower(m_table.Name) + "\" id=\"" + StringDeal.HeadLower(m_table.Name) + "\" />";
                    str += "<input readonly=\"readonly\" class=\"form-control form-showpanel\"  vid=\"" + StringDeal.HeadLower(m_table.Name) + "\" modal_title=\"选择" + m_table.Brief + "\" modal_url=\"../Manage" + m_table.SelectMember + "/Modal.aspx\" name=\"" + StringDeal.HeadLower(m_table.Name) + "_name\" id=\"" + StringDeal.HeadLower(m_table.Name) + "_name\"/>";
                    break;
                default:
                    str = "<input class=\"form-control\" " + strNecessary + " name=\"" + StringDeal.HeadLower(m_table.Name) + "\" /> ";
                    break;
            }
            return str;
        }

        public string GetSearchForm()
        {
            if (!m_table.BSearch) return "";

            string str = "";

            string[] members = m_table.SelectMember.Split('|');
            string[] value = m_table.SelectValue.Split('|');

            if (m_table.EditType == "复选选择框(checkBox)" || m_table.EditType == "选择框(select)" || m_table.EditType == "单选选择框(radio)")
            {
                str = "<select class=\"form-control\" name=\"" + StringDeal.HeadLower(m_table.Name) + "\" id=\"" + StringDeal.HeadLower(m_table.Name) + "\"  runat=\"server\">\r\n";


                string valueStr = "";
                if (m_table.NetType == "long" || m_table.NetType == "decimal" || m_table.NetType == "double" || m_table.NetType == "int"

                  || m_table.NetType == "Single" || m_table.NetType == "UInt32")
                {
                    valueStr = "-1";
                }
                str += "<option value=\"" + valueStr + "\">选择" + m_table .Brief + "</option>\r\n";
               
                for (int i = 0; i < members.Length; i++)
                {
                    str += "<option value=\"" + value[i] + "\">" + members[i] + "</option>\r\n";
                }
                str += "</select>";
            }
            else if (m_table.EditType == "下拉框表关联")
            {
                str = "<select class=\"form-control\" name=\"" + StringDeal.HeadLower(m_table.Name) + "\" id=\"" + StringDeal.HeadLower(m_table.Name) + "\"  runat=\"server\">";
                str += "</select>";
            }
            else if (m_table.EditType == "弹出框表关联")
            {
                str = "<input type=\"hidden\" name=\"" + StringDeal.HeadLower(m_table.Name) + "\" id=\"" + StringDeal.HeadLower(m_table.Name) + "\" runat=\"server\"/>";
                str += "<input placeholder=\"选择" + m_table.Brief + "\" readonly=\"readonly\" class=\"form-control form-showpanel\"  vid=\"" + StringDeal.HeadLower(m_table.Name) + "\" modal_title=\"选择" + m_table.Brief + "\" modal_url=\"../Manage" + m_table.SelectMember + "/Modal.aspx\" name=\"" + StringDeal.HeadLower(m_table.Name) + "_name\" id=\"" + StringDeal.HeadLower(m_table.Name) + "_name\" runat=\"server\"/>";
            }
            else if (m_table.EditType == "时间选择框(datetime)")
            {

                str = "<div class=\"input-group date\"><span class=\"input-group-addon\"><i class=\"fa fa-calendar\"></i></span><input class=\"form-control form-datetime begintime\" name=\"begin_" + StringDeal.HeadLower(m_table.Name) + "\"   id=\"begin_" + StringDeal.HeadLower(m_table.Name) + "\"  readonly=\"readonly\"  runat=\"server\"  /></div>";
                str +="     </div>\r\n";
                str +="</div>\r\n";
                str +="<div class=\"col-sm-3\">";
                str +="        <div class=\"form-group\">";
                str += "            <label class=\"control-label\" for=\"order_id\">结束" + m_table.Brief + "</label>";

                str += "   <div class=\"input-group date\"><span class=\"input-group-addon\"><i class=\"fa fa-calendar\"></i></span> <input class=\"form-control form-datetime endtime\" name=\"end_" + StringDeal.HeadLower(m_table.Name) + "\"    id=\"end_" + StringDeal.HeadLower(m_table.Name) + "\"  readonly=\"readonly\"  runat=\"server\" /></div>";
                
            }
            else
            {
                str = "<input class=\"form-control\" name=\"" + StringDeal.HeadLower(m_table.Name) + "\"  placeholder=\"" + m_table.Brief + "\" runat=\"server\"  id=\"" + StringDeal.HeadLower(m_table.Name) + "\" /> ";
            } 

            return str;
        }
         
        public string GetTanChuSearchForm()
        {
            if (!m_table.BSearch) return "";

            string str = "";

            string[] members = m_table.SelectMember.Split('|');
            string[] value = m_table.SelectValue.Split('|');

            if (m_table.EditType == "复选选择框(checkBox)" || m_table.EditType == "选择框(select)" || m_table.EditType == "单选选择框(radio)")
            {
                str = "<select style=\"width: 30%;\" placeholder=\"" + m_table .Brief + "\"  class=\"input-sm form-control\" name=\"" + StringDeal.HeadLower(m_table.Name) + "\" id=\"" + StringDeal.HeadLower(m_table.Name) + "\"  runat=\"server\">\r\n";


                string valueStr = "";
                if (m_table.NetType == "long" || m_table.NetType == "decimal" || m_table.NetType == "double" || m_table.NetType == "int"

                  || m_table.NetType == "Single" || m_table.NetType == "UInt32")
                {
                    valueStr = "-1";
                }
                str += "  <option value=\"" + valueStr + "\">选择" + m_table.Brief + "</option>\r\n";

                for (int i = 0; i < members.Length; i++)
                {
                    str += " <option value=\"" + value[i] + "\">" + members[i] + "</option>\r\n";
                }
                str += "</select>";
            }
            else if (m_table.EditType == "下拉框表关联")
            {
                str = "<select style=\"width: 30%;\" placeholder=\"" + m_table.Brief + "\" class=\"input-sm form-control\" name=\"" + StringDeal.HeadLower(m_table.Name) + "\" id=\"" + StringDeal.HeadLower(m_table.Name) + "\"  runat=\"server\">";
                str += "</select>";
            }
            else if (m_table.EditType == "弹出框表关联")
            {
                str = "<input type=\"hidden\" name=\"" + StringDeal.HeadLower(m_table.Name) + "\" id=\"" + StringDeal.HeadLower(m_table.Name) + "\" runat=\"server\"/>";
                str += "<input readonly=\"readonly\" style=\"width: 30%;\" placeholder=\"点击选择" + m_table.Brief + "\" class=\"input-sm  form-control form-showpanel\"  vid=\"" + StringDeal.HeadLower(m_table.Name) + "\" modal_title=\"选择" + m_table.Brief + "\" modal_url=\"../Manage" + m_table.SelectMember + "/Modal.aspx\" name=\"" + StringDeal.HeadLower(m_table.Name) + "_name\" id=\"" + StringDeal.HeadLower(m_table.Name) + "_name\" runat=\"server\"/>";
            }
            else if (m_table.EditType == "时间选择框(datetime)")
            {

                str = "<div class=\"input-group date\"><span class=\"input-group-addon\"><i class=\"fa fa-calendar\"></i></span> <input style=\"width: 30%;\" placeholder=\"开始" + m_table.Brief + "\" class=\"input-sm form-control form-datetime begintime\" name=\"begin_" + StringDeal.HeadLower(m_table.Name) + "\"   id=\"begin_" + StringDeal.HeadLower(m_table.Name) + "\"  readonly=\"readonly\"  runat=\"server\"  /></div>";
                str += " <div class=\"input-group date\"><span class=\"input-group-addon\"><i class=\"fa fa-calendar\"></i></span> <input style=\"width: 30%;\" placeholder=\"结束" + m_table.Brief + "\" class=\"input-sm form-control form-datetime endtime\" name=\"end_" + StringDeal.HeadLower(m_table.Name) + "\"    id=\"end_" + StringDeal.HeadLower(m_table.Name) + "\"  readonly=\"readonly\"  runat=\"server\" /></div>";

            }
            else
            {
                str = "<input style=\"width: 30%;\" placeholder=\"" + m_table.Brief + "\" class=\"input-sm form-control\" name=\"" + StringDeal.HeadLower(m_table.Name) + "\"  placeholder=\"" + m_table.Brief + "\" runat=\"server\"  id=\"" + StringDeal.HeadLower(m_table.Name) + "\" /> ";
            }

            return str;
        }
  
        public string GetEditerJsValue()
        {
            string str = "";
            if (m_table.EditType == "可视化编辑器")
            {
                str = @"         KE.show({
            id : '" + StringDeal.HeadLower(m_table.Name) + @"',
            imageUploadJson : '../../asp.net/upload_json.ashx',
            fileManagerJson : '../../asp.net/file_manager_json.ashx',
            allowFileManager : true,
		    afterCreate : function(id) {
			    KE.event.ctrl(document, 13, function() {
				    KE.util.setData(id);
				    document.forms['theform'].submit();
			    });
			    KE.event.ctrl(KE.g[id].iframeDoc, 13, function() {
				    KE.util.setData(id);
				    document.forms['theform'].submit();
			    });
		    }
             });
";
            }
            else if (m_table.EditType == "进度条上传")
            {
                str = @"
window.onload = function () {
 setUpSwf(""" + StringDeal.HeadLower(m_table.Name) + @""");
			    }  
";
            }
            return str;
        }
        
        public string GetSetSearchForm()
        {
            if (!m_table.BSearch) return "";
            string members = m_table.SelectMember;
            string[] values = m_table.SelectValue.Split('|');
            string str = "";
            if (m_table.EditType == "时间选择框(datetime)")
            {
                str = "begin_" + StringDeal.HeadLower(m_table.Name) + ".Value = GetStrFrom(\"begin_" + StringDeal.HeadUpper(m_table.Name) + "\"); \r\n";
                str += "end_" + StringDeal.HeadLower(m_table.Name) + ".Value = GetStrFrom(\"end_" + StringDeal.HeadUpper(m_table.Name) + "\"); \r\n";

            }
            else if (m_table.EditType == "下拉框表关联")
            {

                str += @"List<" + StringDeal.HeadUpper(members) + @"> " + StringDeal.HeadLower(members) + @"List = TableOperate<" + StringDeal.HeadUpper(members) + @">.Select();
                " + StringDeal.HeadUpper(members) + @" one" + StringDeal.HeadUpper(members) + @" = new " + StringDeal.HeadUpper(members) + @"();
                one" + StringDeal.HeadUpper(members) + @"." + StringDeal.HeadUpper(values[0]) + @" = 0;
                one" + StringDeal.HeadUpper(members) + @"." + StringDeal.HeadUpper(values[1]) + @" = ""选择" + m_table .Brief + @""";
                " + StringDeal.HeadLower(members) + @"List.Insert(0, one" + StringDeal.HeadUpper(members) + @");
                " + StringDeal.HeadLower(m_table.Name) + @".DataSource = " + StringDeal.HeadLower(members) + @"List;
                " + StringDeal.HeadLower(m_table.Name) + @".DataTextField = """ + StringDeal.HeadUpper(values[1]) + @""";
                " + StringDeal.HeadLower(m_table.Name) + @".DataValueField = """ + StringDeal.HeadUpper(values[0]) + @""";
                ";
                str += StringDeal.HeadLower(m_table.Name) + ".DataBind();\r\n";
                str += StringDeal.HeadLower(m_table.Name) + ".Value=  GetStrFrom(\"" + StringDeal.HeadUpper(m_table.Name) + "\"); \r\n";

            }
            else if (m_table.EditType == "弹出框表关联")
            {
                str = StringDeal.HeadLower(m_table.Name) + ".Value=  GetStrFrom(\"" + StringDeal.HeadUpper(m_table.Name) + "\"); \r\n";
                str = StringDeal.HeadLower(m_table.Name) + "_name.Value=  GetStrFrom(\"" + StringDeal.HeadUpper(m_table.Name) + "_name\"); \r\n";

            }
            else
            {
                str = StringDeal.HeadLower(m_table.Name) + ".Value=  GetStrFrom(\"" + StringDeal.HeadUpper(m_table.Name) + "\"); \r\n";
            }

            return str;
        }

        public string GetSetSearchCondition()
        {
           
            if (!m_table.BSearch) return "";
            string members = m_table.SelectMember;
            string[] values = m_table.SelectValue.Split('|');
            string str = "";
            if (m_table.EditType == "时间选择框(datetime)")
            {
                str = @"
 #region " + m_table.Brief + @"
if (GetStrFrom(""begin_" + StringDeal.HeadLower(m_table.Name) + @""") != """")
                {
 
                    DateTime " + StringDeal.HeadUpper(m_table.Name) + @"begin = Convert." + m_table.ConvertString + @"(this.Request[""begin_" + StringDeal.HeadLower(m_table.Name) + @"""]);

                    condition.AddConditon("" and " + StringDeal.HeadUpper(m_table.Name) + @">=@begin_" + StringDeal.HeadUpper(m_table.Name) + @"  "");
                    condition.AddParameter(""begin_" + StringDeal.HeadUpper(m_table.Name) + @""", " + StringDeal.HeadUpper(m_table.Name) + @"begin);
                }";

                str += @"  if (GetStrFrom(""end_" + StringDeal.HeadLower(m_table.Name) + @""") != """")
                {
 
                    DateTime " + StringDeal.HeadUpper(m_table.Name) + @"end = Convert." + m_table.ConvertString + @"(this.Request[""end_" + StringDeal.HeadLower(m_table.Name) + @"""]);

                    condition.AddConditon("" and " + StringDeal.HeadUpper(m_table.Name) + @"<=@end_" + StringDeal.HeadUpper(m_table.Name) + @"  "");
                    condition.AddParameter(""end_" + StringDeal.HeadUpper(m_table.Name) + @""", " + StringDeal.HeadUpper(m_table.Name) + @"end);
                }
#endregion
";


            }
            else
            {

                if (m_table.NetType == "long" || m_table.NetType == "decimal" || m_table.NetType == "double" || m_table.NetType == "int"

                   || m_table.NetType == "Single" || m_table.NetType == "UInt32")
                {
                    str = @" 
 #region " + m_table.Brief + @"
" + m_table.NetType + @" condition" + StringDeal.HeadUpper(m_table.Name) + @" = -1 ;";
                   str += @"                   
                    if (!string.IsNullOrEmpty(this.Request[""" + StringDeal.HeadUpper(m_table.Name) + @"""]))
                    {
                       condition" + StringDeal.HeadUpper(m_table.Name) + @" = Convert." + m_table.ConvertString + @"(this.Request[""" + StringDeal.HeadLower(m_table.Name) + @"""]);
                    }

                    if (condition" + StringDeal.HeadUpper(m_table.Name) + @" != -1)
                    {
                        condition." + StringDeal.HeadUpper(m_table.Name) + @" =  condition" + StringDeal.HeadUpper(m_table.Name) + @" ;
                    }
#endregion
                    ";
                }
                else
                {
                    str = @" 
 #region " + m_table.Brief + @"                   
                    if (!string.IsNullOrEmpty(this.Request[""" + StringDeal.HeadUpper(m_table.Name) + @"""]))
                    {
                        " + m_table.NetType + @" condition" + StringDeal.HeadUpper(m_table.Name) + @" = Convert." + m_table.ConvertString + @"(this.Request[""" + StringDeal.HeadLower(m_table.Name) + @"""]);
                        condition." + StringDeal.HeadUpper(m_table.Name) + @" = ""%"" + condition" + StringDeal.HeadUpper(m_table.Name) + @" + ""%"";
                        condition.AddAttach(""" + StringDeal.HeadUpper(m_table.Name) + @""", ""like"");
                    }
#endregion
                    ";
                }
            }

            return str;
        }

        //没在用
        public string GetUpdateForm()
        {
            string str = "";

            string[] members = m_table.SelectMember.Split('|');
            string[] value = m_table.SelectValue.Split('|');
            string strNecessary = "";
            if (m_table.Necessary)
            {
                strNecessary = "required";
            }
            switch (m_table.EditType)
            {


                case "文本框(text)":
                    str = "<input class=\"form-control\" " + strNecessary + " name=\"" + StringDeal.HeadLower(m_table.Name) + "\" value=\"<%#" + StringDeal.HeadLower(m_table.TableName) + "." + StringDeal.HeadUpper(StringDeal.HeadLower(m_table.Name)) + "%>\" /> ";
                    break;
                case "密码框(password)":
                    str = "<input class=\"form-control\" " + strNecessary + " name=\"" + StringDeal.HeadLower(m_table.Name) + "\" type=\"password\" value=\"<%#" + StringDeal.HeadLower(m_table.TableName) + "." + StringDeal.HeadUpper(StringDeal.HeadLower(m_table.Name)) + "%>\" /> ";
                    break;
                case "复选选择框(checkBox)":

                    for (int i = 0; i < members.Length; i++)
                    {
                        str += "<input type=\"checkbox\" name=\"" + StringDeal.HeadLower(m_table.Name) + "\" value=\"" + value[i] + "\"  <%#SetChecked(Convert.ToString(" + StringDeal.HeadLower(m_table.TableName) + "." + StringDeal.HeadUpper(StringDeal.HeadLower(m_table.Name)) + "), \"" + value[i] + "\") %> />" + members[i] + "";
                    }
                    if (string.IsNullOrEmpty(m_table.SelectMember))
                    {
                        str = "<input type=\"checkbox\" name=\"" + StringDeal.HeadLower(m_table.Name) + "\" value=\"" + StringDeal.HeadLower(m_table.Name) + "\" <%#SetChecked(Convert.ToString(" + StringDeal.HeadLower(m_table.TableName) + "." + StringDeal.HeadUpper(StringDeal.HeadLower(m_table.Name)) + "), " + StringDeal.HeadLower(m_table.Name) + ") %>/>" + StringDeal.HeadLower(m_table.Name) + "";
                    }
                    break;
                case "选择框(select)":


                    str = "<select class=\"form-control\" " + strNecessary + " name=\"" + StringDeal.HeadLower(m_table.Name) + "\" >";
                    for (int i = 0; i < members.Length; i++)
                    {
                        str += "<option value=\"" + value[i] + "\"  <%#SetSelected(Convert.ToString(" + StringDeal.HeadLower(m_table.TableName) + "." + StringDeal.HeadUpper(StringDeal.HeadLower(m_table.Name)) + "), \"" + value[i] + "\") %> >" + members[i] + "</option>";
                    }
                    str += "</select>";
                    break;
                case "单选选择框(radio)":

                    for (int i = 0; i < members.Length; i++)
                    {
                        str += "<input name=\"" + StringDeal.HeadLower(m_table.Name) + "\" type=\"radio\" value=\"" + value[i] + "\"  <%#SetChecked(Convert.ToString(" + StringDeal.HeadLower(m_table.TableName) + "." + StringDeal.HeadUpper(StringDeal.HeadLower(m_table.Name)) + "), \"" + value[i] + "\") %>  />" + members[i] + "";
                    }
                    break;
                case "时间选择框(datetime)":
                    str = "<input class=\"form-control form-datetime\"" + strNecessary + " name=\"" + StringDeal.HeadLower(m_table.Name) + "\" value=\"<%#" + StringDeal.HeadLower(m_table.TableName) + "." + StringDeal.HeadUpper(StringDeal.HeadLower(m_table.Name)) + "%>\"   readonly=\"readonly\"  />";
                    break;
                case "上传选择框(upload)":
                    str = @"<INPUT class=""form-control"" " + strNecessary + @" name=""" + StringDeal.HeadLower(m_table.Name) + @""" value=""<%#" + StringDeal.HeadLower(m_table.TableName) + "." + StringDeal.HeadUpper(StringDeal.HeadLower(m_table.Name)) + @"%>"" >  <input type=""button"" id=""btn_" + StringDeal.HeadLower(m_table.Name) + @""" value=""上传"" onClick=""openwin(this);"" />
        &nbsp;</td>
    </tr>
	
     <TR id=""upPic_" + StringDeal.HeadLower(m_table.Name) + @""" style="" display:none"">
    <TD class=row height=30 style=""width: 83px"">上传图片：</TD>
    <TD class=row ><iframe  id=""Iframe1_" + StringDeal.HeadLower(m_table.Name) + @"""  name=""upimg_" + StringDeal.HeadLower(m_table.Name) + @""" src=""../UpFile.aspx?name=" + StringDeal.HeadLower(m_table.Name) + @""" width=""450"" height=""55""  frameborder=0></IFRAME>";

                    break;
                case "文本框(textarea)":
                    str = "<textarea class=\"form-control\" " + strNecessary + " name=\"" + StringDeal.HeadLower(m_table.Name) + "\" cols=\"50\" rows=\"10\" ><%#" + StringDeal.HeadLower(m_table.TableName) + "." + StringDeal.HeadUpper(StringDeal.HeadLower(m_table.Name)) + "</textarea>";
                    break;
                default:
                    str = "<input class=\"form-control\" " + strNecessary + " name=\"" + StringDeal.HeadLower(m_table.Name) + "\"  value=\"<%#" + StringDeal.HeadLower(m_table.TableName) + "." + StringDeal.HeadUpper(StringDeal.HeadLower(m_table.Name)) + "%>\" /> ";
                    break;
            }
            return str;
        }
         
        public string GetServerForm()
        {
            string str = "";

            string[] members = m_table.SelectMember.Split('|');
            string[] value = m_table.SelectValue.Split('|');
            string strNecessary = "";
            string strCheckType = "";
            if (m_table.Necessary)
            {
                strNecessary = "required";
            }

            if (m_table.NetType == "int")
            {
                strCheckType = " checkint";
            }
            else if (m_table.NetType == "double")
            {
                strCheckType = " checkfloat";
            } 

            switch (m_table.EditType)
            {


                case "文本框(text)":
                    str = "<input requiredName=\"" + StringDeal.HeadLower(m_table.Brief) + "\" class=\"form-control " + strNecessary + strCheckType + "\" name=\"" + StringDeal.HeadLower(m_table.Name) + "\"  runat=\"server\"  id=\"" + StringDeal.HeadLower(m_table.Name) + "\" /> ";
                    break;
                case "密码框(password)":
                    str = "<input requiredName=\"" + StringDeal.HeadLower(m_table.Brief) + "\"  class=\"form-control " + strNecessary + strCheckType + "\" name=\"" + StringDeal.HeadLower(m_table.Name) + "\" type=\"password\"  runat=\"server\"  id=\"" + StringDeal.HeadLower(m_table.Name) + "\"  /> ";
                    break;
                case "复选选择框(checkBox)":

                    for (int i = 0; i < members.Length; i++)
                    {
                        str += "<input  requiredName=\"" + StringDeal.HeadLower(m_table.Brief) + "\"  type=\"checkbox\" name=\"" + StringDeal.HeadLower(m_table.Name) + "\"  id=\"_" + StringDeal.HeadLower(m_table.Name) + "__" + i + "\" value=\"" + value[i] + "\"    runat=\"server\" />" + members[i] + "  \r\n ";
                    }
                    if (string.IsNullOrEmpty(m_table.SelectMember))
                    {
                        str = "<input  requiredName=\"" + StringDeal.HeadLower(m_table.Brief) + "\"  type=\"checkbox\" name=\"" + StringDeal.HeadLower(m_table.Name) + "\"  id=\"_" + StringDeal.HeadLower(m_table.Name) + "__\"  value=\"" + StringDeal.HeadLower(m_table.Name) + "\"   runat=\"server\" />" + StringDeal.HeadLower(m_table.Name) + "  \r\n ";
                    }
                    break;
                case "选择框(select)":


                    str = "<select  requiredName=\"" + StringDeal.HeadLower(m_table.Brief) + "\"  class=\"form-control " + strNecessary + "\" name=\"" + StringDeal.HeadLower(m_table.Name) + "\" id=\"" + StringDeal.HeadLower(m_table.Name) + "\"  runat=\"server\"> \r\n";
                    for (int i = 0; i < members.Length; i++)
                    {
                        str += "<option value=\"" + value[i] + "\">" + members[i] + "</option> \r\n";
                    }
                    str += "</select>";
                    break;
                //"_" + strID + "__"
                case "单选选择框(radio)":

                    for (int i = 0; i < members.Length; i++)
                    {
                        str += "<input  requiredName=\"" + StringDeal.HeadLower(m_table.Brief) + "\"  name=\"" + StringDeal.HeadLower(m_table.Name) + "\"   id=\"_" + StringDeal.HeadLower(m_table.Name) + "__" + i + "\"  type=\"radio\" value=\"" + value[i] + "\"   runat=\"server\"  />" + members[i] + " \r\n";
                    }
                    break;
                case "时间选择框(datetime)":
                    str = "<div class=\"input-group date\"><span class=\"input-group-addon\"><i class=\"fa fa-calendar\"></i></span><input  requiredName=\"" + StringDeal.HeadLower(m_table.Brief) + "\"  class=\"form-control form-datetime " + strNecessary + "\" name=\"" + StringDeal.HeadLower(m_table.Name) + "\"   id=\"" + StringDeal.HeadLower(m_table.Name) + "\"   readonly=\"readonly\" runat=\"server\"  /></div>";
                    break;
                case "上传选择框(upload)":
                    str = @"<INPUT  requiredName=""" + StringDeal.HeadLower(m_table.Brief) + @""" type=""hidden"" class=""form-control " + strNecessary + strCheckType + @""" name=""" + StringDeal.HeadLower(m_table.Name) + @"""  id=""" + StringDeal.HeadLower(m_table.Name) + @"""  runat=""server"" >
                            <iframe  id=""Iframe1_" + StringDeal.HeadLower(m_table.Name) + @"""  name=""upimg_" + StringDeal.HeadLower(m_table.Name) + @""" src=""../UpFile.aspx?name=" + StringDeal.HeadLower(m_table.Name) + @""" width=""365"" height=""48""  frameborder=0></IFRAME>
<br /> 
                                             <div id=""div_" + StringDeal.HeadLower(m_table.Name) + @""">
                                             <%#getFileHtml(" + StringDeal.HeadLower(m_table.TableName) + @"." + StringDeal.HeadUpper(m_table.Name) + @", """ + StringDeal.HeadLower(m_table.Name) + @""")%>
                                             </div>
";

                    break;
                case "文本框(textarea)":
                    str = "<textarea requiredName=\"" + StringDeal.HeadLower(m_table.Brief) + "\"  class=\"form-control " + strNecessary + strCheckType + "\" name=\"" + StringDeal.HeadLower(m_table.Name) + "\" cols=\"50\" rows=\"6\" id=\"" + StringDeal.HeadLower(m_table.Name) + "\"  runat=\"server\" ></textarea>";
                    break;

                case "可视化编辑器":
                    str = "<textarea  requiredName=\"" + StringDeal.HeadLower(m_table.Brief) + "\"  class=\"form-control summernote " + strNecessary + strCheckType + "\" name=\"" + StringDeal.HeadLower(m_table.Name) + "\"   style=\" width:100%; height:400px\"   id=\"" + StringDeal.HeadLower(m_table.Name) + "\"  runat=\"server\"></textarea>";
                    break;

                case "进度条上传":
                    str = @"<INPUT  requiredName=""" + StringDeal.HeadLower(m_table.Brief) + @"""  type=""hidden"" class=""form-control " + strNecessary + strCheckType + @""" name=""" + StringDeal.HeadLower(m_table.Name) + @"""   id=""" + StringDeal.HeadLower(m_table.Name) + @"""  runat=""server"">  
                            <iframe  id=""Iframe1_" + StringDeal.HeadLower(m_table.Name) + @"""  name=""upimg_" + StringDeal.HeadLower(m_table.Name) + @""" src=""../UpFileProgress.aspx?name=" + StringDeal.HeadLower(m_table.Name) + @""" width=""375"" height=""140""  frameborder=0></IFRAME>
<br /> 
                                             <div id=""div_" + StringDeal.HeadLower(m_table.Name) + @""">
                                             <%#getFileHtml(" + StringDeal.HeadLower(m_table.TableName) + @"." + StringDeal.HeadUpper(m_table.Name) + @", """ + StringDeal.HeadLower(m_table.Name) + @""")%>
                                             </div>
"; 
                    break;

                case "下拉框表关联":
                    str = "<select  requiredName=\"" + StringDeal.HeadLower(m_table.Brief) + "\" class=\"form-control " + strNecessary + strCheckType + "\" name=\"" + StringDeal.HeadLower(m_table.Name) + "\" id=\"" + StringDeal.HeadLower(m_table.Name) + "\"  runat=\"server\"  > </select>";
                    break;

                case "弹出框表关联":
                    str = "<input  type=\"hidden\"　name=\"" + StringDeal.HeadLower(m_table.Name) + "\" id=\"" + StringDeal.HeadLower(m_table.Name) + "\" runat=\"server\"/>";
                    str += "<input　 requiredName=\"" + StringDeal.HeadLower(m_table.Brief) + "\" readonly=\"readonly\" placeholder=\"点击选择" + m_table.Brief + "\" class=\"form-control form-showpanel " + strNecessary + "\" vid=\"" + StringDeal.HeadLower(m_table.Name) + "\" modal_title=\"选择" + m_table.Brief + "\" modal_url=\"../Manage" + m_table.SelectMember + "/Modal.aspx\" name=\"" + StringDeal.HeadLower(m_table.Name) + "_name\" id=\"" + StringDeal.HeadLower(m_table.Name) + "_name\" runat=\"server\"/>";
                    break;

                default:
                    str = "<input requiredName=\"" + StringDeal.HeadLower(m_table.Brief) + "\"  class=\"form-control " + strNecessary + strCheckType + "\" name=\"" + StringDeal.HeadLower(m_table.Name) + "\" id=\"" + StringDeal.HeadLower(m_table.Name) + "\" runat=\"server\" /> ";
                    break;
            }
            return str;
        }

        public string GetListShowHanShu()
        {

            string str = "";

            string[] members = m_table.SelectMember.Split('|');
            string[] value = m_table.SelectValue.Split('|');

            if (m_table.EditType == "复选选择框(checkBox)" || m_table.EditType == "选择框(select)" || m_table.EditType == "单选选择框(radio)")
            {
                if (m_table.SelectMember != m_table.SelectValue)
                {
                    str += "#region " + m_table.Brief + "显示函数\r\n";
                    str += "protected string GetSelect" + StringDeal.HeadUpper(m_table.Name) + "(" + m_table.NetType + " word)\r\n";
                    str += "{\r\n";
                    str += "    switch (word)\r\n";
                    str += "    {\r\n";

                    for (int i = 0; i < members.Length; i++)
                    {
                        if (m_table.NetType == "string")
                        {
                            str += "  case \"" + value[i] + "\":\r\n";
                        }
                        else
                        {
                            str += "  case " + value[i] + ":\r\n";
                        }
                        str += "    return \"" + members[i] + "\";\r\n";
                    }
                    str += "  default:\r\n";
                    str += "    return \"\";\r\n";
                    str += "   }\r\n";
                    str += "}\r\n";
                    str += "#endregion \r\n";
                }
            }
            else if (m_table.EditType == "下拉框表关联" || m_table.EditType == "弹出框表关联")
            {
                if (value.Length == 2)
                {
                    string name = value[0];
                    string name1 = value[1];
                    str += "#region " + m_table.Brief + "表关联显示函数\r\n";
                    str += "List<" + StringDeal.HeadUpper(m_table.SelectMember) + "> m_" + StringDeal.HeadLower(m_table.Name) + "List = new List<" + StringDeal.HeadUpper(m_table.SelectMember) + ">(); \r\n";
                    str += "protected string GetTanChu" + StringDeal.HeadUpper(m_table.Name) + "(" + m_table.NetType + " word) \r\n";
                    str += "{ \r\n";
                    str += "    for (int i = 0; i < m_" + StringDeal.HeadLower(m_table.Name) + "List.Count; i++) \r\n";
                    str += "    { \r\n";
                    str += "        if (m_" + StringDeal.HeadLower(m_table.Name) + "List[i]." + StringDeal.HeadUpper(name) + " == word) \r\n";
                    str += "        { \r\n";
                    str += "            return m_" + StringDeal.HeadLower(m_table.Name) + "List[i]." + StringDeal.HeadUpper(name1) + "; \r\n";
                    str += "        } \r\n";
                    str += "    }  \r\n";
                    str += "    return \"\"; \r\n";
                    str += "} \r\n";
                    str += "#endregion \r\n";
                }
            }


            return str;
        }

        public string GetViewShowHanShu()
        {
            string str = "";
            string[] members = m_table.SelectMember.Split('|');
            string[] value = m_table.SelectValue.Split('|');

            if (m_table.EditType == "复选选择框(checkBox)" || m_table.EditType == "选择框(select)" || m_table.EditType == "单选选择框(radio)")
            {
                if (m_table.SelectMember != m_table.SelectValue)
                {
                    str += "#region " + m_table.Brief + "显示函数\r\n";
                    str += "protected string GetSelect" + StringDeal.HeadUpper(m_table.Name) + "(" + m_table.NetType + " word)\r\n";
                    str += "{\r\n";
                    str += "    switch (word)\r\n";
                    str += "    {\r\n";

                    for (int i = 0; i < members.Length; i++)
                    {
                        if (m_table.NetType == "string")
                        {
                            str += "  case \"" + value[i] + "\":\r\n";
                        }
                        else
                        {
                            str += "  case " + value[i] + ":\r\n";
                        }
                        str += "    return \"" + members[i] + "\";\r\n";
                    }
                    str += "  default:\r\n";
                    str += "    return \"\";\r\n";
                    str += "   }\r\n";
                    str += "}\r\n";
                    str += "#endregion \r\n";
                }
            }
            else if (m_table.EditType == "下拉框表关联" || m_table.EditType == "弹出框表关联")
            {
                if (value.Length == 2)
                {
                    string name = value[0];
                    string name1 = value[1];
                    str += "#region " + m_table.Brief + "表关联显示函数\r\n";
                 
                    str += "protected string GetView" + StringDeal.HeadUpper(m_table.Name) + "(" + m_table.NetType + " word) \r\n";
                    str += "{ \r\n";


                    str += "" + StringDeal.HeadUpper(m_table.SelectMember) + " v" + StringDeal.HeadUpper(m_table.Name) + " = new " + StringDeal.HeadUpper(m_table.SelectMember) + "();\r\n";
                    str += "v" + StringDeal.HeadUpper(m_table.Name) + "." + value[1] + " = \"\";\r\n";
                    str += "" + StringDeal.HeadUpper(m_table.SelectMember) + " c" + StringDeal.HeadUpper(m_table.Name) + " = new " + StringDeal.HeadUpper(m_table.SelectMember) + "();\r\n";
                    str += "c" + StringDeal.HeadUpper(m_table.Name) + "." + value[0] + " = word;\r\n";
                    str += "return TableOperate<" + StringDeal.HeadUpper(m_table.SelectMember) + ">.GetOneValue(v" + StringDeal.HeadUpper(m_table.Name) + ", c" + StringDeal.HeadUpper(m_table.Name) + ");\r\n";


                  //str += "    for (int i = 0; i < m_" + StringDeal.HeadLower(m_table.Name) + "List.Count; i++) \r\n";
                  //  str += "    { \r\n";
                  //  str += "        if (m_" + StringDeal.HeadLower(m_table.Name) + "List[i]." + StringDeal.HeadUpper(name) + " == word) \r\n";
                  //  str += "        { \r\n";
                  //  str += "            return m_" + StringDeal.HeadLower(m_table.Name) + "List[i]." + StringDeal.HeadUpper(name1) + "; \r\n";
                  //  str += "        } \r\n";
                  //  str += "    }  \r\n";
                  //  str += "    return \"\"; \r\n";
                    str += "} \r\n";
                    str += "#endregion \r\n";
                }
            }


            return str;
        }
    }


}
