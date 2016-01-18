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

namespace LogisticSolutions.Services
{
    public class CourierService : ServiceBase, ICourierService
    {

        public CourierService(IDataFactory dataFactory, HttpContextBase httpContext)
            : base(dataFactory, httpContext)
        {
        }

        public IEnumerable<GetReceiptsViewModel> GetReceipts()
        {
            IEnumerable<GetReceiptsViewModel> receipts;
            
            using (var db = DataFactory.GetDataContext())
            {
                receipts =
                    db.Deliveries.AsNoTracking().Where(
                        del =>
                            del.PickupAddress.City == CurrentUser.UserInfo.Location &&
                            del.TrackingHistory.OrderByDescending(x => x.Id).FirstOrDefault().Status == TrackingStatus.RegistredInSystem
                            ).Select(d => new GetReceiptsViewModel()
                            {
                                DeliveryNumber = d.Number, 
                                Name = d.PickupAddress.Name,
                                ContactPerson = d.PickupAddress.ContactPerson,
                                AddressLine1 = d.PickupAddress.AddressLine1,
                                AddressLine2 = d.PickupAddress.AddressLine2,
                                City = d.PickupAddress.City,
                                PostalCode = d.PickupAddress.PostalCode
                            })
                            .ToList();

            }

            return receipts;
        }

        public IEnumerable<Delivery> GetDeliveries()
        {
            IEnumerable<Delivery> deliveries;

            using (var db = DataFactory.GetDataContext())
            {
                deliveries =
                    db.Deliveries.AsNoTracking().Where(
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

                delivery.AddTrackingHistoryPoint(GenerateTrackingPoint(TrackingStatus.PickedUpFromSender));
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

                delivery.AddTrackingHistoryPoint(GenerateTrackingPoint(TrackingStatus.InDelivery));
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

                delivery.AddTrackingHistoryPoint(GenerateTrackingPoint(TrackingStatus.WarehousePass));
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

                delivery.AddTrackingHistoryPoint(GenerateTrackingPoint(TrackingStatus.Delivered));
                db.SaveChanges();
                return true;
            }
        }
    }
}