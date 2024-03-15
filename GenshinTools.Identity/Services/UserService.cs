using GenshinTools.Application.Services.Interfaces.Identity;
using GenshinTools.Domain.Models.Identity;
using GenshinTools.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinTools.Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<User> GetUser(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        return new User
        {
            Id = user.Id,
            Name = user.UserName
        };
    }

    public async Task<List<User>> GetUsers()
    {
        var users = await _userManager.GetUsersInRoleAsync("Users");
        return users.Select(x => new User {
            Id = x.Id,
            Name = x.UserName
        }).ToList();
    }
}
