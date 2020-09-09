using Core.DataAccess;
using Database.Sql.ERP.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Sql.ERP.UnitOfWork
{
    public interface ICommonUnitOfWork
    {
        ITableGenericRepository<JobCategory> JobCategoryRepository { get; }
        ITableGenericRepository<File> FileCVRepository { get; }
        ITableGenericRepository<Skill> SkillRepository { get; }

    }
}
