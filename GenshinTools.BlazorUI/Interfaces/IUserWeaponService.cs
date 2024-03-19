using GenshinTools.BlazorUI.Models;

namespace GenshinTools.BlazorUI.Interfaces;

public interface IUserWeaponService {
    Task AssociateWeaponToUser(string userId, int weaponId);
    Task DisassociateWeaponToUser(string userId, int weaponId);
    Task<List<WeaponVM>> GetUserWeapons(string userId);
    Task<List<WeaponVM>> GetUserWeaponsFiltered(string userId);
}
