﻿using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HoaLacLaptopShop.Helpers
{
    public static class HttpContextHelpers
    {
        public static async Task LoginAsUser(this HttpContext context, User user, bool rememberMe)
        {
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = rememberMe,
                ExpiresUtc = rememberMe ? DateTime.UtcNow.AddMinutes(30) : (DateTime?)null
            };
            await context.SignInAsync
            (
                new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>{new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),}, "Login")),
                authProperties
            )
            .ContinueWith(x => context.Items["CurrentUser"] = user);
            return;
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

        public static User? GetCurrentUser(this HttpContext context)
        {
            return context.IsLoggedIn()
                ? context.Items["CurrentUser"] as User
                : null;
        }

        public static async Task SignOut(this HttpContext context)
        {
            await context.SignOutAsync().ContinueWith(x => context.Items["CurrentUser"] = null);
            return;
        }
    }
}
