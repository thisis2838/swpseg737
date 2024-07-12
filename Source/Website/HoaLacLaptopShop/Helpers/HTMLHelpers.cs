using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace HoaLacLaptopShop.Helpers
{
    public static class HtmlHelpers
    {
        public static Task<IHtmlContent> PartialAsync(this IHtmlHelper htmlHelper, string partialViewName, object model, string prefix)
        {
            var viewData = new ViewDataDictionary(htmlHelper.ViewData);
            var htmlPrefix = viewData.TemplateInfo.HtmlFieldPrefix;
            viewData.TemplateInfo.HtmlFieldPrefix += !Equals(htmlPrefix, string.Empty) ? $".{prefix}" : prefix;
            return htmlHelper.PartialAsync(partialViewName, model, viewData);
        }
    }
}
