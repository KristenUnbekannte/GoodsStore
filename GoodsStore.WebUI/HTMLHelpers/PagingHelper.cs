using GoodsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace GoodsStore.WebUI.HTMLHelpers
{
    public static class PagingHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
                                              PagingInfo pagingInfo,
                                              Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int x = 0; x < 2; x++)
            {
                TagBuilder tag = new TagBuilder("a");
                if (pagingInfo.CurrentPage == 1||pagingInfo.TotalPages==0)
                    tag.AddCssClass("disabled");

                TagBuilder span = new TagBuilder("span");
                span.MergeAttribute("aria-hidden", "true");
                if (x == 0)
                {
                    tag.MergeAttribute("href", pageUrl(1));
                    span.AddCssClass("glyphicon glyphicon-backward");
                }
                else
                {
                    tag.MergeAttribute("href", pageUrl(pagingInfo.CurrentPage - 1));
                    span.AddCssClass("glyphicon glyphicon-step-backward");
                }

                tag.AddCssClass("btn btn-default");
                tag.InnerHtml += span.ToString();
                result.Append(tag.ToString());
            }
            int from = (pagingInfo.CurrentPage < 3 || pagingInfo.TotalPages < 6) ? 1 : pagingInfo.CurrentPage + 2 > pagingInfo.TotalPages ? pagingInfo.TotalPages - 4 : pagingInfo.CurrentPage - 2;
            int to = pagingInfo.TotalPages < 6 ? pagingInfo.TotalPages : from + 4;
            for (int i = from; i <= to; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-warning");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            for (int x = 0; x < 2; x++)
            {
                TagBuilder tag = new TagBuilder("a");
                if (pagingInfo.CurrentPage == pagingInfo.TotalPages || pagingInfo.TotalPages == 0)
                    tag.AddCssClass("disabled");

                TagBuilder span = new TagBuilder("span");
                span.MergeAttribute("aria-hidden", "true");
                if (x == 0)
                {
                    tag.MergeAttribute("href", pageUrl(pagingInfo.CurrentPage + 1));
                    span.AddCssClass("glyphicon glyphicon-step-forward");
                }
                else
                {
                    tag.MergeAttribute("href", pageUrl(pagingInfo.TotalPages));
                    span.AddCssClass("glyphicon glyphicon-forward");
                }

                tag.AddCssClass("btn btn-default");
                tag.InnerHtml += span.ToString();
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}