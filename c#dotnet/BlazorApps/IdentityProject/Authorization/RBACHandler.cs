using IdentityProject.Data;
using IdentityProject.Data.Procs;
using IdentityProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityProject.Authorization
{
    public class RBACHandler : AuthorizationHandler<RBACRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected ApplicationDbContext dbCon { get; }
        public UserManager<ApplicationUser> User { get; }
        public IDataService DataService { get; }

        public IUserCtrlrlMapService ctrlrFromCookie { get; }

        public RBACHandler(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbCon
            , UserManager<ApplicationUser> _user, IDataService _dataService, IUserCtrlrlMapService _ctrlrFromCookie)
        {
            this._httpContextAccessor = httpContextAccessor;
            this.dbCon = dbCon;
            this.User = _user;
            this.DataService = _dataService;
            this.ctrlrFromCookie = _ctrlrFromCookie;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, RBACRequirement requirement)
        {
            /*           
            //var userAuth = context.User.Identity.IsAuthenticated;
            //var userName = context.User.Identity.Name;

            //var rd = _httpContextAccessor.HttpContext.Request;
            //string aa = rd.RouteValues["controller"].ToString();
            //string bb = rd.RouteValues["action"].ToString();
            */

            if (context.Resource is HttpContext httpContext && httpContext.GetEndpoint() is RouteEndpoint endpoint)
            {
                endpoint.RoutePattern.RequiredValues.TryGetValue("controller", out var _controller);

                // Check the controller
                //var listOfControllers = await DataService.GetMenuItemsAsync(context.User); // listOfControllers.Contains(_controller.ToString());

                var listOfControllers = ctrlrFromCookie.GetMenuItems(context.User); 

                var check = listOfControllers.Contains(_controller.ToString());

                if (check == true)
                {
                    context.Succeed(requirement);
                }
            }
            await Task.CompletedTask;            
        }
    }
}
