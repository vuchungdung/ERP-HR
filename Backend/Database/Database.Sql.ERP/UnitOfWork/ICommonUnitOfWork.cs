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
        ITableGenericRepository<FileCV> FileCVRepository { get; }
        ITableGenericRepository<Level> LevelRepository { get; }
        ITableGenericRepository<Skill> SkillRepository { get; }

    }
}
