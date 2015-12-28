using System.Collections.Generic;
using LogisticSolutions.Models;

namespace LogisticSolutions.Interfaces
{
    public interface IWarehouseService
    {
        bool WarehouseRelease(Delivery delivery);
        bool WarehouseReceipt(Delivery delivery);
        IEnumerable<Delivery> GetAllDeliveries();
    }
}