using System;
using System.Data.Entity;
using LogisticSolutions.Models;

namespace LogisticSolutions.DAL
{
    public interface IDataContext : IDisposable
    {
        IDbSet<Delivery> Deliveries { get; set; }
        IDbSet<TrackingStatus> TrackingStatuses { get; set; }

        int SaveChanges();
    }
}