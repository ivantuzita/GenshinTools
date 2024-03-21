using GenshinTools.Domain.Interfaces;
using GenshinTools.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace GenshinTools.Persistence.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : class {

    protected readonly GenshinDatabaseContext _context;

    public GenericRepository(GenshinDatabaseContext context)
    {
        _context = context;
    }

    public async Task<List<T>> GetAllAsync() {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id) {
        return await _context.Set<T>().FindAsync(id);
    }

}
