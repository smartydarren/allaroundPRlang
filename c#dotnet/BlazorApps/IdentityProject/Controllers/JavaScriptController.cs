using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityProject.Controllers
{
    [AllowAnonymous]
    public class JavaScriptController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
