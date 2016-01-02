namespace LogisticSolutions.Models
{
    public class DeliveryViewModel
    {
        public string Number { get; set; }
        public PostalAddress PickupAddress { get; set; }
        public PostalAddress DestinationAddress { get; set; }
        public TrackingStatus Status { get; set; }
    }
}