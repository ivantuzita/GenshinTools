using GenshinTools.BlazorUI.Models;
using GenshinTools.BlazorUI.Services.Base;

namespace GenshinTools.BlazorUI.Interfaces;

public interface IUserWeaponService {
    Task<Response<Guid>> AssociateWeaponToUser(string userId, int weaponId);
    Task<Response<Guid>> DisassociateWeaponToUser(string userId, int weaponId);
    Task<List<WeaponVM>> GetUserWeapons(string userId);
    Task<List<WeaponVM>> GetUserWeaponsFiltered(string userId);
}
