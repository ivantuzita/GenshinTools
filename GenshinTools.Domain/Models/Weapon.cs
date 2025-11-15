using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenshinTools.Domain.Models; 
public class Weapon {
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string PictureURL { get; set; }
    [Required]
    public int Quality { get; set; }
    [ForeignKey("ascension_material")]
    public int IdAscensionMaterial { get; set; }
    public virtual AscensionMaterial AscensionMaterial { get; set; }
}
