using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assesment.Inventory.Controllers.Error
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            ViewBag.Error = "Sorry, an error has occured!";

            return View();
        }
    }
}