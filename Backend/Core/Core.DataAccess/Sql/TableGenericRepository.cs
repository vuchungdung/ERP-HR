using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Sql
{
    public class TableGenericRepository<T> : GenericRepository<T>, ITableGenericRepository<T> where T : class
    {
        public TableGenericRepository(DbContext context) : base(context)
        {

        }

        public void Add(T entity)
        {
            this._dbSet.Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await this._dbSet.AddAsync(entity).ConfigureAwait(false);
        }

        public void AddRange(T[] entity)
        {
            this._dbSet.AddRange(entity);
        }

        public async Task AddRangeAsync(T[] entity)
        {
            await this._dbSet.AddRangeAsync(entity).ConfigureAwait(false);
        }

        public void Delete(T entity)
        {
            this._dbSet.Remove(entity);
        }

        public void DeleteRange(T[] entity)
        {
            this._dbSet.RemoveRange(entity);
        }

        public void Update(T entity)
        {
            this._dbSet.Update(entity);
        }

        public void UpdateRange(T[] entity)
        {
            this._dbSet.UpdateRange(entity);
        }
    }
}
