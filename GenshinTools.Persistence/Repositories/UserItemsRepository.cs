using GenshinTools.Domain.Interfaces;
using GenshinTools.Persistence.DatabaseContext;

namespace GenshinTools.Persistence.Repositories; 
public class UserItemsRepository<T> : IUserItemsRepository<T> where T : class {

    protected readonly GenshinDatabaseContext _context;

    public UserItemsRepository(GenshinDatabaseContext context) {
        _context = context;
    }

    public Task<List<T>> GetItemsByUserId(int userId) {
        throw new NotImplementedException();
    }

    public Task<List<T>> GetTodayItemsByUserId(int userId) {
        throw new NotImplementedException();
    }

    private int dayOfWeek() {
        return ((int)DateTime.Now.DayOfWeek + 6) % 7;
    }
}
