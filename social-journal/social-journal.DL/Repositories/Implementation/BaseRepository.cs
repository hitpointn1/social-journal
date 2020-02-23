using Microsoft.EntityFrameworkCore;
using social_journal.Base;
using social_journal.Base.Enums;
using social_journal.Base.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace social_journal.DL.Repositories
{
    public abstract class BaseRepository<TEntity, TDBContext> : IAsyncRepository<TEntity>
        where TEntity : class, IEntity
        where TDBContext : DbContext
    {
        protected readonly TDBContext DbContext;
        protected readonly ILog Logger;

        public BaseRepository(TDBContext context, ILog logger)
        {
            DbContext = context;
            Logger = logger;
        }

        public async Task Add(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            await DbContext.SaveChangesAsync();
            LogAction(DBAction.Add, entity);
        }

        public async Task Add(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().AddRange(entities);
            await DbContext.SaveChangesAsync();
            LogAction(DBAction.Add, entities);
        }

        public async Task Remove(TEntity entity)
        {
            if (entity == null || entity.ID == 0)
            {
                LogAction(DBAction.Delete, null);
                return;
            }
                
            DbContext.Set<TEntity>().Remove(entity);
            await DbContext.SaveChangesAsync();
            LogAction(DBAction.Delete, entity);
        }

        public async Task Remove(IEnumerable<TEntity> entities)
        {
            var dbSet = DbContext.Set<TEntity>();
            dbSet.RemoveRange(entities);

            await DbContext.SaveChangesAsync();
            LogAction(DBAction.Delete, entities);
        }

        public async Task Remove(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = await GetWithConditions(predicate);
            await Remove(entities);
        }

        public async Task Remove(int id)
        {
            TEntity entity = await DbContext.Set<TEntity>().FindAsync(id);
            await Remove(entity);
        }

        public Task<IEnumerable<TEntity>> GetAll(bool asNoTracking = false)
        {
            return GetWithConditions(null, asNoTracking: asNoTracking);
        }

        public async Task<TEntity> GetByID(int id, bool asNoTracking = false)
        {
            var dbSet = DbContext.Set<TEntity>();
            TEntity entity = asNoTracking
                ? await dbSet.FindAsync(id)
                : await dbSet.AsNoTracking().FirstOrDefaultAsync(item => item.ID == id);

            LogAction(DBAction.Get, entity);
            return entity;
        }

        public async Task<int> GetCount(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null
                ? 0
                : await DbContext.Set<TEntity>().CountAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetPaged(Expression<Func<TEntity, bool>> predicate,
            int page,
            int count,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            bool asNoTracking = false)
        {
            IQueryable<TEntity> query;
            if (page != 0 && count != 0)
                query = DbContext.Set<TEntity>()
                    .Where(predicate)
                    .Skip((page - 1) * count)
                    .Take(count);
            else
                query = DbContext.Set<TEntity>()
                    .Where(predicate);
            if (orderBy != null)
                query = orderBy(query);
            TEntity[] entities = asNoTracking
                ? await query.AsNoTracking().ToArrayAsync()
                : await query.ToArrayAsync();
            LogAction(DBAction.Get, entities);
            return entities;
        }

        public Task<IEnumerable<TEntity>> GetWithConditions(Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            bool asNoTracking = false)
        {
            return GetPaged(predicate, 0, 0, orderBy, asNoTracking);
        }

        public async Task Update(TEntity entity)
        {
            DbContext.Set<TEntity>().Update(entity);
            await DbContext.SaveChangesAsync();
            LogAction(DBAction.Update, entity);
        }

        public async Task Update(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().UpdateRange(entities);
            await DbContext.SaveChangesAsync();
            LogAction(DBAction.Update, entities);
        }

        private void LogAction(DBAction action, IEnumerable<TEntity> entities)
        {
            LogAction(action, entities.ToArray());
        }

        private void LogAction(DBAction action, params TEntity[] entities)
        {
            if (entities.Length == 0 || entities == null)
            {
                Logger.Warning("No items to perform operation");
                return;
            }
            string entityIDs = entities.Select(item => item.ID + ", ").ToString();
            string logMessage = string.Format("Successfully {0} new items.\n IDs: {1}", action.GetDescription(), entityIDs.Remove(entityIDs.Length - 2));
            Logger.Info(logMessage);
        }
    }
}
