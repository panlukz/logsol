using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogisticSolutions.Models
{
    public enum TrackingStatusEnum
    {
        RegistredInSystem,
        PickedUpFromSender,
        WarehouseReceipt,
        WarehouseRelease,
        InDelivery,
        Delivered
    }
}