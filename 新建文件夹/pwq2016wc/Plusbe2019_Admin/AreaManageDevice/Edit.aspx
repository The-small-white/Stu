<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Plusbe2019_Admin_AreaManageDevice_Edit" %>

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
    <link href="<%=SysConfig.Hui %>css/style.css?v=4.1.0" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/plugins/iCheck/custom.css" rel="stylesheet">
    <script>
   function changeRoom(obj) {

            $.post("ajax.aspx", { id: obj.value },
                function (data) {
                    if (data != "0") {
                        // alert(data);
                        $("#AreID").html(data);
                    }
                });
        }

     window.onload = function () {
            var arid = '<%#news.AreaID%>';
            $("#AreID  option[value='" + arid + "'] ").attr("selected", true)
        }
 function changeDeviceType(obj) {
            if (obj == 1) {
                //继电器。
                $(".JDQ").show();
                $(".TYJ").hide();
                $(".TYJ1").hide();
                $(".PC").hide();
                $(".PC1").hide();

            } else if (obj == 2) {
                //PC电脑
                $(".PC").show();
                $(".PC1").show();
                $(".JDQ").hide();
                $(".TYJ").hide();
                $(".TYJ1").hide();
            } else if (obj == 3) {
                $(".JDQ").show();
                $(".TYJ").hide();
                $(".TYJ1").hide();
                $(".PC").hide();
                $(".PC1").hide();

            } else if (obj == 4) {
                //投影仪
                $(".PC").show();
                $(".PC1").hide();
                $(".TYJ1").show();
                $(".TYJ").hide();
                $(".JDQ").hide();
            } else if (obj == 5) {
                //自定义投影仪
                $(".PC").show();
                $(".JDQ").hide();
                $(".PC1").hide();
                $(".TYJ").show();
                $(".TYJ1").hide();

            }
            else if (obj == 6) {
                //pjlink
                $(".PC").show();
                $(".PC1").hide();
                $(".JDQ").hide();
                $(".TYJ").hide();
                $(".TYJ1").hide();

            }
            else if (obj == 7) {
                //自定义

                $(".PC").show();
                $(".JDQ").hide();
                $(".PC1").hide();
                $(".TYJ").show();
                $(".TYJ1").hide();
            }

}
 function CheckHide() {
            var dtype = <%#news.DeviceType%>;
            changeDeviceType(dtype);
        }
    </script>
</head>
    

<body onload="CheckHide()">
    <div class="wrapper wrapper-content animated fadeInRight">


        <div class="row">
            <div class="col-sm-12">
                <div class="ibox float-e-margins">

                    <div class="ibox-content">
                        <form name="theform" id="theform" class="form-horizontal" method="post" role="form" action="edit.aspx" onsubmit="return CheckForm();">
                            <input name="iD" id="iD" type="hidden" runat="server">
                            <input name="typeid" value="<%#TypeID %>" type="hidden" />
                            <input name="action" value="save" type="hidden" />
                            <div class="form-group">
                                <label class="col-sm-2 control-label">名称：</label>

                                <div class="col-sm-5">
                                    <input type="text" class="form-control required" name="Name" value="<%#news.Name %>" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-2 control-label">设备类型：</label>

                                <div class="col-sm-5">
                                    <select class="form-control" name="deviceType" id="deviceType" runat="server" onchange="changeDeviceType(this.value)">
                                                <option value="">--请选择--</option>
                                                <option value="1">继电器开关</option>
                                                <option value="2">PC电脑</option>
                                                <option value="3">电脑改装开关</option>
                                                <option value="4">投影仪</option>
                                                <option value="5">自定义投影仪</option>
                                                <option value="6">投影仪PJLink</option>
                                                <option value="7">其他</option>
                                            </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-2 control-label">开启次数:</label>

                                <div class="col-sm-5">
                                    <input type="number" class="form-control " name="OpenCount" value="<%#news.OpenCount %>" />
                                </div>
                            </div>
                            
                             <div class="form-group PC2">
                                <label class="col-sm-2 control-label">设备ip地址：</label>

                                <div class="col-sm-5">                             
                                        <input type="text" class="form-control" name="Ip" value="<%#news.Ip %>" />
                                </div>
                            </div>

                             <div class="form-group PC">
                                <label class="col-sm-2 control-label">端口号：</label>

                                <div class="col-sm-5">
                                    <input type="number" class="form-control" name="Port" value="<%#news.Port %>" />
                                </div>
                            </div>

                             <div class="form-group PC1">
                                <label class="col-sm-2 control-label">Mac地址：</label>

                                <div class="col-sm-5">
                                    <input type="text" class="form-control" name="Mac" value="<%#news.Mac %>" />
                                </div>
                            </div>

                          <%--  <div class="form-group">
                                <label class="col-sm-2 control-label">X坐标：</label>

                                <div class="col-sm-5">
                                    <input type="number" class="form-control required" name="X" value="<%#news.X %>" />
                                </div>
                            </div>

                             <div class="form-group">
                                <label class="col-sm-2 control-label">Y坐标：</label>

                                <div class="col-sm-5">
                                    <input type="number" class="form-control required" name="Y" value="<%#news.Y %>" />
                                </div>
                            </div>--%>




                     

                                 <div class="form-group TYJ1">
                                <label class="col-sm-2 control-label">投影机类型：</label>
                                <div class="col-sm-5">

                                    <select class="chosen-select" name="projectorType" id="projectorType">

                                        <asp:Repeater ID="repeater1" runat="server" DataSource="<%#projectorList%>">
                                            <ItemTemplate>
                                                  <option <%#SetSelected(((Projector)Container.DataItem).ID + "",news.ProjectorType+"") %> value="<%#((Projector)Container.DataItem).ID %>"><%#((Projector)Container.DataItem).Name %></option>

                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </select>
                                </div>
                            </div>
                                  <div class="form-group JDQ">
                                <label class="col-sm-2 control-label">电源控制IP：</label>

                                <div class="col-sm-5">
                                    <input type="text" class="form-control " name="SwitchIP" value="<%#news.SwitchIP %>" />
                                </div>
                            </div>

                              <div class="form-group JDQ">
                                <label class="col-sm-2 control-label">电源控制端口：</label>

                                <div class="col-sm-5">
                                    <input type="number" class="form-control " name="SwitchPort" value="<%#news.SwitchPort %>" />
                                </div>
                            </div>

                               <div class="form-group JDQ">
                                <label class="col-sm-2 control-label">电源控制编号：</label>

                                <div class="col-sm-5">
                                    <input type="number" class="form-control " name="SwitchIndex" value="<%#news.SwitchIndex %>" />
                                </div>
                            </div>

                              <div class="form-group JDQ">
                                <label class="col-sm-2 control-label">电源控制组编号：</label>

                                <div class="col-sm-5">
                                    <input type="number" class="form-control " name="SwitchGroup" value="<%#news.SwitchGroup %>" />
                                </div>
                            </div>

                                 <div class="form-group" style="display: none">
                                <label class="col-sm-2 control-label">延时启动时间：</label>

                                <div class="col-sm-5">
                                    <input type="text" class="form-control " name="SwitchTime" value="<%#news.SwitchTime %>" />
                                </div>
                            </div>

                                 <%-- 投影仪协议部分--%>
                                <div class="form-group TYJ">
                                <label class="col-sm-2 control-label">协议类型：</label>
                                <div class="col-sm-5">
                                    <select class="chosen-select" name="protocol" id="protocol" style="width: 280px;" runat="server">
                                                <option value="0">TCP</option>
                                                <option value="1">UDP</option>   
                                                <option value="2">HTTP</option>  
                                    </select>
                                </div>
                            </div>

                                   <div class="form-group TYJ">
                                <label class="col-sm-2 control-label">打开协议代码：</label>
                                      <div class="col-sm-5">
                                            <input type="text" class="form-control" name="openProtocol" id="openProtocol" value="<%#news.OpenProtocol %>">
                                        </div>
                                <div class="col-sm-5">
                                     <span class="TYJ" style="float: left; display: inline-block; line-height: 34px;">字符串格式</span>
                                       <div class="col-sm-1 TYJ">
                                    <select class="chosen-select" name="charType" id="charType" style="width: 180px;" runat="server">
                                                <option value="0">16进制</option>
                                                <option value="1">字符串</option>   
                                                <option value="2">2进制</option>  
                                    </select>
                                           </div>
                                </div>
                            </div>

                               <div class="form-group TYJ">
                                <label class="col-sm-2 control-label">关闭协议代码：</label>

                                <div class="col-sm-5">
                                    <input type="text" class="form-control " name="closeProtocol" value="<%#news.CloseProtocol %>" />
                                </div>
                            </div>

                                 <div class="form-group TYJ">
                                <label class="col-sm-2 control-label">查询协议代码：</label>

                                <div class="col-sm-5">
                                    <input type="text" class="form-control " name="QueryProtocol" value="<%#news.QueryProtocol %>" />
                                </div>
                            </div>
                                <div class="form-group TYJ">
                                <label class="col-sm-2 control-label">回传开启代码：</label>
                                      <div class="col-sm-5">
                                            <input type="text" class="form-control" name="queryOpen" id="queryOpen" value="<%#news.QueryOpen %>">
                                        </div>
                                <div class="col-sm-3">
                                     <span class="TYJ" style="float: left; display: inline-block; line-height: 34px;">字符串格式</span>
                                       <div class="col-sm-1 TYJ">
                                    <select class="chosen-select" name="reCharType" id="reCharType" style="width: 180px;" runat="server">
                                                <option value="0">16进制</option>
                                                <option value="1">字符串</option>   
                                                <option value="2">2进制</option>  
                                    </select>
                                           </div>
                                </div>
                            </div>
                                   <div class="form-group TYJ">
                                <label class="col-sm-2 control-label">回传关闭代码：</label>

                                <div class="col-sm-5">
                                    <input type="text" class="form-control " name="QueryClose" value="<%#news.QueryClose %>" />
                                </div>
                            </div>              
                          
                            <div class="form-group">
                                <label class="col-sm-2 control-label">所属展区：</label>
                                <div class="col-sm-10">

                                    <select class="chosen-select" name="AreaID" id="AreaID" style="width: 180px;">

                                        <asp:Repeater ID="repeater" runat="server" DataSource="<%#CloudSQL.GetMyArea() %>">
                                            <ItemTemplate>
                                                <option value="<%#((Area)Container.DataItem).ID %>" <%# SysConfig.Selected(((Area)Container.DataItem).ID+"",news.AreaID+"") %>>
                                                    <%#((Area)Container.DataItem).AreaName %>
                                                </option>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-2 control-label">状态：</label>

                                <div class="col-sm-5">
                                    <select class="chosen-select" name="State" id="State" style="width: 180px;" runat="server">
                                                <option value="1">启用</option>
                                                <option value="0">停用</option>                                    
                                    </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-2 control-label">备注：</label>
                                <div class="col-sm-10">
                                    <textarea name="brief" class="form-control" aria-required="true"><%#news.Brief %></textarea>
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
        $('#deviceType').chosen({
            disable_search_threshold: 10,
            disable_search: true
        });

 $('#projectorType').chosen({
            disable_search_threshold: 10,
            disable_search: true
        });

 $('#protocol').chosen({
            disable_search_threshold: 10,
            disable_search: true
        });

 $('#charType').chosen({
            disable_search_threshold: 10,
            disable_search: true
        });

 $('#reCharType').chosen({
            disable_search_threshold: 10,
            disable_search: true
        });

 $('#AreaID').chosen({
            disable_search_threshold: 10,
            disable_search: true
        });

 $('#State').chosen({
            disable_search_threshold: 10,
            disable_search: true
        });
        var index = parent.layer.getFrameIndex(window.name); 
        $(".i-checks").iCheck({ checkboxClass: "icheckbox_square-green", radioClass: "iradio_square-green", })
        $("#closeIframe").click(function () {
            parent.layer.close(index);
        });
       
        $("#post").click(function ()
        {
            var required = $('.required');
            for (var i = 0; i < required.length; i++) {
                if (!$(required[i]).val()) {
                    $(required[i]).focus();
                    parent.layer.msg('该项不能为空', function () {
                        //关闭后的操作
                    });
                    return false;
                }
            }
            $.post('edit.aspx', $('#theform').serialize(), function (result) {
                if (!result.isOk)
                {
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
