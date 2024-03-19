using GenshinTools.Domain.Models;

namespace GenshinTools.Application.Services.Interfaces;

public interface IUserWeaponService {
    Task AssociateWeaponToUser(string userId, int charId);
    Task DisassociateWeaponToUser(string userId, int charId);
    Task<List<Weapon>> GetUserWeapons(string userId);
    Task<List<Weapon>> GetUserWeaponsFiltered(string userId);
}
