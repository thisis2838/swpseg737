using HoaLacLaptopShop.Helpers;
using HoaLacLaptopShop.Models;
<<<<<<< HEAD
using Microsoft.AspNetCore.Http;
=======
using Microsoft.AspNetCore.Authentication.Cookies;
>>>>>>> 3d257d4f702f09b8a6841301f611102c5bdd162d
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HoaLacLaptopShopContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("HoaLacLaptopShop"));
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/User/Login";
    options.AccessDeniedPath = "/AccessDenied";
});

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
<<<<<<< HEAD

// Enable session middleware
app.UseSession();
// Set defaultuser with id 1 in DB to test
//app.Use(async (context, next) =>
//{
//    // Check if the session doesn't have a default user set
//    if (string.IsNullOrEmpty(context.Session.GetString("DefaultUserId")))
//    {
//        using (var scope = app.Services.CreateScope())
//        {
//            var dbContext = scope.ServiceProvider.GetRequiredService<HoaLacLaptopShopContext>();
//            var defaultUser = dbContext.Users.FirstOrDefault(u => u.ID == 1);

//            if (defaultUser != null)
//            {
//                // Assuming DefaultUserId is a string
//                context.Session.SetString("DefaultUserId", defaultUser.ID.ToString());
//            }
//        }
//    }

//    await next.Invoke();
//});

=======
app.UseAuthentication();
>>>>>>> 3d257d4f702f09b8a6841301f611102c5bdd162d
app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(name: "product", pattern: "{controller=Product}/{action=Detail}/{id?}");

app.Run();
