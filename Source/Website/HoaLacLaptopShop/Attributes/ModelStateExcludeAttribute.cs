using HoaLacLaptopShop.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HoaLacLaptopShop.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ModelStateExcludeAttribute : Attribute, IActionFilter
    {
        private string[] _excludeMembers = null!;
        public ModelStateExcludeAttribute(params string[] excludedMembers)
        {
            _excludeMembers = excludedMembers;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            foreach (var bad in context.ModelState.Keys.Where(x => _excludeMembers.Contains(x)))
            {
                context.ModelState.Remove(bad);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
