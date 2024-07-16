using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TruckPlan.Data;

namespace TruckPlan.EntityFramework
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "Server=localhost;Database=TruckPlan;User Id=sa;Password=AycA7gR9qwESrm;TrustServerCertificate=True;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TruckDriver> TruckDriver { get; set; }
        public DbSet<Truck> Truck { get; set; }
        public DbSet<TruckGPS> TruckGPS { get; set; }
        public DbSet<Journey> Journey { get; set; }
        public DbSet<JourneySummary> JourneySummary { get; set; }

    }
}
