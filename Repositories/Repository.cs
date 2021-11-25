using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbContext DbContext { get; }

        public Repository(DbContext context)
        {
            DbContext = context;
        }

        public void Delete(T entity)
        {
            this.DbContext.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            this.DbContext.Set<T>().RemoveRange(entities);
        }

        public IEnumerable<T> GetAll()
        {
            return DbContext.Set<T>().ToList();
        }

        public T FindById(int id)
        {
            return this.DbContext.Set<T>().Find(id);
        }

        public T FindById(Guid id)
        {
            return this.DbContext.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            this.DbContext.Set<T>().Add(entity);
        }

        public void InsertRange(IEnumerable<T> entities)
        {
            this.DbContext.Set<T>().AddRange(entities);
        }

        public IQueryable<T> QueryAllReadOnly()
        {
            return this.DbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> QueryCondition(Expression<Func<T, bool>> expression)
        {
            return this.DbContext.Set<T>().Where(expression);
        }

        public IQueryable<T> QueryConditionReadOnly(Expression<Func<T, bool>> expression)
        {
            return this.DbContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            this.DbContext.Set<T>().Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            this.DbContext.Set<T>().UpdateRange(entities);
        }

        public T Single(Expression<Func<T, bool>> expression = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            bool disableTracking = true)
        {
            IQueryable<T> query = this.DbContext.Set<T>();
            if(disableTracking){
                query = query.AsNoTracking();
            }

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (orderBy != null)
            {
                return orderBy(query).FirstOrDefault();
            }

            return query.FirstOrDefault();
        }

    }
}
