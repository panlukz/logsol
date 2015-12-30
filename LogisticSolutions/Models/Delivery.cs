﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LogisticSolutions.Models
{
    public class Delivery
    {
        public Delivery()
        {
            TrackingHistory = new HashSet<TrackingHistoryPoint>();
        }

        [Key]
        public string Number { get; set; }

        public string SenderId { get; set; }

        public PostalAddress PickupAddress { get; set; }

        public PostalAddress DestinationAddress { get; set; }

        public virtual ICollection<TrackingHistoryPoint> TrackingHistory { get; private set; }
    }
}