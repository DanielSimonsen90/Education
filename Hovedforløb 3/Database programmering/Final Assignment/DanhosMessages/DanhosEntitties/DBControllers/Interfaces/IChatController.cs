using DanhosEntitties.Components;
using System;
using System.Collections.Generic;

namespace DanhosEntitties.DBControllers.Interfaces
{
    interface IChatController
    {
        Chat AddChat(Chat chat = null);

        IList<Chat> GetChats(Func<Chat, bool> predicate);
        Chat GetChat(Func<Chat, bool> predicate);
        Chat GetChat(int id);

        Chat UpdateChat(Chat chat);
        Chat UpdateChat(int id);

        void DeleteChat(Chat chat);
        void DeleteChat(int id);
    }
}
