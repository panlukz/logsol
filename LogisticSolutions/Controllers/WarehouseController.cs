using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogisticSolutions.Interfaces;
using LogisticSolutions.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LogisticSolutions.Controllers
{
    [Authorize(Roles = "Warehouseman,Admin")]
    public class WarehouseController : Controller
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        public ActionResult ShowWarehouse()
        {
            var deliveriesInWarehouse = _warehouseService.GetAllDeliveries();
            return Content("Wyświetlamy wszystkie przesyłki ktore mają status zdane na magazyn");
        }

        public ActionResult WarehouseReceipt(Delivery delivery)
        {
            var result = _warehouseService.WarehouseReceipt(delivery) ? string.Format("Przyjecie na magazyn przesylki {0}", delivery.Number) :
            "Błąd w przyjęciu przesyłki na magazyn!";

            return Content(result);
        }

        public ActionResult WarehouseRelease(Delivery delivery)
        {
            var result = _warehouseService.WarehouseRelease(delivery) ? string.Format("Wydanie z magazynu przesylki {0}", delivery.Number) :
            "Błąd w wydaniu przesyłki z magazynu!";

            return Content(result);
        }
    }
}