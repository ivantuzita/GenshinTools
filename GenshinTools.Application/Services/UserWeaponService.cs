using AutoMapper;
using GenshinTools.Application.Exceptions;
using GenshinTools.Application.Services.Interfaces;
using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models;

namespace GenshinTools.Application.Services; 
public class UserWeaponService : IUserWeaponService {

    private readonly IUserWeaponRepository _repository;
    private readonly IGenericRepository<Weapon> _weaponRepo;
    private readonly IGenericRepository<User> _userRepo;

    public UserWeaponService(IUserWeaponRepository repository,
        IGenericRepository<Weapon> weaponRepo,
        IGenericRepository<User> userRepo)
    {
        _weaponRepo = weaponRepo;
        _userRepo = userRepo;
        _repository = repository;
    }

    public async Task AssociateWeaponToUser(int userId, int weaponId)
    {
        var userExists = _userRepo.GetByIdAsync(userId);

        if (userExists == null)
        {
            throw new NotFoundException($"User with id {userId} has not been found.");
        }

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

    public async Task DisassociateWeaponToUser(int userId, int weaponId)
    {
        var userExists = _userRepo.GetByIdAsync(userId);

        if (userExists == null)
        {
            throw new NotFoundException($"User with id {userId} has not been found.");
        }

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

    public async Task<List<Weapon>> GetUserWeapons(int userId)
    {
        var userExists = _userRepo.GetByIdAsync(userId);

        if (userExists == null)
        {
            throw new NotFoundException($"User with id {userId} has not been found.");
        }

        return await _repository.GetUserWeapons(userId);
    }

    public async Task<List<Weapon>> GetUserWeaponsFiltered(int userId)
    {
        var userExists = _userRepo.GetByIdAsync(userId);

        if (userExists == null)
        {
            throw new NotFoundException($"User with id {userId} has not been found.");
        }

        return await _repository.GetUserWeaponsFiltered(userId);
    }
}
