using System;
using System.Collections.Generic;

namespace DanhoComponents
{
    public class Chat : IID
    {
        public int ID { get; set; }
        public List<Message> Messages { get; set; }
        public List<User> Users { get; set; }

        public Message SendMessage(string content)
        {
            throw new NotImplementedException();
        }
    }
}