using GenshinTools.BlazorUI.Models;

namespace GenshinTools.BlazorUI.Interfaces;

public interface IUserWeaponService {
    Task AssociateWeaponToUser(int userId, int weaponId);
    Task DisassociateWeaponToUser(int userId, int weaponId);
    Task<List<WeaponVM>> GetUserWeapons(int userId);
    Task<List<WeaponVM>> GetUserWeaponsFiltered(int userId);
}
