<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Plusbe2019_Admin_login" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0">

    <title><%=SysConfig.WebTitle %></title>
    <link rel="shortcut icon" href="<%=SysConfig.Hui %>favicon.ico"> 
    <link href="<%=SysConfig.Hui %>css/bootstrap.min.css" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/font-awesome.css?v=4.4.0" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/animate.css" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/style.css" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/login.css" rel="stylesheet">
    <script src="<%=SysConfig.Hui %>js/jquery.min.js"></script>
    <script src="<%=SysConfig.Hui %>js/layer-v3.1.1/layer/layer.js"></script>
    <!--[if lt IE 9]>
    <meta http-equiv="refresh" content="0;ie.html" />
    <![endif]-->
    <script>
        if (window.top !== window.self) {
            window.top.location = window.location;
        }
    </script>
    <style>
	.bar {
		height: 34px;
		width: 235px;
	}
    </style>
    <script>/*@cc_on window.location.href="https://support.dmeng.net/upgrade-your-browser.html?referrer="+encodeURIComponent(window.location.href); @*/</script>
</head>

<body class="signin">
    <div class="signinpanel">
        <div class="row">
            <div class="col-sm-7">
                <div class="signin-info">
                    <div class="logopanel m-b">
                        <h1>[ PlusbeCloud ]</h1>
                    </div>
                    <div class="m-b"></div>
                    <h4>欢迎使用 <strong>Plusbe云平台</strong></h4>
                   
                   
                </div>
            </div>
            <div class="col-sm-5">
                <form method="post" action="login.aspx"  id="theform" runat="server" onsubmit="return false;">
                    <input name="action" value="save" type="hidden" /> 
                    <h4 class="no-margins">登录</h4>
                    <p class="m-t-md">登录到云平台后台</p>
                    <input type="text" class="form-control uname required" name="username" data-name="用户名" placeholder="用户名"  />
                    <input type="password" class="form-control pword m-b required" name="usermima" AUTOCOMPLETE="off" data-name="密码" placeholder="密码" />
	                <button type="button" id="code" class="btn btn-block btn-outline btn-primary">点击验证</button>
                    <button id="login" class="btn btn-success btn-block" >登录</button>
                </form>
               
            </div>
        </div>
        <div class="signup-footer">
            <div class="pull-left">
                版权所有权：杭州向正科技有限公司&copy; 2019 All Rights Reserved
            </div>
        </div>
    </div>
    <script>
        $("#code").click(
            function () {
                layer.open({
                    type: 2,
                    title: false,
                    area: ['315px', '248px'],
                    shade: 0.8,
                    closeBtn: 0,
                    shadeClose: true,
                    content: ['demo.htm', 'no']
                });
            })
           $("#login").click(function () {
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
               $.post('login.aspx', $('#theform').serialize(), function (result) {
                   if (!result.isOk) {
                       layer.msg(result.msg, function () {
                           //关闭后的操作
                       });
                   }
                   else {

                       location.href = result.url;
                   }
               });
           })
        
</script>
</body>

</html>

