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

            return Content("Wyswietlamy wszystkie odbiory!");
        }

        [Authorize(Roles = "Courier, Admin")]
        [HttpPost]
        public ActionResult Receipt(Delivery delivery)
        {
            var result = _courierService.Receipt(delivery) ? "Odbior zrobiony!" : "Bład w obiorze";

            return Content(result);
        }

        [Authorize(Roles = "Courier, Admin")]
        [HttpPost]
        public ActionResult PassToWarehouse(Delivery delivery)
        {
            var result = _courierService.WarehousePass(delivery) ? "Przekazanie na magazyn udane!" : "Bład w przekazaniu na magazyn";

            return Content(result);
        }

        [Authorize(Roles = "Courier, Admin")]
        [HttpPost]
        public ActionResult PickFromWarehouse(Delivery delivery)
        {

            var result = _courierService.WarehousePick(delivery) ? "Pobrano przesyłkę z magazynu!" : "Bład w pobraniu przesyłki z magazynu";

            return Content(result);
        }

    }
}