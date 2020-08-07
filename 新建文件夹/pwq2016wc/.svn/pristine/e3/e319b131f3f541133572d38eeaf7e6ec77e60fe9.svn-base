<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view.aspx.cs" Inherits="Plusbe2019_Admin_CloudNews_view" %>

<!doctype html>
<html lang="en">

<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">


    <link rel="shortcut icon" href="<%=SysConfig.Hui %>favicon.ico"> 
    <link href="<%=SysConfig.Hui %>css/bootstrap.min.css?v=3.3.6" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/font-awesome.css?v=4.4.0" rel="stylesheet">
    <link href="<%=SysConfig.Hui %>css/style.css?v=4.1.0" rel="stylesheet">
    <link rel="stylesheet" href="<%=SysConfig.Hui %>css/plugins/plyr/plyr.css">
    <style type="text/css">
iframe {
    margin: 0;
    border-style: none;
    width: 100%;
    height: 100%;
}
</style>
</head>

<body class="gray-bg">
    <div class="alert alert-info">
         预览（视频格式支持mp4,ppt预览需域名支持）：<%#news.Title %>
     </div>
    <%if (news.FileType == 3)
        { %>
        <iframe src='https://view.officeapps.live.com/op/view.aspx?src=http://storage.xuetangx.com/UploadFiles/<%#news.Files %>' width='100%' height='100%' frameborder='1'>
        </iframe>
    <%}
    else if (news.FileType == 2)
    { %>
      <iframe src='<%#news.Files %>' width='100%' height='100%' frameborder='1'>
                     </iframe>
    <%}
    else
    {%>
    <div class="wrapper animated fadeInRight">
        <div class="row">
            
            <div class="col-sm-12">
                <%if (news.FileType == 1)
                    { %>
                <div class="ibox float-e-margins">
                    <div class="ibox-content">
                        <div class="player">
                            <video poster="" controls crossorigin>
                                <!-- Video files -->
                                <source src="/UploadFiles/<%#news.Files %>" type="video/mp4">
                              

                                <!-- Text track file -->
                               
                                    <!-- Fallback for browsers that don't support the <video> element -->
                                   
                            </video>
                        </div>
                    </div>
                </div>
                <%}
                    else if (news.FileType == 4)
                    { %>
                 <div class="ibox-content ">
                        <div class="carousel slide" id="carousel2">
               
                            <div class="carousel-inner">
                                <asp:Repeater ID="pic" runat="server">
                                    <ItemTemplate>
                                       <div class="item <%#Container.ItemIndex==0?"active":"" %>">
                                       <img alt="image" class="img-responsive" src="/UploadFiles/<%# GetDataItem()%>">
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <a data-slide="prev" href="carousel.html#carousel2" class="left carousel-control">
                                <span class="icon-prev"></span>
                            </a>
                            <a data-slide="next" href="carousel.html#carousel2" class="right carousel-control">
                                <span class="icon-next"></span>
                            </a>
                        </div>
                    </div>
                <%}%>
                    
                </div>
            
        </div>
    </div>
    <%} %>
    
    <script>
        (function (d, u) {
            var a = new XMLHttpRequest(),
                b = d.body;

            // Check for CORS support
            // If you're loading from same domain, you can remove the if statement
            if ("withCredentials" in a) {
                a.open("GET", u, true);
                a.send();
                a.onload = function () {
                    var c = d.createElement("div");
                    c.setAttribute("hidden", "");
                    c.innerHTML = a.responseText;
                    b.insertBefore(c, b.childNodes[0]);
                }
            }
        })(document, "<%=SysConfig.Hui %>css/plugins/plyr/sprite.svg");
    </script>

    <!-- Plyr core script -->
    <script src="<%=SysConfig.Hui %>js/plugins/plyr/plyr.js"></script>
    <script>
        plyr.setup();
    </script>

    <!-- 全局js -->
    <script src="<%=SysConfig.Hui %>js/jquery.min.js?v=2.1.4"></script>
    <script src="<%=SysConfig.Hui %>js/bootstrap.min.js?v=3.3.6"></script>

    <!-- 自定义js -->
    <script src="<%=SysConfig.Hui %>js/content.js?v=1.0.0"></script>

    <!--统计代码，可删除-->
</body>

</html>

