using GoodsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace GoodsStore.WebUI.HTMLHelpers
{
    public static class AjaxPagingHelper
    {
        public static IHtmlString PageLinks(this AjaxHelper ajaxHelper, PagingInfo pagingInfo, AjaxOptions ajaxOptions,
                                            string actionName, Func<int, object> values)
        {
            StringBuilder result = new StringBuilder();
            int val;
            for (int x = 0; x < 2; x++)
            {
                TagBuilder builder = new TagBuilder("span");
                builder.MergeAttribute("aria-hidden", "true");
                if (x == 0)
                {
                    val = 1;
                    builder.AddCssClass("glyphicon glyphicon-backward btn btn-default span_height");
                }
                else
                {
                    val = pagingInfo.CurrentPage - 1;
                    builder.AddCssClass("glyphicon glyphicon-step-backward  btn btn-default span_height");
                }
                if (pagingInfo.CurrentPage == 1 || pagingInfo.TotalPages == 0)
                    builder.AddCssClass("disabled");
                var link = ajaxHelper.ActionLink("[replaceme]", actionName, values(val), ajaxOptions).ToHtmlString();
                link=link.Replace("[replaceme]", builder.ToString(TagRenderMode.SelfClosing));
                result.Append(link);
            }

            int from = (pagingInfo.CurrentPage < 3 || pagingInfo.TotalPages < 6) ? 1 : pagingInfo.CurrentPage + 2 > pagingInfo.TotalPages ? pagingInfo.TotalPages - 4 : pagingInfo.CurrentPage - 2;
            int to = pagingInfo.TotalPages < 6 ? pagingInfo.TotalPages : from + 4;
            for (int i = from; i <= to; i++)
            {
                TagBuilder tag = new TagBuilder("input");
                tag.MergeAttribute("type", "text");
                tag.MergeAttribute("value", i.ToString());
                tag.MergeAttribute("readonly", "readonly");
                tag.AddCssClass("input_width btn btn-default");
                if (i == pagingInfo.CurrentPage)
                    tag.AddCssClass("selected btn-warning ");

                var link = ajaxHelper.ActionLink("[replaceme]", actionName, values(i), ajaxOptions).ToHtmlString();
                link = link.Replace("[replaceme]", tag.ToString(TagRenderMode.SelfClosing));
                result.Append(link);
            }
            for (int x = 0; x < 2; x++)
            {
                TagBuilder tag = new TagBuilder("span");
                tag.MergeAttribute("aria-hidden", "true");
                if (x == 0)
                {
                    tag.AddCssClass("glyphicon glyphicon-step-forward");
                    val=pagingInfo.CurrentPage + 1;
                }
                else
                {
                    val=pagingInfo.TotalPages;
                    tag.AddCssClass("glyphicon glyphicon-forward");
                }
                if (pagingInfo.CurrentPage == pagingInfo.TotalPages || pagingInfo.TotalPages == 0)
                    tag.AddCssClass("disabled");
                tag.AddCssClass("btn btn-default span_height");
                var link = ajaxHelper.ActionLink("[replaceme]", actionName, values(val), ajaxOptions).ToHtmlString();
                link = link.Replace("[replaceme]", tag.ToString(TagRenderMode.SelfClosing));
                result.Append(link);
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}