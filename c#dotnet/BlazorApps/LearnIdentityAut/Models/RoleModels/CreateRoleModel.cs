using System.ComponentModel.DataAnnotations;

namespace LearnIdentityAut.Models.RoleModels
{
    public class CreateRoleModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
