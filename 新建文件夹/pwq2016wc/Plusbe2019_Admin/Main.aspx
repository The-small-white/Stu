<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Plusbe2019_Admin_Main" %>
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

    <!-- Morris -->
    <link href="<%=SysConfig.Hui %>css/plugins/morris/morris-0.4.3.min.css" rel="stylesheet">

    <!-- Gritter -->
    <link href="<%=SysConfig.Hui %>js/plugins/gritter/jquery.gritter.css" rel="stylesheet">

    <link href="<%=SysConfig.Hui %>css/animate.css" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/style.css?v=4.1.0" rel="stylesheet">

</head>

<body class="gray-bg">
    <div class="wrapper wrapper-content">
        <div class="row">
                   <div class="col-sm-3">
                <div class="widget style1 lazur-bg">
                    <div class="row">
                        <div class="col-xs-4">
                            <i class="fa fa-file-word-o fa-5x"></i>
                        </div>
                        <div class="col-xs-8 text-right">
                            <span> 资源总数 </span>
                            <h2 class="font-bold"><%=CloudSQL.GetMyWJ() %></h2>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-3">
                <div class="widget style1 lazur-bg">
                    <div class="row">
                        <div class="col-xs-4">
                            <i class="fa fa-desktop fa-5x"></i>
                        </div>
                        <div class="col-xs-8 text-right">
                            <span> 主机个数 </span>
                            <h2 class="font-bold"><%=CloudSQL.GetMyPC() %></h2>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-3">
                <div class="widget style1 lazur-bg">
                    <div class="row">
                        <div class="col-xs-4">
                            <i class="fa fa-eye fa-5x"></i>
                        </div>
                        <div class="col-xs-8 text-right">
                            <span> 展厅参观次数 </span>
                            <h2 class="font-bold"><%=Count %></h2>
                        </div>
                    </div>
                </div>
            </div>
         <div class="col-sm-3">
                <div class="widget style1 navy-bg">
                    <div class="row">
                        <div class="col-xs-4">
                            <i class="fa fa-comment-o fa-5x"></i>
                        </div>
                        <div class="col-xs-8">
                         <span> 最新公告 </span>
                         <p ><%#CloudSQL.GetTopNews() %></p>
                        </div>
                    </div>
                </div>
            </div>
            <%--<div class="col-sm-4">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>信息公告</h5>
                        
                    </div>
                    
                    <div class="ibox-content">
                        <div class="feed-activity-list">
                            <asp:Repeater ID="rep" runat="server" DataSource="<%#CloudSQL.ListNews() %>">
                                <ItemTemplate>
                                     <div class="feed-element">
                                <div>
                                    <small class="pull-right text-navy"><%#SysConfig.DateStringFromNow(((AnnNews)Container.DataItem).AddTime) %></small>
                                    <strong><%# ((AnnNews)Container.DataItem).Author%></strong>
                                    <div><%#SysConfig.GetStr1(((AnnNews)Container.DataItem).Contents,100)%></div>
                                    <small class="text-muted"><%# ((AnnNews)Container.DataItem).AddTime.GetDateTimeFormats('f')[0].ToString()%></small>
                                </div>
                            </div>
                                </ItemTemplate>
                            </asp:Repeater>                          
                            

                        </div>
                    </div>
                </div>
            </div>

            <div class="col-sm-8">

                <div class="row">
                    <div class="col-sm-6">
                        <div class="ibox float-e-margins">
                            <div class="ibox-title">
                                <h5>管理员登陆信息</h5>
                            </div>
                            <div class="ibox-content" >
                                <table class="table table-hover no-margins">
                                    <thead>
                                        <tr>
                                            <th>用户</th>
                                          
                                            <th>最后登陆时间</th>
                                           
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="user" runat="server" DataSource="<%#CloudSQL.GetMyUser() %>">
                                            <ItemTemplate>
                                            <tr>
                                           <td><%#((Admin_User)Container.DataItem).FullName %></td>
                                            <td><i class="fa fa-clock-o"></i> <%#((Admin_User)Container.DataItem).LastLoginTime.GetDateTimeFormats('f')[0].ToString() %></td>
                                            </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="ibox float-e-margins">
                            <div class="ibox-title">
                                <h5>最近更新的资源</h5>
                                
                            </div>
                            <div class="ibox-content" >
                                <ul class="todo-list m-t small-list ui-sortable">
                                     <asp:Repeater ID="Repeater1" runat="server" DataSource="<%#CloudSQL.NewsList() %>">
                                            <ItemTemplate>
                                    <li>
                                       
                                        <span class="m-l-xs"><%#((View_News)Container.DataItem).Title %></span>
                                        <small class="label label-primary"><i class="fa fa-clock-o"></i> <%#SysConfig.DateStringFromNow(((View_News)Container.DataItem).AddTime) %></small>
                                    </li>
                                      </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                

            </div>--%>


        </div>
        <div class="row">
           <div class="col-sm-12">
                <div class="ibox float-e-margins">
                     <%--<div class="ibox-title">
                        <h5>展厅开启次数</h5>
                    </div>--%>
                    <div class="ibox-content">
                        <div class="echarts" id="echarts-line-chart"></div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            
                 <div class="col-sm-6">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>展厅资料分析</h5>
                    </div>
                    <div class="ibox-content">
                        <div class="echarts" id="echarts-pie-chart"></div>
                    </div>
                </div>
            </div>
                     <div class="col-sm-6">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>资料分析</h5>
                    </div>
                    <div class="ibox-content">

                        <div class="echarts" id="echarts-bar-chart"></div>
                    </div>
                </div>
            </div>
        </div>


        
            
    </div>

    <!-- 全局js -->
    <script src="<%=SysConfig.Hui %>js/jquery.min.js?v=2.1.4"></script>
    <script src="<%=SysConfig.Hui %>js/bootstrap.min.js?v=3.3.6"></script>
    <script src="<%=SysConfig.Hui %>js/plugins/echarts/echarts-all.js"></script>
    <script src="<%=SysConfig.Hui %>js/content.js?v=1.0.0"></script>


    <script>
        $(document).ready(function () {
            var lineChart = echarts.init(document.getElementById("echarts-line-chart"));
            var lineoption = {
                title: {
                    text: '展厅开启月度分析'
                },
                tooltip: {
                    trigger: 'axis'
                },
                legend: {
                    data: ['开启次数']
                },
                grid: {
                    x: 40,
                    x2: 40,
                    y2: 24
                },
                calculable: true,
                xAxis: [
                    {
                        type: 'category',
                        boundaryGap: false,
                        data: [<%=GetNowYue()%>]
                    }
                ],
                yAxis: [
                    {
                        type: 'value',
                        axisLabel: {
                            formatter: '{value}次'
                        }
                    }
                ],
                series: [
                    {
                        name: '最高开启',
                        type: 'line',
                        data: [<%=GetCount()%>],
                        markPoint: {
                            data: [
                                { type: 'max', name: '最大值' },
                                { type: 'min', name: '最小值' }
                            ]
                        },
                        markLine: {
                            data: [
                                { type: 'average', name: '平均值' }
                            ]
                        }
                    }
                ]
            };
            lineChart.setOption(lineoption);
            $(window).resize(lineChart.resize);

            var pieChart = echarts.init(document.getElementById("echarts-pie-chart"));
            var pieoption = {
                title: {
                    text: '我的资料分析',
                    subtext: '资料分类',
                    x: 'center'
                },
                tooltip: {
                    trigger: 'item',
                    formatter: "{a} <br/>{b} : {c} ({d}%)"
                },
                legend: {
                    orient: 'vertical',
                    x: 'left',
                    data: ['视频', '图片', 'PPT', '网页']
                },
                calculable: true,
                series: [
                    {
                        name: '资料数量',
                        type: 'pie',
                        radius: '55%',
                        center: ['50%', '60%'],
                        data: [
                            { value: <%=GetFileCount(1)%>, name: '视频' },
                            { value: <%=GetFileCount(4)%>, name: '图片' },
                            { value: <%=GetFileCount(3)%>, name: 'PPT' },
                            { value: <%=GetFileCount(2)%>, name: '网页' },
                           
                        ]
                    }
                ]
            };
            pieChart.setOption(pieoption);
            $(window).resize(pieChart.resize);
            var barChart = echarts.init(document.getElementById("echarts-bar-chart"));
            var baroption = {
                title: {
                    text: '年度资料更新'
                },
                tooltip: {
                    trigger: 'axis'
                },
                legend: {
                    data: ['月更新数']
                },
                grid: {
                    x: 30,
                    x2: 40,
                    y2: 24
                },
                calculable: true,
                xAxis: [
                    {
                        type: 'category',
                        data: ['1月', '2月', '3月', '4月', '5月', '6月', '7月', '8月', '9月', '10月', '11月', '12月']
                    }
                ],
                yAxis: [
                    {
                        type: 'value'
                    }
                ],
                series: [
                    {
                        name: '更新量',
                        type: 'bar',
                        data: [<%=GetUp()%>],
                        markPoint: {
                            data: [
                                { type: 'max', name: '最大值' },
                                { type: 'min', name: '最小值' }
                            ]
                        },
                        markLine: {
                            data: [
                                { type: 'average', name: '平均值' }
                            ]
                        }
                    }
                    
                ]
            };
            barChart.setOption(baroption);

            window.onresize = barChart.resize;
        });
    </script>
  

</body>

</html>
