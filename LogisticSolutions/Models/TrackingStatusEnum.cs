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
        WarehousePass,
        WarehouseReceipt,
        WarehouseRelease,
        InDelivery,
        Delivered
    }
}