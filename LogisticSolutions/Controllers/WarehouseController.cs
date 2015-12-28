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

        public ActionResult WarehouseReceipt(string deliveryId)
        {
            var result = _warehouseService.WarehouseReceipt(deliveryId) ? string.Format("Przyjecie na magazyn przesylki {0}", deliveryId) :
            "Błąd w przyjęciu przesyłki na magazyn!";

            return Content(result);
        }

        public ActionResult WarehouseRelease(string deliveryId)
        {
            var result = _warehouseService.WarehouseRelease(deliveryId) ? string.Format("Wydanie z magazynu przesylki {0}", deliveryId) :
            "Błąd w wydaniu przesyłki z magazynu!";

            return Content(result);
        }
    }
}