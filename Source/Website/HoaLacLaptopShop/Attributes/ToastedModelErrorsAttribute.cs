using HoaLacLaptopShop.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HoaLacLaptopShop.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ToastedModelErrorsAttribute : Attribute, IActionFilter
    {
        public ToastedModelErrorsAttribute(params string[] includedMembers)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var invalids = context.ModelState
                    .Where(x => x.Value?.ValidationState == ModelValidationState.Invalid)
                    .SelectMany(x => x.Value?.Errors.Select(x => x.ErrorMessage)!)
                    .Where(x => x != null);
                foreach (var invalid in invalids)
                {
                    (context.Controller as Controller)?.AddError(invalid);
                }
            }
        }
    }
}
