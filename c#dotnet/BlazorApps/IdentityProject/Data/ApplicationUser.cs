using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IdentityProject.Data
{
    public class ApplicationUser : IdentityUser<int>
    {    
        public string Name { get; set; }
        
    }
}
