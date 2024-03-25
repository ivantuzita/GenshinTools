using System.ComponentModel.DataAnnotations;

namespace GenshinTools.Domain.Models; 
public class UserCharacter {
    [Required]
    [Key]
    public int Id { get; set; }
    [Required]
    public string UserId { get; set; }
    [Required]
    public int CharacterId { get; set; }
}
