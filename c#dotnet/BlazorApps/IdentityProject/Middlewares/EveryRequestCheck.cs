using IdentityProject.Data;
using IdentityProject.Data.Procs;
using Microsoft.AspNetCore.Identity;

namespace IdentityProject.Middlewares
{
    public class EveryRequestCheck
    {
        public RequestDelegate next { get; }
        private ApplicationDbContext dbcon { get; set; }

        public EveryRequestCheck(RequestDelegate del)
        {
            next = del;
            //dbcon = context;
        }

        public async Task InvokeAsync(HttpContext context, ApplicationDbContext dbcon, SignInManager<ApplicationUser> manager)
        {
            var userName = context.User.Identity.Name;
            //var userID = new Access_GetUserID().GetUserID(context);
            var menu = dbcon.db_Menu.ToList();
            Console.WriteLine($"Authenticated user is :{userName}");

            //if (userName == null) context.Response.Redirect("/Account/login");

            if (context.Request.Path != "/Account/login")
            {
                if (userName == "aisli.quadros")
                {
                    //vawait context.Response.CompleteAsync();

                    await manager.SignOutAsync();
                    context.Response.Redirect("/Account/login");
                    //context.Response.Redirect("/Account/Login");                
                }
            }            
            await next(context);
        }

    }
}
