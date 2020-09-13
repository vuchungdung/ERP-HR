using Core.DataAccess;
using Database.Sql.ERP.Entities.Cadidate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Sql.ERP.UnitOfWork
{
    public interface ICadidateUnitOfWork
    {
        ITableGenericRepository<Cadidate> CadidateRepository { get; }
        ITableGenericRepository<CadidateApplyHistory> CadidateApplyHistoryRepository { get; }

    }
}
