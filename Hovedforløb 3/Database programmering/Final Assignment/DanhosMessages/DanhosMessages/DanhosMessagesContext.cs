using Microsoft.EntityFrameworkCore;
using DanhosMessages.Entitties.Components;

namespace DanhosMessages
{
    public class DanhosMessagesContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }

        private string ConnectionString { get; set; } = 
            "Data Source=(localdb)\\MSSQLLocalDB;" + 
            "Initial Catalog=H3DBProgFinal;" + 
            "Trusted_Connection=true;";
        public static readonly DanhosMessagesContext Context = new("(localdb)\\MSSQLLocalDB");

        public DanhosMessagesContext() {}
        public DanhosMessagesContext(string dataSource, string dbName = "H3DBProgFinal")
        {
            //Laptop values:
            //  DANIEL-SIMONSEN\\MASTERRUNEUWU
            //  H3DBProgFinal

            ConnectionString =
                $"Data Source={dataSource};" +
                $"Initial Catalog={dbName};" +
                "Trusted_Connection=true;";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) => builder.UseSqlServer(ConnectionString);
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(u => u.Chats)      //User has many chats
                .WithMany(c => c.Users);    //Chat has many users

            builder.Entity<Chat>()
                .HasMany(c => c.Users)      //Chat has many users
                .WithMany(u => u.Chats);    //User has many chats
            builder.Entity<Chat>()
                .HasMany(c => c.Messages)   //Chat has many messages
                .WithOne(m => m.Chat);      //Message has one chat

            builder.Entity<Message>()
                .HasOne(m => m.Chat)        //Message has one chat
                .WithMany(c => c.Messages); //Chat has many messages
            builder.Entity<Message>()
                .HasOne(m => m.Sender)      //Message has one sender (user)
                .WithMany(m => m.Messages); //User has many messages
        }


        public void StateAsModified<Entity>(Entity entity) where Entity : class => Entry(entity).State = EntityState.Modified;
        public void StateAsDeleted<Entity>(Entity entity) where Entity : class => Entry(entity).State = EntityState.Deleted;
        public int ExecuteSqlCommand(string sql, params object[] parameters) => Database.ExecuteSqlRaw(sql, parameters);
    }
}