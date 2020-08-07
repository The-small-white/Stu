using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;

using System.Data;
using CodeBuild.Model;
using Dejun.DataProvider.Table;

namespace TemplateEngine
{
    public class BuildByTemplate
    {       
        #region 内部变量
        private TableManage m_table;// 列名表  
        private List<Table> m_listTable;// 列名表  
        private string m_template = "Template";
        #endregion


        #region 构造函数
        public BuildByTemplate(TableManage tableManage, bool bMode)
        {
            m_table = tableManage;
            m_listTable = new List<Table>();
            //if (bMode)
            //{
            //    AddModeBiXu();
            //}
            //else
            //{
            //    TypeUnit typeUnit = ConvertType("2");
            //    Table table = new Table();
            //    table.TableName = m_table.EnglishName;
            //    table.ChineseTableName = m_table.Name;

            //    table.Name = "ID";
            //    table.Brief = "编号";
            //    table.NetType = typeUnit.NetType;
            //    table.SqlType = typeUnit.SqlType;
            //    table.ConvertString = typeUnit.ConvertString;
            //    table.BIndex = true;
            //    m_listTable.Add(table);
            //}

            string[] ziduanZWArr = tableManage.ZhongWenZiDuan.Split(',');
            string[] ziduanArr = tableManage.ZiDuan.Split(',');
            string[] ziduanTypeArr = tableManage.ZiDuanType.Split(',');
            string[] addTypeArr = tableManage.AddType.Split(',');
            string[] chengYuanArr = tableManage.ChengYuan.Split(',');
            string[] zhiArr = tableManage.Zhi.Split(',');
            string[] biXuArr = tableManage.BiXu.Split(',');
            string[] souSuoArr = tableManage.SouSuo.Split(',');
            string[] lieBiaoArr = tableManage.LieBiao.Split(',');

            for (int i = 0; i < ziduanZWArr.Length; i++)
            {
                if (ziduanArr[i] == "AddID" || ziduanArr[i] == "AddName" || ziduanArr[i] == "AddTime" )
                {
                    continue;
                }
                TypeUnit typeUnit = ConvertType(ziduanTypeArr[i]);
                Table table = new Table();
                table.TableName = tableManage.EnglishName;
                table.ChineseTableName = tableManage.Name;

                table.Name = ziduanArr[i];
                table.Brief = ziduanZWArr[i];
                table.BSearch = souSuoArr[i] == "1";
                table.EditType = GetEditStr(addTypeArr[i]);
                table.Necessary = biXuArr[i] == "1";
                table.NetType = typeUnit.NetType;
                table.SelectMember = chengYuanArr[i];
                table.SelectValue = zhiArr[i];
                table.SqlType = typeUnit.SqlType;
                table.ConvertString = typeUnit.ConvertString;
                table.BIndex = lieBiaoArr[i] == "1";
                m_listTable.Add(table);
            }


            for (int i = 0; i < ziduanZWArr.Length; i++)
            {
                if (ziduanArr[i] == "AddID" || ziduanArr[i] == "AddName" || ziduanArr[i] == "AddTime")
                {
                    TypeUnit typeUnit = ConvertType(ziduanTypeArr[i]);
                    Table table = new Table();
                    table.TableName = tableManage.EnglishName;
                    table.ChineseTableName = tableManage.Name;

                    table.Name = ziduanArr[i];
                    table.Brief = ziduanZWArr[i];
                    table.BSearch = souSuoArr[i] == "1";
                    table.EditType = GetEditStr(addTypeArr[i]);
                    table.Necessary = biXuArr[i] == "1";
                    table.NetType = typeUnit.NetType;
                    table.SelectMember = chengYuanArr[i];
                    table.SelectValue = zhiArr[i];
                    table.SqlType = typeUnit.SqlType;
                    table.ConvertString = typeUnit.ConvertString;
                    table.BIndex = lieBiaoArr[i] == "1";
                    m_listTable.Add(table);
                }
                
            }

            //if (!bMode)
            //{

            //    TypeUnit typeUnit = ConvertType("字符串长度50");
            //    Table table = new Table();
            //    table.TableName = m_table.EnglishName;
            //    table.ChineseTableName = m_table.Name;

            //    table.Name = "ID";
            //    table.Brief = "添加人姓名";
            //    table.NetType = typeUnit.NetType;
            //    table.SqlType = typeUnit.SqlType;
            //    table.ConvertString = typeUnit.ConvertString;
            //    table.BIndex = true;
            //    m_listTable.Add(table);
            //}



        }
        #endregion
         
        private void AddModeBiXu()
        {
            //string[] ziduanZWArr = "编号,添加时间,添加人ID,添加人姓名,审批人,审批结果,钉钉,钉钉发送结果".Split(',');
            //string[] ziduanArr = "ID,XTAddTime,XTAddID,XTAddName,XTShenPi,XTShenPiResult,XTDingDing,XTDingDingResult".Split(',');
            //string[] ziduanTypeArr = "2,3,2,0,1,1,1,1".Split(',');

            //for (int i = 0; i < ziduanZWArr.Length; i++)
            //{
            //    TypeUnit typeUnit = ConvertType(ziduanTypeArr[i]);
            //    Table table = new Table();
            //    table.TableName = m_table.EnglishName;
            //    table.ChineseTableName = m_table.Name;

            //    table.Name = ziduanArr[i];
            //    table.Brief = ziduanZWArr[i];
            //    table.NetType = typeUnit.NetType;
            //    table.SqlType = typeUnit.SqlType;
            //    table.ConvertString = typeUnit.ConvertString;
            //    m_listTable.Add(table);
            //}
        }
        private string BuildByStr(string templateStr)
        {
            bool bSearch = false;
            bool bDate = false;
            bool bIndexDate = false;
            bool bUpload = false;
            bool bEditer = false;
            int i = 0;
            int indexCount = 0;
            while (templateStr.IndexOf("{循环") != -1)
            {
                string forBegin = "{循环" + i + "}";
                string forEnd = "{结束循环" + i + "}";
                string itemStr = StringDeal.CutString(templateStr, forBegin, forEnd);

                string newStr = "";
                indexCount = 0;
                int colCount = 0;
                for (int j = 0; j < m_listTable.Count; j++)
                {
                    Table table = m_listTable[j];

                    if ((templateStr == "Edit.aspx" || templateStr == "Edit.aspx.cs")
                        && (table.Name == "AddTime" || table.Name == "AddID"))
                    {
                        continue;
                    }
                    
                     //string[] ziduanZWArr = "编号,添加时间,添加人ID,添加人姓名,审批人,审批结果,钉钉,钉钉发送结果".Split(',');
            //string[] ziduanArr = "ID,XTAddTime,XTAddID,XTAddName,XTShenPi,XTShenPiResult,XTDingDing,XTDingDingResult".Split(',');
            //string[] ziduanTypeArr = "2,3,2,0,1,1,1,1".Split(',');

                    string tempStr = itemStr.Replace("{列名}", table.Name);

                    string beginStr11 = "{首页显示}";
                    string endStr11 = "{结束首页显示}";
                    string delItemStr11 = StringDeal.CutString(tempStr, beginStr11, endStr11);
                    if (table.BIndex)
                    {
                        tempStr = tempStr.Replace("{首页显示}", "");
                        tempStr = tempStr.Replace("{结束首页显示}", "");
                        colCount++;
                    }
                    else
                    {
                        tempStr = tempStr.Replace(beginStr11 + delItemStr11 + endStr11, "");
                    }

                    beginStr11 = "{搜索字段}";
                    endStr11 = "{结束搜索字段}";
                    delItemStr11 = StringDeal.CutString(tempStr, beginStr11, endStr11);
                    if (table.BSearch)
                    {
                        tempStr = tempStr.Replace("{搜索字段}", "");
                        tempStr = tempStr.Replace("{结束搜索字段}", "");
                    }
                    else
                    {
                        tempStr = tempStr.Replace(beginStr11 + delItemStr11 + endStr11, "");
                    }


                    tempStr = tempStr.Replace("{表名}", table.TableName);
                    tempStr = tempStr.Replace("{首字母大写表名}", StringDeal.HeadUpper(table.TableName));
                    tempStr = tempStr.Replace("{首字母小写表名}", StringDeal.HeadLower(table.TableName));
                    tempStr = tempStr.Replace("{中文表名}", string.IsNullOrEmpty(table.ChineseTableName) ? table.TableName : table.ChineseTableName);


                    tempStr = tempStr.Replace("{小写列名}", StringDeal.HeadLower(table.Name));
                    tempStr = tempStr.Replace("{列名NET类型}", table.NetType);
                    tempStr = tempStr.Replace("{首字母大写列名}", StringDeal.HeadUpper(table.Name));
                    tempStr = tempStr.Replace("{列名sql类型}", table.SqlType);
                    tempStr = tempStr.Replace("{类型转化字符}", table.ConvertString);

                    tempStr = tempStr.Replace("{中文列名}", string.IsNullOrEmpty(table.Brief) ? table.Name : table.Brief);
                    FormItem formItem = new FormItem(table);
                    tempStr = tempStr.Replace("{表单字符串}", formItem.GetForm());
                    tempStr = tempStr.Replace("{更新表单字符串}", formItem.GetUpdateForm());
                    tempStr = tempStr.Replace("{添加和更新表单字符串}", formItem.GetServerForm());
                    string lieLength = "col-sm-3";
                    if (table.EditType == "可视化编辑器" || table.EditType == "上传选择框(upload)" || table.EditType == "进度条上传")
                    {
                        lieLength = "col-sm-10";
                    }
                    tempStr = tempStr.Replace("{列的长度}", lieLength);
                    tempStr = tempStr.Replace("{设置值表单字符串}", formItem.GetUpdateSetValue());
                    tempStr = tempStr.Replace("{设置值表单条件字符串}", formItem.GetUpdateConditon());

                    tempStr = tempStr.Replace("{验证字符串}", formItem.GetJs());
                    tempStr = tempStr.Replace("{插入验证是否必须}", formItem.GetInsertNecessary());
                    tempStr = tempStr.Replace("{更新验证是否必须}", formItem.GetUpdateNecessary());

                   string liexianshi = "(("+StringDeal.HeadUpper(table.TableName)+")Container.DataItem)."+StringDeal.HeadUpper(table.Name);
                   if ((table.EditType == "选择框(select)" || table.EditType == "复选选择框(checkBox)" || table.EditType == "单选选择框(radio)") && table.SelectMember != table.SelectValue)
                   {
                       liexianshi = "GetSelect" + StringDeal.HeadUpper(table.Name) + "(" + liexianshi + ")";
                   }
                   else if (table.EditType == "下拉框表关联" || table.EditType == "弹出框表关联")
                   {
                       liexianshi = "GetTanChu" + StringDeal.HeadUpper(table.Name) + "(" + liexianshi + ")";
                   }
                   tempStr = tempStr.Replace("{首页列表字段显示}", liexianshi);
                   tempStr = tempStr.Replace("{首页列表字段显示函数}", formItem.GetListShowHanShu());

                     
                   tempStr = tempStr.Replace("{显示页字段显示函数}", formItem.GetViewShowHanShu());
                   
                   tempStr = tempStr.Replace("{首页列表弹出字段获取列表}", formItem.GetShouYeTanList());

                   if (colCount == 2)
                   {
                       string ljie = "<a href=\"View.aspx?" + StringDeal.HeadLower(m_listTable[0].Name) + "=<%#((" + StringDeal.HeadUpper(table.TableName) + ")Container.DataItem)." + StringDeal.HeadUpper(m_listTable[0].Name) + " %>\">";
                       tempStr = tempStr.Replace("{首页列表链接}", ljie);
                       tempStr = tempStr.Replace("{首页列表链接结束}", "</a>");
                   }
                   else
                   {
                       tempStr = tempStr.Replace("{首页列表链接}", "");
                       tempStr = tempStr.Replace("{首页列表链接结束}", "");
                   }
                    //{首页列表字段显示}

                    if (table.BSearch)
                    {
                        bSearch = true;
                    }
                    if (table.EditType == "时间选择框(datetime)")
                    {
                        bDate = true;
                    }

                    if (table.EditType == "时间选择框(datetime)" && table.BSearch)
                    {
                        bIndexDate = true;
                    }
                    if (table.BIndex)
                    {
                        indexCount++;
                    }

                    if (table.EditType == "进度条上传")
                    {
                        bUpload = true;
                    }

                    if (table.EditType == "可视化编辑器")
                    {
                        bEditer = true;
                    }

                    tempStr = tempStr.Replace("{搜索表单字符串}", formItem.GetSearchForm());
                    tempStr = tempStr.Replace("{弹出框搜索表单字符串}", formItem.GetTanChuSearchForm());
                    tempStr = tempStr.Replace("{设置搜索表单字符串}", formItem.GetSetSearchForm());
                    tempStr = tempStr.Replace("{设置搜索表单查询条件}", formItem.GetSetSearchCondition());
                    tempStr = tempStr.Replace("{设置搜索表单查询条件1}", formItem.GetSetSearchCondition().Replace("this.Request[", "context.Request["));

                    tempStr = tempStr.Replace("{表单相关JS}", formItem.GetEditerJsValue());
                    if (table.EditType == "进度条上传" || table.EditType == "上传选择框(upload)")
                    {
                        string setBiaoDan = "new" + StringDeal.HeadUpper(table.TableName) + "." + StringDeal.HeadUpper(table.Name) + " = this.Request[\"" + StringDeal.HeadLower(table.Name) + "_fileName\"] + \"|\" + this.Request[\"" + StringDeal.HeadLower(table.Name) + "_showName\"] + \"|\" + this.Request[\"" + StringDeal.HeadLower(table.Name) + "_addTime\"];\r\n";
                        tempStr = tempStr.Replace("{设置上传文件列表表单}", setBiaoDan);
                    }
                    else
                    {
                        tempStr = tempStr.Replace("{设置上传文件列表表单}", "");
                    }

                    if (table.Name == "DaKuanZhuangTai" || table.Name == "XTShenHeZhuangTai")
                    {

                        string setBiaoDan = "new" + StringDeal.HeadUpper(table.TableName) + "." + StringDeal.HeadUpper(table.Name) + " = 0;\r\n";
                        tempStr = tempStr.Replace("{设置值数字默认值}", setBiaoDan);
                    }
                    else
                    {
                        tempStr = tempStr.Replace("{设置值数字默认值}", "");
                    }

                    newStr += tempStr;
                }

                itemStr = "{循环" + i + "}" + itemStr + "{结束循环" + i + "}";

                templateStr = templateStr.Replace(itemStr, newStr);

                i++;
            }

            #region 处理特殊循环
            string teshuForBegin = "{第二列开始循环}";
            string teshuForEnd = "{结束第二列开始循环}";
            string teshuItemStr = StringDeal.CutString(templateStr, teshuForBegin, teshuForEnd);

            string teshuNewStr = "";

            for (int j = 1; j < m_listTable.Count; j++)
            {
                Table table = m_listTable[j];

                if ((templateStr == "Edit.aspx" || templateStr == "Edit.aspx.cs")
                        && (table.Name == "AddTime" || table.Name == "AddID"))
                {
                    continue;
                }
                string tempStr = teshuItemStr.Replace("{列名}", table.Name);
                tempStr = tempStr.Replace("{表名}", table.TableName);
                tempStr = tempStr.Replace("{首字母大写表名}", StringDeal.HeadUpper(table.TableName));
                tempStr = tempStr.Replace("{首字母小写表名}", StringDeal.HeadLower(table.TableName));

                tempStr = tempStr.Replace("{小写列名}", StringDeal.HeadLower(table.Name));
                tempStr = tempStr.Replace("{列名NET类型}", table.NetType);
                tempStr = tempStr.Replace("{首字母大写列名}", StringDeal.HeadUpper(table.Name));
                tempStr = tempStr.Replace("{列名sql类型}", table.SqlType);
                tempStr = tempStr.Replace("{类型转化字符}", table.ConvertString);

                tempStr = tempStr.Replace("{中文列名}", string.IsNullOrEmpty(table.Brief) ? table.Name : table.Brief);
                FormItem formItem = new FormItem(table);
                tempStr = tempStr.Replace("{表单字符串}", formItem.GetForm());
                tempStr = tempStr.Replace("{更新表单字符串}", formItem.GetUpdateForm());
                tempStr = tempStr.Replace("{添加和更新表单字符串}", formItem.GetServerForm());
                string lieLength = "col-sm-3";
                if (table.EditType == "可视化编辑器" || table.EditType == "上传选择框(upload)" || table.EditType == "进度条上传")
                {
                    lieLength = "col-sm-10";
                }
                tempStr = tempStr.Replace("{列的长度}", lieLength);
                tempStr = tempStr.Replace("{设置值表单字符串}", formItem.GetUpdateSetValue());
                tempStr = tempStr.Replace("{验证字符串}", formItem.GetJs());
                tempStr = tempStr.Replace("{插入验证是否必须}", formItem.GetInsertNecessary());
                tempStr = tempStr.Replace("{更新验证是否必须}", formItem.GetUpdateNecessary());

              
                 // <%#getFileHtml(m_baoXiaoGuanLi.BaoXiaoPingZheng, "baoXiaoPingZheng", false)%>      <%#{文件列表预览函数}m_{首字母小写表名}.{首字母大写列名}{文件列表预览函数结束}%> 

                teshuNewStr += tempStr;
            }
            //templateStr = templateStr.Replace("{循环" + i + "}", "");
            //templateStr = templateStr.Replace("{结束循环" + i + "}", "");
            //newStr = "{循环" + i + "}" + newStr + "{结束循环" + i + "}";
            teshuItemStr = "{第二列开始循环}" + teshuItemStr + "{结束第二列开始循环}";
            templateStr = templateStr.Replace(teshuItemStr, teshuNewStr);

            #endregion

            #region 处理特殊循环1
            string teshuForBegin1 = "{第二列开始循环1}";
            string teshuForEnd1 = "{结束第二列开始循环1}";
            string teshuItemStr1 = StringDeal.CutString(templateStr, teshuForBegin1, teshuForEnd1);

            string teshuNewStr1 = "";

            for (int j = 1; j < m_listTable.Count; j++)
            {
                Table table = m_listTable[j];

                if ((templateStr == "Edit.aspx" || templateStr == "Edit.aspx.cs")
                        && (table.Name == "AddTime" || table.Name == "AddID"))
                {
                    continue;
                }


                string tempStr = teshuItemStr1.Replace("{列名}", table.Name);
                tempStr = tempStr.Replace("{表名}", table.TableName);
                tempStr = tempStr.Replace("{首字母大写表名}", StringDeal.HeadUpper(table.TableName));
                tempStr = tempStr.Replace("{首字母小写表名}", StringDeal.HeadLower(table.TableName));

                tempStr = tempStr.Replace("{小写列名}", StringDeal.HeadLower(table.Name));
                tempStr = tempStr.Replace("{列名NET类型}", table.NetType);
                tempStr = tempStr.Replace("{首字母大写列名}", StringDeal.HeadUpper(table.Name));
                tempStr = tempStr.Replace("{列名sql类型}", table.SqlType);
                tempStr = tempStr.Replace("{类型转化字符}", table.ConvertString);

                tempStr = tempStr.Replace("{中文列名}", string.IsNullOrEmpty(table.Brief) ? table.Name : table.Brief);
                FormItem formItem = new FormItem(table);
                tempStr = tempStr.Replace("{表单字符串}", formItem.GetForm());
                tempStr = tempStr.Replace("{更新表单字符串}", formItem.GetUpdateForm());
                tempStr = tempStr.Replace("{添加和更新表单字符串}", formItem.GetServerForm());
                string lieLength = "col-sm-3";
                if (table.EditType == "可视化编辑器" || table.EditType == "上传选择框(upload)" || table.EditType == "进度条上传")
                {
                    lieLength = "col-sm-10";
                }
                tempStr = tempStr.Replace("{列的长度}", lieLength);
                tempStr = tempStr.Replace("{设置值表单字符串}", formItem.GetUpdateSetValue());
                tempStr = tempStr.Replace("{验证字符串}", formItem.GetJs());
                tempStr = tempStr.Replace("{插入验证是否必须}", formItem.GetInsertNecessary());
                tempStr = tempStr.Replace("{更新验证是否必须}", formItem.GetUpdateNecessary());

                if (table.EditType == "上传选择框(upload)" || table.EditType == "进度条上传")
                {
                    tempStr = tempStr.Replace("{文件列表预览函数}", "getFileHtml(");
                    tempStr = tempStr.Replace("{文件列表预览函数结束}", ", \"" + StringDeal.HeadLower(table.Name) + "\", true)");
                }
                else if ((table.EditType == "选择框(select)" || table.EditType == "复选选择框(checkBox)" || table.EditType == "单选选择框(radio)") && table.SelectMember != table.SelectValue)
                {
                    //liexianshi = "GetSelect" + StringDeal.HeadUpper(table.Name) + "(" + liexianshi + ")";
                    tempStr = tempStr.Replace("{文件列表预览函数}", "GetSelect" + StringDeal.HeadUpper(table.Name) + "(");
                    tempStr = tempStr.Replace("{文件列表预览函数结束}", ")");
                }
                else if (table.EditType == "下拉框表关联" || table.EditType == "弹出框表关联")
                {
                    //liexianshi = "GetView" + StringDeal.HeadUpper(table.Name) + "(" + liexianshi + ")";
                    tempStr = tempStr.Replace("{文件列表预览函数}",  "GetView" + StringDeal.HeadUpper(table.Name) + "(");
                    tempStr = tempStr.Replace("{文件列表预览函数结束}", ")");
                }
                else
                {
                    tempStr = tempStr.Replace("{文件列表预览函数}", "");
                    tempStr = tempStr.Replace("{文件列表预览函数结束}", "");
                }
                teshuNewStr1 += tempStr;

            }
            //templateStr = templateStr.Replace("{循环" + i + "}", "");
            //templateStr = templateStr.Replace("{结束循环" + i + "}", "");
            //newStr = "{循环" + i + "}" + newStr + "{结束循环" + i + "}";
            teshuItemStr1 = "{第二列开始循环1}" + teshuItemStr1 + "{结束第二列开始循环1}";
            templateStr = templateStr.Replace(teshuItemStr1, teshuNewStr1);

            #endregion


            #region 处理默认字段不显示循环1
              teshuForBegin1 = "{不显示默认循环1}";
              teshuForEnd1 = "{结束不显示默认循环1}";
              teshuItemStr1 = StringDeal.CutString(templateStr, teshuForBegin1, teshuForEnd1);

              teshuNewStr1 = "";

            for (int j = 1; j < m_listTable.Count; j++)
            {
                Table table = m_listTable[j];
                if   (table.Name == "AddTime" || table.Name == "AddID")
                {
                    continue;
                }


                string tempStr = teshuItemStr1.Replace("{列名}", table.Name);
                tempStr = tempStr.Replace("{表名}", table.TableName);
                tempStr = tempStr.Replace("{首字母大写表名}", StringDeal.HeadUpper(table.TableName));
                tempStr = tempStr.Replace("{首字母小写表名}", StringDeal.HeadLower(table.TableName));

                tempStr = tempStr.Replace("{小写列名}", StringDeal.HeadLower(table.Name));
                tempStr = tempStr.Replace("{列名NET类型}", table.NetType);
                tempStr = tempStr.Replace("{首字母大写列名}", StringDeal.HeadUpper(table.Name));
                tempStr = tempStr.Replace("{列名sql类型}", table.SqlType);
                tempStr = tempStr.Replace("{类型转化字符}", table.ConvertString);

                tempStr = tempStr.Replace("{中文列名}", string.IsNullOrEmpty(table.Brief) ? table.Name : table.Brief);
                FormItem formItem = new FormItem(table);
                tempStr = tempStr.Replace("{表单字符串}", formItem.GetForm());
                tempStr = tempStr.Replace("{更新表单字符串}", formItem.GetUpdateForm());
                tempStr = tempStr.Replace("{添加和更新表单字符串}", formItem.GetServerForm());
                string lieLength = "col-sm-3";
                if (table.EditType == "可视化编辑器" || table.EditType == "上传选择框(upload)" || table.EditType == "进度条上传")
                {
                    lieLength = "col-sm-10";
                }
                tempStr = tempStr.Replace("{列的长度}", lieLength);
                tempStr = tempStr.Replace("{设置值表单字符串}", formItem.GetUpdateSetValue());
                tempStr = tempStr.Replace("{验证字符串}", formItem.GetJs());
                tempStr = tempStr.Replace("{插入验证是否必须}", formItem.GetInsertNecessary());
                tempStr = tempStr.Replace("{更新验证是否必须}", formItem.GetUpdateNecessary());

                teshuNewStr1 += tempStr;

            }
            //templateStr = templateStr.Replace("{循环" + i + "}", "");
            //templateStr = templateStr.Replace("{结束循环" + i + "}", "");
            //newStr = "{循环" + i + "}" + newStr + "{结束循环" + i + "}";
            teshuItemStr1 = "{不显示默认循环1}" + teshuItemStr1 + "{结束不显示默认循环1}";
            templateStr = templateStr.Replace(teshuItemStr1, teshuNewStr1);

            #endregion



            Table table1 = m_listTable[0];
            //TypeUnit oneTypeUnit = TypeDeal.Convert(oneVarData.VarType);
            templateStr = templateStr.Replace("{第一列首字母大写列名}", StringDeal.HeadUpper(table1.Name));
            templateStr = templateStr.Replace("{第一列列名}", table1.Name);
            templateStr = templateStr.Replace("{第一列列名NET类型}", table1.NetType);
            templateStr = templateStr.Replace("{第一列列名sql类型}", table1.SqlType);
            templateStr = templateStr.Replace("{第一列类型转化字符}", table1.ConvertString);
            templateStr = templateStr.Replace("{第一列小写列名}", StringDeal.HeadLower(table1.Name));
            templateStr = templateStr.Replace("{列数+1}", (m_listTable.Count + 1) + "");
            templateStr = templateStr.Replace("{列数+2}", (m_listTable.Count + 2) + "");
            templateStr = templateStr.Replace("{首页列数+1}", (indexCount + 1) + "");
            templateStr = templateStr.Replace("{首页列数+2}", (indexCount + 2) + "");
            templateStr = templateStr.Replace("{首页列数+3}", (indexCount + 3) + "");
            templateStr = templateStr.Replace("{首页列数+4}", (indexCount + 4) + "");

            templateStr = templateStr.Replace("{表名}", table1.TableName);
            templateStr = templateStr.Replace("{中文表名}", string.IsNullOrEmpty(table1.ChineseTableName) ? table1.TableName : table1.ChineseTableName);
            templateStr = templateStr.Replace("{首字母大写表名}", StringDeal.HeadUpper(table1.TableName));
            templateStr = templateStr.Replace("{首字母小写表名}", StringDeal.HeadLower(table1.TableName));
            templateStr = templateStr.Replace("{现在时间}", DateTime.Now.ToString());

            if (m_table.ShenPiID > 0)
            {
                string shenpiStr = "DingDingSpHelper helper = new DingDingSpHelper();\r\n";
                shenpiStr += "new" + StringDeal.HeadUpper(table1.TableName) + "." + StringDeal.HeadUpper(table1.Name) + " = _" + StringDeal.HeadLower(table1.Name) + ";\r\n";
                shenpiStr += "helper.Send(new" + StringDeal.HeadUpper(table1.TableName) + ", TableOperate<TableManage>.GetRowData(new TableManage() { EnglishName = new" + StringDeal.HeadUpper(table1.TableName) + ".GetType().Name }));\r\n";

                templateStr = templateStr.Replace("{添加审批流程}", shenpiStr);
            }
            else
            {
                templateStr = templateStr.Replace("{添加审批流程}", "");
            }


            
            //string ceshi11 = "<%@ Page Language=\"C#\" AutoEventWireup=\"true\" CodeFile=\"Delete.aspx.cs\" Inherits=\"Admin_Manage{首字母大写表名}_Delete\" %>";
            //ceshi11 = ceshi11.Replace("{首字母大写表名}", StringDeal.HeadUpper(table1.TableName));
      
            //templateStr = templateStr.Replace("首字母大写表名", "测测");
            

            string beginStr111 = "{搜索}";
            string endStr111 = "{结束搜索}";
            string delItemStr111 = StringDeal.CutString(templateStr, beginStr111, endStr111);
            if (bSearch)
            {

                templateStr = templateStr.Replace("{搜索}", "");
                templateStr = templateStr.Replace("{结束搜索}", "");
            }
            else
            {
                templateStr = templateStr.Replace(beginStr111 + delItemStr111 + endStr111, "");
            }



            if (bDate)
            {
                templateStr = templateStr.Replace("{日期表单JS}", @"  
<link rel=""stylesheet"" type=""text/css"" media=""all"" href=""../calendar/calendar-win2k-cold-1.css"" title=""win2k-cold-1"" />
<script type=""text/javascript"" src=""../calendar/calendar.js""></script>
<script type=""text/javascript"" src=""../calendar/lang/calendar-zh.js""></script>
<script type=""text/javascript"" src=""../calendar/calendar-setup.js""></script>");
            }
            else
            {
                templateStr = templateStr.Replace("{日期表单JS}", "");
            }


            if (bIndexDate)
            {
                templateStr = templateStr.Replace("{搜索日期表单JS}", @" 
<link rel=""stylesheet"" type=""text/css"" media=""all"" href=""../calendar/calendar-win2k-cold-1.css"" title=""win2k-cold-1"" />
<script type=""text/javascript"" src=""../calendar/calendar.js""></script>
<script type=""text/javascript"" src=""../calendar/lang/calendar-zh.js""></script>
<script type=""text/javascript"" src=""../calendar/calendar-setup.js""></script>");
            }
            else
            {
                templateStr = templateStr.Replace("{搜索日期表单JS}", "");
            }


            if (bEditer)
            {
                templateStr = templateStr.Replace("{可视化编辑器JS}", @"<script type=""text/javascript"" charset=""utf-8"" src=""../../kindeditor/kindeditor.js""></script>");
            }
            else
            {
                templateStr = templateStr.Replace("{可视化编辑器JS}", "");
            }

            if (bUpload)
            {
                templateStr = templateStr.Replace("{进度条上传JS}", @"	
<script type=""text/javascript"" src=""../swfupload/swfupload.js""></script>
<script type=""text/javascript"" src=""../js/handlers.js""></script>
");
            }
            else
            {
                templateStr = templateStr.Replace("{进度条上传JS}", "");
            }


            if (bEditer)
            {
                templateStr = templateStr.Replace("{是否带有可视化编辑器}", " ValidateRequest=\"false\" ");
            }
            else
            {
                templateStr = templateStr.Replace("{是否带有可视化编辑器}", "");
            }



            string beginStr = "{删除右侧,}";
            string endStr = "{结束删除右侧,}";
            string delItemStr = StringDeal.CutString(templateStr, beginStr, endStr);
            string newDelStr = delItemStr.TrimEnd(',', ' ');
            delItemStr = beginStr + delItemStr + endStr;
            templateStr = templateStr.Replace(delItemStr, newDelStr);

            beginStr = "{删除右侧||}";
            endStr = "{结束删除右侧||}";
            delItemStr = StringDeal.CutString(templateStr, beginStr, endStr);
            newDelStr = delItemStr.TrimEnd('|', ' ');
            //newDelStr = delItemStr.TrimEnd('|');
            delItemStr = beginStr + delItemStr + endStr;
            templateStr = templateStr.Replace(delItemStr, newDelStr);
 


            return templateStr;

        }
  
        /// <summary>
        /// 读取数据建立文件
        /// </summary>
        /// <param name="_fileList"></param>
        public void BuildByFiles(string file, string pathRoot, bool bfugai)
        {
            string fileName = pathRoot + "\\Admin\\ManageTableManage\\Template\\" + file + ".bak";
            string buildPath = pathRoot + "\\Admin\\Manage" + StringDeal.HeadUpper(m_table.EnglishName);
            if (!Directory.Exists(buildPath))
            {
                Directory.CreateDirectory(buildPath);
            }
            string newFileName = buildPath + "\\" + file;

            if (File.Exists(newFileName) && !bfugai)
            {
                File.Move(newFileName, newFileName + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak");
            }

            string fileContent = File.ReadAllText(fileName);
            string resultContent = BuildByStr(fileContent);
            File.WriteAllText(newFileName, resultContent, Encoding.UTF8);
        }

        /// <summary>
        /// 生成model文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="pathRoot"></param>
        public void BuildMode(string pathRoot)
        {
            string buildModePath = pathRoot + "\\App_Code\\DataProvider\\Table";
            string newFileName = buildModePath + "\\" + StringDeal.HeadUpper(m_table.EnglishName) + ".cs";
            string fileName = pathRoot + "\\Admin\\ManageTableManage\\Template\\{首字母大写表名}.cs.bak";

            string fileContent = File.ReadAllText(fileName);
            string resultContent = BuildByStr(fileContent);
            File.WriteAllText(newFileName, resultContent, Encoding.UTF8);
        }
        private TypeUnit ConvertType(string sqlTypeWord)
        {
            TypeUnit typeUnit = new TypeUnit();
            switch (sqlTypeWord)  
            {
                #region case
                case "0":
                    typeUnit.NetType = "string";
                    typeUnit.SqlType = "NVarChar";
                    typeUnit.ConvertString = "ToString";
                    break;

                case "1":
                    typeUnit.NetType = "string";
                    typeUnit.SqlType = "NVarChar";
                    typeUnit.ConvertString = "ToString";
                    break;

                case "2":
                    typeUnit.NetType = "int";
                    typeUnit.SqlType = "Int";
                    typeUnit.ConvertString = "ToInt32";
                    break;

                case "3":
                    typeUnit.NetType = "DateTime";
                    typeUnit.SqlType = "DateTime";
                    typeUnit.ConvertString = "ToDateTime";
                    break;

                case "4":
                    typeUnit.NetType = "Boolean";
                    typeUnit.SqlType = "Bit";
                    typeUnit.ConvertString = "ToBoolean";
                    break;

                case "5":
                    typeUnit.NetType = "double";
                    typeUnit.SqlType = "Float";
                    typeUnit.ConvertString = "ToDouble";
                    break;

                case "6":
                    typeUnit.NetType = "double";
                    typeUnit.SqlType = "Float";
                    typeUnit.ConvertString = "ToDouble";
                    break;
                case "7":
                    typeUnit.NetType = "long";
                    typeUnit.SqlType = "BigInt";
                    typeUnit.ConvertString = "ToInt64";
                    break;

                default:
                    typeUnit.NetType = "string";
                    typeUnit.SqlType = "VarChar";
                    typeUnit.ConvertString = "ToString";

                    break;
                #endregion
            }
            return typeUnit;
        }

 

        private string GetEditStr(string sqlTypeWord)
        {
            switch (sqlTypeWord)
            {
                #region case
                case "0":
                    return "文本框(text)";
                case "1":
                    return "密码框(password)";
                case "2":
                    return "单选选择框(radio)";
                case "3":
                    return "复选选择框(checkBox)";

                case "4":
                    return "选择框(select)";

                case "5":
                    return "时间选择框(datetime)";

                case "6":
                    return "上传选择框(upload)";
                case "7":
                    return "文本框(textarea)";
                case "8":
                    return "可视化编辑器";
                case "9":
                    return "进度条上传";
                case "10":
                    return "下拉框表关联";
                case "11":
                    return "弹出框表关联";
                default:
                    return "文本框(text)";
                #endregion
            }
        }



        private TypeUnit ConvertType1(string sqlTypeWord)
        {
            TypeUnit typeUnit = new TypeUnit();
            switch (sqlTypeWord)
            {
                #region case
                case "字符串长度50":
                    typeUnit.NetType = "string";
                    typeUnit.SqlType = "NVarChar";
                    typeUnit.ConvertString = "ToString";
                    break;

                case "字符串不限长度":
                    typeUnit.NetType = "string";
                    typeUnit.SqlType = "NVarChar";
                    typeUnit.ConvertString = "ToString";
                    break;

                case "数字":
                    typeUnit.NetType = "int";
                    typeUnit.SqlType = "Int";
                    typeUnit.ConvertString = "ToInt32";
                    break;

                case "时间":
                    typeUnit.NetType = "DateTime";
                    typeUnit.SqlType = "DateTime";
                    typeUnit.ConvertString = "ToDateTime";
                    break;

                case "布尔型":
                    typeUnit.NetType = "Boolean";
                    typeUnit.SqlType = "Bit";
                    typeUnit.ConvertString = "ToBoolean";
                    break;

                case "float(单精度浮点型)":
                    typeUnit.NetType = "double";
                    typeUnit.SqlType = "Float";
                    typeUnit.ConvertString = "ToDouble";
                    break;

                case "double(双精度浮点型)":
                    typeUnit.NetType = "double";
                    typeUnit.SqlType = "Float";
                    typeUnit.ConvertString = "ToDouble";
                    break;
                case "数字(大)":
                    typeUnit.NetType = "long";
                    typeUnit.SqlType = "BigInt";
                    typeUnit.ConvertString = "ToInt64";
                    break;

                default:
                    typeUnit.NetType = "string";
                    typeUnit.SqlType = "VarChar";
                    typeUnit.ConvertString = "ToString";

                    break;
                #endregion
            }
            return typeUnit;
        }
    }
}
