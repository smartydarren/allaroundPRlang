global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
using AllModelsAndDB.Models;

namespace AllModelsAndDB.Models
{
    [Table("Employee", Schema = "Employee")]
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        
        [ForeignKey("AddressID")]
        public AddressEmp? Address { get; set; }
    }
}