using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;
        public EmployeeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await appDbContext.VarEmployees.AddAsync(employee);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            var result = appDbContext.VarEmployees
                    .FirstOrDefault(e => e.employeeID == employeeId);
            if (result != null)
            {
                appDbContext.VarEmployees.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            
            return await appDbContext.VarEmployees
                    .FirstOrDefaultAsync(e => e.employeeID == employeeId);
        }

        public async Task<Employee> GetEmployeeByEmail(string employeeEmail)
        {
            var result = await appDbContext.VarEmployees
                    .FirstOrDefaultAsync(e => e.emailID == employeeEmail);
            return result;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await appDbContext.VarEmployees.ToListAsync();

        }

        public async Task<IEnumerable<Employee>> SearchEmployees(string name, Gender? gender)
        {
            IQueryable<Employee> query = appDbContext.VarEmployees;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(Emp => Emp.firstName.Contains(name)
                    || Emp.lastName.Contains(name));
            }

            if (gender != null)
            {
                query = query.Where(G => G.gender == gender);
            }

            return await query.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await appDbContext.VarEmployees
                    .FirstOrDefaultAsync(e => e.employeeID == employee.employeeID);
            if (result != null)
            {
                result.firstName = employee.firstName;
                result.lastName = employee.lastName;
                result.emailID = employee.emailID;
                result.dateOfBirth = employee.dateOfBirth;
                result.gender = employee.gender;
                result.DepartmentId = employee.DepartmentId;
                result.photoPath = employee.photoPath;

                await appDbContext.SaveChangesAsync();
                return result;
            }return null;

        }
    }
}
