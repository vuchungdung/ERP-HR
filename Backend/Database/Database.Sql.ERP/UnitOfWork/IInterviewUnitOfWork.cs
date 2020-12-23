using Core.DataAccess;
using Database.Sql.ERP.Entities.Common;
using Database.Sql.ERP.Entities.Interview;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Sql.ERP.UnitOfWork
{
    public interface IInterviewUnitOfWork
    {
        ITableGenericRepository<InterviewDate> InterviewDateRepository { get; }
        ITableGenericRepository<InterviewResult> InterviewResultRepository { get; }
        ITableGenericRepository<Process> ProcessRepository { get; }
        ITableGenericRepository<InterviewProcess> InterviewProcessRepository { get; }

    }
}
