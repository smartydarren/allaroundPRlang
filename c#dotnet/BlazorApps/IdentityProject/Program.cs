using IdentityProject.Authorization;
using IdentityProject.Data;
using IdentityProject.Middlewares;
using IdentityProject.Models;
using IdentityProject.Security;
using IdentityProject.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(e =>
e.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddAntiforgery(options =>
{
    options.Cookie.Name = "DQAntiForg";
    options.Cookie.SameSite = SameSiteMode.None;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;    
});

builder.Services.AddIdentity<ApplicationUser, Access_ApplicationRole>(opt =>
{
    opt.SignIn.RequireConfirmedAccount = true;
}).AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "DQCookie";
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.ReturnUrlParameter = "returnurl";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
    options.SlidingExpiration = true;
    //options.Cookie.MaxAge = TimeSpan.FromMinutes(25);
    options.Cookie.SameSite = SameSiteMode.None;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

//builder.Services.AddMemoryCache();

/*
builder.Services.AddAuthentication().AddCookie("Cookies", "DarrensCookies", options =>
{
    options.Cookie.Name = "DQCookie";
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.ReturnUrlParameter = "returnurl";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
    options.Cookie.SameSite = SameSiteMode.None;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    

}).AddScheme<MyAuthScheme,MyAuthHandler>("Cookies",null)
      .AddCookie("Cookies2")
      .AddJwtBearer("JwtTokens", options =>
      options.SaveToken = true
      );
*/

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RBAC",
        policyBuilder =>
            policyBuilder.AddRequirements(
                new RBACRequirement()                               
            ));    
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IAuthorizationHandler, RBACHandler>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IDataService, DataService>();
builder.Services.AddScoped<IUserCtrlrlMapService, UserCtrlrlMapService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();  //This is used for serving static files css,js etc

app.UseRouting();
app.UseAuthentication();
//app.UseMiddleware<EveryRequestCheck>();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}").RequireAuthorization("RBAC");

app.Run();
