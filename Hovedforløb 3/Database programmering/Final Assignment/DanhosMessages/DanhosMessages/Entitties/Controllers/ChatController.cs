using DanhosMessages.Entitties.Components;

namespace DanhosMessages.Entitties.Controllers
{
    public class ChatController : Controller<Chat>
    {
        public ChatController(DanhosMessagesContext context) : base(context) { }

        protected override Chat AddIfNull(Chat chat) => chat ?? new Chat();
    }
}
