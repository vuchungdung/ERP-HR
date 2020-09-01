using Core.DataAccess;
using Database.Sql.ERP.Entities.Cadidate;
using Database.Sql.ERP.Entities.Common;
using Database.Sql.ERP.Entities.Interview;
using Database.Sql.ERP.Entities.Recruitment;
using Database.Sql.ERP.Entities.System;
using Database.Sql.ERP.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Database.Sql.ERP
{
    public class ERPUnitOfWork : IERPUnitOfWork, IDisposable
    {
        public ITableGenericRepository<Cadidate> CadidateRepository => throw new NotImplementedException();

        public ITableGenericRepository<CadidateApplyHistory> CadidateApplyHistoryRepository => throw new NotImplementedException();

        public ITableGenericRepository<JobCategory> JobCategoryRepository => throw new NotImplementedException();

        public ITableGenericRepository<FileCV> FileCVRepository => throw new NotImplementedException();

        public ITableGenericRepository<Level> LevelRepository => throw new NotImplementedException();

        public ITableGenericRepository<Skill> SkillRepository => throw new NotImplementedException();

        public ITableGenericRepository<InterviewDate> InterviewRepository => throw new NotImplementedException();

        public ITableGenericRepository<InterviewProcess> InterviewProcessRepository => throw new NotImplementedException();

        public ITableGenericRepository<InterviewResult> InterviewResultRepository => throw new NotImplementedException();

        public ITableGenericRepository<Process> ProcessRepository => throw new NotImplementedException();

        public ITableGenericRepository<JobDescription> JobDescriptionRepository => throw new NotImplementedException();

        public ITableGenericRepository<RecruitmentPlan> RecruitmentPlanRepository => throw new NotImplementedException();

        public ITableGenericRepository<User> UserRepository => throw new NotImplementedException();

        public ITableGenericRepository<Role> RoleRepository => throw new NotImplementedException();

        public ITableGenericRepository<Command> CommandRepository => throw new NotImplementedException();

        public ITableGenericRepository<CommandInFunction> CommandInFunctionRepository => throw new NotImplementedException();

        public ITableGenericRepository<Function> FunctionRepository => throw new NotImplementedException();

        public ITableGenericRepository<Permission> PermissionRepository => throw new NotImplementedException();

        ITableGenericRepository<UserRole> ISystemUnitOfWork.CadidateRepository => throw new NotImplementedException();

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public Task BeginTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public void CommitTransaction()
        {
            throw new NotImplementedException();
        }

        public Task CommitTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void RollbackTransaction()
        {
            throw new NotImplementedException();
        }

        public Task RollbackTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
