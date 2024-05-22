using Microsoft.AspNetCore.Mvc;

namespace HoaLacLaptopShop.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error403()
        {
            return View("403");
        }

        public IActionResult Error404()
        {
            return View("404");
        }
    }
}
