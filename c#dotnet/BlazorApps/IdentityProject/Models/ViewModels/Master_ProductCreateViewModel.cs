using System.ComponentModel.DataAnnotations;

namespace IdentityProject.Models.ViewModels
{
    public class Master_ProductCreateViewModel
    {
        [Required]
        [MaxLength(45)]
        public string Product { get; set; }
    }
}
