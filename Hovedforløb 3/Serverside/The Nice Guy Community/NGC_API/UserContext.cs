using Microsoft.EntityFrameworkCore;
using NGC_Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGC_API
{
    public class UserContext : DanhoLibrary.EFController.DanhoDBContext
    {
        public DbSet<Login> Logins { get; set; }
        public DbSet<User> Users { get; set; }

        private string ConnectionString { get; set; } =
            //"Data Source=DANIEL-SIMONSEN\\MASTERRUNEUWU;" +
            "Data Source=(localdb)\\MSSQLLocalDB;" +
            "Initial Catalog=H3ServersideNGC;" +
            "Trusted_Connection=true;";

        public UserContext() { }
        public UserContext(string dataSource, string dbName = "H3ServersideNGC")
        {
            //Values:
            //  DANIEL-SIMONSEN\\MASTERRUNEUWU  [LAPTOP]
            //  (localdb)\\MSSQLLocalDB         [PC]
            //  H3ServersideNGC                 [dbName]

            ConnectionString =
                $"Data Source={dataSource};" +
                $"Initial Catalog={dbName};" +
                "Trusted_Connection=true;";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder) => builder.UseSqlServer(ConnectionString);
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Login>()
                .HasOne(login => login.User)
                .WithOne(user => user.Login)
                .HasForeignKey<User>(u => u.ID);
        }
    }
}
