using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogisticSolutions.DAL;
using LogisticSolutions.Interfaces;
using LogisticSolutions.Models;
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
                //with commented line query will show deliveries with RegistredInSystem status only!
                reciepts = db.Deliveries.Where(del => del.PickupAddress.City == CurrentUser.UserInfo.Location
                                           /*&& del.TrackingHistory.Count == 1*/).ToList();
            }

            return reciepts;
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