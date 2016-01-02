using System.Data.Entity;
using LogisticSolutions.Interfaces;
using LogisticSolutions.Models;
using LogisticSolutions.Models.Users;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LogisticSolutions.DAL
{
    public class DataContext : IdentityDbContext<ApplicationUser>, IDataContext
    {
        public DataContext()
            : base("DefaultConnection")
        {
        }

        public static DataContext Create()
        {
            return new DataContext();
        }

        public IDbSet<Delivery> Deliveries { get; set; }
        public IDbSet<TrackingHistoryPoint> TrackingHistoryPoints { get; set; }
    }
}