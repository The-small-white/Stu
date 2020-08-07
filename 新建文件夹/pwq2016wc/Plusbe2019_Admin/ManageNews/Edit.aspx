
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Plusbe2019_Admin_ManageNews_Edit" %>
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
                        <input type="hidden" value="<%#PCID %>" name="pcid" />
                        <input type="hidden" id="Size" value="<%#news.FileSize %>" name="FileSize" />
                        <div class="form-group">
                            <label class="col-sm-2 control-label">标题：</label>

                            <div class="col-sm-5">
                                <input type="text" class="form-control required" name="title" id="title" data-name="标题" value="<%#news.Title %>"  />
                            </div>
                        </div>
                        <%if (AdminMethod.CheckManage("u3d"))
                            {%>
                          <div class="form-group">
                            <label class="col-sm-2 control-label">
                                <button class="btn btn-info" id="upid" type="button"><i class="fa fa-cloud-upload"></i>上传缩略图</button>
                             

                            </label>

                            <div class="col-sm-10">
                                
                                 <%if (news.Pic == null || news.Pic == "")
                                     { %>
                                     <img src="../Hui/img/def.png" id="picfile" style="width:128px;">
                                <%}
                                    else
                                    { %>
                                <img src="/UploadFiles/<%#news.Pic %>" id="picfile" style="width:128px;">
                                <%} %>
                               
                                

                            
                                <input type="hidden" class="form-control" data-name="缩略图" id="pic" name="pic" value="<%#news.Pic %>"  />
                            </div>
                        </div>
                        <%} %>


                                <div class="form-group">
                            <label class="col-sm-2 control-label">上传文件：</label>

                            <div class="col-sm-10">
                                <div id="uploader">
                <div class="queueList">
                    <div id="dndArea" class="placeholder">

                        <div id="filePicker"></div>
                       <%-- <p>或将文件拖到这里，单次允许300文件！</p>--%>
                    </div>
                    <%--<ul class="filelist">
                        <li id="WU_FILE_0">
                            <p class="title">p_big2.jpg</p>
                            <p class="imgWrap">
                                <img src="data:image/jpeg;base64,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"></p>
                                <p class="progress"><span></span></p>
                                <div class="file-panel" style="height: 0px;">
                                    <span class="cancel">删除</span>
                                    <span class="rotateRight">向右旋转</span>
                                    <span class="rotateLeft">向左旋转</span>

                                </div>

                        </li>

                    </ul>--%>
                </div>

                <div class="statusBar" style="display:none;">
                    <div class="progress">
                        <span class="text">0%</span>
                        <span class="percentage"></span>
                    </div><div class="info"></div>
                    <div class="btns">
                        <div id="filePicker2"></div><div class="uploadBtn">开始上传</div>
                    </div>
                    <div class="info2" style="line-height: 18px;color:Red;height:20px;"></div>
                </div>
                 
                </div>
                                <input type="text" id="upload" class="form-control required" data-name="文件路径" name="files" value="<%#news.Files %>"  />
                            </div>
                        </div>
                        <input type="hidden" value="<%#news.Files %>" name="oldFiles" />
                      <div class="form-group">
                            <label class="col-sm-2 control-label">模式选择：</label>

                            <div class="col-sm-5">
                                 <select class="chosen-select" name="ModeID"    id="ModeID" style="width:180px;">
                                     <asp:Repeater ID="repeater" runat="server" DataSource="<%#m_ExhibitionList %>">
                                       <ItemTemplate>
                                       <option  value="<%#((Channel)Container.DataItem).ID %>" <%# SysConfig.Selected(((Channel)Container.DataItem).ID + "", news.ModeID + "") %> <%# ((Channel)Container.DataItem).Child ? "disabled" : ""%>>
                                         <%# ChannelProvider.GetDepth(((Channel)Container.DataItem).Depth)%>
                                         <%#((Channel)Container.DataItem).Name %>
                                     </option>
                                      </ItemTemplate>
                                       </asp:Repeater>
                                </select>
                            </div>
                        </div>
                     <div class="form-group">
                            <label class="col-sm-2 control-label">所属栏目：</label>

                            <div class="col-sm-5">
                                
                                 <select class="chosen-select" name="ChannelID"    id="ChannelID" style="width:180px;">
                                     <option value="-1">默认</option>
                                     <asp:Repeater ID="repeater2" runat="server" DataSource="<%#m_ExhibitionList1 %>">
                                       <ItemTemplate>
                                       <option  value="<%#((ModeChannel)Container.DataItem).ID %>" <%# SysConfig.Selected(((ModeChannel)Container.DataItem).ID + "", news.ChannelID + "") %> <%# ((ModeChannel)Container.DataItem).Child ? "disabled" : ""%>>
                                         <%# ModeChannelProvider.GetDepth(((ModeChannel)Container.DataItem).Depth)%>
                                         <%#((ModeChannel)Container.DataItem).Name %>
                                     </option>
                                      </ItemTemplate>
                                       </asp:Repeater>
                                </select>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">备注/讲解词：</label>
                            <div class="col-sm-8">
                                 <textarea  name="brief" class="form-control"  aria-required="true"><%#news.Brief %></textarea>
                                <span class="help-block m-b-none"></span>
                            </div>
                        </div>
                         <%if (AdminMethod.CheckManage("u3d")){%>
                         <div class="form-group">
                            <label class="col-sm-2 control-label">备注1：</label>
                            <div class="col-sm-8">
                                 <textarea name = "brief1" class="form-control"  aria-required="true"><%#news.Brief1 %></textarea>
                                <span class="help-block m-b-none"></span>
                            </div>
                        </div>
                         <div class="form-group">
                            <label class="col-sm-2 control-label">备注2：</label>
                            <div class="col-sm-8">
                                 <textarea  name="brief2" class="form-control"  aria-required="true"><%#news.Brief2 %></textarea>
                                <span class="help-block m-b-none"></span>
                            </div>
                        </div>
                        <%} %>
                         <div class="form-group">
                            <label class="col-sm-2 control-label">数据配置：</label>
                            <div class="col-sm-8">
                                 <textarea  name="JsonStr" class="form-control" id="JsonStr"  aria-required="true"><%#news.JsonStr %></textarea>
                                <span class="help-block m-b-none"> 
                                    <span class="label" title='{"type": "google","data": ""}'>谷歌</span>
                                    <span class="label" title='{"type": "browser","data": ""}'>Browser</span>
                                    <span class="label" title='{"type": "browserend","data": ""}'>Browser内嵌</span>
                                    <span class="label" title='{"type": "googleend","data": ""}'>谷歌窗口内嵌</span>
                                    <span class="label" title='{"type": "ie","data": ""}'>IE外调</span>
                                    <span class="label" title='{"type": "googleother","data": ""}'>谷歌外调</span>
                                    <span class="label" title='{"type": "exe","title": "","killname": ""}'>EXE示例</span>
                                   
                                </span>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">资源标签：</label>                              
                                 <div class="col-sm-5">
                                 <select class="chosen-select" name="TagID"    id="TagID" style="width:180px;">
                                     <asp:Repeater ID="repeater1" runat="server" DataSource="<%#CloudSQL.GetTagList() %>">
                                       <ItemTemplate>
                                       <option  value="<%#((TagTree)Container.DataItem).ID %>" <%# SysConfig.Selected(((TagTree)Container.DataItem).ID + "", news.TagID + "") %> <%# ((TagTree)Container.DataItem).Child ? "disabled" : ""%>>
                                         <%# TagProvider.GetDepth(((TagTree)Container.DataItem).Depth)%>
                                         <%#((TagTree)Container.DataItem).Name %>
                                     </option>
                                      </ItemTemplate>
                                       </asp:Repeater>
                                </select>
                            </div>
                        </div>
                         <div class="form-group">
                            <label class="col-sm-2 control-label">状态：</label>
                            <div class="col-sm-10">
                               
                                 <select class="chosen-select " name="state"    id="state" style="width:180px;" runat="server">
                                   <option value="1">展示</option>
                                   <option value="0">停用</option>
                                </select>
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

    
    <script src="<%=SysConfig.AdminPath %>MingApp/Scripts/jquery.js" type="text/javascript"></script>
    <script src="<%=SysConfig.AdminPath %>MingApp/Scripts/webuploader0.1.6.js" type="text/javascript"></script>
    <script src="<%=SysConfig.AdminPath %>MingApp/Scripts/upload.js" type="text/javascript"></script>
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
            upUrl: '../UpFaceApi/FilePic.aspx?t=0', //文件上传接口
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

                        $('#picfile').attr("src", "/UploadFiles/" + url + "?" + Math.random());
                        $('#pic').val(url);

                        $('#picfile').show();
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
        $('#TagID').chosen({

        });
        $('#ModeID').chosen({

        });
        $('#ChannelID').chosen({

        });
        $('#state').chosen({
            disable_search_threshold: 10,
            disable_search: true
        });
        var index = parent.layer.getFrameIndex(window.name); 
        $(".i-checks").iCheck({ checkboxClass: "icheckbox_square-green", radioClass: "iradio_square-green", })
        $("#closeIframe").click(function () {
            parent.layer.close(index);
        });
        $(".label").click(function () {
            var $this = $(this);
            var html = $this.attr("title");
            $("#JsonStr").val(html);
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
