using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IGenericRepository<T>
    {
        bool Any(Expression<Func<T, bool>> where = null);

        Task<bool> AnyAsync(Expression<Func<T, bool>> where = null);

        int Count(Expression<Func<T, bool>> where = null);

        Task<int> CountAsync(Expression<Func<T, bool>> where = null);

        T FirstOrDefault(Expression<Func<T, bool>> where = null);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where = null);

        IQueryable<T> Query(string[] includes = null);

        T SingleOrDefault(Expression<Func<T, bool>> where = null);

        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where = null);
    }
}
