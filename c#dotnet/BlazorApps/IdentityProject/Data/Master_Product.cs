using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityProject.Data
{
    [Table("Master_Product")]
    public class Master_Product
    {
        [Key]
        public int Id { get; set; }
        public string Product { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public ApplicationUser? CreUser { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public int? UpdatedBy { get; set; }
        [ForeignKey("UpdatedBy")]
        public ApplicationUser? UpdUser { get; set; }
        public bool Enabled { get; set; }


    }
}

