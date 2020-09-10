using Assesment.Inventory.Common.Util.Helpers;
using Assesment.Inventory.Data.EntityManager.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Assesment.Inventory.Data.EntityManager.Repository
{
    /// <summary>
    /// BaseRepository class
    /// </summary>
    /// <seealso cref="Assesment.Inventory.Data.EntityManager.Repository.IRepository" />
    public class BaseRepository : IRepository
    {
        /// <summary>
        /// The inventory database context
        /// </summary>
        private InventoryDbContext inventoryDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository"/> class.
        /// </summary>
        public BaseRepository()
        {
            this.inventoryDbContext = new InventoryDbContext();
        }

        /// <summary>
        /// Deletes the specified predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate">The predicate.</param>
        public void Delete<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            try
            {
                List<T> instance = inventoryDbContext.Set<T>().Where(predicate).ToList();

                if (instance.Any())
                {
                    foreach (var item in instance)
                    {
                        if (item != null)
                        {
                            inventoryDbContext.Set<T>().Remove(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex, MethodBase.GetCurrentMethod().Name);

                throw ex;
            }
        }

        /// <summary>
        /// Gets all query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IQueryable<T> GetIQueryable<T>() where T : class
        {            
            try
            {
                return this.inventoryDbContext.Set<T>();
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex, MethodBase.GetCurrentMethod().Name);

                throw ex;
            }
        }

        /// <summary>
        /// Inserts the specified instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">The instance.</param>
        /// <returns>
        /// Instance.
        /// </returns>
        public T Insert<T>(T instance) where T : class
        {
            try
            {
                return this.inventoryDbContext.Set<T>().Add(instance);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex, MethodBase.GetCurrentMethod().Name);

                throw ex;
            }
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            int returnValue = -1;
            try
            {
                returnValue = this.inventoryDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex, MethodBase.GetCurrentMethod().Name);

                throw ex;
            }

            return returnValue;
        }

        /// <summary>
        /// Updates the specified instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">The instance.</param>
        /// <returns>
        /// Instance.
        /// </returns>
        public T Update<T>(T instance) where T : class
        {
            try
            {
                this.inventoryDbContext.Set<T>().Attach(instance);
                this.inventoryDbContext.Entry(instance).State = EntityState.Modified;

                return instance;
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex, MethodBase.GetCurrentMethod().Name);

                throw ex;
            }
        }
    }
}
