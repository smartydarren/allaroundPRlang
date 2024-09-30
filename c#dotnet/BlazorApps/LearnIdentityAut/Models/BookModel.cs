using LearnIdentityAut.Helpers;
using System.ComponentModel.DataAnnotations;

namespace LearnIdentityAut.Models
{
    public class BookModel
    {
        public int BookID { get; set; }
        [Required(ErrorMessage ="Please Enter Book Title")]
        [DataType(DataType.Text)]
        [MyCustomValidation("mvc",ErrorMessage ="Please enter a valid title")]
        public string BookTitle { get; set; }
        [Required(ErrorMessage = "Please Enter Author")]
        public string? Author { get; set; }
        [Required(ErrorMessage = "Please Enter Description")]
        public string? Description { get; set; }
        public string? Category { get; set; }
        //[Required]
        public string? Language { get; set; }
        //[Required(ErrorMessage = "Please select a Language")]
        public List<string>? MultiLanguage { get; set; }
        public int? TotalPages { get; set; }
        [Required(ErrorMessage = "Please select a Language")]
        public int? LanguageIDRef { get; set; }
        [Display(Name ="Please upload a cover photo")]
        //[Required(ErrorMessage ="Cover Photo upload Mandatory")]
        public IFormFile CoverPhoto { get; set; }

    }
}
