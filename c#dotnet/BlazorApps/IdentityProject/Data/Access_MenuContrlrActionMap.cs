using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityProject.Data
{
    [Table("Access_MenuContrlrActionMap")]
    public class Access_MenuContrlrActionMap
    {
        [Key]
        public int Id { get; set; }  
        public int MenuID { get; set; }
        [ForeignKey("MenuID")]
        public Access_Menu Menus { get; set; }

        public string ControllerName { get; set; }
        public string ActionMethod { get; set; } 
        public bool AllowViewType { get; set; } = false;
        public bool AllowCreateType { get; set; } = false;
        public bool AllowEditType { get; set; } = true;
        public bool AllowDeleteType { get; set; } = true;
    }
}
