using DanhosEntitties.Components;
using DanhosEntitties.DBControllers.Interfaces;
using System;
using System.Collections.Generic;

namespace DanhosEntitties.DBControllers
{
    public class MessageController : Controller<Message>, IMessageController
    {
        public MessageController(DanhosMessagesContext context) : base(context) { }
        protected override Message AddIfNull(Message message) => message; //Message CANNOT be null

        public Message AddMessage(Message message = null) => Insert(AddIfNull(message));

        public IList<Message> GetMessages(Func<Message, bool> predicate) => Get(predicate);
        public Message GetMessage(Func<Message, bool> predicate) => Get(predicate)[0];
        public Message GetMessage(int id) => Get(id);

        public Message UpdateMessage(Message message) => Update(message);
        public Message UpdateMessage(int id) => Update(id);

        public void DeleteMessage(Message message) => Delete(message);
        public void DeleteMessage(int id) => DeleteMessage(id);
    }
}
