using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Middlewares;
using HoaLacLaptopShop.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HoaLacLaptopShopContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("HoaLacLaptopShop"));
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie
(
    options=>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Error/403";
    }
);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdmin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("RequireMarketing", policy => policy.RequireRole("Marketing"));
    options.AddPolicy("RequireSales", policy => policy.RequireRole("Sales"));
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();

var app = builder.Build();

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

// Enable session middleware
app.UseSession();

app.UseAuthentication();
app.UseMiddleware<RoleSyncMiddleware>();
app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(name: "product", pattern: "{controller=Product}/{action=Detail}/{id?}");

app.Run();
