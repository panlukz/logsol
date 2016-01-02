using System.Collections.Generic;
using LogisticSolutions.Models;

namespace LogisticSolutions.Interfaces
{
    public interface IDeliveryService
    {
        bool RegisterDelivery(Delivery newDelivery);
        IEnumerable<Delivery> GetDeliveries();
        IEnumerable<TrackingHistoryPointViewModel> GetTrackingDetails(string id);
    }
}