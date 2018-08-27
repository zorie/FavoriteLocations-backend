using FavLocs.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavLocs.Data.Repositories
{
    public class EFRepository<T> : IEFRepository<T>
        where T : class
    {
        private readonly IFavLocsDbContext dbContext;
        private readonly IDbSet<T> dbSet;

        public EFRepository(IFavLocsDbContext dbContext)
        {
            if(dbContext == null)
            {
                throw new ArgumentNullException("Database context cannot be null");
            }

            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<T>();
        }

        private DbEntityEntry GetAttachedEntry(T entity)
        {
            var entry = this.dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }

            return entry;
        }

        public IQueryable<T> All
        {
            get { return this.dbSet; }            
        }

        public void Add(T entity)
        {
            var entry = this.GetAttachedEntry(entity);
            entry.State = EntityState.Added;
        }

        public void Delete(T entity)
        {
            var entry = this.GetAttachedEntry(entity);
            entry.State = EntityState.Deleted;
        }

        public T GetById(object id)
        {            
            return this.dbSet.Find(id);
        }

        public void Update(T entity)
        {
            var entry = this.GetAttachedEntry(entity);
            entry.State = EntityState.Modified;
        }
    }
}
