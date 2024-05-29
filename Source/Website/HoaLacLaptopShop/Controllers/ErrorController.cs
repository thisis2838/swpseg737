using HoaLacLaptopShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace HoaLacLaptopShop.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet("Error/{type}")]
        public IActionResult Index(KnownErrorType type)
        {
            switch (type)
            {
                case KnownErrorType.NotFound:
                    return Index(new ErrorViewModel()
                    {
                        ErrorCode = 404,
                        ErrorName = "Not Found",
                        Message = "The page you've just tried to access could not be found."
                    });
                case KnownErrorType.Forbidden:
                    return Index(new ErrorViewModel()
                    {
                        ErrorCode = 403,
                        ErrorName = "Forbidden",
                        Message = "The page you've just tried to access is beyond your authority."
                    });
                case KnownErrorType.Unknown:
                default:
                    return Index(new ErrorViewModel()
                    {
                        ErrorCode = 0,
                        ErrorName = "Unknown",
                        Message = "An unknown error occurred. Please conatct the system administrator for further details."
                    });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index(ErrorViewModel? model = null)
        {
            if (model == null) return Index(KnownErrorType.Unknown);
            return View(model);
        }
    }

    public enum KnownErrorType
    {
        Unknown,
        NotFound,
        Forbidden
    }
}
