using GenshinTools.Domain.Models;

namespace GenshinTools.Domain.Interfaces;

public interface IUserWeaponRepository {
    Task AssociateWeaponToUser(int userId, int weaponId);
    Task DisassociateWeaponToUser(int userId, int weaponId);
    Task<List<Weapon>> GetUserWeapons(int userId);
    Task<List<Weapon>> GetUserWeaponsFiltered(int userId);
    Task<bool> AlreadyAssociated(int userId, int weaponId);
}
