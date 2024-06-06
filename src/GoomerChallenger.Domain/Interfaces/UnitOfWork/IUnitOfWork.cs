using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoomerChallenger.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        Task Commit(CancellationToken cancellationToken);
        void RollBack();
    }
}
