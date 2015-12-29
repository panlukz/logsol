using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogisticSolutions.Interfaces;
using LogisticSolutions.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace LogisticSolutions.Services
{
    public class WarehouseService : ServiceBase, IWarehouseService
    {
        public WarehouseService(IDataFactory dataFactory, ApplicationUser user = null) : base(dataFactory, user)
        {
        }

        public bool WarehouseRelease(string deliveryId)
        {
            using (var db = DataFactory.GetDataContext())
            {
                var delivery = db.Deliveries.FirstOrDefault(del => del.Number == deliveryId);

                if (delivery == null) return false;

                delivery.TrackingHistory.Add(GenerateTrackingPoint(TrackingStatusEnum.WarehouseRelease));
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

                delivery.TrackingHistory.Add(GenerateTrackingPoint(TrackingStatusEnum.WarehouseReceipt));
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
                            del.TrackingHistory.OrderByDescending(x => x.DateTime).FirstOrDefault().Location == CurrentUser.UserInfo.Location &&
                            del.TrackingHistory.OrderByDescending(x => x.DateTime).FirstOrDefault().Status == TrackingStatusEnum.WarehousePass).ToList();
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
                            del.TrackingHistory.OrderByDescending(x => x.DateTime).FirstOrDefault().Status == TrackingStatusEnum.WarehouseReceipt).ToList();
            }

            return deliveries;
        }
    }
}