using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace HoaLacLaptopShop.Helpers
{
    public static class ControllerHelper
    {
        public static void SetError(this Controller controller, string error)
        {
            controller.TempData["Error"] = error;
        }

        public static void SetMessage(this Controller controller, string message)
        {
            controller.TempData["Message"] = message;
        }
    }
}
