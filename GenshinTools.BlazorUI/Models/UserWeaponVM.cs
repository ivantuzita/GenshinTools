using System.ComponentModel.DataAnnotations;

namespace GenshinTools.BlazorUI.Models;
public class UserWeaponVM {
    [Required]
    public int UserId { get; set; }
    [Required]
    public int WeaponId { get; set; }
}
