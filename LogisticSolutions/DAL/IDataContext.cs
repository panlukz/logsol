using System.Data.Entity;
using LogisticSolutions.Models;

namespace LogisticSolutions.DAL
{
    public interface IDataContext
    {
        DbSet<Delivery> Deliveries { get; set; }
        DbSet<TrackingStatus> TrackingStatuses { get; set; }
    }
}