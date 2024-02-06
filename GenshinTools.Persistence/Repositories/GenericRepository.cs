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

    public async Task CreateAsync(T entity) {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id) {
        var obj = _context.Set<T>().Find(id);

        if (obj != null) {
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<T>> GetAllAsync() {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id) {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task UpdateAsync(T entity) {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }
}
