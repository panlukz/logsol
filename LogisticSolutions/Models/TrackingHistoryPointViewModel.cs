using System;

namespace LogisticSolutions.Models
{
    public class TrackingHistoryPointViewModel
    {
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        public TrackingStatus Status { get; set; }
        public string Author { get; set; }
    }
}