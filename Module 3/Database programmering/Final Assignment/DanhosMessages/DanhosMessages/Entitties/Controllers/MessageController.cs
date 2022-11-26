using DanhosMessages.Components.Errors;
using DanhosMessages.Entitties.Components;

namespace DanhosMessages.Entitties.Controllers
{
    public class MessageController : Controller<Message>
    {
        public MessageController(DanhosMessagesContext context) : base(context) { }

        protected override Message AddIfNull(Message message)
        {
            if (message == null) throw new InvalidMessageException("Message cannot be null");
            return message;
        }
    }
}
