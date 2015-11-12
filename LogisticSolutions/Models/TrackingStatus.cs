using System;

namespace LogisticSolutions.Models
{
    public class TrackingStatus
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        public TrackingStatusEnum Status { get; set; }
        public string Author { get; set; }

        public string Delivery_Number { get; set; }
        public Delivery Delivery { get; set; }
    }
}