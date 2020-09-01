using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface ITableGenericRepository<T> : IGenericRepository<T>
    {
        void AddRange(T[] entity);

        Task AddRangeAsync(T[] entity);

        void Add(T entity);

        Task AddAsync(T entity);

        void Delete(T entity);

        void DeleteRange(T[] entity);

        void Update(T entity);

        void UpdateRange(T[] entity);
    }
}
