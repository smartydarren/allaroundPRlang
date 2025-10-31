using System.ComponentModel.DataAnnotations;

namespace LearnIdentityAut.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage ="Please Enter an Email"),EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password Required")][DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
