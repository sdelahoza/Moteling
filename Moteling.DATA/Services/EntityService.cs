using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moteling.DATA.Infrastructure;
using Moteling.DATA.Services.Interfaces;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Moteling.DATA.Services
{
    public class EntityService<TEntity> : IEntityService<TEntity> where TEntity : class
    {
        private IContextBase baseContext;
        private DbSet<TEntity> entityDbSet;

        public DbSet<TEntity> EntityDbSet
        {
            get { return entityDbSet; }
        }

        public EntityService(IContextBase context)
        {
            baseContext = context;
            entityDbSet = baseContext.Set<TEntity>();
        }

        public int GetTotalRecords(Expression<Func<TEntity, bool>> predicate)
        {
            return entityDbSet.AsNoTracking().Where(predicate).Count();
        }

        public void Add(TEntity entity)
        {
            EntityEntry dbEntityEntry = baseContext.Entry(entity);
            baseContext.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            EntityEntry dbEntityEntry = baseContext.Entry(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public void Edit(TEntity entity)
        {
            EntityEntry dbEntityEntry = baseContext.Entry(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return entityDbSet.AsNoTracking().AsEnumerable();
        }

        public IEnumerable<TEntity> FindBy<K>(
            Expression<Func<TEntity, bool>> predicate,
            int? page = null,
            int? pageSize = null,
            Expression<Func<TEntity, K>> order = null,
            bool? isOrderByDescendent = null)
        {
            IQueryable<TEntity> query = entityDbSet.AsNoTracking().Where(predicate);

            query = EntityOrderBy(query, order, isOrderByDescendent);

            return EntityPaginated(query, page, pageSize);
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = entityDbSet.AsNoTracking().Where(predicate);

            return query.AsEnumerable();
        }

        public IEnumerable<TEntity> FindByAndInclude<K>(
            Expression<Func<TEntity, bool>> predicate,
            int? page = null,
            int? pageSize = null,
            Expression<Func<TEntity, K>> order = null,
            bool? isOrderByDescendent = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = entityDbSet.AsNoTracking().Where(predicate);
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            query = EntityOrderBy(query, order, isOrderByDescendent);

            return EntityPaginated(query, page, pageSize);
        }

        public IEnumerable<TEntity> FindByAndInclude(
            Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = entityDbSet.AsNoTracking().Where(predicate);
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.AsEnumerable();
        }

        public IQueryable<TEntity> EntityOrderBy<K>(
             IQueryable<TEntity> query,
             Expression<Func<TEntity, K>> order = null,
             bool? isOrderByDescendent = null)
        {
            if (order != null)
            {
                query = ((bool)isOrderByDescendent)
                    ? query.OrderByDescending(order)
                    : query.OrderBy(order);
            }

            return query;
        }

        public IEnumerable<TEntity> EntityPaginated(
             IQueryable<TEntity> query,
             int? page = null,
             int? pageSize = null)
        {
            if (page != null && pageSize != null)
            {
                return query.ToPagedList(
                    (int)page,
                    (int)pageSize);
            }
            else
            {
                return query.AsEnumerable();
            }
        }
    }
}
