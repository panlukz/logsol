using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogisticSolutions.Interfaces;
using LogisticSolutions.Models;
using LogisticSolutions.Models.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace LogisticSolutions.Services
{
    public class WarehouseService : ServiceBase, IWarehouseService
    {
        public WarehouseService(IDataFactory dataFactory, HttpContextBase httpContext) : base(dataFactory, httpContext)
        {
        }

        public bool WarehouseRelease(string deliveryId)
        {
            using (var db = DataFactory.GetDataContext())
            {
                var delivery = db.Deliveries.FirstOrDefault(del => del.Number == deliveryId);

                if (delivery == null) return false;

                delivery.AddTrackingHistoryPoint(GenerateTrackingPoint(TrackingStatus.WarehouseRelease));

                //TODO It's temporary until I will do something with passing deliveries between warehouses
                delivery.AddTrackingHistoryPoint(GenerateTrackingPoint(TrackingStatus.WarehousePass, delivery.DestinationAddress.City));
                db.SaveChanges();
                return true;
            }
        }

        public bool WarehouseReceipt(string deliveryId)
        {
            using (var db = DataFactory.GetDataContext())
            {
                var delivery = db.Deliveries.FirstOrDefault(del => del.Number == deliveryId);

                if (delivery == null) return false;

                delivery.AddTrackingHistoryPoint(GenerateTrackingPoint(TrackingStatus.WarehouseReceipt));
                db.SaveChanges();
                return true;
            }
        }

        public IEnumerable<Delivery> GetPassedDeliveries()
        {
            IEnumerable<Delivery> deliveries;
            using (var db = DataFactory.GetDataContext())
            {
                deliveries =
                    db.Deliveries.Where(
                        del =>
                            del.TrackingHistory.Where(x => x.Status == TrackingStatus.WarehousePass).OrderByDescending(x => x.DateTime).FirstOrDefault().Location == CurrentUser.UserInfo.Location).ToList();
            }

            return deliveries;
        }

        public IEnumerable<Delivery> GetRecievedDeliveries()
        {
            IEnumerable<Delivery> deliveries;
            using (var db = DataFactory.GetDataContext())
            {
                deliveries =
                    db.Deliveries.Where(
                        del =>
                            del.TrackingHistory.OrderByDescending(x => x.DateTime).FirstOrDefault().Location == CurrentUser.UserInfo.Location &&
                            del.TrackingHistory.OrderByDescending(x => x.DateTime).FirstOrDefault().Status == TrackingStatus.WarehouseReceipt).ToList();
            }

            return deliveries;
        }
    }
}