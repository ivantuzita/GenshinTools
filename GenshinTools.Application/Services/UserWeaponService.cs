using AutoMapper;
using GenshinTools.Application.Services.Interfaces;
using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models;

namespace GenshinTools.Application.Services; 
public class UserWeaponService : IUserWeaponService {

    private readonly IUserItemsRepository<UserWeapon> _repository;
    private readonly IMapper _mapper;

    public UserWeaponService(IUserItemsRepository<UserWeapon> repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<List<UserWeapon>> GetItemsByUserId(int userId) {
        var result = await _repository.GetItemsByUserId(userId);

        if (result == null) {
            throw new Exception($"No characters found for userId {userId}.");
        }

        return result;
    }

    public async Task<List<UserWeapon>> GetTodayItemsByUserId(int userId) {
        //shouldn't return errors because maybe you don't have any leveling up to do today
        var result = await _repository.GetTodayItemsByUserId(userId);
        return result;
    }
}
