using HoaLacLaptopShop.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace HoaLacLaptopShop.Areas.Shared.Controllers
{
    public abstract class HoaLacController : Controller
    {
        protected virtual string? ManagedObjectsString { get; } = null;

        [NonAction]
        public UnauthorizedResult Unauthorized(string message)
        {
            this.AddError(message);
            return base.Unauthorized();
        }
        [NonAction]
        public override UnauthorizedResult Unauthorized()
        {
            this.AddError($"You are not allowed to add/edit/delete {ManagedObjectsString ?? ""}");
            return base.Unauthorized();
        }
        [NonAction]
        public NotFoundResult NotFound(string message)
        {
            this.AddError(message);
            return base.NotFound();
        }
        [NonAction]
        public override NotFoundResult NotFound()
        {
            this.AddError($"One or more {ManagedObjectsString ?? "objects"} were not found.");
            return base.NotFound();
        }
    }
}
