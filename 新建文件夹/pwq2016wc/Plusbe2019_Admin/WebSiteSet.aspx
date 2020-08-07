<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebSiteSet.aspx.cs" Inherits="Plusbe2019_Admin_WebSiteSet" %>

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
    <link href="<%=SysConfig.AdminPath %>MingApp/Styles/webuploader.css" rel="stylesheet" type="text/css" />

</head>

<body class="gray-bg">
    <div class="wrapper wrapper-content">

        <div class="row">
            <div class="col-sm-5">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>平台设置</h5>

                    </div>
                    <div class="ibox-content">
                        <div class="alert alert-info">
                            平台全局设置！
                        </div>
                        <form role="form" class="form-horizontal m-t" name="theform" id="theform" action="WebSiteSet.aspx" onsubmit="return false;">
                            <input name="iD" id="iD" type="hidden" value="1">
                            <input name="action" value="save" type="hidden" />
                            <div class="form-group draggable">
                                <label class="col-sm-3 control-label">站点名：</label>
                                <div class="col-sm-9">
                                    <input type="text" name="WebName" class="form-control" placeholder="请输入平台名" value="<%#config.WebName %>">
                                </div>
                            </div>
                            <div class="form-group draggable">
                                <label class="col-sm-3 control-label">启用白名单：</label>
                                <div class="col-sm-9">
                                    <div class="checkbox checkbox-inline">
                                        <input type="checkbox" id="inlineCheckbox" name="UserIP" value="1" <%=SysConfig.SetCheckedMore(config.UserIP+"","1") %>>
                                        <label for="inlineCheckbox">启用</label>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group draggable">
                                <label class="col-sm-3 control-label">客户端版本：</label>
                                <div class="col-sm-3">
                                    <input type="text" class="form-control" id="ver" placeholder="" disabled value="<%#config.Version %>">
                                </div>
                                <div class="col-sm-5">

                                    <div id="filePicker"></div>
                                </div>
                            </div>
                            <div class="form-group draggable">
                                <div class="col-sm-12 col-sm-offset-3">
                                    <button class="btn btn-primary" type="submit" id="post">保存设置</button>

                                </div>
                            </div>
                        </form>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>

        </div>

    </div>

    <!-- 全局js -->
    <script src="<%=SysConfig.Hui %>js/jquery.min.js?v=2.1.4"></script>
    <script src="<%=SysConfig.AdminPath %>MingApp/Scripts/webuploader0.1.6.js" type="text/javascript"></script>
    <script src="<%=SysConfig.Hui %>js/bootstrap.min.js?v=3.3.6"></script>

    <!-- 自定义js -->
    <script src="<%=SysConfig.Hui %>js/content.js?v=1.0.0"></script>

    <script src="<%=SysConfig.Hui %>js/layer-v3.1.1/layer/layer.js"></script>
    <script>
        $("#post").click(function () {
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
            $.post('WebSiteSet.aspx', $('#theform').serialize(), function (result) {
                if (!result.isOk) {
                    parent.layer.msg(result.msg, { time: 2000 });
                }
                else {
                    parent.layer.msg(result.msg, {
                        icon: 1,
                        time: 1000 //2秒关闭（如果不配置，默认是3秒）
                    }, function () {

                        location.reload();

                    });

                }
            });
        })
        // 实例化
        uploader = WebUploader.create({
            pick: {
                id: '#filePicker',
                label: '发布更新文件'
            },
            formData: {
                uid: 123
            },
            auto: true,
            accept: {
                extensions: 'exe',

            },
            swf: '/Plusbe2019_Admin/MingApp/Scripts/Uploader.swf',
            server: 'WebSiteSet.aspx',
            disableGlobalDnd: true,
            fileSizeLimit: 4000 * 1024 * 1024,    // 4G M
            fileSingleSizeLimit: 2000 * 1024 * 1024    //2G
        });
        var index = document.getElementById("ver").value;
        uploader.on('uploadSuccess', function (file, response) {
            console.log("监听：", response);
            if (response == 'undefined' || response == '' || response == null) {
            }
            else {
                $.post('WebSiteSet.aspx', { action: "Ver", iD: 1, index }, function (result) {
                    console.log(result.isOk)
                    if (!result.isOk) {
                        parent.layer.msg(result.msg, { time: 2000 });
                    }
                    else {
                        parent.layer.msg(result.msg, {
                            icon: 1,
                            time: 1000 //2秒关闭（如果不配置，默认是3秒）
                        }, function () {

                            location.reload();

                        });

                    }
                });
            }
        });

    </script>


    <!--统计代码，可删除-->
</body>

</html>

