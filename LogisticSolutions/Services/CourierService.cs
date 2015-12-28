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
    public class CourierService : ICourierService
    {
        private readonly IDataFactory _dataFactory;
        private readonly ApplicationUser _currentUser;

        public CourierService(IDataFactory dataFactory, ApplicationUser user = null)
        {
            _dataFactory = dataFactory;
            _currentUser = user ??
                HttpContext.Current.GetOwinContext()
                    .GetUserManager<ApplicationUserManager>()
                    .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
        }

        public IEnumerable<Delivery> GetReceipts()
        {
            IEnumerable<Delivery> reciepts;
            
            using (var db = _dataFactory.GetDataContext())
            {
                //with commented line query will show deliveries with RegistredInSystem status only!
                reciepts = db.Deliveries.Where(del => del.PickupAddress.City == _currentUser.UserInfo.Location
                                           /*&& del.TrackingHistory.Count == 1*/).ToList();
            }

            return reciepts;
        }

        public bool Reciept(string deliveryId)
        {
            using (var db = _dataFactory.GetDataContext())
            {
                var delivery = db.Deliveries.FirstOrDefault(del => del.Number == deliveryId);
                delivery.TrackingHistory.Add(
                    new TrackingStatus()
                    {   Author = _currentUser.Id,
                        DateTime = DateTime.Now, 
                        Status = TrackingStatusEnum.PickedUpFromSender,
                        Location = _currentUser.UserInfo.Location
                    });

                db.SaveChanges();
            }

            return true;
        }

        public bool WarehousePick(string deliveryId)
        {
            using (var db = _dataFactory.GetDataContext())
            {
                var delivery = db.Deliveries.FirstOrDefault(del => del.Number == deliveryId);
                delivery.TrackingHistory.Add(
                    new TrackingStatus()
                    {
                        Author = _currentUser.Id,
                        DateTime = DateTime.Now,
                        Status = TrackingStatusEnum.InDelivery,
                        Location = _currentUser.UserInfo.Location
                    });
                db.SaveChanges();
            }
            return true;
        }

        public bool WarehousePass(string deliveryId)
        {
            using (var db = _dataFactory.GetDataContext())
            {
                var delivery = db.Deliveries.FirstOrDefault(del => del.Number == deliveryId);
                delivery.TrackingHistory.Add(
                    new TrackingStatus()
                    {
                        Author = _currentUser.Id,
                        DateTime = DateTime.Now,
                        Status = TrackingStatusEnum.WarehouseReciept,
                        Location = _currentUser.UserInfo.Location
                    });
                db.SaveChanges();
            }

            return true;
        }

        public bool Deliver(string deliveryId)
        {
            using (var db = _dataFactory.GetDataContext())
            {
                var delivery = db.Deliveries.FirstOrDefault(del => del.Number == deliveryId);
                delivery.TrackingHistory.Add(
                    new TrackingStatus()
                    {
                        Author = _currentUser.Id,
                        DateTime = DateTime.Now,
                        Status = TrackingStatusEnum.Delivered,
                        Location = _currentUser.UserInfo.Location
                    });
                db.SaveChanges();
            }

            return true;
        }
    }
}