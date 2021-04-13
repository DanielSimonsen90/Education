using DanhoComponents;
using System;
using System.Collections.Generic;

namespace DanhosEntitties.DBControllers.Interfaces
{
    interface IMessageController
    {
        Message AddMessage(Message message = null);

        IList<Message> GetMessages(Func<Message, bool> predicate);
        Message GetMessage(Func<Message, bool> predicate);
        Message GetMessage(int id);

        Message UpdateMessage(Message message);
        Message UpdateMessage(int id);

        void DeleteMessage(Message message);
        void DeleteMessage(int id);
    }
}
