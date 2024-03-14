using System.ComponentModel.DataAnnotations;

namespace GenshinTools.Domain.Models; 
public class Weapon {
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string PictureURL { get; set; }
    public string WeekDays { get; set; }
}
