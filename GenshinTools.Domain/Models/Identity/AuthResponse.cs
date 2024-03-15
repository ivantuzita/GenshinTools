using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinTools.Domain.Models.Identity;

public class AuthResponse
{
    public string Id { get; set; }
    public string Username { get; set; }
    public string Token { get; set; }
}
