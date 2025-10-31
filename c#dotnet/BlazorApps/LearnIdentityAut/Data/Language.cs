using System.ComponentModel.DataAnnotations;

namespace LearnIdentityAut.Data
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string? Description { get; set; }

        //Navigational Properties
        //public ICollection<Books> Books { get; set; }
    }
}
