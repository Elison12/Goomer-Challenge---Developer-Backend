using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoomerChallenger.Notification.Entities;

namespace GoomerChallenger.Domain.Interfaces.BaseRepository
{
    public interface IBaseRepository<T>
    {
        Task AddAsync(T obj);
        Task<Boolean> UpdateAsync( T obj);
    }
}
