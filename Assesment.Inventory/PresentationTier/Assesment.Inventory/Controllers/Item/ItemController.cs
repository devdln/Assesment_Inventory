using Assesment.Inventory.Common.Ioc;
using Assesment.Inventory.Common.Model.Item;
using Assesment.Inventory.Core.API.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Assesment.Inventory.Common.Model.ViewModel;
using Assesment.Inventory.Common.Util.Helpers;
using System.Reflection;
using Assesment.Inventory.Common.Util.Constants;

namespace Assesment.Inventory.Controllers.Item
{
    /// <summary>
    /// ItemController class
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    [Authorize()]
    public class ItemController : Controller
    {
        /// <summary>
        /// The item service
        /// </summary>
        IItemService itemService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemController"/> class.
        /// </summary>
        public ItemController()
        {
            this.itemService = IocResolver.Resolve<IItemService>();
        }

        // GET: Item
        /// <summary>
        /// Indexes the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public ActionResult Index(int? page)
        {
            ItemPaginationModel itemPagination = this.itemService.Pagination(page);

            return View(itemPagination);
        }

        // GET: Item/Details/5
        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            ItemDTO item = this.itemService.Get(id);

            return View(item);
        }

        // GET: Item/Create
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        /// <summary>
        /// Creates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(ItemDTO item)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    ItemDTO itemReturned = this.itemService.Create(item);

                    if(itemReturned == null)
                    {
                        ModelState.AddModelError(string.Empty, ConstantErrors.ITEM_CREATE_ERROR);

                        return View("Create", item);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    return View("Create", item);
                }                
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex, MethodBase.GetCurrentMethod().Name);

                return View();
            }
        }

        // GET: Item/Edit/5
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            ItemDTO item = this.itemService.Get(id);

            return View(item);
        }

        // POST: Item/Edit/5
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(int id, ItemDTO item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ItemDTO itemReturned = this.itemService.Update(item);

                    if (itemReturned == null)
                    {
                        ModelState.AddModelError(string.Empty, ConstantErrors.ITEM_UPDATE_ERROR);

                        return View("Edit", item);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    return View("Edit", item);
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex, MethodBase.GetCurrentMethod().Name);

                return View();
            }
        }

        // GET: Item/Delete/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            ItemDTO item = this.itemService.Get(id);

            return View(item);
        }

        // POST: Item/Delete/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id, ItemDTO item)
        {
            try
            {
                bool isDeleteSuccess = this.itemService.Delete(id);

                if (isDeleteSuccess)
                {
                    return RedirectToAction("Index");                    
                }
                else
                {
                    ModelState.AddModelError(string.Empty, ConstantErrors.ITEM_UPDATE_ERROR);

                    return View("Edit", item);
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex, MethodBase.GetCurrentMethod().Name);

                return View();
            }
        }
    }
}
