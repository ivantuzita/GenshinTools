using AutoMapper;
using GenshinTools.Application.DTOs;
using GenshinTools.Application.Exceptions;
using GenshinTools.Application.Services.Interfaces;
using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models;

namespace GenshinTools.Application.Services;
public class WeaponService : IWeaponService {

    private readonly IGenericRepository<Weapon> _repository;
    private readonly IMapper _mapper;

    public WeaponService(IGenericRepository<Weapon> repository, IMapper mapper) {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task CreateAsync(WeaponDTO weaponDTO) {
        var newWeapon = _mapper.Map<Weapon>(weaponDTO);
        await _repository.CreateAsync(newWeapon);
    }

    public async Task DeleteByIdAsync(int id) {
        await _repository.DeleteByIdAsync(id);
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

    public async Task UpdateAsync(WeaponDTO weaponDTO) {
        var existingWeapon = await _repository.GetByIdAsync(weaponDTO.Id);

        if (existingWeapon == null) {
            throw new NotFoundException($"Weapon with id {weaponDTO.Id} has not been found.");
        }

        var newWeapon = _mapper.Map<Weapon>(weaponDTO);
        await _repository.UpdateAsync(newWeapon);
    }
}
