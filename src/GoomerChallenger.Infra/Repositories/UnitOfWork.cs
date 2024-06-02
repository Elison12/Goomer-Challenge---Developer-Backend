using GoomerChallenger.Domain.Interfaces.UnitOfWork;
using GoomerChallenger.Infra.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace GoomerChallenger.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private IDbContextTransaction? _transaction;
        private readonly GoomerContext _GoomerContext;

        public UnitOfWork(GoomerContext goomerContext)
        {
            _GoomerContext = goomerContext;
        }

        public void BeginTransaction()
        {
            _transaction = _GoomerContext.Database.BeginTransaction();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
        }

        public void RollBack()
        {
            _transaction?.Rollback();
        }
    }
}
