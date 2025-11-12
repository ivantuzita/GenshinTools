using GenshinTools.Application.DTOs;
using GenshinTools.Domain.Models;

namespace GenshinTools.Application.Services.Interfaces;

public interface IUserWeaponService {
    Task AssociateWeaponToUser(UserWeaponDTO model);
    Task DisassociateWeaponToUser(UserWeaponDTO model);
    Task<List<Weapon>> GetUserWeapons(string userId);
    Task<List<Weapon>> GetUserWeaponsFiltered(string userId);
}
