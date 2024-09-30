using IdentityProject.Data;

namespace IdentityProject.Models.ViewModels
{
    public class Product_ProductListViewModel
    {
        public int ProductID { get; set; }
        public String ProductName { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

    }
}
