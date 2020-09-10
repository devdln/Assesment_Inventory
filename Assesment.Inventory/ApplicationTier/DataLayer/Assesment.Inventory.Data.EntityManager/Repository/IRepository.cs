using System;
using System.Linq;

namespace Assesment.Inventory.Data.EntityManager.Repository
{
    /// <summary>
    /// IRepository interface
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Gets all query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IQueryable<T> GetIQueryable<T>() where T : class;

        /// <summary>
        /// Inserts the specified instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">The instance.</param>
        /// <returns>Instance.</returns>
        T Insert<T>(T instance) where T : class;

        /// <summary>
        /// Updates the specified instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">The instance.</param>
        /// <returns>Instance.</returns>
        T Update<T>(T instance) where T : class;

        /// <summary>
        /// Deletes the specified predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate">The predicate.</param>
        void Delete<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}
