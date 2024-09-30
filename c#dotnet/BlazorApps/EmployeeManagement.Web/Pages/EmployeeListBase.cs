using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeService employeeService { get; set; }
        public IEnumerable<Employee> EmployeesArray { get; set; }
        protected override async Task OnInitializedAsync()
        {
            EmployeesArray = new List<Employee>();
            EmployeesArray = (await employeeService.GetEmployee());
            
            //LoadEmployees();
            //return base.OnInitializedAsync();
        }

        private void LoadEmployees()
        {
            Employee e1 = new Employee
            {
                employeeID = 1,
                firstName = "Darren",
                lastName = "Quadros",
                emailID = "smartydarren@gmail.com",
                gender = Gender.Male,
                DepartmentId = 1,
                photoPath = "images/Boy.jpg"
            };

            Employee e2 = new Employee
            {
                employeeID = 2,
                firstName = "Aislinn",
                lastName = "Quadros",
                emailID = "aislinn.quadros@gmail.com",
                gender = Gender.Female,
                DepartmentId = 2,
                photoPath = "images/Girl.jpg"
            };

            Employee e3 = new Employee
            {
                employeeID = 2,
                firstName = "Ashley",
                lastName = "Ribeiro",
                emailID = "ashley@gmail.com",
                gender = Gender.Male,
                DepartmentId = 1,
                photoPath = "images/Boy.jpg"
            };

            EmployeesArray = new List<Employee> { e1, e2, e3 };


        }
    }
}
