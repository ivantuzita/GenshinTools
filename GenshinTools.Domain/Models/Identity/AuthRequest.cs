﻿using System.ComponentModel.DataAnnotations;

namespace GenshinTools.Domain.Models.Identity;
public class AuthRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
