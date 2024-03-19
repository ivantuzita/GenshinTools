using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GenshinTools.Domain.Models; 
[Keyless]
public class UserWeapon {
    [Required]
    public string UserId { get; set; }
    [Required]
    public int WeaponId { get; set; }
}
