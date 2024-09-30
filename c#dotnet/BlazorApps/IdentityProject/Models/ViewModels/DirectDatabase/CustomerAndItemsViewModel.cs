using System.ComponentModel.DataAnnotations;

namespace IdentityProject.Models.ViewModels.DirectDatabase
{
    public class CustomerAndItemsViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Please Enter Customer Name")]
        [MaxLength(50)]
        public string? CustomerName { get; set; }
    }
}
