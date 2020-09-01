using Core.DataAccess;
using Database.Sql.ERP.Entities.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Sql.ERP.UnitOfWork
{
    public interface ISystemUnitOfWork
    {
        ITableGenericRepository<User> UserRepository { get; }
        ITableGenericRepository<Role> RoleRepository { get; }
        ITableGenericRepository<UserRole> CadidateRepository { get; }
        ITableGenericRepository<Command> CommandRepository { get; }
        ITableGenericRepository<CommandInFunction> CommandInFunctionRepository { get; }
        ITableGenericRepository<Function> FunctionRepository { get; }
        ITableGenericRepository<Permission> PermissionRepository { get; }
    }
}
