using DanhoComponents;
using LoginDatabase.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace DanhosMessages
{
    public class ProgramContext : DbContext, IDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public Chat Chat { get; set; }

        private static string ConnectionString { get; set; }

        public ProgramContext(string dataSource, string dbName = "H3DBProgFinal")
        {
            //Laptop values:
            //  DANIEL-SIMONSEN\\MASTERRUNEUWU
            //  H3DBProgORM

            ConnectionString =
                $"Data Source={dataSource};" +
                $"Initial Catalog={dbName};" +
                "Trusted_Connection=true;";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(ConnectionString);

        public void StateAsModified<Entity>(Entity entity) where Entity : class => Entry(entity).State = EntityState.Modified;
        public void StateAsDeleted<Entity>(Entity entity) where Entity : class => Entry(entity).State = EntityState.Deleted;
        public int ExecuteSqlCommand(string sql, params object[] parameters) => throw new NotImplementedException();
    }
}
