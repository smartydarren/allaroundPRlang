using System.ComponentModel.DataAnnotations;

namespace LearnIdentityAut.Models.RoleModels
{
    public class EditRoleModel
    {
        public EditRoleModel()
        {
            Users = new List<string>();
        }
        public string Id { get; set; }

        [Required(ErrorMessage ="Role Name is Required")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }
    }
}
