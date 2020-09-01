using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Sql
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            if(context == null)
            {
                throw new Exception();
            }
            this._dbSet = context.Set<T>();
        }

        public bool Any(Expression<Func<T, bool>> where = null)
        {
            if(where != null)
            {
                return this._dbSet.Any(where);
            }
            return this._dbSet.Any();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> where = null)
        {
            if (where != null)
            {
                return await this._dbSet.AnyAsync(where).ConfigureAwait(false);
            }

            return await this._dbSet.AnyAsync().ConfigureAwait(false);
        }

        public int Count(Expression<Func<T, bool>> where = null)
        {
            if (where != null)
            {
                return this._dbSet.Count(where);
            }

            return this._dbSet.Count();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> where = null)
        {
            if (where != null)
            {
                return await this._dbSet.CountAsync(where).ConfigureAwait(false);
            }

            return await this._dbSet.CountAsync().ConfigureAwait(false);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> where = null)
        {
            if (where != null)
            {
                IQueryable<T> query = this._dbSet;
                return query.FirstOrDefault(where);
            }

            return this._dbSet.FirstOrDefault();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where = null)
        {
            if (where != null)
            {
                IQueryable<T> query = this._dbSet;
                return await query.FirstOrDefaultAsync(where).ConfigureAwait(false);
            }

            return await this._dbSet.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public IQueryable<T> Query(string[] includes = null)
        {
            var query = this._dbSet.AsNoTracking();
            if (includes != null && includes.Any())
            {
                query = includes.Aggregate(query, (current, inc) => current.Include(inc));
            }

            return query;
        }

        public T SingleOrDefault(Expression<Func<T, bool>> where = null)
        {
            if (where != null)
            {
                IQueryable<T> query = this._dbSet;
                return query.SingleOrDefault(where);
            }

            return this._dbSet.SingleOrDefault();
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where = null)
        {
            if (where != null)
            {
                IQueryable<T> query = this._dbSet;
                return await query.SingleOrDefaultAsync(where).ConfigureAwait(false);
            }

            return await this._dbSet.SingleOrDefaultAsync().ConfigureAwait(false);
        }
    }
}
