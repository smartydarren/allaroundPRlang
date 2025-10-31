using EmployeeMVCApp.Models.Repos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeeMVCApp.Controllers
{
    //[Route("Account")]
    public class AccountController : Controller
    {
        private IAccountService accservice;

        public AccountController(IAccountService acc)
        {
            this.accservice = acc;
        }

        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password, string returnUrl)
        {
            var account = accservice.Login(username, password);
            if (account is false)
            {
                TempData["Error"] = "Error Username/Password Invalid!";
                return View("login");
            }
            else { 
                //HttpContext.Session.SetString("username", username);
                //return RedirectToAction("Welcome");
                var claims = new List<Claim>();
                claims.Add(new Claim("username", username));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
                var cIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(cIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                return Redirect(returnUrl);
            }
            
        }

        [Route("welcome")]
        public IActionResult Welcome()
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            return View("Welcome");
        }

        //[Route("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            //HttpContext.Session.Remove("username");
            return RedirectToAction("Login");
        }
    }
}
