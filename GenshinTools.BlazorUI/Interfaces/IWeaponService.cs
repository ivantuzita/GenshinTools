using GenshinTools.BlazorUI.Models;
using GenshinTools.BlazorUI.Services.Base;

namespace GenshinTools.BlazorUI.Interfaces;

public interface IWeaponService {
    Task<List<WeaponVM>> GetAllWeaponsAsync();
    Task<WeaponVM> GetWeaponByIdAsync(int id);
    Task<Response<Guid>> CreateWeaponAsync(WeaponVM weapon);
    Task<Response<Guid>> UpdateWeaponAsync(int id, WeaponVM weapon);
    Task<Response<Guid>> DeleteWeaponByIdAsync(int id);
}
