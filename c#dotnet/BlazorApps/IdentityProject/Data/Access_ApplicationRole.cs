using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityProject.Data
{
    public class Access_ApplicationRole : IdentityRole<int>
    {        
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public ApplicationUser? CreUser { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? UpdatedBy { get; set; } 
        [ForeignKey("UpdatedBy")]
        public ApplicationUser? UpdUser { get; set; }

        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }
    }
}
