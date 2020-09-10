using Assesment.Inventory.Common.Model.Item;
using System.Collections.Generic;

namespace Assesment.Inventory.Common.Model.ViewModel
{
    /// <summary>
    /// ItemPaginationModel class
    /// </summary>
    public class ItemPaginationModel
    {
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public IEnumerable<ItemDTO> Items { get; set; }

        /// <summary>
        /// Gets or sets the page count.
        /// </summary>
        /// <value>
        /// The page count.
        /// </value>
        public int PageCount { get; set; }

        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        /// <value>
        /// The page number.
        /// </value>
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the page list.
        /// </summary>
        /// <value>
        /// The page list.
        /// </value>
        public List<int> PageList { get; set; }
    }
}
