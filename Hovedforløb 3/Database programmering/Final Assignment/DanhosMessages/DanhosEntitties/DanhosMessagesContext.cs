using Microsoft.EntityFrameworkCore;
using DanhoComponents;

namespace DanhosEntitties
{
    public class DanhosMessagesContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }

        private static string ConnectionString { get; set; }

        public DanhosMessagesContext(string dataSource, string dbName = "H3DBProgFinal")
        {
            //Laptop values:
            //  DANIEL-SIMONSEN\\MASTERRUNEUWU
            //  H3DBProgORM

            ConnectionString =
                $"Data Source={dataSource};" +
                $"Initial Catalog={dbName};" +
                "Trusted_Connection=true;";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) => builder.UseSqlServer(ConnectionString);

        public void StateAsModified<Entity>(Entity entity) where Entity : class => Entry(entity).State = EntityState.Modified;
        public void StateAsDeleted<Entity>(Entity entity) where Entity : class => Entry(entity).State = EntityState.Deleted;
        public int ExecuteSqlCommand(string sql, params object[] parameters) => Database.ExecuteSqlRaw(sql, parameters);
    }
}