using GenshinTools.Domain.Models;

namespace GenshinTools.Domain.Interfaces;

public interface IUserWeaponRepository {
    Task AssociateWeaponToUser(string userId, int weaponId);
    Task DisassociateWeaponToUser(string userId, int weaponId);
    Task<List<Weapon>> GetUserWeapons(string userId);
    Task<List<Weapon>> GetUserWeaponsFiltered(string userId);
    Task<bool> AlreadyAssociated(string userId, int weaponId);
}
