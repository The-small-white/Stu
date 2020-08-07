<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MailBoxs.aspx.cs" Inherits="Plusbe2019_Admin_MailBoxs" %>
<%@ Import Namespace="Dejun.DataProvider.Table" %>
<!DOCTYPE html>
<html>

<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title><%=SysConfig.WebTitle %></title>
    <link rel="shortcut icon" href="<%=SysConfig.Hui %>favicon.ico"> 
    <link href="<%=SysConfig.Hui %>css/bootstrap.min.css?v=3.3.6" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/font-awesome.css?v=4.4.0" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/plugins/iCheck/custom.css" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/animate.css" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/style.css?v=4.1.0" rel="stylesheet">

</head>

<body class="gray-bg">
    <div class="wrapper wrapper-content">
        <div class="row">
            
            <div class="col-sm-12">
                <div class="mail-box-header">

                    <form method="get" action="MailBoxs.aspx" id="theform1" name="theform1"   class="pull-right mail-search">
                        <div class="input-group">
                            <input type="text" class="form-control input-sm" name="msg" placeholder="搜索消息正文" id="msg" runat="server">
                            <div class="input-group-btn">
                                <button type="submit" class="btn btn-sm btn-primary">
                                    搜索
                                </button>
                            </div>
                        </div>
                    </form>
                    <h2>
                    收件箱 (<%#list.Count %>)
                </h2>
                    <div class="mail-tools tooltip-demo m-t-md">

                        <button class="btn btn-white btn-sm" id="refresh" data-toggle="tooltip" data-placement="top" title="刷新"><i class="fa fa-refresh"></i> 刷新</button>
                        <button class="btn btn-white btn-sm operate" data-id="1"  data-toggle="tooltip" data-placement="top" title="标为已读"><i class="fa fa-eye"></i>
                        </button>
                       <%-- <button class="btn btn-white btn-sm operate" data-id="2" data-toggle="tooltip" data-placement="top" title="标为重要"><i class="fa fa-exclamation"></i>
                        </button>--%>
                        <button class="btn btn-white btn-sm operate" data-id="-1" data-toggle="tooltip" data-placement="top" title="删除邮件"><i class="fa fa-trash-o"></i>
                        </button>

                    </div>
                </div>
                <div class="mail-box">
                     <form id="theform" name="theform"  method="post">
                         <input type="hidden" value="0" id="states" name="states"  />
                    <table class="table table-hover table-mail">
                        <tbody>
                            <tr class="unread">
                                <td class="check-mail">
                                    <input type="checkbox" class="i-checks" id="allcheck">
                                </td>
                                
                                <td class="mail-ontact"><a href="#">发件人</a>
                                </td>
                               
                                <td class="mail-subject"><a href="#">主题</a>
                                </td>
                              
                                <td class="text-right mail-date">时间</td>
                            </tr>
                             <asp:Repeater ID="Repeater1" runat="server" DataSource="<%# list %>">
                                     <ItemTemplate>
                            <tr class="unread" id="tr_<%# ((Mailbox)Container.DataItem).ID%>">
                                <td class="check-mail">
                                    <input type="checkbox" class="i-checks"  name="checkshop" value="<%#((Mailbox)Container.DataItem).ID%>">
                                </td>
                               
                                </td>
                                <td class="mail-ontact"><a href="#" class="see" data-id="<%# ((Mailbox)Container.DataItem).ID%>" data-states="<%# ((Mailbox)Container.DataItem).States%>" data-name="<%#((Mailbox)Container.DataItem).Msg %>"><%#((Mailbox)Container.DataItem).SendName %></a><%#GetStates(((Mailbox)Container.DataItem)) %>
                                </td>
                                <td class="mail-subject"><a href="#" class="see" data-id="<%# ((Mailbox)Container.DataItem).ID%>" data-states="<%# ((Mailbox)Container.DataItem).States%>" data-name="<%#((Mailbox)Container.DataItem).Msg %>"><%#((Mailbox)Container.DataItem).Msg %></a>
                                </td>
                               
                                <td class="text-right mail-date"><%#((Mailbox)Container.DataItem).AddTime.GetDateTimeFormats('f')[0].ToString() %></td>
                            </tr>
                              </ItemTemplate>
                                 </asp:Repeater>
                        </tbody>
                        <tfoot> <tr><td colspan="10" class="footable-visible"> <%#this.GetPagingHtml() %></td> </tr></tfoot>
                    </table>
                         </form>

                </div>
            </div>
        </div>
    </div>


    <!-- 全局js -->
    <script src="<%=SysConfig.Hui %>js/jquery.min.js?v=2.1.4"></script>
    <script src="<%=SysConfig.Hui %>js/bootstrap.min.js?v=3.3.6"></script>



    <!-- 自定义js -->
    <script src="<%=SysConfig.Hui %>js/content.js?v=1.0.0"></script>


    <!-- iCheck -->
    <script src="<%=SysConfig.Hui %>js/plugins/iCheck/icheck.min.js"></script>
    <script src="<%=SysConfig.Hui %>js/layer-v3.1.1/layer/layer.js"></script>
    <script>
        $(document).ready(function () {
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
        });
        $('.see').click(function ()
        {
            var $this = $(this);
            
            $.post('Delete.aspx', { checkshop: $this.data('id'), states: 1 }, function (result) {
                if (result.isOk) {
                    layer.open({
                        type: 1,
                        skin: 'layui-layer-rim', //加上边框
                        area: ['420px', '240px'], //宽高
                        content: '<div style="padding: 50px; line-height: 22px; font-weight: 240;"><br>' + $this.data('name') + '</div>',
                        success: function (layero) {
                            $('#box_' + $this.data('id')).remove();
                        }
                    });
                }
            });
           
            
            
            
        });
        $('.operate').click(function ()
        {
            var $this = $(this);
            if ($("input[type='checkbox']:checked").length == 0) {
                layer.msg('请选择操作对象!', function () {
                    //关闭后的操作
                });
                return;
            }
            else
            {
                var ids = $this.data('id');
                $("#states").val(ids);
                var msg = '标记为已读';
                if (ids == '2') {
                    msg = '标记为重要';
                }
                else if (ids == '-1') {
                    msg = '删除';
                }
                layer.confirm('确定要' + msg+'该信息？', {
                    btn: ['确定', '取消'] //按钮
                }, function () {
                    var arr = $('#theform').serializeArray();
                    $.post('Delete.aspx', arr, function (result) {
                        if (result.isOk) {
                            layer.msg('执行成功', { icon: 1, time: 1000 });
                            for (var i = 0; i < arr.length; i++) {
                                if (arr[i].name == 'checkshop') {
                                    $('#tr_' + arr[i].value).remove();
                                }
                            }
                        } else {
                            layer.msg('执行失败', { icon: 2, time: 1000 });
                        }
                    });
                });

            }
        });
    </script>

</body>

</html>

