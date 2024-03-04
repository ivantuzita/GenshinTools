using System.ComponentModel.DataAnnotations;

namespace GenshinTools.BlazorUI.Models;
public class UserCharacterVM {
    [Required]
    public int UserId { get; set; }
    [Required]
    public int CharacterId { get; set; }
}
