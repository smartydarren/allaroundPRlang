using DInventory_Models;
using Microsoft.AspNetCore.Mvc;

namespace DInventory_MVCApplication.Controllers
{
    [Route("Students")]
    public class StudentController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAllStudents()
        {
            var listOfStudents = StudentsList();
            return View(listOfStudents);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetStudent(int id)
        {
            var listOfStudents = StudentsList();
            var singleStudent = listOfStudents.FirstOrDefault(m => m.StudentID == id);
            return View(singleStudent);
        }

        [HttpGet]
        [Route("/Create")]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        [Route("/Create")]
        public IActionResult AddStudent(Student stud)
        {
            StudentsList().Add(stud);
            //listOfStudents.Add(new Student {StudentID = stud.StudentID, StudentName=stud.StudentName, StudentAddress= stud.StudentAddress });
            return RedirectToAction("GetAllStudents","student");
        }

        //loose binding example
        [HttpGet]
        [Route("/FormMethod")]
        public IActionResult FormMethod()
        {
            return View();
        }

        [HttpPost]
        [Route("/FormMethod")]
        public IActionResult FormMethod(Student stud)
        {
            if (ModelState.IsValid)
            {
                StudentsList().Add(stud);
                return RedirectToAction("GetAllStudents", "student");
            }
            return View("FormMethod");
        }

        //Tightly binding example - it uses Lambda
        [HttpGet]
        [Route("/TightBinding")]
        public IActionResult TightBindingMethod()
        {
            return View();
        }

        [HttpPost]
        [Route("/TightBinding")]
        public IActionResult TightBindingMethod(Student stud)
        {
            if (ModelState.IsValid)
            {
                StudentsList().Add(stud);
                return RedirectToAction("GetAllStudents", "student");
            }
            return View("TightBindingMethod");
        }


        private static List<Student> StudentsList()
        {
            return new List<Student>()
            {
                    new Student()
                {
                    StudentID = 1,
                    StudentName = "Darren Quadros",
                    StudentAddress = "Agripada"
                },
                    new Student()
                {
                    StudentID = 2,
                    StudentName = "Aislinn Quadros",
                    StudentAddress = "Kanjurmarg"
                },
                    new Student()
                {
                    StudentID = 3,
                    StudentName = "Denver Quadros",
                    StudentAddress = "St Ignatius High School"
                },
                    new Student()
                {
                    StudentID = 4,
                    StudentName = "Adelyn Quadros",
                    StudentAddress = "St Josephs High School"
                }
            };            

        }

    }
}
