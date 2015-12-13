using System;
using System.Data.Entity;
using LogisticSolutions.Models;

namespace LogisticSolutions.DAL
{
    public interface IDataContext : IDisposable
    {
        DbSet<Delivery> Deliveries { get; set; }
        DbSet<TrackingStatus> TrackingStatuses { get; set; }

        int SaveChanges();
    }
}