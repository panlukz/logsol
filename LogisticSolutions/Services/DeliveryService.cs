using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LogisticSolutions.DAL;
using LogisticSolutions.Interfaces;
using LogisticSolutions.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebGrease.Css.Extensions;


namespace LogisticSolutions.Services
{
    public sealed class DeliveryService : IDeliveryService
    {
        private readonly IDataFactory _dataFactory;
        private readonly ApplicationUser _currentUser;

        public DeliveryService(IDataFactory dataFactory, ApplicationUser user = null)
        {
            _dataFactory = dataFactory;
            _currentUser = user ??
                HttpContext.Current.GetOwinContext()
                    .GetUserManager<ApplicationUserManager>()
                    .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
        }

        public bool RegisterDelivery(Delivery newDelivery)
        {
            newDelivery.SenderId = _currentUser.Id;
            newDelivery.Number = Guid.NewGuid().ToString();
            newDelivery.TrackingHistory.Add(new TrackingStatus()
            {
                Author = _currentUser.Id,
                DateTime = DateTime.Now,
                Location = _currentUser.UserInfo.Location
            });

            using (var dataContext = _dataFactory.GetDataContext())
            {
                dataContext.Deliveries.Add(newDelivery);
                dataContext.SaveChanges();
            }

            return true;
        }

        public IEnumerable<Delivery> GetDeliveries()
        {
            IEnumerable<Delivery> deliveries;

            using (var db = _dataFactory.GetDataContext())
            {
                deliveries =
                    db.Deliveries.Where(d => d.SenderId == _currentUser.Id).Include(e => e.TrackingHistory).ToList();
            }
            return deliveries;
        }

        public Delivery GetTrackingDetails(string id)
        {
            Delivery delivery;

            using (var db = _dataFactory.GetDataContext())
            {
                delivery = db.Deliveries.Where(d => d.Number == id).Include(e => e.TrackingHistory).FirstOrDefault();
            }

            return delivery;
        }
    }
}