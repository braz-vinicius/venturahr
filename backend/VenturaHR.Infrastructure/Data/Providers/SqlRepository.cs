using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VenturaHR.Domain.Interfaces;
using VenturaHR.Infrastructure.Data.Extensions;

namespace VenturaHR.Infrastructure.Data.Providers
{
    public abstract class SqlRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        protected DbContext Context { get; }

        protected readonly DbSet<TEntity> DbSet;

        protected SqlRepository(DbContext dbContext)
        {
            Context = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        public void Add(TEntity item)
        {
            DbSet.Add(item);

            Context.SaveChanges();
        }

        public void Delete(TEntity item)
        {
            DbSet.Remove(item);

            Context.SaveChanges();
        }

        public void DeleteById<T>(T id)
        {
            var entity = DbSet.Find(id);

            DbSet.Remove(entity);

            Context.SaveChanges();
        }

        public void Update(TEntity item)
        {
            DbSet.Update(item);

            Context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter, params string[] includeEntities)
        {
            return DbSet.Where(filter).IncludeMultiple(includeEntities).SingleOrDefault();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return DbSet.Where(filter).SingleOrDefault();
        }


        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.AsEnumerable();
        }

        public IEnumerable<TEntity> FindWhere(Expression<Func<TEntity, bool>> filter, params string[] includeEntities)
        {
            return DbSet.Where(filter).IncludeMultiple(includeEntities);
        }
    }

}
