using Core.DataAccess;
using Database.Sql.ERP.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Sql.ERP
{
    public interface IERPUnitOfWork : ICadidateUnitOfWork,ICommonUnitOfWork,IInterviewUnitOfWork,IRecruitmentUnitOfWork,ISystemUnitOfWork,IGenericUnitOfWork
    {
    }
}
