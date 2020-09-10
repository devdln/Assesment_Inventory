using Assesment.Inventory.Common.Model.Item;
using Assesment.Inventory.Common.Model.ViewModel;
using System.Collections.Generic;

namespace Assesment.Inventory.Core.API.Item
{
    /// <summary>
    /// IItemService interface
    /// </summary>
    public interface IItemService
    {
        /// <summary>
        /// Creates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        ItemDTO Create(ItemDTO item);

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        ItemDTO Update(ItemDTO item);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        bool Delete(long Id, ItemDTO item);

        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ItemDTO> List();

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        ItemDTO Get(long Id);

        /// <summary>
        /// Paginations the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        ItemPaginationModel Pagination(int? page);
    }
}
