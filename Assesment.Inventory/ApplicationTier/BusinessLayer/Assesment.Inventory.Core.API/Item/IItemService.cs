using Assesment.Inventory.Common.Model.Item;
using Assesment.Inventory.Common.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.Inventory.Core.API.Item
{
    public interface IItemService
    {
        ItemDTO Create(ItemDTO item);

        ItemDTO Update(ItemDTO item);

        int Delete(long Id);

        IEnumerable<ItemDTO> List();

        ItemDTO Get(long Id);

        ItemPaginationModel Pagination(int? page);
    }
}
