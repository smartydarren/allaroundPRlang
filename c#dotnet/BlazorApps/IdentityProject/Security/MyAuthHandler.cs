using IdentityProject.Data.Procs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;

namespace IdentityProject.Security
{
    public class MyAuthHandler : AuthenticationHandler<MyAuthScheme>
    {
        public MyAuthHandler(IOptionsMonitor<MyAuthScheme> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {           
            var userID = new Access_GetUserID().GetUserID(Request.HttpContext);          

            if (userID != 1)
            {
                return AuthenticateResult.NoResult();
            }

            var Ticket = new AuthenticationTicket(Request.HttpContext.User, CookieAuthenticationDefaults.AuthenticationScheme);

            return AuthenticateResult.Success(Ticket);
        }
    }
}
