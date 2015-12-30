using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticSolutions.Models
{
    public class TrackingHistoryPoint
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        public TrackingStatus Status { get; set; }
        public string Author { get; set; }
        
        [Required]
        public Delivery Delivery { get; set; }
    }
}