using System.ComponentModel.DataAnnotations;

namespace IdentityProject.Models.ViewModels.Role
{
    public class Access_RoleCreateViewModel
    {
        public int ? RoleId { get; set; }

        [Required(ErrorMessage = "Please Enter Role Name")]
        [MaxLength(25)]
        public string RoleName { get; set; }

        [MaxLength(150)]
        public string? Description { get; set; }
    }
}
