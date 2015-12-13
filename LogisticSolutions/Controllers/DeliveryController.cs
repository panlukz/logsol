using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogisticSolutions.DAL;
using LogisticSolutions.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LogisticSolutions.Controllers
{
    public class DeliveryController : Controller
    {
        private readonly IDataFactory dataFactory;

        public DeliveryController(IDataContext data, IDataFactory dataFac)
        {
            dataFactory = dataFac;
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
            var currentUserId = User.Identity.GetUserId();
            var userManager =
                new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = userManager.FindById(currentUserId);

            newDelivery.SenderId = currentUser.Id;
            newDelivery.Number = Guid.NewGuid().ToString();
            newDelivery.TrackingHistory.Add(new TrackingStatus()
            {
                Author = User.Identity.GetUserId(),
                DateTime = DateTime.Now,
                Location = currentUser.UserInfo.Location
            });

            using (var dataContext = dataFactory.GetDataContext())
            {
                dataContext.Deliveries.Add(newDelivery);
                dataContext.SaveChanges();
            }


            

            return Content("Przesyłka zostanie odebrana z " + newDelivery.PickupAddress.City + " oraz wysłana do " + newDelivery.DestinationAddress.City);
        }

        public ActionResult Tracking()
        {
            List<Delivery> deliveriesList;
            using (var db = new DataContext())
            {
                var userId = User.Identity.GetUserId();
                deliveriesList = db.Deliveries.Where(d => d.SenderId == userId).Include(e => e.TrackingHistory).ToList();
            }

            return View(deliveriesList);
        }

        public ActionResult TrackingDetails(string id)
        {
            Delivery delivery;

            using (var db = new DataContext())
            {
                var userId = User.Identity.GetUserId();
                delivery = db.Deliveries.Where(d => d.Number == id).Include(e => e.TrackingHistory).FirstOrDefault();
            }

            return View(delivery);
        }
    }
}