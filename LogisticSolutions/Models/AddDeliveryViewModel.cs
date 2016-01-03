using System;

namespace LogisticSolutions.Models
{
    public class AddDeliveryViewModel
    {
        public decimal Weight { get; set; }

        public decimal Height { get; set; }

        public decimal Width { get; set; }

        public decimal Length { get; set; }

        public DateTime ReceiptDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string Content { get; set; }

        public string AdditionalInfo { get; set; }

        public PostalAddress PickupAddress { get; set; }

        public PostalAddress DestinationAddress { get; set; }

    }
}