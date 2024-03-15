using AutoMapper;
using GenshinTools.Application.Exceptions;
using GenshinTools.Application.Services.Interfaces;
using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models;
using GenshinTools.Domain.Models.Identity;

namespace GenshinTools.Application.Services;
public class UserCharacterService : IUserCharacterService {

    private readonly IUserCharacterRepository _repository;
    private readonly IGenericRepository<Character> _charRepo;
    private readonly IGenericRepository<AuthRequest> _userRepo;

    public UserCharacterService(IUserCharacterRepository repository,
        IGenericRepository<Character> charRepo,
        IGenericRepository<AuthRequest> userRepo)
    {
        _repository = repository;
        _userRepo = userRepo;
        _charRepo = charRepo;
    }

    public async Task AssociateCharacterToUser(int userId, int charId)
    {
        var userExists = _userRepo.GetByIdAsync(userId);

        if (userExists == null)
        {
            throw new NotFoundException($"User with id {userId} has not been found.");
        }

        var charExists = _charRepo.GetByIdAsync(charId);

        if (charExists == null)
        {
            throw new NotFoundException($"Character with id {charId} has not been found.");
        }

        var alreadyAssociated = await _repository.AlreadyAssociated(userId, charId);

        if (alreadyAssociated)
        {
            throw new BadRequestException($"Character with id {charId} is already associated with user id {userId}.");
        }

        await _repository.AssociateCharacterToUser(userId, charId);
    }

    public async Task DisassociateCharacterToUser(int userId, int charId)
    {
        var userExists = _userRepo.GetByIdAsync(userId);

        if (userExists == null)
        {
            throw new NotFoundException($"User with id {userId} has not been found.");
        }

        var charExists = _charRepo.GetByIdAsync(charId);

        if (charExists == null)
        {
            throw new NotFoundException($"Character with id {charId} has not been found.");
        }

        var alreadyAssociated = await _repository.AlreadyAssociated(userId, charId);

        if (!alreadyAssociated)
        {
            throw new BadRequestException($"Character with id {charId} is not associated with user id {userId}.");
        }

        await _repository.DisassociateCharacterToUser(userId, charId);
    }

    public async Task<List<Character>> GetUserCharacters(int userId)
    {
        var userExists = _userRepo.GetByIdAsync(userId);

        if (userExists == null)
        {
            throw new NotFoundException($"User with id {userId} has not been found.");
        }

        return await _repository.GetUserCharacters(userId);
    }

    public async Task<List<Character>> GetUserCharactersFiltered(int userId)
    {
        var userExists = _userRepo.GetByIdAsync(userId);

        if (userExists == null)
        {
            throw new NotFoundException($"User with id {userId} has not been found.");
        }

        return await _repository.GetUserCharactersFiltered(userId);
    }
}
