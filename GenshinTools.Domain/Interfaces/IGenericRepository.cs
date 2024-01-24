namespace GenshinTools.Domain.Interfaces; 
public interface IGenericRepository<T> where T : class {
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteByIdAsync(int id);
}
