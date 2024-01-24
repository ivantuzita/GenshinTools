using GenshinTools.Application.DTOs;
using GenshinTools.Domain.Models;

namespace GenshinTools.Application.Services.Interfaces; 
public interface IUserService {
    Task<List<User>> GetAllAsync();
    Task<UserDTO> GetByIdAsync(int id);
    Task CreateAsync(UserDTO userDTO);
    Task UpdateAsync(UserDTO userDTO);
    Task DeleteByIdAsync(int id);
}
