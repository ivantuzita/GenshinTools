using GenshinTools.Application.DTOs;
using GenshinTools.Domain.Models;

namespace GenshinTools.Application.Services.Interfaces; 
public interface IWeaponService {
    Task<List<Weapon>> GetAllAsync();
    Task<Weapon> GetByIdAsync(int id);
    Task CreateAsync(WeaponDTO weaponDTO);
    Task UpdateAsync(WeaponDTO weaponDTO);
    Task DeleteByIdAsync(int id);
}
