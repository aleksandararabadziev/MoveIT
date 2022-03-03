using Microsoft.EntityFrameworkCore;
using SmallProject.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SmallProject.Data.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DataContext DbContext;

        public Repository(DataContext _DbContext)
        {
            DbContext = _DbContext;
        }

        public void Create(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            DbContext.Entry(entity).State = EntityState.Added;
            DbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
            DbContext.Entry(entity).State = EntityState.Deleted;
            DbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(object id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> Query()
        {
            return DbContext.Set<TEntity>().AsQueryable<TEntity>();
        }

        public void Update(TEntity entity)
        {
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
        }
    }
}
