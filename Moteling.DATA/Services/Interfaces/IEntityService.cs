using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Moteling.DATA.Services.Interfaces
{
    public interface IEntityService<TEntity> where TEntity : class
    {
        DbSet<TEntity> EntityDbSet { get; }

        /// <summary>
        /// Get total records of a query
        /// </summary>-
        /// <param name="predicate">Query</param>
        /// <returns></returns>
        int GetTotalRecords(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// Add a new object
        /// </summary>
        /// <param name="entity">Object</param>
        void Add(TEntity entity);

        /// <summary>
        /// Delete an especific object
        /// </summary>
        /// <param name="entity">Object to delete</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Edit an existing object
        /// </summary>
        /// <param name="entity">Object updated</param>
        void Edit(TEntity entity);

        /// <summary>
        /// Get all objects
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Get a query result paginated
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <param name="predicate">Query</param>
        /// <param name="page">Page to return</param>
        /// <param name="pageSize">Number of object per page</param>
        /// <param name="order">Order By</param>
        /// <param name="isOrderByDescendent"></param>
        /// <returns></returns>
        IEnumerable<TEntity> FindBy<K>(
            Expression<Func<TEntity, bool>> predicate,
            int? page = null,
            int? pageSize = null,
            Expression<Func<TEntity, K>> order = null,
            bool? isOrderByDescendent = null);

        /// <summary>
        /// Get a query result
        /// </summary>
        /// <param name="predicate">Query</param>
        /// <returns></returns>
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Get a query result paginated with relations
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <param name="predicate">Query</param>
        /// <param name="page">Page to return</param>
        /// <param name="pageSize">Number of object per page</param>
        /// <param name="order">Order By</param>
        /// <param name="isOrderByDescendent"></param>
        /// <param name="includeProperties">Relations to include</param>
        /// <returns></returns>
        IEnumerable<TEntity> FindByAndInclude<K>(
            Expression<Func<TEntity, bool>> predicate,
            int? page = null,
            int? pageSize = null,
            Expression<Func<TEntity, K>> order = null,
            bool? isOrderByDescendent = null,
            params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// Get a query result with relations
        /// </summary>
        /// <param name="predicate">Query</param>
        /// <param name="includeProperties">Relations to include</param>
        /// <returns></returns>
        IEnumerable<TEntity> FindByAndInclude(
            Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// Order a query resut
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <param name="query">Query</param>
        /// <param name="order">Order by expression</param>
        /// <param name="isOrderByDescendent"></param>
        /// <returns></returns>
        IQueryable<TEntity> EntityOrderBy<K>(
            IQueryable<TEntity> query,
            Expression<Func<TEntity, K>> order = null,
            bool? isOrderByDescendent = null);

        /// <summary>
        /// Paginate a query result
        /// </summary>
        /// <param name="query">Query</param>
        /// <param name="page">Page to return</param>
        /// <param name="pageSize">Number of object per page</param>
        /// <returns></returns>
        IEnumerable<TEntity> EntityPaginated(
            IQueryable<TEntity> query,
            int? page = null,
            int? pageSize = null);
    }
}