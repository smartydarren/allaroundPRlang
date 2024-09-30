using System.ComponentModel.DataAnnotations;

namespace IdentityProject.Models.ViewModels
{
    public class Access_UserCreationViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "User Id")]
        public string UserId { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "EmailID")]
        public string Email { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
