using System.ComponentModel.DataAnnotations;

namespace GenshinTools.Domain.Models; 
public class AscensionMaterial {
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string PictureURL { get; set; }
    //separated by comma
    [Required]
    public string WeekDays { get; set; }
    //separated by semicolon
    public string DomainLocationURL { get; set; }
}