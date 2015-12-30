using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogisticSolutions.DAL;
using LogisticSolutions.Interfaces;
using LogisticSolutions.Models;
using LogisticSolutions.Models.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace LogisticSolutions.Services
{
    public class CourierService : ServiceBase, ICourierService
    {
        
        public CourierService(IDataFactory dataFactory, ApplicationUser user = null) : base(dataFactory, user)
        {
        }

        public IEnumerable<Delivery> GetReceipts()
        {
            IEnumerable<Delivery> reciepts;
            
            using (var db = DataFactory.GetDataContext())
            {
                reciepts =
                    db.Deliveries.Where(
                        del =>
                            del.PickupAddress.City == CurrentUser.UserInfo.Location &&
                            del.TrackingHistory.OrderByDescending(x => x.DateTime).FirstOrDefault().Status ==
                            TrackingStatusEnum.RegistredInSystem).ToList();
            }

            return reciepts;
        }

        public IEnumerable<Delivery> GetDeliveries()
        {
            IEnumerable<Delivery> deliveries;

            using (var db = DataFactory.GetDataContext())
            {
                deliveries =
                    db.Deliveries.Where(
                        del =>
                            del.TrackingHistory.Where(x => x.Status == TrackingStatusEnum.WarehouseReceipt)
                                .OrderByDescending(x => x.DateTime).FirstOrDefault().Location == CurrentUser.UserInfo.Location &&
                            del.DestinationAddress.City == CurrentUser.UserInfo.Location).ToList();
            }

            return deliveries;
        }

        public bool Reciept(string deliveryId)
        {
            using (var db = DataFactory.GetDataContext())
            {
                var delivery = db.Deliveries.FirstOrDefault(del => del.Number == deliveryId);

                if (delivery == null) return false;

                delivery.TrackingHistory.Add(GenerateTrackingPoint(TrackingStatusEnum.PickedUpFromSender));
                db.SaveChanges();
                return true;
            }
        }

        public bool WarehousePick(string deliveryId)
        {
            using (var db = DataFactory.GetDataContext())
            {
                var delivery = db.Deliveries.FirstOrDefault(del => del.Number == deliveryId);

                if (delivery == null) return false;

                delivery.TrackingHistory.Add(GenerateTrackingPoint(TrackingStatusEnum.InDelivery));
                db.SaveChanges();
                return true;
            }    
        }

        public bool WarehousePass(string deliveryId)
        {
            using (var db = DataFactory.GetDataContext())
            {
                var delivery = db.Deliveries.FirstOrDefault(del => del.Number == deliveryId);
                
                if (delivery == null) return false;

                delivery.TrackingHistory.Add(GenerateTrackingPoint(TrackingStatusEnum.WarehousePass));
                db.SaveChanges();
                return true;
            }
        }

        public bool Deliver(string deliveryId)
        {
            using (var db = DataFactory.GetDataContext())
            {
                var delivery = db.Deliveries.FirstOrDefault(del => del.Number == deliveryId);

                if (delivery == null) return false;

                delivery.TrackingHistory.Add(GenerateTrackingPoint(TrackingStatusEnum.Delivered));
                db.SaveChanges();
                return true;
            }
        }
    }
}