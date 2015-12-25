using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogisticSolutions.DAL;
using LogisticSolutions.Interfaces;
using LogisticSolutions.Models;
using LogisticSolutions.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace LogisticSolutions.Controllers
{
    public class DeliveryController : Controller
    {
        private readonly IDataFactory _dataFactory;
        private readonly IDeliveryService _deliveryService;

        public DeliveryController(IDataFactory dataFactory, IDeliveryService deliveryService)
        {
            _dataFactory = dataFactory;
            _deliveryService = deliveryService;
        }

        [Authorize(Roles = "Customer,Courier,Warehouseman,Admin")]
        public ActionResult AddDelivery()
        {
            return View();
        }


        [Authorize(Roles = "Customer,Admin")]
        [HttpPost]
        public ActionResult AddDelivery(Delivery newDelivery)
        {
            var result = _deliveryService.RegisterDelivery(newDelivery)
                ? "Przesyłka zostanie odebrana z " + newDelivery.PickupAddress.City + " oraz wysłana do " +
                  newDelivery.DestinationAddress.City
                : "Błąd";

            return Content(result);
        }

        public ActionResult Tracking()
        {
            var deliveries = _deliveryService.GetDeliveries();
            
            return View(deliveries);
        }



        public ActionResult TrackingDetails(string id)
        {
            var delivery = _deliveryService.GetTrackingDetails(id); 

            return View(delivery);
        }
    }
}