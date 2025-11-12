using GenshinTools.Application.DTOs;
using GenshinTools.Application.Exceptions;
using GenshinTools.Application.Services.Interfaces;
using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models;
using GenshinTools.Domain.Models.Identity;

namespace GenshinTools.Application.Services;
public class UserWeaponService : IUserWeaponService {

    private readonly IUserWeaponRepository _repository;
    private readonly IGenericRepository<Weapon> _weaponRepo;
    private readonly IGenericRepository<User> _userRepo;
    public UserWeaponService(IUserWeaponRepository repository, IGenericRepository<Weapon> weaponRepo, IGenericRepository<User> userRepo) {
        _weaponRepo = weaponRepo;
        _repository = repository;
        _userRepo = userRepo;
    }

    public async Task AssociateWeaponToUser(UserWeaponDTO model)
    {
        var userExists = await _userRepo.GetByIdAsync(int.Parse(model.UserId));

        if (userExists == null)
            throw new NotFoundException($"User has not been found.");

        var weaponExists = await _weaponRepo.GetByIdAsync(model.WeaponId);

        if (weaponExists == null)
            throw new NotFoundException($"Weapon with id {model.WeaponId} has not been found.");

        var alreadyAssociated = await _repository.AlreadyAssociated(model.UserId, model.WeaponId);

        if (alreadyAssociated)
            throw new BadRequestException($"Weapon with id {model.WeaponId} is already associated with user.");

        await _repository.AssociateWeaponToUser(model.UserId, model.WeaponId);
    }

    public async Task DisassociateWeaponToUser(UserWeaponDTO model)
    {
        var userExists = await _userRepo.GetByIdAsync(int.Parse(model.UserId));

        if (userExists == null)
            throw new NotFoundException($"User has not been found.");

        var weaponExists = await _weaponRepo.GetByIdAsync(model.WeaponId);

        if (weaponExists == null)
            throw new NotFoundException($"Weapon with id {model.WeaponId} has not been found.");

        var alreadyAssociated = await _repository.AlreadyAssociated(model.UserId, model.WeaponId);

        if (!alreadyAssociated)
        {
            throw new BadRequestException($"Weapon with id {model.WeaponId} is not associated with user.");
        }

        await _repository.DisassociateWeaponToUser(model.UserId, model.WeaponId);
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
