using Microsoft.AspNetCore.Mvc.Razor;

namespace HoaLacLaptopShop.Services
{
    public class ViewLocationExpander : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            // No need to populate any values here
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            var areaName = context.ActionContext.RouteData.Values["area"]?.ToString();
            areaName = string.IsNullOrEmpty(areaName) ? "Public" : areaName;

            if (!string.IsNullOrEmpty(areaName))
            {
                var areaViewLocations = new[]
                {
                    $"/Areas/{areaName}/Views/{{1}}/{{0}}.cshtml",
                    $"/Areas/{areaName}/Views/ComponentSeries/{{1}}/{{0}}.cshtml",
                    $"/Areas/{areaName}/Views/Shared/{{0}}.cshtml"
                };

                viewLocations = areaViewLocations.Concat(viewLocations);
            }

            return viewLocations;
        }
    }
}
