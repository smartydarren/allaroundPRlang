using AllModelsAndDB.Models;
using EmployeeMVCApp.Models;
using EmployeeMVCApp.Models.DBConn;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeMVCApp.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDataConnection _context;

        public HomeController(ILogger<HomeController> logger, AppDataConnection context)
        {
            _context = context;
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            //ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.username = HttpContext.User.Identity.Name;
            return View("Index");
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

        //Getting a JSON request
        [HttpGet]
        public JsonResult GetEmployees()
        {
            var InitialJson = _context.employeesDataSet.FirstOrDefault();
            var myJson = Json(InitialJson);
            return myJson;
        }

        [HttpPost]
        public JsonResult AddEmployees(Employee emp)
        {
            string R = "Reult";
            var Njson = Json(R);
            return Json(Njson);
        }
    }
}