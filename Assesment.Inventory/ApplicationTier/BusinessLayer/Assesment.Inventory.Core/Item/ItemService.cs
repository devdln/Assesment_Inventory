using Assesment.Inventory.Common.Ioc;
using Assesment.Inventory.Common.Model.Item;
using Assesment.Inventory.Core.API.Item;
using Assesment.Inventory.Data.EntityManager.Repository;
using System;
using System.Collections.Generic;
using ItemSchema = Assesment.Inventory.Data.Model.Item;
using System.Linq;
using Assesment.Inventory.Common.Model.Enums;
using Assesment.Inventory.Common.Model.ViewModel;
using Assesment.Inventory.Common.Util.Helpers;
using System.Reflection;

namespace Assesment.Inventory.Core.Item
{
    /// <summary>
    /// ItemService class
    /// </summary>
    /// <seealso cref="Assesment.Inventory.Core.API.Item.IItemService" />
    public class ItemService : IItemService
    {
        /// <summary>
        /// The repository
        /// </summary>
        IRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemService"/> class.
        /// </summary>
        public ItemService()
        {
            this.repository = IocResolver.Resolve<IRepository>();
        }

        /// <summary>
        /// Creates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public ItemDTO Create(ItemDTO item)
        {
            try
            {
                // map to db entity
                ItemSchema.Item itemDb = this.MapDtoToDbEntity(item);

                // set record status
                itemDb.RecordStatusId = (int)RecordStatuses.Active;

                itemDb = this.repository.Insert<ItemSchema.Item>(itemDb);
                this.repository.SaveChanges(); // call save changes to commit data to db
            }
            catch (Exception ex)
            {
                item = null;

                LogHelper.LogException(ex, MethodBase.GetCurrentMethod().Name);
            }

            return item;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public bool Delete(long Id)
        {
            bool isDeleteSuccess = false;

            try
            {
                ItemSchema.Item itemDb = this.repository.GetIQueryable<ItemSchema.Item>().Where<ItemSchema.Item>(a => a.Id == Id).FirstOrDefault<ItemSchema.Item>();

                itemDb.RecordStatusId = (int)RecordStatuses.Delete; // set reocrds status as delete

                this.repository.SaveChanges(); // commit data to db

                isDeleteSuccess = true;
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex, MethodBase.GetCurrentMethod().Name);
            }

            return isDeleteSuccess;
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public ItemDTO Get(long Id)
        {
            ItemDTO item = null;

            try
            {
                ItemSchema.Item itemDb = this.repository.GetIQueryable<ItemSchema.Item>().Where<ItemSchema.Item>(a => a.Id == Id).FirstOrDefault<ItemSchema.Item>();

                item = AutoMapperConf.AutoMapperConf.Instance.Mapper.Map<ItemDTO>(itemDb);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex, MethodBase.GetCurrentMethod().Name);                
            }

            return item;
        }

        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ItemDTO> List()
        {
            IEnumerable<ItemDTO> items = null;

            try
            {
                // get active records from db
                IEnumerable<ItemSchema.Item> itemsDbRecords = this.repository.GetIQueryable<ItemSchema.Item>().Where<ItemSchema.Item>(a => a.RecordStatusId == (int)RecordStatuses.Active)
                                                                        .ToList<ItemSchema.Item>();

                items = AutoMapperConf.AutoMapperConf.Instance.Mapper.Map<List<ItemDTO>>(itemsDbRecords);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex, MethodBase.GetCurrentMethod().Name);                
            }

            return items;
        }

        /// <summary>
        /// Paginations the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public ItemPaginationModel Pagination(int? page)
        {
            ItemPaginationModel itemPagination = new ItemPaginationModel();

            try
            {
                int pageSize = 10;

                itemPagination.PageNumber = (page ?? 1);

                // get no of active records
                int recordCount = this.repository.GetIQueryable<ItemSchema.Item>().Where<ItemSchema.Item>(a => a.RecordStatusId == (int)RecordStatuses.Active).Count();

                // get active reocrds according to selected page
                IEnumerable<ItemSchema.Item> items = this.repository.GetIQueryable<ItemSchema.Item>().Where<ItemSchema.Item>(a => a.RecordStatusId == (int)RecordStatuses.Active).OrderBy(a => a.Id)
                                                                    .Skip(pageSize * (itemPagination.PageNumber - 1)).Take(pageSize).ToList<ItemSchema.Item>();

                // page count calculate
                itemPagination.PageCount = (recordCount % pageSize) == 0 ? recordCount / pageSize : (recordCount / pageSize) + 1;

                // map data to items
                itemPagination.Items = AutoMapperConf.AutoMapperConf.Instance.Mapper.Map<List<ItemDTO>>(items);

                // no of pages in to an list to show in page 
                itemPagination.PageList = Enumerable.Range(1, itemPagination.PageCount).ToList();
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex, MethodBase.GetCurrentMethod().Name);

                throw ex;
            }

            return itemPagination;
        }

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public ItemDTO Update(ItemDTO item)
        {
            try
            {
                ItemSchema.Item itemDb = this.MapDtoToDbEntity(item);

                // set record status
                itemDb.RecordStatusId = (int)RecordStatuses.Active;

                itemDb = this.repository.Update<ItemSchema.Item>(itemDb);

                this.repository.SaveChanges();
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex, MethodBase.GetCurrentMethod().Name);
            }

            return item;
        }

        /// <summary>
        /// Maps the dto to database entity.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        private ItemSchema.Item MapDtoToDbEntity(ItemDTO item)
        {
            return AutoMapperConf.AutoMapperConf.Instance.Mapper.Map<ItemSchema.Item>(item);
        }
    }
}
