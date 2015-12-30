using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LogisticSolutions.DAL;
using LogisticSolutions.Interfaces;
using LogisticSolutions.Models;
using LogisticSolutions.Models.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebGrease.Css.Extensions;


namespace LogisticSolutions.Services
{
    public sealed class DeliveryService : ServiceBase, IDeliveryService
    {
        public DeliveryService(IDataFactory dataFactory, HttpContextBase httpContext)
            : base(dataFactory, httpContext)
        {
        }

        public bool RegisterDelivery(Delivery newDelivery)
        {
            newDelivery.SenderId = CurrentUser.Id;
            newDelivery.Number = Guid.NewGuid().ToString();
            newDelivery.TrackingHistory.Add(GenerateTrackingPoint(TrackingStatus.RegistredInSystem));

            using (var dataContext = DataFactory.GetDataContext())
            {
                dataContext.Deliveries.Add(newDelivery);
                dataContext.SaveChanges();
            }

            return true;
        }

        public IEnumerable<Delivery> GetDeliveries()
        {
            IEnumerable<Delivery> deliveries;

            using (var db = DataFactory.GetDataContext())
            {
                deliveries =
                    db.Deliveries.Where(d => d.SenderId == CurrentUser.Id).Include(e => e.TrackingHistory).ToList();
            }
            return deliveries;
        }

        public Delivery GetTrackingDetails(string id)
        {
            Delivery delivery;

            using (var db = DataFactory.GetDataContext())
            {
                delivery = db.Deliveries.Where(d => d.Number == id).Include(e => e.TrackingHistory).FirstOrDefault();
            }

            return delivery;
        }
    }
}