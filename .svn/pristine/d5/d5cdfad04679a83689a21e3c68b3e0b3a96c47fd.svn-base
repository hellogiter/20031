using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace System.Web.Mvc.Html
{
    public static class HtmlHelperExt
    {
        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, bool isHasAll)
        {
            //return DropDownListFor(htmlHelper, expression, selectList, null /* optionLabel */, null /* htmlAttributes */);
            MvcHtmlString mvcHtmlString = htmlHelper.DropDownListFor(expression, selectList);
            //无可选项时直接返回
            if (selectList.Count() <= 0)
            {
                return mvcHtmlString;
            }
            if (!isHasAll)
            {
                return mvcHtmlString;
            }
            string htmlString = mvcHtmlString.ToHtmlString();

            const string entryFlag = "<option";
            int index = htmlString.IndexOf(entryFlag, System.StringComparison.Ordinal);

            const string appendHtml = "<option value=''>--ALL--</option>";
            string result = htmlString.Insert(index, appendHtml);

            return new MvcHtmlString(result);
        }

        public static MvcHtmlString DropDownListDisabledFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList)
        {
            return htmlHelper.DropDownListFor(expression, selectList, new { disabled = "disabled" });
        }

        public static MvcHtmlString PageNative(this HtmlHelper htmlHelper, int? pageIndex,
            int? pageSize, long? total, string redirectUrl, string fun = "")
        {
            //check参数
            if (null == total || total < 1) return new MvcHtmlString(string.Empty);
            //pageIndex,pageSize,total,utl
            if (null == pageSize || pageSize > 50) { pageSize = 20;/*超过限制，默认*/}
            if (null == pageIndex || pageIndex < 1) { pageIndex = 1; }
            if (string.IsNullOrEmpty(redirectUrl))
            {
                var context = HttpContext.Current;
                if (null != context)
                {
                    redirectUrl = context.Request.Url.AbsolutePath;
                }
            }

            var html = GetHtmlAttr(redirectUrl, fun);

            StringBuilder pagerBilder = new StringBuilder();
            //总页数
            var totalPages = Math.Max((int)((total + pageSize - 1) / pageSize), 1);
            if (totalPages > 1)
            {
                //if (pageIndex != 1)
                {//处理首页连接
                    pagerBilder.AppendFormat("<a class='pageLink' " + html.Replace("***","1") + ">首页</a> ");

                }
                if (pageIndex > 1)
                {//处理上一页的连接
                    var index = (pageIndex - 1).ToString();
                    pagerBilder.AppendFormat("<a class='pageLink'  " + html.Replace("***", index) + ">上一页</a> ");

                }

                pagerBilder.Append(" ");
                int currint = 5;
                for (int i = 0; i <= 10; i++)
                {//一共最多显示10个页码，前面5个，后面5个
                    if ((pageIndex + i - currint) >= 1 && (pageIndex + i - currint) <= totalPages)
                    {
                        if (currint == i)
                        {//当前页处理

                            var index = pageIndex.ToString();
                            pagerBilder.AppendFormat("<a class='cpb'  " + html.Replace("***", index) + ">{0}</a> ", pageIndex);
                        }
                        else
                        {//一般页处理

                            var index = (pageIndex + i - currint).ToString();

                            pagerBilder.AppendFormat(
                                "<a class='pageLink'  " + html.Replace("***", index) + ">{0}</a> ", pageIndex + i - currint);

                        }
                    }
                    pagerBilder.Append(" ");
                }
                if (pageIndex < totalPages)
                {//处理下一页的链接

                    var index = (pageIndex + 1).ToString();

                    pagerBilder.AppendFormat("<a class='pageLink'  " + html.Replace("***", index) + ">下一页</a> ");

                }
                else
                {
                    //pagerBilder.Append("<span class='pageLink'>下一页</span>");
                }
                pagerBilder.Append(" ");
                if (pageIndex != totalPages)
                {
                    var index = totalPages.ToString();

                    pagerBilder.AppendFormat("<a class='pageLink' " + html.Replace("***", index) + ">末页</a> ");

                }
                pagerBilder.Append(" ");
            }
            //pagerBilder.AppendFormat("第{0}页 / 共{1}页", pageIndex, totalPages);//这个统计加不加都行

            pagerBilder.AppendFormat("第{0}页 / 共{1}页，共<span style='color:red'>{2}</span>条", pageIndex, totalPages, total);//这个统计加不加都行

            return new MvcHtmlString(pagerBilder.ToString());
        }

        /// <summary>
        /// 获取html属性
        /// </summary>
        /// <param name="url">链接</param>
        /// <param name="fun">方法</param>
        /// <returns></returns>
        private static string GetHtmlAttr(string url, string fun)
        {
            var html = "";

            if (string.IsNullOrEmpty(fun))
            {
                html = "href='" + url + "?pageIndex=***'";
            }
            else
            {
                html = "href='javascript:;' onclick='" + fun + "(***)'";
            }

            return html;
        }

        public static MvcHtmlString TextBoxDisabledFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.TextBoxFor(expression, new { disabled = "disabled" });
        }

        /// <summary>
        /// 获取下拉列表
        /// </summary>
        /// <param name="id">控件名</param>
        /// <param name="list">列表</param>
        /// <param name="selectVal">选择值</param>
        /// <returns></returns>
        public static MvcHtmlString GetDropDownList(string id, SortedList<int, string> list, string selectVal = "")
        {
            var selected = "";

            var html = "<select id='" + id + "'>";
            html += "<option value='-1'>全部</option>";

            foreach (var item in list)
            {
                selected = "";
                if (selectVal == item.Value)
                {
                    selected = "selected";
                }
                html += "<option value='" + item.Key + "' " + selected + " >" + item.Value + "</option>";

            }
            html += "</select>";

            return new MvcHtmlString(html);
        }
    }
}
