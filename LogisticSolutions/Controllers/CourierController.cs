using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogisticSolutions.Interfaces;
using LogisticSolutions.Models;

namespace LogisticSolutions.Controllers
{
    public class CourierController : Controller
    {
        private readonly ICourierService _courierService;

        public CourierController(ICourierService courierService)
        {
            _courierService = courierService;
        }

        // GET: Courier
        [Authorize(Roles = "Courier, Admin")]
        public ActionResult GetReceipts()
        {
            var receipts = _courierService.GetReceipts();

            return View(receipts);
        }

        // GET: Courier
        [Authorize(Roles = "Courier, Admin")]
        public ActionResult GetDeliveries()
        {
            var receipts = _courierService.GetDeliveries();

            return View(receipts);
        }

        [Authorize(Roles = "Courier, Admin")]
        [HttpPost]
        public ActionResult Receipt(string deliveryId)
        {
            var result = _courierService.Reciept(deliveryId) ? "Odbior zrobiony!" : "Bład w obiorze";

            return Content(result);
        }

        [Authorize(Roles = "Courier, Admin")]
        [HttpPost]
        public ActionResult PassToWarehouse(string deliveryId)
        {
            var result = _courierService.WarehousePass(deliveryId) ? "Przekazanie na magazyn udane!" : "Bład w przekazaniu na magazyn";

            return Content(result);
        }

        [Authorize(Roles = "Courier, Admin")]
        [HttpPost]
        public ActionResult PickFromWarehouse(string deliveryId)
        {

            var result = _courierService.WarehousePick(deliveryId) ? "Pobrano przesyłkę z magazynu!" : "Bład w pobraniu przesyłki z magazynu";

            return Content(result);
        }

        [Authorize(Roles = "Courier, Admin")]
        [HttpPost]
        public ActionResult Deliver(string deliveryId)
        {
            var result = _courierService.Deliver(deliveryId) ? "Pobrano przesyłkę z magazynu!" : "Bład w pobraniu przesyłki z magazynu";

            return Content(result);
        }
        

    }
}