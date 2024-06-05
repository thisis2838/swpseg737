using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HoaLacLaptopShop.Middlewares
{
    public class RoleSyncMiddleware
    {
        private readonly RequestDelegate _next;

        public RoleSyncMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, HoaLacLaptopShopContext dbContext)
        {
            var ctxUser = context.User;
            var identity = ctxUser.Identity as ClaimsIdentity;
            if (identity?.IsAuthenticated ?? false)
            {
                var claims = identity.Claims;
                var roles = claims.Where(x => x.Type == ClaimTypes.Role);
                foreach (var role in roles)
                {
                    identity.RemoveClaim(role);
                }
                var userId = int.Parse(claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
                var user = dbContext.Users.AsNoTracking().FirstOrDefault(x => x.ID == userId);
                if (user is null)
                {
                    await context.SignOutAsync();
                }
                else
                {
                    if (user.IsMarketing) identity.AddClaim(new Claim(ClaimTypes.Role, "Marketing"));
                    if (user.IsSales) identity.AddClaim(new Claim(ClaimTypes.Role, "Sales"));
                    if (user.IsAdmin) identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                }
                context.Items["CurrentUser"] = user;
            }
            await _next(context);
        }
    }
}
