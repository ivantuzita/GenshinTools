using GenshinTools.Domain.Models;

namespace GenshinTools.Application.Services.Interfaces; 
public interface ICharacterService {
    Task<List<Character>> GetAllAsync();
    Task<Character> GetByIdAsync(int id);
}
