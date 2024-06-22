using HoaLacLaptopShop.Areas.Public.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Net;

namespace HoaLacLaptopShop.Areas.Public.Controllers
{
    public class ErrorController : Controller
    {
        private static readonly Dictionary<HttpStatusCode, ErrorViewModel> _viewModels = new()
        {
            {
                HttpStatusCode.NotFound, new ErrorViewModel()
                {
                    ErrorCode = 404,
                    ErrorName = "Not Found",
                    Message = "The page you've just tried to access could not be found."
                }
            },
            {
                HttpStatusCode.Forbidden, new ErrorViewModel()
                {
                    ErrorCode = 403,
                    ErrorName = "Forbidden",
                    Message = "The page you've just tried to access is barred from you."
                }
            },
            {
                HttpStatusCode.Unauthorized, new ErrorViewModel()
                {
                    ErrorCode = 401,
                    ErrorName = "Unauthorized",
                    Message = "The page you've just tried to access is not within your authority."
                }
            }
        };

        [Route("/Error/{code}")]
        public IActionResult Code(HttpStatusCode code)
        {
            ErrorViewModel model = null!;
            if (!_viewModels.TryGetValue(code, out model!))
            {
                model = new ErrorViewModel()
                {
                    ErrorCode = (int)code,
                    ErrorName = (code == 0) ? "Unknown Error" : code.ToString(),
                    Message = "An error occured. Please conatct the system administrator for further details."
                };
            }
            return View(nameof(Index), model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [NonAction]
        public IActionResult Index(ErrorViewModel? model = null)
        {
            if (model == null) return Code(0);
            return View(model);
        }
    }
}
