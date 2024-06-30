using HoaLacLaptopShop.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HoaLacLaptopShop.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ModelStateIncludeAttribute : Attribute, IActionFilter
    {
        private string[] _includeMembers = null!;
        public ModelStateIncludeAttribute(params string[] includedMembers)
        {
            _includeMembers = includedMembers;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            foreach (var bad in context.ModelState.Keys.Where(x => !_includeMembers.Contains(x)))
            {
                context.ModelState.Remove(bad);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
