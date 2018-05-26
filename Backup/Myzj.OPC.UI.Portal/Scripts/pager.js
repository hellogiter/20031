$(document).ready(function () {

    var paginator = $(".paginator");
    //有分页再绑定
    if (paginator != undefined) {
        $(".paginator a").each(function (k, v) {
            var ele = $(v);
            ele.bind('click', function () {
                //解析pageIndex'
                var analyseFlag = "pageIndex=";
                var href = ele.attr("href");
                var start = href.indexOf(analyseFlag);
                if (start > -1) {
                    var pageIndexStr = href.substring(start, href.length);
                    if (pageIndexStr.length > 0) {
                        var pageIndex = pageIndexStr.split('=')[1];
                        //生成hidden
                        var pageIndexInput =
                            $('<input type="hidden" name="PageIndex" value="' + pageIndex + '"/>');
                        var pagerAction =
                            $('<input type="hidden" value="" name="pager" />');
                        var form = $("form");
                        form.append(pageIndexInput).append(pagerAction);
                        form.submit();
                    }
                }
                return false;
            });
        });
    }
});