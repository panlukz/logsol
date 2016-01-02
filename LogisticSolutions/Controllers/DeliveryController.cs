﻿using System.Web.Mvc;
using LogisticSolutions.Interfaces;
using LogisticSolutions.Models;

namespace LogisticSolutions.Controllers
{
    public class DeliveryController : Controller
    {
        private readonly IDeliveryService _deliveryService;

        public DeliveryController(IDeliveryService deliveryService)
        {
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
                ? string.Format("Przesyłka zostanie odebrana z {0} oraz wysłana do {1}", newDelivery.PickupAddress.City,
                    newDelivery.DestinationAddress.City)
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
            var trackingDetails = _deliveryService.GetTrackingDetails(id);

            return View(trackingDetails);
        }
    }
}