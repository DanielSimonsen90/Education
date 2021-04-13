using DanhoComponents;
using LoginDatabase.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DanhoEnTitties.Context
{
    interface IProgramContext : IDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<Chat> Chats { get; set; }
    }
}
