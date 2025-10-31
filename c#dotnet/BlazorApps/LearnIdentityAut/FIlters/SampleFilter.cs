using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LearnIdentityAut.FIlters
{
    public class SampleFilter : IActionFilter,IAuthorizationFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("OnActionExecuting");
           
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            var ttt = context.HttpContext.GetRouteValue("controller");

                //check access 
                if (user.Identity.Name != "smartydarren@gmail.com")
                {
                    //all good, add some code if you want. Or don't
                    context.Result = new RedirectToRouteResult(
                                        new RouteValueDictionary
                                   {
                                       { "action", "AccessDenied" },
                                       { "controller", "Home" }
                                   });
                }
                else
                {
                    //DENIED!
                    //return "ChallengeResult" to redirect to login page (for example)

                }
            }
        
    }
}
