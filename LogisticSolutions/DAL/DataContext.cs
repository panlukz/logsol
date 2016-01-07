using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
#if DEBUG
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
#endif
        }

        public static DataContext Create()
        {
            return new DataContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Removing cascade delete conventions
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
            
        public IDbSet<Delivery> Deliveries { get; set; }
        public IDbSet<TrackingHistoryPoint> TrackingHistoryPoints { get; set; }
        public IDbSet<PostalAddress> PostalAddresses { get; set; }
    }
}