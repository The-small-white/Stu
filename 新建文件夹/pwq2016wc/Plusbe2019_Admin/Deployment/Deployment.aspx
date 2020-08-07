<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Deployment.aspx.cs" Inherits="Plusbe2019_Admin_WebSiteSet" %>

<!DOCTYPE html>
<html>

<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title><%=SysConfig.WebTitle %></title>
    <link rel="shortcut icon" href="<%=SysConfig.Hui %>favicon.ico">
    <link href="<%=SysConfig.Hui %>css/bootstrap.min.css?v=3.3.6" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/font-awesome.css?v=4.4.0" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/animate.css" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/plugins/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/style.css?v=4.1.0" rel="stylesheet">

</head>

<body class="gray-bg">
    <div class="wrapper wrapper-content">

        <div class="row">
            <div class="col-sm-5">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>部署初始化</h5>

                    </div>
                    <div class="ibox-content">
                        <div class="alert alert-info">
                            非开发人员勿动！！！！！！
                        </div>
               
                            <div class="form-group draggable">
                                <div class="col-sm-12 col-sm-offset-3">
                                    <button class="btn btn-primary" type="button"  id="del">清理滞留数据</button>

                                </div>
                            </div>
                        
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>

        </div>

    </div>

    <!-- 全局js -->
    <script src="<%=SysConfig.Hui %>js/jquery.min.js?v=2.1.4"></script>
    <script src="<%=SysConfig.Hui %>js/bootstrap.min.js?v=3.3.6"></script>

    <!-- 自定义js -->
    <script src="<%=SysConfig.Hui %>js/content.js?v=1.0.0"></script>

    <script src="<%=SysConfig.Hui %>js/layer-v3.1.1/layer/layer.js"></script>
    <script>
        $('#del').click(function () {
            layer.confirm('确定要部署初始化(数据清除！！！)？', {
                btn: ['确定', '取消'] //按钮
            }, function () {
                    $.post('DeployDel.aspx', { id: -1 }, function (result)
                    {
                        
                        if (result=="1")
                        {
                            layer.msg('初始化成功', { icon: 1, time: 1000 });
                        } else {
                            layer.msg('初始化失败', { icon: 2, time: 1000 });
                        }
                    });
                });
        });

    </script>
  

    <!--统计代码，可删除-->
</body>

</html>

