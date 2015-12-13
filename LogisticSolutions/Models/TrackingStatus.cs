using System;
using System.ComponentModel.DataAnnotations;

namespace LogisticSolutions.Models
{
    public class TrackingStatus
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        public TrackingStatusEnum Status { get; set; }
        public string Author { get; set; }
        
        [Required]
        public Delivery Delivery { get; set; }
    }
}