using ConsoleProject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleAppLearning.LearnConcepts.data;

[Table("Access_Menu")]
public class Access_Menu
{
    [Key]
    public int Id { get; set; }
    public string MenuName { get; set; }
    public int? ParentMenuId { get; set; }
    public string? Controller { get; set; }
    public string? Action { get; set; }

    public DateTime CreatedDate { get; set; }
    public int CreatedBy { get; set; }
    [ForeignKey("CreatedBy")]
    public Users CreUser { get; set; }

    [Column(TypeName = "bit")]
    public bool Enabled { get; set; }
    public int? OrderBy { get; set; }
    public bool IsForMenu { get; set; } = false;
    public bool IsForRole { get; set; } = false;
}
