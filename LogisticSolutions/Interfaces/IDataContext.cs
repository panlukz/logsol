using System;
using System.Data.Entity;
using LogisticSolutions.Models;

namespace LogisticSolutions.Interfaces
{
    public interface IDataContext : IDisposable
    {
        IDbSet<Delivery> Deliveries { get; set; }
        IDbSet<TrackingHistoryPoint> TrackingHistoryPoints { get; set; }

        int SaveChanges();
    }
}