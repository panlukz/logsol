using System.Data.Entity;
using LogisticSolutions.Interfaces;
using LogisticSolutions.Models;

namespace LogisticSolutions.DAL
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext()
            : base("DefaultConnection")
        {
        }

        public IDbSet<Delivery> Deliveries { get; set; }
        public IDbSet<TrackingStatus> TrackingStatuses { get; set; }
    }
}