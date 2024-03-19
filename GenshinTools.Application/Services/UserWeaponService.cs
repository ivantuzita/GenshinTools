using AutoMapper;
using GenshinTools.Application.Exceptions;
using GenshinTools.Application.Services.Interfaces;
using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models;
using GenshinTools.Domain.Models.Identity;

namespace GenshinTools.Application.Services;
public class UserWeaponService : IUserWeaponService {

    private readonly IUserWeaponRepository _repository;
    private readonly IGenericRepository<Weapon> _weaponRepo;

    public UserWeaponService(IUserWeaponRepository repository,
        IGenericRepository<Weapon> weaponRepo)
    {
        _weaponRepo = weaponRepo;
        _repository = repository;
    }

    public async Task AssociateWeaponToUser(string userId, int weaponId)
    {
        var weaponExists = _weaponRepo.GetByIdAsync(weaponId);

        if (weaponExists == null)
        {
            throw new NotFoundException($"Weapon with id {weaponId} has not been found.");
        }

        var alreadyAssociated = await _repository.AlreadyAssociated(userId, weaponId);

        if (alreadyAssociated) {
            throw new BadRequestException($"Weapon with id {weaponId} is already associated with user id {userId}.");
        }

        await _repository.AssociateWeaponToUser(userId, weaponId);
    }

    public async Task DisassociateWeaponToUser(string userId, int weaponId)
    {
        var weaponExists = _weaponRepo.GetByIdAsync(weaponId);

        if (weaponExists == null)
        {
            throw new NotFoundException($"Weapon with id {weaponId} has not been found.");
        }

        var alreadyAssociated = await _repository.AlreadyAssociated(userId, weaponId);

        if (!alreadyAssociated)
        {
            throw new BadRequestException($"Weapon with id {weaponId} is not associated with user id {userId}.");
        }

        await _repository.DisassociateWeaponToUser(userId, weaponId);
    }

    public async Task<List<Weapon>> GetUserWeapons(string userId)
    {
        return await _repository.GetUserWeapons(userId);
    }

    public async Task<List<Weapon>> GetUserWeaponsFiltered(string userId)
    {
        return await _repository.GetUserWeaponsFiltered(userId);
    }
}
