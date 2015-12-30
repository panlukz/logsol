using System;
using System.ComponentModel.DataAnnotations;

namespace LogisticSolutions.Models
{
    public enum TrackingStatus
    {
        [Display(Name = "Zarejestrowano w systemie")]
        RegistredInSystem,

        [Display(Name = "Odebrano od nadawcy")]
        PickedUpFromSender,

        [Display(Name = "Przekazanie na magazyn")]
        WarehousePass,

        [Display(Name = "Odbiór na magazynie")]
        WarehouseReceipt,

        [Display(Name = "Wydanie z magazynu")]
        WarehouseRelease,

        [Display(Name = "W dostawie")]
        InDelivery,

        [Display(Name = "Dostarczono")]
        Delivered

    }
}