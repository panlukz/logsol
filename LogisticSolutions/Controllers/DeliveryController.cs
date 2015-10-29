using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogisticSolutions.Models;

namespace LogisticSolutions.Controllers
{
    public class DeliveryController : Controller
    {

        public ActionResult Tracking(string deliveryNumber)
        {

            var pickupAddress = new PostalAddress("Krzyżowa 22/1 42-123 Warszawa");
            var destinationAddress = new PostalAddress("Warszawska 31/2 43-122 Gdańsk");
            var delivery = new Delivery(pickupAddress, destinationAddress);

            delivery.AddTrackingPoint(TrackingStatusEnum.PickedUpFromSender);

            var deliveryTrackingHistory = delivery.TrackingHistory;

            return View(deliveryTrackingHistory);
        }
    }
}