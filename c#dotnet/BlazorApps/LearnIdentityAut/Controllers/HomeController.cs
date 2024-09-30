using LearnIdentityAut.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Dynamic;

namespace LearnIdentityAut.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration _configuration)
        {
            _logger = logger;
            configuration = _configuration;
        }

        [Route("")]
        [Route("Index")]
        [Route("home")]
        public IActionResult Index()
        {
            //viewBAG Eg
            ViewBag.Title1 = "Darren has created viewbag";
            ViewBag.newBook = new BookModel() { BookID = 1, Author = "Aislinn" };
            dynamic data = new ExpandoObject();
            data.ID = 5; data.Name = "Denver";
            ViewBag.expando = data;

            //viewData Eg
            ViewData["Tile2"] = "Darren has created viewdata";
            ViewData["book1"] = new BookModel { BookID = 6, Author = "Luiza" };

            //reading appsetting data
            var myAppName = configuration["AppName"];
            var myAppNameChild = configuration["Key2:key2ChildObj1"];

            var useGetValueMethod = configuration.GetValue<bool>("NewObject:MyBooleanValue");
            var useGetValueMethod1 = configuration.GetValue<string>("NewObject:MyBooleanString");

            ViewBag.useGetValueMethod1 = useGetValueMethod1;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("About-us/{id}", Name="AboutDarren")]
        public IActionResult Aboutus(int id)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}