using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinTools.Domain.Models.Identity;

public class RegistrationRequest
{
    [Required]
    public string Username { get; set; }
    [Required]
    [MinLength(6)]
    public string Password { get; set; }
}
