<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Plusbe2019_ManageUserinfo_Edit" %>
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
     <link href="<%=SysConfig.AdminPath %>MingApp/Styles/webuploader.css" rel="stylesheet" type="text/css" />
    <link href="<%=SysConfig.AdminPath %>MingApp/Styles/style.css" rel="stylesheet" type="text/css" />
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
                          <input type="hidden" id="Size" value="<%#news.FileSize %>" name="FileSize" />
                        <div class="form-group">
                            <label class="col-sm-2 control-label">姓名：</label>

                            <div class="col-sm-5">
                                <input type="text" class="form-control required" name="Name" value="<%#news.Name %>"  />
                            </div>
                        </div>

                          <div class="form-group">
                            <label class="col-sm-2 control-label">昵称：</label>

                            <div class="col-sm-5">
                                <input type="text" class="form-control required" name="NickName" value="<%#news.NickName %>"  />
                            </div>
                        </div>

                           <div class="form-group">
                            <label class="col-sm-2 control-label">联系方式：</label>

                            <div class="col-sm-5">
                                <input type="number" class="form-control required" name="Phone" value="<%#news.Phone %>"  />
                            </div>
                        </div>

                            <div class="form-group">
                            <label class="col-sm-2 control-label">微信标识：</label>

                            <div class="col-sm-5">
                                <input type="text" class="form-control " name="WxID" value="<%#news.WxID %>"  />
                            </div>
                        </div>
                                         <div class="form-group">
                            <label class="col-sm-2 control-label">二维码标识：</label>

                            <div class="col-sm-5">
                                <input type="text" class="form-control " name="ErCode" value="<%#news.ErCode %>"  />
                            </div>
                        </div>  
                        
                            <div class="form-group">
                                <label class="col-sm-2 control-label">性别：</label>

                                <div class="col-sm-5">
                                    <select class="chosen-select" name="Gender" id="Gender" style="width: 180px;" runat="server">
                                                <option value="0">男</option>
                                                <option value="1">女</option>                                    
                                    </select>
                                </div>
                            </div>

                          <div class="form-group">
                                <label class="col-sm-2 control-label">年龄段：</label>

                                <div class="col-sm-5">
                                    <select class="chosen-select" name="AgeType" id="AgeType" style="width: 180px;">
                                           <asp:Repeater ID="repeater" runat="server" DataSource="<%#CloudSQL.GetMyAge() %>">
                                            <ItemTemplate>
                                                <option value="<%#((AgeType)Container.DataItem).ID %>" <%# SysConfig.Selected(((AgeType)Container.DataItem).ID+"",news.AgeType+"") %>>
                                                    <%#((AgeType)Container.DataItem).AgeName %>
                                                </option>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                     
                                    </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-2 control-label">行业：</label>

                                <div class="col-sm-5">
                                    <select class="chosen-select" name="TradeID" id="TradeID" style="width: 180px;">
                                               <asp:Repeater ID="repeater1" runat="server" DataSource="<%#CloudSQL.GetMyTrdType() %>">
                                            <ItemTemplate>
                                                <option value="<%#((TrdType)Container.DataItem).ID %>" <%# SysConfig.Selected(((TrdType)Container.DataItem).ID+"",news.TradeID+"") %>>
                                                    <%#((TrdType)Container.DataItem).TradeType %>
                                                </option>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </select>
                                </div>
                            </div>
        
                    <div class="form-group">
                            <label class="col-sm-2 control-label">
                                <button class="btn btn-info" id="upid" type="button"><i class="fa fa-cloud-upload"></i>上传头像</button>
                             

                            </label>

                            <div class="col-sm-10">
                                
                                 <%if (news.HeadImage == null || news.HeadImage == "")
                                     { %>
                                     <img src="../Hui/img/def.png" id="pic" style="width:128px;">
                                <%}else{ %>
                                <img src="/UserFacePic/<%#news.HeadImage %>" id="pic" style="width:128px;">
                                <%} %>
                               
                                

                            
                                <input type="hidden" class="form-control required" data-name="文件路径" id="HeadImage" name="HeadImage" value="<%#news.HeadImage %>"  />
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
       <script src="../Hui/js/fcup/fcup.js"></script>
    <script src="../Hui/js/fcup/fcupBtn.js"></script>
    <script>
        $.fcup({

            upId: 'upid', //上传dom的id
            upShardSize: '10', //切片大小,(单次上传最大值)单位M，默认2M
            upMaxSize: '10', //上传文件大小,单位M，不设置不限制
            uploading: '上传中....',
            upUrl: '../UpFaceApi/FacePic.aspx?t=1', //文件上传接口
            upType: 'jpg,png,jpeg', //上传类型检测,用,号分割
            errtype: '请上传图片文件',//不支持类型的提示文字
            //接口返回结果回调，根据结果返回的数据来进行判断，可以返回字符串或者json来进行判断处理
            upCallBack: function (res) {
                if (res.isOk) {

                    // 状态
                    var status = res.obj["status"];
                    // 信息
                    // var msg = res.message;
                   
                    // url
                    var url = res.obj["file_Name"];

                    // 已经完成了
                    if (status == 2) {

                        $('#pic').attr("src", "/UserFacePic/" + url + "?" + Math.random());
                        $('#HeadImage').val(url);
                       
                        $('#pic').show();
                    }

                    // 还在上传中
                    if (status == 1) {
                        //console.log(msg);
                    }

                    // 接口返回错误
                    if (status == 0) {
                        // 停止上传并且提示信息
                        // $.upStop(msg);
                    }
                }

            },

            // 上传过程监听，可以根据当前执行的进度值来改变进度条
            upEvent: function (num) {
                // num的值是上传的进度，从1到100
                // 改变进度条的值
                var controlButton = jQuery('.fcup-button');
                controlButton.fcupSet(num);
            },

            // 发生错误后的处理
            upStop: function (errmsg) {
                // 这里只是简单的alert一下结果，可以使用其它的弹窗提醒插件
                alert(errmsg);
            },

            // 开始上传前的处理和回调,比如进度条初始化等
            upStart: function () {
                // 初始化进度条插件
                jQuery('.fcup-button').fcupInitialize();
                $('#pic').hide();
                // alert('开始上传');
            }

        });
    </script>
<script>
    $(document).ready(function ()
    {
        $('#Gender').chosen({
            disable_search_threshold: 10,
            disable_search: true
        });
        $('#TradeID').chosen({
            disable_search_threshold: 10,
            disable_search: true
        });
 $('#AgeType').chosen({
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
