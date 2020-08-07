(function (jQuery) {
    jQuery.fn.fcupInitialize = function () {

        return this.each(function () {

            var button = jQuery(this),
                fcup = 0;
            if (!jQuery.uploading) {
                jQuery.uploading = '上传中...';
            }
            if (!jQuery.upfinished) {
                jQuery.upfinished = '上传完成';
            }
            var options = jQuery.extend({
                loading: jQuery.uploading,
                finished: jQuery.upfinished
            },
                button.data());

            button.attr({
                'data-loading': options.loading,
                'data-finished': options.finished
            });
            var bar = jQuery('<span class="tz-bar background-horizontal">').appendTo(button);
            button.on('fcup',
                function (e, val, absolute, finish) {

                    if (!button.hasClass('in-fcup')) {
                        bar.show();
                        fcup = 0;
                        button.removeClass('finished').addClass('in-fcup');
                    }
                    if (absolute) {
                        fcup = val;
                    } else {
                        fcup += val;
                    }

                    if (fcup >= 100) {
                        fcup = 100;
                    }

                    if (finish) {

                        button.removeClass('in-fcup').addClass('finished');

                        bar.delay(500).fadeOut(function () {
                            button.trigger('fcup-finish');
                            setProgress(0);
                        });

                    }

                    setProgress(fcup);
                });

            function setProgress(percentage) {
                bar.filter('.background-horizontal,.background-bar').width(percentage + '%');
                bar.filter('.background-vertical').height(percentage + '%');
            }

        });

    };

    jQuery.fn.fcupStart = function () {
        var button = this.first(),
            last_fcup = new Date().getTime();
        if (button.hasClass('in-fcup')) {
            return this;
        }
        button.on('fcup',
            function () {
                last_fcup = new Date().getTime();
            });
        var interval = window.setInterval(function () {

            if (new Date().getTime() > 2000 + last_fcup) {

                button.fcupIncrement(5);
            }

        },
            500);

        button.on('fcup-finish',
            function () {
                window.clearInterval(interval);
            });

        return button.fcupIncrement(10);
    };

    jQuery.fn.fcupFinish = function () {
        return this.first().fcupSet(100);
    };

    jQuery.fn.fcupIncrement = function (val) {

        val = val || 10;

        var button = this.first();

        button.trigger('fcup', [val]);

        return this;
    };

    jQuery.fn.fcupSet = function (val) {
        val = val || 10;

        var finish = false;
        if (val >= 100) {
            finish = true;
        }

        return this.first().trigger('fcup', [val, true, finish]);
    };

})(jQuery);