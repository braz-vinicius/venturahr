using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace VenturaHR.Domain.Interfaces
{
    /// <summary>
    /// Base interface that represents a generic repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        /// <summary>
        /// Add item into repository
        /// </summary>
        /// <param name="item">Item to add to repository</param>
        void Add(TEntity item);

        /// <summary>
        /// Deletes an item from the repository
        /// </summary>
        /// <param name="item">Item to delete from repository</param>
        void Delete(TEntity item);

        /// <summary>
        /// Deletes an item from the repository given its id.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        void DeleteById<T>(T id);

        /// <summary>
        /// Updates an item from the repository
        /// </summary>
        /// <param name="item">Item to update from repository</param>
        void Update(TEntity item);


        /// <summary>
        /// Given an expression filter, obtains an element of type {T} in repository
        /// </summary>
        /// <returns>List of selected elements</returns>
        TEntity Get(Expression<Func<TEntity, bool>> filter, params string[] includeEntities);

        /// <summary>
        /// Get all elements of type {T} in repository
        /// </summary>
        /// <returns>List of selected elements</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Get all elements of type {T} in repository
        /// </summary>
        /// <returns>List of selected elements</returns>
        IEnumerable<TEntity> FindWhere(Expression<Func<TEntity, bool>> filter, params string[] includeEntities);

    }
}
