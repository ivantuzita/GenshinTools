using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GenshinTools.Domain.Models; 
[Keyless]
public class UserCharacter {
    [Required]
    public string UserId { get; set; }
    [Required]
    public int CharacterId { get; set; }
}
