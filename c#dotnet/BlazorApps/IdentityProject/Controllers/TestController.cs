using IdentityProject.Models.ViewModels.Test;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IdentityProject.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            string shortName;
            var p1 = User.Claims.Select(claim => new ListAllClaimsViewModel 
            {cType = claim.Type , cValue = claim.Value }).ToList();



            Claim c1 = new Claim("JsonTest", "[{}]");            

            return View(p1);
        }
    }
}
