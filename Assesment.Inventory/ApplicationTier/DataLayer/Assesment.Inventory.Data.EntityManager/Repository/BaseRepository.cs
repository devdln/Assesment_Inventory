using Assesment.Inventory.Data.EntityManager.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.Inventory.Data.EntityManager.Repository
{
    public class BaseRepository : IRepository
    {
        private InventoryDbContext inventoryDbContext;

        public BaseRepository()
        {
            this.inventoryDbContext = new InventoryDbContext();
        }

        public void Delete<T>(Expression<Func<T, bool>> predicate) where T : class
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

        public IQueryable<T> GetIQueryable<T>() where T : class
        {            
            try
            {
                return this.inventoryDbContext.Set<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Insert<T>(T instance) where T : class
        {
            try
            {
                return this.inventoryDbContext.Set<T>().Add(instance);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SaveChanges()
        {
            int returnValue = -1;
            try
            {
                returnValue = this.inventoryDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnValue;
        }

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
                throw ex;
            }
        }
    }
}
