using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LogisticSolutions.Models;

namespace LogisticSolutions.DAL
{
    public class DeliveryContext : DbContext
    {
        public DeliveryContext()
            : base("DefaultConnection")
        {
            
        }

        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<TrackingStatus> TrackingStatuses { get; set; }
    }
}