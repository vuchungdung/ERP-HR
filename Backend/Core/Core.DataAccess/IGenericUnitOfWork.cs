using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IGenericUnitOfWork
    {
        void BeginTransaction();

        Task BeginTransactionAsync();

        void CommitTransaction();

        Task CommitTransactionAsync();

        void RollbackTransaction();

        Task RollbackTransactionAsync();

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
