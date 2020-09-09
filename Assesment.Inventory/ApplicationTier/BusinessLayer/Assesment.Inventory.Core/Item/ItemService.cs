using Assesment.Inventory.Common.Ioc;
using Assesment.Inventory.Common.Model.Item;
using Assesment.Inventory.Core.API.Item;
using Assesment.Inventory.Data.EntityManager.Repository;
using System;
using System.Collections.Generic;
using ItemSchema = Assesment.Inventory.Data.Model.Item;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assesment.Inventory.Common.Model.Enums;
using AutoMapper;
using Assesment.Inventory.Common.Model.ViewModel;

namespace Assesment.Inventory.Core.Item
{
    public class ItemService : IItemService
    {
        IRepository repository;

        public ItemService()
        {
            this.repository = IocResolver.Resolve<IRepository>();
        }

        public ItemDTO Create(ItemDTO item)
        {
            ItemSchema.Item itemDb = this.MapDtoToDbEntity(item);

            itemDb.RecordStatusId = (int)RecordStatuses.Active;
            this.repository.Insert<ItemSchema.Item>(itemDb);
            this.repository.SaveChanges();

            return item;
        }

        public int Delete(long Id)
        {
            int returnValue = 0;

            ItemSchema.Item itemDb = this.repository.GetIQueryable<ItemSchema.Item>().Where<ItemSchema.Item>(a => a.Id == Id).FirstOrDefault<ItemSchema.Item>();
            itemDb.RecordStatusId = (int)RecordStatuses.Delete;

            this.repository.SaveChanges();

            return returnValue;
        }

        public ItemDTO Get(long Id)
        {
            ItemSchema.Item itemDb = this.repository.GetIQueryable<ItemSchema.Item>().Where<ItemSchema.Item>(a => a.Id == Id).FirstOrDefault<ItemSchema.Item>();

            ItemDTO item = AutoMapperConf.AutoMapperConf.Instance.Mapper.Map<ItemDTO>(itemDb);

            return item;
        }

        public IEnumerable<ItemDTO> List()
        {
            IEnumerable<ItemSchema.Item> items = this.repository.GetIQueryable<ItemSchema.Item>().Where<ItemSchema.Item>(a => a.RecordStatusId == (int)RecordStatuses.Active)
                                                                .ToList<ItemSchema.Item>();

            return AutoMapperConf.AutoMapperConf.Instance.Mapper.Map<List<ItemDTO>>(items);
        }

        public ItemPaginationModel Pagination(int? page)
        {
            ItemPaginationModel itemPagination = new ItemPaginationModel();

            int pageSize = 10;

            itemPagination.PageNumber = (page ?? 1);

            int recordCount = this.repository.GetIQueryable<ItemSchema.Item>().Where<ItemSchema.Item>(a => a.RecordStatusId == (int)RecordStatuses.Active).Count();

            IEnumerable<ItemSchema.Item> items = this.repository.GetIQueryable<ItemSchema.Item>().Where<ItemSchema.Item>(a => a.RecordStatusId == (int)RecordStatuses.Active).OrderBy(a => a.Id)
                                                                .Skip(pageSize * (itemPagination.PageNumber - 1)).Take(pageSize).ToList<ItemSchema.Item>();

            itemPagination.PageCount = (recordCount % pageSize) == 0 ? recordCount / pageSize : (recordCount / pageSize) + 1;
            itemPagination.Items = AutoMapperConf.AutoMapperConf.Instance.Mapper.Map<List<ItemDTO>>(items);

            itemPagination.PageList = Enumerable.Range(1, itemPagination.PageCount).ToList();

            return itemPagination;
        }

        public ItemDTO Update(ItemDTO item)
        {
            ItemSchema.Item itemDb = this.MapDtoToDbEntity(item);

            itemDb.RecordStatusId = (int)RecordStatuses.Active;
            this.repository.Update<ItemSchema.Item>(itemDb);
            this.repository.SaveChanges();

            return item;
        }

        private ItemSchema.Item MapDtoToDbEntity(ItemDTO item)
        {
            return AutoMapperConf.AutoMapperConf.Instance.Mapper.Map<ItemSchema.Item>(item);
        }
    }
}
