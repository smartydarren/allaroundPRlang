using IdentityProject.Data;

namespace IdentityProject.Models.ViewModels.Role
{
    public class RoleConfigurationViewModel
    {       
        //public Access_Menu menuItems { get; set; }
        public string? MenuName { get; set; }
        public int MenuID { get; set; }
        public bool AllowView { get; set; }
        public bool AllowCreate { get; set; }
        public bool AllowUpdate { get; set; }
        public bool AllowDelete { get; set; }
        public int? updatedBy { get; set; }
        public DateTime? updatedDate { get; set; }


    }
}
