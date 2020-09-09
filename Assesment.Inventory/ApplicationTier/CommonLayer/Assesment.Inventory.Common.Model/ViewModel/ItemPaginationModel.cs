using Assesment.Inventory.Common.Model.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.Inventory.Common.Model.ViewModel
{
    public class ItemPaginationModel
    {
        public IEnumerable<ItemDTO> Items { get; set; }

        public int PageCount { get; set; }

        public int PageNumber { get; set; }

        public List<int> PageList { get; set; }
    }
}
