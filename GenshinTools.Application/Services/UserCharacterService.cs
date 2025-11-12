using GenshinTools.Application.DTOs;
using GenshinTools.Application.Exceptions;
using GenshinTools.Application.Services.Interfaces;
using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models;
using GenshinTools.Domain.Models.Identity;

namespace GenshinTools.Application.Services;
public class UserCharacterService : IUserCharacterService {

    private readonly IUserCharacterRepository _repository;
    private readonly IGenericRepository<Character> _charRepo;
    private readonly IGenericRepository<User> _userRepo;
    public UserCharacterService(IUserCharacterRepository repository, IGenericRepository<Character> charRepo, IGenericRepository<User> userRepo) {
        _repository = repository;
        _charRepo = charRepo;
        _userRepo = userRepo;
    }

    public async Task AssociateCharacterToUser(UserCharacterDTO model) {
        var userExists = await _userRepo.GetByIdAsync(int.Parse(model.UserId));

        if (userExists == null)
            throw new NotFoundException($"User has not been found.");

        var charExists = _charRepo.GetByIdAsync(model.CharacterId);

        if (charExists == null)
            throw new NotFoundException($"Character with id {model.CharacterId} has not been found.");

        var alreadyAssociated = await _repository.AlreadyAssociated(model.UserId, model.CharacterId);

        if (alreadyAssociated)
            throw new BadRequestException($"Character with id {model.CharacterId} is already associated with user id {model.UserId}.");

        await _repository.AssociateCharacterToUser(model.UserId, model.CharacterId);
    }

    public async Task DisassociateCharacterToUser(UserCharacterDTO model) {
        var userExists = await _userRepo.GetByIdAsync(int.Parse(model.UserId));

        if (userExists == null)
            throw new NotFoundException($"User has not been found.");

        var charExists = _charRepo.GetByIdAsync(model.CharacterId);

        if (charExists == null)
            throw new NotFoundException($"Character with id {model.CharacterId} has not been found.");

        var alreadyAssociated = await _repository.AlreadyAssociated(model.UserId, model.CharacterId);

        if (!alreadyAssociated)
            throw new BadRequestException($"Character with id {model.CharacterId} is not associated with user id {model.UserId}.");

        await _repository.DisassociateCharacterToUser(model.UserId, model.CharacterId);
    }

    public async Task<List<Character>> GetUserCharacters(string userId) {
        return await _repository.GetUserCharacters(userId);
    }

    public async Task<List<Character>> GetUserCharactersFiltered(string userId) {
        return await _repository.GetUserCharactersFiltered(userId);
    }
}
