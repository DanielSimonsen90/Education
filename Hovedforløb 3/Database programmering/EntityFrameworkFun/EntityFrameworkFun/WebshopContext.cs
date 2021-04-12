using EntityFrameworkFun.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkFun
{
    public class WebshopContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Basket> Baskets { get; set; }

        private static string ConnectionString
        {
            get => "Data Source=DANIEL-SIMONSEN\\MASTERRUNEUWU;" +
                "Initial Catalog=H3DBProgORM;" +
                "Trusted_Connection=true;";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(connectionString: ConnectionString);
        }
    }
}
