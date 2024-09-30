using System.Linq;
using EmployeeManagement.Api.Models;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public readonly IEmployeeRepository EmployeeRepository;
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.EmployeeRepository = employeeRepository;
        }
        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Employee>>> Search(string name, Gender? gender)
        {
            try
            {
                var reault = await EmployeeRepository.SearchEmployees(name, gender);
                
                if (reault.Any())
                {
                    return Ok(reault);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                return Ok(await EmployeeRepository.GetEmployees());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving Data");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var result = await EmployeeRepository.GetEmployee(id);
            if (result == null)
            {
                return NotFound($"Employee with ID {id} not found");
            }
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }

                var emp = await EmployeeRepository.GetEmployeeByEmail(employee.emailID);
                if (emp != null)
                {
                    ModelState.AddModelError("Email", "Email ID already in use");
                    return BadRequest(ModelState);
                }

                var CreatedEmployee = await EmployeeRepository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployeeById), new { id = CreatedEmployee.employeeID }, CreatedEmployee);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id , Employee employee)
        {
            try
            {
                if (id != employee.employeeID)
                {
                    return BadRequest("Employee ID Mismatch");
                }

                var empToUpdate = await EmployeeRepository.GetEmployee(id);
                if (empToUpdate == null)
                {
                    return NotFound($"Employee with ID: {id} not found");
                }

                return await EmployeeRepository.UpdateEmployee(employee);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating Employee");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var empToDelete = await EmployeeRepository.GetEmployee(id);
                if (empToDelete == null)
                {
                    return NotFound($"Employee with ID: {id} not found");
                }
                await EmployeeRepository.DeleteEmployee(id);
                return empToDelete;

            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
