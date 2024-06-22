using HoaLacLaptopShop.Data;
using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Middlewares;
using HoaLacLaptopShop.Models;
using HoaLacLaptopShop.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using System.Net;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<HoaLacLaptopShopContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("HoaLacLaptopShop"));
        });
        builder.Services.AddDbContext<TemporaryResourceContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("HoaLacLaptopShop"));
        });

        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromSeconds(10);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
        {
            options.LoginPath = "/Account/Login";
            options.AccessDeniedPath = "/Error/403";
        });
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("RequireAdmin", policy => policy.RequireRole("Admin"));
            options.AddPolicy("RequireMarketing", policy => policy.RequireRole("Marketing"));
            options.AddPolicy("RequireSales", policy => policy.RequireRole("Sales"));
        });

        builder.Services.AddHttpContextAccessor();
        builder.Services.AddSingleton<ILocalResourceService, LocalResourceService>();
        builder.Services.AddScoped<ITemporaryResourceService, TemporaryResourceService>();
        builder.Services
            .AddControllersWithViews()
            .AddRazorOptions(options =>
            {
                options.ViewLocationExpanders.Add(new CustomViewLocationExpander());
            });

        var app = builder.Build();
        CleanUpTemporaryFiles(app.Services);

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseStatusCodePagesWithRedirects("/Error/{0}");
        app.UseRouting();
        app.UseSession();

        app.UseAuthentication();
        app.UseMiddleware<RoleSyncMiddleware>();
        app.UseAuthorization();

        app.MapAreaControllerRoute
        (
            "adminArea", "Administration",
            pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
        );
        app.MapAreaControllerRoute
        (
            "publicArea", "Public",
            pattern: "Public/{controller=Home}/{action=Index}/{id?}"
        );
        app.MapControllerRoute
        (
            "default",
            pattern: "{controller}/{action}/{id?}",
            new { controller = "Home", action = "Index" }
        );

        app.Run();
    }

    private static void CleanUpTemporaryFiles(IServiceProvider services)
    {
        using (var scope = services.CreateScope()) 
        {
            using var db = scope.ServiceProvider.GetRequiredService<TemporaryResourceContext>();
            db.Resources.ExecuteDelete();
        }
        using (services.CreateScope())
        {
            var local = services.GetRequiredService<ILocalResourceService>();
            local.DirectoryRemove(local.GetRelativePath(ResourceType.Temp));
        }
    }
}