using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DanhosEntitties.Components
{
    public class User : HasID
    {
        [Key]
        public override int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Chat> Chats { get; set; }

        public User() {}
        public User(string name)
        {
            Name = name;
            Chats = new HashSet<Chat>();
        }
    }
}