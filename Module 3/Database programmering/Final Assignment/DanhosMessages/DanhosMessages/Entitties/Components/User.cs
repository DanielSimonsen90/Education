using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DanhosMessages.Entitties.Components
{
    public class User : HasID
    {
        [Key]
        public override int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Chat> Chats { get; set; }
        public ICollection<Message> Messages { get; set; }

        public User() => Chats = new HashSet<Chat>();
        public User(string name) : this() => Name = name;
    }
}