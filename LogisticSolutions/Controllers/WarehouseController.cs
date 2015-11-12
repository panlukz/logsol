using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogisticSolutions.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LogisticSolutions.Controllers
{
    [Authorize(Roles = "Warehouseman,Admin")]
    public class WarehouseController : Controller
    {

        public ActionResult ShowWarehouse()
        {
            var currentUserId = User.Identity.GetUserId();
            var userManager =
                new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = userManager.FindById(currentUserId);
            return Content("Wyświetlamy wszystkie przesyłki ktore mają status zdane na magazyn z miasta " + currentUser.UserInfo.Location);
        }

        public ActionResult WarehouseReceipt(Delivery delivery)
        {
            return Content("Przyjecie na magazyn przesylki" + delivery.Number);
        }

        public ActionResult WarehouseRelease(Delivery delivery)
        {
            return Content("Warehouse delivery!");
        }
    }
}