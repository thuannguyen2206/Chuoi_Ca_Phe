using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repositories
{
    public interface IRepository<T> where T : class
    {
        T FindById(int id);

        T FindById(Guid id);

        IEnumerable<T> GetAll();

        T Single(Expression<Func<T, bool>> expression = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            bool disableTracking = true);

        void Insert(T entity);

        void InsertRange(IEnumerable<T> entities);

        void Update(T entity);

        void UpdateRange(IEnumerable<T> entities);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entities);

        IQueryable<T> QueryAllReadOnly();

        IQueryable<T> QueryCondition(Expression<Func<T, bool>> expression);

        IQueryable<T> QueryConditionReadOnly(Expression<Func<T, bool>> expression);
    }
}
