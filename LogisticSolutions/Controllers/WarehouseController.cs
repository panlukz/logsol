using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogisticSolutions.Models;

namespace LogisticSolutions.Controllers
{
    public class WarehouseController : Controller
    {
        // GET: Warehouse
        public ActionResult WarehouseReceipt(Delivery delivery)
        {
            return View();
        }

        public ActionResult WarehouseRelease(Delivery delivery)
        {
            return View();
        }
    }
}