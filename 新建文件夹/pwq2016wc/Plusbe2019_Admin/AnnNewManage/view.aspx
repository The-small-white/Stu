<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view.aspx.cs" Inherits="Plusbe2019_Admin_AnnNewManage_view" %>
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
     <div class="row">
        <div class="col-sm-12">
            <div class="wrapper wrapper-content animated fadeInUp">
                <ul class="notes">
                     <asp:Repeater ID="Repeater2" runat="server" DataSource="<%# m_tableManageList %>">
                     <ItemTemplate>
                    <li>
                        <a href="showView.aspx?iD=<%# ((AnnNews)Container.DataItem).ID%>" title="">
                        <div>
                            <small><%# ((AnnNews)Container.DataItem).AddTime.GetDateTimeFormats('f')[0].ToString()%>/<%# ((AnnNews)Container.DataItem).Author%></small>
                            <h4> <%# SysConfig.GetStr1(((AnnNews)Container.DataItem).Title,10)%></h4>
                            <p> <%#SysConfig.GetStr1(((AnnNews)Container.DataItem).Contents,100)%></p>
                           
                        </div> </a>
                    </li>
                    </ItemTemplate>
                    </asp:Repeater>
                   
                </ul>
            </div>
        </div>
    </div>
    

    <!-- 全局js -->
    <script src="<%=SysConfig.Hui %>js/jquery.min.js?v=2.1.4"></script>
    <script src="<%=SysConfig.Hui %>js/bootstrap.min.js?v=3.3.6"></script>

    <!-- 自定义js -->
    <script src="<%=SysConfig.Hui %>js/content.js?v=1.0.0"></script>
    <!--统计代码，可删除-->

</body>

</html>

