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

        public string ActualLocation { get; set; }

        public virtual ICollection<TrackingHistoryPoint> TrackingHistory { get; private set; }

        public void AddTrackingHistoryPoint(TrackingHistoryPoint historyPoint)
        {
            TrackingHistory.Add(historyPoint);
            ActualLocation = historyPoint.Location;
        }
    }
}