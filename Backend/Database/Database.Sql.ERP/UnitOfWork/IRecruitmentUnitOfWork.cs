using Core.DataAccess;
using Database.Sql.ERP.Entities.Recruitment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Sql.ERP.UnitOfWork
{
    public interface IRecruitmentUnitOfWork
    {
        ITableGenericRepository<JobDescription> JobDescriptionRepository { get; }
    }
}
