using GoomerChallenger.Infra.Data.Context;
using GoomerChallenger.Infra.Interfaces;
using GoomerChallenger.Notification.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoomerChallenger.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity, new()
    {
        private readonly GoomerContext _GoomerContext;


        public BaseRepository(GoomerContext context)
        {
            _GoomerContext = context;
        }

        public virtual async Task<T> CreateAsync(T obj)
        {
            _GoomerContext.Add(obj);
            await _GoomerContext.SaveChangesAsync();

            return obj;
        }

        public virtual async Task DeleteAsync(T obj)
        {
            _GoomerContext.Remove(obj);
            await _GoomerContext.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _GoomerContext.Set<T>()
                                       .AsNoTracking()
                                       .ToListAsync();
        }

        public Task GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> Update(T obj)
        {
            _GoomerContext.Entry(obj).State = EntityState.Modified;
            await _GoomerContext.SaveChangesAsync();

            return obj;
        }
    }
}
