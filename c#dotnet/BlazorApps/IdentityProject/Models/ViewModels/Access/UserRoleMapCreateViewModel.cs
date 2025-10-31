namespace IdentityProject.Models.ViewModels.Access
{
    public class UserRoleMapCreateViewModel
    {
        public int UserId { get; set; }
        public int RoleID { get; set; }
        public string? RoleName { get; set; }
        public bool isChecked { get; set; }           
    }
}
