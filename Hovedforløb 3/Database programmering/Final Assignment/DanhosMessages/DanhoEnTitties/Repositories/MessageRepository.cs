using DanhoComponents;
using LoginDatabase.Repositories;
using LoginDatabase.Interfaces;

namespace DanhoEnTitties.Repositories
{
    public class MessageRepository : Repository<Message>
    {
        public MessageRepository(IDbContext context) : base(context) { }


    }
}
