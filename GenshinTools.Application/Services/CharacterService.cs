using GenshinTools.Application.Exceptions;
using GenshinTools.Application.Services.Interfaces;
using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models;

namespace GenshinTools.Application.Services;
public class CharacterService : ICharacterService {

    private readonly IGenericRepository<Character> _repository;

    public CharacterService(IGenericRepository<Character> repository)
    {
        _repository = repository;
    }

    public async Task<List<Character>> GetAllAsync() {
        var result = await _repository.GetAllAsync();

        if (result == null) {
            throw new Exception("No characters found.");
        }

        return result;
    }

    public async Task<Character> GetByIdAsync(int id) {
        var result = await _repository.GetByIdAsync(id);
        return result;
    }
}
