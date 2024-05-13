using System.ComponentModel.DataAnnotations;


namespace webapiLearn.Models
{
    public class Shirt
    {
        [Required]
        public int ShirtId { get; set; }
        public string? Brand { get; set;}
        public string? Color { get; set; }
        [Required]
        public int Size { get; set; }
        public string? Gender { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
