
using AllModelsAndDB.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMVCApp.Models.DBConn
{
    public class AppDataConnection : DbContext
    {
        public AppDataConnection(DbContextOptions<AppDataConnection> options) : base(options)
        {

        }

        public DbSet<Employee> employeesDataSet { get; set; }
        public DbSet<AddressEmp> employeeAddress { get; set; }
        public DbSet<Users> loginUser { get; set; }

    }
}
