using System.Web.Mvc;
using LogisticSolutions.Interfaces;

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
            var deliveriesInWarehouse = _warehouseService.GetRecievedDeliveries();
            return View(deliveriesInWarehouse);
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