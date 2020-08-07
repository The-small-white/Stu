var userInfo = { userId: "ming", guidold: "" };   //用户会话信息
var counttxt = 0;
var chunkSize = 2000 * 1024;        //分块大小2000k
var stime = new Date().getTime();
(function ($) {
    // 当domReady的时候开始初始化
    $(function () {
        var $wrap = $('#uploader'),

            // 图片容器
            $queue = $('<ul class="filelist"></ul>')
                .appendTo($wrap.find('.queueList')),

            // 状态栏，包括进度和控制按钮
            $statusBar = $wrap.find('.statusBar'),

            // 文件总体选择信息。
            $info = $statusBar.find('.info'),
            $info2 = $statusBar.find('#info2'),
            // 上传按钮
            $upload = $wrap.find('.uploadBtn'),

            // 没选择文件之前的内容。
            $placeHolder = $wrap.find('.placeholder'),

            $progress = $statusBar.find('.progress').hide(),

            // 添加的文件数量
            fileCount = 0,

            //生成MD5的总数;
            md5count = 0,
            // 添加的文件总大小
            fileSize = 0,

            // 优化retina, 在retina下这个值是2
            ratio = window.devicePixelRatio || 1,

            // 缩略图大小
            thumbnailWidth = 110 * ratio,
            thumbnailHeight = 110 * ratio,

            // 可能有pedding, ready, uploading, confirm, done.
            state = 'pedding',

            // 所有文件的进度信息，key为file id
            percentages = {},
            // 判断浏览器是否支持图片的base64
            isSupportBase64 = (function () {
                var data = new Image();
                var support = true;
                data.onload = data.onerror = function () {
                    if (this.width != 1 || this.height != 1) {
                        support = false;
                    }
                }
                data.src = "data:image/gif;base64,R0lGODlhAQABAIAAAAAAAP///ywAAAAAAQABAAACAUwAOw==";
                return support;
            })(),

            // 检测是否已经安装flash，检测flash的版本
            flashVersion = (function () {
                var version;

                try {
                    version = navigator.plugins['Shockwave Flash'];
                    version = version.description;
                } catch (ex) {
                    try {
                        version = new ActiveXObject('ShockwaveFlash.ShockwaveFlash')
                            .GetVariable('$version');
                    } catch (ex2) {
                        version = '0.0';
                    }
                }
                version = version.match(/\d+/g);
                return parseFloat(version[0] + '.' + version[1], 10);
            })(),

            supportTransition = (function () {
                var s = document.createElement('p').style,
                    r = 'transition' in s ||
                        'WebkitTransition' in s ||
                        'MozTransition' in s ||
                        'msTransition' in s ||
                        'OTransition' in s;
                s = null;
                return r;
            })(),

            // WebUploader实例
            uploader,
            GUID = WebUploader.Base.guid(); //当前页面是生成的GUID作为标示

        //使用状态来操作验证，秒传，需要秒传才打开
        function getServer(type) {   //测试用，根据不同类型的后端返回对应的请求地址
            switch (type) {
                case "php": return "./fileUpload.php"
                case "net": return "/Plusbe2019_Admin/MingApp/server/webup.aspx";
                case "java": return "http://localhost:8080/fileUpload";
                case "dubbo": return "http://127.0.0.1:8888/fileUpload";
            }
        }

        var backEndUrl = getServer("net");

        WebUploader.Uploader.register({
            "before-send-file": "beforeSendFile"
            , "before-send": "beforeSend"
            , "after-send-file": "afterSendFile"
        }, {
                beforeSendFile: function (file) {
                    //秒传验证
                    var task = new $.Deferred();
                    var start = new Date().getTime();
                (new WebUploader.Uploader()).md5File(file, 0, 10 * 1024 * 1024).progress(function (percentage) {
                        //console.log(percentage);
                    }).then(function (val) {
                        console.log("生成【" + file.name + "】的MD5【" + val + "】耗时: " + ((new Date().getTime()) - start) / 1000);
                        stime = new Date().getTime();
                        md5Mark = val;
                        file.md5 = val;
                        //userInfo.md5 = val;
                        file.md5 = val;//把当前MD5值存入文件定义中，避免和下一文件的MD5冲突

                        $.ajax({
                            type: "GET"
                            , url: backEndUrl
                            , data: {
                                status: "md5Check"
                                , md5: val
                                , size: file.size
                                , ext: file.ext
                            }
                            , cache: false
                            , timeout: 1000 //todo 超时的话，只能认为该文件不曾上传过
                            , dataType: "json"
                        }).then(function (data, textStatus, jqXHR) {
                            console.log("返回的数据:");
                            if (data.ifExist) {   //若存在，这返回失败给WebUploader，表明该文件不需要上传
                                //console.log("存在！");
                                //console.log(data.ifExist);
                                task.reject();
                                uploader.skipFile(file);
                                file.path = data.path;
                                file.statusText = "mfile";
                                console.log(file.statusText);
                                UploadComlate(file, data.path);//上传结束，等待合并
                            } else {
                                //console.log("不存在！");
                                //console.log(data.ifExist);
                                task.resolve();
                                //拿到上传文件的唯一名称，用于断点续传
                                //uniqueFileName = md5('' + userInfo.userId + file.name + file.type + file.lastModifiedDate + file.size);
                                uniqueFileName = file.md5;
                                userInfo.md5 = file.md5;
                                filesize = file.size;
                                fileext = file.ext;
                            }
                        }, function (jqXHR, textStatus, errorThrown) {    //任何形式的验证失败，都触发重新上传
                            console.log("重新上传文件！" + errorThrown);
                            task.resolve();
                            //拿到上传文件的唯一名称，用于断点续传
                            uniqueFileName = file.md5;
                            userInfo.md5 = file.md5;
                            filesize = file.size;
                            fileext = file.ext;
                        });
                    });
                    return $.when(task);
                }
                , beforeSend: function (block) {
                    //分片验证是否已传过，用于断点续传
                    var task = new $.Deferred();
                    $.ajax({
                        type: "GET"
                        , url: backEndUrl
                        , data: {
                            status: "chunkCheck"
                            , name: uniqueFileName
                            , chunkIndex: block.chunk
                            , size: block.end - block.start
                            , filesize: filesize
                            , ext: fileext
                        }
                        , cache: false
                        , timeout: 1000 //todo 超时的话，只能认为该分片未上传过
                        , dataType: "json"
                    }).then(function (data, textStatus, jqXHR) {
                        if (data.ifExist) {   //若存在，返回失败给WebUploader，表明该分块不需要上传
                            task.reject();
                        } else {
                            task.resolve();
                        }
                    }, function (jqXHR, textStatus, errorThrown) {    //任何形式的验证失败，都触发重新上传
                        task.resolve();
                    });

                    return $.when(task);
                }
                /*, afterSendFile: function(file){
                    var chunksTotal = 0;
                    if((chunksTotal = Math.ceil(file.size/chunkSize)) > 1){
                        //合并请求
                        var task = new $.Deferred();
                        $.ajax({
                            type: "GET"
                            , url: backEndUrl
                            , data: {
                                status: "chunksMerge"
                                , name: file.name
                                , chunks: chunksTotal
                                , ext: file.ext
                                , md5: file.md5
                                , size: file.size
                                
                            }
                            , cache: false
                            , dataType: "json"
                        }).then(function(data, textStatus, jqXHR){

                            //todo 检查响应是否正常

                            task.resolve();
                            file.path = data.path;
                            UploadComlate(file);

                        }, function(jqXHR, textStatus, errorThrown){
                            task.reject();
                        });

                        return $.when(task);
                    }else{
                        UploadComlate(file);
                    }
                }*/
            });
        function UploadComlate(file, path) {
            //console.log(file);
            counttxt++;
            $info2.html('<br><font color=blue>' + counttxt + '.【' + file.name + '】上传完成【' + path + '】,用时：' + ((new Date().getTime()) - stime) / 1000 + '秒!' + '</font>' + $info2.html());
            //$("#" + file.id + " .percentage").text("上传完毕,用时：" + ((new Date().getTime()) - stime) / 1000+"秒!");
            //$(".itemStop").hide();
            //$(".itemUpload").hide();
            //$(".itemDel").hide();
            console.log(file.size)
            var uploadfiles = document.getElementById("upload");
            var Size = document.getElementById("Size");
            if (!uploadfiles.value) {
                uploadfiles.value += path.substr(13);
                Size.value += file.size;
            } else {
                uploadfiles.value += "|" + path.substr(13);
                Size.value += "|" + file.size;
            }
            console.log(uploadfiles.value)
        }
        //秒传验证功能结束








        if (!WebUploader.Uploader.support('flash') && WebUploader.browser.ie) {

            // flash 安装了但是版本过低。
            if (flashVersion) {
                (function (container) {
                    window['expressinstallcallback'] = function (state) {
                        switch (state) {
                            case 'Download.Cancelled':
                                alert('您取消了更新！')
                                break;

                            case 'Download.Failed':
                                alert('安装失败')
                                break;

                            default:
                                alert('安装已成功，请刷新！');
                                break;
                        }
                        delete window['expressinstallcallback'];
                    };

                    var swf = 'Scripts/expressInstall.swf';
                    // insert flash object
                    var html = '<object type="application/' +
                        'x-shockwave-flash" data="' + swf + '" ';

                    if (WebUploader.browser.ie) {
                        html += 'classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" ';
                    }

                    html += 'width="100%" height="100%" style="outline:0">' +
                        '<param name="movie" value="' + swf + '" />' +
                        '<param name="wmode" value="transparent" />' +
                        '<param name="allowscriptaccess" value="always" />' +
                        '</object>';

                    container.html(html);

                })($wrap);

                // 压根就没有安转。
            } else {
                $wrap.html('<a href="http://www.adobe.com/go/getflashplayer" target="_blank" border="0"><img alt="get flash player" src="http://www.adobe.com/macromedia/style_guide/images/160x41_Get_Flash_Player.jpg" /></a>');
            }

            return;
        } else if (!WebUploader.Uploader.support()) {
            alert('Web Uploader 不支持您的浏览器！');
            return;
        }

        // 实例化
        uploader = WebUploader.create({
            pick: {
                id: '#filePicker',
                label: '点击选择文件'
            },
            formData: {
                uid: 123
            },
            dnd: '#dndArea',
            paste: '#uploader',
            accept: {
                title: 'Files',
                extensions: 'jpg,jpeg,png,ppt,pptx,pps,ppsx,mp3,mp4,mpe,mpeg,mpg,mkv,mov,avi,flv,rmvb,wmv,wma,rm,swf,PNG,JGP,JPEG,pdf,txt',

            },
            swf: '/Plusbe2019_Admin/MingApp/Scripts/Uploader.swf',
            chunked: true, //分片处理大文件
            chunkSize: chunkSize,
            server: '/Plusbe2019_Admin/MingApp/server/webup.aspx',
            disableGlobalDnd: true,
            threads: 10, //上传并发数
            //由于Http的无状态特征，在往服务器发送数据过程传递一个进入当前页面是生成的GUID作为标示
            formData: function () { return $.extend(true, {}, userInfo); },
            fileNumLimit: 300,
            compress: false, //图片在上传前不进行压缩
            fileSizeLimit: 4000 * 1024 * 1024,    // 4G M
            fileSingleSizeLimit: 2000 * 1024 * 1024    //2G
        });


        $(document).ready(function () {

            var uploadfiles = document.getElementById("upload");
            var Size = document.getElementById("Size");
            var res = uploadfiles.value;
            var list = res.split("|");
            var Sizelist = Size.value.split("|");
            for (var i = 0; i < list.length; i++) {
                var obj = {};
                obj.name = list[i];
                obj.size = Number(Sizelist[i]);
                //obj.lastModifiedDate = item.createTime;
                //obj.id = item.id;
                //obj.ext = item.fileType.substr(1);

                var file = new WebUploader.File(obj);
                //此处是关键，将文件状态改为'已上传完成'
                file.setStatus('complete')
                uploader.addFile(file);
            }
        });

        // 拖拽时不接受 js, txt 文件。
        uploader.on('dndAccept', function (items) {
            var denied = false,
                len = items.length,
                i = 0,
                // 修改js类型
                unAllowed = 'text/plain;application/javascript ';

            for (; i < len; i++) {
                // 如果在列表里面
                if (~unAllowed.indexOf(items[i].type)) {
                    denied = true;
                    break;
                }
            }

            return !denied;
        });

        uploader.on('beforeFileQueued', function (file) {
            //$upload.removeClass('disabled');

            //$upload.addClass('disabled');
            //$upload.text('上传准备..');
            //if(fileCount==md5count)
            //{
            //$upload.removeClass('disabled');
            //$upload.text('开始上传');
            // }

        });
        uploader.on('fileDequeued', function () {
            md5count--;
        });
        uploader.on('fileQueued', function (file) {
            //uploader.md5File(file)
            //uploader.md5File(file, 0, 10 * 1024)
            // 完成
            // .then(function (val) {
            //console.log('filecount:'+fileCount+',md5count:'+md5count+',md5:', val);
            //  GUID = val;
            //  file.md5 = val;
            //  md5count++;
            // userInfo.guid = val;
            var title = document.getElementById("title");
            if (!title) {

            } else {
                if (!title.value) {
                    title.value = file.name;
                }
                console.log(title.value)

                file.chunksize = chunkSize;
            }
            // if(fileCount==md5count)
            // {
            $upload.removeClass('disabled');
            $upload.text('开始上传');
            // }
            // });

        });
        uploader.on('dialogOpen', function () {
            //console.log('here');
        });

        // uploader.on('filesQueued', function() {
        //     uploader.sort(function( a, b ) {
        //         if ( a.name < b.name )
        //           return -1;
        //         if ( a.name > b.name )
        //           return 1;
        //         return 0;
        //     });
        // });

        // 添加“添加文件”的按钮，
        uploader.addButton({
            id: '#filePicker2',
            label: '继续添加'
        });

        uploader.on('ready', function () {
            window.uploader = uploader;
        });

        // 当有文件添加进来时执行，负责view的创建
        function addFile(file) {
            console.log(file)
            var $li = $('<li id="' + file.id + '">' +
                '<p class="title">' + file.name + '</p>' +
                '<p class="imgWrap"></p>' +
                '<p class="progress"><span></span></p>' +
                '</li>'),

                $btns = $('<div class="file-panel">' +
                    '<span class="cancel">删除</span>' +
                    '<span class="rotateRight">向右旋转</span>' +
                    '<span class="rotateLeft">向左旋转</span></div>').appendTo($li),
                $prgress = $li.find('p.progress span'),
                $wrap = $li.find('p.imgWrap'),
                $info = $('<p class="error"></p>'),

                showError = function (code) {
                    switch (code) {
                        case 'exceed_size':
                            text = '文件大小超出';
                            break;
                        case 'F_EXCEED_SIZE':
                            text = '单个文件大小超出限制';
                            break;
                        case 'interrupt':
                            text = '上传暂停';
                            break;
                        case 'error':
                            text = '上传失败，请重试';
                            break;
                        case 'Q_TYPE_DENIED':
                            text = '请上传图片视频ppt等文件格式';
                            break;
                        case 'mfile':
                            text = '文件秒传';
                            break;
                        default:
                            //console.log('错误代码：'+code+'【'+file.name+'|'+file.md5+'】');
                            text = '失败，验证中..';
                            //有错误情况，到服务器验证是错误，还是秒传文件 
                            $.get("/Plusbe2019_Admin/MingApp/server/webup.aspx", { status: "fileMerge", md5: file.md5, ext: file.ext, size: file.size },
                                function (data) {
                                    data = $.parseJSON(data);
                                    if (data.hasError) {
                                        text = '失败，请重试';
                                        $info.html(text).appendTo($li);
                                    } else {
                                        text = '<p style="background:#193366">' + data.f_ext + '</p>';
                                        $info.html(text).appendTo($li);
                                    }
                                });

                            //验证文件结束


                            break;
                    }

                    $info.text(text).appendTo($li);
                };

            if (file.getStatus() === 'invalid') {
                showError(file.statusText);
                //console.log('文件状态为文件不合格'+file.statusText);
            } else {
                // @todo lazyload
                $wrap.text('预览中');
                uploader.makeThumb(file, function (error, src) {
                    var img;
                    if (error)
                    {
                        $wrap.text('不能预览');
                        //alert(file.name);
                        if (file.name.length > 2) {
                            if (file.name.indexOf(".pptx") != -1 || file.name.indexOf(".ppt") != -1) $wrap.html('<a href="#" style="text-decoration-line: none;color: #666;" title="' + file.name + '">PPT文档</a>');
                            if (file.name.indexOf(".xlsx") != -1 || file.name.indexOf(".xls") != -1) $wrap.html('<a href="#" style="text-decoration-line: none;color: #666;" title="' + file.name + '">EXCEL文档</a>');
                            if (file.name.indexOf(".rar") != -1 || file.name.indexOf(".zip") != -1 || file.name.indexOf(".7z") != -1) $wrap.html('<a href="#" style="text-decoration-line: none;color: #666;" title="' + file.name + '">压缩文档</a>');
                            if (file.name.indexOf(".swf") != -1) $wrap.html('<a href="#" style="text-decoration-line: none;color: #666;" title="' + file.name + '">swf动画文档</a>');
                            if (file.name.indexOf(".pdf") != -1) $wrap.html('<a href="#" style="text-decoration-line: none;color: #666;" title="' + file.name + '">PDF文档</a>');

                            if (file.name.indexOf(".exe") != -1 || file.name.indexOf(".com") != -1) $wrap.html('<a href="#" style="text-decoration-line: none;color: #666;" title="' + file.name + '">可执行文件</a>');
                            if (file.name.indexOf(".docx") != -1 || file.name.indexOf(".doc") != -1) $wrap.html('<a href="#" style="text-decoration-line: none;color: #666;" title="' + file.name + '">Word文档</a>');
                            if (file.name.indexOf(".txt") != -1) $wrap.html('<a href="#" style="text-decoration-line: none;color: #666;" title="' + file.name + '">文本文档</a>');
                            if (file.name.indexOf(".html") != -1 || file.name.indexOf(".shtml") != -1 || file.name.indexOf(".html") != -1) $wrap.html('<a href="#" style="text-decoration-line: none;color: #666;" title="' + file.name + '">web网页文档</a>');
                            if (file.name.indexOf(".css") != -1) $wrap.html('<a href="#" style="text-decoration-line: none;color: #666;" title="' + file.name + '">web样式文档</a>');
                            if (file.name.indexOf(".js") != -1) $wrap.html('<a href="#" style="text-decoration-line: none;color: #666;" title="' + file.name + '">web脚本文档</a>');
                            if (file.name.indexOf(".mp4") != -1 || file.name.indexOf(".avi") != -1 || file.name.indexOf(".flv") != -1 || file.name.indexOf(".mpg") != -1 || file.name.indexOf(".mp4") != -1 || file.name.indexOf(".rm") != -1 || file.name.indexOf(".wmv") != -1 || file.name.indexOf(".rmvb") != -1 || file.name.indexOf(".mov") != -1) $wrap.html('<a href="#" style="text-decoration-line: none;color: #666;" title="' + file.name + '">视频文件</a>');
                            if (file.name.indexOf(".aif") != -1 || file.name.indexOf(".wma") != -1 || file.name.indexOf(".ram") != -1 || file.name.indexOf(".au") != -1 || file.name.indexOf(".mid") != -1 || file.name.indexOf(".mp3") != -1 || file.name.indexOf(".wav") != -1) $wrap.html('<a href="#" style="text-decoration-line: none;color: #666;" title="' + file.name + '">音频文件</a>');

                        }
                        return;
                    }
                    console.log(src);
                    if (isSupportBase64) {
                        if (src) {
                            img = $('<img src="' + src + '">');
                        } else {
                            img = $('<img src="../../UploadFiles/' + file.name + '">');
                            $li.append('<span class="success"></span>');
                            text = '<p style="background:#193366">' + '　' + '</p>';
                            $info.html(text).appendTo($li);
                        }
                        $wrap.empty().append(img);
                    } else {
                        $.ajax('preview.ashx', {
                            method: 'get',
                            data: src,
                            dataType: 'json'
                        }).done(function (response) {
                            if (response.result) {
                                img = $('<img src="' + response.result + '">');
                                $wrap.empty().append(img);
                            } else {
                                $wrap.text("预览出错");
                            }
                        });
                    }
                }, thumbnailWidth, thumbnailHeight);

                percentages[file.id] = [file.size, 0];
                file.rotation = 0;
            }

            file.on('statuschange', function (cur, prev) {
                if (prev === 'progress') {
                    $prgress.hide().width(0);
                } else if (prev === 'queued') {
                    //$li.off('mouseenter mouseleave');
                    //$btns.remove();
                }
                //console.log('文件状态改变:'+file.statusText+'cur:'+cur+'prev:'+prev);
                // 成功
                if (cur === 'error' || cur === 'invalid') {

                    showError(file.statusText);
                    percentages[file.id][1] = 1;
                } else if (cur === 'interrupt') {
                    showError('interrupt');
                } else if (cur === 'queued') {
                    $info.remove();
                    $prgress.css('display', 'block');
                    percentages[file.id][1] = 0;
                } else if (cur === 'progress') {
                    $info.remove();
                    $prgress.css('display', 'block');
                } else if (cur === 'complete') {
                    $prgress.hide().width(0);
                    $li.append('<span class="success"></span>');
                }

                $li.removeClass('state-' + prev).addClass('state-' + cur);
            });

            $li.on('mouseenter', function () {
                $btns.stop().animate({ height: 30 });
            });

            $li.on('mouseleave', function () {
                $btns.stop().animate({ height: 0 });
            });

            $btns.on('click', 'span', function () {
                var index = $(this).index(),
                    deg;

                switch (index) {
                    case 0:
                        uploader.removeFile(file);
                        return;

                    case 1:
                        file.rotation += 90;
                        break;

                    case 2:
                        file.rotation -= 90;
                        break;
                }

                if (supportTransition) {
                    deg = 'rotate(' + file.rotation + 'deg)';
                    $wrap.css({
                        '-webkit-transform': deg,
                        '-mos-transform': deg,
                        '-o-transform': deg,
                        'transform': deg
                    });
                } else {
                    $wrap.css('filter', 'progid:DXImageTransform.Microsoft.BasicImage(rotation=' + (~ ~((file.rotation / 90) % 4 + 4) % 4) + ')');
                    // use jquery animate to rotation
                    // $({
                    //     rotation: rotation
                    // }).animate({
                    //     rotation: file.rotation
                    // }, {
                    //     easing: 'linear',
                    //     step: function( now ) {
                    //         now = now * Math.PI / 180;

                    //         var cos = Math.cos( now ),
                    //             sin = Math.sin( now );

                    //         $wrap.css( 'filter', "progid:DXImageTransform.Microsoft.Matrix(M11=" + cos + ",M12=" + (-sin) + ",M21=" + sin + ",M22=" + cos + ",SizingMethod='auto expand')");
                    //     }
                    // });
                }


            });
            $li.appendTo($queue);
        }

        // 负责view的销毁
        function removeFile(file) {
            var $li = $('#' + file.id);

            delete percentages[file.id];
            updateTotalProgress();
            $li.off().find('.file-panel').off().end().remove();
        }

        function updateTotalProgress() {
            var loaded = 0,
                total = 0,
                spans = $progress.children(),
                percent;

            $.each(percentages, function (k, v) {
                total += v[0];
                loaded += v[0] * v[1];
            });

            percent = total ? loaded / total : 0;


            spans.eq(0).text(Math.round(percent * 100) + '%');
            spans.eq(1).css('width', Math.round(percent * 100) + '%');
            updateStatus();
        }

        function updateStatus() {
            var text = '', stats;

            if (state === 'ready') {
                text = '选中' + fileCount + '个文件，共' +
                    WebUploader.formatSize(fileSize) + '。';
            } else if (state === 'confirm') {
                stats = uploader.getStats();
                if (stats.uploadFailNum) {
                    text = '已成功上传' + stats.successNum + '个文件，' +
                        stats.uploadFailNum + '文件上传失败，<a class="retry" href="#">重新上传</a>失败文件或<a class="ignore" href="#">忽略</a>'
                }

            } else {
                stats = uploader.getStats();
                text = '共' + fileCount + '个（' +
                    WebUploader.formatSize(fileSize) +
                    '），已上传' + stats.successNum + '个';

                if (stats.uploadFailNum) {
                    text += '，失败' + stats.uploadFailNum + '个';
                }
            }

            $info.html(text);
        }

        function setState(val) {
            var file, stats;

            if (val === state) {
                return;
            }

            $upload.removeClass('state-' + state);
            $upload.addClass('state-' + val);
            state = val;

            switch (state) {
                case 'pedding':
                    $placeHolder.removeClass('element-invisible');
                    $queue.hide();
                    $statusBar.addClass('element-invisible');

                    uploader.refresh();
                    break;

                case 'ready':
                    $placeHolder.addClass('element-invisible');
                    $('#filePicker2').removeClass('element-invisible');
                    $queue.show();
                    $statusBar.removeClass('element-invisible');
                    //$upload.addClass('disabled');
                    //$upload.text('上传准备..');

                    uploader.refresh();
                    break;

                case 'uploading':
                    $('#filePicker2').addClass('element-invisible');
                    $progress.show();

                    $upload.text('暂停上传');
                    break;

                case 'paused':
                    $progress.show();
                    uploader.stop(true);
                    $upload.text('继续上传');
                    break;

                case 'confirm':
                    $progress.hide();
                    $('#filePicker2').removeClass('element-invisible');
                    $upload.text('开始上传');

                    stats = uploader.getStats();
                    if (stats.successNum && !stats.uploadFailNum) {
                        setState('finish');
                        return;
                    }
                    break;
                case 'finish':
                    stats = uploader.getStats();
                    if (stats.successNum) {
                        var txt1 = '';
                        txt1 = '共' + fileCount + '个（' +
                            WebUploader.formatSize(fileSize) +
                            '），已上传' + stats.successNum + '个';

                        if (stats.uploadFailNum) {
                            txt1 += '，失败' + stats.uploadFailNum + '个';
                        }
                        //$info2.html('上传完成');
                        //counttxt++;
                        $info2.html('<br><font color=blue><b>上传任务完成!</b>' + txt1 + '</font>' + $info2.html());
                        //alert('上传完成');
                    } else {
                        // 没有成功的图片，重设
                        state = 'done';
                        location.reload();
                    }
                    break;
            }

            updateStatus();
        }

        uploader.onUploadProgress = function (file, percentage) {
            var $li = $('#' + file.id),
                $percent = $li.find('.progress span');

            $percent.css('width', percentage * 100 + '%');
            percentages[file.id][1] = percentage;
            updateTotalProgress();
        };

        uploader.onFileQueued = function (file) {
            fileCount++;
            fileSize += file.size;

            if (fileCount === 1) {
                $placeHolder.addClass('element-invisible');
                $statusBar.show();
            }

            addFile(file);
            setState('ready');
            updateTotalProgress();
        };

        uploader.onFileDequeued = function (file) {
            fileCount--;
            fileSize -= file.size;

            if (!fileCount) {
                setState('pedding');
            }

            removeFile(file);
            updateTotalProgress();

        };

        //all算是一个总监听器
        uploader.on('all', function (type, arg1, arg2) {
            //console.log("all监听：", type, arg1, arg2);
            var stats;
            switch (type) {
                case 'uploadFinished':
                    setState('confirm');
                    break;

                case 'startUpload':
                    setState('uploading');
                    break;

                case 'stopUpload':
                    setState('paused');
                    break;

            }
        });

        // 文件上传成功,合并文件。
        uploader.on('uploadSuccess', function (file, response) {
            console.log("监听：", response);
            if (response == 'undefined' || response == '' || response == null) {
                counttxt++;
                //showError("error");
                file.statusText = "error";
                $info2.html('<br><font color=red>' + counttxt + '.<b>【' + file.name + '】上传结束，但未获取到服务器数据！</b>' + '</font>' + $info2.html());
            }
            else {
                if (response.chunked) {
                    var chunksTotal = 0;
                    var fsize = file.size;
                    var uploadfiles = document.getElementById("upload");
                    var Size = document.getElementById("Size");
                    if (!uploadfiles.value) {
                        uploadfiles.value += file.md5 + "." + file.ext;
                        Size.value += file.size;
                    } else {
                        uploadfiles.value += "|" + file.md5 + "." + file.ext;
                        Size.value += "|" + file.size;
                    }
                    if ((chunksTotal = Math.ceil(file.size / chunkSize)) > 1) {
                        counttxt++;
                        $info2.html('<br><font color=blue>' + counttxt + '.【' + file.name + '】文件合并开始...' + '</font>' + $info2.html());
                        $.get("/Plusbe2019_Admin/MingApp/server/webup.aspx", { status: "chunksMerge", md5: file.md5, ext: file.ext, name: file.name, chunks: chunksTotal, size: fsize },
                            function (data) {
                                data = $.parseJSON(data);
                                if (data.hasError) {
                                    //alert('文件合并失败！');
                                    //file.Status='error';
                                    //showError("error");
                                    counttxt++;
                                    file.statusText = "error";
                                    $info2.html('<br>' + counttxt + '.【' + file.name + '"】文件合并失败: ' + data.f_ext + $info2.html());
                                    //$info2.html('文件合并失败');
                                    //file.getStatus=4;
                                } else {
                                    //alert(decodeURIComponent(data.savePath));
                                    counttxt++;
                                    $info2.html('<br><font color=blue>' + counttxt + '.【' + file.name + '】文件合并成功: ' + decodeURIComponent(data.path) + '</font>' + $info2.html());
                                    console.log(data.hasError);
                                    //var uploadfiles = document.getElementById("upload");
                                    //var Size = document.getElementById("Size");
                                    //if (!uploadfiles.value) {
                                    //    uploadfiles.value += file.md5 + "." + file.ext;
                                    //    Size.value += file.size;
                                    //} else {
                                    //    uploadfiles.value += "|" + file.md5 + "." + file.ext;
                                    //    Size.value += "|" + file.size;
                                    //}

                                }
                            });
                    }
                }
                else {
                    var uploadfiles = document.getElementById("upload");
                    var Size = document.getElementById("Size");
                    if (!uploadfiles.value) {
                        uploadfiles.value += file.md5 + "." + file.ext;
                        Size.value += file.size;
                    } else {
                        uploadfiles.value += "|" + file.md5 + "." + file.ext;
                        Size.value += "|" + file.size;
                    }
                }
            }
        });

        uploader.onError = function (code) {
            //alert('Eroor: ' + code);
            counttxt++;
            console.log(counttxt);
            console.log(code);
            if (code == "Q_TYPE_DENIED" && counttxt != "1")
            {
                layer.msg("请上传图片,视频,PPT格式的文件");
            }
            $info2.html('<br><b>' + counttxt + '.【错误提示】: ' + code + '</b>' + $info2.html());
        };

        $upload.on('click', function () {
            if ($(this).hasClass('disabled')) {
                return false;
            }

            if (state === 'ready') {
                uploader.upload();
            } else if (state === 'paused') {
                uploader.upload();
            } else if (state === 'uploading') {
                uploader.stop();
            }
        });

        $info.on('click', '.retry', function () {
            uploader.retry();
        });

        $info.on('click', '.ignore', function () {
            alert('todo');
        });

        $upload.addClass('state-' + state);
        updateTotalProgress();
    });

})(jQuery);
