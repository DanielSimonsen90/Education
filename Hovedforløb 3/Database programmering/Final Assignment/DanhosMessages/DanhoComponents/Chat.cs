using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DanhoComponents
{
    public class Chat : IID
    {
        [Key]
        public int ID { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public Chat()
        {
            Messages = new HashSet<Message>();
            Users = new HashSet<User>();
        }
    }
}