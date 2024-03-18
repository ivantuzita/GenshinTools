using System.ComponentModel.DataAnnotations;

namespace GenshinTools.BlazorUI.Models.Authentication;

public class UserVM
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}
