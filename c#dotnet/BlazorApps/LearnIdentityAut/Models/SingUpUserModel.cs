using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LearnIdentityAut.Models
{
    public class SingUpUserModel
    {

        [Required(ErrorMessage = "Enter your name")]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter your Email")]
        [EmailAddress(ErrorMessage ="Please enter a valid email")]
        [Remote(action: "IsEmailInUseForNewUser", controller:"Account")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter a password")]
        [Compare("ConfirmPassword",ErrorMessage ="Password does not match")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Reconfirm your password")] [Display(Name ="ReConfirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
