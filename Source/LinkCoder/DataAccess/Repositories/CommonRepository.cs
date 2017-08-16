using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories
{
    public class CommonRepository<T> : ICommonRepository<T> where T : class
    {
        protected DbContext Context { get; set; }

        public CommonRepository(DbContext context)
        {
            this.Context = context;
        }

        public virtual void Create(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            Context.SaveChanges();
        }

        public virtual IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public virtual void Dispose()
        {
            Context.Dispose();
        }

        public T GetBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> source = GetAll();
            if (includes.Any())
            {
                foreach (var include in includes)
                    source = (source.Include(include));
            }
            return source.FirstOrDefault(predicate);
        }
    }
}
