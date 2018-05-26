$(document).ready(function () {
    //移到底部
    $(".showDetailTable :text:not(:disabled)").each(function (k, v) {
        var ele = $(v);
        var name = ele.attr('name');
        if (name != undefined) {
            if (name.indexOf('Start') > -1 || name.indexOf('End') > -1 || name.indexOf('Day') > -1 || name.indexOf('Date') > -1 || name.indexOf('Time') > -1) {
                ele.addClass("Wdate");
                ele.bind("click", function () {
                    WdatePicker();
                });
            }
        }
    });

    $(".showDetailTable :text").each(function (k, v) {
        var ele = $(v);
        var name = ele.attr('name');
        if (name != undefined) {
            if (name.indexOf('Start') > -1 || name.indexOf('End') > -1 || name.indexOf('Day') > -1 || name.indexOf('Date') > -1 || name.indexOf('Time') > -1) {
                ele.addClass("Wdate");
                ele.bind("click", function () {

                    WdatePicker();
                });
            }
        }
    });

    $(".showDetailTableMultiColumnm :text").each(function (k, v) {
        var ele = $(v);
        var name = ele.attr('name');
        if (name != undefined) {
            if (name.indexOf('Start') > -1 || name.indexOf('End') > -1 || name.indexOf('Day') > -1 || name.indexOf('Date') > -1 || name.indexOf('Time') > -1) {
                ele.addClass("Wdate");
                ele.bind("click", function () {

                    WdatePicker();
                });
            }
        }
    });

    $(".resultTable tbody tr").mouseover(function () {
        $(this).css("background", "silver").siblings().css("background", "");
    });

    setInterval("timer()", 1);
});

//组装
function timer() {
    var time = curentTime();
    var week = getWeek();

    $("#currentTime").text(time);
    $("#currentWeek").text(week);
}

//获取年月日时分秒
function curentTime() {
    var now = new Date();

    var year = now.getFullYear();       //年
    var month = now.getMonth() + 1;     //月
    var day = now.getDate();            //日
    var hh = now.getHours();            //时
    var mm = now.getMinutes();          //分
    var ss = now.getSeconds();          //秒

    if (month < 10)
        month = "0" + month;
    if (day < 10)
        day = "0" + day;
    if (hh < 10)
        hh = "0" + hh;
    if (mm < 10)
        mm = '0' + mm;
    if (ss < 10)
        ss = '0' + ss;

    var clock = year + "-" + month + "-" + day + "  " + hh + ":" + mm + ":" + ss;
    return (clock);
}

//获取星期
function getWeek() {
    var date = new Date();
    var week = date.getDay();
    var pre = "星期";

    var showWeek = '';
    switch (week) {
        case 0:
            showWeek = "日";
            break;
        case 1:
            showWeek = "一";
            break;
        case 2:
            showWeek = "二";
            break;
        case 3:
            showWeek = "三";
            break;
        case 4:
            showWeek = "四";
            break;
        case 5:
            showWeek = "五";
            break;
        case 6:
            showWeek = "六";
            break;
        default:
            showWeek = "";
            break;
    }

    return pre + showWeek;
}

//隐藏左边菜单栏
var temp = 0;
function show_menuC() {
    if (temp == 0) {
        $('#LeftBox').hide();
        $('#RightBox').css("margin-left", '0');
        $('#Mobile').css("background", '~/Content/Images/center.gif');
        temp = 1;
    } else {
        $('#LeftBox').show();
        $('#RightBox').css("margin-left", '222px');
        $('#Mobile').css("background", '~/Content/Images/center0.gif');
        temp = 0;
    }
}

//显示菜单下拉列表
function show_menuB(that) {
    var brothers = $(that).parent().parent().siblings();
    var len = brothers.length;
    var flag;
    for (var i = 0; i < len; i++) {
        var iFlag = $(brothers[i]).css("display");
        if (iFlag == "block") {
            flag = true;
        }
        if (flag) {
            $(brothers[i]).hide();
        } else {
            $(brothers[i]).show();
        }
    }
}

function logOut() {
    if (window.confirm("确定退出吗?")) {
        $.ajax({
            url: "/Home/LogOut",
            type: "post",
            success: function (res) {
                if (res.Key) {
                    location.reload().href("/Home/Index");
                }
            }
        });
    }
}

var dialog;
function changePwd() {
    dialog = $.Zebra_Dialog("", {
        'type': '', //- confirmation error information question warning
        'modal': true,
        'overlay_close': false,
        'custom_class': 'dialog',
        'overlay_opacity': 0.5,
        'width': 500,
        'title': '修改密码',
        'buttons': false, //'buttons': ['确定', '取消'],
        'source': {
            //'ajax':{url:'url','cache':false}
            'iframe': {
                'src': '/Home/ChangePassword',
                'height': 270,
                'frameborder': 0,
                'scrolling': 'no'
            }
        },
    });
}

function reloadPage() {
    window.location.href = window.location.href;
}

(function ($) {
	$.psAlert = function (info, type,setting,title) {
		var alerttype = '';
		var alerttitle = '';
		switch (type) {
			case 1:
				alerttype = 'error';
				alerttitle = '错误提示';
				break;
			case 2:
				alerttype = 'warning';
				alerttitle = '警告提示';
				break;
			case 3:
				alerttype = 'information';
				alerttitle = '消息提示';
				break;
			case 4:
				alerttype = 'confirmation';
				alerttitle = '正确提示';
				break;
			default:
				alerttitle = title;
				break;
		}
		var defaults = {
			'type': alerttype,
			'title': alerttitle
		};
		var opts = $.extend(defaults, setting);
		new $.Zebra_Dialog(info, opts);
	};
})(jQuery);
