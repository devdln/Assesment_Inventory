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

namespace Assesment.Inventory.Controllers.Item
{
    [Authorize()]
    public class ItemController : Controller
    {
        IItemService itemService;

        public ItemController()
        {
            this.itemService = IocResolver.Resolve<IItemService>();
        }

        // GET: Item
        public ActionResult Index(int? page)
        {
            ItemPaginationModel itemPagination = this.itemService.Pagination(page);

            return View(itemPagination);
        }

        // GET: Item/Details/5
        public ActionResult Details(int id)
        {
            ItemDTO item = this.itemService.Get(id);

            return View(item);
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        public ActionResult Create(ItemDTO item)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    ItemDTO itemReturned = this.itemService.Create(item);
                }
                else
                {
                    return View("Create", item);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int id)
        {
            ItemDTO item = this.itemService.Get(id);

            return View(item);
        }

        // POST: Item/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ItemDTO item)
        {
            try
            {
                // TODO: Add update logic here
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    ItemDTO itemReturned = this.itemService.Update(item);
                }
                else
                {
                    return View("Edit", item);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int id)
        {
            ItemDTO item = this.itemService.Get(id);

            return View(item);
        }

        // POST: Item/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ItemDTO item)
        {
            try
            {
                // TODO: Add delete logic here
                int returnValue = this.itemService.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
