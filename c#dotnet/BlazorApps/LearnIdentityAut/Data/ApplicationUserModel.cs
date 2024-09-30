using Microsoft.AspNetCore.Identity;

namespace LearnIdentityAut.Models
{
    public class ApplicationUserModel : IdentityUser
    {
        public string? Name { get; set; }
    }
}
