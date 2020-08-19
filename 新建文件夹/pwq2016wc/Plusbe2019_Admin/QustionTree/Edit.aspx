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
                            <label class="col-sm-2 control-label">类别：</label>

                            <div class="col-sm-5">
                                <input type="text" class="form-control required" data-name="类别" name="name" value="<%#news.Name %>"  />
                            </div>
                        </div>
                       <div class="form-group">
                            <label class="col-sm-2 control-label">所属架构：</label>
                            <div class="col-sm-10">
                               
                                 <select class="chosen-select" name="parentID"    id="parentID" style="width:180px;">
                                   <option value="0">做为一级栏目</option>
                                     <asp:Repeater ID="repeater" runat="server" DataSource="<%#m_ExhibitionList %>">
                                       <ItemTemplate>
                                     <option  value="<%#((QuestionType)Container.DataItem).ID %>" <%# SysConfig.Selected(((QuestionType)Container.DataItem).ID+"",news.ParentID+"") %> 
                                         <%# ((QuestionType)Container.DataItem).Child?"":"disabled"%>>
                                         <%# QusetionProvider.GetDepth(((QuestionType)Container.DataItem).Depth)%>
                                         <%#((QuestionType)Container.DataItem).Name %>
                                     </option>
                                      </ItemTemplate>
                                       </asp:Repeater>
                                </select>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">是否有子模式：</label>
                            <div class="col-sm-10">
                                  <div class="radio radio-info radio-inline">
                                        <input type="radio" id="inlineRadio1" value="true" name="child" <%#SysConfig.Checked("true",m_nowChild) %> >
                                        <label for="inlineRadio1">是</label>
                                    </div>
                                    <div class="radio radio-inline">
                                        <input type="radio" id="inlineRadio2" value="false" name="child"  <%#SysConfig.Checked("false",m_nowChild) %> >
                                        <label for="inlineRadio2">否</label>
                                    </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">备注：</label>
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
    <script src="<%=SysConfig.Hui %>js/form-chosenselect.js"></script>
<script>
    $(document).ready(function ()
    {
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
            var radio = $("input[name='child']:checked").val();
            var parentID = $("#parentID").val();
            if (parentID == 0 && radio == "false") {
                parent.layer.msg('一级栏目不能设置为无子模式', function () {
                    //关闭后的操作
                });
                return false;
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
                        parent.GetTree();
                        
                    });

                }
            });
        })
        

    });
</script>

</body>

</html>
