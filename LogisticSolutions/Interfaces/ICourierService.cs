using System.Collections.Generic;
using LogisticSolutions.Models;

namespace LogisticSolutions.Interfaces
{
    public interface ICourierService
    {
        IEnumerable<Delivery> GetReceipts();

        IEnumerable<Delivery> GetDeliveries();        

        bool Reciept(string deliveryId);
        
        bool WarehousePick(string deliveryId);
        
        bool WarehousePass(string deliveryId);

        bool Deliver(string deliveryId);

    }
}