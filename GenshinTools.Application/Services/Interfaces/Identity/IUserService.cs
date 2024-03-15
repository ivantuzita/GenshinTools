using GenshinTools.Domain.Models.Identity;

namespace GenshinTools.Application.Services.Interfaces.Identity
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User> GetUser(string id);
    }
}
