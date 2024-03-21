using GenshinTools.Application.Services.Interfaces;
using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models;

namespace GenshinTools.Application.Services;
public class WeaponService : IWeaponService {

    private readonly IGenericRepository<Weapon> _repository;

    public WeaponService(IGenericRepository<Weapon> repository) {
        _repository = repository;
    }

    public async Task<List<Weapon>> GetAllAsync() {
        var result = await _repository.GetAllAsync();

        if (result == null) {
            throw new Exception("No weapons found.");
        }

        return result;
    }

    public async Task<Weapon> GetByIdAsync(int id) {
        var result = await _repository.GetByIdAsync(id);
        return result;
    }

}
