using GoomerChallenger.Domain.Interfaces.BaseRepository;
using GoomerChallenger.Domain.Models;
using GoomerChallenger.Infra.Data.Context;
using GoomerChallenger.Notification.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoomerChallenger.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity, new()
    {
        private readonly GoomerContext _GoomerContext;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(GoomerContext context)
        {
            _GoomerContext = context;
            _dbSet = _GoomerContext.Set<T>();
        }

        public virtual async Task<T> CreateAsync(T obj)
        {
            _GoomerContext.Add(obj);
            await _GoomerContext.SaveChangesAsync();

            return obj;
        }

        public async Task AddAsync(T obj)
            => await _dbSet.AddAsync(obj);

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

        public virtual async Task<T> GetAsync(int id)
        {
            var obj = await _GoomerContext.Set<T>()
                        .AsNoTracking()
                        .Where(x => x.Id.Equals(id))
                        .ToListAsync();


            return obj.FirstOrDefault();
        }

        public virtual async Task<T> Update(T obj)
        {
            _GoomerContext.Entry(obj).State = EntityState.Modified;
            await _GoomerContext.SaveChangesAsync();

            return obj;
        }

        public async Task<Boolean> UpdateAsync(T obj)
        {
            var updated = _GoomerContext.Entry(obj).State = EntityState.Modified;
            await _GoomerContext.SaveChangesAsync();

            return updated != 0;
        }
    }
}
