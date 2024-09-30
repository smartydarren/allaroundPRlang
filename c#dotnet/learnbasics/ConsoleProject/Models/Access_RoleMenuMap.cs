using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleAppLearning.LearnConcepts.Data
{
    [Table("Access_RoleMenuMap")]
    [Index(nameof(RoleId), nameof(MenuId), IsUnique = true)]
    public class Access_RoleMenuMap
    {
        [Key]
        public int Id { get; set; }
       
        public int RoleId { get; set; }
        
       
        public int MenuId { get; set; }
        
       
        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }
                 
        public int BatchNo { get; set; }
        public bool AllowView { get; set; }
        public bool AllowCreate { get; set; }
        public bool AllowUpdate { get; set; }
        public bool AllowDelete { get; set; }
    }
}
