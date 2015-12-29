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
            using (var db = _dataFactory.GetDataContext())
            {
                var delivery = db.Deliveries.FirstOrDefault(del => del.Number == deliveryId);
                delivery.TrackingHistory.Add(
                    new TrackingStatus()
                    {
                        Author = _currentUser.Id,
                        DateTime = DateTime.Now,
                        Status = TrackingStatusEnum.WarehouseRelease,
                        Location = _currentUser.UserInfo.Location
                    });

                db.SaveChanges();
            }

            return true;
        }

        public bool WarehouseReceipt(string deliveryId)
        {
            using (var db = _dataFactory.GetDataContext())
            {
                var delivery = db.Deliveries.FirstOrDefault(del => del.Number == deliveryId);
                delivery.TrackingHistory.Add(
                    new TrackingStatus()
                    {
                        Author = _currentUser.Id,
                        DateTime = DateTime.Now,
                        Status = TrackingStatusEnum.WarehouseReceipt,
                        Location = _currentUser.UserInfo.Location
                    });

                db.SaveChanges();
            }

            return true;
        }

        public IEnumerable<Delivery> GetRecievedDeliveries()
        {
            IEnumerable<Delivery> deliveries;
            using (var db = _dataFactory.GetDataContext())
            {
                deliveries =
                    db.Deliveries.Where(
                        del =>
                            del.TrackingHistory.OrderByDescending(x => x.DateTime).FirstOrDefault().Location == _currentUser.UserInfo.Location &&
                            del.TrackingHistory.OrderByDescending(x => x.DateTime).FirstOrDefault().Status == TrackingStatusEnum.WarehouseReceipt).ToList();
            }

            return deliveries;
        }
    }
}