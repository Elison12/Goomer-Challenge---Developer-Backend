namespace GoomerChallenger.Domain.Interfaces.BaseRepository
{
    public interface IBaseRepository<T>
    {
        Task AddAsync(T obj);
        Task<Boolean> UpdateAsync(T obj);
        Task<T> GetAsync(int id);
        Task DeleteAsync(T obj);
    }
}
