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

        public CourierService(IDataFactory dataFactory, HttpContextBase httpContext)
            : base(dataFactory, httpContext)
        {
        }

        public IEnumerable<Delivery> GetReceipts()
        {
            IEnumerable<Delivery> reciepts;
            
            using (var db = DataFactory.GetDataContext())
            {
                //Wyswietla odbiory czyli takie kt�re maj� ostatni status jako RegistredInSystem
                //i ten PickUpCity jest miastem zalogowanego kuriera
                reciepts =
                    db.Deliveries.Where(
                        del =>
                            del.PickupAddress.City == CurrentUser.UserInfo.Location &&
                            del.TrackingHistory.OrderByDescending(x => x.Id).FirstOrDefault().Status == TrackingStatus.RegistredInSystem
                            ).ToList();
            }

            return reciepts;
        }

        public IEnumerable<Delivery> GetDeliveries()
        {
            IEnumerable<Delivery> deliveries;

            using (var db = DataFactory.GetDataContext())
            {
                //Wy�wietla przesy�ki do  dostarczenia. Czyli ostatni status to WareHouseReciept
                //w miescie tym samym co DestinationCity i tym samym co maisto zalogowanego kuriera.
                deliveries =
                    db.Deliveries.Where(
                        del =>
                            del.DestinationAddress.City == CurrentUser.UserInfo.Location &&
                            del.TrackingHistory.OrderByDescending(x => x.Id).FirstOrDefault().Status == TrackingStatus.WarehouseReceipt &&
                            del.TrackingHistory.OrderByDescending(x => x.Id).FirstOrDefault().Location == CurrentUser.UserInfo.Location
                            ).ToList();
            }

            return deliveries;
        }

        public bool Reciept(string deliveryId)
        {
            using (var db = DataFactory.GetDataContext())
            {
                var delivery = db.Deliveries.FirstOrDefault(del => del.Number == deliveryId);

                if (delivery == null) return false;

                delivery.TrackingHistory.Add(GenerateTrackingPoint(TrackingStatus.PickedUpFromSender));
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

                delivery.TrackingHistory.Add(GenerateTrackingPoint(TrackingStatus.InDelivery));
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

                delivery.TrackingHistory.Add(GenerateTrackingPoint(TrackingStatus.WarehousePass));
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

                delivery.TrackingHistory.Add(GenerateTrackingPoint(TrackingStatus.Delivered));
                db.SaveChanges();
                return true;
            }
        }
    }
}