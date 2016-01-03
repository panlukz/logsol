using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LogisticSolutions.Interfaces;
using LogisticSolutions.Models;


namespace LogisticSolutions.Services
{
    public sealed class DeliveryService : ServiceBase, IDeliveryService
    {
        public DeliveryService(IDataFactory dataFactory, HttpContextBase httpContext)
            : base(dataFactory, httpContext)
        {
        }

        public bool RegisterDelivery(AddDeliveryViewModel deliveryVM)
        {

            var delivery = new Delivery()
            {
                //TODO need to use automapper here for sure
                SenderId = CurrentUser.Id,
                Number = Guid.NewGuid().ToString(),
                DestinationAddress = deliveryVM.DestinationAddress,
                PickupAddress = deliveryVM.PickupAddress,
                AdditionalInfo = deliveryVM.AdditionalInfo,
                Content = deliveryVM.Content,
                DeliveryDate = deliveryVM.DeliveryDate,
                ReceiptDate = deliveryVM.ReceiptDate,
                Height = deliveryVM.Height,
                Width = deliveryVM.Width,
                Weight = deliveryVM.Weight,
                Length = deliveryVM.Length
            };

            delivery.AddTrackingHistoryPoint(GenerateTrackingPoint(TrackingStatus.RegistredInSystem, delivery.PickupAddress.City));

            using (var db = DataFactory.GetDataContext())
            {
                db.Deliveries.Add(delivery);
                db.SaveChanges();
            }

            return true;
        }

        public IEnumerable<DeliveryViewModel> GetDeliveries()
        {
            IEnumerable<DeliveryViewModel> deliveries;

            using (var db = DataFactory.GetDataContext())
            {
                deliveries =
                    db.Deliveries.Where(d => d.SenderId == CurrentUser.Id)/*.Include(e => e.TrackingHistory)*/.Select(d => new DeliveryViewModel()
                    {
                        Number = d.Number,
                        Status = d.TrackingHistory.OrderByDescending(tr => tr.Id).FirstOrDefault().Status,
                        PickupAddress = d.PickupAddress,
                        DestinationAddress = d.DestinationAddress
                    }).ToList();
            }
            return deliveries;
        }

        public IEnumerable<TrackingHistoryPointViewModel> GetTrackingDetails(string id)
        {
            IEnumerable<TrackingHistoryPointViewModel> historyPoints;

            using (var db = DataFactory.GetDataContext())
            {
                historyPoints =
                    db.TrackingHistoryPoints.Where(p => p.Delivery.Number == id)
                        .Select(p => new TrackingHistoryPointViewModel()
                        {
                            //TODO to think, maybe use AutoMapper in here?
                            Location = p.Location,
                            Status =  p.Status,
                            DateTime = p.DateTime,
                            Author = p.Author
                        }).ToList();
            }

            return historyPoints;
        }
    }
}