using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GenshinTools.Domain.Models.Identity;

[Keyless]
public class AuthRequest
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}
