using DanhosMessages.Entitties.Controllers;

namespace DanhosMessages.Entitties
{
    public class DBAccess
    {
        public static readonly DBAccess Database = new(DanhosMessagesContext.Context);

        public UserController Users { get; set; }
        public ChatController Chats { get; set; }
        public MessageController Messages { get; set; }

        public DBAccess(DanhosMessagesContext context)
        {
            Users = new UserController(context);
            Chats = new ChatController(context);
            Messages = new MessageController(context);
        }
    }
}
