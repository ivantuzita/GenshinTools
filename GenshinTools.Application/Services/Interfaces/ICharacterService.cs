using GenshinTools.Application.DTOs;
using GenshinTools.Domain.Models;

namespace GenshinTools.Application.Services.Interfaces; 
public interface ICharacterService {
    Task<List<Character>> GetAllAsync();
    Task<CharacterDTO> GetByIdAsync(int id);
    Task CreateAsync(CharacterDTO charDTO);
    Task UpdateAsync(CharacterDTO charDTO);
    Task DeleteByIdAsync(int id);
}
