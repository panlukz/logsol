using System.Collections.Generic;
using LogisticSolutions.Models;

namespace LogisticSolutions.Interfaces
{
    public interface ICourierService
    {
        IEnumerable<Delivery> GetReceipts();
        bool Receipt(Delivery delivery);
        bool WarehousePick(Delivery delivery);
        bool WarehousePass(Delivery delivery);

    }
}