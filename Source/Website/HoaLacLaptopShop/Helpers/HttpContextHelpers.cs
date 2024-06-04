﻿using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HoaLacLaptopShop.Helpers
{
    public static class HttpContextHelpers
    {
        public static async void LoginAsUser(this HttpContext context, User user)
        {
            await context.SignInAsync
                (
                    new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.ID.ToString())
                    },
                    "Login"
                )));
        }

        private static ClaimsIdentity? GetCurrentIdentity(this HttpContext context)
        {
            var identity = context.User?.Identity as ClaimsIdentity;
            if (identity is null || !identity.IsAuthenticated) return null;
            return identity;
        }

        public static int? GetCurrentUserID(this HttpContext context)
        {
            var identity = context.GetCurrentIdentity();
            if (identity == null) return null;
            return int.Parse(identity.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
        }

        public static bool IsLoggedIn(this HttpContext context)
        {
            return context.GetCurrentUserID() is not null;
        }

        public static User? GetCurrentUser(this HttpContext context, HoaLacLaptopShopContext dbContext)
        {
            var id = context.GetCurrentUserID();
            if (!id.HasValue) return null;
            return dbContext.Users.AsNoTracking().Single(x => x.ID == id.Value);
        }

        public static RoledActor? GetCurrentUserRoles(this HttpContext context)
        {
            if (context.GetCurrentUserID() is null) return null;
            var roles = context.GetCurrentIdentity()!.FindAll(ClaimTypes.Role).Select(x => x.Value);
            return new RoledActor()
            {
                IsAdmin = roles.Any(x => x == "Admin"),
                IsSales = roles.Any(x => x == "Sales"),
                IsMarketing = roles.Any(x => x == "Marketing")
            };
        }
    }
}
