using Core.DataAccess;
using Core.DataAccess.Sql;
using Database.Sql.ERP.Entities.Candidate;
using Database.Sql.ERP.Entities.Common;
using Database.Sql.ERP.Entities.Interview;
using Database.Sql.ERP.Entities.Recruitment;
using Database.Sql.ERP.Entities.System;
using Database.Sql.ERP.UnitOfWork;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Database.Sql.ERP
{
    public class ERPUnitOfWork : IERPUnitOfWork, IDisposable
    {
        private readonly ERPContext _context;
        private IDbContextTransaction _transaction;


        private ITableGenericRepository<Candidate> _cadidateRepository;
        public ITableGenericRepository<Candidate> CandidateRepository
        {
            get
            {
                return _cadidateRepository = _cadidateRepository ?? new TableGenericRepository<Candidate>(_context);
            }
        }
        private ITableGenericRepository<WorkHistory> _cadidateApplyHistoryRepository;
        public ITableGenericRepository<WorkHistory> CandidateApplyHistoryRepository
        {
            get
            {
                return _cadidateApplyHistoryRepository = _cadidateApplyHistoryRepository ?? new TableGenericRepository<WorkHistory>(_context);
            }
        }

        private ITableGenericRepository<JobCategory> _jobCategoryRepository;
        public ITableGenericRepository<JobCategory> JobCategoryRepository
        {
            get
            {
                return _jobCategoryRepository = _jobCategoryRepository ?? new TableGenericRepository<JobCategory>(_context);
            }
        }

        private ITableGenericRepository<File> _fileCVRepository;
        public ITableGenericRepository<File> FileCVRepository
        {
            get
            {
                return _fileCVRepository = _fileCVRepository ?? new TableGenericRepository<File>(_context);
            }
        }

        private ITableGenericRepository<Provider> _providerRepository;
        public ITableGenericRepository<Provider> ProviderRepository
        {
            get
            {
                return _providerRepository = _providerRepository ?? new TableGenericRepository<Provider>(_context);
            }
        }

        private ITableGenericRepository<Skill> _skillRepository;
        public ITableGenericRepository<Skill> SkillRepository
        {
            get
            {
                return _skillRepository = _skillRepository ?? new TableGenericRepository<Skill>(_context);
            }
        }

        private ITableGenericRepository<InterviewDate> _interviewDateRepository;
        public ITableGenericRepository<InterviewDate> InterviewDateRepository
        {
            get
            {
                return _interviewDateRepository = _interviewDateRepository ?? new TableGenericRepository<InterviewDate>(_context);
            }
        }

        
        private ITableGenericRepository<InterviewResult> _interviewResultRepository;
        public ITableGenericRepository<InterviewResult> InterviewResultRepository 
        {
            get
            {
                return _interviewResultRepository = _interviewResultRepository ?? new TableGenericRepository<InterviewResult>(_context);
            }
        }

        private ITableGenericRepository<Process> _processRepository;
        public ITableGenericRepository<Process> ProcessRepository 
        {
            get
            {
                return _processRepository = _processRepository ?? new TableGenericRepository<Process>(_context);
            }
        }

        private ITableGenericRepository<JobDescription> _jobDescriptionRepository;
        public ITableGenericRepository<JobDescription> JobDescriptionRepository 
        {
            get
            {
                return _jobDescriptionRepository = _jobDescriptionRepository ?? new TableGenericRepository<JobDescription>(_context);
            }
        }

        private ITableGenericRepository<User> _userRepository;
        public ITableGenericRepository<User> UserRepository 
        {
            get
            {
                return _userRepository = _userRepository ?? new TableGenericRepository<User>(_context);
            }
        }
        private ITableGenericRepository<Role> _roleRepository;
        public ITableGenericRepository<Role> RoleRepository 
        {
            get
            {
                return _roleRepository = _roleRepository ?? new TableGenericRepository<Role>(_context);
            }
        }

        private ITableGenericRepository<Command> _commandRepository;
        public ITableGenericRepository<Command> CommandRepository 
        {
            get
            {
                return _commandRepository = _commandRepository ?? new TableGenericRepository<Command>(_context);
            }
        }

        private ITableGenericRepository<CommandInFunction> _commandInFunctionRepository;
        public ITableGenericRepository<CommandInFunction> CommandInFunctionRepository 
        {
            get
            {
                return _commandInFunctionRepository = _commandInFunctionRepository ?? new TableGenericRepository<CommandInFunction>(_context);
            }
        }

        private ITableGenericRepository<Function> _functionRepository;
        public ITableGenericRepository<Function> FunctionRepository 
        {
            get
            {
                return _functionRepository = _functionRepository ?? new TableGenericRepository<Function>(_context);
            }
        }

        private ITableGenericRepository<Permission> _permissionRepository;
        public ITableGenericRepository<Permission> PermissionRepository 
        {
            get
            {
                return _permissionRepository = _permissionRepository ?? new TableGenericRepository<Permission>(_context);
            }
        }

        private ITableGenericRepository<UserRole> _userRoleRepository;
        public ITableGenericRepository<UserRole> UserRoleRepository 
        {
            get
            {
                return _userRoleRepository = _userRoleRepository ?? new TableGenericRepository<UserRole>(_context);
            }
        }

        private ITableGenericRepository<Tag> _tagRepository;
        public ITableGenericRepository<Tag> TagRepository
        {
            get
            {
                return _tagRepository = _tagRepository ?? new TableGenericRepository<Tag>(_context);
            }
        }

        public ERPUnitOfWork(ERPContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync().ConfigureAwait(true);
        }

        public void CommitTransaction()
        {
            _transaction?.Commit();
        }

        public async Task CommitTransactionAsync()
        {
            await (_transaction?.CommitAsync()).ConfigureAwait(true);
        }

        public void RollbackTransaction()
        {
            _transaction?.Rollback();
        }

        public async Task RollbackTransactionAsync()
        {
            await (_transaction?.RollbackAsync()).ConfigureAwait(true);
        }


        public void Dispose()
        {
            if (_context != null)
            {
                if (_transaction != null)
                {
                    _transaction.Dispose();
                }

                _context.Dispose();
                GC.SuppressFinalize(this);
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(true);
        }

    }
}
