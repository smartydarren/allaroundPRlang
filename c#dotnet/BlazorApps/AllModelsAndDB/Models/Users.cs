using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllModelsAndDB.Models
{
    [Table("Users", Schema = "Access")]
    public class Users
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}
