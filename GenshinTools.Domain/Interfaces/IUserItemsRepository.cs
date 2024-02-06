namespace GenshinTools.Domain.Interfaces; 
public interface IUserItemsRepository<T> where T : class{
    Task<List<T>> GetItemsByUserId(int userId);
    Task<List<T>> GetTodayItemsByUserId(int userId);
}
