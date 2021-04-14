using DanhosEntitties.Components;
using DanhosEntitties.DBControllers.Interfaces;
using System;
using System.Collections.Generic;

namespace DanhosEntitties.DBControllers
{
    public class ChatController : Controller<Chat>, IChatController
    {
        public ChatController(DanhosMessagesContext context) : base(context) { }
        protected override Chat AddIfNull(Chat chat) => chat ?? new Chat();

        public Chat AddChat(Chat chat = null) => Insert(AddIfNull(chat));

        public IList<Chat> GetChats(Func<Chat, bool> predicate) => Get(predicate);
        public Chat GetChat(Func<Chat, bool> predicate) => Get(predicate)[0];
        public Chat GetChat(int id) => Get(id);

        public Chat UpdateChat(Chat chat) => Update(chat);
        public Chat UpdateChat(int id) => Update(id);

        public void DeleteChat(Chat chat) => Delete(chat);
        public void DeleteChat(int id) => Delete(id);
    }
}
