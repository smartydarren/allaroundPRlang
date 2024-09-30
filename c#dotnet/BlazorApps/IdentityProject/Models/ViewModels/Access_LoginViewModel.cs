using System.ComponentModel.DataAnnotations;

namespace IdentityProject.Models.ViewModels
{
    public class Access_LoginViewModel
    {
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me?")]
        public bool RememberMe { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
