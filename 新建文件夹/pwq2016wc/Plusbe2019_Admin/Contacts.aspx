<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contacts.aspx.cs" Inherits="Plusbe2019_Admin_Contacts" %>
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

    <link href="<%=SysConfig.Hui %>css/animate.css" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/style.css?v=4.1.0" rel="stylesheet">

</head>

<body class="gray-bg">
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <asp:Repeater ID="userlist" runat="server" DataSource="<%#list %>">
                <ItemTemplate>
                    <div class="col-sm-4">
                <div class="contact-box">
                    <a href="profile.html">
                        <div class="col-sm-4">
                            <div class="text-center">
                                <img alt="image" class="img-circle m-t-xs img-responsive" src="<%=SysConfig.Hui %>img/a2.png">
                                <div class="m-t-xs font-bold"><%# ((View_AdminUser)Container.DataItem).JobTitle%></div>
                            </div>
                        </div>
                        <div class="col-sm-8">
                            <h3><strong><%# ((View_AdminUser)Container.DataItem).FullName%></strong></h3>
                            <p><i class="fa fa-map-marker"></i> <%# ((View_AdminUser)Container.DataItem).Address%></p>
                            <address>
                            <strong><%# ((View_AdminUser)Container.DataItem).ExhibitionName%></strong><br>
                            E-mail:<%# ((View_AdminUser)Container.DataItem).Email%><br>
                           
                            <abbr title="Phone">Tel:</abbr> <%# ((View_AdminUser)Container.DataItem).Phone%>
                        </address>
                        </div>
                        <div class="clearfix"></div>
                    </a>
                </div>
            </div>
                </ItemTemplate>
            </asp:Repeater>
            
        
        </div>
    </div>

    <!-- 全局js -->
    <script src="<%=SysConfig.Hui %>js/jquery.min.js?v=2.1.4"></script>
    <script src="<%=SysConfig.Hui %>js/bootstrap.min.js?v=3.3.6"></script>



    <!-- 自定义js -->
    <script src="<%=SysConfig.Hui %>js/content.js?v=1.0.0"></script>



    <script>
        $(document).ready(function () {
            $('.contact-box').each(function () {
                animationHover(this, 'pulse');
            });
        });
    </script>
    <!--统计代码，可删除-->

</body>

</html>

