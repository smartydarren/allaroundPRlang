using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnIdentityAut.Data
{
    public class Books
    {
        [Key]
        public int BookID { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string? Category { get; set; }
        public string? Language { get; set; }
        public int TotalPages { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdateOn { get; set; }

        //navigational properties
        [ForeignKey("LanguageRef")]
        public int? LanguageIDRef { get; set; } = 7;
        public Language? LanguageRef { get; set; }
    }
}
