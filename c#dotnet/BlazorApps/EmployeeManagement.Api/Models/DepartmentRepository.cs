using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext appDbContext;
        public DepartmentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public Departments GetDepartment(int departmentID)
        {
            return appDbContext.VarDepartments.FirstOrDefault(dept => dept.departmentID == departmentID);
        }

        public IEnumerable<Departments> GetDepartments()
        {
            return appDbContext.VarDepartments.ToList();
        }
    }
}
