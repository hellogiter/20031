
Ext.onReady(function () {
    setTimeout(function () {
        var detailWindow = Ext.getCmp("detailWindow");
        if (detailWindow) {
            detailWindow.width = 850;
            detailWindow.height = 550;
        }
    }, 500);
});

function xalert(msg) {
    Ext.net.Notification.show({
        title: '提示',
        iconCls: '#Information',
        pinEvent: 'click',
        html: "<div style='padding:10px;font-size:12px;'>" + msg + '</div>',
        height: 125,
        width: 250
    });
};

function notifyMsg(title, msg) {
    Ext.net.Notification.show({
        iconCls: 'icon-information',
        hideFx: {
            args: ['r', {}],
            fxName: 'slideOut'
        },
        showFx: {
            args: ['r', {}],
            fxName: 'slideIn'
        },
        pinEvent: 'click',
        bodyStyle: 'padding:10px',
        shadow: false,
        title: title,
        html: msg,
        height: 150,
        width: 300
    });
}

function xwarning(msg) {
    Ext.MessageBox.show({
        title: '警告',
        msg: msg,
        buttons: Ext.MessageBox.OK,
        icon: Ext.MessageBox.WARNING
    });
};

function isURL(v) {
    var url = /(((^https?)|(^ftp)):\/\/((([\-\w]+\.)+\w{2,3}(\/[%\-\w]+(\.\w{2,})?)*(([\w\-\.\?\\\/+@&#;`~=%!]*)(\.\w{2,})?)*)|(localhost|LOCALHOST))\/?)/i;
    return url.test(v);
}

function Request() {
    var url = location.search; //获取url中"?"符后的字串
    var theRequest = new Object();
    if (url.indexOf("?") != -1) {
        var str = url.substr(1);
        if (str.indexOf("&") != -1) {
            strs = str.split("&");
            for (var i = 0; i < strs.length; i++) {
                theRequest[strs[i].split("=")[0]] = unescape(strs[i].split("=")[1]);
            }
        } else {
            theRequest[str.split("=")[0]] = unescape(str.split("=")[1]);
        }
    }
    return theRequest;
}

function renderBool(a) {
    var t = typeof (a);
    switch (t) {
        case "string":
            if (a == "true") {
                return "是";
            }
            break;
        case "boolean":
            if (a) {
                return "是";
            }
            break;
    }
    return "否";
}

function renderText(a) {
    return X.String.ellipsis(a, 20, '...');
}

function renderHTML(a) {
    return X.String.htmlDecode(a);
}

//展示性别列
function renderSex(a) {
    var r;
    switch (a) {
        case 0:
            r = '未知';
            break;
        case 1:
            r = '男';
            break;
        case 2:
            r = '女';
            break;
        default:
            r = '未知';
            break;
    }
    return r;
}

Ext.Object.merge(Ext.util, {
    //控件的显示隐藏
    cmpToggle: function (id) {
        var cmp = Ext.getCmp(id);
        if (cmp) {
            if (cmp.isVisible()) {
                cmp.hide();
            } else {
                cmp.show();
            }
        }
    }
});

if (typeof (UE) != 'undefined') {
    Ext.Object.merge(UE, {
        imageDialog: function showImageDialog(editor, targetId, limit) {

            if (typeof (limit) === "undefined" || limit <= 0) {
                limit = 10;
            }

            var beforeInsertImage = function (t, arg) {

                if (typeof (arg) == 'undefined') {
                    xwarning("返回对象为undefined");
                    return false;
                }

                if (arg.length > limit) {
                    xwarning("选择图片不能超过" + limit + "张。");
                    return false;
                }

                var targetCmp = X.getCmp(targetId);
                var val = Ext.Array.pluck(arg, "src").join(',');
                targetCmp.setValue(val);
                editor.removeListener("beforeInsertImage", beforeInsertImage);
                return false;
            };

            editor.addListener('beforeInsertImage', beforeInsertImage);

            editor.addListener('imageClosed', function () {
                editor.removeListener("beforeInsertImage", beforeInsertImage);
            });

            var myImage = editor.getDialog("insertimage");
            myImage.open();

        }
    });
}

/*
    根据数据状态更新图标状态
*/
var gridPrepareCommand = function (grid, command, record, row) {
    if ((command.command == 'changestate' || command.command == "enable") && ((record.data.State == 0) || record.data.State == "Disable")) {
        command.iconCls = "icon-acceptdisable";
        command.qtext = "点击启用";
    }

    if ((command.command == 'changestate' || command.command == "enable") && (record.data.State == 1 || record.data.State == "Enable")) {
        command.iconCls = "icon-accept";
        command.qtext = "点击禁用";
    }

    if (command.command == 'edit' && record.data.Editable == 0) {
        command.disabled = true;
        command.qtext = "不可编辑";
    }

    if (command.command == 'enable' && record.data.Editable == 0) {
        command.disabled = true;
        command.qtext = "不可编辑";
    }

    if (command.command == 'delete' && record.data.Editable == 0) {
        command.disabled = true;
        command.qtext = "不可删除";
    }

    if (command.command == 'start' && record.data.IsStartNow == 1) {
        command.disabled = true;
    }

    if (command.command == 'update') {
        command.disabled = true;
        if (record.data.payStatus !== '2' && record.data.flowStatus !== '-1' && record.data.payMethod == -100) {
            command.disabled = false;
        }
    }
};

/*
    添加选项卡
*/
function AddTab(title, url, id) {
    if (typeof (top.window.loadExample) == "function") {
        top.window.loadExample(url, id || title, title);
    } else {
        window.open(url);
    }
}

function getCurosr(el) {
    var range = { text: "", start: 0, end: 0 };

    if (el.setSelectionRange) { // W3C	
        el.focus();
        range.start = el.selectionStart;
        range.end = el.selectionEnd;
        range.text = (range.start != range.end) ? el.value.substring(range.start, range.end) : "";
    } else if (document.selection) { // IE
        el.focus();
        var i,
            oS = document.selection.createRange(),
            // Don't: oR = el.createTextRange()
            oR = document.body.createTextRange();
        oR.moveToElementText(el);

        range.text = oS.text;
        range.bookmark = oS.getBookmark();

        // object.moveStart(sUnit [, iCount]) 
        // Return Value: Integer that returns the number of units moved.
        for (i = 0; oR.compareEndPoints('StartToStart', oS) < 0 && oS.moveStart("character", -1) !== 0; i++) {
            // Why? You can alert(el.value.length)
            if (el.value.charAt(i) == '\r') {
                i++;
            }
        }
        range.start = i;
        range.end = range.text.length + range.start;
    }
    return range;
}

function setCursor(el, range) {
    var oR, start, end;
    if (!range) {
        alert("You must get cursor position first.")
    }
    el.focus();
    if (el.setSelectionRange) { // W3C
        el.setSelectionRange(range.start, range.end);
    } else if (el.createTextRange) { // IE
        oR = el.createTextRange();

        // Fixbug : ues moveToBookmark()
        // In IE, if cursor position at the end of textarea, the set function don't work
        if (el.value.length === range.start) {
            //alert('hello')
            oR.collapse(false);
            oR.select();
        } else {
            oR.moveToBookmark(range.bookmark);
            oR.select();
        }
    }
}




UE.getEditor('editor-img').addListener('contentChange', function (editor) {
    //获取编辑器中的内容（html 代码）
    var img = UE.getEditor('editor-img').getPlainTxt();
    if (img != "") {
        //判断是否是单图片上传，如果是单传不做任何处理，等待回调函数再次调用。
        if (img.indexOf("loadingclass") == -1) {
            //把编辑器中的内容放到临时div中，然后进行获取文件名称。
            $("#temp-img-list").html(img);
            var array = new Array();
            //循环获取文件名称
            $("#temp-img-list img").each(function () {
                var src = $(this).attr("src");
                var name = src.replace("/upload/image/", "");
                array.push(name);
            });
            //清空编辑器中的内容，以便下一次添加图片。
            UE.getEditor('editor-img').execCommand('cleardoc');
            //调用callbackImg获取懂图片名称
            if (typeof callbackImg === "function") {
                eval("callbackImg('" + array + "')");
            }
        }
    }
});



function dateFmtStr(obj, type) {
    if (type == 1) {
        if (obj.value == "") {
            WdatePicker({ dateFmt: 'yyyy-MM-dd 00:00:00' });
        } else {
            WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss' });
        }
    } else {
        if (obj.value == "") {
            WdatePicker({ dateFmt: 'yyyy-MM-dd 23:59:59' });
        } else {
            WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss' });
        }
    }

}
