
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Repositories
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IUnitOfWork 
        where TContext : DbContext
    {
        public TContext Context { get; }

        public UnitOfWork(TContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Dispose()
        {
            this.Context?.Dispose();
            GC.SuppressFinalize(this);
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(this.Context);
        }

        public int SaveChanges()
        {
            var entries = this.Context.ChangeTracker.Entries()
                .Where(x => (x.State == EntityState.Added) || (x.State == EntityState.Deleted) || (x.State == EntityState.Modified));

            return this.Context.SaveChanges();
        }
    }
}
