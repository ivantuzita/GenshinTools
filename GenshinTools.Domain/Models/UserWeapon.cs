using System.ComponentModel.DataAnnotations;

namespace GenshinTools.Domain.Models; 
public class UserWeapon {
    [Required]
    [Key]
    public int Id { get; set; }
    [Required]
    public string UserId { get; set; }
    [Required]
    public int WeaponId { get; set; }
}
