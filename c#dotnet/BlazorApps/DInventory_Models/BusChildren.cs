using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DInventory_Models
{
    [Table("BusChildren", Schema = "Masters")]
    public class BusChildren
    {
        [Key]
        public int BusChildID { get; set; }

        [ForeignKey("BusParents")]
        public int BusParentID { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Minium 3"), MaxLength(50, ErrorMessage = " & Max 50 Chars")]
        //[Column(TypeName = "nvarchar(50)")]
        public string BusChildName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Minium 3"), MaxLength(8, ErrorMessage = " & Max 8 Chars")]
        //[Column(TypeName = "nvarchar(8)")]
        public string BusChildShortName { get; set; }

        [MaxLength(800, ErrorMessage = " You cant exceel 800 Characters")]
        //[Column(TypeName = "nvarchar(800)")]
        public string Description { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

     
       public virtual BusParents BusParents { get; private set; } //very Important
    }

}
