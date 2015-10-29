using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogisticSolutions.Models
{
    public class TrackingStatus
    {
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        public TrackingStatusEnum Status { get; set; }
        public string Author { get; set; }
    }
}