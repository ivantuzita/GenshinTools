using System.ComponentModel.DataAnnotations;

namespace GenshinTools.Domain.Models.Identity;

public class RegistrationRequest
{
    [Required]
    public string Username { get; set; }
    [Required]
    [MinLength(6)]
    public string Password { get; set; }
}
