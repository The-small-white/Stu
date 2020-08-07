<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Plusbe2019_Admin_index" %>
<%@ Import Namespace="Dejun.DataProvider.Table" %>
<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="renderer" content="webkit">

    <title><%=SysConfig.WebTitle %></title>

    <!--[if lt IE 9]>
    <meta http-equiv="refresh" content="0;ie.html" />
    <![endif]-->

    <link rel="shortcut icon" href="<%=SysConfig.Hui %>favicon.ico"> 
    <link href="<%=SysConfig.Hui %>css/bootstrap.min.css?v=3.3.6" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/font-awesome.min.css?v=4.4.0" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/animate.css" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/style.css?v=4.1.0" rel="stylesheet">
</head>

<body class="fixed-sidebar full-height-layout gray-bg" style="overflow:hidden">
    <div id="wrapper">
        <!--左侧导航开始-->
        <nav class="navbar-default navbar-static-side" role="navigation">
            <div class="nav-close"><i class="fa fa-times-circle"></i>
            </div>
            <div class="sidebar-collapse">
                <ul class="nav" id="side-menu">
                    <li class="nav-header">
                        <div class="dropdown profile-element">
                            <span><img alt="image" class="img-circle" src="<%=AdminMethod.HeadPic %>" height="64px;" width="64px;" /></span>
                            <a data-toggle="dropdown" class="dropdown-toggle" href="#">
                                <span class="clear">
                               <span class="block m-t-xs"><strong class="font-bold"><%=AdminMethod.AdminName %></strong></span>
                                <span class="text-muted text-xs block"><%=AdminMethod.AdminFullName %><b class="caret"></b></span>
                                </span>
                            </a>
                            <ul class="dropdown-menu animated fadeInRight m-t-xs">
                                
                                <li><a class="J_menuItem" href="AdminManage/Edit.aspx?iD=-1">个人资料</a>
                                </li>
                                 <%if (AdminMethod.CheckManage("zhiyuan"))
                                     {%>
                                  <li><a class="J_menuItem" href="AdminMailBox/MailBoxs.aspx">信箱</a>
                                      <%} %>
                                </li>
                                <li><a class="J_menuItem" href="contacts.aspx">联系人</a>
                                </li>
                                <li class="divider"></li>
                                <li><a href="login.aspx?action=loginout">安全退出</a>
                                </li>
                            </ul>
                        </div>
                        <div class="logo-element">Cloud
                        </div>
                    </li>
                     <%if (AdminMethod.CheckManage("kuangjia"))
                         { %>
                      <li>
                        <a class="J_menuItem" href="AdminExTree/manage.aspx"><i class="fa fa-columns"></i> <span class="nav-label">展厅架构</span></a>
                    </li>
                    <%} %>
                    <li>
                        <a href="#"><i class="fa fa-desktop"></i> <span class="nav-label">信息公告</span><span class="fa arrow"></span></a>
                        <ul class="nav nav-second-level">
                            <li><a class="J_menuItem" href="AnnNewManage/manage.aspx">公告管理</a>
                            </li>
                             <li><a class="J_menuItem" href="AnnNewManage/view.aspx">公告列表</a>
                            </li>
                             <li><a class="J_menuItem" href="AnnNewManage/manage.aspx?t=my">我的发布</a>
                             </li>

                        </ul>
                    </li>
                    <%if (AdminMethod.CheckManage("zhiyuan"))
                                { %>
                    <li>
                        <a href="#"><i class="fa fa-cloud"></i> <span class="nav-label">资源池</span><span class="fa arrow"></span></a>
                        <ul class="nav nav-second-level">
                            <li><a class="J_menuItem" href="CloudNews/manage.aspx">云资源库</a>
                            </li>
                            <%if (AdminMethod.CheckManage("tag"))
                                { %>
                            <li><a class="J_menuItem" href="AdminTypeTree/manage.aspx">资源分类</a>
                            </li>
                          <%} %>
                            <li>
                                <a href="#">我的资源 <span class="fa arrow"></span></a>
                                <ul class="nav nav-third-level">
                                    <li><a class="J_menuItem" href="CloudNews/manage.aspx?t=-1">我的资源</a>
                                    </li>
                                  <%--  <li><a class="J_menuItem" href="form_file_upload.html">我的申请</a>
                                    </li>
                                    <li><a class="J_menuItem" href="form_avatar.html">我的审核</a>
                                    </li>--%>
                                </ul>
                            </li>
                 
                        </ul>
                    </li>
                    <%} %>


                    
                    <%if (AdminMethod.CheckManage("zk"))
                        { %>
                       <li> <a href="#"><i class="fa fa-home"></i><span class="nav-label">设备中控</span><span class="fa arrow"></span></a>
                        <ul class="nav nav-second-level">
                                    <li><a class="J_menuItem" href="AreaManageLight/manage.aspx">灯光管理</a>
                                    </li>
                                    <li><a class="J_menuItem" href="AreaManageDevice/manage.aspx">设备管理</a>
                                    </li>
                                    <li><a class="J_menuItem" href="AreaManageDevice/manage.aspx?tid=1">其他设备</a>
                                    </li>
                        </ul>
                    </li>
                    <%} %>
                      <li>
                        <a href="#"><i class="fa fa-folder"></i><span class="nav-label">展厅内容</span><span class="fa arrow"></span></a>
                        <ul class="nav nav-second-level">
                             <li><a class="J_menuItem" href="PCManage/Manage.aspx">主机列表</a></li>
                             <li><a class="J_menuItem" href="AreaManage/manage.aspx">展区管理</a></li>
                        </ul>
                    </li>
                     <li>
                        <a class="J_menuItem" href="AdminMode/manage.aspx"><i class="fa fa-th"></i> <span class="nav-label">场景模式</span></a>
                    </li>
                     <%if (AdminMethod.CheckManage("u3d"))
                         { %>
                     <li>
                        <a class="J_menuItem" href="AdminChannel/manage.aspx"><i class="fa fa-navicon"></i> <span class="nav-label">U3D栏目设置</span></a>
                    </li>
                    <%} %>
                     <%if (AdminMethod.CheckManage("answer"))
                        { %>
                     <li>
                        <a href="#"><i class="fa fa-book"></i> <span class="nav-label">题库管理</span><span class="fa arrow"></span></a>
                        <ul class="nav nav-second-level">
                            
                            <li><a class="J_menuItem" href="QustionTree/Manage.aspx">题库分类</a> </li>
                            <li><a class="J_menuItem" href="QustionTitle/Manage.aspx">题库列表</a></li>
                         </ul>

                    </li>
                    <%} %>
                     <%if (AdminMethod.CheckManage("yuyue"))
                         { %>
                    <li>
                        <a href="#">
                            <i class="fa fa fa-clock-o"></i>
                            <span class="nav-label">预约管理</span>
                            <span class="fa arrow"></span>
                        </a>
                        <ul class="nav nav-second-level">
                            <li>
                                <a class="J_menuItem" href="AreaManageReserveDate/Manage.aspx">预约时间</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="AreaManageReserveMsg/Manage.aspx">预约列表</a>
                            </li>
                   
                        </ul>
                    </li>
                    <%} %>
                    <%if (AdminMethod.CheckManage("face"))
                        { %>
                        <li>
                        <a href="#"><i class="fa fa-eye"></i> <span class="nav-label">人脸识别</span><span class="fa arrow"></span></a>
                        <ul class="nav nav-second-level">
                            <li>
                                <a href="#">用户管理 <span class="fa arrow"></span></a>
                                <ul class="nav nav-third-level">
                                    <li><a class="J_menuItem" href="ManageUserinfo/Manage.aspx">用户列表</a>
                                     <li><a class="J_menuItem" href="UserInfoAge/Manage.aspx">年龄段管理</a>
                                     <li><a class="J_menuItem" href="UserInfoTrad/Manage.aspx">行业管理</a>
                                        
                                   
                                  
                                </ul>
                            </li>
                          <li>
                                <a href="#">人脸库 <span class="fa arrow"></span></a>
                                <ul class="nav nav-third-level">
                                    <li><a class="J_menuItem" href="ManageFace/Manage.aspx">人脸库管理</a>
                                        <li><a class="J_menuItem" href="ManageFace/Managelog.aspx">人脸日志</a>
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </li>
                     <%} %>
                    <%if (AdminMethod.CheckManage("yuyin"))
                        { %>
                        <li>
                        <a href="#"><i class="fa fa-microphone"></i> <span class="nav-label">语音识别</span><span class="fa arrow"></span></a>
                        <ul class="nav nav-second-level">
                         <li><a class="J_menuItem" href="SpeechManage/Manage.aspx">指令列表</a></li>
                        </ul>
                        </li>
                   <%} %>
                     <%if (AdminMethod.CheckManage("ibeacon"))
                        { %>
                        <li>
                        <a href="#"><i class="fa fa-rss"></i> <span class="nav-label">蓝牙分析</span><span class="fa arrow"></span></a>
                        <ul class="nav nav-second-level">
                         <li><a class="J_menuItem" href="ibeaconManage/Manage.aspx">基站列表</a></li>
                         <li><a class="J_menuItem" href="ibeaconDevManage/Manage.aspx">信标列表</a></li>
                       
                        </ul>
                        </li>
                   <%} %>
                    <%if (AdminMethod.CheckManage("set"))
                        { %>
                    <li>
                        <a href="#"><i class="fa fa-cog fa-spin"></i> <span class="nav-label">平台设置</span><span class="fa arrow"></span></a>
                        <ul class="nav nav-second-level">
                            <li><a class="J_menuItem" href="websiteset.aspx">平台设置</a></li>
                             <li><a class="J_menuItem" href="IPManage/Manage.aspx">访问白名单</a></li>
                            <%-- <li><a class="J_menuItem" href="TableManage/Manage.aspx">表单列表</a>
                            </li>--%>
                         </ul>

                    </li>
                    <%} %>
                    <%if (AdminMethod.CheckManage("sys"))
                        { %>
                     <li>
                        <a href="#"><i class="fa fa-user"></i> <span class="nav-label">系统管理</span><span class="fa arrow"></span></a>
                        <ul class="nav nav-second-level">
                            <li><a class="J_menuItem" href="AdminManage/Manage.aspx">管理员管理</a></li>
                              <li><a class="J_menuItem" href="LogManage/Manage.aspx">操作日志</a></li>
                            <li><a class="J_menuItem" href="Deployment/Deployment.aspx">部署初始化</a></li>
                         </ul>
                    </li>
                    <%} %>
                   
            </div>
        </nav>
        <!--左侧导航结束-->
        <!--右侧部分开始-->
        <div id="page-wrapper" class="gray-bg dashbard-1">
            <div class="row border-bottom">
                <nav class="navbar navbar-static-top" role="navigation" style="margin-bottom: 0">
                    <div class="navbar-header">
                        <a class="navbar-minimalize minimalize-styl-2 btn btn-primary " href="#"><i class="fa fa-bars"></i> </a>
                        
                    </div>
                    <ul class="nav navbar-top-links navbar-right">
                          <%if (AdminMethod.CheckManage("zhiyuan"))
                                  {%>
                           <li class="dropdown">
                            <a class="dropdown-toggle count-info" data-toggle="dropdown" href="#">
                                <i class="fa fa-bell"></i> <span class="label label-primary"><%#MsgCount%></span>
                            </a>
                            <ul class="dropdown-menu dropdown-alerts">
                                <li>
                                    <a class="J_menuItem" href="AdminMailBox/MailBoxs.aspx">
                                        <div>
                                            <i class="fa fa-envelope fa-fw"></i> 
                                            <%if (MsgCount == "")
                                  { %>
                                            您暂无未读消息
                                            <%}
                                  else
                                  { %>
                                            您有<%=MsgCount == "" ? "" : MsgCount %>条未读消息
                                            <%} %>
                                            
                                           
                                        </div>
                                    </a>
                                </li>
                     
                                <li class="divider"></li>
                                <li>
                                    <div class="text-center link-block">
                                        <a class="J_menuItem" href="AdminMailBox/MailBoxs.aspx">
                                            <strong>查看所有 </strong>
                                            <i class="fa fa-angle-right"></i>
                                        </a>
                                    </div>
                                </li>
                            </ul>
                        </li>
                        <%} %>
                        <li class="dropdown hidden-xs">
                          
                            <div class="sk-spinner sk-spinner-wave">
                                <div class="sk-rect1"></div>
                                <div class="sk-rect2"></div>
                                <div class="sk-rect3"></div>
                                <div class="sk-rect4"></div>
                                <div class="sk-rect5"></div>
                            </div>
                           <%-- <a class="right-sidebar-toggle" aria-expanded="false">
                                <i class="fa fa-tasks"></i>版本信息
                            </a>--%>
                        </li>
                    </ul>
                </nav>
            </div>
            <div class="row content-tabs">
                <button class="roll-nav roll-left J_tabLeft"><i class="fa fa-backward"></i>
                </button>
                <nav class="page-tabs J_menuTabs">
                    <div class="page-tabs-content">
                        <a href="javascript:;" class="active J_menuTab" data-id="main.aspx">首页</a>
                    </div>
                </nav>
                <button class="roll-nav roll-right J_tabRight"><i class="fa fa-forward"></i>
                </button>
                <div class="btn-group roll-nav roll-right">
                    <button class="dropdown J_tabClose" data-toggle="dropdown">关闭操作<span class="caret"></span>

                    </button>
                    <ul role="menu" class="dropdown-menu dropdown-menu-right">
                        <li class="J_tabShowActive"><a>定位当前选项卡</a>
                        </li>
                        <li class="divider"></li>
                        <li class="J_tabCloseAll"><a>关闭全部选项卡</a>
                        </li>
                        <li class="J_tabCloseOther"><a>关闭其他选项卡</a>
                        </li>
                    </ul>
                </div>
                <a href="login.aspx?action=loginout" class="roll-nav roll-right J_tabExit"><i class="fa fa fa-sign-out"></i> 退出</a>
            </div>
            <div class="row J_mainContent" id="content-main">
                <iframe class="J_iframe" name="iframe0" width="100%" height="100%" src="main.aspx" frameborder="0" data-id="main.aspx" seamless></iframe>
            </div>
            <div class="footer">
                <div class="pull-right">版权所有权：杭州向正科技有限公司&copy; 2019 All Rights Reserved
                </div>
            </div>
        </div>
        <!--右侧部分结束-->
        <!--右侧边栏开始-->
        <div id="right-sidebar">
            <div class="sidebar-container">

                <ul class="nav nav-tabs">

                    <li class="active">
                        <a data-toggle="tab" href="#tab-1">
                            <i class="fa fa-gear"></i> 系统信息
                        </a>
                    </li>
          
                </ul>

                <div class="tab-content">
                    <div id="tab-1" class="tab-pane active">
                        <div class="panel-body">
                            <h3> <i class="fa fa-comments-o"></i> 系统信息</h3>
                            <small><i class="fa fa-tim"></i> 云平台3.0</small>
                        </div>
                        
                    </div>
                  
                </div>

            </div>
        </div>
        <!--右侧边栏结束-->
        <!--mini聊天窗口开始-->
        
        
        <!--mini聊天窗口结束-->
    </div>
    
    <!-- 全局js -->
    <script src="<%=SysConfig.Hui %>js/jquery.min.js"></script>
    <script src="<%=SysConfig.Hui %>js/bootstrap.min.js"></script>
    <script src="<%=SysConfig.Hui %>js/plugins/metisMenu/jquery.metisMenu.js"></script>
    <script src="<%=SysConfig.Hui %>js/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script src="<%=SysConfig.Hui %>js/plugins/layer/layer.min.js"></script>

    <!-- 自定义js -->
    <script src="<%=SysConfig.Hui %>js/hplus.js?v=4.1.0"></script>
    <script type="text/javascript" src="<%=SysConfig.Hui %>js/contabs.js"></script>

    <!-- 第三方插件 -->
    <script src="<%=SysConfig.Hui %>js/plugins/pace/pace.min.js"></script>

</body>

</html>

