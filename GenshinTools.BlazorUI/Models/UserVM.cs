using System.ComponentModel.DataAnnotations;

namespace GenshinTools.BlazorUI.Models;
public class UserVM {
    [Required]
    public int Id { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}
