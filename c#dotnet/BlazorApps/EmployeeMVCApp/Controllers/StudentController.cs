using AllModelsAndDB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMVCApp.Controllers
{
   // [Authorize]
    public class StudentController : Controller
    {

        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student stud)
        {
            return View();
        }

        [ResponseCache(Duration =20, Location = ResponseCacheLocation.Client)]
        public ActionResult GetDate()
        {
            return View();
        }

        public ActionResult GetError()
        {

            throw new Exception();
            
        }
        public ActionResult ErrorPage()
        {
            return View("ErrorPage");
        }
    }
}
