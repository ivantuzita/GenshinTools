using AutoMapper;
using GenshinTools.Application.Services.Interfaces;
using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models;

namespace GenshinTools.Application.Services; 
public class UserCharacterService : IUserCharacterService {

    private readonly IUserItemsRepository<UserCharacter> _repository;
    private readonly IMapper _mapper;

    public UserCharacterService(IUserItemsRepository<UserCharacter> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<UserCharacter>> GetItemsByUserId(int userId) {
        var result = await _repository.GetItemsByUserId(userId);

        if (result == null) {
            throw new Exception($"No characters found for userId {userId}.");
        }

        return result;
    }

    public async Task<List<UserCharacter>> GetTodayItemsByUserId(int userId) {
        //shouldn't return errors because maybe you don't have any leveling up to do today
        var result = await _repository.GetTodayItemsByUserId(userId);
        return result;
    }
}
