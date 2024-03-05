using GenshinTools.BlazorUI.Models;
using GenshinTools.BlazorUI.Services.Base;

namespace GenshinTools.BlazorUI.Interfaces;

public interface IUserService {
    Task<List<UserVM>> GetAllUsersAsync();
    Task<UserVM> GetUserByIdAsync(int id);
    Task<Response<Guid>> CreateUserAsync(UserVM user);
    Task<Response<Guid>> UpdateUserAsync(int id, UserVM user);
    Task<Response<Guid>> DeleteUserByIdAsync(int id);

}
