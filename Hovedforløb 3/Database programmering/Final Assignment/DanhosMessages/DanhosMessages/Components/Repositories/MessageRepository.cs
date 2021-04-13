using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DanhoComponents;
using LoginDatabase.Repositories;
using LoginDatabase.Interfaces;

namespace DanhosMessages.Components.Repositories
{
    public class MessageRepository : Repository<Message>
    {
        public MessageRepository(IDbContext context, string dataSource) : base(context) => context = new ProgramContext(dataSource);
        public MessageRepository(IDbContext context, string dataSource, string dbName) : base(context) => context = new ProgramContext(dataSource, dbName);
    }
}
