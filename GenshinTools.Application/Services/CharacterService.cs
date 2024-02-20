using AutoMapper;
using GenshinTools.Application.DTOs;
using GenshinTools.Application.Exceptions;
using GenshinTools.Application.Services.Interfaces;
using GenshinTools.Domain.Interfaces;
using GenshinTools.Domain.Models;

namespace GenshinTools.Application.Services;
public class CharacterService : ICharacterService {

    private readonly IGenericRepository<Character> _repository;
    private readonly IMapper _mapper;

    public CharacterService(IGenericRepository<Character> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task CreateAsync(CharacterDTO charDTO) {
        var newChar = _mapper.Map<Character>(charDTO);
        await _repository.CreateAsync(newChar);
    }

    public async Task DeleteByIdAsync(int id) {
        await _repository.DeleteByIdAsync(id);
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

    public async Task UpdateAsync(CharacterDTO charDTO) {
        var existingChar = await _repository.GetByIdAsync(charDTO.Id);

        if (existingChar == null) {
            throw new NotFoundException($"Character with id {charDTO.Id} has not been found.");
        }

        var newChar = _mapper.Map<Character>(charDTO);
        await _repository.UpdateAsync(newChar);
    }
}
