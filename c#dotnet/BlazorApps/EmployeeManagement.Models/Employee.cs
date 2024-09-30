using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int employeeID { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        [MinLength(2)]
        public string lastName { get; set; }
        public string emailID { get; set; }
        public DateTime dateOfBirth { get; set; }
        public Gender gender { get; set; }
        public int DepartmentId { get; set; }
        public string photoPath { get; set; }
    }
}
