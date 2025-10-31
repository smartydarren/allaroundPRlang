using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllModelsAndDB.Models
{
    [Table("AddressEmp", Schema = "Employee")]
    public class AddressEmp
    {
        [Key]
        public int AddressID { get; set; }
        public string Address { get; set; }
    }
}
