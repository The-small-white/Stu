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
    <link href="<%=SysConfig.Hui %>css/style.css?v=4.1.0" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/plugins/iCheck/custom.css" rel="stylesheet">

</head>

<body class="gray-bg">
<div class="wrapper wrapper-content animated fadeInRight">
    
    
    <div class="row">
        <div class="col-sm-12">
            <div class="ibox float-e-margins">
                
                <div class="ibox-content">
                    <form method="post" class="form-horizontal"  name="theform" id="theform" action="Edit.aspx">
                        <input name="iD" id="iD" type="hidden" runat="server">
                        <input name="action" value="save" type="hidden" />
                        <div class="form-group">
                            <label class="col-sm-2 control-label">展区名：</label>

                            <div class="col-sm-5">
                                <input type="text" class="form-control required" name="AreaName" data-name="展区名" value="<%#news.AreaName %>"  />
                            </div>
                        </div>
                     
                        <div class="form-group">
                            <label class="col-sm-2 control-label">提示讲解：</label>
                            <div class="col-sm-10">
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
                    parent.layer.msg($(required[i]).data('name') + '不能为空', function () {
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
