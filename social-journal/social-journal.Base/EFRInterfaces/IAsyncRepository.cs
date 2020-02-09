using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace social_journal.Base
{
    public interface IAsyncRepository<TEntity>
        where TEntity : IEntity
    {
        Task Add(TEntity entity);
        Task Add(IEnumerable<TEntity> entities);
        Task Update(TEntity entity);
        Task Update(IEnumerable<TEntity> entities);
        Task<TEntity> GetByID(int id, bool asNoTracking = false);
        Task<int> GetCount(Expression<Func<TEntity, bool>> predicate = null);
        Task<IEnumerable<TEntity>> GetAll(bool asNoTracking = false);
        Task<IEnumerable<TEntity>> GetWithConditions(Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            bool asNoTracking = false);
        Task<IEnumerable<TEntity>> GetPaged(Expression<Func<TEntity, bool>> predicate,
            int page,
            int count,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            bool asNoTracking = false);
        Task Delete(TEntity entity);
        Task Delete(Expression<Func<TEntity, bool>> predicate);
        Task Delete(int id);
    }
}
