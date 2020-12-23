using Core.DataAccess;
using Database.Sql.ERP.Entities.Candidate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Sql.ERP.UnitOfWork
{
    public interface ICandidateUnitOfWork
    {
        ITableGenericRepository<Candidate> CandidateRepository { get; }
        ITableGenericRepository<WorkHistory> WorkHistoryRepository { get; }

        ITableGenericRepository<Education> EducationRepository { get; }

        ITableGenericRepository<Award> AwardRepository { get; }


    }
}
