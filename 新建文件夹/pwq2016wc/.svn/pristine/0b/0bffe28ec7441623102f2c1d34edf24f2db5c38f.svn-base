<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Plusbe2019_Admin_TableManage_Edit" %>
<%@ Import Namespace="Dejun.DataProvider.Table" %>
<!DOCTYPE html>
<html>

<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title><%=SysConfig.WebTitle %></title>
    <link rel="shortcut icon" href="<%=SysConfig.Hui %>favicon.ico"> 
    <link href="<%=SysConfig.Hui %>css/bootstrap.min.css?v=3.3.6" rel="stylesheet">
     <link href="<%=SysConfig.Hui %>css/plugins/chosen/chosen.css" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/font-awesome.css?v=4.4.0" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/plugins/iCheck/custom.css" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/animate.css" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/plugins/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/style.css?v=4.1.0" rel="stylesheet">
   

</head>

<body class="gray-bg">
<div class="wrapper wrapper-content animated fadeInRight">
    
    
    <div class="row">
        <div class="col-sm-12">
            <div class="ibox float-e-margins">
                
                <div class="ibox-content">
                    <form method="post" class="form-horizontal"  name="theform" id="theform" action="Edit.aspx" onsubmit="return false;">
                        <input name="iD" id="iD" type="hidden" runat="server">
                        <input name="action" value="save" type="hidden" />
                        <input type="hidden" value="<%#news.Pass %>" name="oldpass" />
                        <div class="form-group">
                            <label class="col-sm-2 control-label">用户名：</label>

                            <div class="col-sm-5">
                                <input type="text" class="form-control required"  name="name" data-name="用户名"   <%#news.ID!=0?"readonly":"" %>  value="<%#news.Name %>"  />
                            </div>
                        </div>
                      
                        <div class="form-group">
                            <label class="col-sm-2 control-label">密码：</label>
                            <div class="col-sm-5">
                                <input type="password" class="form-control" name="pass" id="pass" value="">
                                <span class="help-block m-b-none"><i class="fa fa-info-circle"></i> 必须包含大小写字母、数字、特称字符，至少8个字符。</span>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">重新输入密码：</label>
                            <div class="col-sm-5">
                                <input type="password" class="form-control" id="repass" value="">
                                <span class="help-block m-b-none"><i class="fa fa-info-circle"></i> 请再次输入您的密码</span>
                            </div>
                        </div>
                    <div class="form-group">
                            <label class="col-sm-2 control-label">姓名：</label>
                            <div class="col-sm-5">
                                <input type="text" class="form-control required" data-name="姓名"  name="fullname" value="<%#news.FullName %>">
                                <span class="help-block m-b-none"></span>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">个人信息：</label>
                            <div class="col-sm-8">
                               <div class="row">
                                        <div class="col-md-4">
                                            <input type="email"  class="form-control required" data-name="邮箱" name="email"  value="<%#news.Email %>">
                                            <span class="help-block m-b-none"><i class="fa fa-info-circle"></i> 请输入邮箱</span>
                                        </div>
                                        <div class="col-md-4">
                                            <input type="text"  class="form-control required" data-name="手机号"  name="phone" value="<%#news.Phone %>">
                                             <span class="help-block m-b-none"><i class="fa fa-info-circle"></i> 请输入手机号</span>
                                        </div>
                                        <div class="col-md-4">
                                            <input type="text"  class="form-control required"  data-name="职位名称" name="jobTitle" value="<%#news.JobTitle %>">
                                             <span class="help-block m-b-none"><i class="fa fa-info-circle"></i> 请输入职位名称</span>
                                        </div>
                                    </div>
                            </div>
                        </div>
                          <div class="form-group">
                            <label class="col-sm-2 control-label">地址：</label>
                            <div class="col-sm-5">
                                <textarea  name="address" class="form-control"  aria-required="true"><%#news.Address %></textarea>
                                <span class="help-block m-b-none"></span>
                            </div>
                        </div>
                       <%if (MyID != -1)
                               {%>
                         <div class="form-group">
                            <label class="col-sm-2 control-label">管理员等级：</label>
                            <div class="col-sm-10">
                               
                                 <select class="chosen-select" name="UserLevel"  id="UserLevel"    style="width:180px;" >
                                    <%if (AdminMethod.AdminLevel == 2)
                                        { %>
                                  <option value="2" <%# SysConfig.Selected(news.UserLevel,2)%>>超级管理员</option>
                                      <%} %>
                                    <%if (AdminMethod.AdminLevel >0)
                                        { %>
                                   <option value="1" <%#SysConfig.Selected(news.UserLevel,1)%> >展厅管理员</option>
                                   <option value="0"<%#SysConfig.Selected(news.UserLevel,0)%>>普通管理</option>
                                     <%} %>
                                     
                                </select>
                            </div>
                        </div>
                         <div class="form-group">
                            <label class="col-sm-2 control-label">账号状态：</label>
                            <div class="col-sm-10">
                               
                                 <select class="chosen-select " name="states"    id="states" style="width:180px;" runat="server">
                                   <option value="1">正常</option>
                                   <option value="0">锁定</option>
                                </select>
                            </div>
                        </div>
                        <%if (AdminMethod.AdminLevel > 0)
                            { %>
                         <div class="form-group">
                            <label class="col-sm-2 control-label">所属展厅：</label>
                            <div class="col-sm-10">
                               
                                  <select class="chosen-select" name="ExhibitionID"    id="ExhibitionID" style="width:180px;">
                                   
                                     <asp:Repeater ID="repeater" runat="server" DataSource="<%#m_ExhibitionList %>">
                                       <ItemTemplate>
                                     <option  value="<%#((Exhibition)Container.DataItem).ID %>" <%# SysConfig.Selected(((Exhibition)Container.DataItem).ID+"",news.ExhibitionID+"") %> <%# ((Exhibition)Container.DataItem).Child?"disabled":""%>>
                                         <%# ExhibitionProvider.GetDepth(((Exhibition)Container.DataItem).Depth)%>
                                         <%#((Exhibition)Container.DataItem).Name %>
                                     </option>
                                      </ItemTemplate>
                                       </asp:Repeater>
                                </select>
                            </div>
                        </div>
                          <%} %>
                        <%if (AdminMethod.CheckManage("quanxian"))
                            { %>
                        <div class="form-group">
                             <label class="col-sm-2 control-label">权限设置</label>
                            <div class="col-sm-10">
                                  <div class="checkbox checkbox-inline">
                                        <input type="checkbox" id="inlineCheckbox" name="manage" value="kuangjia" <%=SysConfig.SetCheckedMore(news.Manage, "kuangjia") %>>
                                        <label for="inlineCheckbox"> 展厅架构 </label>
                                    </div>
                                    <div class="checkbox checkbox-inline">
                                        <input type="checkbox" id="inlineCheckbox7" name="manage" value="zhiyuan" <%=SysConfig.SetCheckedMore(news.Manage, "zhiyuan") %>>
                                        <label for="inlineCheckbox7"> 资源池 </label>
                                    </div>
                            <div class="checkbox checkbox-inline">
                                        <input type="checkbox" id="inlineCheckbox1" name="manage" value="cloud" <%=SysConfig.SetCheckedMore(news.Manage, "cloud") %>>
                                        <label for="inlineCheckbox1"> 资源池管理 </label>
                                    </div>
                                    <div class="checkbox checkbox-inline">
                                        <input type="checkbox" id="inlineCheckbox2" name="manage" value="face" <%=SysConfig.SetCheckedMore(news.Manage, "face") %> />
                                        <label for="inlineCheckbox2"> 人脸识别 </label>
                                    </div>
                                    <div class="checkbox checkbox-inline">
                                        <input type="checkbox" id="inlineCheckbox3" name="manage" value="tag" <%=SysConfig.SetCheckedMore(news.Manage, "tag") %>>
                                        <label for="inlineCheckbox3"> 资源标签 </label>
                                    </div>
                                 <div class="checkbox checkbox-inline">
                                        <input type="checkbox" id="inlineCheckbox4" name="manage" value="yuyin" <%=SysConfig.SetCheckedMore(news.Manage, "yuyin") %>>
                                        <label for="inlineCheckbox4"> 语音识别 </label>
                                    </div>
                                 <div class="checkbox checkbox-inline">
                                        <input type="checkbox" id="inlineCheckbox5" name="manage" value="zk" <%=SysConfig.SetCheckedMore(news.Manage, "zk") %>>
                                        <label for="inlineCheckbox5"> 设备中控 </label>
                                    </div>
                                 <div class="checkbox checkbox-inline">
                                        <input type="checkbox" id="inlineCheckbox10" name="manage" value="yuyue" <%=SysConfig.SetCheckedMore(news.Manage, "yuyue") %>>
                                        <label for="inlineCheckbox10"> 预约 </label>
                                    </div>
                                 <div class="checkbox checkbox-inline">
                                        <input type="checkbox" id="inlineCheckbox6" name="manage" value="set" <%=SysConfig.SetCheckedMore(news.Manage, "set") %>>
                                        <label for="inlineCheckbox6"> 平台管理 </label>
                                    </div>
                              <div class="checkbox checkbox-inline">
                                        <input type="checkbox" id="inlineCheckbox8" name="manage" value="quanxian" <%=SysConfig.SetCheckedMore(news.Manage, "quanxian") %>>
                                        <label for="inlineCheckbox8"> 权限设置 </label>
                                    </div>
                                <div class="checkbox checkbox-inline">
                                        <input type="checkbox" id="inlineCheckbox9" name="manage" value="sys" <%=SysConfig.SetCheckedMore(news.Manage, "sys") %>>
                                        <label for="inlineCheckbox9"> 系统管理 </label>
                                    </div>
                                <div class="checkbox checkbox-inline">
                                        <input type="checkbox" id="inlineCheckbox11" name="manage" value="answer" <%=SysConfig.SetCheckedMore(news.Manage, "answer") %>>
                                        <label for="inlineCheckbox11"> 题库管理 </label>
                                    </div>
                                 <div class="checkbox checkbox-inline">
                                        <input type="checkbox" id="inlineCheckbox12" name="manage" value="ibeacon" <%=SysConfig.SetCheckedMore(news.Manage, "ibeacon") %>>
                                        <label for="inlineCheckbox12"> 蓝牙定位 </label>
                                    </div>
                                 <div class="checkbox checkbox-inline">
                                        <input type="checkbox" id="inlineCheckbox13" name="manage" value="u3d" <%=SysConfig.SetCheckedMore(news.Manage, "u3d") %>>
                                        <label for="inlineCheckbox13"> U3D </label>
                                    </div>
                                </div>
                        
                               
                        </div>
                        <%} %>
                      
                        <%} %>
                            <div class="form-group">
                            <label class="col-sm-2 control-label">备注</label>
                            <div class="col-sm-5">
                               <textarea  name="brief" class="form-control"  aria-required="true"><%#news.Brief %></textarea>
                                <span class="help-block m-b-none"></span>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-4 col-sm-offset-2">
                                <button class="btn btn-primary" type="button" id="post"><i class="fa fa-check"></i>&nbsp;提交</button>
                                <button class="btn btn-white" type="button" id="closeIframe"><i class="fa fa-close"></i>&nbsp;取消</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</div>


    <script src="<%=SysConfig.Hui %>js/jquery.min.js?v=2.1.4"></script>
    <script src="<%=SysConfig.Hui %>js/bootstrap.min.js?v=3.3.6"></script>
    <!-- Peity -->
    <script src="<%=SysConfig.Hui %>js/plugins/peity/jquery.peity.min.js"></script>

    <!-- 自定义js -->
    <script src="<%=SysConfig.Hui %>js/content.js?v=1.0.0"></script>
    <script src="<%=SysConfig.Hui %>js/plugins/chosen/chosen.jquery.js"></script>

    <!-- iCheck -->
    <script src="<%=SysConfig.Hui %>js/plugins/iCheck/icheck.min.js"></script>

    <!-- Peity -->
    <script src="<%=SysConfig.Hui %>js/demo/peity-demo.js"></script>
     <script src="<%=SysConfig.Hui %>js/layer-v3.1.1/layer/layer.js"></script>
    
<script>
    $(document).ready(function ()
    {
        
        $('#UserLevel').chosen({
            disable_search_threshold: 10,
            disable_search: true
        });
        $('#states').chosen({
            disable_search_threshold: 10,
            disable_search: true
        });
        $('#ExhibitionID').chosen({
            
            
        });

        var index = parent.layer.getFrameIndex(window.name); 
        $(".i-checks").iCheck({ checkboxClass: "icheckbox_square-green", radioClass: "iradio_square-green", })
        $("#closeIframe").click(function () {
            parent.layer.close(index);
        });
       
        $("#post").click(function ()
        {
            if ($("#pass").val() != "")
            {
                if ($("#pass").val() != $("#repass").val())
                {
                    parent.layer.msg('两次输入的密码不一致请重新输入', function () {
                        //关闭后的操作
                    });
                   return false;
                }
                var pwdRegex = new RegExp('(?=.*[0-9])(?=.*[A-Z])(?=.*[a-z])(?=.*[^a-zA-Z0-9]).{8,30}');

                if (!pwdRegex.test($("#pass").val())) {
                    parent.layer.msg('您的密码复杂度太低（密码中必须包含大小写字母、数字、特殊字符），请及时修改密码！', function () {
                        //关闭后的操作
                    });
                    return false;
                }
            }
            
            var required = $('.required');
            for (var i = 0; i < required.length; i++) {
                if (!$(required[i]).val()) {
                    $(required[i]).focus();
                    parent.layer.msg($(required[i]).data('name') + '不能为空', function () {
                        //关闭后的操作
                    });
                    return false;
                }
            }
            $.post('edit.aspx', $('#theform').serialize(), function (result) {
                if (!result.isOk) {
                    parent.layer.msg(result.msg,{time:2000});
                }
                else {
                    parent.layer.msg(result.msg, {
                        icon: 1,
                        time: 1000 //2秒关闭（如果不配置，默认是3秒）
                    }, function ()
                    {
                        parent.layer.close(index);
                        parent.location.reload();
                        
                    });

                }
            });
        })
        

    });
</script>

</body>

</html>
