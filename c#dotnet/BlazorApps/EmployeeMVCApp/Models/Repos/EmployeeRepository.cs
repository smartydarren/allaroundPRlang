using AllModelsAndDB.Models;
using EmployeeMVCApp.Models.DBConn;

namespace EmployeeMVCApp.Models.Repos
{
    public class EmployeeRepository : ICrudOperations

    {

    protected readonly AppDataConnection _context;
    
        public EmployeeRepository(AppDataConnection dbCon)
        {
            this._context = dbCon;
        }

        public int AddEmployee(Employee model)
        {
            _context.employeesDataSet.Add(model);
            _context.SaveChanges();
            return model.EmployeeID;
         }

        public List<Employee> GetAllEmployees()
        {
            var result1 = _context.employeesDataSet.ToList();
            //OR using custom Model, but its better to create a another Class/Type
            var result = _context.employeesDataSet.Select(x => new Employee()
            {
                EmployeeID = x.EmployeeID,
                EmployeeName = x.EmployeeName,
                Address = new AddressEmp() { 
                    Address = x.Address.Address
                }
            }
            ).ToList();

            return result;
        }

        public bool DeleteEmployee(int id)
        {
            var emp = new Employee
            {
                EmployeeID = id
            };
            _context.Entry(emp).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();

            return false;
        }
    }
}
