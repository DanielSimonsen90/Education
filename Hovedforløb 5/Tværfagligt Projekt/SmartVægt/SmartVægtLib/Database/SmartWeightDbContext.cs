using SmartWeightLib.Models;
using System.Data.Entity;
#nullable disable

namespace SmartWeightLib.Database
{
    public class SmartWeightDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<PartialMeasurement> PartialMeasurements { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<Weight> Weights { get; set; }
    }
}
