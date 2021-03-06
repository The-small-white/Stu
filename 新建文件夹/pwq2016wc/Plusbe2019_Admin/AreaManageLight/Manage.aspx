﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="Plusbe2019_Admin_AreaManageLight_Manage" %>
<%@ Import Namespace="Dejun.DataProvider.Table" %>
 <!DOCTYPE html>
<html>

<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title><%=SysConfig.WebTitle %></title>

    <link rel="shortcut icon" href="favicon.ico">
    <link href="<%=SysConfig.Hui %>css/bootstrap.min.css?v=3.3.6" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/font-awesome.css?v=4.4.0" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/plugins/chosen/chosen.css" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/plugins/iCheck/custom.css" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/animate.css" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/style.css?v=4.1.0" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/plugins/iCheck/custom.css" rel="stylesheet">
  

</head>

<body class="gray-bg">
    <div class="wrapper wrapper-content animated fadeInRight">
             <div class="ibox-content">
                        <form role="form" action="Manage.aspx" id="theform1" name="theform1" method="get" class="form-inline">
                            <div class="form-group">
                                <input type="text" placeholder="请输入名称"  name="name" id="name"  runat="server" class="form-control">
                            </div>

                               <div class="form-group">
                                  <select class="chosen-select" name="AreaID" id="AreaID" style="width:180px;">
                                     <option value="0">选择展区名</option>
                                  <asp:Repeater ID="repeater2" runat="server" DataSource="<%#CloudSQL.GetMyArea() %>">
                                            <ItemTemplate>
                                                <option value="<%#((Area)Container.DataItem).ID %>" <%# SysConfig.Selected(((Area)Container.DataItem).ID+"",AreaID+"") %>>
                                                    <%#((Area)Container.DataItem).AreaName %>
                                                </option>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                </select>
                            </div>
                            <button class="btn btn-white" type="submit"><i class="fa fa-search"></i> 搜索</button>
                            <button class="btn btn-white " type="button" id="refresh"><i class="fa fa-refresh"></i> 刷新</button>
                          
                         
                        </form>
                    </div>
     
        <div class="row">
           
            <div class="col-sm-12">
                 
                <div class="ibox float-e-margins">
                    
                    <div class="ibox-content">
                        
                                    <button class="btn btn-success editmySelf"  data-id="0" type="button">添加</button>
                                    <button class="btn btn-danger"  type="button" id="deleteAll">删除</button>
                       <form id="theform" name="theform"  method="post">
                        <table class="table table-bordered table-hover">
                     <thead class="text-c">
                                <tr>    
                                    <th width="8%">
                                         <input type="checkbox" class="i-checks"  id="allcheck">
                                    </th>
                                    <th>序列</th>
                                    <th>名称</th>
                                    <th>IP</th>
                                     <th>端口</th>
                                     <th>第几路</th>
                                     <th>地址码</th>
                                     <th>所属展区</th>
                                   <%-- <th>X坐标</th>
                                     <th>Y坐标</th>--%>
                                     <th>状态</th>
                                     <th>排序</th>
                                     
                                    <th>编辑</th>
                                </tr>
                            </thead>
                            <tbody class="text-c">
                                 <asp:Repeater ID="Repeater1" runat="server" DataSource="<%# m_tableManageList %>">
                                     <ItemTemplate>
                                <tr id="tr_<%# ((View_Light)Container.DataItem).ID%>">
                                    <td> 
                                        <input type="checkbox" class="i-checks" name="checkshop" value="<%#((View_Light)Container.DataItem).ID%>">
                                    </td>
                                    <td><%#Container.ItemIndex+1%></td>
                                   
                                        <td><%# ((View_Light)Container.DataItem).Title%></td>
                                    <td><%# ((View_Light)Container.DataItem).SwitchIP%></td>
                                          <td><%# ((View_Light)Container.DataItem).SwitchPort%></td>
                                          <td><%# ((View_Light)Container.DataItem).SwitchIndex%></td>
                                          <td><%# ((View_Light)Container.DataItem).SwitchGroup%></td>                                       
                                          <td><%# ((View_Light)Container.DataItem).AreaName%></td>
                                        <%-- <td><%# ((View_Light)Container.DataItem).X%></td>
                                         <td><%# ((View_Light)Container.DataItem).Y%></td>--%>





                                          <td><%# GetStates((((View_Light)Container.DataItem).State))%></td>
                                           <td>
                                        <span   data-id="<%#((View_Light)Container.DataItem).ID%>" class=" up glyphicon glyphicon-arrow-up" aria-hidden="true"></span>
                                        <span  data-id="<%#((View_Light)Container.DataItem).ID%>" class=" down glyphicon glyphicon-arrow-down" aria-hidden="true"></span>

                                           </td>
                                    <td class="text-c">
                                            <a href="#" class="btn btn-sm btn-success copymySelf" data-id="<%#((View_Light)Container.DataItem).ID%>"><i class="fa fa-clone"></i> 复制 </a>
                                            <a href="#" class="btn btn-sm btn-info editmySelf" data-id="<%#((View_Light)Container.DataItem).ID%>"><i class="fa fa-pencil"></i> 编辑 </a>
                                            <a href="#" class="btn btn-danger btn-sm deleteSelf" data-id="<%#((View_Light)Container.DataItem).ID%>"><i class="fa fa-remove"></i> 删除 </a>
                                     </td>
                                </tr>
                                 </ItemTemplate>
                                 </asp:Repeater>                     
                            </tbody>
                             <tfoot> <tr><td colspan="15" class="footable-visible"> <%#this.GetPagingHtml() %></td> </tr></tfoot>
                        </table>
                        </form>

                    </div>
                </div>
            </div>
  
        </div>
        
    </div>

    <!-- 全局js -->
    <script src="<%=SysConfig.Hui %>js/jquery.min.js?v=2.1.4"></script>
    <script src="<%=SysConfig.Hui %>js/bootstrap.min.js?v=3.3.6"></script>



    <!-- Peity -->
    <script src="<%=SysConfig.Hui %>js/plugins/peity/jquery.peity.min.js"></script>
          <script src="<%=SysConfig.Hui %>js/plugins/chosen/chosen.jquery.js"></script>
    <!-- 自定义js -->
    <script src="<%=SysConfig.Hui %>js/content.js?v=1.0.0"></script>


    <!-- iCheck -->
    <script src="<%=SysConfig.Hui %>js/plugins/iCheck/icheck.min.js"></script>
      
    <!-- Peity -->
    <script src="<%=SysConfig.Hui %>js/demo/peity-demo.js"></script>
     <script src="<%=SysConfig.Hui %>js/layer-v3.1.1/layer/layer.js"></script>

    <script>
        $(document).ready(function ()
        {      
            $('#AreaID').chosen({
            });
        
            $('.i-checks').iCheck({
                checkboxClass: 'icheckbox_square-green',
                radioClass: 'iradio_square-green',
            });


            $('#allcheck').on('ifChecked', function (event) {
                if ($('#allcheck').is(':checked')) {
                    $("input[name='checkshop']").iCheck('check');
                }
            });

            $('#allcheck').on('ifUnchecked', function (event) {
                if (!$('#allcheck').is(':checked')) {
                    $("input[name='checkshop']").iCheck('uncheck');
                }
            });
        });
        $('#refresh').click(function () {
            location.reload();
        })
        $('.editmySelf').click(function () {
            var $this = $(this);
            var ids = $this.data('id');
            var url = 'edit.aspx?iD=' + $this.data('id');
            if (ids == 0) {
                url = 'edit.aspx';
            }
           
            layer.open({
                type: 2,
                area: ['800px', '600px'],
                title: '添加/编辑',
                fixed: false, //不固定
                maxmin: true,
                content: url
            });
        });
        $('.deleteSelf').click(function () {
            var $this = $(this);
            layer.confirm('确定要删除该信息？', {
                btn: ['确定', '取消'] //按钮
            }, function () {
                    $.post('Delete.aspx', { id: $this.data('id') }, function (result) {
                        if (result.isOk) {
                            layer.msg('删除成功', { icon: 1, time: 1000 });
                            $this.parent().parent().remove();
                        } else {
                            layer.msg('删除失败', { icon: 2, time: 1000 });
                        }
                    });
                });
        });
        $('.copymySelf').click(function () {
            var $this = $(this);
            layer.confirm('确定要复制该信息？', {
                btn: ['确定', '取消'] //按钮
            }, function ()
                {
                    $.post('Copy.aspx', { id: $this.data('id') }, function (result) {
                    if (result.isOk) {
                        layer.msg('复制成功', { icon: 1, time: 1000 });
                        location.reload();
                    } else {
                        layer.msg('复制失败', { icon: 2, time: 1000 });
                    }
                });
            });
        });
        $('#deleteAll').click(function () {
            if ($("input[type='checkbox']:checked").length == 0) {
                layer.msg('请选择删除对象!',function () {
                    //关闭后的操作
                });
                return;
            }
            else {
                layer.confirm('确定要删除该信息？', {
                    btn: ['确定', '取消'] //按钮
                }, function () {
                        var arr = $('#theform').serializeArray();
                        $.post('Delete.aspx', arr, function (result) {
                            if (result.isOk) {
                                layer.msg('删除成功', { icon: 1, time: 1000 });
                                for (var i = 0; i < arr.length; i++) {
                                    if (arr[i].name == 'checkshop') {
                                        $('#tr_' + arr[i].value).remove();
                                    }
                                }
                            } else {
                                layer.msg('删除失败', { icon: 2, time: 1000 });
                            }
                        });
                    });

            }
        });
        $('.up').click(function () {
            var $this = $(this);
            var ids = $this.data('id');

            changeSortOrder("up", ids);
        });
        $('.down').click(function () {
            var $this = $(this);
            var ids = $this.data('id');
            changeSortOrder("down", ids);
        });
        function changeSortOrder(action, id) {
            var actionPath = "ChangeSortOrder.aspx?action=" + action + "&id=" + id + "&areaid=<%=AreaID%>";
            $.ajax({
                type: "post",
                url: actionPath,
                dataType: "html",
                data: "",
                success: function (result) {
                    if (result != "") {
                        var id1 = $("#tr_" + id);
                        var id2 = $("#tr_" + result);
                        if ("up" == action) {
                            id2.before(id1);
                        }
                        else {
                            id1.before(id2);
                        }
                    }
                }
            });
        }

    </script>

  
    <!--统计代码，可删除-->

</body>

</html>

