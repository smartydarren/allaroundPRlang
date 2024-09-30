using EmployeeManagement.Models;

namespace EmployeeManagement.Api.Models
{
    public interface IDepartmentRepository
    {
        IEnumerable<Departments> GetDepartments();
        Departments GetDepartment(int departmentID);

    }
}
