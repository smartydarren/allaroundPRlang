using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConsoleProject.Models;

namespace ConsoleAppLearning.LearnConcepts.Data
{
    [Table("Access_MainMenu")]
    public class Access_MainMenu
    {
        [Key]
        public int Id { get; set; }
        public string MainMenu { get; set; }
        public DateTime CreatedDate { get; set; }


        public int CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public Users? CreUser { get; set; }


        [Column(TypeName = "bit")]
        public bool Enabled { get; set; }

        public int? OrderBy { get; set; }

    }
}
