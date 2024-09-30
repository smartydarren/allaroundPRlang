using IdentityProject.Data.Procs;
using IdentityProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IdentityProject.Controllers
{    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       
        public IActionResult Index()
        {
            //ViewBag.userID = new Access_GetUserID().GetUserID(HttpContext);
            ViewBag.userID = HttpContext.User.FindFirst("UserID");
            ViewBag.usernm = HttpContext.User.Identity.Name;
            //ViewBag.userIDTF = AuthUser.HasClaim(cc => cc.Value == "UserID");
            //ViewBag.userID = AuthUser.FindFirst("UserID");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}