using GenshinTools.Domain.Models;

namespace GenshinTools.Application.Services.Interfaces;

public interface IUserWeaponService {
    Task<List<UserWeapon>> GetItemsByUserId(int userId);
    Task<List<UserWeapon>> GetTodayItemsByUserId(int userId);
}
