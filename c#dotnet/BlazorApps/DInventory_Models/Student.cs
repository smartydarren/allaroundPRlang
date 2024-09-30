using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DInventory_Models
{
    [Table("Students", Schema = "Learn")]
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Please Enter Your Name")]
        [MinLength(3, ErrorMessage = "Minium 3"), MaxLength(50, ErrorMessage = " & Max 50 Chars")]
        public string StudentName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Minium 3"), MaxLength(100, ErrorMessage = " & Max 100 Chars")]
        public string StudentAddress { get; set; }
    }
}
