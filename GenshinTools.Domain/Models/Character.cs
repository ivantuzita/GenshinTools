using System.ComponentModel.DataAnnotations;

namespace GenshinTools.Domain.Models;
public class Character {
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string PictureURL { get; set; }
    [Required]
    public int Quality { get; set; }
    //separated by comma
    [Required]
    public string WeekDays { get; set; }
    public string TalentMaterial { get; set; }
    public string TalentMaterialPictureURL { get; set; }
    //separated by semicolon
    public string DomainLocationURL { get; set;}
}
