using System.Collections.Generic;
using System.Linq;

namespace SmallProject.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(object id);

        IEnumerable<TEntity> GetAll();

        IQueryable<TEntity> Query();

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
