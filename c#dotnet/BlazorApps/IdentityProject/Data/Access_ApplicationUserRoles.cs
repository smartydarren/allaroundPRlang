using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityProject.Data
{
    [Table("AspNetUserRoles")]
    public class Access_ApplicationUserRoles : IdentityUserRole<int>
    {          
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        [ForeignKey("ModifiedBy")]
        public ApplicationUser ModUserFk { get; set; }
        public int BatchNo { get; set; }        
    }
}
