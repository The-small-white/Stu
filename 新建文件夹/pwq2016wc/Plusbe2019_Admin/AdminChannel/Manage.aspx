<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="Plusbe2019_Admin_TableManage_Manage" %>
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
    <link href="<%=SysConfig.Hui %>css/plugins/iCheck/custom.css" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/animate.css" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/style.css?v=4.1.0" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/plugins/iCheck/custom.css" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/plugins/treeview/bootstrap-treeview.css" rel="stylesheet">


</head>

<body class="gray-bg">
                    <div class="col-sm-3" style="position: fixed;top: 40px;right: 20px;z-index:2">
                        <h5>执行操作：<label id="outhtml">请选择要操作的对象</label></h5>
                         <input type="hidden" value="0" id="id" />
                        <hr>
                        <div id="event_output">
                        <button class="btn btn-primary addmySelf" type="button"><i class="fa fa-edit"></i>&nbsp;添加</button>
                        <button class="btn btn-info editmySelf" type="button"><i class="fa fa-pencil"></i>&nbsp;编辑</button>
                        <button class="btn btn-danger deleteSelf" type="button"><i class="fa fa-remove"></i>&nbsp;&nbsp;<span class="bold">删除</span></button>
                       <button class="btn btn-warning"  type="button" id="deall">删除全部</button>
                        <button class="btn btn-success news" type="button"><i class="fa fa-bars"></i>&nbsp;&nbsp;<span class="bold">内容</span></button>
                        
                        </div>
                    </div>
    <div class="row wrapper wrapper-content animated fadeInRight">
        <div class="col-sm-12">
          <div class="ibox float-e-margins">
               
                <div class="ibox-content">
                     <div class="col-sm-9">
                    <div id="treeview3" class="test treeview">
                        
                    </div>
                         </div>
                     
                    <div class="clearfix"></div>
                </div>
        
            
            </div>
        </div>
    





    </div>

    <!-- 全局js -->
    <script src="<%=SysConfig.Hui %>js/jquery.min.js?v=2.1.4"></script>
    <script src="<%=SysConfig.Hui %>js/bootstrap.min.js?v=3.3.6"></script>



    <!-- Peity -->
    <script src="<%=SysConfig.Hui %>js/plugins/peity/jquery.peity.min.js"></script>

    <!-- 自定义js -->
    <script src="<%=SysConfig.Hui %>js/content.js?v=1.0.0"></script>


    <!-- iCheck -->
    <script src="<%=SysConfig.Hui %>js/plugins/iCheck/icheck.min.js"></script>

    <!-- Peity -->
    <script src="<%=SysConfig.Hui %>js/demo/peity-demo.js"></script>
     <script src="<%=SysConfig.Hui %>js/layer-v3.1.1/layer/layer.js"></script>
    <script src="<%=SysConfig.Hui %>js/plugins/treeview/bootstrap-treeview.js"></script>
   <%-- <script src="<%=SysConfig.Hui %>js/demo/treeview-demo.js"></script>--%>

    <script>
        $(document).ready(function ()
        {
            GetTree();
   
        });
        function GetTree() {
            $.ajax({
                url: "TreeApi.aspx",
                type: "post",
                contentType: "application/json",
                timeout: 3000, //超时时间：30秒
                async: false,//false-同步（当这个ajax执行完后才会继续执行其他代码）；异步-与其他代码互不影响，一起运行。
                dataType: "json",
                success: function (data) {
                    $('#treeview3').treeview({
                        levels: 1,
                        color: "#428bca",
                        data: data,
                        onNodeSelected: function (event, node) {
                            $('#outhtml').html('当前选中的ID为 ' + node.id + ',名称为：' + node.text);
                            $('#id').val(node.id); 
                        }
                    });
                    tree = data;
                }, error: function (data) {
                    console.log(data);
                }
            });
        }
        $('.addmySelf').click(function ()
        {
            var $this = $(this);
            var ids = $('#id').val();
            layer.open({
                type: 2,
                area: ['800px', '600px'],
                title: '添加/编辑',
                fixed: false, //不固定
                maxmin: true,
                content: 'edit.aspx?pid=' + ids
            });
            
        })
        $('.editmySelf').click(function () {
            var $this = $(this);
            var ids = $('#id').val();
            var url = 'edit.aspx?iD=' + ids;
            if (ids == 0) {
                layer.msg('请选择编辑对象!', function () {
                    //关闭后的操作
                });
            }
            else {
                layer.open({
                    type: 2,
                    area: ['800px', '600px'],
                    title: '添加/编辑',
                    fixed: false, //不固定
                    maxmin: true,
                    content: url
                });
            }
        });
        $('.news').click(function () {
            var $this = $(this);
            var ids = $('#id').val();
            
            if (ids == 0) {
                layer.msg('请选择编辑对象!', function () {
                    //关闭后的操作
                });
            }
            else {
                location.href = '../channlnew/manage.aspx?pcid=' + ids;
            }
        });
        $('.deleteSelf').click(function ()
        {
            var ids = $('#id').val();
            if (ids == 0) {
                layer.msg('请选择删除对象!', function () {
                    //关闭后的操作
                });
                return false;
            }
            layer.confirm('确定要删除该信息？', {
                btn: ['确定', '取消'] //按钮
            }, function ()
                {
                    $.post('Delete.aspx', { id: ids }, function (result) {
                    if (result.isOk) {
                        layer.msg('删除成功', { icon: 1, time: 1000 });
                        GetTree(); $('#id').val(0)
                    } else {
                        layer.msg('删除失败', { icon: 2, time: 1000 });
                    }
                });
            });
        });

       $('#deall').click(function () {
            var $this = $(this);
            layer.confirm('确定要删除全部信息？', {
                btn: ['确定', '取消'] //按钮
            }, function () {
                    $.post('Delete.aspx', { all: 1 }, function (result) {
                        if (result.isOk) {
                            layer.msg('删除成功', { icon: 1, time: 1000 });
                            location.reload();
                        } else {
                            layer.msg('删除失败', { icon: 2, time: 1000 });
                        }
                    });
                });
        });
     

    </script>

  
    <!--统计代码，可删除-->

</body>

</html>

