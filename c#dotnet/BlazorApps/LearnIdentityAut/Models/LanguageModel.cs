using System.ComponentModel.DataAnnotations;

namespace LearnIdentityAut.Models
{
    public class LanguageModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter language")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
