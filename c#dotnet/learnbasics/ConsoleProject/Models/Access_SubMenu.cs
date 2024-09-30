using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConsoleProject.Models;

namespace ConsoleAppLearning.LearnConcepts.Data
{
    [Table("Access_SubMenu")]
    public class Access_SubMenu
    {
        [Key]
        public int Id { get; set; }
        public string SubMenu { get; set; }
        public string Controller { get; set; }
        public string? Action { get; set; }
        public DateTime CreatedDate { get; set; }


        public int CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public Users CreUser { get; set; }

        public int? MainMenuId { get; set; }
        [ForeignKey("MainMenuId")]
        public Access_MainMenu MainMenu { get; set; }


        [Column(TypeName = "bit")]
        public bool Enabled { get; set; }

        public int? OrderBy { get; set; }
    }
}
