using LearnIdentityAut.Data;
using LearnIdentityAut.FIlters;
using LearnIdentityAut.Models;
using LearnIdentityAut.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//Dependecy of Interfaces/Classes
builder.Services.AddScoped<IBookRepo, BookRepo>();
builder.Services.AddScoped<ILanguageRepo, LanguageRepo>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

builder.Services.AddIdentity<ApplicationUserModel, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.ConfigureApplicationCookie(e =>
{
    e.LoginPath = "/Account/SignIn";
});

builder.Services.AddMvc(ep =>
{
    //ep.Filters.Add(new SampleFilter());
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    ep.Filters.Add(new AuthorizeFilter(policy));
}) ;

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Home/AccessDenied";
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("EditRolePolicy",
        policy => policy.RequireClaim("Edit Role", "true"));
});



//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
  //  .AddEntityFrameworkStores<ApplicationDbContext>();
//builder.Services.AddControllersWithViews();

#if DEBUG
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
#endif

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseMigrationsEndPoint();
}
else
{
    app.UseStatusCodePagesWithRedirects("/Home/Error");
    //app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
}

/*
app.Use(async (context, nextTask) =>
{
    await context.Response.WriteAsync("<Html><Body>Hello from first middleware");
    await nextTask(context);
    await context.Response.WriteAsync("<BR />ByeBye from first middleware</Html></Body>");
});

app.Map("/map", x =>
{
    x.Run(a => a.Response.WriteAsync("<BR />Hello from Map Branch"));
});

app.MapWhen(c => c.Request.Query.ContainsKey("count"), async a =>
{
    a.Run(a => a.Response.WriteAsync($"<BR />Count is : {a.Request.Query["count"]}"));
});

//app.Run(a => a.Response.WriteAsync("<BR />Hello from Application"));

//or
//app.Run( async x => { 
//  await x.Response.WriteAsync("<BR />Hello from Application");

   });

*/

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapRazorPages();



/*app.UseEndpoints(cnd =>
{
    cnd.MapGet("/", async cnt =>
     {
         await cnt.Response.WriteAsync("<BR />Hello Darren");
         await cnt.Response.WriteAsync($"<BR /> Host Name : " +
             $"{Environment.MachineName}, Env Name: {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}");
     });
});
*/


app.Run();
