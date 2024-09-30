global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;

namespace DInventory_Models
{
    [Table("BusParents", Schema = "Masters")]
    public class BusParents
    {
        [Key]
        public int BusParentID { get; set; }
        
        [Required]
        [MinLength(3, ErrorMessage = "Minium 3"), MaxLength(50, ErrorMessage = " & Max 50 Chars")]
        //[Column(TypeName = "nvarchar(50)")]
        public string BusParentName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Minium 3"), MaxLength(8, ErrorMessage = " & Max 8 Chars")]
        //[Column(TypeName = "nvarchar(8)")]
        public string BusParentShortName { get; set; }

        [MaxLength(800, ErrorMessage = " You cant exceel 800 Characters")]
        //[Column(TypeName = "nvarchar(800)")]
        public string Description { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        public virtual List<BusChildren> ListOfBusChildren { get; set; } = new List<BusChildren>();

    }
}