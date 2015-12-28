using System.Collections.Generic;
using LogisticSolutions.Models;

namespace LogisticSolutions.Interfaces
{
    public interface IWarehouseService
    {
        bool WarehouseRelease(string deliveryId);
        bool WarehouseReceipt(string deliveryId);
        IEnumerable<Delivery> GetAllDeliveries();
    }
}